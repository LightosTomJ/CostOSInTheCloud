using System;

namespace Desktop.common.nomitech.common.data.descriptor
{
	using BigDecimalType = org.hibernate.type.BigDecimalType;
	using BooleanType = org.hibernate.type.BooleanType;
	using IntegerType = org.hibernate.type.IntegerType;
	using LongType = org.hibernate.type.LongType;
	using StringType = org.hibernate.type.StringType;
	using TextType = org.hibernate.type.TextType;
	using TimestampType = org.hibernate.type.TimestampType;
	using Type = org.hibernate.type.Type;

	public class DataObjectDescriptor
	{
	  public const string LONG_TYPE = "Long";

	  public const string TEXT_TYPE = "Text";

	  public const string DECIMAL_TYPE = "Decimal";

	  public const string INTEGER_TYPE = "Integer";

	  public const string DATE_TYPE = "Date";

	  public const string BOOLEAN_TYPE = "Boolean";

	  public const string BYTE_TYPE = "Byte";

	  public const string CURRENCY_TYPE = "Currency";

	  public const string DATETIME_TYPE = "Datetime";

	  public const string PERCENTAGE_TYPE = "Percentage";

	  private string fieldName;

	  private string columnName;

	  private string fieldKey;

	  private string displayName;

	  private string dataType;

	  public static Type typeToHibernateInstance(DataObjectDescriptor paramDataObjectDescriptor)
	  {
		  return typeToHibernateInstance(paramDataObjectDescriptor.dataType);
	  }

	  public static Type typeToHibernateInstance(string paramString)
	  {
		  return paramString.Equals("Text") ? TextType.INSTANCE : (paramString.Equals("Long") ? LongType.INSTANCE : ((paramString.Equals("Decimal") || paramString.Equals("Percentage") || paramString.Equals("Currency")) ? BigDecimalType.INSTANCE : (paramString.Equals("Integer") ? IntegerType.INSTANCE : ((paramString.Equals("Date") || paramString.Equals("Datetime")) ? TimestampType.INSTANCE : (paramString.Equals("Boolean") ? BooleanType.INSTANCE : StringType.INSTANCE)))));
	  }

	  public static Type classToHibernateInstance(Type paramClass)
	  {
		  return paramClass.Equals(typeof(string)) ? TextType.INSTANCE : (paramClass.Equals(typeof(Long)) ? LongType.INSTANCE : (paramClass.Equals(typeof(decimal)) ? BigDecimalType.INSTANCE : (paramClass.Equals(typeof(Integer)) ? IntegerType.INSTANCE : (paramClass.Equals(typeof(DateTime)) ? TimestampType.INSTANCE : (paramClass.Equals(typeof(Boolean)) ? BooleanType.INSTANCE : StringType.INSTANCE)))));
	  }

	  public DataObjectDescriptor()
	  {
	  }

	  public DataObjectDescriptor(string paramString1, string paramString2, string paramString3, string paramString4, string paramString5)
	  {
		this.fieldName = paramString1;
		this.columnName = paramString2;
		this.fieldKey = paramString3;
		this.displayName = paramString4;
		this.dataType = paramString5;
	  }

	  public DataObjectDescriptor(string paramString1, string paramString2, string paramString3, string paramString4)
	  {
		this.fieldName = paramString1;
		this.columnName = paramString2;
		this.fieldKey = null;
		this.displayName = paramString3;
		this.dataType = paramString4;
	  }

	  public DataObjectDescriptor(string paramString1, string paramString2, string paramString3)
	  {
		this.fieldName = paramString1;
		this.columnName = paramString1;
		this.fieldKey = null;
		this.displayName = paramString2;
		this.dataType = paramString3;
	  }

	  public virtual string FieldKey
	  {
		  get
		  {
			  return this.fieldKey;
		  }
		  set
		  {
			  this.fieldKey = value;
		  }
	  }


	  public virtual string FieldName
	  {
		  get
		  {
			  return this.fieldName;
		  }
		  set
		  {
			  this.fieldName = value;
		  }
	  }


	  public virtual string ColumnName
	  {
		  get
		  {
			  return this.columnName;
		  }
		  set
		  {
			  this.columnName = value;
		  }
	  }


	  public virtual string DisplayName
	  {
		  get
		  {
			  return this.displayName;
		  }
		  set
		  {
			  this.displayName = value;
		  }
	  }


	  public virtual string DataType
	  {
		  get
		  {
			  return this.dataType;
		  }
		  set
		  {
			  this.dataType = value;
		  }
	  }


	  public virtual string KendoDataType
	  {
		  get
		  {
			  return this.dataType.Equals("Text") ? "string" : (this.dataType.Equals("Decimal") ? "number" : (this.dataType.Equals("Boolean") ? "boolean" : (this.dataType.Equals("Date") ? "date" : (this.dataType.Equals("Long") ? "number" : "number"))));
		  }
	  }

	  public override string ToString()
	  {
		  return this.displayName;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\data\descriptor\DataObjectDescriptor.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}