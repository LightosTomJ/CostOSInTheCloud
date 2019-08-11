using System;
using System.Collections.Generic;

namespace Models.local
{

	using DatabaseTable = nomitech.common.@base.DatabaseTable;
	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="PARAMOUTPUT"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>

	[Serializable]
	public class ParamItemOutputTable : DatabaseTable, IComparable, ProjectIdEntity
	{

		public static readonly string[] VIEWABLE_FIELDS = new string[] {"paramOutputId", "title", "sortOrder", "factorEquation", "quantityEquation", "productivityEquation", "generationCondition", "resourceIds"};

		private long? paramOutputId;

		private string quantityEquation;
		private string factorEquation;

		private string labLocEquation;
		private string matLocEquation;
		private string equLocEquation;
		private string subLocEquation;
		private string conLocEquation;

		private string generationCondition;
		private string title;
		private string productivityEquation;

		private int? sortOrder;
		private string loopVar;

		private string resourceIds;

		private ParamItemTable paramItemTable;
		private ISet<ParamItemConceptualResourceTable> conceptualSet;
		private ISet<ParamItemQueryResourceTable> queryResourceSet;

		public virtual object valueForField(string field)
		{
			return field;
		}

		public virtual ParamItemOutputTable Data
		{
			set
			{
				FactorEquation = value.FactorEquation;
				QuantityEquation = value.QuantityEquation;
				GenerationCondition = value.GenerationCondition;
				ResourceIds = value.ResourceIds;
				SortOrder = value.SortOrder;
				LoopVar = value.LoopVar;
				Title = value.Title;
				ProductivityEquation = value.ProductivityEquation;
    
				LabLocEquation = value.LabLocEquation;
				MatLocEquation = value.MatLocEquation;
				EquLocEquation = value.EquLocEquation;
				SubLocEquation = value.SubLocEquation;
				ConLocEquation = value.ConLocEquation;
			}
		}

		public virtual object clone()
		{
			ParamItemOutputTable pItemTable = new ParamItemOutputTable();

			pItemTable.ParamOutputId = ParamOutputId;
			pItemTable.FactorEquation = FactorEquation;
			pItemTable.QuantityEquation = QuantityEquation;
			pItemTable.GenerationCondition = GenerationCondition;
			pItemTable.ResourceIds = ResourceIds;
			pItemTable.SortOrder = SortOrder;
			pItemTable.LoopVar = LoopVar;
			pItemTable.Title = Title;
			pItemTable.ProductivityEquation = ProductivityEquation;

			pItemTable.LabLocEquation = LabLocEquation;
			pItemTable.MatLocEquation = MatLocEquation;
			pItemTable.EquLocEquation = EquLocEquation;
			pItemTable.SubLocEquation = SubLocEquation;
			pItemTable.ConLocEquation = ConLocEquation;
			pItemTable.ProjectId = ProjectId;

			return pItemTable;
		}

		public virtual object copy()
		{
			ParamItemOutputTable pItemTable = (ParamItemOutputTable) clone();

			if (ConceptualSet != null)
			{
				pItemTable.ConceptualSet = new HashSet<ParamItemConceptualResourceTable>();
				foreach (ParamItemConceptualResourceTable table in ConceptualSet)
				{
					pItemTable.ConceptualSet.Add((ParamItemConceptualResourceTable) table.clone());
				}
			}
			if (QueryResourceSet != null)
			{
				pItemTable.QueryResourceSet = new HashSet<ParamItemQueryResourceTable>();
				foreach (ParamItemQueryResourceTable table in QueryResourceSet)
				{
					pItemTable.QueryResourceSet.Add((ParamItemQueryResourceTable) table.copy());
				}
			}

			return pItemTable;
		}

