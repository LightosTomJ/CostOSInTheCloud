using System;
using System.Collections.Generic;

namespace Models.proj
{

	using BaseEntity = nomitech.common.@base.BaseEntity;
	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	//#RXL_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="IFCELEMENT"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
	public class IfcElementTable : BaseEntity, ProjectIdEntity
	{

		private long? id;
		private string title;
		private string description;

		private string globalId;
		private string location;
		private string label;
		private string type;
		private string material;
		private string layer;
		private string building;
		private string fileName;
		private string ifcFile;
		private string storey;
		private string model;
		private string groupZone;
		private DateTime lastUpdate;

		private string name;
		private string objectType;
		private string color;
		private double? transparency;

		private decimal qty1;
		private string uom1;
		private string qtyName1;

		private decimal qty2;
		private string uom2;
		private string qtyName2;

		private decimal qty3;
		private string uom3;
		private string qtyName3;

		private string applicationName;
		private int? cndId;

		private decimal topElevation;
		private decimal bottomElevation;

		private string parentElementId;
		private string parentSpaceId;

		private bool? isDecomposed;

		private ISet<IfcElementPropertyTable> properties;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="ELEMID" </summary>
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
		/// @hibernate.property column="CNDID" type="int" </summary>
		/// <returns> Integer </returns>
		public virtual int? CndId
		{
			get
			{
				return cndId;
			}
			set
			{
				this.cndId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCID" type="costos_string" index="IDX_IGID" </summary>
		/// <returns> String </returns>
		public virtual string GlobalId
		{
			get
			{
				return globalId;
			}
			set
			{
				this.globalId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCFNAME" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string FileName
		{
			get
			{
				return fileName;
			}
			set
			{
				this.fileName = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCFILE" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string IfcFile
		{
			get
			{
				return ifcFile;
			}
			set
			{
				this.ifcFile = value;
			}
		}
		/// <summary>
		/// @hibernate.property column="IFCLABEL" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Label
		{
			get
			{
				return label;
			}
			set
			{
				this.label = value;
			}
		}
		/// <summary>
		/// @hibernate.property column="IFCLOCATION" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string Location
		{
			get
			{
				return location;
			}
			set
			{
				this.location = value;
			}
		}
		/// <summary>
		/// @hibernate.property column="IFCTYPE" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Type
		{
			get
			{
				return type;
			}
			set
			{
				this.type = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCMATERIAL" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Material
		{
			get
			{
				return material;
			}
			set
			{
				this.material = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCLAYER" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Layer
		{
			get
			{
				return layer;
			}
			set
			{
				this.layer = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCBUILDING" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Building
		{
			get
			{
				return building;
			}
			set
			{
				this.building = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCSTOREY" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Storey
		{
			get
			{
				return storey;
			}
			set
			{
				this.storey = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCMODEL" type="costos_string" index="IDX_IMODEL" </summary>
		/// <returns> String </returns>
		public virtual string Model
		{
			get
			{
				return model;
			}
			set
			{
				this.model = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCZONE" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string GroupZone
		{
			get
			{
				return groupZone;
			}
			set
			{
				this.groupZone = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCDATE" type="date" </summary>
		/// <returns> String </returns>
		public virtual DateTime LastUpdate
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

		/// <summary>
		/// @hibernate.property column="IFCNAME" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Name
		{
			get
			{
				return name;
			}
			set
			{
				this.name = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCOBJECTTYPE" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string ObjectType
		{
			get
			{
				return objectType;
			}
			set
			{
				this.objectType = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCCOLOR" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Color
		{
			get
			{
				return color;
			}
			set
			{
				this.color = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCTRANSPARENCY" type="double" </summary>
		/// <returns> String </returns>
		public virtual double? Transparency
		{
			get
			{
				return transparency;
			}
			set
			{
				this.transparency = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCQTY1" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal Qty1
		{
			get
			{
				return qty1;
			}
			set
			{
				this.qty1 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCUOM1" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Uom1
		{
			get
			{
				return uom1;
			}
			set
			{
				this.uom1 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCQTYNAME1" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string QtyName1
		{
			get
			{
				return qtyName1;
			}
			set
			{
				this.qtyName1 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCQTY2" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal Qty2
		{
			get
			{
				return qty2;
			}
			set
			{
				this.qty2 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCUOM2" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Uom2
		{
			get
			{
				return uom2;
			}
			set
			{
				this.uom2 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCQTYNAME2" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string QtyName2
		{
			get
			{
				return qtyName2;
			}
			set
			{
				this.qtyName2 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCQTY3" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal Qty3
		{
			get
			{
				return qty3;
			}
			set
			{
				this.qty3 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCUOM3" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Uom3
		{
			get
			{
				return uom3;
			}
			set
			{
				this.uom3 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCQTYNAME3" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string QtyName3
		{
			get
			{
				return qtyName3;
			}
			set
			{
				this.qtyName3 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCTITLE" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string Title
		{
			get
			{
				return title;
			}
			set
			{
				this.title = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCDESCRIPTION" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string Description
		{
			get
			{
				return description;
			}
			set
			{
				this.description = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCAPPNAME" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ApplicationName
		{
			get
			{
				return applicationName;
			}
			set
			{
				this.applicationName = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="TOPELEV" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal TopElevation
		{
			get
			{
				return topElevation;
			}
			set
			{
				this.topElevation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="BOTTOMELEV" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal BottomElevation
		{
			get
			{
				return bottomElevation;
			}
			set
			{
				this.bottomElevation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="PARENTID" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string ParentElementId
		{
			get
			{
				return parentElementId;
			}
			set
			{
				this.parentElementId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="DECOMPOSES" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? IsDecomposed
		{
			get
			{
				return isDecomposed;
			}
			set
			{
				this.isDecomposed = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="PARENTSPACEID" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string ParentSpaceId
		{
			get
			{
				return parentSpaceId;
			}
			set
			{
				this.parentSpaceId = value;
			}
		}

		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="ELEMID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.IfcElementPropertyTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<IfcElementPropertyTable> Properties
		{
			get
			{
				return properties;
			}
			set
			{
				this.properties = value;
			}
		}

		private long? projectId;
		//#RXL_START
		/// <summary>
		/// @hibernate.property column="PRJID" type="long" index="IDX_PRJID" </summary>
		/// <returns> BigDecimal </returns>
		//#RXL_END
		public override long? ProjectId
		{
			get
			{
				return projectId;
			}
			set
			{
				this.projectId = value;
			}
		}

	}

}