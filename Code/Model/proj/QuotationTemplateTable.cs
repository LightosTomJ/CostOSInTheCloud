using System;

namespace Model.proj
{

	using BaseEntity = nomitech.common.@base.BaseEntity;
	//#RXP_START
	/// 
	/// <summary>
	/// @author: George Hatzisymeon
	/// @hibernate.class table="QUOTETEMPLATE"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// 
	/// </summary>
	//#RXP_END
	public class QuotationTemplateTable : BaseEntity
	{

		private long? id;
		private sbyte[] excelFile;
	//	private LayoutTable layoutTableId;
		private string editorId;
		private DateTime createDate;
		private DateTime lastUpdate;
		private string title;
		private bool isMaterialQuote;
		private long? layoutTableId;
		private bool? dflt;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="ID" </summary>
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
		/// @hibernate.property column="XCELLFILE" type="binary" length="73741824" </summary>
		/// <returns> description </returns>
		public virtual sbyte[] ExcelFile
		{
			get
			{
				return excelFile;
			}
			set
			{
				this.excelFile = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EDITORID" type="costos_string" </summary>
		/// <returns> code </returns>
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

		/// 
		/// <summary>
		/// @hibernate.property column="CREATEDATE" type="timestamp" </summary>
		/// <returns> stateProvince </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="LASTUPDATE" type="timestamp" </summary>
		/// <returns> lastUpdate </returns>
		public virtual DateTime LastUpdate
		{
			get
			{
				return lastUpdate;
			}
			set
			{
				lastUpdate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TITLE" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string Title
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="ISMATERIAL" type="boolean" </summary>
		/// <returns> IsMaterialQuote </returns>
		public virtual bool IsMaterialQuote
		{
			get
			{
				return isMaterialQuote;
			}
			set
			{
				this.isMaterialQuote = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LAYOUTID" type="long" </summary>
		/// <returns> layoutTableId </returns>
		public virtual long? LayoutTableId
		{
			get
			{
				return layoutTableId;
			}
			set
			{
				this.layoutTableId = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="DFLT" type="boolean" </summary>
		/// <returns> dflt </returns>
		public virtual bool? Dflt
		{
			get
			{
				return dflt;
			}
			set
			{
				this.dflt = value;
			}
		}

		public override string ToString()
		{
			return Title;
		}
	}

}