		public virtual object copyWithParamItem()
		{
			ParamItemOutputTable pItemTable = (ParamItemOutputTable) copy();

			if (ParamItemTable != null)
			{
				pItemTable.ParamItemTable = (ParamItemTable) paramItemTable.clone();
			}
			return pItemTable;
		}
		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="PARAMOUTPUTID" </summary>
		/// <returns> Long </returns>
		public virtual long? ParamOutputId
		{
			get
			{
				return paramOutputId;
			}
			set
			{
				this.paramOutputId = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="QTYEQ" type="costos_text" </summary>
		/// <returns> title </returns>
		public virtual string QuantityEquation
		{
			get
			{
				return quantityEquation;
			}
			set
			{
				this.quantityEquation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FACTOREQ" type="costos_text" </summary>
		/// <returns> title </returns>
		public virtual string FactorEquation
		{
			get
			{
				return factorEquation;
			}
			set
			{
				this.factorEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="LABLOCEQ" type="costos_text" </summary>
		/// <returns> title </returns>
		public virtual string LabLocEquation
		{
			get
			{
				return labLocEquation;
			}
			set
			{
				this.labLocEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="MATLOCEQ" type="costos_text" </summary>
		/// <returns> title </returns>
		public virtual string MatLocEquation
		{
			get
			{
				return matLocEquation;
			}
			set
			{
				this.matLocEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EQULOCEQ" type="costos_text" </summary>
		/// <returns> title </returns>
		public virtual string EquLocEquation
		{
			get
			{
				return equLocEquation;
			}
			set
			{
				this.equLocEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="SUBLOCEQ" type="costos_text" </summary>
		/// <returns> title </returns>
		public virtual string SubLocEquation
		{
			get
			{
				return subLocEquation;
			}
			set
			{
				this.subLocEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CONLOCEQ" type="costos_text" </summary>
		/// <returns> title </returns>
		public virtual string ConLocEquation
		{
			get
			{
				return conLocEquation;
			}
			set
			{
				this.conLocEquation = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PRDEQ" type="costos_text" </summary>
		/// <returns> title </returns>
		public virtual string ProductivityEquation
		{
			get
			{
				return productivityEquation;
			}
			set
			{
				this.productivityEquation = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TITLE" type="costos_text" </summary>
		/// <returns> title </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="RESIDS" type="costos_text" </summary>
		/// <returns> title </returns>
		public virtual string ResourceIds
		{
			get
			{
				return resourceIds;
			}
			set
			{
				this.resourceIds = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="GENERATION" type="costos_text" </summary>
		/// <returns> title </returns>
		public virtual string GenerationCondition
		{
			get
			{
				return generationCondition;
			}
			set
			{
				this.generationCondition = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SORTORDER" type="int" </summary>
		/// <returns> title </returns>
		public virtual int? SortOrder
		{
			get
			{
				return sortOrder;
			}
			set
			{
				this.sortOrder = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LOOPVAR" type="string" </summary>
		/// <returns> title </returns>
		public virtual string LoopVar
		{
			get
			{
				return loopVar;
			}
			set
			{
				this.loopVar = value;
			}
		}


		/// <summary>
		/// @hibernate.many-to-one
		///  column="PARAMITEMID" </summary>
		/// <returns> ParamItemTable </returns>
		public virtual ParamItemTable ParamItemTable
		{
			get
			{
				return paramItemTable;
			}
			set
			{
				this.paramItemTable = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="false"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="PARAMOUTPUTID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ParamItemConceptualResourceTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<ParamItemConceptualResourceTable> ConceptualSet
		{
			get
			{
				return conceptualSet;
			}
			set
			{
				this.conceptualSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="false"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="PARAMOUTPUTID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ParamItemQueryResourceTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<ParamItemQueryResourceTable> QueryResourceSet
		{
			get
			{
				return queryResourceSet;
			}
			set
			{
				this.queryResourceSet = value;
			}
		}


		public virtual int CompareTo(object o)
		{
			if (o is ParamItemOutputTable)
			{
				return SortOrder.compareTo(((ParamItemOutputTable) o).SortOrder);
			}
			return -1;
		}

		public override string Description
		{
			get
			{
				// TODO Auto-generated method stub
				return null;
			}
			set
			{
				// TODO Auto-generated method stub
			}
		}

		public override decimal TableRate
		{
			get
			{
				// TODO Auto-generated method stub
				return null;
			}
		}

		public override long? Id
		{
			get
			{
				return ParamOutputId;
			}
		}

		public override string EditorId
		{
			get
			{
				// TODO Auto-generated method stub
				return null;
			}
			set
			{
				// TODO Auto-generated method stub
    
			}
		}

		public override string CreateUserId
		{
			get
			{
				// TODO Auto-generated method stub
				return null;
			}
			set
			{
				// TODO Auto-generated method stub
    
			}
		}

		public override DateTime CreateDate
		{
			get
			{
				// TODO Auto-generated method stub
				return null;
			}
			set
			{
				// TODO Auto-generated method stub
    
			}
		}

		public override DateTime LastUpdate
		{
			get
			{
				// TODO Auto-generated method stub
				return null;
			}
			set
			{
				// TODO Auto-generated method stub
    
			}
		}





		public override string ToString()
		{
			return Title;
		}


		private long? projectId;
		//#RXL_START
		/// <summary>
		/// @hibernate.property column="PRJID" type="long" index="IDX_PRJID" </summary>
		/// <returns> BigDecimal </returns>
		//#RXL_END
		public override long? ProjectId
		{
			get
			{
				return projectId;
			}
			set
			{
				this.projectId = value;
			}
		}

	}

}