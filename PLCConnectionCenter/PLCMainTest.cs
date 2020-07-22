using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opc.Ua;
using System.ComponentModel;
using Opc.Ua.Client;
using System.Collections.ObjectModel;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Windows;
using Opc.Ua.Configuration;

namespace PLCConnectionCenter
{
    class PLCMainTest
    {
    }
}
namespace UAClient
{
    public class UAHelper
    {
        #region Private Fields
        //private ApplicationInstance application;
        private ApplicationConfiguration m_configuration;
        private Session m_session;
        private int m_reconnectPeriod = 10;
        private int m_discoverTimeout = 5000;
        private SessionReconnectHandler m_reconnectHandler;
        private CertificateValidationEventHandler m_CertificateValidation;
        private EventHandler m_ReconnectComplete;
        private EventHandler m_ReconnectStarting;
        private EventHandler m_KeepAliveComplete;
        private EventHandler m_ConnectComplete;
        public event MonitoredItemNotificationEventHandler SubscriptionDataChangeEvent = null;
        private Subscription m_subscription;
        //private StatusStrip m_StatusStrip;
        //private ToolStripItem m_ServerStatusLB;
        //private ToolStripItem m_StatusUpateTimeLB;
        #endregion
        #region Public Members
        //public string OpcUaName { get; set; }
        /// <summary>
        /// The name of the session to create.
        /// </summary>
        public string SessionName { get; set; }
        /// <summary>
        /// Gets or sets a flag indicating that the domain checks should be ignored when connecting.
        /// </summary>
        public bool DisableDomainCheck { get; set; }
        /// <summary>
        /// The locales to use when creating the session.
        /// </summary>
        public string[] PreferredLocales { get; set; }
        /// <summary>
        /// The user identity to use when creating the session.
        /// </summary>
        public IUserIdentity UserIdentity { get; set; }
        /// <summary>
        /// The client application configuration.
        /// </summary>
        public ApplicationConfiguration Configuration
        {
            get { return m_configuration; }
            set
            {
                if (!Object.ReferenceEquals(m_configuration, value))
                {
                    if (m_configuration != null)
                    {
                        m_configuration.CertificateValidator.CertificateValidation -= m_CertificateValidation;
                    }
                    m_configuration = value;
                    if (m_configuration != null)
                    {
                        m_configuration.CertificateValidator.CertificateValidation += m_CertificateValidation;
                    }
                }
            }
        }
        /// <summary>
        /// The currently active session.
        /// </summary>
        public Session MySession
        {
            get { return m_session; }
        }
        /// <summary>
        /// The number of seconds between reconnect attempts (0 means reconnect is disabled).
        /// </summary>
        [DefaultValue(10)]
        public int ReconnectPeriod
        {
            get { return m_reconnectPeriod; }
            set { m_reconnectPeriod = value; }
        }
        /// <summary>
        /// Raised when a good keep alive from the server arrives.
        /// </summary>
        public event EventHandler KeepAliveComplete
        {
            add { m_KeepAliveComplete += value; }
            remove { m_KeepAliveComplete -= value; }
        }
        /// <summary>
        /// Raised when a reconnect operation starts.
        /// </summary>
        public event EventHandler ReconnectStarting
        {
            add { m_ReconnectStarting += value; }
            remove { m_ReconnectStarting -= value; }
        }
        /// <summary>
        /// Raised when a reconnect operation completes.
        /// </summary>
        public event EventHandler ReconnectComplete
        {
            add { m_ReconnectComplete += value; }
            remove { m_ReconnectComplete -= value; }
        }
        /// <summary>
        /// Raised after successfully connecting to or disconnecing from a server.
        /// </summary>
        public event EventHandler ConnectComplete
        {
            add { m_ConnectComplete += value; }
            remove { m_ConnectComplete -= value; }
        }
        public UAHelper(string OpcUaName) : this(OpcUaName, string.Empty)
        {
        }
        public UAHelper(string sessionName, ApplicationConfiguration cfg)
        {
            this.SessionName = sessionName;
            if (cfg == null)
            {
                SetDefaultConfiguration();
            }
            else
            {
                this.m_configuration = cfg;
            }
        }
        public UAHelper(string sessionName, string cfgPath)
        {
            this.SessionName = sessionName;
            if (string.IsNullOrEmpty(cfgPath))
            {
                SetDefaultConfiguration();
            }
            else
            {
                LoadConfiguration(cfgPath);
                m_configuration.CertificateValidator = new CertificateValidator();
            }
        }
        private async void LoadConfiguration(string cfgPath)
        {
            m_configuration = await ApplicationConfiguration.Load("Client", ApplicationType.Client);
        }
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
        /// <summary>
        /// Sets the URLs shown in the control.
        /// </summary>
        public void SetAvailableUrls(IList<string> urls)
        {
            //UrlCB.Items.Clear();
            if (urls != null)
            {
                foreach (string url in urls)
                {
                    int index = url.LastIndexOf("/discovery", StringComparison.InvariantCultureIgnoreCase);
                    if (index != -1)
                    {
                        //UrlCB.Items.Add(url.Substring(0, index));
                        continue;
                    }
                    //UrlCB.Items.Add(url);
                }
                //if (UrlCB.Items.Count > 0)
                //{
                // UrlCB.SelectedIndex = 0;
                //}
            }
        }
        /// <summary>
        /// Creates a new session.
        /// </summary>
        /// <returns>The new session object.</returns>
        public async Task<Session> Connect(string serverUrl)
        {
            Session session = await Connect(serverUrl, false);
            return session;
        }
        /// <summary>
        /// Creates a new session.
        /// </summary>
        /// <param name="serverUrl">The URL of a server endpoint.</param>
        /// <param name="useSecurity">Whether to use security.</param>
        /// <returns>The new session object.</returns>
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
        /// Disconnects from the server.
        /// </summary>
        public void Disconnect()
        {
            UpdateStatus(false, DateTime.UtcNow, "Disconnected");
            // stop any reconnect operation.
            if (m_reconnectHandler != null)
            {
                m_reconnectHandler.Dispose();
                m_reconnectHandler = null;
            }
            // disconnect any existing session.
            if (m_session != null)
            {
                m_session.Close(10000);
                m_session = null;
            }
            // raise an event.
            //DoConnectComplete(null); 2018.08.15 注释，没有明白断开连接时为什么要触发连接成功
        }
        ///// <summary>
        ///// Prompts the user to choose a server on another host.
        ///// </summary>
        //public void Discover(string hostName)
        //{
        // string endpointUrl = new DiscoverServerDlg().ShowDialog(m_configuration, hostName);
        // if (endpointUrl != null)
        // {
        // ServerUrl = endpointUrl;
        // }
        //}
        #endregion
        #region Private Methods
        /// <summary>
        /// Raises the connect complete event on the main GUI thread.
        /// </summary>
        private void DoConnectComplete(object state)
        {
            if (m_ConnectComplete != null)
            {
                m_ConnectComplete(this, null);
            }
        }
        /// <summary>
        /// Finds the endpoint that best matches the current settings.
        /// </summary>
        private EndpointDescription SelectEndpoint(string discoveryUrl, bool useSecurity)
        {
            Cursor cuisour = Cursors.Wait;
            try
            {
                // return the selected endpoint.
                return CoreClientUtils.SelectEndpoint(discoveryUrl, useSecurity, m_discoverTimeout);
            }
            finally
            {
                cuisour = Cursors.Arrow;
            }
        }
        #endregion
        #region Event Handlers
        /// <summary>
        /// Updates the status control.
        /// </summary>
        /// <param name="error">Whether the status represents an error.</param>
        /// <param name="time">The time associated with the status.</param>
        /// <param name="status">The status message.</param>
        /// <param name="args">Arguments used to format the status message.</param>
        private void UpdateStatus(bool error, DateTime time, string status, params object[] args)
        {
            //if (m_ServerStatusLB != null)
            //{
            // m_ServerStatusLB.Text = String.Format(status, args);
            // m_ServerStatusLB.ForeColor = (error) ? Color.Red : Color.Empty;
            //}
            //if (m_StatusUpateTimeLB != null)
            //{
            // m_StatusUpateTimeLB.Text = time.ToLocalTime().ToString("hh:mm:ss");
            // m_StatusUpateTimeLB.ForeColor = (error) ? Color.Red : Color.Empty;
            //}
        }
        /// <summary>
        /// Handles a keep alive event from a session.
        /// </summary>
        private void Session_KeepAlive(Session session, KeepAliveEventArgs e)
        {
            //if (this.InvokeRequired)
            //{
            // this.BeginInvoke(new KeepAliveEventHandler(Session_KeepAlive), session, e);
            // return;
            //}
            try
            {
                // check for events from discarded sessions.
                if (!Object.ReferenceEquals(session, m_session))
                {
                    return;
                }
                // start reconnect sequence on communication error.
                if (ServiceResult.IsBad(e.Status))
                {
                    if (m_reconnectPeriod <= 0)
                    {
                        UpdateStatus(true, e.CurrentTime, "Communication Error ({0})", e.Status);
                        return;
                    }
                    UpdateStatus(true, e.CurrentTime, "Reconnecting in {0}s", m_reconnectPeriod);
                    if (m_reconnectHandler == null)
                    {
                        if (m_ReconnectStarting != null)
                        {
                            m_ReconnectStarting(this, e);
                        }
                        m_reconnectHandler = new SessionReconnectHandler();
                        m_reconnectHandler.BeginReconnect(m_session, m_reconnectPeriod * 1000, Server_ReconnectComplete);
                    }
                    return;
                }
                // update status.
                UpdateStatus(false, e.CurrentTime, "Connected [{0}]", session.Endpoint.EndpointUrl);
                // raise any additional notifications.
                if (m_KeepAliveComplete != null)
                {
                    m_KeepAliveComplete(this, e);
                }
            }
            catch (Exception exception)
            {
                //ClientUtils.HandleException("Error", exception);
            }
        }
        ///// <summary>
        ///// Handles a click on the connect button.
        ///// </summary>
        //private async void Server_ConnectMI_Click(object sender, EventArgs e)
        //{
        // try
        // {
        // await Connect();
        // }
        // catch (Exception exception)
        // {
        // ClientUtils.HandleException(this.Text, exception);
        // }
        //}
        /// <summary>
        /// Handles a reconnect event complete from the reconnect handler.
        /// </summary>
        private void Server_ReconnectComplete(object sender, EventArgs e)
        {
            //if (this.InvokeRequired)
            //{
            // this.BeginInvoke(new EventHandler(Server_ReconnectComplete), sender, e);
            // return;
            //}
            try
            {
                // ignore callbacks from discarded objects.
                if (!Object.ReferenceEquals(sender, m_reconnectHandler))
                {
                    return;
                }
                m_session = m_reconnectHandler.Session;
                m_reconnectHandler.Dispose();
                m_reconnectHandler = null;
                // raise any additional notifications.
                if (m_ReconnectComplete != null)
                {
                    m_ReconnectComplete(this, e);
                }
            }
            catch (Exception exception)
            {
                //ClientUtils.HandleException("Error", exception);
            }
        }
        /// <summary>
        /// Handles a certificate validation error.
        /// </summary>
        private void CertificateValidator_CertificateValidation(CertificateValidator sender, CertificateValidationEventArgs e)
        {
            //if (this.InvokeRequired)
            //{
            // this.Invoke(new CertificateValidationEventHandler(CertificateValidator_CertificateValidation), sender, e);
            // return;
            //}
            try
            {
                e.Accept = m_configuration.SecurityConfiguration.AutoAcceptUntrustedCertificates;
                if (!m_configuration.SecurityConfiguration.AutoAcceptUntrustedCertificates)
                {
                    MessageBoxResult result = MessageBox.Show(
                    e.Certificate.Subject,
                    "Untrusted Certificate",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Error
                    );
                    e.Accept = (result == MessageBoxResult.Yes);
                }
            }
            catch (Exception exception)
            {
                //ClientUtils.HandleException("Error", exception);
            }
        }
        #endregion
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
        /// Browses the address space and returns the references found.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="nodesToBrowse">The set of browse operations to perform.</param>
        /// <param name="throwOnError">if set to <c>true</c> a exception will be thrown on an error.</param>
        /// <returns>
        /// The references found. Null if an error occurred.
        /// </returns>
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
        /// Changes the value in the text box to the data type required for the write operation.
        /// </summary>
        /// <returns>A value with the correct type.</returns>
        public object ChangeType(DataValue m_value, string v)
        {
            object value = (m_value != null) ? m_value.Value : null;
            switch (m_value.WrappedValue.TypeInfo.BuiltInType)
            {
                case BuiltInType.Boolean:
                    {
                        value = Convert.ToBoolean(v);
                        break;
                    }
                case BuiltInType.SByte:
                    {
                        value = Convert.ToSByte(v);
                        break;
                    }
                case BuiltInType.Byte:
                    {
                        value = Convert.ToByte(v);
                        break;
                    }
                case BuiltInType.Int16:
                    {
                        value = Convert.ToInt16(v);
                        break;
                    }
                case BuiltInType.UInt16:
                    {
                        value = Convert.ToUInt16(v);
                        break;
                    }
                case BuiltInType.Int32:
                    {
                        value = Convert.ToInt32(v);
                        break;
                    }
                case BuiltInType.UInt32:
                    {
                        value = Convert.ToUInt32(v);
                        break;
                    }
                case BuiltInType.Int64:
                    {
                        value = Convert.ToInt64(v);
                        break;
                    }
                case BuiltInType.UInt64:
                    {
                        value = Convert.ToUInt64(v);
                        break;
                    }
                case BuiltInType.Float:
                    {
                        value = Convert.ToSingle(v);
                        break;
                    }
                case BuiltInType.Double:
                    {
                        value = Convert.ToDouble(v);
                        break;
                    }
                default:
                    {
                        value = v;
                        break;
                    }
            }
            return value;
        }
        /// <summary>
        /// Creates the monitored item.
        /// </summary>
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
            // add the new monitored item.
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
        public bool DeleteMonitoredItem(List<MonitoredItem> monitoredItems)
        {
            bool result = true;
            for (int i = 0; i < monitoredItems.Count; i++)
            {
                monitoredItems[i].Notification -= m_MonitoredItem_Notification;
            }
            if (m_subscription != null)
            {
                m_subscription.RemoveItems(monitoredItems);
                m_subscription.ApplyChanges();
            }
            return result;
        }
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
        protected virtual void m_MonitoredItem_Notification(MonitoredItem monitoreditem, MonitoredItemNotificationEventArgs e)
        {
            this.SubscriptionDataChangeEvent?.Invoke(monitoreditem, e);
        }
    }
}

