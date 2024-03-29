﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace RFTechnology
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="AHRFKJ")]
	public partial class DataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void InsertUserComputerData(UserComputerData instance);
    partial void UpdateUserComputerData(UserComputerData instance);
    partial void DeleteUserComputerData(UserComputerData instance);
    #endregion
		
		public DataClassesDataContext() : 
				base(global::RFTechnology.Properties.Settings.Default.AHRFKJConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<WxPayInformation> WxPayInformation
		{
			get
			{
				return this.GetTable<WxPayInformation>();
			}
		}
		
		public System.Data.Linq.Table<UserComputerData> UserComputerData
		{
			get
			{
				return this.GetTable<UserComputerData>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AddUserWxPayInformation")]
		public int AddUserWxPayInformation(
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="NetID", DbType="NVarChar(128)")] string netID, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string appid, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string attach, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string bank_type, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> cash_fee, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string cash_fee_type, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string fee_type, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string is_subscribe, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string mch_id, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string nonce_str, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string openid, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string out_trade_no, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string result_code, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string return_code, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string return_msg, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string sign, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> time_end, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> total_fee, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string trade_state, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string trade_state_desc, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string trade_type, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string transaction_id, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Writed", DbType="Int")] ref System.Nullable<int> writed)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), netID, appid, attach, bank_type, cash_fee, cash_fee_type, fee_type, is_subscribe, mch_id, nonce_str, openid, out_trade_no, result_code, return_code, return_msg, sign, time_end, total_fee, trade_state, trade_state_desc, trade_type, transaction_id, writed);
			writed = ((System.Nullable<int>)(result.GetParameterValue(22)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.CheckComputerWithRegInformation")]
		public int CheckComputerWithRegInformation([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserNetBoardID", DbType="NVarChar(128)")] string userNetBoardID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userNetBoardID);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.CreateNewReginformation")]
		public ISingleResult<CreateNewReginformationResult> CreateNewReginformation([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ComputerName", DbType="NVarChar(128)")] string computerName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NetBoardID", DbType="NVarChar(128)")] string netBoardID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="BIOSID", DbType="NVarChar(128)")] string bIOSID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CPUID", DbType="NVarChar(MAX)")] string cPUID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DiskID", DbType="NVarChar(MAX)")] string diskID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="BoardID", DbType="NVarChar(128)")] string boardID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="KeyCode", DbType="NVarChar(128)")] string keyCode, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="SubmitTime", DbType="DateTime")] System.Nullable<System.DateTime> submitTime)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), computerName, netBoardID, bIOSID, cPUID, diskID, boardID, keyCode, submitTime);
			return ((ISingleResult<CreateNewReginformationResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.UpdataUserLogTime")]
		public int UpdataUserLogTime([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserNetBoardID", DbType="NVarChar(128)")] string userNetBoardID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userNetBoardID);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetDbAllDataWithCurrentPC")]
		public int GetDbAllDataWithCurrentPC([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserNetBoardID", DbType="NVarChar(128)")] string userNetBoardID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="KeyCode", DbType="NVarChar(128)")] ref string keyCode, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CreateTime", DbType="DateTime")] ref System.Nullable<System.DateTime> createTime, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="RegPayFinishedTime", DbType="DateTime")] ref System.Nullable<System.DateTime> regPayFinishedTime, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="LastLogTime", DbType="DateTime")] ref System.Nullable<System.DateTime> lastLogTime, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="RegPayDays", DbType="Int")] ref System.Nullable<int> regPayDays, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ValidServerEndTime", DbType="DateTime")] ref System.Nullable<System.DateTime> validServerEndTime)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userNetBoardID, keyCode, createTime, regPayFinishedTime, lastLogTime, regPayDays, validServerEndTime);
			keyCode = ((string)(result.GetParameterValue(1)));
			createTime = ((System.Nullable<System.DateTime>)(result.GetParameterValue(2)));
			regPayFinishedTime = ((System.Nullable<System.DateTime>)(result.GetParameterValue(3)));
			lastLogTime = ((System.Nullable<System.DateTime>)(result.GetParameterValue(4)));
			regPayDays = ((System.Nullable<int>)(result.GetParameterValue(5)));
			validServerEndTime = ((System.Nullable<System.DateTime>)(result.GetParameterValue(6)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.UpataUserPayInformation")]
		public int UpataUserPayInformation([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserNetBoardID", DbType="NVarChar(128)")] string userNetBoardID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="RegPayDays", DbType="Int")] System.Nullable<int> regPayDays)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userNetBoardID, regPayDays);
			return ((int)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.WxPayInformation")]
	public partial class WxPayInformation
	{
		
		private string _ID;
		
		private string _NetID;
		
		private string _device_info;
		
		private string _openid;
		
		private string _is_subscribe;
		
		private string _trade_type;
		
		private string _trade_state;
		
		private string _bank_type;
		
		private System.Nullable<int> _total_fee;
		
		private System.Nullable<int> _settlement_total_fee;
		
		private string _fee_type;
		
		private System.Nullable<int> _cash_fee;
		
		private string _cash_fee_type;
		
		private System.Nullable<int> _coupon_fee;
		
		private System.Nullable<int> _coupon_count;
		
		private string _coupon_type__n;
		
		private string _coupon_id__n;
		
		private System.Nullable<int> _coupon_fee__n;
		
		private string _transaction_id;
		
		private string _out_trade_no;
		
		private string _attach;
		
		private string _time_end;
		
		private string _trade_state_desc;
		
		public WxPayInformation()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="NVarChar(128)")]
		public string ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NetID", DbType="NVarChar(128)")]
		public string NetID
		{
			get
			{
				return this._NetID;
			}
			set
			{
				if ((this._NetID != value))
				{
					this._NetID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_device_info", DbType="NVarChar(128)")]
		public string device_info
		{
			get
			{
				return this._device_info;
			}
			set
			{
				if ((this._device_info != value))
				{
					this._device_info = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_openid", DbType="NVarChar(128)")]
		public string openid
		{
			get
			{
				return this._openid;
			}
			set
			{
				if ((this._openid != value))
				{
					this._openid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_is_subscribe", DbType="NVarChar(128)")]
		public string is_subscribe
		{
			get
			{
				return this._is_subscribe;
			}
			set
			{
				if ((this._is_subscribe != value))
				{
					this._is_subscribe = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_trade_type", DbType="NVarChar(128)")]
		public string trade_type
		{
			get
			{
				return this._trade_type;
			}
			set
			{
				if ((this._trade_type != value))
				{
					this._trade_type = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_trade_state", DbType="NVarChar(128)")]
		public string trade_state
		{
			get
			{
				return this._trade_state;
			}
			set
			{
				if ((this._trade_state != value))
				{
					this._trade_state = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_bank_type", DbType="NVarChar(128)")]
		public string bank_type
		{
			get
			{
				return this._bank_type;
			}
			set
			{
				if ((this._bank_type != value))
				{
					this._bank_type = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_total_fee", DbType="Int")]
		public System.Nullable<int> total_fee
		{
			get
			{
				return this._total_fee;
			}
			set
			{
				if ((this._total_fee != value))
				{
					this._total_fee = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_settlement_total_fee", DbType="Int")]
		public System.Nullable<int> settlement_total_fee
		{
			get
			{
				return this._settlement_total_fee;
			}
			set
			{
				if ((this._settlement_total_fee != value))
				{
					this._settlement_total_fee = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fee_type", DbType="NVarChar(128)")]
		public string fee_type
		{
			get
			{
				return this._fee_type;
			}
			set
			{
				if ((this._fee_type != value))
				{
					this._fee_type = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cash_fee", DbType="Int")]
		public System.Nullable<int> cash_fee
		{
			get
			{
				return this._cash_fee;
			}
			set
			{
				if ((this._cash_fee != value))
				{
					this._cash_fee = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cash_fee_type", DbType="NVarChar(128)")]
		public string cash_fee_type
		{
			get
			{
				return this._cash_fee_type;
			}
			set
			{
				if ((this._cash_fee_type != value))
				{
					this._cash_fee_type = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_coupon_fee", DbType="Int")]
		public System.Nullable<int> coupon_fee
		{
			get
			{
				return this._coupon_fee;
			}
			set
			{
				if ((this._coupon_fee != value))
				{
					this._coupon_fee = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_coupon_count", DbType="Int")]
		public System.Nullable<int> coupon_count
		{
			get
			{
				return this._coupon_count;
			}
			set
			{
				if ((this._coupon_count != value))
				{
					this._coupon_count = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="coupon_type_$n", Storage="_coupon_type__n", DbType="NVarChar(128)")]
		public string coupon_type__n
		{
			get
			{
				return this._coupon_type__n;
			}
			set
			{
				if ((this._coupon_type__n != value))
				{
					this._coupon_type__n = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="coupon_id_$n", Storage="_coupon_id__n", DbType="NVarChar(128)")]
		public string coupon_id__n
		{
			get
			{
				return this._coupon_id__n;
			}
			set
			{
				if ((this._coupon_id__n != value))
				{
					this._coupon_id__n = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="coupon_fee_$n", Storage="_coupon_fee__n", DbType="Int")]
		public System.Nullable<int> coupon_fee__n
		{
			get
			{
				return this._coupon_fee__n;
			}
			set
			{
				if ((this._coupon_fee__n != value))
				{
					this._coupon_fee__n = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_transaction_id", DbType="NVarChar(128)")]
		public string transaction_id
		{
			get
			{
				return this._transaction_id;
			}
			set
			{
				if ((this._transaction_id != value))
				{
					this._transaction_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_out_trade_no", DbType="NVarChar(128)")]
		public string out_trade_no
		{
			get
			{
				return this._out_trade_no;
			}
			set
			{
				if ((this._out_trade_no != value))
				{
					this._out_trade_no = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_attach", DbType="NVarChar(128)")]
		public string attach
		{
			get
			{
				return this._attach;
			}
			set
			{
				if ((this._attach != value))
				{
					this._attach = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_time_end", DbType="NVarChar(128)")]
		public string time_end
		{
			get
			{
				return this._time_end;
			}
			set
			{
				if ((this._time_end != value))
				{
					this._time_end = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_trade_state_desc", DbType="NVarChar(128)")]
		public string trade_state_desc
		{
			get
			{
				return this._trade_state_desc;
			}
			set
			{
				if ((this._trade_state_desc != value))
				{
					this._trade_state_desc = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserComputerData")]
	public partial class UserComputerData : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _ID;
		
		private string _ComputerName;
		
		private string _NetID;
		
		private string _CPUID;
		
		private string _BoardID;
		
		private string _BIOSID;
		
		private string _DiskID;
		
		private System.Nullable<System.DateTime> _CreateTime;
		
		private System.Nullable<int> _RegPayDays;
		
		private System.Nullable<System.DateTime> _RegPayFinishedTime;
		
		private System.Nullable<System.DateTime> _PushedEndTime;
		
		private System.Nullable<System.DateTime> _LastLogTime;
		
		private string _KeyCode;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(string value);
    partial void OnIDChanged();
    partial void OnComputerNameChanging(string value);
    partial void OnComputerNameChanged();
    partial void OnNetIDChanging(string value);
    partial void OnNetIDChanged();
    partial void OnCPUIDChanging(string value);
    partial void OnCPUIDChanged();
    partial void OnBoardIDChanging(string value);
    partial void OnBoardIDChanged();
    partial void OnBIOSIDChanging(string value);
    partial void OnBIOSIDChanged();
    partial void OnDiskIDChanging(string value);
    partial void OnDiskIDChanged();
    partial void OnCreateTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnCreateTimeChanged();
    partial void OnRegPayDaysChanging(System.Nullable<int> value);
    partial void OnRegPayDaysChanged();
    partial void OnRegPayFinishedTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnRegPayFinishedTimeChanged();
    partial void OnPushedEndTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnPushedEndTimeChanged();
    partial void OnLastLogTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnLastLogTimeChanged();
    partial void OnKeyCodeChanging(string value);
    partial void OnKeyCodeChanged();
    #endregion
		
		public UserComputerData()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="NVarChar(128) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ComputerName", DbType="NVarChar(128)")]
		public string ComputerName
		{
			get
			{
				return this._ComputerName;
			}
			set
			{
				if ((this._ComputerName != value))
				{
					this.OnComputerNameChanging(value);
					this.SendPropertyChanging();
					this._ComputerName = value;
					this.SendPropertyChanged("ComputerName");
					this.OnComputerNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NetID", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string NetID
		{
			get
			{
				return this._NetID;
			}
			set
			{
				if ((this._NetID != value))
				{
					this.OnNetIDChanging(value);
					this.SendPropertyChanging();
					this._NetID = value;
					this.SendPropertyChanged("NetID");
					this.OnNetIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CPUID", DbType="NChar(50)")]
		public string CPUID
		{
			get
			{
				return this._CPUID;
			}
			set
			{
				if ((this._CPUID != value))
				{
					this.OnCPUIDChanging(value);
					this.SendPropertyChanging();
					this._CPUID = value;
					this.SendPropertyChanged("CPUID");
					this.OnCPUIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BoardID", DbType="NChar(50)")]
		public string BoardID
		{
			get
			{
				return this._BoardID;
			}
			set
			{
				if ((this._BoardID != value))
				{
					this.OnBoardIDChanging(value);
					this.SendPropertyChanging();
					this._BoardID = value;
					this.SendPropertyChanged("BoardID");
					this.OnBoardIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BIOSID", DbType="NChar(50)")]
		public string BIOSID
		{
			get
			{
				return this._BIOSID;
			}
			set
			{
				if ((this._BIOSID != value))
				{
					this.OnBIOSIDChanging(value);
					this.SendPropertyChanging();
					this._BIOSID = value;
					this.SendPropertyChanged("BIOSID");
					this.OnBIOSIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiskID", DbType="NChar(50)")]
		public string DiskID
		{
			get
			{
				return this._DiskID;
			}
			set
			{
				if ((this._DiskID != value))
				{
					this.OnDiskIDChanging(value);
					this.SendPropertyChanging();
					this._DiskID = value;
					this.SendPropertyChanged("DiskID");
					this.OnDiskIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> CreateTime
		{
			get
			{
				return this._CreateTime;
			}
			set
			{
				if ((this._CreateTime != value))
				{
					this.OnCreateTimeChanging(value);
					this.SendPropertyChanging();
					this._CreateTime = value;
					this.SendPropertyChanged("CreateTime");
					this.OnCreateTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RegPayDays", DbType="Int")]
		public System.Nullable<int> RegPayDays
		{
			get
			{
				return this._RegPayDays;
			}
			set
			{
				if ((this._RegPayDays != value))
				{
					this.OnRegPayDaysChanging(value);
					this.SendPropertyChanging();
					this._RegPayDays = value;
					this.SendPropertyChanged("RegPayDays");
					this.OnRegPayDaysChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RegPayFinishedTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> RegPayFinishedTime
		{
			get
			{
				return this._RegPayFinishedTime;
			}
			set
			{
				if ((this._RegPayFinishedTime != value))
				{
					this.OnRegPayFinishedTimeChanging(value);
					this.SendPropertyChanging();
					this._RegPayFinishedTime = value;
					this.SendPropertyChanged("RegPayFinishedTime");
					this.OnRegPayFinishedTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PushedEndTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> PushedEndTime
		{
			get
			{
				return this._PushedEndTime;
			}
			set
			{
				if ((this._PushedEndTime != value))
				{
					this.OnPushedEndTimeChanging(value);
					this.SendPropertyChanging();
					this._PushedEndTime = value;
					this.SendPropertyChanged("PushedEndTime");
					this.OnPushedEndTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastLogTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> LastLogTime
		{
			get
			{
				return this._LastLogTime;
			}
			set
			{
				if ((this._LastLogTime != value))
				{
					this.OnLastLogTimeChanging(value);
					this.SendPropertyChanging();
					this._LastLogTime = value;
					this.SendPropertyChanged("LastLogTime");
					this.OnLastLogTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KeyCode", DbType="NChar(128)")]
		public string KeyCode
		{
			get
			{
				return this._KeyCode;
			}
			set
			{
				if ((this._KeyCode != value))
				{
					this.OnKeyCodeChanging(value);
					this.SendPropertyChanging();
					this._KeyCode = value;
					this.SendPropertyChanged("KeyCode");
					this.OnKeyCodeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	public partial class CreateNewReginformationResult
	{
		
		private System.Nullable<System.DateTime> _Column1;
		
		public CreateNewReginformationResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="", Storage="_Column1", DbType="DateTime")]
		public System.Nullable<System.DateTime> Column1
		{
			get
			{
				return this._Column1;
			}
			set
			{
				if ((this._Column1 != value))
				{
					this._Column1 = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
