using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim.bimengine
{
	using BIMQTOType = nomitech.bimengine.types.BIMQTOType;
	using IfcEnginePropertiesData = nomitech.common.ifc.IfcEnginePropertiesData;
	using IfcEngineQuantitiesData = nomitech.common.ifc.IfcEngineQuantitiesData;
	using UIProgress = nomitech.common.ui.UIProgress;
	using StringUtils = nomitech.common.util.StringUtils;
	using BIMProperty = nomitech.ifcengine.props.BIMProperty;
	using BIMPropertySet = nomitech.ifcengine.props.BIMPropertySet;
	using Session = org.hibernate.Session;
	using BigDecimalType = org.hibernate.type.BigDecimalType;
	using BooleanType = org.hibernate.type.BooleanType;
	using IntegerType = org.hibernate.type.IntegerType;
	using LongType = org.hibernate.type.LongType;
	using StringType = org.hibernate.type.StringType;

	public class BimEnginePropertiesLoader
	{
	  private string elemPropertySQL = "SELECT e.ID as elemId, i.ID as propId, i.GRPNAME as groupName, i.name as name, ISNUM as isNumber, i.NUMVAL as numberValue, i.TXTVAL as textValue, i.QTYTYPE as qtyType FROM BC_ELEMPROP i LEFT JOIN BC_ELEMENT e ON e.ID  = i.ELEMENT_ID  WHERE e.TYPE = :typeId AND e.MODEL_ID = :modelId";

	  private string elemQuantitySQL = " SELECT e.ID as elemId, i.ID as propId, i.GRPNAME as groupName, i.name as name, i.VAL as value, i.QTYPE as qtyType, i.NAMEID as nameId FROM BC_QUANTITY i LEFT JOIN BC_ELEMENT e ON e.ID  = i.ELEMENT_ID  WHERE e.TYPE = :typeId AND e.MODEL_ID = :modelId";

	  private long? modelId;

	  private UIProgress progress;

	  private IDictionary<long, IfcEnginePropertiesData> propsDataMap = null;

	  private IDictionary<long, IfcEngineQuantitiesData> quantsDataMap = null;

	  public BimEnginePropertiesLoader(long? paramLong, UIProgress paramUIProgress)
	  {
		this.modelId = paramLong;
		this.progress = paramUIProgress;
	  }

	  public virtual void clearCache()
	  {
		this.propsDataMap = null;
		this.quantsDataMap = null;
	  }

	  public virtual void cacheElementProperties(Session paramSession, int? paramInteger, int paramInt, bool paramBoolean)
	  {
		if (paramInt == -1)
		{
		  this.propsDataMap = new Hashtable();
		}
		else
		{
		  this.propsDataMap = new Hashtable(paramInt);
		}
		System.Collections.IList list = paramSession.createSQLQuery(this.elemPropertySQL).addScalar("elemId", LongType.INSTANCE).addScalar("propId", LongType.INSTANCE).addScalar("groupName", StringType.INSTANCE).addScalar("name", StringType.INSTANCE).addScalar("isNumber", BooleanType.INSTANCE).addScalar("numberValue", BigDecimalType.INSTANCE).addScalar("textValue", StringType.INSTANCE).addScalar("qtyType", IntegerType.INSTANCE).setInteger("typeId", paramInteger.Value).setLong("modelId", this.modelId.Value).list();
		foreach (object[] arrayOfObject in list)
		{
		  long? long1 = (long?)arrayOfObject[0];
		  long? long2 = (long?)arrayOfObject[1];
		  string str1 = (string)arrayOfObject[2];
		  string str2 = (string)arrayOfObject[3];
		  bool? @bool = (bool?)arrayOfObject[4];
		  decimal bigDecimal = (decimal)arrayOfObject[5];
		  string str3 = (string)arrayOfObject[6];
		  int? integer = (int?)arrayOfObject[7];
		  BIMProperty bIMProperty = new BIMProperty();
		  bIMProperty.DoubleValue = bigDecimal.doubleValue();
		  bIMProperty.Number = @bool.Value;
		  bIMProperty.Value = str3;
		  bIMProperty.Name = str2;
		  IfcEnginePropertiesData ifcEnginePropertiesData = (IfcEnginePropertiesData)this.propsDataMap[long1];
		  if (ifcEnginePropertiesData == null)
		  {
			ifcEnginePropertiesData = new IfcEnginePropertiesData();
			ifcEnginePropertiesData.PropSetList = new LinkedList();
			this.propsDataMap[long1] = ifcEnginePropertiesData;
		  }
		  if (StringUtils.isNullOrBlank(str1))
		  {
			str1 = "Misc";
		  }
		  BIMPropertySet bIMPropertySet = ifcEnginePropertiesData.findProperySet(str1);
		  if (bIMPropertySet == null)
		  {
			bIMPropertySet = new BIMPropertySet();
			bIMPropertySet.Name = str1;
			bIMPropertySet.Properties = new LinkedList();
			ifcEnginePropertiesData.PropSetList.Add(bIMPropertySet);
		  }
		  bIMPropertySet.Properties.add(bIMProperty);
		  this.progress.incrementProgress(1);
		}
		cacheElementQuantites(paramSession, paramInteger, paramInt, paramBoolean);
	  }

	  private void cacheElementQuantites(Session paramSession, int? paramInteger, int paramInt, bool paramBoolean)
	  {
		if (!paramBoolean)
		{
		  this.quantsDataMap = new Hashtable();
		}
		System.Collections.IList list = paramSession.createSQLQuery(this.elemQuantitySQL).addScalar("elemId", LongType.INSTANCE).addScalar("propId", LongType.INSTANCE).addScalar("groupName", StringType.INSTANCE).addScalar("name", StringType.INSTANCE).addScalar("value", BigDecimalType.INSTANCE).addScalar("qtyType", IntegerType.INSTANCE).addScalar("nameId", IntegerType.INSTANCE).setInteger("typeId", paramInteger.Value).setLong("modelId", this.modelId.Value).list();
		foreach (object[] arrayOfObject in list)
		{
		  long? long1 = (long?)arrayOfObject[0];
		  long? long2 = (long?)arrayOfObject[1];
		  string str1 = (string)arrayOfObject[2];
		  string str2 = (string)arrayOfObject[3];
		  decimal bigDecimal = (decimal)arrayOfObject[4];
		  int? integer1 = (int?)arrayOfObject[5];
		  int? integer2 = (int?)arrayOfObject[6];
		  if (paramBoolean)
		  {
			BIMProperty bIMProperty = new BIMProperty();
			bIMProperty.DoubleValue = bigDecimal.doubleValue();
			bIMProperty.Number = true;
			bIMProperty.Value = "";
			bIMProperty.Name = str2;
			IfcEnginePropertiesData ifcEnginePropertiesData = (IfcEnginePropertiesData)this.propsDataMap[long1];
			if (ifcEnginePropertiesData == null)
			{
			  ifcEnginePropertiesData = new IfcEnginePropertiesData();
			  ifcEnginePropertiesData.PropSetList = new LinkedList();
			  this.propsDataMap[long1] = ifcEnginePropertiesData;
			}
			BIMPropertySet bIMPropertySet = ifcEnginePropertiesData.findProperySet(str1);
			if (bIMPropertySet == null)
			{
			  bIMPropertySet = new BIMPropertySet();
			  bIMPropertySet.Name = str1;
			  bIMPropertySet.Properties = new LinkedList();
			  ifcEnginePropertiesData.PropSetList.Add(bIMPropertySet);
			}
			bIMPropertySet.Properties.add(bIMProperty);
		  }
		  else
		  {
			IfcEngineQuantitiesData ifcEngineQuantitiesData = (IfcEngineQuantitiesData)this.quantsDataMap[long1];
			if (ifcEngineQuantitiesData == null)
			{
			  ifcEngineQuantitiesData = new IfcEngineQuantitiesData();
			  this.quantsDataMap[long1] = ifcEngineQuantitiesData;
			}
			ifcEngineQuantitiesData.setQuantity(BIMQTOType.values()[integer2.Value], Convert.ToDouble(bigDecimal.doubleValue()));
		  }
		  this.progress.incrementProgress(1);
		}
	  }

	  public virtual IfcEnginePropertiesData getElementProperties(long? paramLong)
	  {
		IfcEnginePropertiesData ifcEnginePropertiesData = (IfcEnginePropertiesData)this.propsDataMap[paramLong];
		if (ifcEnginePropertiesData == null)
		{
		  ifcEnginePropertiesData = new IfcEnginePropertiesData();
		  ifcEnginePropertiesData.PropSetList = new LinkedList();
		  this.propsDataMap[paramLong] = ifcEnginePropertiesData;
		}
		return ifcEnginePropertiesData;
	  }

	  public virtual IfcEngineQuantitiesData getElementQuantities(long? paramLong)
	  {
		IfcEngineQuantitiesData ifcEngineQuantitiesData = (IfcEngineQuantitiesData)this.quantsDataMap[paramLong];
		if (ifcEngineQuantitiesData == null)
		{
		  ifcEngineQuantitiesData = new IfcEngineQuantitiesData();
		  this.quantsDataMap[paramLong] = ifcEngineQuantitiesData;
		}
		return ifcEngineQuantitiesData;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\bimengine\BimEnginePropertiesLoader.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}