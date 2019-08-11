using System;
using System.Text;

namespace Desktop.common.nomitech.common.countries
{

	[Serializable]
	public class Country : IComparable
	{
	  private const long serialVersionUID = 3689355407466181430L;

	  public static readonly System.Collections.IComparer CASE_INSENSITIVE_ORDER = new ComparatorAnonymousInnerClass();

	  private class ComparatorAnonymousInnerClass : System.Collections.IComparer
	  {
		  public int compare(object param1Object1, object param1Object2)
		  {
			string str1 = ((Country)param1Object1).Label;
			string str2 = ((Country)param1Object2).Label;
			return string.Compare(str1, str2, StringComparison.OrdinalIgnoreCase);
		  }
	  }

	  private string label = null;

	  private string value = null;

	  public Country()
	  {
	  }

	  public Country(string paramString1, string paramString2)
	  {
		this.label = paramString1;
		this.value = paramString2;
	  }

	  public virtual string Label
	  {
		  get
		  {
			  return this.label;
		  }
		  set
		  {
			  this.label = value;
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


	  public virtual int CompareTo(object paramObject)
	  {
		string str = ((Country)paramObject).Label;
		return Label.CompareTo(str);
	  }

	  public override string ToString()
	  {
		StringBuilder stringBuffer = new StringBuilder("LabelValue[");
		stringBuffer.Append(this.label);
		stringBuffer.Append(", ");
		stringBuffer.Append(this.value);
		stringBuffer.Append("]");
		return stringBuffer.ToString();
	  }

	  public override bool Equals(object paramObject)
	  {
		if (paramObject == this)
		{
		  return true;
		}
		if (!(paramObject is Country))
		{
		  return false;
		}
		Country country = (Country)paramObject;
		sbyte b = (string.ReferenceEquals(Value, null)) ? 1 : 0;
		b += (sbyte)((string.ReferenceEquals(country.Value, null)) ? 1 : 0);
		return (b == 2) ? true : ((b == 1) ? false : Value.Equals(country.Value));
	  }

	  public override int GetHashCode()
	  {
		  return (string.ReferenceEquals(Value, null)) ? 17 : Value.GetHashCode();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\countries\Country.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}