using System;

namespace Model.proj
{

	using BaseEntity = nomitech.common.@base.BaseEntity;

	//#RXP_START
	/// <summary>
	/// @author: Periklis Laros
	/// 
	/// 
	/// @hibernate.class table="NEWPROJECTTEMPLATE"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class NewProjectTemplateTable : BaseEntity
	{
		public const int BOTTOM_UP = 0;
		public const int TOP_DOWN = 1;
		private long? id;
		private string title;
		private int type;
		private string description;
		private string paramItemIds;
		private string templateImageId;
		private bool has2D;
		private bool hasBIM;
		private bool hasGIS;
		private string wbsFill;
		private string wbs2Fill;
		private bool hasAddFromExcel;
		private string layoutIds;
		private string projectVariableTemplateIds;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="ID" </summary>
		/// <returns> Long </returns>
		public override long? Id
		{
			get
			{
    
				return this.id;
			}
			set
			{
				this.id = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="TYPE" type="int" </summary>
		/// <returns> title </returns>
		public virtual int Type
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
		/// Description Here
		/// 
		/// @hibernate.property column="TITLE" type="costos_string" </summary>
		/// <returns> title </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="DESCRIPTION" type="costos_text" </summary>
		/// <returns> description </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="PARAMITEMIDS" type="costos_string" </summary>
		/// <returns> paramItemIds </returns>
		public virtual string ParamItemIds
		{
			get
			{
				return paramItemIds;
			}
			set
			{
				this.paramItemIds = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="TEMPLATEIMAGEID "type="costos_string" </summary>
		/// <returns> templateImage </returns>
		public virtual string TemplateImageId
		{
			get
			{
				return templateImageId;
			}
			set
			{
				this.templateImageId = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="HAS2D" type="boolean" </summary>
		/// <returns> has2D </returns>
		public virtual bool Has2D
		{
			get
			{
				return has2D;
			}
			set
			{
				has2D = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="HASBIM" type="boolean" </summary>
		/// <returns> hasBIM </returns>
		public virtual bool HasBIM
		{
			get
			{
				return hasBIM;
			}
			set
			{
				this.hasBIM = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="HASGIS" type="boolean" </summary>
		/// <returns> hasGIS </returns>
		public virtual bool HasGIS
		{
			get
			{
				return hasGIS;
			}
			set
			{
				this.hasGIS = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="HASEXCEL" type="boolean" </summary>
		/// <returns> hasAddFromExcel </returns>
		public virtual bool HasAddFromExcel
		{
			get
			{
				return hasAddFromExcel;
			}
			set
			{
				this.hasAddFromExcel = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="LAYATOUIDS" type="costos_string" </summary>
		/// <returns> String </returns>

		public virtual string LayoutIds
		{
			get
			{
				return layoutIds;
			}
			set
			{
				this.layoutIds = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="WBSFILL" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string WbsFill
		{
			get
			{
				return wbsFill;
			}
			set
			{
				this.wbsFill = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="WBS2FILL" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Wbs2Fill
		{
			get
			{
				return wbs2Fill;
			}
			set
			{
				this.wbs2Fill = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PROJECTVARIABLETEMPLATEIDS" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string ProjectVariableTemplateIds
		{
			get
			{
				return projectVariableTemplateIds;
			}
			set
			{
				this.projectVariableTemplateIds = value;
			}
		}


	}

}