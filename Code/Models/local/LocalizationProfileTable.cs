using System;
using System.Collections.Generic;

namespace Models.local
{

	using BaseTable = Desktop.common.nomitech.common.@base.BaseTable;
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// @hibernate.class table="LOCPROF"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class LocalizationProfileTable : BaseTable
	{

		private long? id;
		private string profileName;
		private bool? supportsState;
		private string fromCountry;
		private string fromState;
		private IList<LocalizationFactorTable> factors;
		private string editorId;
		private string createUserId;
		private DateTime lastUpdate;
		private DateTime createDate;

		public virtual LocalizationProfileTable Data
		{
			set
			{
				ProfileName = value.ProfileName;
				SupportsState = value.SupportsState;
				EditorId = value.EditorId;
				FromCountry = value.FromCountry;
				FromState = value.FromState;
				//setCreateUserId(getCreateUserId());
				//setLastUpdate(getLastUpdate());
				//setCreateDate(getCreateDate());
    
			}
		}

		public virtual object Clone()
		{
			LocalizationProfileTable table = new LocalizationProfileTable();

			table.Id = Id;
			table.Data = this;
			table.FromCountry = FromCountry;
			table.FromState = FromState;
			table.EditorId = EditorId;
			table.CreateUserId = CreateUserId;
			table.LastUpdate = LastUpdate;
			table.CreateDate = CreateDate;

			return table;
		}

		public virtual object copy()
		{
			LocalizationProfileTable table = (LocalizationProfileTable) Clone();

			table.Factors = new List<LocalizationFactorTable>();

			if (Factors == null)
			{
				return table;
			}

			foreach (LocalizationFactorTable factor in Factors)
			{
				if (factor == null)
				{ // Should not happen
					continue;
				}
				table.Factors.Add((LocalizationFactorTable) factor.clone());
			}

			return table;
		}
		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="FUNCTIONID" </summary>
		/// <returns> Long </returns>
		public virtual long? Id
		{
			get
			{
				return id;
			}
			set
			{
				this.id = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FROMCOUNTRY" type="costos_string" </summary>
		/// <returns> name </returns>
		public virtual string FromCountry
		{
			get
			{
				return fromCountry;
			}
			set
			{
				this.fromCountry = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FROMSTATE" type="costos_string" </summary>
		/// <returns> name </returns>
		public virtual string FromState
		{
			get
			{
				return fromState;
			}
			set
			{
				this.fromState = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="NAME" type="costos_string" </summary>
		/// <returns> profileName </returns>
		public virtual string ProfileName
		{
			get
			{
				return profileName;
			}
			set
			{
				this.profileName = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="SUPSTATE" type="boolean" </summary>
		/// <returns> profileName </returns>
		public virtual bool? SupportsState
		{
			get
			{
				return supportsState;
			}
			set
			{
				this.supportsState = value;
			}
		}

		/// <summary>
		/// @hibernate.list  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="FID"
		/// @hibernate.list-index
		///  column="FACCOUNT"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.LocalizationFactorTable"
		/// return List
		/// </summary>
		public virtual IList<LocalizationFactorTable> Factors
		{
			get
			{
				return factors;
			}
			set
			{
				this.factors = value;
			}
		}

		public override string Title
		{
			get
			{
				return ProfileName;
			}
			set
			{
				ProfileName = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EDITORID" type="costos_string" </summary>
		/// <returns> profileName </returns>
		public virtual string EditorId
		{
			get
			{
				return editorId;
			}
			set
			{
				this.editorId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CREATEUSERID" type="costos_string" </summary>
		/// <returns> profileName </returns>
		public virtual string CreateUserId
		{
			get
			{
				return createUserId;
			}
			set
			{
				this.createUserId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CREATEDATE" type="timestamp" </summary>
		/// <returns> profileName </returns>
		public virtual DateTime CreateDate
		{
			get
			{
				return createDate;
			}
			set
			{
				this.createDate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="LASTUPDATE" type="timestamp" </summary>
		/// <returns> profileName </returns>
		public override DateTime LastUpdate
		{
			get
			{
				return lastUpdate;
			}
			set
			{
				this.lastUpdate = value;
			}
		}

		public override decimal TableRate
		{
			get
			{
				return null;
			}
		}
	}

}