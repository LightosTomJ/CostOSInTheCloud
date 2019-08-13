using Models.project;
using System;
using System.Collections.Generic;

namespace Models.layout
{
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

        public long? layoutId { get; set; }
        public string name { get; set; }
        public DateTime lastUpdate { get; set; }
        public string creatorId { get; set; }
        public string editorId { get; set; }
        public string selectedGroupCode { get; set; }
        public string type { get; set; }

        public bool? pblk = new bool?(false);  // pubilc or private?
        public bool? dflt = new bool?(false);

        public string visibTabs { get; set; }

        public bool? spanGroups { get; set; }
        public bool? showAsTree { get; set; }

        public bool? rowStripes { get; set; }
        public bool? multiLines { get; set; }
        public bool? showVerticalGrids { get; set; }
        public bool? showHorizontalGrids { get; set; }
        public string groupName { get; set; }
        public int? zoom { get; set; }

        public string fontLevel1Name { get; set; }
        public int? fontLevel1Size { get; set; }
        public int? fontLevel1Style { get; set; }
        public bool? fontLevel1Undln { get; set; }
        public string fontLevel1Color { get; set; }

        public string level1BackColor { get; set; }
        public string level2BackColor { get; set; }
        public string level3BackColor { get; set; }
        public string level4BackColor { get; set; }
        public string level5BackColor { get; set; }
        public string levelNBackColor { get; set; }
        public string unassignedBackColor { get; set; }
        public string leafBackColor { get; set; }
        public bool? showRowHeader { get; set; }
        public bool? showColumnSeparator { get; set; }
        public string columnSeparatorColor { get; set; }
        public string gridColor { get; set; }

        public string fontLevel2Name { get; set; }
        public int? fontLevel2Size { get; set; }
        public int? fontLevel2Style { get; set; }
        public bool? fontLevel2Undln { get; set; }
        public string fontLevel2Color { get; set; }

        public string fontLevel3Name { get; set; }
        public int? fontLevel3Size { get; set; }
        public int? fontLevel3Style { get; set; }
        public bool? fontLevel3Undln { get; set; }
        public string fontLevel3Color { get; set; }

        public string fontLevel4Name { get; set; }
        public int? fontLevel4Size { get; set; }
        public int? fontLevel4Style { get; set; }
        public bool? fontLevel4Undln { get; set; }
        public string fontLevel4Color { get; set; }

        public string fontLevel5Name { get; set; }
        public int? fontLevel5Size { get; set; }
        public int? fontLevel5Style { get; set; }
        public bool? fontLevel5Undln { get; set; }
        public string fontLevel5Color { get; set; }

        public string fontLevelNName { get; set; }
        public int? fontLevelNSize { get; set; }
        public int? fontLevelNStyle { get; set; }
        public bool? fontLevelNUndln { get; set; }
        public string fontLevelNColor { get; set; }

        public string fontUnassignedName { get; set; }
        public int? fontUnassignedSize { get; set; }
        public int? fontUnassignedStyle { get; set; }
        public bool? fontUnassignedUndln { get; set; }
        public string fontUnassignedColor { get; set; }

        public string fontLeafName { get; set; }
        public int? fontLeafSize { get; set; }
        public int? fontLeafStyle { get; set; }
        public bool? fontLeafUndln { get; set; }
        public string fontLeafColor { get; set; }

        public string rowStripe1Color { get; set; }
        public string rowStripe2Color { get; set; }
        public string layoutUserAndRoles { get; set; }

        public IList<LayoutPanelTable> layoutColumnList = new List<LayoutPanelTable>();
        public ISet<QuotationTemplateTable> quotationTemplateTableSet = new HashSet<QuotationTemplateTable>();

        public LayoutTable()
        { }
    }
}