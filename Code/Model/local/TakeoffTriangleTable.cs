using System;

namespace Model.local
{
	//#RXP_START

	/// <summary>
	/// @author: George Hatzisymeon
	/// @hibernate.class table="TAKEOFFTRIANGLE"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class TakeoffTriangleTable
	{

		private long? id;

		private decimal xPos1;
		private decimal yPos1;
		private decimal zPos1;
		private decimal xPos2;
		private decimal yPos2;
		private decimal zPos2;
		private decimal xPos3;
		private decimal yPos3;
		private decimal zPos3;

		private TakeoffAreaTable areaTable;

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
		/// @hibernate.property column="XPOS1" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Xpos1
		{
			get
			{
				return xPos1;
			}
			set
			{
				this.xPos1 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="YPOS1" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Ypos1
		{
			get
			{
				return yPos1;
			}
			set
			{
				this.yPos1 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ZPOS1" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Zpos1
		{
			get
			{
				return zPos1;
			}
			set
			{
				this.zPos1 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="XPOS2" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Xpos2
		{
			get
			{
				return xPos2;
			}
			set
			{
				this.xPos2 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="YPOS2" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Ypos2
		{
			get
			{
				return yPos2;
			}
			set
			{
				this.yPos2 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ZPOS2" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Zpos2
		{
			get
			{
				return zPos2;
			}
			set
			{
				this.zPos2 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="XPOS3" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Xpos3
		{
			get
			{
				return xPos3;
			}
			set
			{
				this.xPos3 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="YPOS3" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Ypos3
		{
			get
			{
				return yPos3;
			}
			set
			{
				this.yPos3 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ZPOS3" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Zpos3
		{
			get
			{
				return zPos3;
			}
			set
			{
				this.zPos3 = value;
			}
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="TID" </summary>
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

		public virtual object clone()
		{
			TakeoffTriangleTable obj = new TakeoffTriangleTable();

			obj.Id = Id;
			obj.Xpos1 = Xpos1;
			obj.Xpos2 = Xpos2;
			obj.Xpos3 = Xpos3;

			obj.Ypos1 = Ypos1;
			obj.Ypos2 = Ypos2;
			obj.Ypos3 = Ypos3;

			obj.Zpos1 = Zpos1;
			obj.Zpos2 = Zpos2;
			obj.Zpos3 = Zpos3;

			return obj;
		}

		public virtual TakeoffTriangleTable Data
		{
			set
			{
				Xpos1 = value.Xpos1;
				Xpos2 = value.Xpos2;
				Xpos3 = value.Xpos3;
    
				Ypos1 = value.Ypos1;
				Ypos2 = value.Ypos2;
				Ypos3 = value.Ypos3;
    
				Zpos1 = value.Zpos1;
				Zpos2 = value.Zpos2;
				Zpos3 = value.Zpos3;
			}
		}
	}

}