using System;

namespace Model.proj
{

	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	//#RXL_START
	//#RXP_START
	/// <summary>
	/// @author: George Ilias
	/// 
	/// 
	/// @hibernate.class table="EXPENSES"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	//#RXL_END
	[Serializable]
	public class ExpenseTable : Transferable
	{

		private const long serialVersionUID = 1L;

		public static readonly string[] FIELDS = new string[] {"code", "description", "unit", "materialRate", "subconstractorsRate", "laborRate", "miscRate", "quantity", "rate", "months", "percent", "totalCost"};

		private long? expenseId = null;
		private string code = null;
		private string description = null;
		private string unit = null;
		private decimal quantity = null;
		private decimal customRate = null;
		private decimal months = null;
		private decimal percent = null;

		private decimal materialRate = null;
		private decimal subcontractorsRate = null;
		private decimal laborRate = null;
		private decimal miscRate = null;

		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.expenseDataFlavor};

		public ExpenseTable()
		{

		}

		public virtual object clone()
		{
			ExpenseTable obj = new ExpenseTable();

			obj.Code = Code;
			obj.Description = Description;
			obj.Unit = Unit;
			obj.Quantity = Quantity;
			obj.CustomRate = CustomRate;
			obj.Months = Months;
			obj.Percent = Percent;
			obj.MaterialRate = MaterialRate;
			obj.SubcontractorsRate = SubcontractorsRate;
			obj.LaborRate = LaborRate;
			obj.MiscRate = MiscRate;

			return obj;
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="EXPENSEID" </summary>
		/// <returns> Long </returns>
		public virtual long? ExpenseId
		{
			get
			{
				return expenseId;
			}
			set
			{
				expenseId = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CODE" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string Code
		{
			get
			{
				return code;
			}
			set
			{
				this.code = value;
			}
		}




		/// <summary>
		/// Description Here
		/// 
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
		/// Description Here
		/// 
		/// @hibernate.property column="UNIT" type="costos_string" </summary>
		/// <returns> unit </returns>
		public virtual string Unit
		{
			get
			{
				return unit;
			}
			set
			{
				this.unit = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="QUANTITY" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> quantity </returns>
		public virtual decimal Quantity
		{
			get
			{
				return quantity;
			}
			set
			{
				this.quantity = value;
			}
		}




		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CUSTOM_RATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal CustomRate
		{
			get
			{
				return customRate;
			}
			set
			{
				this.customRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="MONTHS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> months </returns>
		public virtual decimal Months
		{
			get
			{
				return months;
			}
			set
			{
				this.months = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PRCNT" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> percent </returns>
		public virtual decimal Percent
		{
			get
			{
				return percent;
			}
			set
			{
				this.percent = value;
			}
		}


		public virtual decimal TotalCost
		{
			get
			{
    
		//		if (getRate() == null) rate = BigDecimalMath.ZERO;
				if (quantity == null)
				{
					quantity = BigDecimalMath.ZERO;
				}
				if (months == null)
				{
					months = BigDecimalMath.ZERO;
				}
				if (percent == null)
				{
					percent = BigDecimalMath.ZERO;
				}
    
				if (Rate != null && quantity != null)
				{
    
					if (!months.Equals(BigDecimalMath.ZERO))
					{
						return Rate * months;
					}
					else if (!percent.Equals(BigDecimalMath.ZERO))
					{
						return Rate * (percent * (new BigDecimalFixed("0.01")));
					}
				}
				return (BigDecimalMath.ZERO);
			}
		}

		public virtual string Category
		{
			get
			{ //examples are 1.1, 2.16 etc.
    
				if (code.IndexOf(".", StringComparison.Ordinal) == -1)
				{ //if it does not contain .
					return "0"; // it is a base category
    
				}
				else if (code.Equals(""))
				{ //case it is a newly created record about to be updated
					return "";
				}
    
				return code.Substring(0,code.LastIndexOf(".", StringComparison.Ordinal));
			}
		}



		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LABOR_RATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal LaborRate
		{
			get
			{
				return laborRate;
			}
			set
			{
				this.laborRate = value;
			}
		}



		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SUBCONTRACTORS_RATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal SubcontractorsRate
		{
			get
			{
				return subcontractorsRate;
			}
			set
			{
				this.subcontractorsRate = value;
			}
		}



		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="MATERIAL_RATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal MaterialRate
		{
			get
			{
				return materialRate;
			}
			set
			{
				this.materialRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="MISC_RATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal MiscRate
		{
			get
			{
				return miscRate;
			}
			set
			{
				this.miscRate = value;
			}
		}



		public virtual decimal CalculatedRate
		{
			get
			{
    
				if (MaterialRate == null)
				{
					MaterialRate = BigDecimalMath.ZERO;
				}
				if (SubcontractorsRate == null)
				{
					SubcontractorsRate = BigDecimalMath.ZERO;
				}
				if (LaborRate == null)
				{
					LaborRate = BigDecimalMath.ZERO;
				}
				if (MiscRate == null)
				{
					MiscRate = BigDecimalMath.ZERO;
				}
    
				decimal sum = MaterialRate + SubcontractorsRate.add(LaborRate).add(MiscRate);
    
				return sum * Quantity;
			}
		}



		public virtual decimal Rate
		{
			get
			{
    
				if (CustomRate != null)
				{
					return CustomRate;
				}
				else
				{
					return CalculatedRate;
				}
			}
			set
			{
    
				CustomRate = value;
    
			}
		}


		public virtual DataFlavor[] TransferDataFlavors
		{
			get
			{
				lock (this)
				{
					return s_supportedDataFlavors;
				}
			}
		}

		public virtual bool isDataFlavorSupported(DataFlavor flavor)
		{
			return DataFlavors.expenseDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.expenseDataFlavor.Equals(flavor))
				{
					return this;
				}
        
				throw new UnsupportedFlavorException(flavor);
			}
		}

	}

}