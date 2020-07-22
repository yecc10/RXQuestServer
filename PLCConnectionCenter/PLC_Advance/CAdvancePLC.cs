using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.UaFx.Client;
using Opc.Ua;
using Opc.Ua.Configuration;
using Opc.Ua.Client;
namespace RXQuestServer.PLC_Advance
{
    public partial class CAdvancePLC : Form
    {
        Subscription m_subscription = null;
        public CAdvancePLC()
        {
            InitializeComponent();
        }
        private void ConnectPLC_Click(object sender, EventArgs e)
        {
            //异步读
            ReadValueIdCollection tmpReads = new ReadValueIdCollection();
            ReadValueId tmpReadId = new ReadValueId();
            tmpReadId.NodeId = (NodeId)CurrentSelectedItem.Reference.NodeId;
            tmpReadId.AttributeId = Attributes.Value;
            tmpReads.Add(tmpReadId);
            ua.MySession.BeginRead(null, 0, TimestampsToReturn.Neither, tmpReads, callback, tmpReads);
            //同步读
            DataValue readValue = ua.MySession.ReadValue((NodeId)CurrentSelectedItem.Reference.NodeId);
            CurrentSelectedItem.Value = readValue.Value.ToString();
        }
        public MonitoredItem CreateMonitoredItem(NodeId nodeId, string displayName)
        {
            if (m_subscription == null)
            {
                m_subscription = new Subscription(m_session.DefaultSubscription);
                m_subscription.PublishingEnabled = true;
                m_subscription.PublishingInterval = 1000;
                m_subscription.KeepAliveCount = 10;
                m_subscription.LifetimeCount = 10;
                m_subscription.MaxNotificationsPerPublish = 1000;
                m_subscription.Priority = 100;
                m_session.AddSubscription(m_subscription);
                m_subscription.Create();
            }
            // add the new monitored item
            MonitoredItem monitoredItem = new MonitoredItem(m_subscription.DefaultItem);
            monitoredItem.StartNodeId = nodeId;
            monitoredItem.AttributeId = Attributes.Value;
            monitoredItem.DisplayName = displayName;
            monitoredItem.MonitoringMode = MonitoringMode.Reporting;
            monitoredItem.SamplingInterval = 1000;
            monitoredItem.QueueSize = 0;
            monitoredItem.DiscardOldest = true;
            monitoredItem.Handle = nodeId;
            monitoredItem.Notification += m_MonitoredItem_Notification;
            m_subscription.AddItem(monitoredItem);
            m_subscription.ApplyChanges();
            if (ServiceResult.IsBad(monitoredItem.Status.Error))
            {
                string tmpStr = monitoredItem.Status.Error.StatusCode.ToString();
            }
            return monitoredItem;
        }
        //订阅回调
        protected virtual void m_MonitoredItem_Notification(MonitoredItem monitoreditem, MonitoredItemNotificationEventArgs e)
        {
            this.SubscriptionDataChangeEvent?.Invoke(monitoreditem, e);
        }
        /// <summary>
        /// 异步写
        /// </summary>
        /// <param name="nodeid"></param>
        /// <param name="dataValue"></param>
        /// <param name="oValue"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public bool BeginWrite(NodeId nodeid, DataValue dataValue, string oValue, AsyncCallback callback)
        {
            bool result = true;
            WriteValueCollection writeValues = new WriteValueCollection();
            WriteValue writeValue = new WriteValue();
            writeValue.NodeId = nodeid;
            writeValue.AttributeId = Attributes.Value;
            writeValue.Value.Value = ChangeType(dataValue, oValue);
            writeValue.Value.StatusCode = StatusCodes.Good;
            writeValue.Value.ServerTimestamp = DateTime.MinValue;
            writeValue.Value.SourceTimestamp = DateTime.MinValue;
            writeValues.Add(writeValue);
            MySession.BeginWrite(null, writeValues, callback, writeValues);
            return result;
        }
        /// <summary>
        /// 同步写
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="dataValue"></param>
        /// <param name="oValue"></param>
        /// <returns></returns>
        public bool WriteValue(NodeId nodeId, DataValue dataValue, string oValue)
        {
            bool result = true;
            WriteValueCollection writeValues = new WriteValueCollection();
            WriteValue writeValue = new WriteValue();
            writeValue.NodeId = nodeId;
            writeValue.AttributeId = Attributes.Value;
            writeValue.Value.Value = ChangeType(dataValue, oValue);
            writeValue.Value.StatusCode = StatusCodes.Good;
            writeValue.Value.ServerTimestamp = DateTime.MinValue;
            writeValue.Value.SourceTimestamp = DateTime.MinValue;
            writeValues.Add(writeValue);
            StatusCodeCollection results;
            DiagnosticInfoCollection diagnosticinfos;
            MySession.Write(null, writeValues, out results, out diagnosticinfos);
            ClientBase.ValidateResponse(results, writeValues);
            ClientBase.ValidateDiagnosticInfos(diagnosticinfos, writeValues);
            if (StatusCode.IsBad(results[0]))
            {
                throw new ServiceResultException(results[0]);
            }
            return result;
        }
        /// <summary>
        /// 读取节点下所有子节点
        /// </summary>
        /// <param name="nodesToBrowse"></param>
        /// <param name="throwOnError"></param>
        /// <returns></returns>
        public ReferenceDescriptionCollection Browse(BrowseDescriptionCollection nodesToBrowse, bool throwOnError)
        {
            try
            {
                ReferenceDescriptionCollection references = new ReferenceDescriptionCollection();
                BrowseDescriptionCollection unprocessedOperations = new BrowseDescriptionCollection();
                while (nodesToBrowse.Count > 0)
                {
                    // start the browse operation.
                    BrowseResultCollection results = null;
                    DiagnosticInfoCollection diagnosticInfos = null;
                    m_session.Browse(
                    null,
                    null,
                    0,
                    nodesToBrowse,
                    out results,
                    out diagnosticInfos);
                    ClientBase.ValidateResponse(results, nodesToBrowse);
                    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToBrowse);
                    ByteStringCollection continuationPoints = new ByteStringCollection();
                    for (int ii = 0; ii < nodesToBrowse.Count; ii++)
                    {
                        // check for error.
                        if (StatusCode.IsBad(results[ii].StatusCode))
                        {
                            // this error indicates that the server does not have enough simultaneously active
                            // continuation points. This request will need to be resent after the other operations
                            // have been completed and their continuation points released.
                            if (results[ii].StatusCode == StatusCodes.BadNoContinuationPoints)
                            {
                                unprocessedOperations.Add(nodesToBrowse[ii]);
                            }
                            continue;
                        }
                        // check if all references have been fetched.
                        if (results[ii].References.Count == 0)
                        {
                            continue;
                        }
                        // save results.
                        references.AddRange(results[ii].References);
                        // check for continuation point.
                        if (results[ii].ContinuationPoint != null)
                        {
                            continuationPoints.Add(results[ii].ContinuationPoint);
                        }
                    }
                    // process continuation points.
                    ByteStringCollection revisedContiuationPoints = new ByteStringCollection();
                    while (continuationPoints.Count > 0)
                    {
                        // continue browse operation.
                        m_session.BrowseNext(
                        null,
                        false,
                        continuationPoints,
                        out results,
                        out diagnosticInfos);
                        ClientBase.ValidateResponse(results, continuationPoints);
                        ClientBase.ValidateDiagnosticInfos(diagnosticInfos, continuationPoints);
                        for (int ii = 0; ii < continuationPoints.Count; ii++)
                        {
                            // check for error.
                            if (StatusCode.IsBad(results[ii].StatusCode))
                            {
                                continue;
                            }
                            // check if all references have been fetched.
                            if (results[ii].References.Count == 0)
                            {
                                continue;
                            }
                            // save results.
                            references.AddRange(results[ii].References);
                            // check for continuation point.
                            if (results[ii].ContinuationPoint != null)
                            {
                                revisedContiuationPoints.Add(results[ii].ContinuationPoint);
                            }
                        }
                        // check if browsing must continue;
                        revisedContiuationPoints = continuationPoints;
                    }
                    // check if unprocessed results exist.
                    nodesToBrowse = unprocessedOperations;
                }
                // return complete list.
                return references;
            }
            catch (Exception exception)
            {
                if (throwOnError)
                {
                    throw new ServiceResultException(exception, StatusCodes.BadUnexpectedError);
                }
                return null;
            }
        }
        /// <summary>
        /// 浏览节点
        /// </summary>
        /// <param name="sourceId"></param>
        /// <returns></returns>
        public ReferenceDescriptionCollection BrowseNodes(NodeId sourceId)
        {
            m_session = this.MySession;
            if (m_session == null)
            {
                return null;
            }
            // set a suitable initial state.
            //if (m_session != null && !m_connectedOnce)
            //{
            // m_connectedOnce = true;
            //}
            // fetch references from the server.
            // find all of the components of the node.
            BrowseDescription nodeToBrowse1 = new BrowseDescription();
            nodeToBrowse1.NodeId = sourceId;
            nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
            nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.Aggregates;
            nodeToBrowse1.IncludeSubtypes = true;
            nodeToBrowse1.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable);
            nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;
            Browser bro = new Browser(m_session);
            ReferenceDescriptionCollection references = bro.Browse(sourceId);
            return references;
        }
        /// <summary>
        /// 连接UA 服务器
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <param name="useSecurity"></param>
        /// <returns></returns>
        public async Task<Session> Connect(string serverUrl, bool useSecurity)
        {
            // disconnect from existing session.
            Disconnect();
            if (m_configuration == null)
            {
                throw new ArgumentNullException("m_configuration");
            }
            // select the best endpoint.
            EndpointDescription endpointDescription = CoreClientUtils.SelectEndpoint(serverUrl, useSecurity, m_discoverTimeout);
            EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(m_configuration);
            ConfiguredEndpoint endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);
            m_session = await Session.Create(
            m_configuration,
            endpoint,
            false,
            !DisableDomainCheck,
            (String.IsNullOrEmpty(SessionName)) ? m_configuration.ApplicationName : SessionName,
            60000,
            UserIdentity,
            PreferredLocales);
            // set up keep alive callback.
            m_session.KeepAlive += new KeepAliveEventHandler(Session_KeepAlive);
            // raise an event.
            DoConnectComplete(null);
            // return the new session.
            return m_session;
        }
        /// <summary>
        /// 初始化配置
        /// </summary>
        private void SetDefaultConfiguration()
        {
            var certificateValidator = new CertificateValidator();
            certificateValidator.CertificateValidation += (sender, eventArgs) =>
            {
                if (ServiceResult.IsGood(eventArgs.Error))
                    eventArgs.Accept = true;
                else if ((eventArgs.Error.StatusCode.Code == StatusCodes.BadCertificateUntrusted) && true)
                    eventArgs.Accept = true;
                else
                    throw new Exception(string.Format("Failed to validate certificate with error code {0}: {1}", eventArgs.Error.Code, eventArgs.Error.AdditionalInfo));
            };
            m_configuration = new ApplicationConfiguration()
            {
                ApplicationUri = "",
                ApplicationName = "Client",
                ApplicationType = ApplicationType.Client,
                CertificateValidator = certificateValidator,
                ServerConfiguration = new ServerConfiguration
                {
                    MaxSubscriptionCount = 10000,
                    MaxMessageQueueSize = 10000,
                    MaxNotificationQueueSize = 10000,
                    MaxPublishRequestCount = 10000
                },
                SecurityConfiguration = new SecurityConfiguration
                {
                    AutoAcceptUntrustedCertificates = true,
                },
                TransportQuotas = new TransportQuotas
                {
                    OperationTimeout = 600000,
                    MaxStringLength = 1048576,
                    MaxByteStringLength = 1048576,
                    MaxArrayLength = 65535,
                    MaxMessageSize = 4194304,
                    MaxBufferSize = 65535,
                    ChannelLifetime = 600000,
                    SecurityTokenLifetime = 3600000
                },
                ClientConfiguration = new ClientConfiguration
                {
                    DefaultSessionTimeout = 60000,
                    MinSubscriptionLifetime = 10000
                },
                DisableHiResClock = true
            };
        }
    }
}
