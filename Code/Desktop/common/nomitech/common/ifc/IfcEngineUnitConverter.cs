using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.ifc
{
	using Pointer = com.sun.jna.Pointer;
	using PointerByReference = com.sun.jna.ptr.PointerByReference;
	using BIMQuantityType = nomitech.common.bim.BIMQuantityType;
	using StringUtils = nomitech.common.util.StringUtils;
	using BIMProperty = nomitech.ifcengine.props.BIMProperty;

	public class IfcEngineUnitConverter
	{
	  private IList<IfcEngineUnit> o_units;

	  private IfcEngineUnit currentLengthUnit = null;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public IfcEngineUnitConverter(java.util.List<IfcEngineUnit> paramList) throws IllegalStateException
	  public IfcEngineUnitConverter(IList<IfcEngineUnit> paramList)
	  {
		this.o_units = paramList;
		this.currentLengthUnit = findUnitBN(115);
	  }

	  public virtual IfcEngineUnit CurrentLengthUnit
	  {
		  get
		  {
			  return this.currentLengthUnit;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private IfcEngineUnit findUnitBN(int paramInt) throws IllegalStateException
	  private IfcEngineUnit findUnitBN(int paramInt)
	  {
		foreach (IfcEngineUnit ifcEngineUnit in this.o_units)
		{
		  if (ifcEngineUnit.Type == paramInt)
		  {
			return ifcEngineUnit;
		  }
		}
		throw new System.InvalidOperationException("Unit of type " + paramInt + " was not declared in IFC file.");
	  }

	  public virtual BIMProperty getLengthPropertyInMM(Pointer paramPointer, string paramString)
	  {
		double? double = IfcEngineUtils.getDoubleAttributeBN(paramPointer, paramString);
		return new BIMProperty(paramString, BIMQuantityType.QTY_MILLI_METER, true, "", double.Value);
	  }

	  public virtual BIMProperty getProperty(Pointer paramPointer, string paramString)
	  {
		string str = IfcEngineUtils.getStringAttributeBN(paramPointer, paramString);
		if (StringUtils.isNullOrBlank(str))
		{
		  return null;
		}
		double d = 0.0D;
		try
		{
		  d = double.Parse(str);
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		return new BIMProperty(str, BIMQuantityType.QTY_MILLI_METER, (d != 0.0D), str, d);
	  }

	  public virtual BIMProperty getLengthPropertyInMM(Pointer paramPointer)
	  {
		string str1 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Name");
		string str2 = IfcEngineUtils.getStringAttributeBN(paramPointer, "LengthValue");
		double d = 0.0D;
		try
		{
		  d = getLengthInMM(double.Parse(str2));
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		return new BIMProperty(str1, BIMQuantityType.QTY_MILLI_METER, (d != 0.0D), str2, d);
	  }

	  public virtual BIMProperty getAreaPropertyInM2(Pointer paramPointer)
	  {
		string str1 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Name");
		string str2 = IfcEngineUtils.getStringAttributeBN(paramPointer, "AreaValue");
		double d = 0.0D;
		try
		{
		  d = double.Parse(str2);
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		return new BIMProperty(str1, BIMQuantityType.QTY_SQUARE_METER, (d != 0.0D), str2, d);
	  }

	  public virtual BIMProperty getVolumePropertyInM3(Pointer paramPointer)
	  {
		string str1 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Name");
		string str2 = IfcEngineUtils.getStringAttributeBN(paramPointer, "VolumeValue");
		double d = 0.0D;
		try
		{
		  d = double.Parse(str2);
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		return new BIMProperty(str1, BIMQuantityType.QTY_CUBIC_METER, (d != 0.0D), str2, d);
	  }

	  public virtual BIMProperty getCountProperty(Pointer paramPointer)
	  {
		string str1 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Name");
		string str2 = IfcEngineUtils.getStringAttributeBN(paramPointer, "CountValue");
		double d = 0.0D;
		try
		{
		  d = double.Parse(str2);
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		return new BIMProperty(str1, 0, (d != 0.0D), str2, d);
	  }

	  public virtual BIMProperty getWeightProperty(Pointer paramPointer)
	  {
		string str1 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Name");
		string str2 = IfcEngineUtils.getStringAttributeBN(paramPointer, "WeightValue");
		double d = 0.0D;
		try
		{
		  d = double.Parse(str2);
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		return new BIMProperty(str1, 0, (d != 0.0D), str2, d);
	  }

	  public virtual BIMProperty getTimeProperty(Pointer paramPointer)
	  {
		string str1 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Name");
		string str2 = IfcEngineUtils.getStringAttributeBN(paramPointer, "TimeValue");
		return new BIMProperty(str1, 0, false, str2, 0.0D);
	  }

	  public virtual BIMProperty getSinglePropertyValue(Pointer paramPointer)
	  {
		string str1 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Name");
		string str2 = IfcEngineUtils.getStringAttributeBN(paramPointer, "NominalValue");
		string str3 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Unit");
		if (!StringUtils.isNullOrBlank(str2))
		{
		  if (str2.Equals(".T."))
		  {
			str2 = "true";
		  }
		  else if (str2.Equals(".F."))
		  {
			str2 = "false";
		  }
		}
		else if (StringUtils.isNullOrBlank(str3))
		{
		  str2 = str2 + " " + str3;
		}
		return new BIMProperty(str1, 0, false, str2, 0.0D);
	  }

	  public virtual BIMProperty getListPropertyValue(Pointer paramPointer)
	  {
		string str1 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Name");
		double? double = IfcEngineUtils.getDoubleViaADBAsFirstElementInAGGRAttributeBN(paramPointer, "ListValues");
		string str2 = IfcEngineUtils.getPathViaADBAsFirstElementInAGGRAttributeBN(paramPointer, "ListValues");
		if (StringUtils.checkEquality(str2, "IFCPOSITIVELENGTHMEASURE"))
		{
		  double = Convert.ToDouble(getLengthInMM(double.Value));
		  return new BIMProperty(str1, BIMQuantityType.QTY_MILLI_METER, (double.Value != 0.0D), "" + double, double.Value);
		}
		return new BIMProperty(str1, 0, (double.Value != 0.0D), "" + double, double.Value);
	  }

	  public virtual BIMProperty getEnumeratedPropertyValue(Pointer paramPointer)
	  {
		string str1 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Name");
		System.Collections.IList list = IfcEngineUtils.getSetAttributeOfADBBN(paramPointer, "EnumerationValues");
		string str2 = null;
		foreach (Pointer pointer in list)
		{
		  PointerByReference pointerByReference = new PointerByReference();
		  IfcEngineInterface_Fields.INSTANCE.sdaiGetADBValue(pointer, 10, pointerByReference);
		  if (!string.ReferenceEquals(str2, null))
		  {
			str2 = pointerByReference.Value.getString(0L);
			continue;
		  }
		  str2 = str2 + ", " + pointerByReference.Value.getString(0L);
		}
		if (!string.ReferenceEquals(str2, null))
		{
		  str2 = "";
		}
		return new BIMProperty(str1, 0, false, str2, 0.0D);
	  }

	  public virtual BIMProperty getBoundedPropertyValue(Pointer paramPointer)
	  {
		string str1 = IfcEngineUtils.getStringAttributeBN(paramPointer, "Name");
		double? double1 = IfcEngineUtils.getDoubleAttributeBN(paramPointer, "UpperBoundValue");
		double? double2 = IfcEngineUtils.getDoubleAttributeBN(paramPointer, "LowerBoundValue");
		string str2 = "U: " + double1 + " L: " + double2;
		return new BIMProperty(str1, 0, false, str2, 0.0D);
	  }

	  public virtual double getVolumeFromGeometryInM3(double paramDouble)
	  {
		  return paramDouble * this.currentLengthUnit.ConversionFactor * this.currentLengthUnit.ConversionFactor * this.currentLengthUnit.ConversionFactor;
	  }

	  public virtual double getAreaFromGeometryInM2(double paramDouble)
	  {
		  return paramDouble * this.currentLengthUnit.ConversionFactor * this.currentLengthUnit.ConversionFactor;
	  }

	  public virtual double getLengthInMM(double paramDouble)
	  {
		  return paramDouble * this.currentLengthUnit.ConversionFactor * 1000.0D;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ifc\IfcEngineUnitConverter.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}