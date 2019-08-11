using System;

namespace Models.local
{

	using BaseEntity = Desktop.common.nomitech.common.@base.BaseEntity;
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// @hibernate.class table="LOCFACTOR"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class LocalizationFactorTable : BaseEntity
	{
		private long? id;
		private string parentCode;
		private string groupCodeName;

		private string toCountry;
		private string toState;
		private string toCity;
		private string toZipCode;

		private decimal laborFactor;
		private decimal materialFactor;
		private decimal subcontractorFactor;
		private decimal consumableFactor;
		private decimal equipmentFactor;
		private decimal assemblyFactor;
		private string geoPolygon;
		private string editorId;
		private bool? online;
		private LocalizationProfileTable localizationProfileTable;

		public virtual LocalizationFactorTable Data
		{
			set
			{
				ToCountry = value.ToCountry;
				ToState = value.ToState;
				ToCity = value.ToCity;
				ToZipCode = value.ToZipCode;
				GroupCodeName = value.GroupCodeName;
				ParentCode = value.ParentCode;
				LaborFactor = value.LaborFactor;
				MaterialFactor = value.MaterialFactor;
				SubcontractorFactor = value.SubcontractorFactor;
				ConsumableFactor = value.ConsumableFactor;
				EquipmentFactor = value.EquipmentFactor;
				AssemblyFactor = value.AssemblyFactor;
				EditorId = value.EditorId;
				GeoPolygon = value.GeoPolygon;
				Online = value.Online;
			}
		}

		public virtual object clone()
		{
			LocalizationFactorTable table = new LocalizationFactorTable();

			table.Data = this;
			table.Id = Id;

			return table;
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="LFID" </summary>
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
		/// @hibernate.property column="PARENTECODE" type="costos_string" </summary>
		/// <returns> name </returns>
		public virtual string ParentCode
		{
			get
			{
				return parentCode;
			}
			set
			{
				this.parentCode = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EDITORID" type="costos_string" </summary>
		/// <returns> name </returns>
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
		/// @hibernate.property column="ONLN" type="boolean" </summary>
		/// <returns> name </returns>
		public virtual bool? Online
		{
			get
			{
				return online;
			}
			set
			{
				this.online = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CODETYPE" type="costos_string" </summary>
		/// <returns> name </returns>
		public virtual string GroupCodeName
		{
			get
			{
				return groupCodeName;
			}
			set
			{
				this.groupCodeName = value;
			}
		}



		/// <summary>
		/// @hibernate.property column="TOCOUNTRY" type="costos_string" </summary>
		/// <returns> name </returns>
		public virtual string ToCountry
		{
			get
			{
				return toCountry;
			}
			set
			{
				this.toCountry = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="TOSTATE" type="costos_string" </summary>
		/// <returns> name </returns>
		public virtual string ToState
		{
			get
			{
				return toState;
			}
			set
			{
				this.toState = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="TOCITY" type="costos_string" </summary>
		/// <returns> name </returns>
		public virtual string ToCity
		{
			get
			{
				return toCity;
			}
			set
			{
				this.toCity = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="TOZIPCODE" type="costos_string" </summary>
		/// <returns> name </returns>
		public virtual string ToZipCode
		{
			get
			{
				return toZipCode;
			}
			set
			{
				this.toZipCode = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="LABFAC" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> name </returns>
		public virtual decimal LaborFactor
		{
			get
			{
				return laborFactor;
			}
			set
			{
				this.laborFactor = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="MATFAC" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> name </returns>
		public virtual decimal MaterialFactor
		{
			get
			{
				return materialFactor;
			}
			set
			{
				this.materialFactor = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="SUBFAC" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> name </returns>
		public virtual decimal SubcontractorFactor
		{
			get
			{
				return subcontractorFactor;
			}
			set
			{
				this.subcontractorFactor = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CONFAC" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> name </returns>
		public virtual decimal ConsumableFactor
		{
			get
			{
				return consumableFactor;
			}
			set
			{
				this.consumableFactor = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EQUFAC" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> equipmentFactor </returns>
		public virtual decimal EquipmentFactor
		{
			get
			{
				return equipmentFactor;
			}
			set
			{
				this.equipmentFactor = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ASSFAC" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> assemblyFactor </returns>
		public virtual decimal AssemblyFactor
		{
			get
			{
				return assemblyFactor;
			}
			set
			{
				this.assemblyFactor = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="GEOPOLY" type="costos_text" </summary>
		/// <returns> geoPolygon </returns>
		public virtual string GeoPolygon
		{
			get
			{
				return geoPolygon;
			}
			set
			{
				this.geoPolygon = value;
			}
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="FID" </summary>
		/// <returns> LocalizationProfileTable </returns>
		public virtual LocalizationProfileTable LocalizationProfileTable
		{
			get
			{
				return localizationProfileTable;
			}
			set
			{
				this.localizationProfileTable = value;
			}
		}


		public virtual LocalizationFactorTable copyWithLocalizationProfileTable()
		{
			LocalizationFactorTable factTable = (LocalizationFactorTable) clone();

			if (LocalizationProfileTable != null)
			{
				factTable.LocalizationProfileTable = (LocalizationProfileTable)LocalizationProfileTable.Clone();
			}

			return factTable;
		}
	}

}