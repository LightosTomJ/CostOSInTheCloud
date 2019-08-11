using System;
using System.Collections.Generic;

namespace Models.local
{
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// @hibernate.class table="TAKEOFFAREA"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class TakeoffAreaTable
	{

		private long? id;
		private bool? blankFill;
		private bool? connectedLine;
		private decimal bezierTension;
		private IList<TakeoffPointTable> polygon;
		private TakeoffConditionTable conditionTable;
		private IList<TakeoffTriangleTable> triangles; // in case we use elevations


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
		/// @hibernate.property column="BLANKFILL" type="boolean" </summary>
		/// <returns> description </returns>
		public virtual bool? BlankFill
		{
			get
			{
				return blankFill;
			}
			set
			{
				this.blankFill = value;
			}
		}



		/// <summary>
		/// @hibernate.property column="CONLINE" type="boolean" </summary>
		/// <returns> description </returns>
		public virtual bool? ConnectedLine
		{
			get
			{
				return connectedLine;
			}
			set
			{
				this.connectedLine = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TENSION" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal BezierTension
		{
			get
			{
				return bezierTension;
			}
			set
			{
				this.bezierTension = value;
			}
		}


		/// <summary>
		/// @hibernate.list  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="PID"
		/// @hibernate.list-index
		///  column="POLYCOUNT"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.TakeoffPointTable"
		/// return List
		/// </summary>
		public virtual IList<TakeoffPointTable> Polygon
		{
			get
			{
				return polygon;
			}
			set
			{
				this.polygon = value;
			}
		}


		/// <summary>
		/// @hibernate.list  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="TID"
		/// @hibernate.list-index
		///  column="TRIACOUNT"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.TakeoffTriangleTable"
		/// return List
		/// </summary>
		public virtual IList<TakeoffTriangleTable> Triangles
		{
			get
			{
				return triangles;
			}
			set
			{
				this.triangles = value;
			}
		}


		/// <summary>
		/// @hibernate.many-to-one
		///  column="AID" </summary>
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
			TakeoffAreaTable obj = new TakeoffAreaTable();
			obj.Id = Id;
			obj.BlankFill = BlankFill;
			obj.ConnectedLine = ConnectedLine;
			obj.BezierTension = BezierTension;
			return obj;
		}

		public virtual TakeoffAreaTable Data
		{
			set
			{
				Id = value.Id;
				BlankFill = value.BlankFill;
				ConnectedLine = value.ConnectedLine;
				BezierTension = value.BezierTension;
			}
		}

		public virtual object copy(bool cyclic)
		{
			TakeoffAreaTable obj = (TakeoffAreaTable)clone();

			obj.Polygon = new List<TakeoffPointTable>();
			obj.Triangles = new List<TakeoffTriangleTable>();

			if (Polygon != null)
			{
				foreach (TakeoffPointTable point in Polygon)
				{
					point = (TakeoffPointTable)point.clone();
					if (cyclic)
					{
						point.AreaTable = obj;
					}
					obj.Polygon.Add(point);
				}
			}

			if (Triangles != null)
			{
				foreach (TakeoffTriangleTable triangle in Triangles)
				{
					triangle = (TakeoffTriangleTable)triangle.clone();
					if (cyclic)
					{
						triangle.AreaTable = obj;
					}
					obj.Triangles.Add(triangle);
				}
			}

			return obj;
		}
	}

}