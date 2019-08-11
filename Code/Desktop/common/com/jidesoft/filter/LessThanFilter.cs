using System;

namespace Desktop.common.com.jidesoft.filter
{
	using JideSwingUtilities = Desktop.common.com.jidesoft.swing.JideSwingUtilities;

	public class LessThanFilter<T> : EqualFilter<T>
	{
	  private const long serialVersionUID = 5587882436883397356L;

	  public LessThanFilter()
	  {
	  }

	  public LessThanFilter(T paramT) : base(paramT)
	  {
	  }

	  public LessThanFilter(string paramString, T paramT) : base(paramString, paramT)
	  {
	  }

	  public virtual bool isValueFiltered(T paramT)
	  {
		if (paramT == default(T))
		{
		  return true;
		}
		if (ObjectGrouper != null)
		{
		  paramT = (T)ObjectGrouper.getValue(paramT);
		}
		return (paramT is Number && this._value is Number) ? ((((Number)paramT).doubleValue() >= ((Number)this._value).doubleValue())) : ((paramT is IComparable && this._value != null) ? ((((IComparable)paramT).CompareTo(this._value) >= 0)) : ((this._value is IComparable) ? ((((IComparable)this._value).CompareTo(paramT) < 0)) : true));
	  }

	  public virtual string Operator
	  {
		  get
		  {
			  return "<";
		  }
	  }

	  public virtual bool stricterThan(Filter paramFilter)
	  {
		int i = FilterFactoryManager.d;
		if (this.GetType() != paramFilter.GetType())
		{
		  return false;
		}
		object @object = ((LessThanFilter)paramFilter).Value;
		return (@object is Number && this._value is Number) ? ((((Number)this._value).doubleValue() <= ((Number)@object).doubleValue())) : ((@object is IComparable && this._value != null) ? ((((IComparable)@object).CompareTo(this._value) >= 0)) : ((this._value is IComparable) ? ((((IComparable)this._value).CompareTo(@object) <= 0)) : false));
	  }

	  public override bool Equals(object paramObject)
	  {
		  return (paramObject != null && paramObject.GetType() == this.GetType() && JideSwingUtilities.Equals(Value, ((LessThanFilter)paramObject).Value, true));
	  }
	}


	 // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\com\jidesoft\filter\LessThanFilter.class
	 // Java compiler version: 8 (52.0)
	 // JD-Core Version:       1.0.7
	 
}