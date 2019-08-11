using System;

namespace Desktop.common.nomitech.common.bim
{
	using IfcElementPropertyTable = nomitech.common.db.project.IfcElementPropertyTable;
	using StringUtils = nomitech.common.util.StringUtils;

	[Serializable]
	public class BIMProperty
	{
	  private string name;

	  private int qtyType;

	  private bool number;

	  private string value;

	  private double doubleValue;

	  public BIMProperty()
	  {
	  }

	  public BIMProperty(string paramString1, int paramInt, bool paramBoolean, string paramString2, double paramDouble)
	  {
		this.name = paramString1;
		this.qtyType = paramInt;
		this.number = paramBoolean;
		this.value = paramString2;
		this.doubleValue = paramDouble;
	  }

	  public virtual string Name
	  {
		  get
		  {
			  return this.name;
		  }
		  set
		  {
			  this.name = value;
		  }
	  }


	  public virtual int QtyType
	  {
		  get
		  {
			  return this.qtyType;
		  }
		  set
		  {
			  this.qtyType = value;
		  }
	  }


	  public virtual bool Number
	  {
		  get
		  {
			  return this.number;
		  }
		  set
		  {
			  this.number = value;
		  }
	  }


	  public virtual string Value
	  {
		  get
		  {
			  return this.value;
		  }
		  set
		  {
			  this.value = value;
		  }
	  }


	  public virtual double DoubleValue
	  {
		  get
		  {
			  return this.doubleValue;
		  }
		  set
		  {
			  this.doubleValue = value;
		  }
	  }


	  public virtual string CostosUOM
	  {
		  get
		  {
			  return (this.qtyType == BIMQuantityType.QTY_CUBIC_METER) ? "M3" : ((this.qtyType == BIMQuantityType.QTY_SQUARE_METER) ? "M2" : ((this.qtyType == BIMQuantityType.QTY_MILLI_METER) ? "LM" : ((this.qtyType == 0) ? "EACH" : "UNKNOWN")));
		  }
	  }

	  public virtual IfcElementPropertyTable convertToIfcElementPropertyTable()
	  {
		IfcElementPropertyTable ifcElementPropertyTable = new IfcElementPropertyTable();
		ifcElementPropertyTable.Name = Name;
		ifcElementPropertyTable.QtyType = Convert.ToInt32(QtyType);
		ifcElementPropertyTable.MetricUom = CostosUOM;
		ifcElementPropertyTable.Value = Value;
		ifcElementPropertyTable.NumberValue = new decimal(DoubleValue);
		ifcElementPropertyTable.Number = Convert.ToBoolean(Number);
		return ifcElementPropertyTable;
	  }

	  public virtual int? IntegerValue
	  {
		  get
		  {
			  return this.number ? Convert.ToInt32((int)this.doubleValue) : (StringUtils.isInteger(this.value) ? Convert.ToInt32(int.Parse(this.value)) : null);
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMProperty.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}