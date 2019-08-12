using System;

namespace Model.local
{
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// @hibernate.class table="TAKEOFFPOINT"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class TakeoffPointTable
	{

		private long? id;
		private decimal xPos;
		private decimal yPos;
		private decimal zPos; // elevation

		private TakeoffAreaTable areaTable;
		private TakeoffLineTable lineTable;
		private TakeoffConditionTable conditionTable;

		public TakeoffPointTable() : base()
		{
		}

		public TakeoffPointTable(decimal xpos1, decimal ypos1, decimal zpos1) : base()
		{
			xPos = xpos1;
			yPos = ypos1;
			zPos = zpos1;
		}
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
		/// @hibernate.property column="ZPOS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Zpos
		{
			get
			{
				return zPos;
			}
			set
			{
				this.zPos = value;
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
		/// @hibernate.many-to-one
		///  column="PID" </summary>
		/// <returns> TakeoffAreaTable </returns>
		public virtual TakeoffAreaTable AreaTable
		{
			get
			{
				return areaTable;
			}
			set
			{
				this.areaTable = value;
			}
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="SID" </summary>
		/// <returns> TakeoffAreaTable </returns>
		public virtual TakeoffLineTable LineTable
		{
			get
			{
				return lineTable;
			}
			set
			{
				this.lineTable = value;
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
			TakeoffPointTable obj = new TakeoffPointTable();
			obj.Id = Id;
			obj.Xpos = Xpos;
			obj.Ypos = Ypos;
			obj.Zpos = Zpos;
			return obj;
		}

		public virtual TakeoffPointTable Data
		{
			set
			{
				Xpos = value.Xpos;
				Ypos = value.Ypos;
				Zpos = value.Zpos;
			}
		}
	}

}