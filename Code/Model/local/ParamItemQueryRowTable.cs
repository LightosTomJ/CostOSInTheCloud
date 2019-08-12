using System;

namespace Model.local
{

	using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;

	/// <summary>
	/// @author: George Hatzisymeon
	/// @hibernate.class table="QUERYROW"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class ParamItemQueryRowTable : ProjectIdEntity
	{

		// AVAILABLE CONDITIONS:
		public const string AND_CONDITION = "AND";
		public const string NOT_CONDITION = "NOT";
		public const string OR_CONDITION = "OR";

		// AVAILABLE RULES:
		public const string EQUAL = "EQ";
		public const string NOT_EQUAL = "NE";
		public const string CONTAINS = "CN";
		public const string NOT_CONTAIN = "NC";
		public const string STARTS_WITH = "SW";
		public const string ENDS_WITH = "EW";
		public const string GREATER_THAN = "GT";
		public const string LESS_THAN = "LT";
		public const string GREATER_EQUAL = "GE";
		public const string LESS_EQUAL = "LE";

		private long? id;
		private string fieldName;
		private string ruleName;
		private string type;
		private string condition;
	//	private String groupCodeEquation;
	//	private String groupCodeEquation;

		private ParamItemQueryResourceTable queryResourceTable;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="QROWID" </summary>
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
		/// @hibernate.property column="FNAME" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string FieldName
		{
			get
			{
				return fieldName;
			}
			set
			{
				this.fieldName = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RNAME" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string RuleName
		{
			get
			{
				return ruleName;
			}
			set
			{
				this.ruleName = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CNDN" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string Condition
		{
			get
			{
				return condition;
			}
			set
			{
				this.condition = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CTYPE" type="costos_string" </summary>
		/// <returns> description </returns>
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
		/// @hibernate.many-to-one
		///  column="QRESID" </summary>
		/// <returns> ParamItemQueryResourceTable </returns>
		public virtual ParamItemQueryResourceTable QueryResourceTable
		{
			get
			{
				return queryResourceTable;
			}
			set
			{
				this.queryResourceTable = value;
			}
		}

		public virtual object clone()
		{
			ParamItemQueryRowTable c = new ParamItemQueryRowTable();
			c.Id = Id;
			c.Data = this;
			c.ProjectId = ProjectId;
			return c;
		}

		public virtual ParamItemQueryRowTable Data
		{
			set
			{
				Condition = value.Condition;
				Type = value.Type;
				RuleName = value.RuleName;
				FieldName = value.FieldName;
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