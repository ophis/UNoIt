﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.235
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="UNOIT")]
	public partial class EntryHistoryDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    #endregion
		
		public EntryHistoryDataContext() : 
				base(global::DAL.Properties.Settings.Default.UNOITConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public EntryHistoryDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EntryHistoryDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EntryHistoryDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EntryHistoryDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<EntryHistoryView> EntryHistoryView
		{
			get
			{
				return this.GetTable<EntryHistoryView>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.EntryHistoryView")]
	public partial class EntryHistoryView
	{
		
		private int _UserID;
		
		private int _EntryReleasedID;
		
		private int _EntryModifiedID;
		
		private int _EntryEvaluationID;
		
		private int _EntryCommentID;
		
		private int _AdministratorsID;
		
		public EntryHistoryView()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int NOT NULL")]
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
					this._UserID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EntryReleasedID", DbType="Int NOT NULL")]
		public int EntryReleasedID
		{
			get
			{
				return this._EntryReleasedID;
			}
			set
			{
				if ((this._EntryReleasedID != value))
				{
					this._EntryReleasedID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EntryModifiedID", DbType="Int NOT NULL")]
		public int EntryModifiedID
		{
			get
			{
				return this._EntryModifiedID;
			}
			set
			{
				if ((this._EntryModifiedID != value))
				{
					this._EntryModifiedID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EntryEvaluationID", DbType="Int NOT NULL")]
		public int EntryEvaluationID
		{
			get
			{
				return this._EntryEvaluationID;
			}
			set
			{
				if ((this._EntryEvaluationID != value))
				{
					this._EntryEvaluationID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EntryCommentID", DbType="Int NOT NULL")]
		public int EntryCommentID
		{
			get
			{
				return this._EntryCommentID;
			}
			set
			{
				if ((this._EntryCommentID != value))
				{
					this._EntryCommentID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AdministratorsID", DbType="Int NOT NULL")]
		public int AdministratorsID
		{
			get
			{
				return this._AdministratorsID;
			}
			set
			{
				if ((this._AdministratorsID != value))
				{
					this._AdministratorsID = value;
				}
			}
		}
	}
}
#pragma warning restore 1591