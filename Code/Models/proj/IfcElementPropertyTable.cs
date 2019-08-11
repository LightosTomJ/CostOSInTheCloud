namespace Models.proj
{

	using BaseEntity = nomitech.common.@base.BaseEntity;
	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	//#RXL_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="IFCPROPERTY"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
	public class IfcElementPropertyTable : BaseEntity, ProjectIdEntity
	{

		private long? id;
		private string groupName;
		private string name;
		private int? qtyType;
		private bool? number;
		private string value;
		private decimal numberValue;
		private string metricUom;

		private IfcElementTable element;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="PROPID" </summary>
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
		/// @hibernate.property column="IFCPROPGROUP" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string GroupName
		{
			get
			{
				return groupName;
			}
			set
			{
				this.groupName = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="IFCPROPNAME" type="costos_string" index="IDX_PNAME" </summary>
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
		/// @hibernate.property column="IFCQTYTYPE" type="int" </summary>
		/// <returns> Integer </returns>
		public virtual int? QtyType
		{
			get
			{
				return qtyType;
			}
			set
			{
				this.qtyType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="IFCISNUM" type="boolean" </summary>
		/// <returns> Boolean </returns>
		public virtual bool? Number
		{
			get
			{
				return number;
			}
			set
			{
				this.number = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="IFCVALUE" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="IFCNUMVAL" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal NumberValue
		{
			get
			{
				return numberValue;
			}
			set
			{
				this.numberValue = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="IFCMTUOM" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string MetricUom
		{
			get
			{
				return metricUom;
			}
			set
			{
				this.metricUom = value;
			}
		}


		/// <summary>
		/// @hibernate.many-to-one
		///  column="ELEMID" index="IDX_ELEMID" </summary>
		/// <returns> IfcElementTable </returns>
		public virtual IfcElementTable Element
		{
			get
			{
				return element;
			}
			set
			{
				this.element = value;
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