namespace Models.local
{
	//#RXP_START

	/// <summary>
	/// @author: George Hatzisymeon
	/// @hibernate.class table="TAKEOFFLEGEND"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	public class TakeoffLegendTable
	{

		private long? id;
		private decimal xPos;
		private decimal yPos;
		private decimal rotationAngle;
		private int? zoom;
		private string legendTxt;
		private string fontName;
		private string fontColor;

		private TakeoffConditionTable conditionTable;

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
		/// Description Here
		/// 
		/// @hibernate.property column="XPOS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Xpos
		{
			get
			{
				return xPos;
			}
			set
			{
				this.xPos = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="YPOS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Ypos
		{
			get
			{
				return yPos;
			}
			set
			{
				this.yPos = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="ZOOM" type="int" </summary>
		/// <returns> rate </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="ROTANGLE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal RotationAngle
		{
			get
			{
				return rotationAngle;
			}
			set
			{
				this.rotationAngle = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LEGTXT" type="costos_text" </summary>
		/// <returns> rate </returns>
		public virtual string LegendTxt
		{
			get
			{
				return legendTxt;
			}
			set
			{
				this.legendTxt = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FNT" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string Font
		{
			get
			{
				return fontName;
			}
			set
			{
				this.fontName = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FNTCOLOR" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string FontColor
		{
			get
			{
				return fontColor;
			}
			set
			{
				this.fontColor = value;
			}
		}


		/// <summary>
		/// @hibernate.many-to-one
		///  column="CID" </summary>
		/// <returns> TakeoffConditionTable </returns>
		public virtual TakeoffConditionTable ConditionTable
		{
			get
			{
				return conditionTable;
			}
			set
			{
				this.conditionTable = value;
			}
		}


		public virtual object clone()
		{
			TakeoffLegendTable t = new TakeoffLegendTable();
			t.Data = this;
			t.Id = Id;
			return t;
		}

		public virtual TakeoffLegendTable Data
		{
			set
			{
				Xpos = value.Xpos;
				Ypos = value.Ypos;
				Zoom = value.Zoom;
				RotationAngle = value.RotationAngle;
				LegendTxt = value.LegendTxt;
				FontColor = value.FontColor;
				Font = value.Font;
			}
		}
	}
}