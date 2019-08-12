namespace Model.local
{

	//#RXP_START
	/// <summary>
	/// @author George Hatzisymeon
	/// 
	/// @hibernate.class table="BENCHMARKBOQCOLMAP"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	public class BenchmarkToBoqColumnMappingTable
	{

		private long? id;
		private long? templateId;
		private string fromBench;
		private string toBoq;
		private string aggregate;
		private string viewName;

		/// <summary>
		/// @hibernate.id generator-class="native" unsaved-value="null" column="ID" </summary>
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
		/// @hibernate.property column="TEMPLATEID" type="long" </summary>
		/// <returns> Long </returns>
		public virtual long? TemplateId
		{
			get
			{
				return templateId;
			}
			set
			{
				this.templateId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FROMBENCH" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string FromBench
		{
			get
			{
				return fromBench;
			}
			set
			{
				this.fromBench = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="TOBOQ" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string ToBoq
		{
			get
			{
				return toBoq;
			}
			set
			{
				this.toBoq = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="AGGREGATE" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Aggregate
		{
			get
			{
				return aggregate;
			}
			set
			{
				this.aggregate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="VIEWNAME" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string ViewName
		{
			get
			{
				return viewName;
			}
			set
			{
				this.viewName = value;
			}
		}

		public virtual BenchmarkToBoqColumnMappingTable Data
		{
			set
			{
				TemplateId = TemplateId;
				FromBench = FromBench;
				ToBoq = ToBoq;
				Aggregate = Aggregate;
				ViewName = ViewName;
			}
		}

		public override BenchmarkToBoqColumnMappingTable clone()
		{
			BenchmarkToBoqColumnMappingTable table = new BenchmarkToBoqColumnMappingTable();
			table.Id = Id;
			table.Data = this;
			return table;
		}

	}

}