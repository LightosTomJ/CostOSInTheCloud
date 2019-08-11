using System;
using System.Collections.Generic;

namespace Models.proj
{

	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	//#RXL_START
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="PAYMENT"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
	//#RXP_END
	[Serializable]
	public class SalaryTable : Transferable
	{

		private const long serialVersionUID = 1L;

		public static readonly string[] FIELDS = new string[] {"salaryIncId", "description", "category", "salary", "factor", "months", "compensation", "total"};

		private long? salaryId = null;
		private string description = null;
		private string category = null;
		private decimal factor = null;
		private decimal salary = null;
		private decimal months = null;
		private decimal customCompensation = null;
		private long? salaryIncId = new long?(0);

		private static List<object> compensationCategoryNames = new List<object>();

		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.salaryDataFlavor};

		public SalaryTable()
		{

		}

		public virtual object clone()
		{
			SalaryTable obj = new SalaryTable();

			obj.Category = Category;
			obj.Description = Description;
			obj.Salary = Salary;
			obj.SalaryIncId = SalaryIncId;
			obj.Factor = Factor;
			obj.Months = Months;
			obj.Compensation = Compensation;

			return obj;
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="PAYMENTID" </summary>
		/// <returns> Long </returns>
		public virtual long? SalaryId
		{
			get
			{
				return salaryId;
			}
			set
			{
				salaryId = value;
				//o_map.put("salaryId",value);
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PAYMENTINCID" type="long" </summary>
		/// <returns> salaryId </returns>
		public virtual long? SalaryIncId
		{
			get
			{
				return salaryIncId;
			}
			set
			{
				salaryIncId = value;
				//o_map.put("salaryId",pKey);
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="DESCRIPTION" type="costos_text" </summary>
		/// <returns> rate </returns>
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
		/// @hibernate.property column="CATEGORY" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string Category
		{
			get
			{
				return category;
			}
			set
			{
				this.category = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PAYMENT_AMOUNT" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Salary
		{
			get
			{
				return salary;
			}
			set
			{
				this.salary = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FACTOR" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Factor
		{
			get
			{
				return factor;
			}
			set
			{
				this.factor = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="MONTHS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
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



		public virtual decimal CalculatedCompensation
		{
			get
			{
    
				if (string.ReferenceEquals(category, null) || !compensationCategoryNames.Contains(category))
				{
					return new BigDecimalFixed("0");
				}
    
    
				int m = months.toBigInteger().intValue(); //(round it down) if months=1.9 -> m = 1
    
				int[] comp = new int[25];
    
				//according to the given table for compensation calculation, it comes out the following formula:
				for (int i = 10;i <= 24 ; i++)
				{
					comp[i] = i - 4;
				}
    
				int compensation_months = 0;
    
				if (m < 2)
				{
    
					compensation_months = 0;
    
				}
				else if (m < 12)
				{
    
					compensation_months = 1;
    
				}
				else if (m < 12 * 4)
				{
    
					compensation_months = 2;
    
				}
				else if (m < 12 * 6)
				{
    
					compensation_months = 3;
    
				}
				else if (m < 12 * 8)
				{
    
					compensation_months = 4;
    
				}
				else if (m < 12 * 10)
				{
    
					compensation_months = 5;
    
				}
				else
				{
					int y = m / 12;
		//			System.out.println("[SalaryTable.getCalculatedCompensation]year = m / 12 =>  "+m+" / 12 = "+y + "  : comp[y] = "+comp[y]);
					compensation_months = comp[y];
    
				}
				decimal calculatedCompensation = (new BigDecimalFixed(compensation_months)).multiply(salary);
				return calculatedCompensation;
			}
		}



		public virtual decimal Total
		{
			get
			{
				//total = salary * months * factor + compensation 
				//System.out.println("Entering getTotal()..");
				return Salary * Months * Factor.add(Compensation);
			}
		}

		public virtual void addCompensationCategoryName(string compensationCategoryName)
		{
			compensationCategoryNames.Add(compensationCategoryName);
		}



		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CUSTOM_COMPENSATION" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal CustomCompensation
		{
			get
			{
    
				return customCompensation;
			}
			set
			{
    
				customCompensation = value;
			}
		}


		/*	
		 *  getCompensation() and setCompensation() are used to provide an uniform API   
		 *  and are not the expected hibernate methods to store and get from the database directly. 
		 */

		public virtual decimal Compensation
		{
			get
			{
    
		//		if(getCustomCompensation() == null || getCustomCompensation().equals(new BigDecimalFixed("0"))){
		//			return getCalculatedCompensation();
		//		}
		//		else{
		//			return getCustomCompensation();	
		//		}
    
				if (CustomCompensation == null)
				{
					CustomCompensation = new BigDecimalFixed("0");
				}
    
				return CustomCompensation;
			}
			set
			{
    
				CustomCompensation = value;
    
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
			return DataFlavors.salaryDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.salaryDataFlavor.Equals(flavor))
				{
					return this;
				}
        
				throw new UnsupportedFlavorException(flavor);
			}
		}
	}

}