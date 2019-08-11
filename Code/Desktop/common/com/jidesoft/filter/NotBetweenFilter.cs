using System;

namespace Desktop.common.com.jidesoft.filter
{
	using JideSwingUtilities = Desktop.common.com.jidesoft.swing.JideSwingUtilities;

	public class NotBetweenFilter<T> : BetweenFilter<T>
	{
	  private const long serialVersionUID = -6203611824586727309L;

	  public NotBetweenFilter()
	  {
	  }

	  public NotBetweenFilter(T paramT1, T paramT2) : base(paramT1, paramT2)
	  {
	  }

	  public NotBetweenFilter(string paramString, T paramT1, T paramT2) : base(paramString, paramT1, paramT2)
	  {
	  }

	  public virtual bool isValueFiltered(T paramT)
	  {
		  return (paramT == default(T) || !base.isValueFiltered(paramT));
	  }

	  public virtual string Operator
	  {
		  get
		  {
			  return " NOT " + base.Operator;
		  }
	  }

	  public virtual bool stricterThan(Filter paramFilter)
	  {
		if (this.GetType() != paramFilter.GetType())
		{
		  return false;
		}
		object object1 = ((NotBetweenFilter)paramFilter).Value1;
		object object2 = ((NotBetweenFilter)paramFilter).Value2;
		return (object1 is Number && this._value1 is Number && object2 is Number && this._value2 is Number && ((Number)this._value1).doubleValue() <= ((Number)object1).doubleValue()) ? ((((Number)this._value2).doubleValue() >= ((Number)object2).doubleValue())) : ((object1 is IComparable && object2 is IComparable && this._value1 != null && this._value2 != null && ((IComparable)object1).CompareTo(this._value1) >= 0) ? ((((IComparable)object2).CompareTo(this._value2) <= 0)) : ((this._value1 is IComparable && this._value2 is IComparable && ((IComparable)this._value1).CompareTo(object1) <= 0) ? ((((IComparable)this._value2).CompareTo(object2) >= 0)) : false));
	  }

	  public override bool Equals(object paramObject)
	  {
		  return (paramObject != null && paramObject.GetType() == this.GetType() && JideSwingUtilities.Equals(Value1, ((NotBetweenFilter)paramObject).Value1, true) && JideSwingUtilities.Equals(Value2, ((NotBetweenFilter)paramObject).Value2, true));
	  }
	}

	 // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\com\jidesoft\filter\NotBetweenFilter.class
	 // Java compiler version: 8 (52.0)
	 // JD-Core Version:       1.0.7
}