﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetMSTuto
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PetShopDb")]
	public partial class PetShopDbDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBillTbl(BillTbl instance);
    partial void UpdateBillTbl(BillTbl instance);
    partial void DeleteBillTbl(BillTbl instance);
    partial void InsertEmployeeTbl(EmployeeTbl instance);
    partial void UpdateEmployeeTbl(EmployeeTbl instance);
    partial void DeleteEmployeeTbl(EmployeeTbl instance);
    partial void InsertInvoiceTbl(InvoiceTbl instance);
    partial void UpdateInvoiceTbl(InvoiceTbl instance);
    partial void DeleteInvoiceTbl(InvoiceTbl instance);
    partial void InsertProductTbl(ProductTbl instance);
    partial void UpdateProductTbl(ProductTbl instance);
    partial void DeleteProductTbl(ProductTbl instance);
    partial void InsertUserTbl(UserTbl instance);
    partial void UpdateUserTbl(UserTbl instance);
    partial void DeleteUserTbl(UserTbl instance);
    partial void InsertCustomerTbl(CustomerTbl instance);
    partial void UpdateCustomerTbl(CustomerTbl instance);
    partial void DeleteCustomerTbl(CustomerTbl instance);
    #endregion
		
		public PetShopDbDataContext() : 
				base(global::PetMSTuto.Properties.Settings.Default.PetShopDbConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PetShopDbDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PetShopDbDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PetShopDbDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PetShopDbDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<BillTbl> BillTbls
		{
			get
			{
				return this.GetTable<BillTbl>();
			}
		}
		
		public System.Data.Linq.Table<EmployeeTbl> EmployeeTbls
		{
			get
			{
				return this.GetTable<EmployeeTbl>();
			}
		}
		
		public System.Data.Linq.Table<InvoiceTbl> InvoiceTbls
		{
			get
			{
				return this.GetTable<InvoiceTbl>();
			}
		}
		
		public System.Data.Linq.Table<ProductTbl> ProductTbls
		{
			get
			{
				return this.GetTable<ProductTbl>();
			}
		}
		
		public System.Data.Linq.Table<UserTbl> UserTbls
		{
			get
			{
				return this.GetTable<UserTbl>();
			}
		}
		
		public System.Data.Linq.Table<CustomerTbl> CustomerTbls
		{
			get
			{
				return this.GetTable<CustomerTbl>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BillTbl")]
	public partial class BillTbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BNum;
		
		private System.DateTime _BDate;
		
		private int _CustId;
		
		private string _CustName;
		
		private int _Amt;
		
		private EntityRef<CustomerTbl> _CustomerTbl;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBNumChanging(int value);
    partial void OnBNumChanged();
    partial void OnBDateChanging(System.DateTime value);
    partial void OnBDateChanged();
    partial void OnCustIdChanging(int value);
    partial void OnCustIdChanged();
    partial void OnCustNameChanging(string value);
    partial void OnCustNameChanged();
    partial void OnAmtChanging(int value);
    partial void OnAmtChanged();
    #endregion
		
		public BillTbl()
		{
			this._CustomerTbl = default(EntityRef<CustomerTbl>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BNum", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int BNum
		{
			get
			{
				return this._BNum;
			}
			set
			{
				if ((this._BNum != value))
				{
					this.OnBNumChanging(value);
					this.SendPropertyChanging();
					this._BNum = value;
					this.SendPropertyChanged("BNum");
					this.OnBNumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BDate", DbType="Date NOT NULL")]
		public System.DateTime BDate
		{
			get
			{
				return this._BDate;
			}
			set
			{
				if ((this._BDate != value))
				{
					this.OnBDateChanging(value);
					this.SendPropertyChanging();
					this._BDate = value;
					this.SendPropertyChanged("BDate");
					this.OnBDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustId", DbType="Int NOT NULL")]
		public int CustId
		{
			get
			{
				return this._CustId;
			}
			set
			{
				if ((this._CustId != value))
				{
					if (this._CustomerTbl.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCustIdChanging(value);
					this.SendPropertyChanging();
					this._CustId = value;
					this.SendPropertyChanged("CustId");
					this.OnCustIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string CustName
		{
			get
			{
				return this._CustName;
			}
			set
			{
				if ((this._CustName != value))
				{
					this.OnCustNameChanging(value);
					this.SendPropertyChanging();
					this._CustName = value;
					this.SendPropertyChanged("CustName");
					this.OnCustNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Amt", DbType="Int NOT NULL")]
		public int Amt
		{
			get
			{
				return this._Amt;
			}
			set
			{
				if ((this._Amt != value))
				{
					this.OnAmtChanging(value);
					this.SendPropertyChanging();
					this._Amt = value;
					this.SendPropertyChanged("Amt");
					this.OnAmtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CustomerTbl_BillTbl", Storage="_CustomerTbl", ThisKey="CustId", OtherKey="CustId", IsForeignKey=true)]
		public CustomerTbl CustomerTbl
		{
			get
			{
				return this._CustomerTbl.Entity;
			}
			set
			{
				CustomerTbl previousValue = this._CustomerTbl.Entity;
				if (((previousValue != value) 
							|| (this._CustomerTbl.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._CustomerTbl.Entity = null;
						previousValue.BillTbls.Remove(this);
					}
					this._CustomerTbl.Entity = value;
					if ((value != null))
					{
						value.BillTbls.Add(this);
						this._CustId = value.CustId;
					}
					else
					{
						this._CustId = default(int);
					}
					this.SendPropertyChanged("CustomerTbl");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.EmployeeTbl")]
	public partial class EmployeeTbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _EmpNum;
		
		private string _EmpName;
		
		private string _EmpAdd;
		
		private System.DateTime _EmpDOB;
		
		private string _EmpPhone;
		
		private string _EmpAcc;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEmpNumChanging(int value);
    partial void OnEmpNumChanged();
    partial void OnEmpNameChanging(string value);
    partial void OnEmpNameChanged();
    partial void OnEmpAddChanging(string value);
    partial void OnEmpAddChanged();
    partial void OnEmpDOBChanging(System.DateTime value);
    partial void OnEmpDOBChanged();
    partial void OnEmpPhoneChanging(string value);
    partial void OnEmpPhoneChanged();
    partial void OnEmpAccChanging(string value);
    partial void OnEmpAccChanged();
    #endregion
		
		public EmployeeTbl()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpNum", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int EmpNum
		{
			get
			{
				return this._EmpNum;
			}
			set
			{
				if ((this._EmpNum != value))
				{
					this.OnEmpNumChanging(value);
					this.SendPropertyChanging();
					this._EmpNum = value;
					this.SendPropertyChanged("EmpNum");
					this.OnEmpNumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string EmpName
		{
			get
			{
				return this._EmpName;
			}
			set
			{
				if ((this._EmpName != value))
				{
					this.OnEmpNameChanging(value);
					this.SendPropertyChanging();
					this._EmpName = value;
					this.SendPropertyChanged("EmpName");
					this.OnEmpNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpAdd", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string EmpAdd
		{
			get
			{
				return this._EmpAdd;
			}
			set
			{
				if ((this._EmpAdd != value))
				{
					this.OnEmpAddChanging(value);
					this.SendPropertyChanging();
					this._EmpAdd = value;
					this.SendPropertyChanged("EmpAdd");
					this.OnEmpAddChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpDOB", DbType="Date NOT NULL")]
		public System.DateTime EmpDOB
		{
			get
			{
				return this._EmpDOB;
			}
			set
			{
				if ((this._EmpDOB != value))
				{
					this.OnEmpDOBChanging(value);
					this.SendPropertyChanging();
					this._EmpDOB = value;
					this.SendPropertyChanged("EmpDOB");
					this.OnEmpDOBChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpPhone", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string EmpPhone
		{
			get
			{
				return this._EmpPhone;
			}
			set
			{
				if ((this._EmpPhone != value))
				{
					this.OnEmpPhoneChanging(value);
					this.SendPropertyChanging();
					this._EmpPhone = value;
					this.SendPropertyChanged("EmpPhone");
					this.OnEmpPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpAcc", DbType="NVarChar(50)")]
		public string EmpAcc
		{
			get
			{
				return this._EmpAcc;
			}
			set
			{
				if ((this._EmpAcc != value))
				{
					this.OnEmpAccChanging(value);
					this.SendPropertyChanging();
					this._EmpAcc = value;
					this.SendPropertyChanged("EmpAcc");
					this.OnEmpAccChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.InvoiceTbl")]
	public partial class InvoiceTbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _INum;
		
		private string _PrName;
		
		private int _PrQty;
		
		private int _PrPrice;
		
		private int _Tamt;
		
		private EntityRef<ProductTbl> _ProductTbl;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnINumChanging(int value);
    partial void OnINumChanged();
    partial void OnPrNameChanging(string value);
    partial void OnPrNameChanged();
    partial void OnPrQtyChanging(int value);
    partial void OnPrQtyChanged();
    partial void OnPrPriceChanging(int value);
    partial void OnPrPriceChanged();
    partial void OnTamtChanging(int value);
    partial void OnTamtChanged();
    #endregion
		
		public InvoiceTbl()
		{
			this._ProductTbl = default(EntityRef<ProductTbl>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_INum", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int INum
		{
			get
			{
				return this._INum;
			}
			set
			{
				if ((this._INum != value))
				{
					this.OnINumChanging(value);
					this.SendPropertyChanging();
					this._INum = value;
					this.SendPropertyChanged("INum");
					this.OnINumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PrName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string PrName
		{
			get
			{
				return this._PrName;
			}
			set
			{
				if ((this._PrName != value))
				{
					if (this._ProductTbl.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPrNameChanging(value);
					this.SendPropertyChanging();
					this._PrName = value;
					this.SendPropertyChanged("PrName");
					this.OnPrNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PrQty", DbType="Int NOT NULL")]
		public int PrQty
		{
			get
			{
				return this._PrQty;
			}
			set
			{
				if ((this._PrQty != value))
				{
					this.OnPrQtyChanging(value);
					this.SendPropertyChanging();
					this._PrQty = value;
					this.SendPropertyChanged("PrQty");
					this.OnPrQtyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PrPrice", DbType="Int NOT NULL")]
		public int PrPrice
		{
			get
			{
				return this._PrPrice;
			}
			set
			{
				if ((this._PrPrice != value))
				{
					this.OnPrPriceChanging(value);
					this.SendPropertyChanging();
					this._PrPrice = value;
					this.SendPropertyChanged("PrPrice");
					this.OnPrPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Tamt", DbType="Int NOT NULL")]
		public int Tamt
		{
			get
			{
				return this._Tamt;
			}
			set
			{
				if ((this._Tamt != value))
				{
					this.OnTamtChanging(value);
					this.SendPropertyChanging();
					this._Tamt = value;
					this.SendPropertyChanged("Tamt");
					this.OnTamtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProductTbl_InvoiceTbl", Storage="_ProductTbl", ThisKey="PrName", OtherKey="PrName", IsForeignKey=true)]
		public ProductTbl ProductTbl
		{
			get
			{
				return this._ProductTbl.Entity;
			}
			set
			{
				ProductTbl previousValue = this._ProductTbl.Entity;
				if (((previousValue != value) 
							|| (this._ProductTbl.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ProductTbl.Entity = null;
						previousValue.InvoiceTbls.Remove(this);
					}
					this._ProductTbl.Entity = value;
					if ((value != null))
					{
						value.InvoiceTbls.Add(this);
						this._PrName = value.PrName;
					}
					else
					{
						this._PrName = default(string);
					}
					this.SendPropertyChanged("ProductTbl");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ProductTbl")]
	public partial class ProductTbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _PrId;
		
		private string _PrName;
		
		private string _PrCat;
		
		private int _PrQty;
		
		private int _PrPrice;
		
		private EntitySet<InvoiceTbl> _InvoiceTbls;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPrIdChanging(int value);
    partial void OnPrIdChanged();
    partial void OnPrNameChanging(string value);
    partial void OnPrNameChanged();
    partial void OnPrCatChanging(string value);
    partial void OnPrCatChanged();
    partial void OnPrQtyChanging(int value);
    partial void OnPrQtyChanged();
    partial void OnPrPriceChanging(int value);
    partial void OnPrPriceChanged();
    #endregion
		
		public ProductTbl()
		{
			this._InvoiceTbls = new EntitySet<InvoiceTbl>(new Action<InvoiceTbl>(this.attach_InvoiceTbls), new Action<InvoiceTbl>(this.detach_InvoiceTbls));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PrId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int PrId
		{
			get
			{
				return this._PrId;
			}
			set
			{
				if ((this._PrId != value))
				{
					this.OnPrIdChanging(value);
					this.SendPropertyChanging();
					this._PrId = value;
					this.SendPropertyChanged("PrId");
					this.OnPrIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PrName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string PrName
		{
			get
			{
				return this._PrName;
			}
			set
			{
				if ((this._PrName != value))
				{
					this.OnPrNameChanging(value);
					this.SendPropertyChanging();
					this._PrName = value;
					this.SendPropertyChanged("PrName");
					this.OnPrNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PrCat", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string PrCat
		{
			get
			{
				return this._PrCat;
			}
			set
			{
				if ((this._PrCat != value))
				{
					this.OnPrCatChanging(value);
					this.SendPropertyChanging();
					this._PrCat = value;
					this.SendPropertyChanged("PrCat");
					this.OnPrCatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PrQty", DbType="Int NOT NULL")]
		public int PrQty
		{
			get
			{
				return this._PrQty;
			}
			set
			{
				if ((this._PrQty != value))
				{
					this.OnPrQtyChanging(value);
					this.SendPropertyChanging();
					this._PrQty = value;
					this.SendPropertyChanged("PrQty");
					this.OnPrQtyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PrPrice", DbType="Int NOT NULL")]
		public int PrPrice
		{
			get
			{
				return this._PrPrice;
			}
			set
			{
				if ((this._PrPrice != value))
				{
					this.OnPrPriceChanging(value);
					this.SendPropertyChanging();
					this._PrPrice = value;
					this.SendPropertyChanged("PrPrice");
					this.OnPrPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProductTbl_InvoiceTbl", Storage="_InvoiceTbls", ThisKey="PrName", OtherKey="PrName")]
		public EntitySet<InvoiceTbl> InvoiceTbls
		{
			get
			{
				return this._InvoiceTbls;
			}
			set
			{
				this._InvoiceTbls.Assign(value);
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
		
		private void attach_InvoiceTbls(InvoiceTbl entity)
		{
			this.SendPropertyChanging();
			entity.ProductTbl = this;
		}
		
		private void detach_InvoiceTbls(InvoiceTbl entity)
		{
			this.SendPropertyChanging();
			entity.ProductTbl = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserTbl")]
	public partial class UserTbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserID;
		
		private string _UserAcc;
		
		private string _UserPass;
		
		private string _UserType;
		
		private string _UserName;
		
		private string _UserPhone;
		
		private System.DateTime _UserDOB;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnUserAccChanging(string value);
    partial void OnUserAccChanged();
    partial void OnUserPassChanging(string value);
    partial void OnUserPassChanged();
    partial void OnUserTypeChanging(string value);
    partial void OnUserTypeChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnUserPhoneChanging(string value);
    partial void OnUserPhoneChanged();
    partial void OnUserDOBChanging(System.DateTime value);
    partial void OnUserDOBChanged();
    #endregion
		
		public UserTbl()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserAcc", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string UserAcc
		{
			get
			{
				return this._UserAcc;
			}
			set
			{
				if ((this._UserAcc != value))
				{
					this.OnUserAccChanging(value);
					this.SendPropertyChanging();
					this._UserAcc = value;
					this.SendPropertyChanged("UserAcc");
					this.OnUserAccChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserPass", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string UserPass
		{
			get
			{
				return this._UserPass;
			}
			set
			{
				if ((this._UserPass != value))
				{
					this.OnUserPassChanging(value);
					this.SendPropertyChanging();
					this._UserPass = value;
					this.SendPropertyChanged("UserPass");
					this.OnUserPassChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserType", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string UserType
		{
			get
			{
				return this._UserType;
			}
			set
			{
				if ((this._UserType != value))
				{
					this.OnUserTypeChanging(value);
					this.SendPropertyChanging();
					this._UserType = value;
					this.SendPropertyChanged("UserType");
					this.OnUserTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserPhone", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string UserPhone
		{
			get
			{
				return this._UserPhone;
			}
			set
			{
				if ((this._UserPhone != value))
				{
					this.OnUserPhoneChanging(value);
					this.SendPropertyChanging();
					this._UserPhone = value;
					this.SendPropertyChanged("UserPhone");
					this.OnUserPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserDOB", DbType="Date NOT NULL")]
		public System.DateTime UserDOB
		{
			get
			{
				return this._UserDOB;
			}
			set
			{
				if ((this._UserDOB != value))
				{
					this.OnUserDOBChanging(value);
					this.SendPropertyChanging();
					this._UserDOB = value;
					this.SendPropertyChanged("UserDOB");
					this.OnUserDOBChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CustomerTbl")]
	public partial class CustomerTbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CustId;
		
		private string _CustName;
		
		private string _CustAdd;
		
		private string _CustPhone;
		
		private string _CustType;
		
		private EntitySet<BillTbl> _BillTbls;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCustIdChanging(int value);
    partial void OnCustIdChanged();
    partial void OnCustNameChanging(string value);
    partial void OnCustNameChanged();
    partial void OnCustAddChanging(string value);
    partial void OnCustAddChanged();
    partial void OnCustPhoneChanging(string value);
    partial void OnCustPhoneChanged();
    partial void OnCustTypeChanging(string value);
    partial void OnCustTypeChanged();
    #endregion
		
		public CustomerTbl()
		{
			this._BillTbls = new EntitySet<BillTbl>(new Action<BillTbl>(this.attach_BillTbls), new Action<BillTbl>(this.detach_BillTbls));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CustId
		{
			get
			{
				return this._CustId;
			}
			set
			{
				if ((this._CustId != value))
				{
					this.OnCustIdChanging(value);
					this.SendPropertyChanging();
					this._CustId = value;
					this.SendPropertyChanged("CustId");
					this.OnCustIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string CustName
		{
			get
			{
				return this._CustName;
			}
			set
			{
				if ((this._CustName != value))
				{
					this.OnCustNameChanging(value);
					this.SendPropertyChanging();
					this._CustName = value;
					this.SendPropertyChanged("CustName");
					this.OnCustNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustAdd", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string CustAdd
		{
			get
			{
				return this._CustAdd;
			}
			set
			{
				if ((this._CustAdd != value))
				{
					this.OnCustAddChanging(value);
					this.SendPropertyChanging();
					this._CustAdd = value;
					this.SendPropertyChanged("CustAdd");
					this.OnCustAddChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustPhone", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string CustPhone
		{
			get
			{
				return this._CustPhone;
			}
			set
			{
				if ((this._CustPhone != value))
				{
					this.OnCustPhoneChanging(value);
					this.SendPropertyChanging();
					this._CustPhone = value;
					this.SendPropertyChanged("CustPhone");
					this.OnCustPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustType", DbType="NVarChar(50)")]
		public string CustType
		{
			get
			{
				return this._CustType;
			}
			set
			{
				if ((this._CustType != value))
				{
					this.OnCustTypeChanging(value);
					this.SendPropertyChanging();
					this._CustType = value;
					this.SendPropertyChanged("CustType");
					this.OnCustTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CustomerTbl_BillTbl", Storage="_BillTbls", ThisKey="CustId", OtherKey="CustId")]
		public EntitySet<BillTbl> BillTbls
		{
			get
			{
				return this._BillTbls;
			}
			set
			{
				this._BillTbls.Assign(value);
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
		
		private void attach_BillTbls(BillTbl entity)
		{
			this.SendPropertyChanging();
			entity.CustomerTbl = this;
		}
		
		private void detach_BillTbls(BillTbl entity)
		{
			this.SendPropertyChanging();
			entity.CustomerTbl = null;
		}
	}
}
#pragma warning restore 1591