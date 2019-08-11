using System;
using System.Collections.Generic;

namespace Models.local
{
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// @hibernate.class table="TAKEOFFLINE"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class TakeoffLineTable
	{

		private long? id;

		private decimal startXPos;
		private decimal startYPos;

		private decimal endXPos;
		private decimal endYPos;

		private IList<TakeoffPointTable> elevationSamples;

		private TakeoffConditionTable conditionTable;

		public TakeoffLineTable() : base()
		{
		}


		public TakeoffLineTable(decimal startXPos, decimal startYPos, decimal endXPos, decimal endYPos) : base()
		{
			this.startXPos = startXPos;
			this.startYPos = startYPos;
			this.endXPos = endXPos;
			this.endYPos = endYPos;
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
		/// @hibernate.property column="SX" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal StartXPos
		{
			get
			{
				return startXPos;
			}
			set
			{
				this.startXPos = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SY" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal StartYPos
		{
			get
			{
				return startYPos;
			}
			set
			{
				this.startYPos = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="EX" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal EndXPos
		{
			get
			{
				return endXPos;
			}
			set
			{
				this.endXPos = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="EY" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal EndYPos
		{
			get
			{
				return endYPos;
			}
			set
			{
				this.endYPos = value;
			}
		}


		/// <summary>
		/// @hibernate.list  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="SID"
		/// @hibernate.list-index
		///  column="ELEVCOUNT"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.TakeoffPointTable"
		/// return List
		/// </summary>
		public virtual IList<TakeoffPointTable> ElevationSamples
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
		/// @hibernate.many-to-one
		///  column="LID" </summary>
		/// <returns> FunctionTable </returns>
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
			TakeoffLineTable obj = new TakeoffLineTable();

			obj.Id = Id;
			obj.StartXPos = StartXPos;
			obj.StartYPos = StartYPos;
			obj.EndXPos = EndXPos;
			obj.EndYPos = EndYPos;

			return obj;
		}

		public virtual TakeoffLineTable Data
		{
			set
			{
				StartXPos = value.StartXPos;
				StartYPos = value.StartYPos;
				EndXPos = value.EndXPos;
				EndYPos = value.EndYPos;
			}
		}

		public virtual object copy(bool cyclic)
		{
			TakeoffLineTable obj = (TakeoffLineTable)clone();

			obj.ElevationSamples = new List<TakeoffPointTable>();
			if (ElevationSamples != null)
			{
				foreach (TakeoffPointTable point in ElevationSamples)
				{
					point = (TakeoffPointTable)point.clone();
					if (cyclic)
					{
						point.LineTable = obj;
					}
					obj.ElevationSamples.Add(point);
				}
			}

			return obj;
		}
	}

}