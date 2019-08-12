using System;

namespace Model.local
{

	using BaseEntity = Desktop.common.nomitech.common.@base.BaseEntity;
	//#RXP_START

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="FIELDCUSTOM"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class FieldCustomizationTable : BaseEntity
	{
		public const int FORMULAIN_RET = 0;
		public const int SELECION_LIST = 1;
		public const int CALCULATED_SELECION_LIST = 2;

		private long? id;
		private string name;
		private string displayName;
		private string formula;
		private string resourceType; // LayoutType Here
		private bool? editable;
		private int? selectionList;
		private string selectionValues;
		private string defSelection;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="ID" </summary>
		/// <returns> Long </returns>
		public override long? Id
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
		/// Description Here
		/// 
		/// @hibernate.property column="NAME" type="costos_string" </summary>
		/// <returns> description </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="DISPLAYNAME" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string DisplayName
		{
			get
			{
				return displayName;
			}
			set
			{
				this.displayName = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FORMULA" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string Formula
		{
			get
			{
				return formula;
			}
			set
			{
				this.formula = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="RSRC" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string ResourceType
		{
			get
			{
				return resourceType;
			}
			set
			{
				this.resourceType = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="EDITABLE" type="boolean" </summary>
		/// <returns> description </returns>
		public virtual bool? Editable
		{
			get
			{
				return editable;
			}
			set
			{
				this.editable = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SELLIST" type="int" </summary>
		/// <returns> description </returns>
		public virtual int? SelectionList
		{
			get
			{
				return selectionList;
			}
			set
			{
				this.selectionList = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SELVALS" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string SelectionValues
		{
			get
			{
				return selectionValues;
			}
			set
			{
				this.selectionValues = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="DEFSEL" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string DefSelection
		{
			get
			{
				return defSelection;
			}
			set
			{
				this.defSelection = value;
			}
		}


		public virtual FieldCustomizationTable Data
		{
			set
			{
				//setId(value.getId());
				DisplayName = value.DisplayName;
				DefSelection = value.DefSelection;
				SelectionList = value.SelectionList;
				Formula = value.Formula;
				Name = value.Name;
				DisplayName = value.DisplayName;
				ResourceType = value.ResourceType;
				Editable = value.Editable;
				SelectionValues = value.SelectionValues;
			}
		}

		public virtual object clone()
		{
			FieldCustomizationTable table = new FieldCustomizationTable();

			table.Id = Id;
			table.DisplayName = DisplayName;
			table.DefSelection = DefSelection;
			table.Formula = Formula;
			table.SelectionList = SelectionList;
			table.Name = Name;
			table.DisplayName = DisplayName;
			table.ResourceType = ResourceType;
			table.Editable = Editable;
			table.SelectionValues = SelectionValues;

			return table;
		}
	}

}