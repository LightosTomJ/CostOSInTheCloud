using System;
using System.Text;

namespace Desktop.common.nomitech.common
{
	using ProjectWBS2Table = Models.local.ProjectWBS2Table;
	using ProjectWBSTable = Models.local.ProjectWBSTable;
	using BoqItemConditionTable = Models.proj.BoqItemConditionTable;
	using BoqItemEquipmentTable = Models.proj.BoqItemEquipmentTable;
	using BoqItemTable = Models.proj.BoqItemTable;
	using BoqItemDefaultFormulas = Desktop.common.nomitech.common.expr.boqitem.BoqItemDefaultFormulas;
	using BigDecimalMath = Desktop.common.nomitech.common.util.BigDecimalMath;
	using IPToCountryUtil = Desktop.common.nomitech.common.util.IPToCountryUtil;
	using StringUtils = Desktop.common.nomitech.common.util.StringUtils;
	using Query = org.hibernate.Query;
	using SQLQuery = org.hibernate.SQLQuery;
	using Session = org.hibernate.Session;
	using Transaction = org.hibernate.Transaction;
	using Column = org.hibernate.mapping.Column;
	using PersistentClass = org.hibernate.mapping.PersistentClass;
	using Property = org.hibernate.mapping.Property;
	using CustomType = org.hibernate.type.CustomType;
	using Type = org.hibernate.type.Type;
	using UserType = org.hibernate.usertype.UserType;

	public class ProjectSchemaUpdateUtil
	{
	  public static void updateNewerSchema(ProjectDBProperties paramProjectDBProperties, ProjectDBUtil paramProjectDBUtil)
	  {
		  updateNewerSchema(paramProjectDBProperties, paramProjectDBUtil, null);
	  }

