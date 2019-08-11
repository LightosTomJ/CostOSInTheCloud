using System.Collections.Generic;

namespace Desktop.common.nomitech.costos.plugin.api
{
	using BoqItemConditionTable = nomitech.common.db.project.BoqItemConditionTable;
	using BoqItemTable = nomitech.common.db.project.BoqItemTable;
	using ConditionTable = nomitech.common.db.project.ConditionTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;

	public class ItemIdWithQuantities
	{
	  private long? id;

	  private IList<decimal> quantity;

	  public ItemIdWithQuantities(long? paramLong)
	  {
		this.id = paramLong;
		this.quantity = null;
	  }

	  public ItemIdWithQuantities(long? paramLong, IList<decimal> paramList)
	  {
		this.id = paramLong;
		this.quantity = paramList;
	  }

	  public virtual long? Id
	  {
		  get
		  {
			  return this.id;
		  }
		  set
		  {
			  this.id = value;
		  }
	  }


	  public virtual IList<decimal> Quantities
	  {
		  get
		  {
			  return this.quantity;
		  }
		  set
		  {
			  this.quantity = value;
		  }
	  }


	  public virtual BoqItemConditionTable[] createBoqConditions(BoqItemTable paramBoqItemTable, ConditionTable[] paramArrayOfConditionTable)
	  {
		BoqItemConditionTable[] arrayOfBoqItemConditionTable = new BoqItemConditionTable[paramArrayOfConditionTable.Length];
		sbyte b = 0;
		foreach (ConditionTable conditionTable in paramArrayOfConditionTable)
		{
		  decimal bigDecimal = null;
		  if (Quantities != null && Quantities.Count > b)
		  {
			bigDecimal = (decimal)Quantities[b];
		  }
		  BoqItemConditionTable boqItemConditionTable = new BoqItemConditionTable();
		  string str = "";
		  if (conditionTable.DefaultQuantity == null || conditionTable.DefaultQuantity.Value == 0)
		  {
			boqItemConditionTable.SelectedUnit = "selectedQty.1";
			str = conditionTable.Unit1;
			if (conditionTable.Quantity2 != null && !conditionTable.Quantity2.Equals(new BigDecimalFixed("0")))
			{
			  boqItemConditionTable.SelectedUnit = "selectedQty.2";
			  str = conditionTable.Unit2;
			}
			if (conditionTable.Quantity3 != null && !conditionTable.Quantity3.Equals(new BigDecimalFixed("0")))
			{
			  boqItemConditionTable.SelectedUnit = "selectedQty.3";
			  str = conditionTable.Unit3;
			}
			if (conditionTable.QuantityF != null && !conditionTable.QuantityF.Equals(new BigDecimalFixed("0")))
			{
			  boqItemConditionTable.SelectedUnit = "selectedQty.F";
			  str = conditionTable.UnitF;
			}
		  }
		  else if (conditionTable.DefaultQuantity.Value == 1)
		  {
			boqItemConditionTable.SelectedUnit = "selectedQty.1";
			str = conditionTable.Unit1;
		  }
		  else if (conditionTable.DefaultQuantity.Value == 2)
		  {
			boqItemConditionTable.SelectedUnit = "selectedQty.2";
			str = conditionTable.Unit2;
		  }
		  else if (conditionTable.DefaultQuantity.Value == 3)
		  {
			boqItemConditionTable.SelectedUnit = "selectedQty.3";
			str = conditionTable.Unit3;
		  }
		  else if (conditionTable.DefaultQuantity.Value == 4)
		  {
			boqItemConditionTable.SelectedUnit = "selectedQty.F";
			str = conditionTable.UnitF;
		  }
		  if (!str.Equals(paramBoqItemTable.Unit))
		  {
			if (str.Equals(conditionTable.Unit1))
			{
			  boqItemConditionTable.SelectedUnit = "selectedQty.1";
			}
			if (str.Equals(conditionTable.Unit2))
			{
			  boqItemConditionTable.SelectedUnit = "selectedQty.2";
			}
			if (str.Equals(conditionTable.Unit3))
			{
			  boqItemConditionTable.SelectedUnit = "selectedQty.3";
			}
			if (str.Equals(conditionTable.UnitF))
			{
			  boqItemConditionTable.SelectedUnit = "selectedQty.F";
			}
		  }
		  boqItemConditionTable.Factor1 = BigDecimalMath.ONE;
		  boqItemConditionTable.Factor2 = BigDecimalMath.ONE;
		  boqItemConditionTable.Sumup = BigDecimalMath.ZERO;
		  if (BigDecimalMath.cmp(bigDecimal, BigDecimalMath.ZERO) > 0)
		  {
			boqItemConditionTable.OverridenQuantity = bigDecimal;
		  }
		  boqItemConditionTable.BoqItemTable = paramBoqItemTable;
		  boqItemConditionTable.ConditionTable = conditionTable;
		  boqItemConditionTable.LastUpdate = new Timestamp(DateTimeHelper.CurrentUnixTimeMillis());
		  arrayOfBoqItemConditionTable[b++] = boqItemConditionTable;
		}
		return arrayOfBoqItemConditionTable;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\ItemIdWithQuantities.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}