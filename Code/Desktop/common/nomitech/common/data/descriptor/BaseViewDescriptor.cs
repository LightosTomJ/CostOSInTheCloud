using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.data.descriptor
{

	public abstract class BaseViewDescriptor
	{
	  public abstract DataObjectDescriptor[] All {get;}

	  public abstract string ViewName {get;}

	  public virtual DataObjectDescriptor[] getDescriptorsByFieldNames(IList<string> paramList)
	  {
		List<object> arrayList = new List<object>(paramList.Count);
		foreach (DataObjectDescriptor dataObjectDescriptor in All)
		{
		  if (paramList.Contains(dataObjectDescriptor.FieldName))
		  {
			arrayList.Add(dataObjectDescriptor);
		  }
		}
		return (DataObjectDescriptor[])arrayList.ToArray(typeof(DataObjectDescriptor));
	  }

	  public virtual DataObjectDescriptor[] getDescriptorsByFieldKeys(IList<string> paramList)
	  {
		List<object> arrayList = new List<object>(paramList.Count);
		foreach (DataObjectDescriptor dataObjectDescriptor in All)
		{
		  if (paramList.Contains(dataObjectDescriptor.FieldKey))
		  {
			arrayList.Add(dataObjectDescriptor);
		  }
		}
		return (DataObjectDescriptor[])arrayList.ToArray(typeof(DataObjectDescriptor));
	  }

	  public virtual DataObjectDescriptor getDescriptorByFieldName(string paramString)
	  {
		foreach (DataObjectDescriptor dataObjectDescriptor in All)
		{
		  if (paramString.Equals(dataObjectDescriptor.FieldName))
		  {
			return dataObjectDescriptor;
		  }
		}
		return null;
	  }

	  public virtual string dispayNameToFieldName(string paramString)
	  {
		foreach (DataObjectDescriptor dataObjectDescriptor in All)
		{
		  if (dataObjectDescriptor.DisplayName.Equals(paramString))
		  {
			return dataObjectDescriptor.FieldName;
		  }
		}
		return null;
	  }

	  public virtual string dispayNameToFieldNameForBenchmarking(string paramString)
	  {
		foreach (DataObjectDescriptor dataObjectDescriptor in All)
		{
		  if (dataObjectDescriptor.DisplayName.Equals(paramString) && !dataObjectDescriptor.FieldName.StartsWith("project", StringComparison.Ordinal))
		  {
			return dataObjectDescriptor.FieldName;
		  }
		}
		return null;
	  }

	  public virtual DataObjectDescriptor[] TextTypeDescriptors
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (DataObjectDescriptor dataObjectDescriptor in All)
			{
			  if (dataObjectDescriptor.DataType.Equals("Text") && !dataObjectDescriptor.FieldName.StartsWith("project", StringComparison.Ordinal))
			  {
				arrayList.Add(dataObjectDescriptor);
			  }
			}
			return (DataObjectDescriptor[])arrayList.ToArray(typeof(DataObjectDescriptor));
		  }
	  }

	  public virtual DataObjectDescriptor[] DecimalTypeDescriptors
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (DataObjectDescriptor dataObjectDescriptor in All)
			{
			  if (dataObjectDescriptor.DataType.Equals("Decimal") && !dataObjectDescriptor.FieldName.StartsWith("project", StringComparison.Ordinal))
			  {
				arrayList.Add(dataObjectDescriptor);
			  }
			}
			return (DataObjectDescriptor[])arrayList.ToArray(typeof(DataObjectDescriptor));
		  }
	  }

	  public virtual DataObjectDescriptor[] IntegerAndLongTypeDescriptors
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (DataObjectDescriptor dataObjectDescriptor in All)
			{
			  if ((dataObjectDescriptor.DataType.Equals("Integer") || dataObjectDescriptor.DataType.Equals("Long")) && !dataObjectDescriptor.FieldName.StartsWith("project", StringComparison.Ordinal))
			  {
				arrayList.Add(dataObjectDescriptor);
			  }
			}
			return (DataObjectDescriptor[])arrayList.ToArray(typeof(DataObjectDescriptor));
		  }
	  }

	  public virtual DataObjectDescriptor[] DateTypeDescriptors
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (DataObjectDescriptor dataObjectDescriptor in All)
			{
			  if (dataObjectDescriptor.DataType.Equals("Date") && !dataObjectDescriptor.FieldName.StartsWith("project", StringComparison.Ordinal))
			  {
				arrayList.Add(dataObjectDescriptor);
			  }
			}
			return (DataObjectDescriptor[])arrayList.ToArray(typeof(DataObjectDescriptor));
		  }
	  }

	  public virtual DataObjectDescriptor[] BooleanTypeDescriptors
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (DataObjectDescriptor dataObjectDescriptor in All)
			{
			  if (dataObjectDescriptor.DataType.Equals("Boolean") && !dataObjectDescriptor.FieldName.StartsWith("project", StringComparison.Ordinal))
			  {
				arrayList.Add(dataObjectDescriptor);
			  }
			}
			return (DataObjectDescriptor[])arrayList.ToArray(typeof(DataObjectDescriptor));
		  }
	  }

	  public virtual DataObjectDescriptor[] ByteTypeDescriptors
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (DataObjectDescriptor dataObjectDescriptor in All)
			{
			  if (dataObjectDescriptor.DataType.Equals("Byte") && !dataObjectDescriptor.FieldName.StartsWith("project", StringComparison.Ordinal))
			  {
				arrayList.Add(dataObjectDescriptor);
			  }
			}
			return (DataObjectDescriptor[])arrayList.ToArray(typeof(DataObjectDescriptor));
		  }
	  }

	  public virtual DataObjectDescriptor[] CurrencyTypeDescriptors
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (DataObjectDescriptor dataObjectDescriptor in All)
			{
			  if (dataObjectDescriptor.DataType.Equals("Currency") && !dataObjectDescriptor.FieldName.StartsWith("project", StringComparison.Ordinal))
			  {
				arrayList.Add(dataObjectDescriptor);
			  }
			}
			return (DataObjectDescriptor[])arrayList.ToArray(typeof(DataObjectDescriptor));
		  }
	  }

	  public virtual DataObjectDescriptor[] DateTimeTypeDescriptors
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (DataObjectDescriptor dataObjectDescriptor in All)
			{
			  if (dataObjectDescriptor.DataType.Equals("Datetime") && !dataObjectDescriptor.FieldName.StartsWith("project", StringComparison.Ordinal))
			  {
				arrayList.Add(dataObjectDescriptor);
			  }
			}
			return (DataObjectDescriptor[])arrayList.ToArray(typeof(DataObjectDescriptor));
		  }
	  }

	  public virtual DataObjectDescriptor[] PercentageTypeDescriptors
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (DataObjectDescriptor dataObjectDescriptor in All)
			{
			  if (dataObjectDescriptor.DataType.Equals("Percentage") && !dataObjectDescriptor.FieldName.StartsWith("project", StringComparison.Ordinal))
			  {
				arrayList.Add(dataObjectDescriptor);
			  }
			}
			return (DataObjectDescriptor[])arrayList.ToArray(typeof(DataObjectDescriptor));
		  }
	  }

	  public override string ToString()
	  {
		  return ViewName;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\data\descriptor\BaseViewDescriptor.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}