	  public static void updateNewerSchema(ProjectDBProperties paramProjectDBProperties, ProjectDBUtil paramProjectDBUtil, SessionInterface paramSessionInterface)
	  {
		bool @bool = false;
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "3.6.0"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Query query = session.createQuery("update BoqItemTable set quantityLoss = 0, estimatedQuantity = quantity, measuredQuantity = quantity, editorId = :userId, createUserId = :userId, createDate = lastUpdate");
			if (paramSessionInterface == null)
			{
			  query.setString("userId", DatabaseDBUtil.Properties.UserId);
			}
			else
			{
			  query.setString("userId", "admin");
			}
			query.executeUpdate();
			transaction.commit();
		  }
		  catch (Exception)
		  {
			if (transaction.Active)
			{
			  transaction.rollback();
			}
		  }
		  paramProjectDBUtil.closeSession();
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "3.7.0"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Query query = session.createQuery("update BoqItemTable set location = '', rollUP = ''");
			query.executeUpdate();
			transaction.commit();
		  }
		  catch (Exception)
		  {
			if (transaction.Active)
			{
			  transaction.rollback();
			}
		  }
		  paramProjectDBUtil.closeSession();
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "3.8.1"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update BoqItemTable set wbs2Code = :wbs2Code where wbs2Code is null");
		  query.setString("wbs2Code", "");
		  query.executeUpdate();
		  query = session.createQuery("update BoqItemTable set location = :location where location is null");
		  query.setString("location", "");
		  query.executeUpdate();
		  query = session.createQuery("update ConditionTable set building = :es, layer = :es, storey = :es, bimMaterial = :es, bimType = :es, location = :es, quantity1Name = :es, quantity2Name = :es, quantity3Name = :es  where location is null");
		  query.setString("es", "");
		  query.executeUpdate();
		  query = session.createQuery("update MaterialTable set bimMaterial = :es, bimType = :es where bimType is null");
		  query.setString("es", "");
		  query.executeUpdate();
		  query = session.createQuery("update AssemblyTable set bimMaterial = :es, bimType = :es where bimType is null");
		  query.setString("es", "");
		  query.executeUpdate();
		  query = session.createQuery("update ConditionTable set takeOffType = :takeOffType where takeOffType is null");
		  query.setString("takeOffType", "On-Screen Takeoff");
		  query.executeUpdate();
		  query = session.createQuery("update BoqItemConditionTable set sumup = 0 where sumup is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "3.8.3"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update MaterialTable set accuracy = 'enum.quotation.accuracy.estimated'");
		  query.executeUpdate();
		  query = session.createQuery("update SubcontractorTable set accuracy = 'enum.quotation.accuracy.estimated'");
		  query.executeUpdate();
		  query = session.createQuery("update BoqItemTable set createDate = lastUpdate where createDate is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "3.8.6"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update BoqItemTable set accuracy = 'enum.quotation.accuracy.estimated'");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "3.8.8"))
		{
		  Console.WriteLine("Updating Project file to 3.8.8");
		  double[] arrayOfDouble = IPToCountryUtil.EuropeGeoPosition;
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Query query = session.createQuery("update MaterialTable set quantity = 0 where quantity is null");
			query.executeUpdate();
			query = session.createQuery("update SubcontractorTable set quantity = 0 where quantity is null");
			query.executeUpdate();
			query = session.createQuery("update SupplierTable set url = '', geoLocation = :geoLocation where url is null");
			query.setString("geoLocation", "" + arrayOfDouble[0] + "," + arrayOfDouble[1]);
			query.executeUpdate();
			query = session.createQuery("update MaterialTable set distanceToSite = 0, distanceUnit = :du, rawMaterial = 'enum.rm.unspecified', inclusion = 'enum.inclusion.matonly', weightUnit = 'KG', shipmentRate = 0, totalRate = rate where distanceToSite is null");
			query.setString("du", "KM");
			query.executeUpdate();
			query = session.createQuery("update SubcontractorTable set inclusion = 'enum.inclusion.subonly' where inclusion is null");
			query.executeUpdate();
			query = session.createQuery("update AssemblyTable set quantity = 0, accuracy = 'enum.quotation.accuracy.estimated', createDate = lastUpdate, createUserId = editorId, laborRate = 0, materialRate = 0, subcontractorRate = 0, consumableRate = 0, equipmentRate = 0 where quantity is null");
			query.executeUpdate();
			query = session.createQuery("update MaterialTable set createDate = lastUpdate, createUserId = editorId where createUserId is null");
			query.executeUpdate();
			query = session.createQuery("update EquipmentTable set createDate = lastUpdate, createUserId = editorId where createUserId is null");
			query.executeUpdate();
			query = session.createQuery("update SubcontractorTable set createDate = lastUpdate, createUserId = editorId where createUserId is null");
			query.executeUpdate();
			query = session.createQuery("update LaborTable set createDate = lastUpdate, createUserId = editorId where createUserId is null");
			query.executeUpdate();
			query = session.createQuery("update SupplierTable set createDate = lastUpdate, createUserId = editorId where createUserId is null");
			query.executeUpdate();
			query = session.createQuery("update ConsumableTable set createDate = lastUpdate, createUserId = editorId where createUserId is null");
			query.executeUpdate();
			GregorianCalendar gregorianCalendar = new GregorianCalendar();
			gregorianCalendar.set(1, 1980);
			query = session.createQuery("update AssemblySubcontractorTable o set o.lastUpdate = :lup where o.lastUpdate is null");
			query.setTimestamp("lup", new Timestamp(gregorianCalendar.Time.Time));
			query.executeUpdate();
			query = session.createQuery("update AssemblyMaterialTable o set o.lastUpdate = :lup where o.lastUpdate is null");
			query.setTimestamp("lup", new Timestamp(gregorianCalendar.Time.Time));
			query.executeUpdate();
			query = session.createQuery("update AssemblyLaborTable o set o.lastUpdate = :lup where o.lastUpdate is null");
			query.setTimestamp("lup", new Timestamp(gregorianCalendar.Time.Time));
			query.executeUpdate();
			query = session.createQuery("update AssemblyConsumableTable o set o.lastUpdate = :lup where o.lastUpdate is null");
			query.setTimestamp("lup", new Timestamp(gregorianCalendar.Time.Time));
			query.executeUpdate();
			query = session.createQuery("update AssemblyEquipmentTable o set o.lastUpdate = :lup where o.lastUpdate is null");
			query.setTimestamp("lup", new Timestamp(gregorianCalendar.Time.Time));
			query.executeUpdate();
			transaction.commit();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramProjectDBUtil.closeSession();
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "3.9.1"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update MaterialTable o set o.fabricationRate = 0 where o.fabricationRate is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "3.9.2"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update BoqItemTable o set o.escalationCost = 0 where o.escalationCost is null");
		  query.executeUpdate();
		  query = session.createQuery("update BoqItemMaterialTable o set o.escalation = 1 where o.escalation is null");
		  query.executeUpdate();
		  query = session.createQuery("update MaterialTable o set o.rawMaterialReliance = 100 where o.rawMaterialReliance is null");
		  query.executeUpdate();
		  query = session.createQuery("update MaterialTable o set o.rawMaterial = 'enum.rm.unspecified' where o.rawMaterial is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "3.9.4"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update ParamItemConceptualResourceTable o set o.weight = '0' where o.weight is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "3.9.5"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update ParamItemInputTable o set o.unit = o.defaultValue where o.unit is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.0.4"))
		{
		  Console.WriteLine("Updating Project file to 4.0.4 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update AssemblyTable o set o.virtual = false, o.virtualMaterial = false, o.virtualEquipment = false, o.virtualSubcontractor = false, o.virtualConsumable = false, o.virtualLabor = false");
		  query.executeUpdate();
		  query = session.createQuery("update EquipmentTable o set o.predicted = false, o.virtual = false");
		  query.executeUpdate();
		  query = session.createQuery("update SubcontractorTable o set o.conceptual = false, o.predicted = false, o.virtual = false");
		  query.executeUpdate();
		  query = session.createQuery("update LaborTable o set o.predicted = false, o.virtual = false");
		  query.executeUpdate();
		  query = session.createQuery("update MaterialTable o set o.conceptual = false, o.predicted = false, o.virtual = false");
		  query.executeUpdate();
		  query = session.createQuery("update ConsumableTable o set o.predicted = false, o.virtual = false");
		  query.executeUpdate();
		  query = session.createQuery("update BoqItemTable o set o.customRate1 = 0, o.customRate2 = 0, o.customRate3 = 0, o.customRate4 = 0, o.customRate5 = 0, o.customRate6 = 0, o.customRate7 = 0, o.customRate8 = 0, o.customRate9 = 0, o.customRate10 = 0");
		  query.executeUpdate();
		  query = session.createQuery("update BoqItemTable o set o.customCumRate1 = 0, o.customCumRate2 = 0, o.customCumRate3 = 0, o.customCumRate4 = 0,o.customCumRate5 = 0");
		  query.executeUpdate();
		  query = session.createQuery("update BoqItemTable o set o.customPercentRate1 = 0, o.customPercentRate2 = 0, o.customPercentRate3 = 0, o.customPercentRate4 = 0, o.customPercentRate5 = 0, o.customPercentRate6 = 0, o.customPercentRate7 = 0, o.customPercentRate8 = 0, o.customPercentRate9 = 0, o.customPercentRate10 = 0");
		  query.executeUpdate();
		  query = session.createQuery("update BoqItemTable o set o.flag = 0, o.customText1 = '', o.customText2 = '', o.customText3 = '', o.customText4 = '', o.customText5 = ''");
		  query.executeUpdate();
		  query = session.createQuery("update ParamItemTable o set o.costModel = false, o.icon = '', o.groupName = ''");
		  query.executeUpdate();
		  query = session.createQuery("update AssemblyTable o set o.unitManhours = 1/o.productivity");
		  query.executeUpdate();
		  session.createQuery("update BoqItemAssemblyTable o set o.localFactor = 1, o.localCountry = '', o.localStateProvince = ''").executeUpdate();
		  session.createQuery("update BoqItemEquipmentTable o set o.localFactor = 1, o.localCountry = '', o.localStateProvince = '', o.energyPrice = 0, o.finalFuelRate = 0").executeUpdate();
		  session.createQuery("update BoqItemSubcontractorTable o set o.localFactor = 1, o.localCountry = '', o.localStateProvince = ''").executeUpdate();
		  session.createQuery("update BoqItemMaterialTable o set o.localFactor = 1, o.localCountry = '', o.localStateProvince = ''").executeUpdate();
		  session.createQuery("update BoqItemLaborTable o set o.localFactor = 1, o.localCountry = '', o.localStateProvince = ''").executeUpdate();
		  session.createQuery("update BoqItemConsumableTable o set o.localFactor = 1, o.localCountry = '', o.localStateProvince = ''").executeUpdate();
		  session.createQuery("update AssemblyEquipmentTable o set o.localFactor = 1, o.localCountry = '', o.localStateProvince = '', o.energyPrice = 0, o.finalFuelRate = 0").executeUpdate();
		  session.createQuery("update AssemblySubcontractorTable o set o.localFactor = 1, o.localCountry = '', o.localStateProvince = ''").executeUpdate();
		  session.createQuery("update AssemblyMaterialTable o set o.localFactor = 1, o.localCountry = '', o.localStateProvince = ''").executeUpdate();
		  session.createQuery("update AssemblyLaborTable o set o.localFactor = 1, o.localCountry = '', o.localStateProvince = ''").executeUpdate();
		  session.createQuery("update AssemblyConsumableTable o set o.localFactor = 1, o.localCountry = '', o.localStateProvince = ''").executeUpdate();
		  string str1 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("totalCost");
		  string str2 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("offeredPrice");
		  string str3 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("quantityLoss");
		  string str4 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("rate");
		  string str5 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("productivity");
		  string str6 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("unitManhours");
		  string str7 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("duration");
		  string str8 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("offeredRate");
		  string str9 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("offeredSecondRate");
		  string str10 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("secondRate");
		  string str11 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("secondQuantity");
		  string str12 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("secondUnit");
		  string str13 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("unitsDiv");
		  string str14 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("assemblyTotalCost");
		  string str15 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("equipmentTotalCost");
		  string str16 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("materialTotalCost");
		  string str17 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("subcontractorTotalCost");
		  string str18 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("laborTotalCost");
		  string str19 = BoqItemDefaultFormulas.Instance.getDefaultFormulaForField("consumableTotalCost");
		  System.Collections.IEnumerator iterator = session.createQuery("from BoqItemTable o").iterate();
		  while (iterator.MoveNext())
		  {
			BoqItemTable boqItemTable = (BoqItemTable)iterator.Current;
			boqItemTable.OfferedPriceFormula = str2;
			boqItemTable.TotalCostFormula = str1;
			boqItemTable.RateFormula = str4;
			boqItemTable.OfferedRateFormula = str8;
			boqItemTable.OfferedSecondRateFormula = str9;
			boqItemTable.SecondRateFormula = str10;
			boqItemTable.SecondQuantityFormula = str11;
			boqItemTable.SecondUnitFormula = str12;
			boqItemTable.UnitsDivFormula = str13;
			boqItemTable.AssemblyTotalCostFormula = str14;
			boqItemTable.EquipmentTotalCostFormula = str15;
			boqItemTable.MaterialTotalCostFormula = str16;
			boqItemTable.SubcontractorTotalCostFormula = str17;
			boqItemTable.LaborTotalCostFormula = str18;
			boqItemTable.ConsumableTotalCostFormula = str19;
			boqItemTable.QuantityLossFormula = str3;
			boqItemTable.UnitManhoursFormula = str6;
			boqItemTable.AdjustedProd = boqItemTable.Productivity;
			boqItemTable.ProdFactor = BigDecimalMath.ONE;
			boqItemTable.AdjustedUnitManhours = boqItemTable.UnitManhours;
			if (boqItemTable.HasProductivity.Value)
			{
			  boqItemTable.DurationFormula = str7;
			  boqItemTable.ProductivityFormula = null;
			}
			else
			{
			  boqItemTable.ProductivityFormula = str5;
			  boqItemTable.DurationFormula = null;
			}
			boqItemTable.recalculate();
			session.update(boqItemTable);
		  }
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.0.4";
		  if (paramProjectDBProperties.getProperty("boqitem.category.type").Equals("wbs"))
		  {
			paramProjectDBProperties.setProperty("boqitem.category.type", "wbsCode");
		  }
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.0.5"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  session.createQuery("update ParamItemInputTable o set o.pblk = false where o.pblk is null").executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.0.5";
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.0.8"))
		{
		  Console.WriteLine("Updating Project file to 4.0.8 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update MaterialTable o set o.rawMaterial2 = :rm,o.rawMaterial3 = :rm,o.rawMaterial4 = :rm,o.rawMaterial5 = :rm,o.rawMaterialReliance2=0,o.rawMaterialReliance3=0,o.rawMaterialReliance4=0,o.rawMaterialReliance5=0 where o.rawMaterial2 is null");
		  query.setString("rm", "enum.rm.unspecified");
		  query.executeUpdate();
		  query = session.createQuery("update EquipmentTable o set o.country = 'GB', o.stateProvince = '' where o.country is null");
		  query.executeUpdate();
		  query = session.createQuery("update EquipmentTable o set o.unit = 'HOUR' where o.unit != 'HOUR'");
		  query.executeUpdate();
		  query = session.createQuery("update LaborTable o set o.unit = 'HOUR' where o.unit != 'HOUR'");
		  query.executeUpdate();
		  query = session.createQuery("update MaterialTable o set o.volFlow = 0, o.volFlowUnit = '', o.massFlow = 0, o.massFlowUnit = '', o.duty = 0, o.dutyUnit = '', o.operPress = 0, o.operPressUnit = '', o.operTemp = 0, o.operTempUnit = 0 where o.operTemp is null");
		  query.executeUpdate();
		  query = session.createQuery("update ParamItemOutputTable o set o.labLocEquation = 'FACTOR', o.matLocEquation = 'FACTOR', o.equLocEquation = 'FACTOR', o.subLocEquation = 'FACTOR', o.conLocEquation = 'FACTOR'");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.0.8";
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.1.3"))
		{
		  Console.WriteLine("Updating Project file to 4.1.3 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update ParamItemConceptualResourceTable o set o.groupCode = '', o.gekCode = '', o.extraCode1 = '', o.extraCode2 = '', o.extraCode3 = '', o.extraCode4 = '', o.extraCode5 = '', o.extraCode6 = '', o.extraCode7 = '', o.volFlow = 0, o.volFlowUnit = '', o.massFlow = 0, o.massFlowUnit = '', o.duty = 0, o.dutyUnit = '', o.operPress = 0, o.operPressUnit = '', o.operTemp = 0, o.operTempUnit = '', o.subcontractorIKA = 0 where o.operTemp is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.1.3";
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.1.5"))
		{
		  Console.WriteLine("Updating Project file to 4.1.5 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update BoqItemTable o set o.customText6 = '', o.customText7 = '', o.customText8 = '', o.customText9 = '', o.customText10 = '', o.customText11 = '', o.customText12 = '', o.customText13 = '', o.customText14 = '', o.customText15 = '', o.customText16 = '', o.customText17 = '', o.customText18 = '', o.customText19 = '', o.customText20 = ''");
		  query.executeUpdate();
		  query = session.createQuery("update AssemblyTable o set o.customText1 = '', o.customText2 = '', o.customText3 = '', o.customText4 = '', o.customText5 = '', o.customText6 = '', o.customText7 = '', o.customText8 = '', o.customText9 = '', o.customText10 = '', o.customText11 = '', o.customText12 = '', o.customText13 = '', o.customText14 = '', o.customText15 = '', o.customText16 = '', o.customText17 = '', o.customText18 = '', o.customText19 = '', o.customText20 = ''");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.1.5";
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.2.3"))
		{
		  Console.WriteLine("Updating Project file to 4.2.2 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update BoqItemTable o set o.locProfile = '', o.locFactor = '', o.locState = '', o.locCountry = '', o.adjustedProd = o.productivity, o.adjustedProdFormula = :ap, o.prodFactor = 0");
		  query.setString("ap", "IF(PRODUCTIVITY_FACTOR<>0,PRODUCTIVITY*PRODUCTIVITY_FACTOR,PRODUCTIVITY)");
		  query.executeUpdate();
		  query = session.createQuery("update BoqItemTable o set o.durationFormula = :df where o.durationFormula = :oldDF");
		  query.setString("df", "IF(ADJUSTED_PRODUCTIVITY<>0,QUANTITY/ADJUSTED_PRODUCTIVITY,0)");
		  query.setString("oldDF", "IF(PRODUCTIVITY<>0,QUANTITY/PRODUCTIVITY,0)");
		  query.executeUpdate();
		  query = session.createQuery("update BoqItemTable o set o.productivityFormula = :pf where o.productivityFormula = :oldPF");
		  query.setString("pf", "IF(DURATION<>0,IF(PRODUCTIVITY_FACTOR<>0,(QUANTITY/DURATION)/PRODUCTIVITY_FACTOR,QUANTITY/DURATION),0)");
		  query.setString("oldPF", "IF(DURATION<>0,QUANTITY/DURATION,0)");
		  query.executeUpdate();
		  query = session.createQuery("update BoqItemTable o set o.unitManhoursFormula = :mh where o.unitManhoursFormula = :oldMH");
		  query.setString("mh", "IF(QUANTITY<>0,IF(PRODUCTIVITY_FACTOR<>0,(TOTAL_MANHOURS/QUANTITY)*PRODUCTIVITY_FACTOR,TOTAL_MANHOURS/QUANTITY),0)");
		  query.setString("oldMH", "IF(QUANTITY<>0,TOTAL_MANHOURS/QUANTITY,0)");
		  query.executeUpdate();
		  query = session.createQuery("update BoqItemTable o set o.adjustedUnitManhoursFormula = :mh");
		  query.setString("mh", "IF(QUANTITY<>0,TOTAL_MANHOURS/QUANTITY,0)");
		  query.executeUpdate();
		  query = session.createQuery("update BoqItemTable o set o.mhoursFactorFormula = :mh, o.mhoursFactor = 0");
		  query.setString("mh", "IF(PRODUCTIVITY_FACTOR<>0,1/PRODUCTIVITY_FACTOR,0)");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.2.3";
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.2.5"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update QuoteItemTable o set o.resource = false where o.resource is null");
		  query.executeUpdate();
		  query = session.createQuery("update QuoteItemTable o set o.mainQuantity = o.quantity where o.mainQuantity is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.2.5";
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.2.6"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			SQLQuery sQLQuery = session.createSQLQuery("UPDATE ASSHISTORY SET RSRC = RESOURCE WHERE RSRC = NULL");
			sQLQuery.executeUpdate();
			sQLQuery = session.createSQLQuery("UPDATE MATHISTORY SET RSRC = RESOURCE WHERE RSRC = NULL");
			sQLQuery.executeUpdate();
			sQLQuery = session.createSQLQuery("UPDATE LABHISTORY SET RSRC = RESOURCE WHERE RSRC = NULL");
			sQLQuery.executeUpdate();
			sQLQuery = session.createSQLQuery("UPDATE SUBHISTORY SET RSRC = RESOURCE WHERE RSRC = NULL");
			sQLQuery.executeUpdate();
			sQLQuery = session.createSQLQuery("UPDATE EQUHISTORY SET RSRC = RESOURCE WHERE RSRC = NULL");
			sQLQuery.executeUpdate();
			sQLQuery = session.createSQLQuery("UPDATE CNMHISTORY SET RSRC = RESOURCE WHERE RSRC = NULL");
			sQLQuery.executeUpdate();
			sQLQuery = session.createSQLQuery("UPDATE QUOTEITEM SET RSRC = RESOURCE WHERE RSRC = NULL");
			sQLQuery.executeUpdate();
			Console.Error.WriteLine("Schema update 1: OK");
		  }
		  catch (Exception exception)
		  {
			Console.Error.WriteLine("Schema update 1: " + exception.Message);
		  }
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.2.6";
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.3.0"))
		{
		  Console.WriteLine("Updating Project file to 4.3.0 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  session.createQuery("update BoqItemTable o set o.estimatorId = o.editorId where o.estimatorId is null").executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.3.0";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.3.1"))
		{
		  Console.WriteLine("Updating Project file to 4.3.1 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("ALTER TABLE QUOTEITEM MODIFY TITLE longtext").executeUpdate();
		  }
		  catch (Exception)
		  {
			try
			{
			  session.createSQLQuery("ALTER TABLE QUOTEITEM ALTER COLUMN TITLE text").executeUpdate();
			}
			catch (Exception)
			{
			  try
			  {
				session.createSQLQuery("ALTER TABLE QUOTEITEM ALTER COLUMN TITLE LONGVARCHAR").executeUpdate();
			  }
			  catch (Exception)
			  {
				Console.WriteLine("Not MySQL or SQL Server Project...");
			  }
			}
		  }
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.3.1";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.4.3"))
		{
		  Console.WriteLine("Updating Project file to 4.4.3 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  session.createSQLQuery("update ASSEMBLY_MATERIAL SET FRATE = (FACTOR1*FACTOR2*LOCALFACTOR*EXCHANGERATE*(select distinct TOTALRATE from MATERIAL where ASSEMBLY_MATERIAL.MATERIALID = MATERIAL.MATERIALID))/DIVIDER where FRATE is NULL").executeUpdate();
		  session.createSQLQuery("update ASSEMBLY_CONSUMABLE SET FRATE = (FACTOR1*FACTOR2*LOCALFACTOR*EXCHANGERATE*(select distinct RATE from CONSUMABLE where ASSEMBLY_CONSUMABLE.CONSUMABLEID = CONSUMABLE.CONSUMABLEID))/DIVIDER where FRATE is NULL").executeUpdate();
		  session.createSQLQuery("update ASSEMBLY_LABOR SET FRATE = (FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*EXCHANGERATE*(select distinct TOTALRATE from LABOR where ASSEMBLY_LABOR.LABORID = LABOR.LABORID))/(select distinct PRODUCTIVITY from ASSEMBLY where ASSEMBLY_LABOR.ASSEMBLYID = ASSEMBLY.ASSEMBLYID) where FRATE is NULL").executeUpdate();
		  session.createSQLQuery("update ASSEMBLY_LABOR SET FIKARATE = (FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*EXCHANGERATE*(select distinct IKA from LABOR where ASSEMBLY_LABOR.LABORID = LABOR.LABORID))/(select distinct PRODUCTIVITY from ASSEMBLY where ASSEMBLY_LABOR.ASSEMBLYID = ASSEMBLY.ASSEMBLYID) where FIKARATE is NULL").executeUpdate();
		  session.createSQLQuery("update ASSEMBLY_EQUIPMENT SET FRATE = (FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*EXCHANGERATE*((select distinct TOTALRATE from EQUIPMENT where ASSEMBLY_EQUIPMENT.EQUIPMENTID = EQUIPMENT.EQUIPMENTID)+FUELRATE))/(select distinct PRODUCTIVITY from ASSEMBLY where ASSEMBLY_EQUIPMENT.ASSEMBLYID = ASSEMBLY.ASSEMBLYID) where FRATE is NULL").executeUpdate();
		  session.createSQLQuery("update ASSEMBLY_EQUIPMENT SET FDEPRATE = (FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*EXCHANGERATE*(select distinct DEPRECIATIONRATE from EQUIPMENT where ASSEMBLY_EQUIPMENT.EQUIPMENTID = EQUIPMENT.EQUIPMENTID))/(select distinct PRODUCTIVITY from ASSEMBLY where ASSEMBLY_EQUIPMENT.ASSEMBLYID = ASSEMBLY.ASSEMBLYID) where FDEPRATE is NULL").executeUpdate();
		  session.createSQLQuery("update ASSEMBLY_EQUIPMENT SET FINALFUELRATE = (FUELRATE*FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*EXCHANGERATE)/(select distinct PRODUCTIVITY from ASSEMBLY where ASSEMBLY_EQUIPMENT.ASSEMBLYID = ASSEMBLY.ASSEMBLYID) where FINALFUELRATE is NULL").executeUpdate();
		  session.createSQLQuery("update ASSEMBLY_SUBCONTRACTOR SET FRATE = (FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*EXCHANGERATE*(select distinct TOTALRATE from SUBCONTRACTOR where ASSEMBLY_SUBCONTRACTOR.SUBCONTRACTORID = SUBCONTRACTOR.SUBCONTRACTORID)) where FRATE is NULL").executeUpdate();
		  session.createSQLQuery("update ASSEMBLY_SUBCONTRACTOR SET FIKARATE = (FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*EXCHANGERATE*(select distinct IKA from SUBCONTRACTOR where ASSEMBLY_SUBCONTRACTOR.SUBCONTRACTORID = SUBCONTRACTOR.SUBCONTRACTORID)) where FIKARATE is NULL").executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.4.3";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.5.0"))
		{
		  Console.WriteLine("Updating Project file to 4.5.0 from version " + paramProjectDBProperties.PreviousVersion);
		  string str = paramProjectDBProperties.getProperty("project.currency.symbol");
		  if (!string.ReferenceEquals(str, null) && str.IndexOf("₤", StringComparison.Ordinal) != -1)
		  {
			str = StringUtils.replaceAll(str, "₤", "£");
			paramProjectDBProperties.setProperty("project.currency.symbol", str);
		  }
		  else if (!string.ReferenceEquals(str, null) && str.IndexOf("?", StringComparison.Ordinal) != -1)
		  {
			str = "£";
			paramProjectDBProperties.setProperty("project.currency.symbol", str);
		  }
		  paramProjectDBProperties.PreviousVersion = "4.5.0";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.6.0"))
		{
		  Console.WriteLine("Updating Project file to 4.6.0 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  session.createSQLQuery("update BOQITEM_MATERIAL SET FRATE = (FACTOR1*FACTOR2*LOCALFACTOR*COSTCENTER*(select distinct TOTALRATE from MATERIAL where BOQITEM_MATERIAL.MATERIALID = MATERIAL.MATERIALID))/DIVIDER where FRATE is NULL").executeUpdate();
		  session.createSQLQuery("update BOQITEM_MATERIAL SET TOTALCOST = FRATE*TOTALUNITS where TOTALCOST is NULL").executeUpdate();
		  session.createSQLQuery("update BOQITEM_CONSUMABLE SET FRATE = (FACTOR1*FACTOR2*LOCALFACTOR*COSTCENTER*(select distinct RATE from CONSUMABLE where BOQITEM_CONSUMABLE.CONSUMABLEID = CONSUMABLE.CONSUMABLEID))/DIVIDER where TOTALCOST is NULL").executeUpdate();
		  session.createSQLQuery("update BOQITEM_CONSUMABLE SET TOTALCOST = FRATE*TOTALUNITS where FRATE is NULL").executeUpdate();
		  session.createSQLQuery("update BOQITEM_LABOR SET FRATE = (TOTALUNITS*FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*COSTCENTER*(select distinct TOTALRATE from LABOR where BOQITEM_LABOR.LABORID = LABOR.LABORID))/nullif((select distinct QUANTITY from BOQITEM where BOQITEM_LABOR.BOQITEMID = BOQITEM.BOQITEMID),0) where FRATE is NULL").executeUpdate();
		  session.createSQLQuery("update BOQITEM_LABOR SET TOTALCOST = (TOTALUNITS*FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*COSTCENTER*(select distinct TOTALRATE from LABOR where BOQITEM_LABOR.LABORID = LABOR.LABORID))where TOTALCOST is NULL").executeUpdate();
		  session.createSQLQuery("update BOQITEM_EQUIPMENT SET FRATE = (TOTALUNITS*FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*COSTCENTER*((select distinct TOTALRATE from EQUIPMENT where BOQITEM_EQUIPMENT.EQUIPMENTID = EQUIPMENT.EQUIPMENTID)+FUELRATE))/nullif((select distinct QUANTITY from BOQITEM where BOQITEM_EQUIPMENT.BOQITEMID = BOQITEM.BOQITEMID),0) where FRATE is NULL").executeUpdate();
		  session.createSQLQuery("update BOQITEM_EQUIPMENT SET TOTALCOST = (TOTALUNITS*FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*COSTCENTER*((select distinct TOTALRATE from EQUIPMENT where BOQITEM_EQUIPMENT.EQUIPMENTID = EQUIPMENT.EQUIPMENTID)+FUELRATE))where TOTALCOST is NULL").executeUpdate();
		  session.createSQLQuery("update BOQITEM_SUBCONTRACTOR SET FRATE = (FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*COSTCENTER*(select distinct TOTALRATE from SUBCONTRACTOR where BOQITEM_SUBCONTRACTOR.SUBCONTRACTORID = SUBCONTRACTOR.SUBCONTRACTORID)) where FRATE is NULL").executeUpdate();
		  session.createSQLQuery("update BOQITEM_SUBCONTRACTOR SET TOTALCOST = FRATE*TOTALUNITS where TOTALCOST is NULL").executeUpdate();
		  System.Collections.IEnumerator iterator = session.createQuery("from BoqItemEquipmentTable o").iterate();
		  sbyte b = 0;
		  while (iterator.MoveNext())
		  {
			BoqItemEquipmentTable boqItemEquipmentTable = (BoqItemEquipmentTable)iterator.Current;
			boqItemEquipmentTable.FinalRate = boqItemEquipmentTable.FinalRate;
			boqItemEquipmentTable.TotalCost = boqItemEquipmentTable.TotalCost;
			Console.WriteLine("Updated: " + boqItemEquipmentTable);
			session.update(boqItemEquipmentTable);
			if (++b % 'ú' == '\x0000')
			{
			  transaction.commit();
			  transaction = session.beginTransaction();
			}
		  }
		  iterator = session.createQuery("from BoqItemConditionTable o").iterate();
		  while (iterator.MoveNext())
		  {
			BoqItemConditionTable boqItemConditionTable = (BoqItemConditionTable)iterator.Current;
			boqItemConditionTable.FinalQuantity = boqItemConditionTable.FinalQuantity;
			boqItemConditionTable.SelectedQuantity = boqItemConditionTable.SelectedQuantity;
			boqItemConditionTable.SelectedQuantityName = boqItemConditionTable.SelectedQuantityName;
			boqItemConditionTable.FinalUnit = boqItemConditionTable.FinalUnit;
			session.update(boqItemConditionTable);
			if (++b % 'ú' == '\x0000')
			{
			  transaction.commit();
			  transaction = session.beginTransaction();
			}
		  }
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.6.0";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.6.1"))
		{
		  Console.WriteLine("Updating Project file to 4.6.1 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  session.createQuery("update ParamItemConceptualResourceTable o set o.laborRate = '0', o.laborIKA = '0', o.consumableRate = '0', o.equipmentReservationRate = '0', o.equipmentLubricatesRate = '0', o.equipmentTiresRate = '0', o.equipmentSparePartsRate = '0', o.equipmentDepreciationRate = '0', o.equipmentFuelRate = '0',o.equipmentFuelConsumption = '0', o.equipmentFuelType = 'OTHER' where o.laborRate is null").executeUpdate();
		  transaction.commit();
		  Console.WriteLine("DONE");
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.6.1";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.6.2"))
		{
		  Console.WriteLine("Updating Project file to 4.6.2 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update ParamItemConceptualResourceTable o set o.notesConcatenation = :es, o.descriptionConcatenation = :es where o.notesConcatenation is null");
		  query.setString("es", "T(\"\")");
		  query.executeUpdate();
		  query = session.createQuery("update ParamItemConceptualResourceTable o set o.customText1Equation = '', o.customText2Equation = '', o.customText3Equation = '', o.customText4Equation = '', o.customText5Equation = '', o.customText6Equation = '', o.customText7Equation = '', o.customText8Equation = '', o.customText9Equation = '', o.customText10Equation = '', o.customRate1Equation = '', o.customRate2Equation = '', o.customRate3Equation = '', o.customRate4Equation = '', o.customRate5Equation = '', o.customRate6Equation = '', o.customRate7Equation = '', o.customRate8Equation = '', o.customRate9Equation = '', o.customRate10Equation = '', o.customCumRate1Equation = '', o.customCumRate2Equation = '', o.customCumRate3Equation = '', o.customCumRate4Equation = '', o.customCumRate5Equation = '' where o.customText1Equation is null");
		  query.executeUpdate();
		  transaction.commit();
		  Console.WriteLine("DONE");
		  paramProjectDBUtil.closeSession();
		  if (paramProjectDBProperties.getProperty("project.currency.symbol").Equals("₤"))
		  {
			paramProjectDBProperties.setProperty("project.currency.symbol", "£");
		  }
		  paramProjectDBProperties.PreviousVersion = "4.6.2";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.6.5"))
		{
		  Console.WriteLine("Updating Project file to 4.6.5 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  session.createQuery("update AssemblyMaterialTable o set o.factor3 = 1/o.factor3 where o.factor3 != 0 and o.factor3 != 1").executeUpdate();
		  session.createQuery("update AssemblyConsumableTable o set o.factor3 = 1/o.factor3 where o.factor3 != 0 and o.factor3 != 1").executeUpdate();
		  session.createQuery("update BoqItemMaterialTable o set o.factor3 = 1/o.factor3 where o.factor3 != 0 and o.factor3 != 1").executeUpdate();
		  session.createQuery("update BoqItemConsumableTable o set o.factor3 = 1/o.factor3 where o.factor3 != 0 and o.factor3 != 1").executeUpdate();
		  session.createQuery("update AssemblyTable o set o.activityBased = true, o.unitEquipmentHours = o.unitManhours where o.activityBased is null").executeUpdate();
		  session.createQuery("update BoqItemTable o set o.activityBased = true, o.equipmentHours = 0 where o.activityBased is null").executeUpdate();
		  session.createQuery("update BoqItemTable o set o.rateFormula = replace(cast(o.rateFormula as string),:lineItemTxt,'')").setString("lineItemTxt", "LINE_ITEM_TOTAL_RATE+").executeUpdate();
		  session.createQuery("update BoqItemTable o set o.rateFormula = replace(cast(o.rateFormula as string),:lineItemTxt,'')").setString("lineItemTxt", "+LINE_ITEM_TOTAL_RATE+").executeUpdate();
		  session.createQuery("update BoqItemTable o set o.rateFormula = replace(cast(o.rateFormula as string),:lineItemTxt,'')").setString("lineItemTxt", "+LINE_ITEM_TOTAL_RATE").executeUpdate();
		  session.createQuery("update BoqItemAssemblyTable o set o.quantityPerUnit = 1 where o.quantityPerUnit is null").executeUpdate();
		  session.createQuery("update BoqItemMaterialTable o set o.quantityPerUnit = 1 where o.quantityPerUnit is null").executeUpdate();
		  session.createQuery("update BoqItemEquipmentTable o set o.quantityPerUnit = 1 where o.quantityPerUnit is null").executeUpdate();
		  session.createQuery("update BoqItemLaborTable o set o.quantityPerUnit = 1 where o.quantityPerUnit is null").executeUpdate();
		  session.createQuery("update BoqItemSubcontractorTable o set o.quantityPerUnit = 1 where o.quantityPerUnit is null").executeUpdate();
		  session.createQuery("update BoqItemConsumableTable o set o.quantityPerUnit = 1 where o.quantityPerUnit is null").executeUpdate();
		  session.createQuery("update AssemblyMaterialTable o set o.quantityPerUnit = 1 where o.quantityPerUnit is null").executeUpdate();
		  session.createQuery("update AssemblyEquipmentTable o set o.quantityPerUnit = 1 where o.quantityPerUnit is null").executeUpdate();
		  session.createQuery("update AssemblyLaborTable o set o.quantityPerUnit = 1 where o.quantityPerUnit is null").executeUpdate();
		  session.createQuery("update AssemblySubcontractorTable o set o.quantityPerUnit = 1 where o.quantityPerUnit is null").executeUpdate();
		  session.createQuery("update AssemblyConsumableTable o set o.quantityPerUnit = 1 where o.quantityPerUnit is null").executeUpdate();
		  transaction.commit();
		  Console.WriteLine("DONE");
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.6.5";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.6.6"))
		{
		  Console.WriteLine("Updating Project file to 4.6.6 from version " + paramProjectDBProperties.PreviousVersion);
		  Console.WriteLine("Your locked columns where: " + paramProjectDBProperties.getProperty("boqitem.column.locked"));
		  paramProjectDBProperties.setIntArrayProperty("boqitem.column.locked", SchemaUpdateUtil.correctUpdatedArray1(paramProjectDBProperties.getIntArrayProperty("boqitem.column.locked")));
		  paramProjectDBProperties.setIntArrayProperty("boqitem.columns.grouped", SchemaUpdateUtil.correctUpdatedArray1(paramProjectDBProperties.getIntArrayProperty("boqitem.columns.grouped")));
		  paramProjectDBProperties.PreviousVersion = "4.6.6";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.6.7"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.6.7...");
			session.createQuery("update LaborTable o set o.conceptual = false where o.conceptual is null").executeUpdate();
			session.createQuery("update ConsumableTable o set o.conceptual = false where o.conceptual is null").executeUpdate();
			session.createQuery("update EquipmentTable o set o.conceptual = false where o.conceptual is null").executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramProjectDBUtil.closeSession();
			paramProjectDBProperties.PreviousVersion = "4.6.7";
			@bool = true;
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.6.8"))
		{
		  Console.WriteLine("Updating Project file to 4.6.8 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("ALTER TABLE PARAMINPUT MODIFY STOVAL LONGTEXT").executeUpdate();
		  }
		  catch (Exception exception)
		  {
			try
			{
			  session.createSQLQuery("ALTER TABLE PARAMINPUT ALTER COLUMN STOVAL text").executeUpdate();
			}
			catch (Exception)
			{
			  try
			  {
				session.createSQLQuery("ALTER TABLE PARAMINPUT ALTER COLUMN STOVAL LONGVARCHAR").executeUpdate();
			  }
			  catch (Exception)
			  {
				Console.WriteLine("Not MySQL or SQL or HSQLDB Server Project...");
				Console.WriteLine(exception.ToString());
				Console.Write(exception.StackTrace);
			  }
			}
		  }
		  try
		  {
			transaction.commit();
		  }
		  catch (Exception)
		  {
		  }
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.6.8";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.7.0"))
		{
		  Console.WriteLine("Updating Project file to 4.7.0 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update BoqItemTable as o set o.bimMaterial = :es, o.bimType = :es where o.bimMaterial is null");
		  query.setString("es", "");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.7.0";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.7.2"))
		{
		  Console.WriteLine("Updating Project file to 4.7.2 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createQuery("update AssemblyTable as o set o.itemCode = o.publishedRevisionCode where o.itemCode is null").executeUpdate();
			session.createQuery("update EquipmentTable as o set o.itemCode = '' where o.itemCode is null").executeUpdate();
			session.createQuery("update LaborTable as o set o.itemCode = '' where o.itemCode is null").executeUpdate();
			session.createQuery("update MaterialTable as o set o.itemCode = '' where o.itemCode is null").executeUpdate();
			session.createQuery("update SupplierTable as o set o.itemCode = '' where o.itemCode is null").executeUpdate();
			session.createQuery("update ConsumableTable as o set o.itemCode = '' where o.itemCode is null").executeUpdate();
			session.createQuery("update ParamItemTable as o set o.itemCode = '' where o.itemCode is null").executeUpdate();
			transaction.commit();
			transaction = session.beginTransaction();
			Query query = session.createQuery("update BoqItemTable as o set o.puGroupCodeFactor = :zero, o.puGekCodeFactor = :zero, o.puExtraCode1Factor = :zero, o.puExtraCode2Factor = :zero, o.puExtraCode3Factor = :zero, o.puExtraCode4Factor = :zero,o.puExtraCode5Factor = :zero, o.puExtraCode6Factor = :zero, o.puExtraCode7Factor = :zero where o.puGroupCodeFactor is null");
			query.setBigDecimal("zero", BigDecimalMath.ZERO);
			query.executeUpdate();
			query = session.createQuery("update AssemblyTable as o set o.puGroupCodeFactor = :zero, o.puGekCodeFactor = :zero, o.puExtraCode1Factor = :zero, o.puExtraCode2Factor = :zero, o.puExtraCode3Factor = :zero, o.puExtraCode4Factor = :zero,o.puExtraCode5Factor = :zero, o.puExtraCode6Factor = :zero, o.puExtraCode7Factor = :zero where o.puGroupCodeFactor is null");
			query.setBigDecimal("zero", BigDecimalMath.ZERO);
			query.executeUpdate();
			transaction.commit();
		  }
		  catch (Exception)
		  {
			if (transaction.Active)
			{
			  transaction.rollback();
			}
		  }
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.7.2";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.7.3"))
		{
		  Console.WriteLine("Updating Project file to 4.7.3 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update AssemblyTable as o set o.customRate1 = :zero, o.customRate2 = :zero, o.customRate3 = :zero, o.customRate4 = :zero, o.customRate5 = :zero, o.customRate6 = :zero,o.customRate7 = :zero, o.customRate8 = :zero, o.customRate9 = :zero, o.customRate10 = :zero where o.customRate10 is null");
		  query.setBigDecimal("zero", BigDecimalMath.ZERO);
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.7.3";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.8.2"))
		{
		  Console.WriteLine("Updating Project file to 4.8.2 from version " + paramProjectDBProperties.PreviousVersion);
		  System.Collections.IEnumerator iterator = paramProjectDBUtil.Configuration.ClassMappings;
		  Session session = paramProjectDBUtil.currentSession();
		  while (iterator.MoveNext())
		  {
			PersistentClass persistentClass = (PersistentClass)iterator.Current;
			if (persistentClass.Table.Name.EndsWith("View"))
			{
			  continue;
			}
			System.Collections.IEnumerator iterator1 = persistentClass.PropertyIterator;
			while (iterator1.MoveNext())
			{
			  Query query = makeTextUpdateQuery(session, persistentClass, (Property)iterator1.Current);
			  if (query != null)
			  {
				query.executeUpdate();
			  }
			}
		  }
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.reloadProperties();
		  paramProjectDBProperties.PreviousVersion = "4.8.2";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.8.3"))
		{
		  Console.WriteLine("Updating Project file to 4.8.3 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  try
		  {
			if (paramProjectDBUtil.DbmsType == ProjectDBUtil.MYSQL_DBMS)
			{
			  session.createSQLQuery("ALTER TABLE ASSEMBLY MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE MATERIAL MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE SUBCONTRACTOR MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE CONSUMABLE MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EQUIPMENT MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE LABOR MODIFY TITLE longtext").executeUpdate();
			}
			else if (paramProjectDBUtil.DbmsType == ProjectDBUtil.SQLSERVER_DBMS)
			{
			  session.createSQLQuery("ALTER TABLE ASSEMBLY ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE MATERIAL ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE SUBCONTRACTOR ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE CONSUMABLE ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EQUIPMENT ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE LABOR ALTER COLUMN TITLE TEXT").executeUpdate();
			}
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.8.3";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.8.4"))
		{
		  Console.WriteLine("Updating Project file to 4.8.4 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update ParamItemConceptualResourceTable as o set o.customText11Equation = :zero, o.customText12Equation = :zero, o.customText13Equation = :zero, o.customText14Equation = :zero, o.customText15Equation = :zero, o.customText16Equation = :zero,o.customText17Equation = :zero, o.customText18Equation = :zero, o.customText19Equation = :zero, o.customText20Equation = :zero where o.customText11Equation is null");
		  query.setString("zero", "");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.8.4";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.8.5"))
		{
		  Console.WriteLine("Updating Project file to 4.8.5 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  if (paramProjectDBUtil.DbmsType == ProjectDBUtil.SQLSERVER_DBMS)
		  {
			System.Collections.IEnumerator iterator = paramProjectDBUtil.Configuration.ClassMappings;
			while (iterator.MoveNext())
			{
			  PersistentClass persistentClass = (PersistentClass)iterator.Current;
			  alterTextToVarCharMax(session, persistentClass);
			}
		  }
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.8.5";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.8.6"))
		{
		  Console.WriteLine("Updating Project file to 4.8.6 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session1 = paramProjectDBUtil.currentSession();
		  Session session2 = null;
		  Console.WriteLine("intf  " + paramSessionInterface);
		  if (paramSessionInterface == null)
		  {
			session2 = DatabaseDBUtil.currentSession();
		  }
		  else
		  {
			session2 = paramSessionInterface.currentSession();
		  }
		  try
		  {
			copyWBSTables(session1, session2);
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  if (paramSessionInterface == null)
		  {
			DatabaseDBUtil.closeSession();
		  }
		  else
		  {
			paramSessionInterface.closeSession();
		  }
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.8.6";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.8.7"))
		{
		  Console.WriteLine("Updating Project file to 4.8.7 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update BoqItemTable o set o.customCumRate6 = 0, o.customCumRate7 = 0, o.customCumRate8 = 0, o.customCumRate9 = 0, o.customCumRate10 = 0, o.customRate11 = 0, o.customRate12 = 0, o.customRate13 = 0, o.customRate14 = 0, o.customRate15 = 0 where o.customRate15 is null");
		  query.executeUpdate();
		  query = session.createQuery("update AssemblyTable o set o.customRate11 = 0, o.customRate12 = 0, o.customRate13 = 0, o.customRate14 = 0, o.customRate15 = 0 where o.customRate15 is null");
		  query.executeUpdate();
		  query = session.createQuery("update ParamItemConceptualResourceTable o set o.customRate11Equation = '', o.customRate12Equation = '', o.customRate13Equation = '', o.customRate14Equation = '', o.customRate15Equation = '', o.customRate6Equation = '', o.customRate7Equation = '', o.customRate8Equation = '', o.customRate9Equation = '', o.customRate10Equation = '', o.customCumRate6Equation = '', o.customCumRate7Equation = '', o.customCumRate8Equation = '', o.customCumRate9Equation = '', o.customCumRate10Equation = '' where o.customRate11Equation is null");
		  query.executeUpdate();
		  query = session.createQuery("update ParamItemQueryResourceTable o set o.customRate11Equation = '', o.customRate12Equation = '', o.customRate13Equation = '', o.customRate14Equation = '', o.customRate15Equation = '', o.customRate6Equation = '', o.customRate7Equation = '', o.customRate8Equation = '', o.customRate9Equation = '', o.customRate10Equation = '', o.customCumRate6Equation = '', o.customCumRate7Equation = '', o.customCumRate8Equation = '', o.customCumRate9Equation = '', o.customCumRate10Equation = '' where o.customRate11Equation is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.8.7";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.8.8"))
		{
		  Console.WriteLine("Updating Project file to 4.8.8 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update QuoteItemTable o set o.material = 0, o.indirectCost = 0, o.manHours = 0 where o.manHours is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.8.8";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.8.9"))
		{
		  Console.WriteLine("Updating Project file to 4.8.9 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update ParamItemTable o set o.multUnitQty = true where o.multUnitQty is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.8.9";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "4.9.0"))
		{
		  Console.WriteLine("Updating Project file to 4.9.0 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update BoqItemTable o set o.paramItemCode = null where o.paramItemTable is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "4.9.0";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "5.0.1"))
		{
		  Console.WriteLine("Updating Project file to 5.0.1 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update ParamItemTable o set o.titleFormula = '' where o.titleFormula is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "5.0.1";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "5.0.2"))
		{
		  Console.WriteLine("Updating Project file to 5.0.2 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update AssemblyTable o set o.overrideType = 0 where o.overrideType is null");
		  query.executeUpdate();
		  query = session.createQuery("update EquipmentTable o set o.overrideType = 0 where o.overrideType is null");
		  query.executeUpdate();
		  query = session.createQuery("update LaborTable o set o.overrideType = 0 where o.overrideType is null");
		  query.executeUpdate();
		  query = session.createQuery("update SubcontractorTable o set o.overrideType = 0 where o.overrideType is null");
		  query.executeUpdate();
		  query = session.createQuery("update MaterialTable o set o.overrideType = 0 where o.overrideType is null");
		  query.executeUpdate();
		  query = session.createQuery("update EquipmentTable o set o.overrideType = 0 where o.overrideType is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "5.0.2";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "5.0.5"))
		{
		  Console.WriteLine("Updating Project file to 5.0.5 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update QuotationTable o set o.notes = '' where o.notes is null");
		  query.executeUpdate();
		  query = session.createQuery("update QuotationTable o set o.title = '' where o.title is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "5.0.5";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "5.0.6"))
		{
		  Console.WriteLine("Updating Project file to 5.0.6 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  string str = "";
		  if (paramProjectDBUtil.DbmsType == ProjectDBUtil.SQLSERVER_DBMS)
		  {
			str = "UPDATE o SET o.SUBQUOTERATE = (select ISNULL(sum(bs.FRATE),0) from BOQITEM_SUBCONTRACTOR bs JOIN SUBCONTRACTOR s on bs.SUBCONTRACTORID = s.SUBCONTRACTORID where bs.BOQITEMID = o.BOQITEMID AND s.ACCURACY like 'enum.quotation.accuracy.quoted'), o.MATQUOTERATE = (select ISNULL(sum(bs.FRATE),0) from BOQITEM_MATERIAL bs JOIN MATERIAL s on bs.MATERIALID = s.MATERIALID where bs.BOQITEMID = o.BOQITEMID AND ACCURACY like 'enum.quotation.accuracy.quoted') from BOQITEM as o";
		  }
		  else
		  {
			str = "UPDATE BOQITEM boq SET SUBQUOTERATE = (select ISNULL(sum(bs.FRATE),0) from BOQITEM_SUBCONTRACTOR bs JOIN SUBCONTRACTOR s on bs.SUBCONTRACTORID = s.SUBCONTRACTORID where bs.BOQITEMID = boq.BOQITEMID AND s.ACCURACY like 'enum.quotation.accuracy.quoted'), MATQUOTERATE = (select ISNULL(sum(bs.FRATE),0) from BOQITEM_MATERIAL bs JOIN MATERIAL s on bs.MATERIALID = s.MATERIALID where bs.BOQITEMID = boq.BOQITEMID AND ACCURACY like 'enum.quotation.accuracy.quoted') ";
		  }
		  SQLQuery sQLQuery = session.createSQLQuery(str);
		  try
		  {
			sQLQuery.executeUpdate();
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "5.0.6";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "5.1.0"))
		{
		  Console.WriteLine("Updating Project file to 5.1.0 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  System.Collections.IList list = session.createSQLQuery("SELECT PKEY FROM PRJPROP WHERE PVAL = '0E-20'").list();
		  string str = "UPDATE PRJPROP SET PVAL = '0' WHERE PVAL = '0E-20'";
		  SQLQuery sQLQuery = session.createSQLQuery(str);
		  sQLQuery.executeUpdate();
		  foreach (string str1 in list)
		  {
			paramProjectDBProperties.setProperty(str1, "0");
		  }
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "5.1.0";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "5.1.3"))
		{
		  Console.WriteLine("Updating Project file to 5.1.3 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  string str = "update RateBuildUpColumnsTable o set o.applyToEveryResource = false where o.applyToEveryResource is null";
		  Query query = session.createQuery(str);
		  query.executeUpdate();
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "5.1.3";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "5.1.9"))
		{
		  Console.WriteLine("Updating Project file to 5.1.9 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  session.createQuery("update SubcontractorTable o set o.subMaterialRate = 0 where o.subMaterialRate is null").executeUpdate();
		  session.createQuery("update WorksheetIdentifyColumnTable o set o.excludeAutoMatch = false where o.excludeAutoMatch is null").executeUpdate();
		  string str = "";
		  if (paramProjectDBUtil.DbmsType == ProjectDBUtil.SQLSERVER_DBMS)
		  {
			str = "update o SET o.AWDMAT = (select ISNULL(sum(qi.MATRATE),0) from QUOTEITEM qi LEFT JOIN QUOTE q on q.EXPENSEID=qi.QUOTATIONID where qi.BOQITEMID = o.BOQITEMID AND qi.STATUS LIKE '%awarded' AND q.QUOTETYPE like '%subcontractor')+(select ISNULL(sum(qi.RATE),0) from QUOTEITEM qi LEFT JOIN QUOTE q on q.EXPENSEID=qi.QUOTATIONID where qi.BOQITEMID = o.BOQITEMID AND qi.STATUS LIKE '%awarded' AND q.QUOTETYPE like '%material'), o.AWDINS = (select ISNULL(sum(qi.INSURANCE),0) from QUOTEITEM qi LEFT JOIN QUOTE q on q.EXPENSEID=qi.QUOTATIONID where qi.BOQITEMID = o.BOQITEMID AND qi.STATUS LIKE '%awarded' AND q.QUOTETYPE like '%subcontractor'), o.AWDSUB = (select ISNULL(sum(qi.RATE),0) from QUOTEITEM qi LEFT JOIN QUOTE q on q.EXPENSEID=qi.QUOTATIONID where qi.BOQITEMID = o.BOQITEMID AND qi.STATUS LIKE '%awarded' AND q.QUOTETYPE like '%subcontractor'), o.AWDMHOURS = (select ISNULL(sum(qi.MANHOURS),0) from QUOTEITEM qi LEFT JOIN QUOTE q on q.EXPENSEID=qi.QUOTATIONID where qi.BOQITEMID = o.BOQITEMID AND qi.STATUS LIKE '%awarded' AND q.QUOTETYPE like '%subcontractor'), o.AWDIND = 0, o.AWDSHIP = 0, o.AWDTOTAL = o.MATQUOTERATE+o.SUBQUOTERATE from BOQITEM as o where o.AWDMAT is null";
		  }
		  else
		  {
			str = "UPDATE BOQITEM boq SET AWDMAT = ISNULL(boq.AWDMAT,0), AWDINS = ISNULL(boq.AWDINS,0), AWDSUB = ISNULL(boq.AWDSUB,0), AWDMHOURS = ISNULL(boq.AWDMHOURS,0), AWDIND = ISNULL(boq.AWDIND,0), AWDSHIP = ISNULL(boq.AWDSHIP,0), AWDTOTAL = boq.MATQUOTERATE+boq.SUBQUOTERATE ";
		  }
		  SQLQuery sQLQuery = session.createSQLQuery(str);
		  try
		  {
			sQLQuery.executeUpdate();
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  transaction.commit();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "5.1.9";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.1.2"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			string str = "update IfcElementTable o set o.topElevation = 0, o.bottomElevation = 0  where o.topElevation is null";
			Query query = session.createQuery(str);
			query.executeUpdate();
			transaction.commit();
		  }
		  catch (Exception)
		  {
			if (session.Open && transaction.Active)
			{
			  transaction.rollback();
			}
		  }
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "6.1.2";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.0"))
		{
		  paramProjectDBUtil.currentSession().createQuery("update ProjectVariableTable set pushField = '' where pushField is null").executeUpdate();
		  processProjectIdUpdates(paramProjectDBUtil);
		  if (paramProjectDBUtil.DbmsType == ProjectDBUtil.SQLSERVER_DBMS)
		  {
			fixConstraints(paramProjectDBUtil);
		  }
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "6.2.0";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.1"))
		{
		  paramProjectDBUtil.currentSession().createQuery("update ParamItemQueryResourceTable o set o.type = 0, o.jsonUrl = '' where o.jsonUrl is null ").executeUpdate();
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "6.2.1";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.2"))
		{
		  Console.WriteLine("Updating Project file to 6.2.2 from version " + paramProjectDBProperties.PreviousVersion);
		  try
		  {
			paramProjectDBUtil.currentSession().createSQLQuery("ALTER TABLE ASSEMBLY ALTER COLUMN NOTES VARCHAR(MAX)").executeUpdate();
			paramProjectDBUtil.currentSession().createSQLQuery("ALTER TABLE GROUPCODE ALTER COLUMN NOTES VARCHAR(MAX)").executeUpdate();
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "6.2.2";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.3"))
		{
		  Console.WriteLine("Updating Project file to 6.2.3 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			paramProjectDBUtil.currentSession().createQuery("update BoqItemTable o set o.customCumRate11 = 0, o.customCumRate12 = 0, o.customCumRate13 = 0, o.customCumRate14 = 0, o.customCumRate15 = 0, o.customCumRate16 = 0, o.customCumRate17 = 0, o.customCumRate18 = 0, o.customCumRate19 = 0, o.customCumRate20 = 0 where o.customCumRate11 is null").executeUpdate();
			paramProjectDBUtil.currentSession().createQuery("update BoqItemTable o set o.customRate16 = 0, o.customRate17 = 0, o.customRate18 = 0, o.customRate19 = 0, o.customRate20 = 0 where o.customRate16 is null").executeUpdate();
			paramProjectDBUtil.currentSession().createQuery("update BoqItemTable o set o.customPercentRate11 = 0, o.customPercentRate12 = 0, o.customPercentRate13 = 0, o.customPercentRate14 = 0, o.customPercentRate15 = 0, o.customPercentRate16 = 0, o.customPercentRate17 = 0, o.customPercentRate18 = 0, o.customPercentRate19 = 0, o.customPercentRate20 = 0 where o.customPercentRate11 is null").executeUpdate();
			paramProjectDBUtil.currentSession().createQuery("update BoqItemTable o set o.customText21 = '', o.customText22 = '', o.customText23 = '', o.customText24 = '', o.customText25 = '' where o.customText21 is null").executeUpdate();
			paramProjectDBUtil.currentSession().createQuery("update AssemblyTable o set o.customRate16 = 0, o.customRate17 = 0, o.customRate18 = 0, o.customRate19 = 0, o.customRate20 = 0 where o.customRate16 is null").executeUpdate();
			paramProjectDBUtil.currentSession().createQuery("update AssemblyTable o set o.customText21 = '', o.customText22 = '', o.customText23 = '', o.customText24 = '', o.customText25 = '' where o.customText21 is null").executeUpdate();
			paramProjectDBUtil.currentSession().createQuery("update ParamItemConceptualResourceTable o set o.customRate16Equation = '', o.customRate17Equation = '', o.customRate18Equation = '', o.customRate19Equation = '', o.customRate20Equation = '' where o.customRate16Equation is null").executeUpdate();
			paramProjectDBUtil.currentSession().createQuery("update ParamItemConceptualResourceTable o set o.customText21Equation = '', o.customText22Equation = '', o.customText23Equation = '', o.customText24Equation = '', o.customText25Equation = '' where o.customText21Equation is null").executeUpdate();
			paramProjectDBUtil.currentSession().createQuery("update ParamItemConceptualResourceTable o set o.customCumRate11Equation = '', o.customCumRate12Equation = '', o.customCumRate13Equation = '', o.customCumRate14Equation = '', o.customCumRate15Equation = '', o.customCumRate16Equation = '', o.customCumRate17Equation = '', o.customCumRate18Equation = '', o.customCumRate19Equation = '', o.customCumRate20Equation = '' where o.customCumRate11Equation is null").executeUpdate();
			paramProjectDBUtil.currentSession().createQuery("update ParamItemQueryResourceTable o set o.customRate16Equation = '', o.customRate17Equation = '', o.customRate18Equation = '', o.customRate19Equation = '', o.customRate20Equation = '' where o.customRate16Equation is null").executeUpdate();
			paramProjectDBUtil.currentSession().createQuery("update ParamItemQueryResourceTable o set o.customText21Equation = '', o.customText22Equation = '', o.customText23Equation = '', o.customText24Equation = '', o.customText25Equation = '' where o.customText21Equation is null").executeUpdate();
			paramProjectDBUtil.currentSession().createQuery("update ParamItemQueryResourceTable o set o.customCumRate11Equation = '', o.customCumRate12Equation = '', o.customCumRate13Equation = '', o.customCumRate14Equation = '', o.customCumRate15Equation = '', o.customCumRate16Equation = '', o.customCumRate17Equation = '', o.customCumRate18Equation = '', o.customCumRate19Equation = '', o.customCumRate20Equation = '' where o.customCumRate11Equation is null").executeUpdate();
			transaction.commit();
		  }
		  catch (Exception)
		  {
			if (transaction.Active)
			{
			  transaction.rollback();
			}
		  }
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "6.2.3";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.4"))
		{
		  Console.WriteLine("Updating Project file to 6.2.4 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = null;
		  if (paramSessionInterface == null)
		  {
			session = DatabaseDBUtil.currentSession();
		  }
		  else
		  {
			session = paramSessionInterface.currentSession();
		  }
		  try
		  {
			System.Collections.IList list = session.createQuery("select u.projectUrlId from ProjectUrlTable as u").list();
			if (list.Count == 0)
			{
			  paramProjectDBUtil.currentSession().createSQLQuery("DELETE FROM PRJPROP").executeUpdate();
			  paramProjectDBUtil.currentSession().createSQLQuery("DELETE FROM PRJUSERPROP").executeUpdate();
			}
			else
			{
			  string str = "";
			  foreach (long? long in list)
			  {
				str = str + "" + long + ",";
			  }
			  int i = str.LastIndexOf(",", StringComparison.Ordinal);
			  str = str.Substring(0, i);
			  paramProjectDBUtil.currentSession().createSQLQuery("DELETE FROM PRJPROP WHERE PRJID NOT IN (" + str + ")").executeUpdate();
			  paramProjectDBUtil.currentSession().createSQLQuery("DELETE FROM PRJUSERPROP WHERE PRJID NOT IN (" + str + ")").executeUpdate();
			  paramProjectDBUtil.currentSession().createSQLQuery("WITH DUPLICATES(MINID, PKEY, PRJID, CNT) AS (SELECT MIN(ID), PKEY, PRJID, COUNT(1) FROM PRJPROP GROUP BY PKEY, PRJID HAVING COUNT(1) > 1) DELETE P1 FROM PRJPROP P1 JOIN DUPLICATES P2 on P1.PKEY = P2.PKEY and P1.PRJID = P2.PRJID and P1.ID != P2.MINID").executeUpdate();
			  Console.WriteLine("EXECUTED 1");
			  paramProjectDBUtil.currentSession().createSQLQuery("WITH DUPLICATES(MINID, PKEY, PROPUSER, PRJID, CNT) AS (SELECT MIN(ID), PKEY, PROPUSER, PRJID, COUNT(1) FROM PRJUSERPROP GROUP BY PKEY, PROPUSER, PRJID HAVING COUNT(1) > 1) DELETE P1 FROM PRJUSERPROP P1 JOIN DUPLICATES P2 on P1.PKEY = P2.PKEY and P1.PROPUSER = P2.PROPUSER and P1.PRJID = P2.PRJID and P1.ID != P2.MINID").executeUpdate();
			  Console.WriteLine("EXECUTED 2");
			}
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  if (paramSessionInterface == null)
		  {
			DatabaseDBUtil.closeSession();
		  }
		  else
		  {
			paramSessionInterface.closeSession();
		  }
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "6.2.4";
		  @bool = true;
		  Console.WriteLine("Successfully Updated Project file to 6.2.4 from version " + paramProjectDBProperties.PreviousVersion);
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.6"))
		{
		  Console.WriteLine("Updating Project file to 6.2.6 from version " + paramProjectDBProperties.PreviousVersion);
		  Session session = paramProjectDBUtil.currentSession();
		  if (paramProjectDBUtil.DbmsType == ProjectDBUtil.SQLSERVER_DBMS)
		  {
			System.Collections.IEnumerator iterator = paramProjectDBUtil.Configuration.ClassMappings;
			while (iterator.MoveNext())
			{
			  PersistentClass persistentClass = (PersistentClass)iterator.Current;
			  paramProjectDBUtil.currentSession().beginTransaction();
			  alterVarCharMaxToNVarCharMax(paramProjectDBUtil.currentSession(), persistentClass);
			  paramProjectDBUtil.currentSession().Transaction.commit();
			}
			paramProjectDBUtil.closeSession();
			iterator = paramProjectDBUtil.Configuration.ClassMappings;
			while (iterator.MoveNext())
			{
			  PersistentClass persistentClass = (PersistentClass)iterator.Current;
			  paramProjectDBUtil.currentSession().beginTransaction();
			  alterVarChar255ToNVarChar255(paramProjectDBUtil, persistentClass);
			  paramProjectDBUtil.currentSession().Transaction.commit();
			}
		  }
		  paramProjectDBUtil.closeSession();
		  paramProjectDBProperties.PreviousVersion = "6.2.6";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.9"))
		{
		  Console.WriteLine("Updating Project file to 6.2.9 from version " + paramProjectDBProperties.PreviousVersion);
		  paramProjectDBProperties.PreviousVersion = "6.2.9";
		  @bool = true;
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.10"))
		{
		  try
		  {
			Console.WriteLine("Updating Project database to 6.2.10 from version " + paramProjectDBProperties.PreviousVersion);
			if (paramProjectDBUtil.DbmsType == ProjectDBUtil.SQLSERVER_DBMS)
			{
			  System.Collections.IEnumerator iterator = paramProjectDBUtil.Configuration.ClassMappings;
			  while (iterator.MoveNext())
			  {
				PersistentClass persistentClass = (PersistentClass)iterator.Current;
				paramProjectDBUtil.currentSession().beginTransaction();
				alterVarCharMaxToNVarCharMax(paramProjectDBUtil.currentSession(), persistentClass);
				paramProjectDBUtil.currentSession().Transaction.commit();
			  }
			  paramProjectDBUtil.closeSession();
			  iterator = paramProjectDBUtil.Configuration.ClassMappings;
			  while (iterator.MoveNext())
			  {
				PersistentClass persistentClass = (PersistentClass)iterator.Current;
				paramProjectDBUtil.currentSession().beginTransaction();
				alterVarChar255ToNVarChar255(paramProjectDBUtil, persistentClass);
				paramProjectDBUtil.currentSession().Transaction.commit();
			  }
			  paramProjectDBUtil.closeSession();
			}
			paramProjectDBUtil.currentSession().createSQLQuery("BEGIN TRAN;\nALTER TABLE WSFILE ALTER COLUMN ACTSHEETS NVARCHAR(MAX);\nCOMMIT;").executeUpdate();
			paramProjectDBUtil.closeSession();
			paramProjectDBProperties.PreviousVersion = "6.2.10";
			@bool = true;
			Console.WriteLine(" Project database succesfully updated to version 6.2.10");
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.11"))
		{
		  try
		  {
			Console.WriteLine("Updating Project file to 6.2.11 from version " + paramProjectDBProperties.PreviousVersion);
			Session session = null;
			if (paramSessionInterface == null)
			{
			  session = DatabaseDBUtil.currentSession();
			}
			else
			{
			  session = paramSessionInterface.currentSession();
			}
			session.createSQLQuery("UPDATE FIELDCUSTOM SET FORMULA = '(TOTAL_RATE*QUANTITY)+FIXED_COST' WHERE NAME = 'totalCost' AND FORMULA = 'TOTAL_RATE*QUANTITY'").executeUpdate();
			if (paramSessionInterface == null)
			{
			  DatabaseDBUtil.closeSession();
			}
			else
			{
			  paramSessionInterface.closeSession();
			}
			paramProjectDBUtil.currentSession().createSQLQuery("UPDATE BOQITEM SET FIXEDCOST = 0 WHERE FIXEDCOST IS NULL").executeUpdate();
			paramProjectDBUtil.currentSession().createSQLQuery("UPDATE BOQITEM SET TOTALCOSTFORM = '(TOTAL_RATE*QUANTITY)+FIXED_COST' WHERE TOTALCOSTFORM = 'TOTAL_RATE*QUANTITY'").executeUpdate();
			paramProjectDBUtil.closeSession();
			paramProjectDBProperties.PreviousVersion = "6.2.11";
			@bool = true;
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
			if (paramSessionInterface == null)
			{
			  if (DatabaseDBUtil.hasOpenedSession())
			  {
				try
				{
				  DatabaseDBUtil.closeSession();
				}
				catch (Exception exception1)
				{
				  Console.WriteLine(exception1.ToString());
				  Console.Write(exception1.StackTrace);
				}
			  }
			}
			else
			{
			  try
			  {
				paramSessionInterface.closeSession();
			  }
			  catch (Exception exception1)
			  {
				Console.WriteLine(exception1.ToString());
				Console.Write(exception1.StackTrace);
			  }
			}
			if (paramProjectDBUtil.hasOpenedSession())
			{
			  try
			  {
				paramProjectDBUtil.closeSession();
			  }
			  catch (Exception exception1)
			  {
				Console.WriteLine(exception1.ToString());
				Console.Write(exception1.StackTrace);
			  }
			}
		  }
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.12"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE PARAMINPUT SET CALCVALUE = 1 WHERE CALCVALUE IS NULL").executeUpdate();
			transaction.commit();
			paramProjectDBUtil.closeSession();
			paramProjectDBProperties.PreviousVersion = "6.2.12";
			@bool = true;
			Console.WriteLine(" Project database succesfully updated to version 6.2.12");
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
			if (session.Open && transaction.Active)
			{
			  transaction.rollback();
			}
			try
			{
			  paramProjectDBUtil.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.13"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE BOQITEM SET GLBPARAMITEMID = PARAMITEMID WHERE GLBPARAMITEMID IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE PARAMITEM SET GLBID = PARAMITEMID WHERE GLBID IS NULL").executeUpdate();
			transaction.commit();
			paramProjectDBUtil.closeSession();
			paramProjectDBProperties.PreviousVersion = "6.2.13";
			@bool = true;
			Console.WriteLine(" Project database succesfully updated to version 6.2.13");
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
			if (session.Open && transaction.Active)
			{
			  transaction.rollback();
			}
			try
			{
			  paramProjectDBUtil.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.14"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE PARAMINPUT SET CALCVALDIGITS = 3 WHERE CALCVALDIGITS IS NULL").executeUpdate();
			transaction.commit();
			paramProjectDBUtil.closeSession();
			paramProjectDBProperties.PreviousVersion = "6.2.14";
			@bool = true;
			Console.WriteLine(" Project database succesfully updated to version 6.2.14");
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
			if (session.Open && transaction.Active)
			{
			  transaction.rollback();
			}
			try
			{
			  paramProjectDBUtil.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.15"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE PROJECTSPECVAR SET HIDDEN = 0 WHERE HIDDEN IS NULL").executeUpdate();
			transaction.commit();
			paramProjectDBUtil.closeSession();
			paramProjectDBProperties.PreviousVersion = "6.2.15";
			@bool = true;
			Console.WriteLine(" Project database succesfully updated to version 6.2.15");
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
			if (session.Open && transaction.Active)
			{
			  transaction.rollback();
			}
			try
			{
			  paramProjectDBUtil.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.16"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			fixBoqAndLineItemAssignmentsTrash(session);
			transaction.commit();
			paramProjectDBUtil.closeSession();
			paramProjectDBProperties.PreviousVersion = "6.2.16";
			@bool = true;
			Console.WriteLine(" Project database succesfully updated to version 6.2.16");
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
			if (session.Open && transaction.Active)
			{
			  transaction.rollback();
			}
			try
			{
			  paramProjectDBUtil.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.17"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE ASSEMBLY_CHILD         SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_CONSUMABLE    SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_EQUIPMENT     SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_LABOR         SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_MATERIAL      SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_SUBCONTRACTOR SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE BOQITEM_ASSEMBLY      SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE BOQITEM_CONSUMABLE    SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE BOQITEM_EQUIPMENT     SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE BOQITEM_LABOR         SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE BOQITEM_MATERIAL      SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE BOQITEM_SUBCONTRACTOR SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			transaction.commit();
			paramProjectDBUtil.closeSession();
			paramProjectDBProperties.PreviousVersion = "6.2.17";
			@bool = true;
			Console.WriteLine(" Project database succesfully updated to version 6.2.17");
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
			if (session.Open && transaction.Active)
			{
			  transaction.rollback();
			}
			try
			{
			  paramProjectDBUtil.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.18"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE BOQITEM SET HAS_ASSFORM = 0 WHERE HAS_ASSFORM IS NULL").executeUpdate();
			transaction.commit();
			paramProjectDBUtil.closeSession();
			paramProjectDBProperties.PreviousVersion = "6.2.18";
			@bool = true;
			Console.WriteLine(" Project database succesfully updated to version 6.2.18");
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
			if (session.Open && transaction.Active)
			{
			  transaction.rollback();
			}
			try
			{
			  paramProjectDBUtil.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.19"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE PARAMINPUT SET FRMROWVIS = 0 WHERE FRMROWVIS IS NULL").executeUpdate();
			transaction.commit();
			paramProjectDBUtil.closeSession();
			paramProjectDBProperties.PreviousVersion = "6.2.19";
			@bool = true;
			Console.WriteLine(" Project database succesfully updated to version 6.2.19");
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
			if (session.Open && transaction.Active)
			{
			  transaction.rollback();
			}
			try
			{
			  paramProjectDBUtil.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.20"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE BOQITEM SET HAS_PVFORM  = 0   WHERE HAS_PVFORM IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE BOQITEM SET PV_VARS     = ''  WHERE PV_VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_CHILD         SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_CONSUMABLE    SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_EQUIPMENT     SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_LABOR         SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_MATERIAL      SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_SUBCONTRACTOR SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE BOQITEM_ASSEMBLY      SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE BOQITEM_CONSUMABLE    SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE BOQITEM_EQUIPMENT     SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE BOQITEM_LABOR         SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE BOQITEM_MATERIAL      SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE BOQITEM_SUBCONTRACTOR SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			transaction.commit();
			paramProjectDBUtil.closeSession();
			paramProjectDBProperties.PreviousVersion = "6.2.20";
			@bool = true;
			Console.WriteLine(" Project database succesfully updated to version 6.2.20");
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
			if (session.Open && transaction.Active)
			{
			  transaction.rollback();
			}
			try
			{
			  paramProjectDBUtil.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.21"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE BOQITEM SET VARS = '' WHERE VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY SET VARS = '' WHERE VARS IS NULL").executeUpdate();
			transaction.commit();
			paramProjectDBUtil.closeSession();
			paramProjectDBProperties.PreviousVersion = "6.2.21";
			@bool = true;
			Console.WriteLine(" Project database succesfully updated to version 6.2.21");
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
			if (session.Open && transaction.Active)
			{
			  transaction.rollback();
			}
			try
			{
			  paramProjectDBUtil.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.2.22"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE ASSEMBLY_EQUIPMENT  SET UNITHOURS = 1  WHERE UNITHOURS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_LABOR      SET UNITHOURS = 1  WHERE UNITHOURS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE BOQITEM_EQUIPMENT   SET UNITHOURS = 1  WHERE UNITHOURS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE BOQITEM_LABOR       SET UNITHOURS = 1  WHERE UNITHOURS IS NULL").executeUpdate();
			transaction.commit();
			paramProjectDBUtil.closeSession();
			paramProjectDBProperties.PreviousVersion = "6.2.22";
			@bool = true;
			Console.WriteLine(" Project database succesfully updated to version 6.2.22");
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
			if (session.Open && transaction.Active)
			{
			  transaction.rollback();
			}
			try
			{
			  paramProjectDBUtil.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (paramProjectDBProperties.isOlderVersionFrom(paramProjectDBProperties.PreviousVersion, "6.3.0"))
		{
		  Session session = paramProjectDBUtil.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE CNDON SET PICKTYPE = 0 WHERE PICKTYPE IS NULL AND TAKEOFFTYPE != 'BIM'").executeUpdate();
			session.createSQLQuery("UPDATE CNDON SET PICKTYPE = 1 WHERE PICKTYPE IS NULL AND TAKEOFFTYPE  = 'BIM'").executeUpdate();
			session.createSQLQuery("UPDATE PARAMCONDITION SET PICKTYPE = 0 WHERE PICKTYPE IS NULL AND TAKEOFFTYPE != 'BIM'").executeUpdate();
			session.createSQLQuery("UPDATE PARAMCONDITION SET PICKTYPE = 1 WHERE PICKTYPE IS NULL AND TAKEOFFTYPE  = 'BIM'").executeUpdate();
			transaction.commit();
			paramProjectDBUtil.closeSession();
			paramProjectDBProperties.PreviousVersion = "6.3.0";
			@bool = true;
			Console.WriteLine(" Project database succesfully updated to version 6.3.0");
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
			if (session.Open && transaction.Active)
			{
			  transaction.rollback();
			}
			try
			{
			  paramProjectDBUtil.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (paramProjectDBUtil.CollaborationMode && @bool && paramSessionInterface == null)
		{
		  try
		  {
			Console.WriteLine("Saving properties upgrades to version: " + paramProjectDBProperties.PreviousVersion);
			paramProjectDBProperties.storeDBProperties();
			Console.WriteLine("Saved!");
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		}
	  }

	  public static void fixBoqAndLineItemAssignmentsTrash(Session paramSession)
	  {
		paramSession.createSQLQuery("DELETE FROM ASSEMBLY_CHILD         WHERE ASSEMBLYID IS NULL OR CHILDID IS NULL").executeUpdate();
		paramSession.createSQLQuery("DELETE FROM ASSEMBLY_CONSUMABLE    WHERE ASSEMBLYID IS NULL OR CONSUMABLEID IS NULL").executeUpdate();
		paramSession.createSQLQuery("DELETE FROM ASSEMBLY_EQUIPMENT     WHERE ASSEMBLYID IS NULL OR EQUIPMENTID IS NULL").executeUpdate();
		paramSession.createSQLQuery("DELETE FROM ASSEMBLY_LABOR         WHERE ASSEMBLYID IS NULL OR LABORID IS NULL").executeUpdate();
		paramSession.createSQLQuery("DELETE FROM ASSEMBLY_MATERIAL      WHERE ASSEMBLYID IS NULL OR MATERIALID IS NULL").executeUpdate();
		paramSession.createSQLQuery("DELETE FROM ASSEMBLY_SUBCONTRACTOR WHERE ASSEMBLYID IS NULL OR SUBCONTRACTORID IS NULL").executeUpdate();
		paramSession.createSQLQuery("DELETE FROM BOQITEM_ASSEMBLY      WHERE BOQITEMID IS NULL OR ASSEMBLYID IS NULL").executeUpdate();
		paramSession.createSQLQuery("DELETE FROM BOQITEM_CONSUMABLE    WHERE BOQITEMID IS NULL OR CONSUMABLEID IS NULL").executeUpdate();
		paramSession.createSQLQuery("DELETE FROM BOQITEM_EQUIPMENT     WHERE BOQITEMID IS NULL OR EQUIPMENTID IS NULL").executeUpdate();
		paramSession.createSQLQuery("DELETE FROM BOQITEM_LABOR         WHERE BOQITEMID IS NULL OR LABORID IS NULL").executeUpdate();
		paramSession.createSQLQuery("DELETE FROM BOQITEM_MATERIAL      WHERE BOQITEMID IS NULL OR MATERIALID IS NULL").executeUpdate();
		paramSession.createSQLQuery("DELETE FROM BOQITEM_SUBCONTRACTOR WHERE BOQITEMID IS NULL OR SUBCONTRACTORID IS NULL").executeUpdate();
	  }

	  public static void updateManyProjectsDBSchema(Session paramSession, string paramString1, string paramString2, long? paramLong)
	  {
		  paramSession.createSQLQuery("update " + paramString1 + ".dbo.PRJPROP set PVAL = '" + paramString2 + "' WHERE PKEY = 'costos.estimating.version' AND PRJID = " + paramLong).executeUpdate();
	  }

	  private static void fixConstraints(ProjectDBUtil paramProjectDBUtil)
	  {
		dropForeignKey(paramProjectDBUtil, "WSFILE", "REVISIONID");
		dropForeignKey(paramProjectDBUtil, "WSREVISION", "REVISIONID");
		dropForeignKey(paramProjectDBUtil, "XCELLFILE", "TEMPLATEID");
		try
		{
		  paramProjectDBUtil.currentSession().createSQLQuery("UPDATE w SET w.MAPPINGID = w.REVISIONID from WSREVISION w").executeUpdate();
		}
		catch (Exception)
		{
		}
		try
		{
		  paramProjectDBUtil.currentSession().createSQLQuery("UPDATE w SET w.FILEID = w.REVISIONID from WSFILE w").executeUpdate();
		}
		catch (Exception)
		{
		}
	  }

	  private static void dropForeignKey(ProjectDBUtil paramProjectDBUtil, string paramString1, string paramString2)
	  {
		try
		{
		  string str = findForeignKey(paramProjectDBUtil, paramString1, paramString2);
		  if (!string.ReferenceEquals(str, null))
		  {
			paramProjectDBUtil.currentSession().createSQLQuery("ALTER TABLE " + paramString1 + " DROP CONSTRAINT " + str).executeUpdate();
			Console.WriteLine("DROPED: " + str);
		  }
		  else
		  {
			Console.WriteLine("COULD NOT DROP: " + paramString1 + " " + paramString2);
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine("COULD NOT DROP: " + paramString1 + " " + paramString2);
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
	  }

	  private static string findForeignKey(ProjectDBUtil paramProjectDBUtil, string paramString1, string paramString2)
	  {
		string str = "SELECT ccu.CONSTRAINT_NAME FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu INNER JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc ON ccu.CONSTRAINT_NAME = rc.CONSTRAINT_NAME INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu ON kcu.CONSTRAINT_NAME = rc.UNIQUE_CONSTRAINT_NAME WHERE ccu.table_name = '" + paramString1 + "' AND ccu.COLUMN_NAME = '" + paramString2 + "' ORDER BY ccu.table_name ";
		return (string)paramProjectDBUtil.currentSession().createSQLQuery(str).uniqueResult();
	  }

	  public static bool checkRequiresProjectIdUpdates(ProjectDBUtil paramProjectDBUtil)
	  {
		Session session = paramProjectDBUtil.currentSession();
		try
		{
		  Number number = (Number)session.createQuery("select count(o.projectId) from ProjectPropertyTable o where o.projectId = " + paramProjectDBUtil.ProjectUrlId).uniqueResult();
		  if (number.intValue() > 0)
		  {
			return false;
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		paramProjectDBUtil.closeSession();
		return true;
	  }

	  public static void processProjectIdUpdates(ProjectDBUtil paramProjectDBUtil)
	  {
		if (paramProjectDBUtil.ProjectUrlId == null)
		{
		  return;
		}
		Session session = paramProjectDBUtil.currentSession();
		System.Collections.IList list = paramProjectDBUtil.listClasses();
		foreach (PersistentClass persistentClass in list)
		{
		  try
		  {
			Type clazz = Type.GetType(persistentClass.ClassName);
			if (clazz.IsAssignableFrom(typeof(Desktop.common.nomitech.common.@base.ProjectIdEntity)))
			{
			  string str = "update " + persistentClass.Table.Name + " set PRJID = :prjId where PRJID is null";
			  session.createSQLQuery(str).setLong("prjId", paramProjectDBUtil.ProjectUrlId.Value).executeUpdate();
			}
		  }
		  catch (ClassNotFoundException classNotFoundException)
		  {
			Console.WriteLine(classNotFoundException.ToString());
			Console.Write(classNotFoundException.StackTrace);
		  }
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static void copyWBSTables(org.hibernate.Session paramSession1, org.hibernate.Session paramSession2) throws Exception
	  private static void copyWBSTables(Session paramSession1, Session paramSession2)
	  {
		int i = ((Number)paramSession1.createQuery("select count(o.projectWBSId) from ProjectWBSTable as o").iterate().next()).intValue();
		int j = ((Number)paramSession1.createQuery("select count(o.projectWBSId) from ProjectWBS2Table as o").iterate().next()).intValue();
		string str1 = (string)paramSession1.createQuery("select o.propValue from ProjectPropertyTable as o where o.propKey ='project.code'").iterate().next();
		string str2 = (string)paramSession1.createQuery("select o.propValue from ProjectPropertyTable as o where o.propKey ='project.name'").iterate().next();
		if (i == 0)
		{
		  Query query = paramSession2.createQuery("from ProjectWBSTable o where o.projectInfoTable.code = :code and o.projectInfoTable.title = :title order by o.projectWBSId");
		  query.setString("code", str1);
		  query.setString("title", str2);
		  foreach (ProjectWBSTable projectWBSTable in query.list())
		  {
			paramSession1.save(projectWBSTable.clone());
		  }
		  paramSession1.flush();
		}
		if (j == 0)
		{
		  Query query = paramSession2.createQuery("from ProjectWBS2Table o where o.projectInfoTable.code = :code and o.projectInfoTable.title = :title order by o.projectWBSId");
		  query.setString("code", str1);
		  query.setString("title", str2);
		  foreach (ProjectWBS2Table projectWBS2Table in query.list())
		  {
			paramSession1.save(projectWBS2Table.clone());
		  }
		  paramSession1.flush();
		}
	  }

	  public static void alterTextToVarCharMax(Session paramSession, PersistentClass paramPersistentClass)
	  {
		System.Collections.IEnumerator iterator = paramPersistentClass.PropertyIterator;
		while (iterator.MoveNext())
		{
		  Property property = (Property)iterator.Current;
		  if (!(property.Type is Desktop.common.nomitech.common.db.types.CostOSTextType) || paramPersistentClass.Table.Name.EndsWith("View"))
		  {
			continue;
		  }
		  System.Collections.IEnumerator iterator1 = property.ColumnIterator;
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		  if (iterator1.hasNext())
		  {
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			Column column = (Column)iterator1.next();
			paramSession.createSQLQuery("BEGIN TRAN;\nALTER TABLE " + paramPersistentClass.Table.Name + " ALTER COLUMN " + column.Name + " VARCHAR(MAX);\nCOMMIT;").executeUpdate();
		  }
		}
	  }

	  public static void alterVarCharMaxToNVarCharMax(Session paramSession, PersistentClass paramPersistentClass)
	  {
		System.Collections.IEnumerator iterator = paramPersistentClass.PropertyIterator;
		while (iterator.MoveNext())
		{
		  Property property = (Property)iterator.Current;
		  if (!(property.Type is Desktop.common.nomitech.common.db.types.CostOSTextType) || paramPersistentClass.Table.Name.EndsWith("View"))
		  {
			continue;
		  }
		  System.Collections.IEnumerator iterator1 = property.ColumnIterator;
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		  if (iterator1.hasNext())
		  {
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			Column column = (Column)iterator1.next();
			try
			{
			  paramSession.createSQLQuery("BEGIN TRAN;\nALTER TABLE " + paramPersistentClass.Table.Name + " ALTER COLUMN " + column.Name + " NVARCHAR(MAX);\nCOMMIT;").executeUpdate();
			}
			catch (Exception exception)
			{
			  Console.WriteLine(exception.ToString());
			  Console.Write(exception.StackTrace);
			}
		  }
		}
	  }

	  public static void alterVarChar255ToNVarChar255(ProjectDBUtil paramProjectDBUtil, PersistentClass paramPersistentClass)
	  {
		System.Collections.IEnumerator iterator = paramPersistentClass.PropertyIterator;
		while (iterator.MoveNext())
		{
		  Property property = (Property)iterator.Current;
		  if (paramPersistentClass.Table.Name.EndsWith("View"))
		  {
			continue;
		  }
		  Type type = property.Type;
		  if (type is CustomType)
		  {
			UserType userType = ((CustomType)type).UserType;
			if (!(userType is Desktop.common.nomitech.common.db.types.CostOSString256Type))
			{
			  continue;
			}
		  }
		  else if (!(type is Desktop.common.nomitech.common.db.types.CostOSStringType))
		  {
			continue;
		  }
		  System.Collections.IEnumerator iterator1 = property.ColumnIterator;
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		  if (iterator1.hasNext())
		  {
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			Column column = (Column)iterator1.next();
			try
			{
			  string str = "BEGIN TRAN;\nALTER TABLE " + paramPersistentClass.Table.Name + " ALTER COLUMN " + column.Name + " NVARCHAR(255);\nCOMMIT;";
			  paramProjectDBUtil.currentSession().createSQLQuery(str).executeUpdate();
			}
			catch (Exception exception)
			{
			  paramProjectDBUtil.closeSession();
			  if (exception.InnerException != null && exception.InnerException.Message.StartsWith("The index '"))
			  {
				paramProjectDBUtil.closeSession();
				paramProjectDBUtil.currentSession().beginTransaction();
				string str1 = exception.InnerException.Message;
				str1 = str1.Substring(str1.IndexOf("'", StringComparison.Ordinal) + 1);
				string str2 = str1.Substring(0, str1.IndexOf("'", StringComparison.Ordinal));
				try
				{
				  string str = "BEGIN TRAN;\nDROP INDEX " + str2 + " ON " + paramPersistentClass.Table.Name + ";\n";
				  str = str + "ALTER TABLE " + paramPersistentClass.Table.Name + " ALTER COLUMN " + column.Name + " NVARCHAR(255);\n";
				  str = str + "CREATE INDEX " + str2 + " ON " + paramPersistentClass.Table.Name + "(" + column.Name + ");\n";
				  str = str + "COMMIT;";
				  Console.WriteLine("EXEC: " + str);
				  paramProjectDBUtil.currentSession().createSQLQuery(str).executeUpdate();
				}
				catch (Exception exception1)
				{
				  Console.WriteLine(exception1.ToString());
				  Console.Write(exception1.StackTrace);
				}
			  }
			}
		  }
		}
	  }

	  public static void alterVarChar255ToNVarChar255(SessionInterface paramSessionInterface, PersistentClass paramPersistentClass)
	  {
		System.Collections.IEnumerator iterator = paramPersistentClass.PropertyIterator;
		while (iterator.MoveNext())
		{
		  Property property = (Property)iterator.Current;
		  if (paramPersistentClass.Table.Name.EndsWith("View"))
		  {
			continue;
		  }
		  Type type = property.Type;
		  if (type is CustomType)
		  {
			UserType userType = ((CustomType)type).UserType;
			if (!(userType is Desktop.common.nomitech.common.db.types.CostOSString256Type))
			{
			  continue;
			}
		  }
		  else if (!(type is Desktop.common.nomitech.common.db.types.CostOSStringType))
		  {
			continue;
		  }
		  System.Collections.IEnumerator iterator1 = property.ColumnIterator;
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		  if (iterator1.hasNext())
		  {
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			Column column = (Column)iterator1.next();
			try
			{
			  string str = "BEGIN TRAN;\nALTER TABLE " + paramPersistentClass.Table.Name + " ALTER COLUMN " + column.Name + " NVARCHAR(255);\nCOMMIT;";
			  paramSessionInterface.currentSession().createSQLQuery(str).executeUpdate();
			}
			catch (Exception exception)
			{
			  paramSessionInterface.closeSession();
			  if (exception.InnerException != null && exception.InnerException.Message.StartsWith("The index '"))
			  {
				paramSessionInterface.closeSession();
				paramSessionInterface.currentSession().beginTransaction();
				string str1 = exception.InnerException.Message;
				str1 = str1.Substring(str1.IndexOf("'", StringComparison.Ordinal) + 1);
				string str2 = str1.Substring(0, str1.IndexOf("'", StringComparison.Ordinal));
				try
				{
				  string str = "BEGIN TRAN;\nDROP INDEX " + str2 + " ON " + paramPersistentClass.Table.Name + ";\n";
				  str = str + "ALTER TABLE " + paramPersistentClass.Table.Name + " ALTER COLUMN " + column.Name + " NVARCHAR(255);\n";
				  str = str + "CREATE INDEX " + str2 + " ON " + paramPersistentClass.Table.Name + "(" + column.Name + ");\n";
				  str = str + "COMMIT;";
				  paramSessionInterface.currentSession().createSQLQuery(str).executeUpdate();
				}
				catch (Exception exception1)
				{
				  Console.WriteLine(exception1.ToString());
				  Console.Write(exception1.StackTrace);
				}
			  }
			}
		  }
		}
	  }

	  public static Query makeTextUpdateQuery(Session paramSession, PersistentClass paramPersistentClass, Property paramProperty)
	  {
		StringBuilder stringBuffer1 = new StringBuilder();
		StringBuilder stringBuffer2 = new StringBuilder();
		stringBuffer1.Append("update " + paramPersistentClass.EntityName + " o set ");
		stringBuffer2.Append("where ");
		bool bool1 = false;
		bool bool2 = false;
		if (paramProperty.Type is Desktop.common.nomitech.common.db.types.CostOSStringType)
		{
		  stringBuffer1.Append("o." + paramProperty.Name + " = '', ");
		  stringBuffer2.Append("o." + paramProperty.Name + " like '" + "{#}" + "' or o." + paramProperty.Name + " like '" + "{=}" + "', ");
		  bool1 = true;
		}
		else if (paramProperty.Type is Desktop.common.nomitech.common.db.types.CostOSTextType)
		{
		  stringBuffer1.Append("o." + paramProperty.Name + " = '', ");
		  stringBuffer2.Append("o." + paramProperty.Name + " like '" + "{#}" + "' or o." + paramProperty.Name + " like '" + "{=}" + "', ");
		  bool2 = true;
		}
		if (!bool1 && !bool2)
		{
		  return null;
		}
		string str1 = stringBuffer1.ToString();
		str1 = str1.Substring(0, str1.Length - 2) + " ";
		string str2 = stringBuffer2.ToString();
		str2 = str2.Substring(0, str2.Length - 2) + " ";
		string str3 = str1 + str2;
		return paramSession.createQuery(str3);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ProjectSchemaUpdateUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}