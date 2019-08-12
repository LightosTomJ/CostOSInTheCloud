using System;
using System.Collections.Generic;

namespace nomitech.common.db.layout
{
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="LAYOUTC"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class LayoutTable
	{

		// Types of Layouts
		public const string BOQ_ITEM = "boqitem";
		public const string VISUALIZER = "visualizer";
		public const string EPS = "eps";
		public const string PROJECT_RESOURCE = "prjresource";
		public const string LABOR = "labor";
		public const string MATERIAL = "material";
		public const string SUPPLIER = "supplier";
		public const string SUBCONTRACTOR = "subcontractor";
		public const string PARAMITEM = "paramitem";
		public const string ASSEMBLY = "assembly";
		public const string CONSUMABLE = "consumable";
		public const string EQUIPMENT = "equipment";
		public const string CONDITION = "condition";
		public const string QUOTATION = "quotation";
		public const string QUOTATION_TEMPLATE = "quotetemplate";
		public const string WORKITEM = "workitem";
		public const string WBS1CODE = "wbs1";
		public const string WBS2CODE = "wbs2";
		public const string PARAMCODE = "param";
		public const string GROUPCODE = "groupcode";
		public const string GEKCODE = "gekcode";
		public const string EXTRACODE1 = "extracode1";
		public const string EXTRACODE2 = "extracode2";
		public const string EXTRACODE3 = "extracode3";
		public const string EXTRACODE4 = "extracode4";
		public const string EXTRACODE5 = "extracode5";
		public const string EXTRACODE6 = "extracode6";
		public const string EXTRACODE7 = "extracode7";
		public const string EXTRACODE8 = "extracode8";
		public const string EXTRACODE9 = "extracode9";
		public const string EXTRACODE10 = "extracode10";

		public const string PROJECTINFO = "projectinfo";
		public const string PROJECTPROPS = "projectprops";
		public const string PROJECTRATES = "projectrates";
		public const string GLOBALPROPS = "globalprops";
		public const string FIELDCUSTOM = "fieldcustom";
		public const string FUNCTION = "function";

		public const string BIMCT_PROJECT = "bcproject";
		public const string BIMCT_MODEL = "bcmodel";


		private long? layoutId = null;
		private string name = null;
		private DateTime lastUpdate = null;
		private string creatorId = null;
		private string editorId = null;
		private string selectedGroupCode = null;
		private string type = null;
		private bool? pblk = new bool?(false); // public or private?
		private bool? dflt = new bool?(false);
		private string visibTabs;

		private bool? spanGroups;
		private bool? showAsTree;

		private bool? rowStripes;
		private bool? multiLines;
		private bool? showVerticalGrids;
		private bool? showHorizontalGrids;
		private string groupName;
		private int? zoom;

		private string fontLevel1Name;
		private int? fontLevel1Size;
		private int? fontLevel1Style;
		private bool? fontLevel1Undln;
		private string fontLevel1Color;

		private string level1BackColor;
		private string level2BackColor;
		private string level3BackColor;
		private string level4BackColor;
		private string level5BackColor;
		private string levelNBackColor;
		private string unassignedBackColor;
		private string leafBackColor;
		private bool? showRowHeader;
		private bool? showColumnSeparator;
		private string columnSeparatorColor;
		private string gridColor;

		private string fontLevel2Name;
		private int? fontLevel2Size;
		private int? fontLevel2Style;
		private bool? fontLevel2Undln;
		private string fontLevel2Color;

		private string fontLevel3Name;
		private int? fontLevel3Size;
		private int? fontLevel3Style;
		private bool? fontLevel3Undln;
		private string fontLevel3Color;

		private string fontLevel4Name;
		private int? fontLevel4Size;
		private int? fontLevel4Style;
		private bool? fontLevel4Undln;
		private string fontLevel4Color;

		private string fontLevel5Name;
		private int? fontLevel5Size;
		private int? fontLevel5Style;
		private bool? fontLevel5Undln;
		private string fontLevel5Color;

		private string fontLevelNName;
		private int? fontLevelNSize;
		private int? fontLevelNStyle;
		private bool? fontLevelNUndln;
		private string fontLevelNColor;

		private string fontUnassignedName;
		private int? fontUnassignedSize;
		private int? fontUnassignedStyle;
		private bool? fontUnassignedUndln;
		private string fontUnassignedColor;

		private string fontLeafName;
		private int? fontLeafSize;
		private int? fontLeafStyle;
		private bool? fontLeafUndln;
		private string fontLeafColor;

		private string rowStripe1Color;
		private string rowStripe2Color;
		private string layoutUserAndRoles;

		private IList<LayoutPanelTable> layoutColumnList = new List<LayoutPanelTable>();
	//	private Set<QuotationTemplateTable> quotationTemplateTableSet;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="LAYOUTCID" </summary>
		/// <returns> Long </returns>
		public virtual long? LayoutId
		{
			get
			{
				return layoutId;
			}
			set
			{
				this.layoutId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="NAME" type="costos_string" </summary>
		/// <returns> Returns the NAME. </returns>
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
				this.lastUpdate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CREATORID" type="costos_string" </summary>
		/// <returns> Returns the CREATORID. </returns>
		public virtual string CreatorId
		{
			get
			{
				return creatorId;
			}
			set
			{
				this.creatorId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EDITORID" type="costos_string" </summary>
		/// <returns> Returns the EDITORID. </returns>
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
		/// @hibernate.property column="SELECTEDGK" type="costos_string" </summary>
		/// <returns> Returns the EDITORID. </returns>
		public virtual string SelectedGroupCode
		{
			get
			{
				return selectedGroupCode;
			}
			set
			{
				this.selectedGroupCode = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="PBLK" type="boolean" </summary>
		/// <returns> Returns the type. </returns>
		public virtual bool? Pblk
		{
			get
			{
				return pblk;
			}
			set
			{
				this.pblk = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="DFLT" type="boolean" </summary>
		/// <returns> Returns the type. </returns>
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

		/// <summary>
		/// @hibernate.property column="TYPE" type="costos_string" </summary>
		/// <returns> Returns the type. </returns>
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
		/// @hibernate.property column="VISIBTABS" type="costos_text" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string VisibTabs
		{
			get
			{
				return visibTabs;
			}
			set
			{
				this.visibTabs = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="SHOWTREE" type="boolean" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual bool? ShowAsTree
		{
			get
			{
				return showAsTree;
			}
			set
			{
				this.showAsTree = value;
			}
		}
		/// <summary>
		/// @hibernate.property column="SPANGRP" type="boolean" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual bool? SpanGroups
		{
			get
			{
				return spanGroups;
			}
			set
			{
				this.spanGroups = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ROWSTRP" type="boolean" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual bool? RowStripes
		{
			get
			{
				return rowStripes;
			}
			set
			{
				this.rowStripes = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="GRPNAME" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
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
		/// @hibernate.property column="F1NAME" type="costos_string" </summary>
		/// <returns> Returns the fontLevel1Name. </returns>
		public virtual string FontLevel1Name
		{
			get
			{
				return fontLevel1Name;
			}
			set
			{
				this.fontLevel1Name = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F1SIZE" type="int" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual int? FontLevel1Size
		{
			get
			{
				return fontLevel1Size;
			}
			set
			{
				this.fontLevel1Size = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F1STYLE" type="int" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual int? FontLevel1Style
		{
			get
			{
				return fontLevel1Style;
			}
			set
			{
				this.fontLevel1Style = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F2NAME" type="costos_string" </summary>
		/// <returns> Returns the fontLevel1Name. </returns>
		public virtual string FontLevel2Name
		{
			get
			{
				return fontLevel2Name;
			}
			set
			{
				this.fontLevel2Name = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F2SIZE" type="int" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual int? FontLevel2Size
		{
			get
			{
				return fontLevel2Size;
			}
			set
			{
				this.fontLevel2Size = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F2STYLE" type="int" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual int? FontLevel2Style
		{
			get
			{
				return fontLevel2Style;
			}
			set
			{
				this.fontLevel2Style = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F3NAME" type="costos_string" </summary>
		/// <returns> Returns the fontLevel3Name. </returns>
		public virtual string FontLevel3Name
		{
			get
			{
				return fontLevel3Name;
			}
			set
			{
				this.fontLevel3Name = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F3SIZE" type="int" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual int? FontLevel3Size
		{
			get
			{
				return fontLevel3Size;
			}
			set
			{
				this.fontLevel3Size = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F3STYLE" type="int" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual int? FontLevel3Style
		{
			get
			{
				return fontLevel3Style;
			}
			set
			{
				this.fontLevel3Style = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F4NAME" type="costos_string" </summary>
		/// <returns> Returns the fontLevel4Name. </returns>
		public virtual string FontLevel4Name
		{
			get
			{
				return fontLevel4Name;
			}
			set
			{
				this.fontLevel4Name = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F4SIZE" type="int" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual int? FontLevel4Size
		{
			get
			{
				return fontLevel4Size;
			}
			set
			{
				this.fontLevel4Size = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FNNAME" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string FontLevelNName
		{
			get
			{
				return fontLevelNName;
			}
			set
			{
				this.fontLevelNName = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FNSIZE" type="int" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual int? FontLevelNSize
		{
			get
			{
				return fontLevelNSize;
			}
			set
			{
				this.fontLevelNSize = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FNSTYLE" type="int" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual int? FontLevelNStyle
		{
			get
			{
				return fontLevelNStyle;
			}
			set
			{
				this.fontLevelNStyle = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FNCLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string FontLevelNColor
		{
			get
			{
				return fontLevelNColor;
			}
			set
			{
				this.fontLevelNColor = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FUNAME" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string FontUnassignedName
		{
			get
			{
				return fontUnassignedName;
			}
			set
			{
				this.fontUnassignedName = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FUSIZE" type="int" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual int? FontUnassignedSize
		{
			get
			{
				return fontUnassignedSize;
			}
			set
			{
				this.fontUnassignedSize = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FUSTYLE" type="int" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual int? FontUnassignedStyle
		{
			get
			{
				return fontUnassignedStyle;
			}
			set
			{
				this.fontUnassignedStyle = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FUCLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string FontUnassignedColor
		{
			get
			{
				return fontUnassignedColor;
			}
			set
			{
				this.fontUnassignedColor = value;
			}
		}
		/// <summary>
		/// @hibernate.property column="F4STYLE" type="int" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual int? FontLevel4Style
		{
			get
			{
				return fontLevel4Style;
			}
			set
			{
				this.fontLevel4Style = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F5NAME" type="costos_string" </summary>
		/// <returns> Returns the fontLevel5Name. </returns>
		public virtual string FontLevel5Name
		{
			get
			{
				return fontLevel5Name;
			}
			set
			{
				this.fontLevel5Name = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F5SIZE" type="int" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual int? FontLevel5Size
		{
			get
			{
				return fontLevel5Size;
			}
			set
			{
				this.fontLevel5Size = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F5STYLE" type="int" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual int? FontLevel5Style
		{
			get
			{
				return fontLevel5Style;
			}
			set
			{
				this.fontLevel5Style = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="LFNAME" type="costos_string" </summary>
		/// <returns> Returns the fontLevel1Name. </returns>
		public virtual string FontLeafName
		{
			get
			{
				return fontLeafName;
			}
			set
			{
				this.fontLeafName = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="LFSIZE" type="int" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual int? FontLeafSize
		{
			get
			{
				return fontLeafSize;
			}
			set
			{
				this.fontLeafSize = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="LFSTYLE" type="int" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual int? FontLeafStyle
		{
			get
			{
				return fontLeafStyle;
			}
			set
			{
				this.fontLeafStyle = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F1CLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string FontLevel1Color
		{
			get
			{
				return fontLevel1Color;
			}
			set
			{
				this.fontLevel1Color = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F2CLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string FontLevel2Color
		{
			get
			{
				return fontLevel2Color;
			}
			set
			{
				this.fontLevel2Color = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F3CLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string FontLevel3Color
		{
			get
			{
				return fontLevel3Color;
			}
			set
			{
				this.fontLevel3Color = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F4CLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string FontLevel4Color
		{
			get
			{
				return fontLevel4Color;
			}
			set
			{
				this.fontLevel4Color = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F5CLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string FontLevel5Color
		{
			get
			{
				return fontLevel5Color;
			}
			set
			{
				this.fontLevel5Color = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="LFCLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string FontLeafColor
		{
			get
			{
				return fontLeafColor;
			}
			set
			{
				this.fontLeafColor = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RS1CLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string RowStripe1Color
		{
			get
			{
				return rowStripe1Color;
			}
			set
			{
				this.rowStripe1Color = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RS2CLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string RowStripe2Color
		{
			get
			{
				return rowStripe2Color;
			}
			set
			{
				this.rowStripe2Color = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="MLTLN" type="boolean" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual bool? MultiLines
		{
			get
			{
				return multiLines;
			}
			set
			{
				this.multiLines = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ZOOM" type="int" </summary>
		/// <returns> Returns the zoom. </returns>
		public virtual int? Zoom
		{
			get
			{
				return zoom;
			}
			set
			{
				this.zoom = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="GRIDON" type="boolean" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual bool? ShowVerticalGrids
		{
			get
			{
				return showVerticalGrids;
			}
			set
			{
				this.showVerticalGrids = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="HGRIDON" type="boolean" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual bool? ShowHorizontalGrids
		{
			get
			{
				return showHorizontalGrids;
			}
			set
			{
				this.showHorizontalGrids = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F1UNDL" type="boolean" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual bool? FontLevel1Undln
		{
			get
			{
				return fontLevel1Undln;
			}
			set
			{
				this.fontLevel1Undln = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F2UNDL" type="boolean" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual bool? FontLevel2Undln
		{
			get
			{
				return fontLevel2Undln;
			}
			set
			{
				this.fontLevel2Undln = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F3UNDL" type="boolean" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual bool? FontLevel3Undln
		{
			get
			{
				return fontLevel3Undln;
			}
			set
			{
				this.fontLevel3Undln = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F4UNDL" type="boolean" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual bool? FontLevel4Undln
		{
			get
			{
				return fontLevel4Undln;
			}
			set
			{
				this.fontLevel4Undln = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="F5UNDL" type="boolean" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual bool? FontLevel5Undln
		{
			get
			{
				return fontLevel5Undln;
			}
			set
			{
				this.fontLevel5Undln = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FNUNDL" type="boolean" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual bool? FontLevelNUndln
		{
			get
			{
				return fontLevelNUndln;
			}
			set
			{
				this.fontLevelNUndln = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FUUNDL" type="boolean" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual bool? FontUnassignedUndln
		{
			get
			{
				return fontUnassignedUndln;
			}
			set
			{
				this.fontUnassignedUndln = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FLUNDL" type="boolean" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual bool? FontLeafUndln
		{
			get
			{
				return fontLeafUndln;
			}
			set
			{
				this.fontLeafUndln = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="L1BCLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string Level1BackColor
		{
			get
			{
				return level1BackColor;
			}
			set
			{
				this.level1BackColor = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="L2BCLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string Level2BackColor
		{
			get
			{
				return level2BackColor;
			}
			set
			{
				this.level2BackColor = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="L3BCLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string Level3BackColor
		{
			get
			{
				return level3BackColor;
			}
			set
			{
				this.level3BackColor = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="L4BCLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string Level4BackColor
		{
			get
			{
				return level4BackColor;
			}
			set
			{
				this.level4BackColor = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="L5BCLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string Level5BackColor
		{
			get
			{
				return level5BackColor;
			}
			set
			{
				this.level5BackColor = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="LNBCLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string LevelNBackColor
		{
			get
			{
				return levelNBackColor;
			}
			set
			{
				this.levelNBackColor = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="UNBCLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string UnassignedBackColor
		{
			get
			{
				return unassignedBackColor;
			}
			set
			{
				this.unassignedBackColor = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="LFBCLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string LeafBackColor
		{
			get
			{
				return leafBackColor;
			}
			set
			{
				this.leafBackColor = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ROWHEAD" type="boolean" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual bool? ShowRowHeader
		{
			get
			{
				return showRowHeader;
			}
			set
			{
				this.showRowHeader = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CSEP" type="boolean" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual bool? ShowColumnSeparator
		{
			get
			{
				return showColumnSeparator;
			}
			set
			{
				this.showColumnSeparator = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CSEPCLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string ColumnSeparatorColor
		{
			get
			{
				return columnSeparatorColor;
			}
			set
			{
				this.columnSeparatorColor = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="GRIDCLR" type="costos_string" </summary>
		/// <returns> Returns the visibTabs. </returns>
		public virtual string GridColor
		{
			get
			{
				return gridColor;
			}
			set
			{
				this.gridColor = value;
			}
		}

		/// <summary>
		/// @hibernate.list  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="LAYOUTCID"
		/// @hibernate.list-index
		///  column="LAYOUTCPANELCOUNT"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.layout.LayoutPanelTable" </summary>
		/// <returns> List </returns>
		public virtual IList<LayoutPanelTable> LayoutColumnList
		{
			get
			{
				return layoutColumnList;
			}
			set
			{
				this.layoutColumnList = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="LAYOUTROLES" type="costos_string" </summary>
		/// <returns> Returns the User and roles for this Layout. </returns>
		public virtual string LayoutUserAndRoles
		{
			get
			{
				return layoutUserAndRoles;
			}
			set
			{
				this.layoutUserAndRoles = value;
			}
		}


	//	/**
	//	 * @hibernate.set
	//	 *  inverse="true"  
	//	 *  cascade="all-delete-orphan"
	//	 *  lazy="true"
	//	 * @hibernate.key
	//	 *  column="QUOTATIONTEMPLATE"
	//	 * @hibernate.one-to-many
	//	 *  class="nomitech.common.db.project.QuotationTemplateTable"
	//	 * @hibernate.cache usage="nonstrict-read-write"
	//	 * @return Set
	//	 */
	//	public Set<QuotationTemplateTable> getQuotationTemplateTableSet() {
	//		return quotationTemplateTableSet;
	//	}

	//	public void setQuotationTemplateTableSet(Set<QuotationTemplateTable> quotationSet) {
	//		quotationTemplateTableSet = quotationSet;
	//	}

		public virtual object clone()
		{
			LayoutTable o = new LayoutTable();

			o.LayoutId = LayoutId;
			o.Name = Name;
			o.LastUpdate = LastUpdate;
			o.CreatorId = CreatorId;
			o.EditorId = EditorId;
			o.SelectedGroupCode = SelectedGroupCode;
			o.Type = Type;
			o.Pblk = Pblk;
			o.Dflt = Dflt;
			o.VisibTabs = VisibTabs;

			o.ShowAsTree = ShowAsTree;
			o.SpanGroups = SpanGroups;
			o.ShowAsTree = ShowAsTree;
			o.RowStripes = RowStripes;
			o.Zoom = Zoom;
			o.MultiLines = MultiLines;
			o.ShowVerticalGrids = ShowVerticalGrids;
			o.ShowHorizontalGrids = ShowHorizontalGrids;
			o.GroupName = GroupName;
			o.FontLevel1Name = FontLevel1Name;
			o.FontLevel1Size = FontLevel1Size;
			o.FontLevel1Style = FontLevel1Style;
			o.FontLevel2Name = FontLevel2Name;
			o.FontLevel2Size = FontLevel2Size;
			o.FontLevel2Style = FontLevel2Style;
			o.FontLevel3Name = FontLevel3Name;
			o.FontLevel3Size = FontLevel3Size;
			o.FontLevel3Style = FontLevel3Style;
			o.FontLevel4Name = FontLevel4Name;
			o.FontLevel4Size = FontLevel4Size;
			o.FontLevel4Style = FontLevel4Style;
			o.FontLevel5Name = FontLevel5Name;
			o.FontLevel5Size = FontLevel5Size;
			o.FontLevel5Style = FontLevel5Style;
			o.FontLevelNName = FontLevelNName;
			o.FontLevelNSize = FontLevelNSize;
			o.FontLevelNStyle = FontLevelNStyle;
			o.FontUnassignedName = FontUnassignedName;
			o.FontUnassignedSize = FontUnassignedSize;
			o.FontUnassignedStyle = FontUnassignedStyle;
			o.FontLeafName = FontLeafName;
			o.FontLeafSize = FontLeafSize;
			o.FontLeafStyle = FontLeafStyle;
			o.FontLevel1Color = FontLevel1Color;
			o.FontLevel2Color = FontLevel2Color;
			o.FontLevel3Color = FontLevel3Color;
			o.FontLevel4Color = FontLevel4Color;
			o.FontLevel5Color = FontLevel5Color;
			o.FontLevelNColor = FontLevelNColor;
			o.FontUnassignedColor = FontUnassignedColor;
			o.FontLeafColor = FontLeafColor;
			o.RowStripe1Color = RowStripe1Color;
			o.RowStripe2Color = RowStripe2Color;

			o.FontLevel1Undln = FontLevel1Undln;
			o.FontLevel2Undln = FontLevel2Undln;
			o.FontLevel3Undln = FontLevel3Undln;
			o.FontLevel4Undln = FontLevel4Undln;
			o.FontLevel5Undln = FontLevel5Undln;
			o.FontLevelNUndln = FontLevelNUndln;
			o.FontUnassignedUndln = FontUnassignedUndln;
			o.FontLeafUndln = FontLeafUndln;

			o.Level1BackColor = Level1BackColor;
			o.Level2BackColor = Level2BackColor;
			o.Level3BackColor = Level3BackColor;
			o.Level4BackColor = Level4BackColor;
			o.Level5BackColor = Level5BackColor;
			o.LevelNBackColor = LevelNBackColor;
			o.UnassignedBackColor = UnassignedBackColor;
			o.LeafBackColor = LeafBackColor;
			o.ShowRowHeader = ShowRowHeader;
			o.ShowColumnSeparator = ShowColumnSeparator;
			o.GridColor = GridColor;
			o.ColumnSeparatorColor = ColumnSeparatorColor;
			o.LayoutUserAndRoles = LayoutUserAndRoles;

			return o;
		}

		public virtual LayoutTable Data
		{
			set
			{
    
				Name = value.Name;
				LastUpdate = value.LastUpdate;
				CreatorId = value.CreatorId;
				EditorId = value.EditorId;
				SelectedGroupCode = value.SelectedGroupCode;
				Type = value.Type;
				Pblk = value.Pblk;
				Dflt = value.Dflt;
				VisibTabs = value.VisibTabs;
    
				ShowAsTree = value.ShowAsTree;
				SpanGroups = value.SpanGroups;
				RowStripes = value.RowStripes;
    
				Zoom = value.Zoom;
				MultiLines = value.MultiLines;
				ShowVerticalGrids = value.ShowVerticalGrids;
				ShowHorizontalGrids = value.ShowHorizontalGrids;
				GroupName = value.GroupName;
    
				FontLevel1Name = value.FontLevel1Name;
				FontLevel1Size = value.FontLevel1Size;
				FontLevel1Style = value.FontLevel1Style;
				FontLevel2Name = value.FontLevel2Name;
				FontLevel2Size = value.FontLevel2Size;
				FontLevel2Style = value.FontLevel2Style;
				FontLevel3Name = value.FontLevel3Name;
				FontLevel3Size = value.FontLevel3Size;
				FontLevel3Style = value.FontLevel3Style;
				FontLevel4Name = value.FontLevel4Name;
				FontLevel4Size = value.FontLevel4Size;
				FontLevel4Style = value.FontLevel4Style;
				FontLevel5Name = value.FontLevel5Name;
				FontLevel5Size = value.FontLevel5Size;
				FontLevel5Style = value.FontLevel5Style;
				FontLevelNName = value.FontLevelNName;
				FontLevelNSize = value.FontLevelNSize;
				FontLevelNStyle = value.FontLevelNStyle;
				FontUnassignedName = value.FontUnassignedName;
				FontUnassignedSize = value.FontUnassignedSize;
				FontUnassignedStyle = value.FontUnassignedStyle;
				FontLeafName = value.FontLeafName;
				FontLeafSize = value.FontLeafSize;
				FontLeafStyle = value.FontLeafStyle;
    
				FontLevel1Color = value.FontLevel1Color;
				FontLevel2Color = value.FontLevel2Color;
				FontLevel3Color = value.FontLevel3Color;
				FontLevel4Color = value.FontLevel4Color;
				FontLevel5Color = value.FontLevel5Color;
				FontLevelNColor = value.FontLevelNColor;
				FontUnassignedColor = value.FontUnassignedColor;
				FontLeafColor = value.FontLeafColor;
				RowStripe1Color = value.RowStripe1Color;
				RowStripe2Color = value.RowStripe2Color;
    
				FontLevel1Undln = value.FontLevel1Undln;
				FontLevel2Undln = value.FontLevel2Undln;
				FontLevel3Undln = value.FontLevel3Undln;
				FontLevel4Undln = value.FontLevel4Undln;
				FontLevel5Undln = value.FontLevel5Undln;
				FontLevelNUndln = value.FontLevelNUndln;
				FontUnassignedUndln = value.FontUnassignedUndln;
				FontLeafUndln = value.FontLeafUndln;
    
				Level1BackColor = value.Level1BackColor;
				Level2BackColor = value.Level2BackColor;
				Level3BackColor = value.Level3BackColor;
				Level4BackColor = value.Level4BackColor;
				Level5BackColor = value.Level5BackColor;
				LevelNBackColor = value.LevelNBackColor;
				UnassignedBackColor = value.UnassignedBackColor;
				LeafBackColor = value.LeafBackColor;
				ShowRowHeader = value.ShowRowHeader;
				ShowColumnSeparator = value.ShowColumnSeparator;
				GridColor = value.GridColor;
				ColumnSeparatorColor = value.ColumnSeparatorColor;
				LayoutUserAndRoles = value.LayoutUserAndRoles;
    
			}
		}

		public virtual LayoutTable copyWithPanels()
		{
			LayoutTable o = new LayoutTable();

			o.LayoutId = LayoutId;
			o.Name = Name;
			o.LastUpdate = LastUpdate;
			o.CreatorId = CreatorId;
			o.EditorId = EditorId;
			o.SelectedGroupCode = SelectedGroupCode;
			o.Type = Type;
			o.Pblk = Pblk;
			o.Dflt = Dflt;
			o.VisibTabs = VisibTabs;

			o.ShowAsTree = ShowAsTree;
			o.SpanGroups = SpanGroups;
			o.RowStripes = RowStripes;
			o.MultiLines = MultiLines;
			o.Zoom = Zoom;
			o.ShowVerticalGrids = ShowVerticalGrids;
			o.ShowHorizontalGrids = ShowHorizontalGrids;
			o.GroupName = GroupName;
			o.FontLevel1Name = FontLevel1Name;
			o.FontLevel1Size = FontLevel1Size;
			o.FontLevel1Style = FontLevel1Style;
			o.FontLevel2Name = FontLevel2Name;
			o.FontLevel2Size = FontLevel2Size;
			o.FontLevel2Style = FontLevel2Style;
			o.FontLevel3Name = FontLevel3Name;
			o.FontLevel3Size = FontLevel3Size;
			o.FontLevel3Style = FontLevel3Style;
			o.FontLevel4Name = FontLevel4Name;
			o.FontLevel4Size = FontLevel4Size;
			o.FontLevel4Style = FontLevel4Style;
			o.FontLevel5Name = FontLevel5Name;
			o.FontLevel5Size = FontLevel5Size;
			o.FontLevel5Style = FontLevel5Style;
			o.FontLevelNName = FontLevelNName;
			o.FontLevelNSize = FontLevelNSize;
			o.FontLevelNStyle = FontLevelNStyle;
			o.FontUnassignedName = FontUnassignedName;
			o.FontUnassignedSize = FontUnassignedSize;
			o.FontUnassignedStyle = FontUnassignedStyle;

			o.FontLeafName = FontLeafName;
			o.FontLeafSize = FontLeafSize;
			o.FontLeafStyle = FontLeafStyle;

			o.FontLevel1Color = FontLevel1Color;
			o.FontLevel2Color = FontLevel2Color;
			o.FontLevel3Color = FontLevel3Color;
			o.FontLevel4Color = FontLevel4Color;
			o.FontLevel5Color = FontLevel5Color;
			o.FontLevelNColor = FontLevelNColor;
			o.FontUnassignedColor = FontUnassignedColor;
			o.FontLeafColor = FontLeafColor;
			o.RowStripe1Color = RowStripe1Color;
			o.RowStripe2Color = RowStripe2Color;

			o.FontLevel1Undln = FontLevel1Undln;
			o.FontLevel2Undln = FontLevel2Undln;
			o.FontLevel3Undln = FontLevel3Undln;
			o.FontLevel4Undln = FontLevel4Undln;
			o.FontLevel5Undln = FontLevel5Undln;
			o.FontLevelNUndln = FontLevelNUndln;
			o.FontUnassignedUndln = FontUnassignedUndln;
			o.FontLeafUndln = FontLeafUndln;

			o.Level1BackColor = Level1BackColor;
			o.Level2BackColor = Level2BackColor;
			o.Level3BackColor = Level3BackColor;
			o.Level4BackColor = Level4BackColor;
			o.Level5BackColor = Level5BackColor;
			o.LevelNBackColor = LevelNBackColor;
			o.UnassignedBackColor = UnassignedBackColor;
			o.LeafBackColor = LeafBackColor;
			o.ShowRowHeader = ShowRowHeader;
			o.ShowColumnSeparator = ShowColumnSeparator;
			o.GridColor = GridColor;
			o.ColumnSeparatorColor = ColumnSeparatorColor;
			o.LayoutUserAndRoles = LayoutUserAndRoles;

			o.layoutColumnList = new List<LayoutPanelTable>();

			if (LayoutColumnList != null)
			{

				IEnumerator<LayoutPanelTable> iter = LayoutColumnList.GetEnumerator();
				while (iter.MoveNext())
				{
					o.layoutColumnList.Add((LayoutPanelTable)iter.Current.clone());
				}
			}
			return o;
		}

		public override string ToString()
		{
			if (Pblk != null && Pblk.Equals(true))
			{
				return Name + " [" + EditorId + "]";
			}

			return Name;
		}

	}
}