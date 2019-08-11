using System;
using System.Collections.Generic;

namespace Models.local
{

	using BaseTable = nomitech.common.@base.BaseTable;
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="TAKEOFFCON"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class TakeoffConditionTable : Transferable, BaseTable
	{

		/* TAKEOFF TYPES */
		public const string ONSCREEN_TAKEOFF = "OST";
		public const string MAP_TAKEOFF = "MAP";

		/* CONDITION TYPES */
		public const string LINEAR_CONDITION = "type.linear";
		public const string AREA_CONDITION = "type.area";
		public const string SPOT_CONDITION = "type.spot";

		/* QTY TYPES */
		public static readonly string[] LINEAR_QTY_TYPES = new string[] {"linear.distance", "linear.elevationdistance", "linear.elevationdistance.wgs84datum", "linear.segment.count", "linear.surface.singleside", "linear.surface.bothside", "linear.surface.toporbottom", "linear.surface.topandbottom", "linear.surface.singleend", "linear.surface.bothends", "linear.surface.recttube", "linear.surface.circletube", "linear.surface.allside", "linear.surface.volume"};

		public static readonly string[] AREA_QTY_TYPES = new string[] {"area", "area.perimeter", "area.count", "area.volume", "area.elevationvolume"};

		public static readonly string[] SPOT_QTY_TYPES = new string[] {"spot", "spot.elevationheight", "spot.totalheight", "spot.perimeter", "spot.toporbottom", "spot.topandbottom", "spot.singlewidthside", "spot.bothwidthsides", "spot.singledepthside", "spot.bothdepthsides", "spot.allsides", "spot.fullallsides", "spot.volume"};

		private long? id;
		private string title;
		private string description;
		private string color;
		private string grouping;
		private string conditionType;
		private int? patternType;
		private int? shapeType;
		private bool? elevation;
		private int? elevationSamples;
		private decimal height;
		private decimal width;
		private decimal depth;
		private decimal thickness;
		private string takeoffType;
		private string editorId;
		private string createUserId;
		private DateTime lastUpdate;
		private DateTime createDate;
		private ProjectInfoTable projectInfoTable;

		private string qty1Type;
		private string qty2Type;
		private string qty3Type;

		private string uom1;
		private string uom2;
		private string uom3;

		private decimal qty1;
		private decimal qty2;
		private decimal qty3;

		private IList<TakeoffLineTable> linesList;
		private IList<TakeoffAreaTable> areaList;
		private IList<TakeoffPointTable> spotList;
		private IList<TakeoffLegendTable> legendList;

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
		/// @hibernate.property column="TITLE" type="costos_string" </summary>
		/// <returns> description </returns>
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
		/// @hibernate.property column="COLOUR" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string Colour
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
		/// @hibernate.property column="GROUPING" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string Grouping
		{
			get
			{
				return grouping;
			}
			set
			{
				this.grouping = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CNDTYPE" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string ConditionType
		{
			get
			{
				return conditionType;
			}
			set
			{
				this.conditionType = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="PATTERNTYPE" type="int" </summary>
		/// <returns> description </returns>
		public virtual int? PatternType
		{
			get
			{
				return patternType;
			}
			set
			{
				this.patternType = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="SHAPETYPE" type="int" </summary>
		/// <returns> description </returns>
		public virtual int? ShapeType
		{
			get
			{
				return shapeType;
			}
			set
			{
				this.shapeType = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ELEVATION" type="boolean" </summary>
		/// <returns> description </returns>
		public virtual bool? Elevation
		{
			get
			{
				return elevation;
			}
			set
			{
				this.elevation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="SAMPLES" type="int" </summary>
		/// <returns> description </returns>
		public virtual int? ElevationSamples
		{
			get
			{
				return elevationSamples;
			}
			set
			{
				this.elevationSamples = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="HEIGHT" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Height
		{
			get
			{
				return height;
			}
			set
			{
				this.height = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="WIDTH" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Width
		{
			get
			{
				return width;
			}
			set
			{
				this.width = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="DEPTH" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Depth
		{
			get
			{
				return depth;
			}
			set
			{
				this.depth = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="THICKNESS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Thickness
		{
			get
			{
				return thickness;
			}
			set
			{
				this.thickness = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="TAKEOFF" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string TakeoffType
		{
			get
			{
				return takeoffType;
			}
			set
			{
				this.takeoffType = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EDITORID" type="costos_string" </summary>
		/// <returns> description </returns>
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
		/// <returns> description </returns>
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
				this.lastUpdate = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CREATEDATE" type="timestamp" </summary>
		/// <returns> lastUpdate </returns>
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
		/// @hibernate.property column="QTY1TYPE" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string Qty1Type
		{
			get
			{
				return qty1Type;
			}
			set
			{
				this.qty1Type = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="QTY2TYPE" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string Qty2Type
		{
			get
			{
				return qty2Type;
			}
			set
			{
				this.qty2Type = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="QTY3TYPE" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string Qty3Type
		{
			get
			{
				return qty3Type;
			}
			set
			{
				this.qty3Type = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="UOM1" type="costos_string" </summary>
		/// <returns> description </returns>
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
		/// @hibernate.property column="UOM2" type="costos_string" </summary>
		/// <returns> description </returns>
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
		/// @hibernate.property column="UOM3" type="costos_string" </summary>
		/// <returns> description </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="QTY1" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="QTY2" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="QTY3" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
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

		public override decimal TableRate
		{
			get
			{
				return null;
			}
		}
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public override object getTransferData(DataFlavor flavor)
		{
			return null;
		}
		public override DataFlavor[] TransferDataFlavors
		{
			get
			{
				return null;
			}
		}
		public override bool isDataFlavorSupported(DataFlavor flavor)
		{
			return false;
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="PROJECTINFOID"
		///  cascade="none" </summary>
		/// <returns> ProjectInfoTable </returns>
		public virtual ProjectInfoTable ProjectInfoTable
		{
			get
			{
				return projectInfoTable;
			}
			set
			{
				this.projectInfoTable = value;
			}
		}

		/// <summary>
		/// @hibernate.list  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="LID"
		/// @hibernate.list-index
		///  column="LINESCOUNT"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.TakeoffLineTable"
		/// return List
		/// </summary>
		public virtual IList<TakeoffLineTable> LinesList
		{
			get
			{
				return linesList;
			}
			set
			{
				this.linesList = value;
			}
		}

		/// <summary>
		/// @hibernate.list  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="AID"
		/// @hibernate.list-index
		///  column="AREACOUNT"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.TakeoffAreaTable"
		/// return List
		/// </summary>
		public virtual IList<TakeoffAreaTable> AreaList
		{
			get
			{
				return areaList;
			}
			set
			{
				this.areaList = value;
			}
		}

		/// <summary>
		/// @hibernate.list  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="CID"
		/// @hibernate.list-index
		///  column="POINTCOUNT"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.TakeoffPointTable"
		/// return List
		/// </summary>
		public virtual IList<TakeoffPointTable> SpotList
		{
			get
			{
				return spotList;
			}
			set
			{
				this.spotList = value;
			}
		}

		/// <summary>
		/// @hibernate.list  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="CID"
		/// @hibernate.list-index
		///  column="LGDCOUNT"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.TakeoffLegendTable"
		/// return List
		/// </summary>
		public virtual IList<TakeoffLegendTable> LegendList
		{
			get
			{
				return legendList;
			}
			set
			{
				this.legendList = value;
			}
		}

		public virtual TakeoffConditionTable Data
		{
			set
			{
    
				Title = value.Title;
				Description = value.Description;
				Colour = value.Colour;
				Grouping = value.Grouping;
				ConditionType = value.ConditionType;
				PatternType = value.PatternType;
				ShapeType = value.ShapeType;
				Elevation = value.Elevation;
				ElevationSamples = value.ElevationSamples;
				Height = value.Height;
				Width = value.Width;
				Thickness = value.Thickness;
				Depth = value.Depth;
    
				TakeoffType = value.TakeoffType;
				Qty1Type = value.Qty1Type;
				Qty2Type = value.Qty2Type;
				Qty3Type = value.Qty3Type;
    
				Uom1 = value.Uom1;
				Uom2 = value.Uom2;
				Uom3 = value.Uom3;
				Qty1 = value.Qty1;
				Qty2 = value.Qty2;
				Qty3 = value.Qty3;
    
			}
		}

		public virtual object clone()
		{
			TakeoffConditionTable obj = new TakeoffConditionTable();

			obj.Id = Id;
			obj.Title = Title;
			obj.Description = Description;
			obj.Colour = Colour;
			obj.Grouping = Grouping;
			obj.ConditionType = ConditionType;
			obj.PatternType = PatternType;
			obj.ShapeType = ShapeType;
			obj.Elevation = Elevation;
			obj.ElevationSamples = ElevationSamples;
			obj.Height = Height;
			obj.Width = Width;
			obj.Thickness = Thickness;
			obj.Depth = Depth;
			obj.EditorId = EditorId;
			obj.CreateUserId = CreateUserId;
			obj.TakeoffType = TakeoffType;
			obj.Qty1Type = Qty1Type;
			obj.Qty2Type = Qty2Type;
			obj.Qty3Type = Qty3Type;
			obj.LastUpdate = LastUpdate;
			obj.CreateDate = CreateDate;
			obj.Uom1 = Uom1;
			obj.Uom2 = Uom2;
			obj.Uom3 = Uom3;
			obj.Qty1 = Qty1;
			obj.Qty2 = Qty2;
			obj.Qty3 = Qty3;

			return obj;
		}

		public virtual object copy(bool cyclic)
		{
			TakeoffConditionTable obj = (TakeoffConditionTable) clone();

			obj.LinesList = new List<TakeoffLineTable>();
			obj.AreaList = new List<TakeoffAreaTable>();
			obj.SpotList = new List<TakeoffPointTable>();
			obj.LegendList = new List<TakeoffLegendTable>();

			if (LinesList != null)
			{
				foreach (TakeoffLineTable toff in LinesList)
				{
					toff = (TakeoffLineTable) toff.copy(cyclic);
					if (cyclic)
					{
						toff.ConditionTable = obj;
					}
					obj.LinesList.Add(toff);
				}
			}
			if (AreaList != null)
			{
				foreach (TakeoffAreaTable toff in AreaList)
				{
					toff = (TakeoffAreaTable) toff.copy(cyclic);
					if (cyclic)
					{
						toff.ConditionTable = obj;
					}
					obj.AreaList.Add(toff);
				}
			}
			if (SpotList != null)
			{
				foreach (TakeoffPointTable toff in SpotList)
				{
					toff = (TakeoffPointTable) toff.clone();
					if (cyclic)
					{
						toff.ConditionTable = obj;
					}
					obj.SpotList.Add(toff);
				}
			}
			if (LegendList != null)
			{
				foreach (TakeoffLegendTable toff in LegendList)
				{
					toff = (TakeoffLegendTable) toff.clone();
					if (cyclic)
					{
						toff.ConditionTable = obj;
					}
					obj.LegendList.Add(toff);
				}
			}

			return obj;
		}
	}

}