namespace UAClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private UAHelper ua = null;
        private ItemInfo CurrentSelectedItem = null;
        private List<ItemInfo> SubSelectedItems = new List<ItemInfo>();
        private ObservableCollection<ItemInfo> ItemsConlection = new ObservableCollection<ItemInfo>();
        private ObservableCollection<ItemInfo> SubcriptionItemsConlection = new ObservableCollection<ItemInfo>();
        public MainWindow()
        {
            InitializeComponent();
            ua = new UAHelper("Test");
            ua.SubscriptionDataChangeEvent += Ua_SubscriptionDataChange;
            ua.ConnectComplete += ua_ConnectComplete;
            ua.KeepAliveComplete += ua_KeepAliveComplete;
            ua.ReconnectComplete += ua_ReconnectComplete;
        }
        private void Ua_SubscriptionDataChange(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            MonitoredItemNotification notification = e.NotificationValue as MonitoredItemNotification;
            if (notification == null)
            {
                return;
            }
            ItemInfo tmpItemInfo = GetItemInfo((NodeId)monitoredItem.Handle);
            tmpItemInfo.Value = Utils.Format("{0}", notification.Value.WrappedValue);
            tmpItemInfo.StatusCode = Utils.Format("{0}", notification.Value.StatusCode);
            tmpItemInfo.TimeStamp = Utils.Format("{0:HH:mm:ss.fff}", notification.Value.SourceTimestamp.ToLocalTime());
        }
        private ItemInfo GetItemInfo(NodeId nodeid)
        {
            ItemInfo tmpItemInfo = null;
            lock (SubcriptionItemsConlection)
            {
                foreach (var i in SubcriptionItemsConlection)
                {
                    if (i.Reference.NodeId.ToString().Equals(nodeid.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        tmpItemInfo = i;
                        break;
                    }
                }
            }
            return tmpItemInfo;
        }
        private void ua_ReconnectComplete(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        private void ua_KeepAliveComplete(object sender, EventArgs e)
        {
            //MessageBox.Show("连接成功!");
            ReferenceDescriptionCollection referenceDescriptionCollection = ua.BrowseNodes(ObjectIds.ObjectsFolder);
        }
        private void ua_ConnectComplete(object sender, EventArgs e)
        {
            //MessageBox.Show("连接成功!");
            btnConnect.IsEnabled = false;
            ReferenceDescriptionCollection referenceDescriptionCollection = ua.BrowseNodes(ObjectIds.ObjectsFolder);
            FillTree(referenceDescriptionCollection);
        }
        private async void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            string tmpUrl = tbUrl.Text.Trim();
            if (string.IsNullOrEmpty(tmpUrl))
            {
                MessageBox.Show("地址不能为空", "提示", MessageBoxButton.OK);
                return;
            }
            try
            {
                await ua.Connect(tmpUrl);
            }
            catch (Exception ex)
            {
                ShowMessage("error", ex);
            }
        }
        private void ShowMessage(string caption, Exception e)
        {
            MessageBox.Show(e.Message, caption, MessageBoxButton.OK);
        }
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            ReferenceDescriptionCollection collection = ua.BrowseNodes(ObjectIds.ObjectsFolder);
            //throw new NotImplementedException();
        }
        private void FillTree(List<ReferenceDescription> ls)
        {
            tvNodes.Items.Clear();
            for (int i = 0; i < ls.Count; i++)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = ls[i].DisplayName;
                item.Tag = ls[i];
                item.Items.Add("*");//占位符
                item.Expanded += Item_Expanded;
                item.Selected += SubItem_Selected;
                tvNodes.Items.Add(item);
            }
        }
        private void Item_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.OriginalSource as TreeViewItem;
            item.Items.Clear();
            ReferenceDescription refDes = item.Tag as ReferenceDescription;
            if (refDes == null || refDes.NodeId.IsAbsolute)
            {
                return;
            }
            ReferenceDescriptionCollection nodes = ua.BrowseNodes((NodeId)refDes.NodeId);
            for (int i = 0; i < nodes.Count; i++)
            {
                TreeViewItem subItem = new TreeViewItem();
                subItem.Header = nodes[i].DisplayName;
                subItem.Tag = nodes[i];
                subItem.Items.Add("*");
                subItem.Expanded += Item_Expanded;
                subItem.Selected += SubItem_Selected;
                item.Items.Add(subItem);
            }
        }
        private void SubItem_Selected(object sender, RoutedEventArgs e)
        {
            ItemsConlection.Clear();
            TreeViewItem item = e.OriginalSource as TreeViewItem;
            ReferenceDescription reference = item.Tag as ReferenceDescription;
            DisplayAttributes((NodeId)reference.NodeId);
            //throw new NotImplementedException();
        }
        /// <summary>
        /// Displays the attributes and properties in the attributes view.
        /// </summary>
        /// <param name="sourceId">The NodeId of the Node to browse.</param>
        private void DisplayAttributes(NodeId sourceId)
        {
            //try
            //{
            ReadValueIdCollection nodesToRead = new ReadValueIdCollection();
            // attempt to read all possible attributes.
            for (uint ii = Attributes.NodeClass; ii <= Attributes.UserExecutable; ii++)
            {
                ReadValueId nodeToRead = new ReadValueId();
                nodeToRead.NodeId = sourceId;
                nodeToRead.AttributeId = ii;
                nodesToRead.Add(nodeToRead);
            }
            int startOfProperties = nodesToRead.Count;
            //// find all of the pror of the node.
            //BrowseDescription nodeToBrowse1 = new BrowseDescription();
            //nodeToBrowse1.NodeId = sourceId;
            //nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
            //nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.HasProperty;
            //nodeToBrowse1.IncludeSubtypes = true;
            //nodeToBrowse1.NodeClassMask = 0;
            //nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;
            //BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
            //nodesToBrowse.Add(nodeToBrowse1);
            //// fetch property references from the server.
            //ReferenceDescriptionCollection references = ua.Browse(nodesToBrowse, true);
            ReferenceDescriptionCollection references = ua.BrowseNodes(sourceId);
            if (references == null)
            {
                return;
            }
            for (int ii = 0; ii < references.Count; ii++)
            {
                // ignore external references.
                if (references[ii].NodeId.IsAbsolute)
                {
                    continue;
                }
                ReadValueId nodeToRead = new ReadValueId();
                nodeToRead.NodeId = (NodeId)references[ii].NodeId;
                nodeToRead.AttributeId = Attributes.Value;
                nodesToRead.Add(nodeToRead);
            }
            // read all values.
            DataValueCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;
            ua.MySession.Read(
            null,
            0,
            TimestampsToReturn.Neither,
            nodesToRead,
            out results,
            out diagnosticInfos);
            ClientBase.ValidateResponse(results, nodesToRead);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);
            // process results.
            for (int ii = 0; ii < results.Count; ii++)
            {
                string name = null;
                string datatype = null;
                string value = null;
                ReferenceDescription tmpReferencedes = null;
                DataValue tmpDataValue = results[ii];
                // process attribute value.
                if (ii < startOfProperties)
                {
                    // ignore attributes which are invalid for the node.
                    if (results[ii].StatusCode == StatusCodes.BadAttributeIdInvalid)
                    {
                        continue;
                    }
                    // get the name of the attribute.
                    name = Attributes.GetBrowseName(nodesToRead[ii].AttributeId);
                    // display any unexpected error.
                    if (StatusCode.IsBad(results[ii].StatusCode))
                    {
                        datatype = Utils.Format("{0}", Attributes.GetDataTypeId(nodesToRead[ii].AttributeId));
                        value = Utils.Format("{0}", results[ii].StatusCode);
                    }
                    // display the value.
                    else
                    {
                        TypeInfo typeInfo = TypeInfo.Construct(results[ii].Value);
                        datatype = typeInfo.BuiltInType.ToString();
                        if (typeInfo.ValueRank >= ValueRanks.OneOrMoreDimensions)
                        {
                            datatype += "[]";
                        }
                        value = Utils.Format("{0}", results[ii].Value);
                    }
                }
                // process property value.
                else
                {
                    // ignore properties which are invalid for the node.
                    if (results[ii].StatusCode == StatusCodes.BadNodeIdUnknown)
                    {
                        continue;
                    }
                    // get the name of the property.
                    name = Utils.Format("{0}", references[ii - startOfProperties]);
                    tmpReferencedes = references[ii - startOfProperties];
                    // display any unexpected error.
                    if (StatusCode.IsBad(results[ii].StatusCode))
                    {
                        datatype = String.Empty;
                        value = Utils.Format("{0}", results[ii].StatusCode);
                    }
                    // display the value.
                    else
                    {
                        TypeInfo typeInfo = TypeInfo.Construct(results[ii].Value);
                        datatype = typeInfo.BuiltInType.ToString();
                        if (typeInfo.ValueRank >= ValueRanks.OneOrMoreDimensions)
                        {
                            datatype += "[]";
                        }
                        value = Utils.Format("{0}", results[ii].Value);
                    }
                }
                // add the attribute name/value to the list view.
                ItemInfo tmpModel = new ItemInfo()
                {
                    Name = name,
                    DataType = datatype,
                    Value = value,
                    Reference = tmpReferencedes,
                    ODataValue = tmpDataValue
                };
                ItemsConlection.Add(tmpModel);
            }
            //}
            //catch (Exception e)
            //{
            // Utils.Trace(e, "Unexpected error in '{0}'.", "error"); //待修改
            // return;
            //}
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgDetial.ItemsSource = ItemsConlection;
            dgSub.ItemsSource = SubcriptionItemsConlection;
            //dgDetial.DataContext = ItemsConlection;
        }
        private void DisConnect_Click(object sender, RoutedEventArgs e)
        {
            ua.Disconnect();
            btnConnect.IsEnabled = true;
            tvNodes.Items.Clear();
            ItemsConlection.Clear();
        }
        private void dgDetial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid tmpDg = sender as DataGrid;
            int tmpSelectedIndex = tmpDg.SelectedIndex;
            if (tmpSelectedIndex == -1) return;
            CurrentSelectedItem = ItemsConlection[tmpSelectedIndex]; ;
        }
        private void mi_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentSelectedItem == null)
            {
                MessageBox.Show("请选择要操作的条目!");
                return;
            }
            MenuItem tmpMi = sender as MenuItem;
            switch (tmpMi.Tag)
            {
                case "0": //同步读
                    DataValue readValue = ua.MySession.ReadValue((NodeId)CurrentSelectedItem.Reference.NodeId);
                    CurrentSelectedItem.Value = readValue.Value.ToString();
                    break;
                case "1": //异步读
                    ReadValueIdCollection tmpReads = new ReadValueIdCollection();
                    ReadValueId tmpReadId = new ReadValueId();
                    tmpReadId.NodeId = (NodeId)CurrentSelectedItem.Reference.NodeId;
                    tmpReadId.AttributeId = Attributes.Value;
                    tmpReads.Add(tmpReadId);
                    ua.MySession.BeginRead(null, 0, TimestampsToReturn.Neither, tmpReads, callback, tmpReads);
                    break;
                case "2": //同步写
                    WriteValueWin f = new WriteValueWin(CurrentSelectedItem, ua);
                    f.ShowDialog();
                    break;
                case "3": //异步写
                    break;
                case "4": //订阅
                    lock (SubcriptionItemsConlection)
                    {
                        if (SubcriptionItemsConlection.Contains(CurrentSelectedItem))
                        {
                            MessageBox.Show("订阅列表中已经存在着项！");
                            return;
                        }
                        MonitoredItem tmpMonitoredItem = ua.CreateMonitoredItem((NodeId)CurrentSelectedItem.Reference.NodeId,
                        CurrentSelectedItem.Name);
                        CurrentSelectedItem.MonitoredItem = tmpMonitoredItem;
                        SubcriptionItemsConlection.Add(CurrentSelectedItem);
                    }
                    break;
                case "5": //取消订阅
                    break;
                default:
                    CurrentSelectedItem = null;
                    break;
            }
        }
        private void callback(IAsyncResult ar)
        {
            if (ar.IsCompleted)
            {
                DataValueCollection results;
                DiagnosticInfoCollection diagnosticinfos;
                ReadValueIdCollection tmpReadIds = ar.AsyncState as ReadValueIdCollection;
                ResponseHeader responseHeader = ua.MySession.EndRead(ar, out results, out diagnosticinfos);
                ClientBase.ValidateResponse(results, tmpReadIds);
                ClientBase.ValidateDiagnosticInfos(diagnosticinfos, tmpReadIds);
                CurrentSelectedItem.Value = results[0].Value.ToString();
            }
            //throw new NotImplementedException();
        }
        private bool SubCollectionIsPro = false;
        private void BtnDeleteSub_OnClick(object sender, RoutedEventArgs e)
        {
            SubCollectionIsPro = true;
            if (SubSelectedItems.Count < 1)
            {
                MessageBox.Show("请选择取消订阅的条目!");
                return;
            }
            List<MonitoredItem> tmpMonitors = new List<MonitoredItem>();
            for (int i = 0; i < SubSelectedItems.Count; i++)
            {
                tmpMonitors.Add(SubSelectedItems[i].MonitoredItem);
                lock (SubcriptionItemsConlection)
                {
                    SubcriptionItemsConlection.Remove(SubSelectedItems[i]);
                }
            }
            ua.DeleteMonitoredItem(tmpMonitors);
            SubSelectedItems.Clear();
            SubCollectionIsPro = false;
        }
        private void dgSub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SubCollectionIsPro) return;
            SubSelectedItems.Clear();
            var eOriginalSource = (DataGrid)e.OriginalSource;
            foreach (var item in eOriginalSource.SelectedItems)
            {
                ItemInfo tmpRow = item as ItemInfo;
                if (!SubSelectedItems.Contains(tmpRow))
                {
                    SubSelectedItems.Add(tmpRow);
                }
            }
        }
    }
    public class ItemInfo : INotifyPropertyChanged
    {
        private string _name;
        private string _dataType;
        private string _value;
        public string Name
        {
            get => _name;
            set
            
{
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
            }
public string DataType
        {
            get => _dataType;
            set
            
{
                if (value == _dataType) return;
                _dataType = value;
                OnPropertyChanged();
            }
            }
public string Value
        {
            get => _value;
            set
            
{
                if (value == _value) return;
                _value = value;
                OnPropertyChanged();
            }
            }
private string statueCode;
        public string StatusCode
        {
            get { return statueCode; }
            set
            {
                if (value == statueCode) return;
                statueCode = value;
                OnPropertyChanged();
            }
        }
        private string timeStamp;
        public string TimeStamp
        {
            get { return timeStamp; }
            set
            {
                if (value == timeStamp) return;
                timeStamp = value;
                OnPropertyChanged();
            }
        }
        public MonitoredItem MonitoredItem { get; set; }
        public ReferenceDescription Reference { get; set; }
        public DataValue ODataValue { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

//namespace UAClient
//{
//    /// <summary>
//    /// WriteValueWin.xaml 的交互逻辑
//    /// </summary>
//    public partial class WriteValueWin : Window
//    {
//        private ItemInfo Item = null;
//        private UAHelper Ua = null;
//        public WriteValueWin(ItemInfo item, UAHelper ua)
//        {
//            InitializeComponent();
//            this.Item = item;
//            this.Ua = ua;
//        }
//        private void Button_Click(object sender, RoutedEventArgs e)
//        {
//            string tmpValue = tbValue.Text.Trim();
//            Button tmpBtn = sender as Button;
//            if (tmpBtn.Tag.Equals("0"))
//            {
//                Ua.WriteValue((NodeId)Item.Reference.NodeId, Item.ODataValue, tmpValue);
//            }
//            else
//            {
//                //异步写
//                Ua.BeginWrite((NodeId)Item.Reference.NodeId, Item.ODataValue, tmpValue, calback);
//            }
//        }
//        private void calback(IAsyncResult ar)
//        {
//            StatusCodeCollection results = null;
//            DiagnosticInfoCollection diagnosticinfos = null;
//            if (ar.IsCompleted)
//            {
//                WriteValueCollection writeValues = ar.AsyncState as WriteValueCollection;
//                Ua.MySession.EndWrite(ar, out results, out diagnosticinfos);
//                ClientBase.ValidateResponse(results, writeValues);
//                ClientBase.ValidateDiagnosticInfos(diagnosticinfos, writeValues);
//            }
//            if (StatusCode.IsBad(results[0]))
//            {
//                throw new ServiceResultException(results[0]);
//            }
//            //throw new NotImplementedException();
//        }
//    }
//}
