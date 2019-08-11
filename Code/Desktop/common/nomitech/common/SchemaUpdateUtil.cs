using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Desktop.common.nomitech.common
{
	using UserTeam = Desktop.common.nomitech.common.auth.UserTeam;
	using BaseDBProperties = Desktop.common.nomitech.common.@base.BaseDBProperties;
	using ResourceToAssignmentTable = Desktop.common.nomitech.common.@base.ResourceToAssignmentTable;
	using ResourceWithAssignmentsTable = Desktop.common.nomitech.common.@base.ResourceWithAssignmentsTable;
	using Currency = Desktop.common.nomitech.common.currency.Currency;
	using CurrencyHome = Desktop.common.nomitech.common.currency.CurrencyHome;
	using DataObjectDescriptor = Desktop.common.nomitech.common.data.descriptor.DataObjectDescriptor;
	using DynBoqItemViewDescriptor = Desktop.common.nomitech.common.data.descriptor.DynBoqItemViewDescriptor;
	using LayoutPanelTable = Models.layout.LayoutPanelTable;
	using LayoutTable = Models.layout.LayoutTable;
	using BoqMetadataTable = Models.local.BoqMetadataTable;
	using CountryTable = Models.local.CountryTable;
	using CurrencyTable = Models.local.CurrencyTable;
	using ProjectInfoTable = Models.local.ProjectInfoTable;
	using ProjectUrlTable = Models.local.ProjectUrlTable;
	using BigDecimalFixed = Models.types.BigDecimalFixed;
	using UICountries = Desktop.common.nomitech.common.ui.UICountries;
	using AddOnUtil = Desktop.common.nomitech.common.util.AddOnUtil;
	using BigDecimalMath = Desktop.common.nomitech.common.util.BigDecimalMath;
	using CryptUtil = Desktop.common.nomitech.common.util.CryptUtil;
	using IPToCountryUtil = Desktop.common.nomitech.common.util.IPToCountryUtil;
	using StringUtils = Desktop.common.nomitech.common.util.StringUtils;
	using TeamAliasUtil = Desktop.common.nomitech.common.util.TeamAliasUtil;
	using Query = org.hibernate.Query;
	using SQLQuery = org.hibernate.SQLQuery;
	using Session = org.hibernate.Session;
	using Transaction = org.hibernate.Transaction;
	using Column = org.hibernate.mapping.Column;
	using PersistentClass = org.hibernate.mapping.PersistentClass;
	using Property = org.hibernate.mapping.Property;
	using Transformers = org.hibernate.transform.Transformers;
	using LongType = org.hibernate.type.LongType;
	using StringType = org.hibernate.type.StringType;
	using Util = org.jboss.security.Util;

	public class SchemaUpdateUtil
	{
	  public static void updateSchema(BaseDBProperties paramBaseDBProperties, string paramString, SessionInterface paramSessionInterface)
	  {
		if (StringUtils.isOlderVersionFrom(paramString, "3.6.0"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA...");
			Query query = session.createQuery("update MaterialTable set bimMaterial = :es, bimType = :es where bimType is null");
			query.setString("es", "");
			query.executeUpdate();
			query = session.createQuery("update AssemblyTable set bimMaterial = :es, bimType = :es where bimType is null");
			query.setString("es", "");
			query.executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "3.6.0");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "3.7.0"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 3.7.0...");
			Query query = session.createQuery("update ProjectInfoTable set storageType = :st where storageType is null");
			query.setString("st", "CEP File");
			query.executeUpdate();
			query = session.createQuery("update ProjectInfoTable set totalCost = :zr, offeredPrice = :zr, primaveraConnected = false, hasBimTakeoff = false, hasOnScreenTakeoff = false, status = :status, currency = :cur, submissionDate = :sDate, location = :emp, stateProvince = :emp, country = 'US', unit = 'M2', client = :emp, contractor = :emp, basementSize = :zr, superstructureSize = :zr, unitCost = :zr, clientBudget = :zr, floors = 1, paymentDuration = 6, projectType = :projectType, subCategory = :subCategory where unitCost is null");
			query.setBigDecimal("zr", new BigDecimalFixed("0"));
			query.setString("status", "enum.boqstatus.underreview");
			query.setString("cur", "USD");
			query.setString("emp", "");
			query.setString("projectType", "dialog.newproject.projecttype.construction");
			query.setString("subCategory", "dialog.newproject.projectsubtype.construction.office");
			query.setDate("sDate", DateTime.Now);
			query.executeUpdate();
			query = session.createQuery("from ProjectInfoTable");
			System.Collections.IEnumerator iterator = query.iterate();
			List<object> arrayList = new List<object>();
			while (iterator.MoveNext())
			{
			  ProjectInfoTable projectInfoTable = (ProjectInfoTable)iterator.Current;
			  ISet<object> set = projectInfoTable.UrlSet;
			  if (set == null || set.Count == 0)
			  {
				arrayList.Add(projectInfoTable);
			  }
			}
			foreach (ProjectInfoTable projectInfoTable in arrayList)
			{
			  ProjectUrlTable projectUrlTable = new ProjectUrlTable();
			  projectUrlTable.Url = "[OLD PROJECT - UNKNOWN URL/FILE]";
			  projectUrlTable.DefaultRevision = true;
			  long? long = (long?)session.save(projectUrlTable);
			  projectUrlTable = (ProjectUrlTable)session.get(typeof(ProjectUrlTable), long);
			  projectInfoTable.UrlSet.Add(projectUrlTable);
			  session.update(projectInfoTable);
			  projectUrlTable.ProjectInfoTable = projectInfoTable;
			  session.update(projectUrlTable);
			}
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "3.7.0");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "3.8.0"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 3.8.0...");
			Query query = session.createQuery("update MaterialTable set accuracy = :es where accuracy is null");
			query.setString("es", "enum.quotation.accuracy.estimated");
			query.executeUpdate();
			query = session.createQuery("update SubcontractorTable set accuracy = :es where accuracy is null");
			query.setString("es", "enum.quotation.accuracy.estimated");
			query.executeUpdate();
			query = session.createQuery("update MaterialTable set bimMaterial = :es, bimType = :es where bimType is null");
			query.setString("es", "");
			query.executeUpdate();
			query = session.createQuery("update AssemblyTable set bimMaterial = :es, bimType = :es where bimType is null");
			query.setString("es", "");
			query.executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "3.8.0");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "3.8.2"))
		{
		  double[] arrayOfDouble = IPToCountryUtil.EuropeGeoPosition;
		  try
		  {
			arrayOfDouble = IPToCountryUtil.getGeoPosition(null);
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 3.8.2 ...");
			Query query = session.createQuery("update MaterialTable set quantity = 0 where quantity is null");
			query.executeUpdate();
			query = session.createQuery("update ProjectInfoTable set geoLocation = :geoLocation where geoLocation is null");
			query.setString("geoLocation", "" + arrayOfDouble[0] + "," + arrayOfDouble[1]);
			query.executeUpdate();
			query = session.createQuery("update SubcontractorTable set quantity = 0 where quantity is null");
			query.executeUpdate();
			query = session.createQuery("update SupplierTable set url = '', geoLocation = :geoLocation where url is null");
			query.setString("geoLocation", "" + arrayOfDouble[0] + "," + arrayOfDouble[1]);
			query.executeUpdate();
			query = session.createQuery("update MaterialTable set distanceToSite = 0, distanceUnit = :du,  rawMaterial = 'enum.rm.unspecified', inclusion = 'enum.inclusion.matonly', shipmentRate = 0, weightUnit = 'KG', totalRate = rate where rawMaterial is null");
			query.setString("du", "KM");
			query.executeUpdate();
			query = session.createQuery("update SubcontractorTable set inclusion = 'enum.inclusion.subonly' where inclusion is null");
			query.executeUpdate();
			query = session.createQuery("update AssemblyTable set quantity = 0, accuracy = 'enum.quotation.accuracy.estimated', createDate = lastUpdate, createUserId = editorId, laborRate = 0, materialRate = 0, subcontractorRate = 0, consumableRate = 0, equipmentRate = 0 where quantity is null");
			query.executeUpdate();
			query = session.createQuery("update ProjectUrlTable set quotesSent = 0, quotesReceived = 0, createUserId = editorId, createDate = lastUpdate where createUserId is null");
			query.executeUpdate();
			query = session.createQuery("update ProjectUrlTable set underReviewItems = 0, pendingItems = 0, approvedItems = 0, completedItems = 0, estimatedItemsTotalCost = 0, quotedItemsTotalCost = 0, markupTotalCost = 0 where markupTotalCost is null");
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
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "3.8.2");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "3.9.1"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 3.9.1...");
			Query query = session.createQuery("update ParamItemTable set sampleRate = 0, unit = :un, extraCode3 = :ec, extraCode4 = :ec, extraCode5 = :ec, extraCode6 = :ec, extraCode7 = :ec where extraCode3 is null");
			query.setString("ec", "");
			query.setString("un", "EACH");
			query = session.createQuery("update MaterialTable o set o.fabricationRate = 0 where o.fabricationRate is null");
			query.executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "3.9.1");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "3.9.3"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 3.9.3...");
			Query query = session.createQuery("update MaterialTable o set o.rawMaterialReliance = 100 where o.rawMaterialReliance is null");
			query.executeUpdate();
			query = session.createQuery("update MaterialTable o set o.rawMaterial = 'enum.rm.unspecified' where o.rawMaterial is null");
			query.executeUpdate();
			query = session.createQuery("update ParamItemOutputTable o set o.factorEquation = 'FACTOR' where o.factorEquation is null");
			query.executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "3.9.3");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "3.9.5"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 3.9.5...");
			Query query = session.createQuery("update ParamItemConceptualResourceTable o set o.weight = '0' where o.weight is null");
			query.executeUpdate();
			query = session.createQuery("update ParamItemConceptualResourceTable o set o.weightUnit = 'KG' where o.weightUnit is null");
			query.executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "3.9.5");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "3.9.6"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 3.9.6...");
			Query query = session.createQuery("update ParamItemInputTable o set o.unit = '' where o.unit is null");
			query.executeUpdate();
			query = session.createQuery("update FunctionArgumentTable o set o.unit = '' where o.unit is null");
			query.executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "3.9.6");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.0.1"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.0.1...");
			Query query = session.createQuery("update AssemblyTable o set o.virtual = false, o.virtualMaterial = false, o.virtualEquipment = false, o.virtualSubcontractor = false, o.virtualConsumable = false, o.virtualLabor = false");
			query.executeUpdate();
			query = session.createQuery("update EquipmentTable o set o.predicted = false, o.virtual = false");
			query.executeUpdate();
			query = session.createQuery("update SubcontractorTable o set o.conceptual = false, o.predicted = false, o.virtual = false");
			query.executeUpdate();
			query = session.createQuery("update LaborTable o set o.conceptual = false, o.predicted = false, o.virtual = false");
			query.executeUpdate();
			query = session.createQuery("update MaterialTable o set o.conceptual = false, o.predicted = false, o.virtual = false");
			query.executeUpdate();
			query = session.createQuery("update ConsumableTable o set o.predicted = false, o.virtual = false");
			query.executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.0.1");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.0.2"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.0.2...");
			System.Collections.IList list = Arrays.asList(session.createQuery("from LayoutTable").list().toArray(new LayoutTable[0]));
			foreach (object @object in list)
			{
			  session.delete(@object);
			}
			Query query = session.createQuery("update ParamItemTable o set o.costModel = false, o.icon = '', o.groupName = ''");
			query.executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.0.2");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.0.3"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.0.3...");
			Query query = session.createQuery("update AssemblyTable o set o.unitManhours = 1/o.productivity");
			query.executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.0.3");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.0.4"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.0.4...");
			session.createQuery("update AssemblyEquipmentTable o set o.localFactor = 1, o.localCountry = '', o.localStateProvince = '', o.energyPrice = 0, o.finalFuelRate = 0").executeUpdate();
			session.createQuery("update AssemblySubcontractorTable o set o.localFactor = 1, o.localCountry = '', o.localStateProvince = ''").executeUpdate();
			session.createQuery("update AssemblyMaterialTable o set o.localFactor = 1, o.localCountry = '', o.localStateProvince = ''").executeUpdate();
			session.createQuery("update AssemblyLaborTable o set o.localFactor = 1, o.localCountry = '', o.localStateProvince = ''").executeUpdate();
			session.createQuery("update AssemblyConsumableTable o set o.localFactor = 1, o.localCountry = '', o.localStateProvince = ''").executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.0.4");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.0.5"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.0.5...");
			session.createQuery("update ParamItemInputTable o set o.pblk = false where o.pblk is null").executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.0.5");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.0.9"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.0.9...");
			Query query = session.createQuery("update MaterialTable o set o.rawMaterial2 = :rm,o.rawMaterial3 = :rm,o.rawMaterial4 = :rm,o.rawMaterial5 = :rm,o.rawMaterialReliance2=0,o.rawMaterialReliance3=0,o.rawMaterialReliance4=0,o.rawMaterialReliance5=0 where o.rawMaterial2 is null");
			query.setString("rm", "enum.rm.unspecified");
			query.executeUpdate();
			query = session.createQuery("update EquipmentTable o set o.country = 'GB', o.stateProvince = '' where o.country is null");
			query.executeUpdate();
			query = session.createQuery("update EquipmentTable o set o.unit = 'HOUR' where o.unit != 'HOUR'");
			query.executeUpdate();
			query = session.createQuery("update LaborTable o set o.unit = 'HOUR' where o.unit != 'HOUR'");
			query.executeUpdate();
			query = session.createQuery("update MaterialTable o set o.volFlow = 0, o.volFlowUnit = '', o.massFlow = 0, o.massFlowUnit = '', o.duty = 0, o.dutyUnit = '', o.operPress = 0, o.operPressUnit = '', o.operTemp = 0, o.operTempUnit = '' where o.operTemp is null");
			query.executeUpdate();
			query = session.createQuery("update ParamItemOutputTable o set o.labLocEquation = 'FACTOR', o.matLocEquation = 'FACTOR', o.equLocEquation = 'FACTOR', o.subLocEquation = 'FACTOR', o.conLocEquation = 'FACTOR'");
			query.executeUpdate();
			if (DatabaseDBUtil.LocalCommunication)
			{
			  SQLQuery sQLQuery = session.createSQLQuery("ALTER TABLE PARAMINPUT MODIFY DEFVALUE longtext");
			  sQLQuery.executeUpdate();
			}
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.0.9");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.1.0"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.1.0...");
			Query query = session.createQuery("update ProjectInfoTable o set o.locationFactors = false, o.locationProfile = '', o.selectedFactor = '' where o.locationProfile is null");
			query.executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.1.0");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.1.2"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.1.2...");
			session.createQuery("update GroupCodeTable o set o.unit = ''").executeUpdate();
			session.createQuery("update GekCodeTable o set o.unit = ''").executeUpdate();
			session.createQuery("update ExtraCode1Table o set o.unit = ''").executeUpdate();
			session.createQuery("update ExtraCode2Table o set o.unit = ''").executeUpdate();
			session.createQuery("update ExtraCode3Table o set o.unit = ''").executeUpdate();
			session.createQuery("update ExtraCode4Table o set o.unit = ''").executeUpdate();
			session.createQuery("update ExtraCode5Table o set o.unit = ''").executeUpdate();
			session.createQuery("update ExtraCode6Table o set o.unit = ''").executeUpdate();
			session.createQuery("update ExtraCode7Table o set o.unit = ''").executeUpdate();
			session.createQuery("update ExtraCode8Table o set o.unit = ''").executeUpdate();
			session.createQuery("update ExtraCode9Table o set o.unit = ''").executeUpdate();
			session.createQuery("update ExtraCode10Table o set o.unit = ''").executeUpdate();
			session.createQuery("update ProjectWBSTable o set o.unit = ''").executeUpdate();
			session.createQuery("update ProjectWBS2Table o set o.unit = ''").executeUpdate();
			session.createQuery("update LayoutPanelTable o set o.enableGrouping = false, o.displayGrouping = false, o.groupedColumns = '', o.groupedColumnOrders = ''").executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.1.2");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.1.3"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.1.3...");
			Query query = session.createQuery("update ParamItemConceptualResourceTable o set o.groupCode = '', o.gekCode = '', o.extraCode1 = '', o.extraCode2 = '', o.extraCode3 = '', o.extraCode4 = '', o.extraCode5 = '', o.extraCode6 = '', o.extraCode7 = '', o.volFlow = 0, o.volFlowUnit = '', o.massFlow = 0, o.massFlowUnit = '', o.duty = 0, o.dutyUnit = '', o.operPress = 0, o.operPressUnit = '', o.operTemp = 0, o.operTempUnit = '', o.subcontractorIKA = 0 where o.operTemp is null");
			query.executeUpdate();
			query = session.createQuery("update FieldCustomizationTable o set o.selectionList = false where o.selectionList is null");
			query.executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.1.3");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.1.4"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.1.4...");
			Query query = session.createQuery("update FieldCustomizationTable o set o.selectionList = false, o.selectionValues = '' where o.selectionList is null");
			query.executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.1.4");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.1.5"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.1.5...");
			Query query = session.createQuery("update AssemblyTable o set o.customText1 = '', o.customText2 = '', o.customText3 = '', o.customText4 = '', o.customText5 = '', o.customText6 = '', o.customText7 = '', o.customText8 = '', o.customText9 = '', o.customText10 = '', o.customText11 = '', o.customText12 = '', o.customText13 = '', o.customText14 = '', o.customText15 = '', o.customText16 = '', o.customText17 = '', o.customText18 = '', o.customText19 = '', o.customText20 = ''");
			query.executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.1.5");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.2.0"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.2.0...");
			session.createQuery("update GroupCodeTable o set o.unitFactor = 1").executeUpdate();
			session.createQuery("update GekCodeTable o set o.unitFactor = 1").executeUpdate();
			session.createQuery("update ExtraCode1Table o set o.unitFactor = 1").executeUpdate();
			session.createQuery("update ExtraCode2Table o set o.unitFactor = 1").executeUpdate();
			session.createQuery("update ExtraCode3Table o set o.unitFactor = 1").executeUpdate();
			session.createQuery("update ExtraCode4Table o set o.unitFactor = 1").executeUpdate();
			session.createQuery("update ExtraCode5Table o set o.unitFactor = 1").executeUpdate();
			session.createQuery("update ExtraCode6Table o set o.unitFactor = 1").executeUpdate();
			session.createQuery("update ExtraCode7Table o set o.unitFactor = 1").executeUpdate();
			session.createQuery("update ExtraCode8Table o set o.unitFactor = 1").executeUpdate();
			session.createQuery("update ExtraCode9Table o set o.unitFactor = 1").executeUpdate();
			session.createQuery("update ExtraCode10Table o set o.unitFactor = 1").executeUpdate();
			session.createQuery("update ProjectWBSTable o set o.unitFactor = 1").executeUpdate();
			session.createQuery("update ProjectWBS2Table o set o.unitFactor = 1").executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.2.0");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.2.1"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.2.1...");
			session.createQuery("update AssemblyTable o set o.unit = 'EACH' where o.unit = 'UNIT.ASSEMBLY.EACH'").executeUpdate();
			session.createQuery("update SubcontractorTable o set o.unit = 'EACH' where o.unit = 'UNIT.SUBCONTRACTOR.EACH'").executeUpdate();
			session.createQuery("update MaterialTable o set o.unit = 'EACH' where o.unit = 'UNIT.MATERIAL.EACH'").executeUpdate();
			session.createQuery("update ConsumableTable o set o.unit = 'EACH' where o.unit = 'UNIT.CONSUMABLE.EACH'").executeUpdate();
			session.createQuery("update ParamItemTable o set o.unit = 'EACH' where o.unit = 'UNIT.PARAMITEM.EACH'").executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.2.1");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.2.3"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.2.3...");
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
			  Console.WriteLine("Schema update 1: OK");
			}
			catch (Exception exception)
			{
			  Console.Error.WriteLine("Schema update 1: " + exception.Message);
			}
			try
			{
			  SQLQuery sQLQuery = session.createSQLQuery("UPDATE LOCFACTOR SET ONLN = ONLINE WHERE ONLN = NULL");
			  sQLQuery.executeUpdate();
			  sQLQuery = session.createSQLQuery("UPDATE FIELDCUSTOM SET RSRC = RESOURCE WHERE RSRC = NULL");
			  sQLQuery.executeUpdate();
			  Console.WriteLine("Schema update 2: OK");
			}
			catch (Exception exception)
			{
			  Console.Error.WriteLine("Schema update 2: " + exception.Message);
			}
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.2.3");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.2.7"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.2.7...");
			session.createQuery("update ProjectUrlTable o set o.dbms = 0 where o.dbms is null").executeUpdate();
			session.createQuery("update ParamItemInputTable o set o.label = o.name where o.label is null").executeUpdate();
			session.createQuery("update FunctionTable o set o.language = 'EXPR' where o.language is null").executeUpdate();
			foreach (ProjectInfoTable projectInfoTable in session.createQuery("from ProjectInfoTable o where o.epsCode is null").list())
			{
			  if (projectInfoTable.ProjectEPSTable == null)
			  {
				session.delete(projectInfoTable);
				continue;
			  }
			  projectInfoTable.recalculate();
			  session.update(projectInfoTable);
			}
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.2.7");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.3.0"))
		{
		  fixBoqItemTable(paramBaseDBProperties, paramString, paramSessionInterface);
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.4.1"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.4.1...");
			Query query = session.createQuery("update ParamItemTable o set o.protectionType = :pType, o.password = :pswd, o.serialNumber = :snum where o.serialNumber is null");
			query.setParameter("pType", "NONE");
			query.setParameter("pswd", "");
			query.setParameter("snum", "");
			query.executeUpdate();
			query = session.createQuery("update FunctionTable o set o.protectionType = :pType, o.password = :pswd, o.serialNumber = :snum where o.serialNumber is null");
			query.setParameter("pType", "NONE");
			query.setParameter("pswd", "");
			query.setParameter("snum", "");
			query.executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.4.1");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.4.3"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.4.3...");
			session.createSQLQuery("update ASSEMBLY_MATERIAL SET FRATE = (FACTOR1*FACTOR2*LOCALFACTOR*EXCHANGERATE*(select distinct TOTALRATE from MATERIAL where ASSEMBLY_MATERIAL.MATERIALID = MATERIAL.MATERIALID))/DIVIDER where FRATE is NULL").executeUpdate();
			session.createSQLQuery("update ASSEMBLY_CONSUMABLE SET FRATE = (FACTOR1*FACTOR2*LOCALFACTOR*EXCHANGERATE*(select distinct RATE from CONSUMABLE where ASSEMBLY_CONSUMABLE.CONSUMABLEID = CONSUMABLE.CONSUMABLEID))/DIVIDER where FRATE is NULL").executeUpdate();
			session.createSQLQuery("update ASSEMBLY_LABOR SET FRATE = (FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*EXCHANGERATE*(select distinct TOTALRATE from LABOR where ASSEMBLY_LABOR.LABORID = LABOR.LABORID))/(select distinct PRODUCTIVITY from ASSEMBLY where ASSEMBLY_LABOR.ASSEMBLYID = ASSEMBLY.ASSEMBLYID) where FRATE is NULL").executeUpdate();
			session.createSQLQuery("update ASSEMBLY_LABOR SET FIKARATE = (FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*EXCHANGERATE*(select distinct IKA from LABOR where ASSEMBLY_LABOR.LABORID = LABOR.LABORID))/(select distinct PRODUCTIVITY from ASSEMBLY where ASSEMBLY_LABOR.ASSEMBLYID = ASSEMBLY.ASSEMBLYID) where FIKARATE is NULL").executeUpdate();
			session.createSQLQuery("update ASSEMBLY_EQUIPMENT SET FRATE = (FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*EXCHANGERATE*((select distinct TOTALRATE from EQUIPMENT where ASSEMBLY_EQUIPMENT.EQUIPMENTID = EQUIPMENT.EQUIPMENTID)+FUELRATE))/(select distinct PRODUCTIVITY from ASSEMBLY where ASSEMBLY_EQUIPMENT.ASSEMBLYID = ASSEMBLY.ASSEMBLYID) where FRATE is NULL").executeUpdate();
			session.createSQLQuery("update ASSEMBLY_EQUIPMENT SET FDEPRATE = (FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*EXCHANGERATE*((select distinct DEPRECIATIONRATE from EQUIPMENT where ASSEMBLY_EQUIPMENT.EQUIPMENTID = EQUIPMENT.EQUIPMENTID)))/(select distinct PRODUCTIVITY from ASSEMBLY where ASSEMBLY_EQUIPMENT.ASSEMBLYID = ASSEMBLY.ASSEMBLYID) where FDEPRATE is NULL").executeUpdate();
			session.createSQLQuery("update ASSEMBLY_EQUIPMENT SET FINALFUELRATE = (FUELRATE*FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*EXCHANGERATE)/(select distinct PRODUCTIVITY from ASSEMBLY where ASSEMBLY_EQUIPMENT.ASSEMBLYID = ASSEMBLY.ASSEMBLYID) where FINALFUELRATE is NULL").executeUpdate();
			session.createSQLQuery("update ASSEMBLY_SUBCONTRACTOR SET FRATE = (FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*EXCHANGERATE*(select distinct TOTALRATE from SUBCONTRACTOR where ASSEMBLY_SUBCONTRACTOR.SUBCONTRACTORID = SUBCONTRACTOR.SUBCONTRACTORID)) where FRATE is NULL").executeUpdate();
			session.createSQLQuery("update ASSEMBLY_SUBCONTRACTOR SET FIKARATE = (FACTOR1*FACTOR2*FACTOR3*LOCALFACTOR*EXCHANGERATE*(select distinct IKA from SUBCONTRACTOR where ASSEMBLY_SUBCONTRACTOR.SUBCONTRACTORID = SUBCONTRACTOR.SUBCONTRACTORID)) where FIKARATE is NULL").executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.4.3");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.4.5"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.4.5...");
			Query query = session.createQuery("update LayoutTable o set o.spanGroups = true, o.rowStripes = true, o.multiLines = false, o.showVerticalGrids = false, o.showHorizontalGrids = false, o.groupName = '', o.showAsTree = true, o.showRowHeader = false, o.showColumnSeparator = true, o.columnSeparatorColor = :sepColor, o.gridColor = :fontColor, o.fontLevel1Name = :fontName, o.fontLevel1Style = :l1Style, o.fontLevel1Size = :l1Size, o.fontLevel1Color = :fontColor, o.fontLevel1Undln = :fontUndln, o.level1BackColor = :bkColor, o.fontLevel2Name = :fontName, o.fontLevel2Style = :l2Style, o.fontLevel2Size = :l2Size, o.fontLevel2Color = :fontColor, o.fontLevel2Undln = :fontUndln, o.level2BackColor = :bkColor, o.fontLevel3Name = :fontName, o.fontLevel3Style = :l3Style, o.fontLevel3Size = :l3Size, o.fontLevel3Color = :fontColor, o.fontLevel3Undln = :fontUndln, o.level3BackColor = :bkColor, o.fontLevel4Name = :fontName, o.fontLevel4Style = :l4Style, o.fontLevel4Size = :l4Size, o.fontLevel4Color = :fontColor, o.fontLevel4Undln = :fontUndln, o.level4BackColor = :bkColor, o.fontLevel5Name = :fontName, o.fontLevel5Style = :l5Style, o.fontLevel5Size = :l5Size, o.fontLevel5Color = :fontColor, o.fontLevel5Undln = :fontUndln, o.level5BackColor = :bkColor, o.fontLevelNName = :fontName, o.fontLevelNStyle = :l5Style, o.fontLevelNSize = :l5Size, o.fontLevelNColor = :fontColor, o.fontLevelNUndln = :fontUndln, o.levelNBackColor = :bkColor, o.fontUnassignedName = :fontName, o.fontUnassignedSize = :l1Size, o.fontUnassignedStyle = :l1Style, o.fontUnassignedColor = :unColor, o.fontUnassignedUndln = :fontUndln, o.unassignedBackColor = :bkColor, o.fontLeafName = :fontName, o.fontLeafSize = :lfSize, o.fontLeafStyle = :lfStyle, o.fontLeafColor = :fontColor, o.fontLeafUndln = :fontUndln, o.leafBackColor = :bkColor,o.rowStripe1Color = :rowStripe1Color, o.rowStripe2Color = :rowStripe2Color");
			query.setString("fontName", "SansSerif");
			query.setString("fontColor", "0;0;0;");
			query.setString("sepColor", "0;0;0;");
			query.setString("bkColor", "255;255;255;");
			query.setBoolean("fontUndln", false);
			query.setInteger("l1Style", 1);
			query.setInteger("l1Size", 11);
			query.setInteger("l2Style", 3);
			query.setInteger("l2Size", 11);
			query.setInteger("l3Style", 1);
			query.setInteger("l3Size", 10);
			query.setInteger("l4Style", 3);
			query.setInteger("l4Size", 10);
			query.setInteger("l5Style", 2);
			query.setInteger("l5Size", 10);
			query.setInteger("lfStyle", 0);
			query.setInteger("lfSize", 10);
			query.setString("unColor", "230;0;0;");
			query.setString("rowStripe1Color", "241;241;241;");
			query.setString("rowStripe2Color", "251;251;251;");
			query.executeUpdate();
			query = session.createQuery("update LayoutTable o set o.rowStripe1Color = :rowStripe1Color, o.rowStripe2Color = :rowStripe2Color where o.type = 'boqitem'");
			query.setString("rowStripe1Color", "198;212;229;");
			query.setString("rowStripe2Color", "241;241;241;");
			query.executeUpdate();
			query = session.createQuery("update LayoutTable o set o.rowStripe1Color = :rowStripe1Color, o.rowStripe2Color = :rowStripe2Color where o.type = 'groupcode' or o.type = 'gekcode' or o.type = 'extracode1' or o.type = 'extracode2' or o.type = 'extracode3' or o.type = 'extracode4' or o.type = 'extracode5' or o.type = 'extracode6' or o.type = 'extracode7' or o.type = 'extracode8' or o.type = 'extracode9' ");
			query.setString("rowStripe1Color", "255;246;173;");
			query.setString("rowStripe2Color", "251;251;251;");
			query.executeUpdate();
			query = session.createQuery("update LayoutTable o set o.rowStripe1Color = :rowStripe1Color, o.rowStripe2Color = :rowStripe2Color where o.type = 'eps'");
			query.setString("rowStripe1Color", "160;240;160;");
			query.setString("rowStripe2Color", "251;251;251;");
			query.executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.4.5");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.5.0"))
		{
		  string str = paramBaseDBProperties.getProperty("projectdefaults.currencysymbol");
		  if (!string.ReferenceEquals(str, null) && str.IndexOf("₤", StringComparison.Ordinal) != -1)
		  {
			str = StringUtils.replaceAll(str, "₤", "£");
			paramBaseDBProperties.setProperty("projectdefaults.currencysymbol", str);
		  }
		  else if (!string.ReferenceEquals(str, null) && str.IndexOf("?", StringComparison.Ordinal) != -1)
		  {
			str = "£";
			paramBaseDBProperties.setProperty("projectdefaults.currencysymbol", str);
		  }
		  paramBaseDBProperties.setProperty("database.schema.version", "4.5.0");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.5.1"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.5.1...");
			session.createQuery("update ParamItemConceptualResourceTable o set o.laborRate = '0', o.laborIKA = '0', o.consumableRate = '0', o.equipmentReservationRate = '0', o.equipmentLubricatesRate = '0', o.equipmentTiresRate = '0', o.equipmentSparePartsRate = '0', o.equipmentDepreciationRate = '0', o.equipmentFuelRate = '0',o.equipmentFuelConsumption = '0', o.equipmentFuelType = 'OTHER'").executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.5.1");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.5.2"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.5.2...");
			if (paramSessionInterface.Dialect is org.hibernate.dialect.MySQLDialect)
			{
			  session.createSQLQuery("ALTER TABLE FNCTON_ARGUMENT MODIFY DEFVAL longtext").executeUpdate();
			}
			else if (paramSessionInterface.Dialect is org.hibernate.dialect.Oracle10gDialect)
			{
			  alterOracleTextColumn(session, "FNCTON_ARGUMENT", "DEFVAL");
			}
			else if (paramSessionInterface.Dialect is org.hibernate.dialect.SQLServerDialect)
			{
			  session.createSQLQuery("ALTER TABLE FNCTON_ARGUMENT ALTER COLUMN DEFVAL TEXT").executeUpdate();
			}
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.5.2");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.5.3"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.5.3...");
			Query query = session.createQuery("update ParamItemConceptualResourceTable o set o.notesConcatenation = :es, o.descriptionConcatenation = :es");
			query.setString("es", "T(\"\")");
			query.executeUpdate();
			query = session.createQuery("update ParamItemConceptualResourceTable o set o.customText1Equation = '', o.customText2Equation = '', o.customText3Equation = '', o.customText4Equation = '', o.customText5Equation = '', o.customText6Equation = '', o.customText7Equation = '', o.customText8Equation = '', o.customText9Equation = '', o.customText10Equation = '', o.customRate1Equation = '', o.customRate2Equation = '', o.customRate3Equation = '', o.customRate4Equation = '', o.customRate5Equation = '', o.customRate6Equation = '', o.customRate7Equation = '', o.customRate8Equation = '', o.customRate9Equation = '', o.customRate10Equation = '', o.customCumRate1Equation = '', o.customCumRate2Equation = '', o.customCumRate3Equation = '', o.customCumRate4Equation = '', o.customCumRate5Equation = ''");
			query.executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.5.3");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.5.7"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.5.7...");
			if (paramSessionInterface.Dialect is org.hibernate.dialect.MySQLDialect)
			{
			  session.createSQLQuery("ALTER TABLE PROJECTWBS MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE PROJECTWBS2 MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE GROUPCODE MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE GEKCODE MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EXTRACODE1 MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EXTRACODE2 MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EXTRACODE3 MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EXTRACODE4 MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EXTRACODE5 MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EXTRACODE6 MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EXTRACODE7 MODIFY TITLE longtext").executeUpdate();
			}
			else if (paramSessionInterface.Dialect is org.hibernate.dialect.Oracle10gDialect)
			{
			  alterOracleTextColumn(session, "PROJECTWBS", "TITLE");
			  alterOracleTextColumn(session, "PROJECTWBS2", "TITLE");
			  alterOracleTextColumn(session, "GROUPCODE", "TITLE");
			  alterOracleTextColumn(session, "GEKCODE", "TITLE");
			  alterOracleTextColumn(session, "EXTRACODE1", "TITLE");
			  alterOracleTextColumn(session, "EXTRACODE2", "TITLE");
			  alterOracleTextColumn(session, "EXTRACODE3", "TITLE");
			  alterOracleTextColumn(session, "EXTRACODE4", "TITLE");
			  alterOracleTextColumn(session, "EXTRACODE5", "TITLE");
			  alterOracleTextColumn(session, "EXTRACODE6", "TITLE");
			  alterOracleTextColumn(session, "EXTRACODE7", "TITLE");
			}
			else if (paramSessionInterface.Dialect is org.hibernate.dialect.SQLServerDialect)
			{
			  session.createSQLQuery("ALTER TABLE PROJECTWBS ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE PROJECTWBS2 ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE GROUPCODE ALTER COLUMN  TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE GEKCODE ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EXTRACODE1 ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EXTRACODE2 ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EXTRACODE3 ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EXTRACODE4 ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EXTRACODE5 ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EXTRACODE6 ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EXTRACODE7 ALTER COLUMN TITLE TEXT").executeUpdate();
			}
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.5.7");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.6.0"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.6.0...");
			session.createQuery("update AssemblyMaterialTable o set o.factor3 = 1/o.factor3 where o.factor3 != 0 and o.factor3 != 1").executeUpdate();
			session.createQuery("update AssemblyConsumableTable o set o.factor3 = 1/o.factor3 where o.factor3 != 0 and o.factor3 != 1").executeUpdate();
			session.createQuery("update AssemblyTable o set o.activityBased = true, o.unitEquipmentHours = o.unitManhours where o.activityBased is null").executeUpdate();
			session.createQuery("update FieldCustomizationTable o set o.formula = replace(cast(o.formula as string),:lineItemTxt,'')").setString("lineItemTxt", "+LINE_ITEM_TOTAL_RATE").executeUpdate();
			session.createQuery("update FieldCustomizationTable o set o.formula = replace(cast(o.formula as string),:lineItemTxt,'')").setString("lineItemTxt", "+LINE_ITEM_TOTAL_RATE+").executeUpdate();
			session.createQuery("update FieldCustomizationTable o set o.formula = replace(cast(o.formula as string),:lineItemTxt,'')").setString("lineItemTxt", "LINE_ITEM_TOTAL_RATE+").executeUpdate();
			session.createQuery("update AssemblyMaterialTable o set o.quantityPerUnit = 1 where o.quantityPerUnit is null").executeUpdate();
			session.createQuery("update AssemblyEquipmentTable o set o.quantityPerUnit = 1 where o.quantityPerUnit is null").executeUpdate();
			session.createQuery("update AssemblyLaborTable o set o.quantityPerUnit = 1 where o.quantityPerUnit is null").executeUpdate();
			session.createQuery("update AssemblySubcontractorTable o set o.quantityPerUnit = 1 where o.quantityPerUnit is null").executeUpdate();
			session.createQuery("update AssemblyConsumableTable o set o.quantityPerUnit = 1 where o.quantityPerUnit is null").executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.6.0");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.6.2"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.6.2...");
			session.createQuery("update ProjectWBSTable o set o.itemCode = o.groupCode where o.itemCode is null").executeUpdate();
			session.createQuery("update ProjectWBS2Table o set o.itemCode = o.groupCode where o.itemCode is null").executeUpdate();
			session.createQuery("update FieldCustomizationTable o set o.resourceType = 'boqitem' where o.resourceType is null").executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.6.2");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.6.3"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.6.3...");
			System.Collections.IEnumerator iterator = session.createQuery("from LayoutTable o where o.type ='boqitem'").iterate();
			while (iterator.MoveNext())
			{
			  LayoutTable layoutTable = (LayoutTable)iterator.Current;
			  LayoutPanelTable layoutPanelTable = (LayoutPanelTable)layoutTable.LayoutColumnList[0];
			  int[] arrayOfInt1 = correctUpdatedArray1(StringUtils.getIntArrayFromString(layoutPanelTable.GroupedColumns));
			  int[] arrayOfInt2 = correctUpdatedArray1(StringUtils.getIntArrayFromString(layoutPanelTable.LockedColumns));
			  layoutPanelTable.GroupedColumns = StringUtils.getStringFromArray(arrayOfInt1);
			  layoutPanelTable.LockedColumns = StringUtils.getStringFromArray(arrayOfInt2);
			  session.update(layoutPanelTable);
			}
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.6.3");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.6.4"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.6.4...");
			session.createQuery("update LaborTable o set o.conceptual = false where o.conceptual is null").executeUpdate();
			session.createQuery("update ConsumableTable o set o.conceptual = false where o.conceptual is null").executeUpdate();
			session.createQuery("update EquipmentTable o set o.conceptual = false where o.conceptual is null").executeUpdate();
			session.createQuery("update LayoutPanelTable o set o.visible = true where o.visible is null").executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.6.4");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.6.5"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.6.5...");
			session.createQuery("update TakeoffAreaTable o set o.connectedLine = false where o.connectedLine is null").executeUpdate();
			session.createQuery("update TakeoffAreaTable o set o.bezierTension = 1 where o.bezierTension is null").executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.6.5");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.6.6"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.6.6...");
			session.createQuery("delete from FieldCustomizationTable o where o.name like 'estim%TotalCost' or o.name like 'estim%Rate' or o.name like 'quoted%TotalCost' or o.name like 'quoted%Rate'").executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.6.6");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.6.7"))
		{
		  Console.WriteLine("UPDATING DATABASE SCHEMA 4.6.7...");
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			if (paramSessionInterface.Dialect is org.hibernate.dialect.MySQLDialect)
			{
			  session.createSQLQuery("ALTER TABLE PARAMINPUT MODIFY STOVAL longtext").executeUpdate();
			}
			else if (paramSessionInterface.Dialect is org.hibernate.dialect.Oracle10gDialect)
			{
			  alterOracleTextColumn(session, "PARAMINPUT", "STOVAL");
			}
			else if (paramSessionInterface.Dialect is org.hibernate.dialect.SQLServerDialect)
			{
			  session.createSQLQuery("ALTER TABLE PARAMINPUT ALTER COLUMN STOVAL TEXT").executeUpdate();
			}
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.6.7");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.7.0"))
		{
		  Console.WriteLine("UPDATING DATABASE SCHEMA 4.7.0...");
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createQuery("update ProjectUserTable o set o.variablesAdmin = false, o.variablesUser = false where o.variablesAdmin is null").executeUpdate();
			Console.WriteLine("DONE");
			transaction.commit();
			paramBaseDBProperties.setProperty("database.schema.version", "4.7.0");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.7.4"))
		{
		  Console.WriteLine("UPDATING DATABASE SCHEMA 4.7.4...");
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			System.Collections.IList list = session.createQuery("from ProjectUrlTable o where o.dbms != 0").list();
			foreach (ProjectUrlTable projectUrlTable in list)
			{
			  string str1 = CryptUtil.Instance.decryptHexString(projectUrlTable.Password);
			  string str2 = projectUrlTable.Username;
			  projectUrlTable.Password = AddOnUtil.Instance.encryptHexString(str1);
			  projectUrlTable.Username = CryptUtil.Instance.encryptHexString(str2);
			  session.update(projectUrlTable);
			}
			Console.WriteLine("DONE");
			transaction.commit();
			paramBaseDBProperties.setProperty("database.schema.version", "4.7.4");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.7.6"))
		{
		  Console.WriteLine("UPDATING DATABASE SCHEMA 4.7.6...");
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Query query = session.createQuery("update AssemblyTable as o set o.puGroupCodeFactor = :zero, o.puGekCodeFactor = :zero, o.puExtraCode1Factor = :zero, o.puExtraCode2Factor = :zero, o.puExtraCode3Factor = :zero, o.puExtraCode4Factor = :zero,o.puExtraCode5Factor = :zero, o.puExtraCode6Factor = :zero, o.puExtraCode7Factor = :zero where o.puGroupCodeFactor is null");
			query.setBigDecimal("zero", BigDecimalMath.ZERO);
			query.executeUpdate();
			session.createQuery("update AssemblyTable as o set o.itemCode = o.publishedRevisionCode where o.itemCode is null").executeUpdate();
			session.createQuery("update EquipmentTable as o set o.itemCode = '' where o.itemCode is null").executeUpdate();
			session.createQuery("update LaborTable as o set o.itemCode = '' where o.itemCode is null").executeUpdate();
			session.createQuery("update MaterialTable as o set o.itemCode = '' where o.itemCode is null").executeUpdate();
			session.createQuery("update SupplierTable as o set o.itemCode = '' where o.itemCode is null").executeUpdate();
			session.createQuery("update ConsumableTable as o set o.itemCode = '' where o.itemCode is null").executeUpdate();
			session.createQuery("update ParamItemTable as o set o.itemCode = '' where o.itemCode is null").executeUpdate();
			fixItemCodeLayouts(session);
			Console.WriteLine("DONE");
			transaction.commit();
			paramBaseDBProperties.setProperty("database.schema.version", "4.7.6");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.7.7"))
		{
		  Console.WriteLine("UPDATING DATABASE SCHEMA 4.7.7...");
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Query query = session.createQuery("update AssemblyTable as o set o.customRate1 = :zero, o.customRate2 = :zero, o.customRate3 = :zero, o.customRate4 = :zero, o.customRate5 = :zero, o.customRate6 = :zero,o.customRate7 = :zero, o.customRate8 = :zero, o.customRate9 = :zero, o.customRate10 = :zero where o.customRate10 is null");
			query.setBigDecimal("zero", BigDecimalMath.ZERO);
			query.executeUpdate();
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.7.7");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.7.8"))
		{
		  Console.WriteLine("UPDATING DATABASE SCHEMA 4.7.8...");
		  System.Collections.IEnumerator iterator = paramSessionInterface.Configuration.ClassMappings;
		  Session session = paramSessionInterface.currentSession();
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
			  Query query = ProjectSchemaUpdateUtil.makeTextUpdateQuery(session, persistentClass, (Property)iterator1.Current);
			  if (query != null)
			  {
				query.executeUpdate();
			  }
			}
		  }
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "4.7.8");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.7.9"))
		{
		  Console.WriteLine("UPDATING DATABASE SCHEMA 4.7.9...");
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			if (paramSessionInterface.Dialect is org.hibernate.dialect.MySQLDialect)
			{
			  session.createSQLQuery("ALTER TABLE ASSEMBLY MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE MATERIAL MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE SUBCONTRACTOR MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE CONSUMABLE MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EQUIPMENT MODIFY TITLE longtext").executeUpdate();
			  session.createSQLQuery("ALTER TABLE LABOR MODIFY TITLE longtext").executeUpdate();
			}
			else if (paramSessionInterface.Dialect is org.hibernate.dialect.Oracle10gDialect)
			{
			  alterOracleTextColumn(session, "ASSEMBLY", "TITLE");
			  alterOracleTextColumn(session, "MATERIAL", "TITLE");
			  alterOracleTextColumn(session, "SUBCONTRACTOR", "TITLE");
			  alterOracleTextColumn(session, "CONSUMABLE", "TITLE");
			  alterOracleTextColumn(session, "EQUIPMENT", "TITLE");
			  alterOracleTextColumn(session, "LABOR", "TITLE");
			}
			else if (paramSessionInterface.Dialect is org.hibernate.dialect.SQLServerDialect)
			{
			  session.createSQLQuery("ALTER TABLE ASSEMBLY ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE MATERIAL ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE SUBCONTRACTOR ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE CONSUMABLE ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE EQUIPMENT ALTER COLUMN TITLE TEXT").executeUpdate();
			  session.createSQLQuery("ALTER TABLE LABOR ALTER COLUMN TITLE TEXT").executeUpdate();
			}
			transaction.commit();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.7.9");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.8.0"))
		{
		  Console.WriteLine("UPDATING DATABASE SCHEMA 4.8.0...");
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update ParamItemConceptualResourceTable as o set o.customText11Equation = :zero, o.customText12Equation = :zero, o.customText13Equation = :zero, o.customText14Equation = :zero, o.customText15Equation = :zero, o.customText16Equation = :zero,o.customText17Equation = :zero, o.customText18Equation = :zero, o.customText19Equation = :zero, o.customText20Equation = :zero where o.customText11Equation is null");
		  query.setString("zero", "");
		  query.executeUpdate();
		  transaction.commit();
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "4.8.0");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.8.1"))
		{
		  Console.WriteLine("UPDATING DATABASE SCHEMA 4.8.1...");
		  Session session = paramSessionInterface.currentSession();
		  if (paramSessionInterface.Dialect is org.hibernate.dialect.SQLServerDialect)
		  {
			System.Collections.IEnumerator iterator = paramSessionInterface.Configuration.ClassMappings;
			while (iterator.MoveNext())
			{
			  PersistentClass persistentClass = (PersistentClass)iterator.Current;
			  ProjectSchemaUpdateUtil.alterTextToVarCharMax(session, persistentClass);
			}
		  }
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "4.8.1");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.8.2"))
		{
		  Console.WriteLine("UPDATING DATABASE SCHEMA 4.8.2...");
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update AssemblyTable o set o.customRate11 = 0, o.customRate12 = 0, o.customRate13 = 0, o.customRate14 = 0, o.customRate15 = 0 where o.customRate15 is null");
		  query.executeUpdate();
		  query = session.createQuery("update ParamItemConceptualResourceTable o set o.customRate11Equation = '', o.customRate12Equation = '', o.customRate13Equation = '', o.customRate14Equation = '', o.customRate15Equation = '', o.customRate6Equation = '', o.customRate7Equation = '', o.customRate8Equation = '', o.customRate9Equation = '', o.customRate10Equation = '', o.customCumRate6Equation = '', o.customCumRate7Equation = '', o.customCumRate8Equation = '', o.customCumRate9Equation = '', o.customCumRate10Equation = '' where o.customRate11Equation is null");
		  query.executeUpdate();
		  query = session.createQuery("update ParamItemQueryResourceTable o set o.customRate11Equation = '', o.customRate12Equation = '', o.customRate13Equation = '', o.customRate14Equation = '', o.customRate15Equation = '', o.customRate6Equation = '', o.customRate7Equation = '', o.customRate8Equation = '', o.customRate9Equation = '', o.customRate10Equation = '', o.customCumRate6Equation = '', o.customCumRate7Equation = '', o.customCumRate8Equation = '', o.customCumRate9Equation = '', o.customCumRate10Equation = '' where o.customRate11Equation is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "4.8.2");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.8.3"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update ReportDefinitionTable o set o.multiUserReport = false where o.multiUserReport is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "4.8.3");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.8.4"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update ParamItemTable o set o.multUnitQty = true where o.multUnitQty is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "4.8.4");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "5.0.1"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update ParamItemTable o set o.titleFormula = '' where o.titleFormula is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "5.0.1");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "5.0.2"))
		{
		  Session session = paramSessionInterface.currentSession();
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
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "5.0.2");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "5.0.3"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update ReportDefinitionTable o set o.online = false where o.online is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "5.0.3");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "5.0.4"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update LayoutTable o set o.layoutUserAndRoles ='' where o.layoutUserAndRoles is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "5.0.4");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "5.0.5"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update RateBuildUpColumnsTable o set o.applyToEveryResource = false where o.applyToEveryResource is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "5.0.5");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "5.0.6"))
		{
		  try
		  {
			Session session = paramSessionInterface.currentSession();
			if (paramSessionInterface.Dialect is org.hibernate.dialect.SQLServerDialect)
			{
			  try
			  {
				Transaction transaction = session.beginTransaction();
				SQLQuery sQLQuery = session.createSQLQuery("ALTER TABLE PRINCIPALS ADD COLOR VARCHAR(256) NULL");
				sQLQuery.executeUpdate();
				transaction.commit();
			  }
			  catch (Exception)
			  {
				Console.WriteLine("Could not alter COLOR to PRINCIPALS TABLE");
			  }
			}
			paramSessionInterface.closeSession();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "5.0.6");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		}
		if (StringUtils.isOlderVersionFrom(paramString, "5.0.7"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update ProjectUrlTable o set o.frozen = false where o.frozen is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "5.0.7");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "5.1.0"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update SubcontractorTable o set o.subMaterialRate = 0 where o.subMaterialRate is null");
		  query.executeUpdate();
		  query = session.createQuery("update ProjectInfoTable o set \to.customCumRate1 = 0, \to.customCumRate2 = 0, \to.customCumRate3 = 0, \to.customCumRate4 = 0, \to.customCumRate5 = 0, \to.customCumRate6 = 0, \to.customCumRate7 = 0, \to.customCumRate8 = 0, \to.customCumRate9 = 0, \to.customCumRate10 = 0 where o.customCumRate1 is null");
		  query.executeUpdate();
		  query = session.createQuery("update ProjectInfoTable o set \to.equipmentTotalCost = 0, \to.subcontractorTotalCost = 0, \to.laborTotalCost = 0, \to.materialTotalCost = 0, \to.consumableTotalCost = 0, \to.laborManhours = 0, \to.equipmentHours = 0 where o.equipmentHours is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "5.1.0");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.1.0"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update LayoutTable o set o.zoom = 100 where o.zoom is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "6.1.0");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.1.1"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update ProjectUrlTable o set o.tablePrefix = '' where o.tablePrefix is null ");
		  query.executeUpdate();
		  query = session.createQuery("update ProjectUrlTable o set o.createsNewDatabases = true where o.createsNewDatabases is null ");
		  query.executeUpdate();
		  transaction.commit();
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "6.1.1");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.1.4"))
		{
		  Session session = paramSessionInterface.currentSession();
		  try
		  {
			session.createQuery("update ProjectVariableTable set pushField = '' where pushField is null").executeUpdate();
			session.createQuery("update ProjectInfoTable o set o.customEpsRate1 = 0, o.customEpsRate2 = 0, o.customEpsRate3 = 0, o.customEpsRate4 = 0, o.customEpsRate5 = 0, o.customEpsRate6 = 0, o.customEpsRate7 = 0, o.customEpsRate8 = 0, o.customEpsRate9 = 0, o.customEpsRate10 = 0, o.customEpsText1 = '', o.customEpsText2 = '', o.customEpsText3 = '', o.customEpsText4 = '', o.customEpsText5 = '', o.customEpsText6 = '', o.customEpsText7 = '', o.customEpsText8 = '', o.customEpsText9 = '', o.customEpsText10 = '' where o.customEpsRate10 is null").executeUpdate();
			if (paramSessionInterface.Dialect is org.hibernate.dialect.SQLServerDialect)
			{
			  try
			  {
				session.createSQLQuery("ALTER TABLE PRINCIPALS ADD AUTHTYPE VARCHAR(256) NULL").executeUpdate();
			  }
			  catch (Exception exception)
			  {
				Console.WriteLine(exception.ToString());
				Console.Write(exception.StackTrace);
			  }
			  try
			  {
				session.createSQLQuery("ALTER TABLE PRINCIPALS ADD ENBL BIT").executeUpdate();
			  }
			  catch (Exception exception)
			  {
				Console.WriteLine(exception.ToString());
				Console.Write(exception.StackTrace);
			  }
			  try
			  {
				session.createSQLQuery("update PRINCIPALS set AUTHTYPE = 'LOCAL' where AUTHTYPE is null").executeUpdate();
			  }
			  catch (Exception exception)
			  {
				Console.WriteLine(exception.ToString());
				Console.Write(exception.StackTrace);
			  }
			  try
			  {
				session.createSQLQuery("update PRINCIPALS set ENBL = 1 where ENBL IS NULL").executeUpdate();
			  }
			  catch (Exception exception)
			  {
				Console.WriteLine(exception.ToString());
				Console.Write(exception.StackTrace);
			  }
			}
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "6.1.4");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.1.5"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update ParamItemQueryResourceTable o set o.type = 0, o.jsonUrl = '' where o.jsonUrl is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "6.1.5");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.0"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  session.createQuery("update LayoutTable as o set o.selectedGroupCode = 'eps', o.visibTabs = 'eps' where o.type = 'eps' and (o.visibTabs='notes' or o.visibTabs='') and (o.selectedGroupCode = 'eps' or o.selectedGroupCode = '') ").executeUpdate();
		  session.createQuery("update ProjectInfoTable as o set o.customEpsText11 = '', o.customEpsText12 = '', o.customEpsText13 = '', o.customEpsText14 = '', o.customEpsText15 = '', o.customEpsText16 = '', o.customEpsText17 = '', o.customEpsText18 = '', o.customEpsText19 = '', o.customEpsText20 = '' where o.customEpsText11 is null").executeUpdate();
		  transaction.commit();
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "6.2.0");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.1"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  session.createSQLQuery("ALTER TABLE ASSEMBLY ALTER COLUMN NOTES VARCHAR(MAX)").executeUpdate();
		  session.createSQLQuery("ALTER TABLE GROUPCODE ALTER COLUMN NOTES VARCHAR(MAX)").executeUpdate();
		  transaction.commit();
		  paramSessionInterface.closeSession();
		  paramBaseDBProperties.setProperty("database.schema.version", "6.2.1");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.2"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  Query query = session.createQuery("update ProjectInfoTable as o set o.customCumRate11 = 0, o.customCumRate12 = 0, o.customCumRate13 = 0, o.customCumRate14 = 0, o.customCumRate15 = 0, o.customCumRate16 = 0, o.customCumRate17 = 0, o.customCumRate18 = 0, o.customCumRate19 = 0, o.customCumRate20 = 0 where o.customCumRate11 is null");
		  query.executeUpdate();
		  query = session.createQuery("update AssemblyTable o set o.customRate16 = 0, o.customRate17 = 0, o.customRate18 = 0, o.customRate19 = 0, o.customRate20 = 0 where o.customRate16 is null");
		  query.executeUpdate();
		  query = session.createQuery("update AssemblyTable o set o.customText21 = '', o.customText22 = '', o.customText23 = '', o.customText24 = '', o.customText25 = '' where o.customText21 is null");
		  query.executeUpdate();
		  query = session.createQuery("update ParamItemConceptualResourceTable o set o.customRate16Equation = '', o.customRate17Equation = '', o.customRate18Equation = '', o.customRate19Equation = '', o.customRate20Equation = '' where o.customRate16Equation is null");
		  query.executeUpdate();
		  query = session.createQuery("update ParamItemConceptualResourceTable o set o.customText21Equation = '', o.customText22Equation = '', o.customText23Equation = '', o.customText24Equation = '', o.customText25Equation = '' where o.customText21Equation is null");
		  query.executeUpdate();
		  query = session.createQuery("update ParamItemConceptualResourceTable o set o.customCumRate11Equation = '', o.customCumRate12Equation = '', o.customCumRate13Equation = '', o.customCumRate14Equation = '', o.customCumRate15Equation = '', o.customCumRate16Equation = '', o.customCumRate17Equation = '', o.customCumRate18Equation = '', o.customCumRate19Equation = '', o.customCumRate20Equation = '' where o.customCumRate11Equation is null");
		  query.executeUpdate();
		  query = session.createQuery("update ParamItemQueryResourceTable o set o.customRate16Equation = '', o.customRate17Equation = '', o.customRate18Equation = '', o.customRate19Equation = '', o.customRate20Equation = '' where o.customRate16Equation is null");
		  query.executeUpdate();
		  query = session.createQuery("update ParamItemQueryResourceTable o set o.customText21Equation = '', o.customText22Equation = '', o.customText23Equation = '', o.customText24Equation = '', o.customText25Equation = '' where o.customText21Equation is null");
		  query.executeUpdate();
		  query = session.createQuery("update ParamItemQueryResourceTable o set o.customCumRate11Equation = '', o.customCumRate12Equation = '', o.customCumRate13Equation = '', o.customCumRate14Equation = '', o.customCumRate15Equation = '', o.customCumRate16Equation = '', o.customCumRate17Equation = '', o.customCumRate18Equation = '', o.customCumRate19Equation = '', o.customCumRate20Equation = '' where o.customCumRate11Equation is null");
		  query.executeUpdate();
		  transaction.commit();
		  paramSessionInterface.closeSession();
		  paramBaseDBProperties.setProperty("database.schema.version", "6.2.2");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.3"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  SQLQuery sQLQuery = session.createSQLQuery("select PRINCIPALID from ROLES where ROLE ='CESUserAdmin' AND ROLEGROUP = 'Roles'");
		  System.Collections.IList list = sQLQuery.list();
		  if (list.Count == 0)
		  {
			SQLQuery sQLQuery1 = session.createSQLQuery("select PRINCIPALID from ROLES where ROLE ='CESAdmin' AND ROLEGROUP = 'Roles'");
			System.Collections.IList list1 = sQLQuery1.list();
			foreach (string str in list1)
			{
			  System.Guid uUID = System.Guid.randomUUID();
			  session.createSQLQuery("insert into ROLES VALUES ('" + uUID.ToString() + "','" + str + "','CESUserAdmin','Roles') ").executeUpdate();
			}
		  }
		  transaction.commit();
		  paramSessionInterface.closeSession();
		  paramBaseDBProperties.setProperty("database.schema.version", "6.2.3");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.4"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE PROJECTINFO SET DEFREV = '' WHERE DEFREV IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE PRJINFO SET PRJINFO.DEFREV = PRJURL.RVSON FROM PROJECTINFO AS PRJINFO INNER JOIN PROJECTURL AS PRJURL ON PRJINFO.PROJECTINFOID = PRJURL.PROJECTINFOID WHERE PRJURL.DEFREV = 1").executeUpdate();
			session.createSQLQuery("UPDATE PROJECTURL SET DESCRIPTION = '' WHERE DESCRIPTION IS NULL").executeUpdate();
			System.Collections.IList list = session.createQuery("select distinct o.databaseName from ProjectUrlTable as o where o.dbms = :dbms").setParameter("dbms", Convert.ToInt32(ProjectServerDBUtil.SQLSERVER_DBMS)).list();
			foreach (string str in list)
			{
			  try
			  {
				session.createSQLQuery("UPDATE URLTABLE SET URLTABLE.DESCRIPTION = PROPTABLE.PVAL FROM PROJECTURL AS URLTABLE INNER JOIN " + str + ".dbo.PRJPROP AS PROPTABLE ON URLTABLE.PROJECTURLID = PROPTABLE.PRJID WHERE PROPTABLE.PKEY = 'project.description'").executeUpdate();
			  }
			  catch (Exception)
			  {
			  }
			}
			transaction.commit();
			paramSessionInterface.closeSession();
			paramBaseDBProperties.setProperty("database.schema.version", "6.2.4");
			Console.WriteLine("Master Database Updated from version 6.2.3 to version 6.2.4 successfully!!");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
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
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.6"))
		{
		  Console.WriteLine("UPDATING DATABASE SCHEMA 6.2.6...");
		  Session session = paramSessionInterface.currentSession();
		  if (paramSessionInterface.Dialect is org.hibernate.dialect.SQLServerDialect)
		  {
			System.Collections.IEnumerator iterator = paramSessionInterface.Configuration.ClassMappings;
			while (iterator.MoveNext())
			{
			  PersistentClass persistentClass = (PersistentClass)iterator.Current;
			  paramSessionInterface.currentSession().beginTransaction();
			  ProjectSchemaUpdateUtil.alterVarCharMaxToNVarCharMax(paramSessionInterface.currentSession(), persistentClass);
			  paramSessionInterface.currentSession().Transaction.commit();
			}
			paramSessionInterface.closeSession();
			iterator = paramSessionInterface.Configuration.ClassMappings;
			while (iterator.MoveNext())
			{
			  PersistentClass persistentClass = (PersistentClass)iterator.Current;
			  paramSessionInterface.currentSession().beginTransaction();
			  ProjectSchemaUpdateUtil.alterVarChar255ToNVarChar255(paramSessionInterface, persistentClass);
			  paramSessionInterface.currentSession().Transaction.commit();
			}
		  }
		  paramSessionInterface.closeSession();
		  Console.WriteLine("DONE");
		  paramBaseDBProperties.setProperty("database.schema.version", "6.2.6");
		  paramBaseDBProperties.storeDBProperties();
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.8"))
		{
		  Console.WriteLine("UPDATING DATABASE SCHEMA 6.2.8...");
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			System.Collections.IList list = session.createSQLQuery("SELECT k.LID as LID FROM (SELECT l.LAYOUTCID LID, MAX(p.LAYOUTCPANELCOUNT) numOfPanels FROM LAYOUTCPANEL p LEFT JOIN LAYOUTC l ON p.LAYOUTCID = l.LAYOUTCID where l.TYPE = 'boqitem' GROUP BY l.LAYOUTCID) k WHERE k.numOfPanels <= 4").addScalar("LID", LongType.INSTANCE).list();
			if (list.Count > 0)
			{
			  System.Collections.IList list1 = session.createQuery("from LayoutTable as o where o.layoutId in (:ids)").setParameterList("ids", list).list();
			  foreach (LayoutTable layoutTable in list1)
			  {
				LayoutPanelTable layoutPanelTable = new LayoutPanelTable();
				layoutPanelTable.ColumnsPreference = "10\t1143\tparamitemId\t0\t2147483647\t15\t75\t75\titemCode\t0\t2147483647\t15\t152\t152\tgroupName\t1\t2147483647\t15\t75\t75\ttitle\t2\t2147483647\t15\t297\t297\ticon\t3\t2147483647\t15\t91\t91\tunit\t4\t2147483647\t15\t75\t75\tmultUnitQty\t5\t2147483647\t15\t153\t153\tsampleRate\t6\t2147483647\t15\t75\t75\tprotectionType\t7\t2147483647\t15\t75\t75\tcreateDate\t8\t2147483647\t15\t150\t150\t\t\t17\t27\t0\tparamitemId\titemCode\ttitle\ttitleFormula\tcostModel\tgroupName\ticon\tunit\tmultUnitQty\tsampleRate\tprotectionType\tnotes\tdescription\teditorId\tlastUpdate\tcreateUserId\tcreateDate\tgroupCode\tgekCode\textraCode1\textraCode2\textraCode3\textraCode4\textraCode5\textraCode6\textraCode7\t26\t0\tparamitemId\titemCode\ttitle\tcostModel\tgroupName\ticon\tunit\tmultUnitQty\tsampleRate\tprotectionType\tnotes\tdescription\teditorId\tlastUpdate\tcreateUserId\tcreateDate\tgroupCode\tgekCode\textraCode1\textraCode2\textraCode3\textraCode4\textraCode5\textraCode6\textraCode7\t25\t0\tparamitemId\titemCode\ttitle\tgroupName\ticon\tunit\tmultUnitQty\tsampleRate\tprotectionType\tnotes\tdescription\teditorId\tlastUpdate\tcreateUserId\tcreateDate\tgroupCode\tgekCode\textraCode1\textraCode2\textraCode3\textraCode4\textraCode5\textraCode6\textraCode7\t24\t0\tparamitemId\titemCode\ttitle\tgroupName\ticon\tunit\tmultUnitQty\tsampleRate\tprotectionType\tnotes\tdescription\teditorId\tlastUpdate\tcreateUserId\tcreateDate\tgekCode\textraCode1\textraCode2\textraCode3\textraCode4\textraCode5\textraCode6\textraCode7\t23\t0\tparamitemId\titemCode\ttitle\tgroupName\ticon\tunit\tmultUnitQty\tsampleRate\tprotectionType\tnotes\tdescription\teditorId\tlastUpdate\tcreateUserId\tcreateDate\textraCode1\textraCode2\textraCode3\textraCode4\textraCode5\textraCode6\textraCode7\t22\t0\tparamitemId\titemCode\ttitle\tgroupName\ticon\tunit\tmultUnitQty\tsampleRate\tprotectionType\tnotes\tdescription\teditorId\tlastUpdate\tcreateUserId\tcreateDate\textraCode2\textraCode3\textraCode4\textraCode5\textraCode6\textraCode7\t21\t0\tparamitemId\titemCode\ttitle\tgroupName\ticon\tunit\tmultUnitQty\tsampleRate\tprotectionType\tnotes\tdescription\teditorId\tlastUpdate\tcreateUserId\tcreateDate\textraCode3\textraCode4\textraCode5\textraCode6\textraCode7\t20\t0\tparamitemId\titemCode\ttitle\tgroupName\ticon\tunit\tmultUnitQty\tsampleRate\tprotectionType\tnotes\tdescription\teditorId\tlastUpdate\tcreateUserId\tcreateDate\textraCode4\textraCode5\textraCode6\textraCode7\t19\t0\tparamitemId\titemCode\ttitle\tgroupName\ticon\tunit\tmultUnitQty\tsampleRate\tprotectionType\tnotes\tdescription\teditorId\tlastUpdate\tcreateUserId\tcreateDate\textraCode5\textraCode6\textraCode7\t18\t0\tparamitemId\titemCode\ttitle\tgroupName\ticon\tunit\tmultUnitQty\tsampleRate\tprotectionType\tnotes\tdescription\teditorId\tlastUpdate\tcreateUserId\tcreateDate\textraCode6\textraCode7\t17\t0\tparamitemId\titemCode\ttitle\tgroupName\ticon\tunit\tmultUnitQty\tsampleRate\tprotectionType\tnotes\tdescription\teditorId\tlastUpdate\tcreateUserId\tcreateDate\textraCode7\t16\t0\tparamitemId\titemCode\ttitle\tgroupName\ticon\tunit\tmultUnitQty\tsampleRate\tprotectionType\tnotes\tdescription\teditorId\tlastUpdate\tcreateUserId\tcreateDate\t15\t0\tparamitemId\titemCode\ttitle\tgroupName\ticon\tunit\tmultUnitQty\tsampleRate\tprotectionType\tnotes\tdescription\teditorId\tcreateUserId\tcreateDate\t14\t0\tparamitemId\titemCode\ttitle\tgroupName\ticon\tunit\tmultUnitQty\tsampleRate\tprotectionType\tnotes\tdescription\teditorId\tcreateDate\t13\t0\tparamitemId\titemCode\ttitle\tgroupName\ticon\tunit\tmultUnitQty\tsampleRate\tprotectionType\tnotes\tdescription\tcreateDate\t12\t0\tparamitemId\titemCode\ttitle\tgroupName\ticon\tunit\tmultUnitQty\tsampleRate\tprotectionType\tnotes\tcreateDate\t11\t1\tparamitemId\titemCode\tgroupName\ttitle\ticon\tunit\tmultUnitQty\tsampleRate\tprotectionType\tcreateDate";
				layoutPanelTable.HeaderRowHeight = Convert.ToInt32(21);
				layoutPanelTable.HeaderAutoresize = true;
				layoutPanelTable.LockedColumns = "0";
				layoutPanelTable.FiltersPreference = "1\t0\t0\t0\t\t\t";
				layoutPanelTable.Visible = true;
				layoutPanelTable.EnableFilters = true;
				layoutPanelTable.SortablePreference = "0";
				long? long = (long?)session.save(layoutPanelTable);
				layoutPanelTable = (LayoutPanelTable)session.load(typeof(LayoutPanelTable), long);
				List<object> arrayList = new List<object>();
				foreach (LayoutPanelTable layoutPanelTable1 in layoutTable.LayoutColumnList)
				{
				  arrayList.Add((LayoutPanelTable)layoutPanelTable1.clone());
				}
				arrayList.Insert(1, layoutPanelTable);
				layoutTable.LayoutColumnList.Clear();
				session.update(layoutTable);
				foreach (LayoutPanelTable layoutPanelTable1 in arrayList)
				{
				  long? long1 = (long?)session.save(layoutPanelTable1);
				  layoutPanelTable1 = (LayoutPanelTable)session.load(typeof(LayoutPanelTable), long1);
				  layoutTable.LayoutColumnList.Add(layoutPanelTable1);
				}
				session.update(layoutTable);
			  }
			}
			transaction.commit();
		  }
		  catch (Exception exception)
		  {
			if (transaction.Active)
			{
			  transaction.rollback();
			}
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		  paramBaseDBProperties.setProperty("database.schema.version", "6.2.8");
		  paramBaseDBProperties.storeDBProperties();
		  Console.WriteLine("DONE");
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.9"))
		{
		  Console.WriteLine("UPDATING DATABASE SCHEMA TO 6.2.9....");
		  paramBaseDBProperties.setProperty("database.schema.version", "6.2.9");
		  paramBaseDBProperties.storeDBProperties();
		  Console.WriteLine("DONE");
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.10"))
		{
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA TO 6.2.10....");
			Session session = paramSessionInterface.currentSession();
			if (paramSessionInterface.Dialect is org.hibernate.dialect.SQLServerDialect)
			{
			  System.Collections.IEnumerator iterator = paramSessionInterface.Configuration.ClassMappings;
			  while (iterator.MoveNext())
			  {
				PersistentClass persistentClass = (PersistentClass)iterator.Current;
				paramSessionInterface.currentSession().beginTransaction();
				ProjectSchemaUpdateUtil.alterVarCharMaxToNVarCharMax(paramSessionInterface.currentSession(), persistentClass);
				paramSessionInterface.currentSession().Transaction.commit();
			  }
			  paramSessionInterface.closeSession();
			  iterator = paramSessionInterface.Configuration.ClassMappings;
			  while (iterator.MoveNext())
			  {
				PersistentClass persistentClass = (PersistentClass)iterator.Current;
				paramSessionInterface.currentSession().beginTransaction();
				ProjectSchemaUpdateUtil.alterVarChar255ToNVarChar255(paramSessionInterface, persistentClass);
				paramSessionInterface.currentSession().Transaction.commit();
			  }
			}
			paramSessionInterface.closeSession();
			paramSessionInterface.currentSession().createSQLQuery("BEGIN TRAN;\nALTER TABLE WSFILE ALTER COLUMN ACTSHEETS NVARCHAR(MAX);\nCOMMIT;").executeUpdate();
			paramSessionInterface.closeSession();
			paramBaseDBProperties.setProperty("database.schema.version", "6.2.10");
			paramBaseDBProperties.storeDBProperties();
			Console.WriteLine("UPDATING DATABASE SCHEMA TO 6.2.10 SUCCESSFULLY COMPLETED.");
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.11"))
		{
		  Console.WriteLine("UPDATING DATABASE SCHEMA TO 6.2.11....");
		  paramBaseDBProperties.setProperty("database.schema.version", "6.2.11");
		  paramBaseDBProperties.storeDBProperties();
		  Console.WriteLine("UPDATING DATABASE SCHEMA TO 6.2.11 SUCCESSFULLY COMPLETED.");
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.12"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE PARAMINPUT SET CALCVALDIGITS = 3 WHERE CALCVALDIGITS IS NULL").executeUpdate();
			transaction.commit();
			paramSessionInterface.closeSession();
			paramBaseDBProperties.setProperty("database.schema.version", "6.2.12");
			paramBaseDBProperties.storeDBProperties();
			Console.WriteLine("Master Database Updated from version 6.2.11 to version 6.2.12 successfully!!");
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
			  paramSessionInterface.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.13"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE LAYOUTC SET TYPE='eps' WHERE TYPE='projectinfo'").executeUpdate();
			transaction.commit();
			paramSessionInterface.closeSession();
			paramBaseDBProperties.setProperty("database.schema.version", "6.2.13");
			paramBaseDBProperties.storeDBProperties();
			Console.WriteLine("Master Database Updated from version 6.2.12 to version 6.2.13 successfully!!");
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
			  paramSessionInterface.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.14"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			fixLayoutRoles(session);
			transaction.commit();
			paramSessionInterface.closeSession();
			paramBaseDBProperties.setProperty("database.schema.version", "6.2.14");
			paramBaseDBProperties.storeDBProperties();
			Console.WriteLine("Master Database Updated from version 6.2.13 to version 6.2.14 successfully!!");
		  }
		  catch (Exception exception)
		  {
			try
			{
			  Console.WriteLine(exception.ToString());
			  Console.Write(exception.StackTrace);
			  if (session.Open && transaction.Active)
			  {
				transaction.rollback();
			  }
			  paramSessionInterface.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			  try
			  {
				paramSessionInterface.closeSession();
			  }
			  catch (Exception exception2)
			  {
				Console.WriteLine(exception2.ToString());
				Console.Write(exception2.StackTrace);
			  }
			}
		  }
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.15"))
		{
		  Console.WriteLine("UPDATING DATABASE SCHEMA TO 6.2.15....");
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			SQLQuery sQLQuery = session.createSQLQuery("update RPDFN  set REPORTTYPE = 0 where RONLINE='0'");
			sQLQuery.executeUpdate();
			sQLQuery = session.createSQLQuery("update RPDFN set REPORTTYPE = 1 where RONLINE='1'");
			sQLQuery.executeUpdate();
			transaction.commit();
			paramSessionInterface.closeSession();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "6.2.15");
			paramBaseDBProperties.storeDBProperties();
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
			  paramSessionInterface.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.16"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE ASSEMBLY_CHILD         SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_CONSUMABLE    SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_EQUIPMENT     SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_LABOR         SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_MATERIAL      SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_SUBCONTRACTOR SET QTYPUNITFORM = '', QTYPUFORMSTATE = 0 WHERE QTYPUNITFORM IS NULL").executeUpdate();
			transaction.commit();
			paramSessionInterface.closeSession();
			paramBaseDBProperties.setProperty("database.schema.version", "6.2.16");
			paramBaseDBProperties.storeDBProperties();
			Console.WriteLine("Master Database Updated from version 6.2.15 to version 6.2.16 successfully!!");
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
			  paramSessionInterface.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.17"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE PARAMINPUT SET FRMROWVIS = 0 WHERE FRMROWVIS IS NULL").executeUpdate();
			transaction.commit();
			paramSessionInterface.closeSession();
			paramBaseDBProperties.setProperty("database.schema.version", "6.2.17");
			paramBaseDBProperties.storeDBProperties();
			Console.WriteLine("Master Database Updated from version 6.2.16 to version 6.2.17 successfully!!");
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
			  paramSessionInterface.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.18"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE ASSEMBLY_CHILD         SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_CONSUMABLE    SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_EQUIPMENT     SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_LABOR         SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_MATERIAL      SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_SUBCONTRACTOR SET PV_VARS = '' WHERE PV_VARS IS NULL").executeUpdate();
			transaction.commit();
			paramSessionInterface.closeSession();
			paramBaseDBProperties.setProperty("database.schema.version", "6.2.18");
			paramBaseDBProperties.storeDBProperties();
			Console.WriteLine("Master Database Updated from version 6.2.17 to version 6.2.18 successfully!!");
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
			  paramSessionInterface.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.19"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE ASSEMBLY SET VARS = '' WHERE VARS IS NULL").executeUpdate();
			transaction.commit();
			paramSessionInterface.closeSession();
			paramBaseDBProperties.setProperty("database.schema.version", "6.2.19");
			paramBaseDBProperties.storeDBProperties();
			Console.WriteLine("Master Database Updated from version 6.2.18 to version 6.2.19 successfully!!");
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
			  paramSessionInterface.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
		if (StringUtils.isOlderVersionFrom(paramString, "6.2.20"))
		{
		  Session session = paramSessionInterface.currentSession();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			session.createSQLQuery("UPDATE ASSEMBLY_LABOR      SET UNITHOURS = 1  WHERE UNITHOURS IS NULL").executeUpdate();
			session.createSQLQuery("UPDATE ASSEMBLY_EQUIPMENT  SET UNITHOURS = 1  WHERE UNITHOURS IS NULL").executeUpdate();
			transaction.commit();
			paramSessionInterface.closeSession();
			paramBaseDBProperties.setProperty("database.schema.version", "6.2.20");
			paramBaseDBProperties.storeDBProperties();
			Console.WriteLine("Master Database Updated from version 6.2.19 to version 6.2.20 successfully!!");
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
			  paramSessionInterface.closeSession();
			}
			catch (Exception exception1)
			{
			  Console.WriteLine(exception1.ToString());
			  Console.Write(exception1.StackTrace);
			}
		  }
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static void fixLayoutRoles(org.hibernate.Session paramSession) throws Exception
	  private static void fixLayoutRoles(Session paramSession)
	  {
		System.Collections.IList list1 = paramSession.createQuery("from LayoutTable").list();
		if (list1.Count == 0)
		{
		  return;
		}
		System.Collections.IList list2 = getAllUserTeams(paramSession);
		System.Collections.IList list3 = getUserData(paramSession);
		Hashtable hashMap = new Hashtable();
		list2.ForEach(paramUserTeam => paramMap.put(paramUserTeam.TeamName, paramUserTeam.TeamId));
		list3.ForEach(paramUserData => paramMap.put(paramUserData.UserName, paramUserData.UserId));
		sbyte b = 0;
		foreach (LayoutTable layoutTable in list1)
		{
		  string str1 = layoutTable.LayoutUserAndRoles;
		  if (StringUtils.isNullOrBlank(str1))
		  {
			continue;
		  }
		  string[] arrayOfString = layoutTable.LayoutUserAndRoles.Split(":", true);
		  StringBuilder stringBuffer = new StringBuilder();
		  foreach (string str3 in arrayOfString)
		  {
			string str4 = (string)hashMap[str3];
			if (!string.ReferenceEquals(str4, null))
			{
			  stringBuffer.Append(str4 + ":");
			}
		  }
		  string str2 = stringBuffer.ToString();
		  if (str2.Length == 0)
		  {
			continue;
		  }
		  layoutTable.LayoutUserAndRoles = str2;
		  paramSession.update(layoutTable);
		  if (++b % 20 == 0)
		  {
			paramSession.flush();
			paramSession.clear();
		  }
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static java.util.List<Desktop.common.nomitech.common.auth.UserTeam> getAllUserTeams(org.hibernate.Session paramSession) throws Exception
	  private static IList<UserTeam> getAllUserTeams(Session paramSession)
	  {
		List<object> arrayList = new List<object>(99);
		for (sbyte b = 1; b < 51; b++)
		{
		  UserTeam userTeam = new UserTeam();
		  userTeam.TeamId = "CESCostTeam" + b;
		  string str1 = (b > 9) ? ("" + b) : ("0" + b);
		  string str2 = TeamAliasUtil.getAliasForTeam(paramSession, "CESCostTeam" + b);
		  if (string.ReferenceEquals(str2, null))
		  {
			userTeam.TeamName = "CostOS Team " + str1;
		  }
		  else
		  {
			userTeam.TeamName = str2;
		  }
		  arrayList.Add(userTeam);
		}
		return arrayList;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static java.util.List<UserData> getUserData(org.hibernate.Session paramSession) throws Exception
	  private static IList<UserData> getUserData(Session paramSession)
	  {
		List<object> arrayList = new List<object>();
		SQLQuery sQLQuery = paramSession.createSQLQuery("SELECT PRINCIPALID AS userId, NAME AS userName FROM PRINCIPALS");
		sQLQuery.addScalar("userId", StringType.INSTANCE);
		sQLQuery.addScalar("userName", StringType.INSTANCE);
		sQLQuery.ResultTransformer = Transformers.aliasToBean(typeof(UserData));
		return sQLQuery.list();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static void fixItemCodeLayouts(org.hibernate.Session paramSession) throws Exception
	  private static void fixItemCodeLayouts(Session paramSession)
	  {
		Query query = paramSession.createQuery("from LayoutPanelTable o where o.layoutTable.type = 'paramitem' or o.layoutTable.type = 'assembly' or o.layoutTable.type = 'equipment' or o.layoutTable.type = 'subcontractor' or o.layoutTable.type = 'labor' or o.layoutTable.type = 'material' or o.layoutTable.type = 'consumable'");
		System.Collections.IList list1 = query.list();
		foreach (LayoutPanelTable layoutPanelTable in list1)
		{
		  updateTable(paramSession, layoutPanelTable, 0, 1);
		}
		query = paramSession.createQuery("from LayoutTable o where o.type = 'boqitem'");
		System.Collections.IList list2 = query.list();
		foreach (LayoutTable layoutTable in list2)
		{
		  list1 = layoutTable.LayoutColumnList;
		  for (sbyte b = 1; b < list1.Count; b++)
		  {
			updateTable(paramSession, (LayoutPanelTable)list1[b], 0, 1);
		  }
		}
	  }

	  private static void updateTable(Session paramSession, LayoutPanelTable paramLayoutPanelTable, int paramInt1, int paramInt2)
	  {
		bool @bool = false;
		if (!StringUtils.isNullOrBlank(paramLayoutPanelTable.LockedColumns))
		{
		  int[] arrayOfInt = getIntArrayProperty(paramLayoutPanelTable.LockedColumns);
		  for (sbyte b = 0; b < arrayOfInt.Length; b++)
		  {
			if (arrayOfInt[b] > paramInt1)
			{
			  arrayOfInt[b] = arrayOfInt[b] + paramInt2;
			}
		  }
		  if (arrayOfInt.Length != 0)
		  {
			paramLayoutPanelTable.LockedColumns = getIntArrayPropertyToSet(arrayOfInt);
			@bool = true;
		  }
		}
		if (!StringUtils.isNullOrBlank(paramLayoutPanelTable.GroupedColumns))
		{
		  int[] arrayOfInt = getIntArrayProperty(paramLayoutPanelTable.GroupedColumns);
		  for (sbyte b = 0; b < arrayOfInt.Length; b++)
		  {
			if (arrayOfInt[b] > 0)
			{
			  arrayOfInt[b] = arrayOfInt[b] + paramInt2;
			}
		  }
		  if (arrayOfInt.Length != 0)
		  {
			paramLayoutPanelTable.GroupedColumns = getIntArrayPropertyToSet(arrayOfInt);
			@bool = true;
		  }
		}
		if (@bool)
		{
		  paramSession.update(paramLayoutPanelTable);
		}
	  }

	  private static string getIntArrayPropertyToSet(int[] paramArrayOfInt)
	  {
		string str = "";
		for (sbyte b = 0; b < paramArrayOfInt.Length; b++)
		{
		  str = str + paramArrayOfInt[b] + ";";
		}
		return str;
	  }

	  public static int[] correctUpdatedArray1(int[] paramArrayOfInt)
	  {
		for (sbyte b = 0; b < paramArrayOfInt.Length; b++)
		{
		  if (paramArrayOfInt[b] >= 2 && paramArrayOfInt[b] < 55)
		  {
			paramArrayOfInt[b] = paramArrayOfInt[b] + 2;
		  }
		}
		return paramArrayOfInt;
	  }

	  private static void alterOracleTextColumn(Session paramSession, string paramString1, string paramString2)
	  {
		paramSession.createSQLQuery("create table " + paramString1 + "_tmp as select * from " + paramString1).executeUpdate();
		paramSession.createSQLQuery("truncate TABLE " + paramString1).executeUpdate();
		paramSession.createSQLQuery("alter table " + paramString1 + " modify " + paramString2 + " LONG").executeUpdate();
		paramSession.createSQLQuery("alter table " + paramString1 + " modify " + paramString2 + " CLOB").executeUpdate();
		paramSession.createSQLQuery("insert into " + paramString1 + " select * from " + paramString1 + "_tmp").executeUpdate();
		paramSession.createSQLQuery("commit").executeUpdate();
		paramSession.createSQLQuery("drop table " + paramString1 + "_tmp").executeUpdate();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void fixUserManagement(Desktop.common.nomitech.common.base.BaseDBProperties paramBaseDBProperties, String paramString, javax.sql.DataSource paramDataSource) throws Exception
	  public static void fixUserManagement(BaseDBProperties paramBaseDBProperties, string paramString, DataSource paramDataSource)
	  {
		if (StringUtils.isOlderVersionFrom(paramString, "4.7.1"))
		{
		  try
		  {
			Console.WriteLine("FIXING USER MANAGEMENT CONSOLE STEP 1...");
			Connection connection = paramDataSource.Connection;
			if (connection == null)
			{
			  return;
			}
			string str = connection.MetaData.URL;
			Statement statement = connection.createStatement();
			try
			{
			  if (str.ToLower().IndexOf("mysql", StringComparison.Ordinal) != -1)
			  {
				statement.execute("ALTER TABLE PRINCIPALS ADD HASHKEY VARCHAR(256)");
			  }
			  else if (str.ToLower().IndexOf("oracle", StringComparison.Ordinal) != -1)
			  {
				statement.execute("ALTER TABLE PRINCIPALS ADD (HASHKEY VARCHAR2(256))");
			  }
			  else if (str.ToLower().IndexOf("sqlserver", StringComparison.Ordinal) != -1)
			  {
				statement.execute("ALTER TABLE PRINCIPALS ADD HASHKEY VARCHAR(256) NULL");
			  }
			  else
			  {
				throw new Exception("");
			  }
			}
			catch (Exception)
			{
			  statement.close();
			  connection.close();
			  return;
			}
			Console.WriteLine("FIXING USER MANAGEMENT CONSOLE STEP 2...");
			ResultSet resultSet = statement.executeQuery("SELECT PRINCIPALID, PASSWORD FROM PRINCIPALS WHERE HASHKEY IS NULL");
			while (resultSet.next())
			{
			  string str1 = resultSet.getString(1);
			  string str2 = resultSet.getString(2);
			  string str3 = CryptUtil.Instance.encryptHexString(str2);
			  string str4 = Util.createPasswordHash("SHA", "BASE64", null, str1, str2);
			  Statement statement1 = connection.createStatement();
			  statement1.executeUpdate("UPDATE PRINCIPALS SET PASSWORD = '" + str3 + "', HASHKEY = '" + str4 + "' WHERE PRINCIPALID = '" + str1 + "'");
			  statement1.close();
			}
			statement.close();
			connection.close();
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		}
	  }

	  public static void fixLineItems(BaseDBProperties paramBaseDBProperties, string paramString, SessionInterface paramSessionInterface)
	  {
		if (StringUtils.isOlderVersionFrom(paramString, "1.0.0"))
		{
		  paramString = "4.1.5";
		  paramBaseDBProperties.setProperty("database.schema.version", paramString);
		  paramBaseDBProperties.storeDBProperties();
		  updateSchema(paramBaseDBProperties, paramString, paramSessionInterface);
		}
		Transaction transaction = paramSessionInterface.currentSession().beginTransaction();
		try
		{
		  Console.WriteLine("FIXING LINE ITEM RELATIONSHIPS...");
		  deleteResourceToAssignments(paramSessionInterface.currentSession(), paramSessionInterface.currentSession().createQuery("from AssemblyEquipmentTable o where o.equipmentTable is null and o.assemblyTable is not null").list(), "equipment");
		  transaction.commit();
		  transaction = paramSessionInterface.currentSession().beginTransaction();
		  deleteResourceToAssignments(paramSessionInterface.currentSession(), paramSessionInterface.currentSession().createQuery("from AssemblySubcontractorTable o where o.subcontractorTable is null and o.assemblyTable is not null").list(), "subcontractor");
		  transaction.commit();
		  transaction = paramSessionInterface.currentSession().beginTransaction();
		  deleteResourceToAssignments(paramSessionInterface.currentSession(), paramSessionInterface.currentSession().createQuery("from AssemblyLaborTable o where o.laborTable is null and o.assemblyTable is not null").list(), "labor");
		  transaction.commit();
		  transaction = paramSessionInterface.currentSession().beginTransaction();
		  deleteResourceToAssignments(paramSessionInterface.currentSession(), paramSessionInterface.currentSession().createQuery("from AssemblyMaterialTable o where o.materialTable is null and o.assemblyTable is not null").list(), "material");
		  transaction.commit();
		  transaction = paramSessionInterface.currentSession().beginTransaction();
		  deleteResourceToAssignments(paramSessionInterface.currentSession(), paramSessionInterface.currentSession().createQuery("from AssemblyConsumableTable o where o.consumableTable is null and o.assemblyTable is not null").list(), "consumable");
		  transaction.commit();
		  Console.WriteLine("DONE");
		}
		catch (Exception exception)
		{
		  if (transaction.Active)
		  {
			transaction.rollback();
		  }
		  paramSessionInterface.closeSession();
		  throw exception;
		}
		paramSessionInterface.closeSession();
	  }

	  private static void deleteResourceToAssignments(Session paramSession, System.Collections.IList paramList, string paramString)
	  {
		foreach (ResourceToAssignmentTable resourceToAssignmentTable in paramList)
		{
		  ResourceWithAssignmentsTable resourceWithAssignmentsTable = resourceToAssignmentTable.getResourceTable();
		  resourceWithAssignmentsTable.getResourceAssignments(paramString).remove(resourceToAssignmentTable);
		  resourceToAssignmentTable.AssignmentResourceTable = null;
		  paramSession.update(resourceToAssignmentTable);
		  paramSession.update(resourceWithAssignmentsTable);
		  paramSession.delete(resourceToAssignmentTable);
		}
	  }

	  public static void fixBoqItemTable(BaseDBProperties paramBaseDBProperties, string paramString, SessionInterface paramSessionInterface)
	  {
		if (paramSessionInterface.Configuration == null)
		{
		  paramBaseDBProperties.setProperty("database.schema.version", "4.3.0");
		  paramBaseDBProperties.storeDBProperties();
		  return;
		}
		if (StringUtils.isOlderVersionFrom(paramString, "4.3.0"))
		{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		  PersistentClass persistentClass = paramSessionInterface.Configuration.getClassMapping(typeof(Desktop.common.nomitech.common.db.project.BoqItemTable).FullName);
		  string str1 = paramSessionInterface.Configuration.getProperty("hibernate.connection.url");
		  string str2 = paramSessionInterface.Configuration.getProperty("hibernate.connection.username");
		  string str3 = paramSessionInterface.Configuration.getProperty("hibernate.connection.password");
		  try
		  {
			Console.WriteLine("UPDATING DATABASE SCHEMA 4.3.0...");
			Connection connection = DriverManager.getConnection(str1, str2, str3);
			Statement statement = connection.createStatement();
			List<object> arrayList1 = new List<object>();
			List<object> arrayList2 = new List<object>();
			foreach (Column column in listColumns(persistentClass))
			{
			  ResultSet resultSet = statement.executeQuery("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'BOQITEM' AND COLUMN_NAME = '" + column.Name + "'");
			  int i;
			  for (i = 0; resultSet.next(); i = resultSet.getInt(1))
			  {
				  ;
			  }
			  bool @bool = (i != 0) ? 1 : 0;
			  if (@bool)
			  {
				arrayList1.Add(column);
			  }
			  else
			  {
				arrayList2.Add(column);
			  }
			  resultSet.close();
			}
			foreach (Column column in arrayList1)
			{
			  if (column.Name.StartsWith("CUSTXT") || column.Name.EndsWith("FORM"))
			  {
				statement.executeUpdate("ALTER TABLE BOQITEM MODIFY " + column.Name + " longtext");
			  }
			}
			foreach (Column column in arrayList2)
			{
			  Console.WriteLine("Processing Missing: " + column.Name + " = " + column.SqlType);
			  if (column.Name.StartsWith("CUSTXT") || column.Name.EndsWith("FORM"))
			  {
				Console.WriteLine("ADDING COLUMN: " + column.Name + " AS longtext");
				statement.executeUpdate("ALTER TABLE BOQITEM ADD " + column.Name + " longtext");
			  }
			}
			statement.close();
			connection.close();
			Console.WriteLine("DONE");
			paramBaseDBProperties.setProperty("database.schema.version", "4.3.0");
			paramBaseDBProperties.storeDBProperties();
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		}
	  }

	  private static IList<Column> listColumns(PersistentClass paramPersistentClass)
	  {
		List<object> arrayList = new List<object>();
		System.Collections.IEnumerator iterator1 = paramPersistentClass.Identifier.ColumnIterator;
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		if (iterator1.hasNext())
		{
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		  Column column = (Column)iterator1.next();
		  arrayList.Add(column);
		}
		System.Collections.IEnumerator iterator2 = paramPersistentClass.PropertyIterator;
		while (iterator2.MoveNext())
		{
		  Property property = (Property)iterator2.Current;
		  iterator1 = property.ColumnIterator;
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		  if (iterator1.hasNext())
		  {
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			Column column = (Column)iterator1.next();
			arrayList.Add(column);
		  }
		}
		return arrayList;
	  }

	  private static int[] getIntArrayProperty(string paramString)
	  {
		List<object> vector = new List<object>();
		for (sbyte b1 = 0; b1 < paramString.Length; b1++)
		{
		  for (int i = b1 + true; i <= paramString.Length; i++)
		  {
			string str = paramString.Substring(b1, i - b1);
			if (str.EndsWith(";", StringComparison.Ordinal))
			{
			  vector.Add(paramString.Substring(b1, (i - 1) - b1));
			  b1 = i - 1;
			  i = paramString.Length;
			}
		  }
		}
		int[] arrayOfInt = new int[vector.Count];
		for (sbyte b2 = 0; b2 < vector.Count; b2++)
		{
		  try
		  {
			arrayOfInt[b2] = int.Parse((string)vector[b2]);
		  }
		  catch (System.FormatException numberFormatException)
		  {
			Console.WriteLine(numberFormatException.ToString());
			Console.Write(numberFormatException.StackTrace);
		  }
		}
		return arrayOfInt;
	  }

	  public static void updateCurrencyTable(SessionInterface paramSessionInterface)
	  {
		Session session = paramSessionInterface.currentSession();
		Number number = (Number)session.createQuery("select count(*) from CurrencyTable ").list().GetEnumerator().next();
		System.Collections.IList list = CurrencyHome.RemainingCurrencies;
		if (number.intValue() == 0)
		{
		  Console.WriteLine("No CurrencyTable Creating from file");
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("CREATING CURRENCYTABLE ...");
			foreach (Currency currency in list)
			{
			  CurrencyTable currencyTable = new CurrencyTable();
			  currencyTable.Data = currency;
			  long? long = (long?)session.save(currencyTable);
			}
			transaction.commit();
			Console.WriteLine("CURRENCY TABLE CREATED");
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		else if (number.intValue() != 0)
		{
		  Console.WriteLine(" CurrencyTable exists updating");
		  System.Collections.IList list1 = session.createQuery("from CurrencyTable").list();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Hashtable hashMap = new Hashtable();
			foreach (CurrencyTable currencyTable in list1)
			{
			  hashMap[currencyTable.Code] = currencyTable;
			}
			foreach (Currency currency in list)
			{
			  if (!hashMap.ContainsKey(currency.Code))
			  {
				CurrencyTable currencyTable = new CurrencyTable();
				currencyTable.Data = currency;
				long? long = (long?)session.save(currencyTable);
			  }
			}
			transaction.commit();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		  Console.WriteLine("CurrencyTable Updated Success");
		}
	  }

	  public static void updateCountryTable(SessionInterface paramSessionInterface)
	  {
		Session session = paramSessionInterface.currentSession();
		Number number = (Number)session.createQuery("select count(*) from CountryTable ").list().GetEnumerator().next();
		List<object> vector = (List<object>)UICountries.AllCountryNames;
		if (number.intValue() == 0)
		{
		  Console.WriteLine("No Country Creating from file");
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("CREATING COUNTRY TABLE ...");
			foreach (string str in vector)
			{
			  CountryTable countryTable = new CountryTable();
			  countryTable.CountryName = str;
			  countryTable.CountryCode = UICountries.getTwoLetterCodeForCountryName(str);
			  long? long = (long?)session.save(countryTable);
			}
			transaction.commit();
			Console.WriteLine("COUNTRY TABLE CREATED");
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		else if (number.intValue() != 0)
		{
		  System.Collections.IList list = session.createQuery("from CountryTable").list();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Hashtable hashMap = new Hashtable();
			foreach (CountryTable countryTable in list)
			{
			  hashMap[countryTable.CountryName] = countryTable;
			}
			foreach (string str in vector)
			{
			  if (!hashMap.ContainsKey(str))
			  {
				CountryTable countryTable = new CountryTable();
				countryTable.CountryName = str;
				countryTable.CountryCode = UICountries.getTwoLetterCodeForCountryName(str);
				long? long = (long?)session.save(countryTable);
			  }
			}
			transaction.commit();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
	  }

	  public static void updateOrCreateMetadataForBoqitem(SessionInterface paramSessionInterface)
	  {
		DataObjectDescriptor[] arrayOfDataObjectDescriptor = DynBoqItemViewDescriptor.Instance.All;
		Session session = paramSessionInterface.currentSession();
		Number number = (Number)session.createQuery("select count(*) from BoqMetadataTable ").list().GetEnumerator().next();
		if (number.intValue() == 0)
		{
		  Console.WriteLine("No BOQ metadata Creating ");
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Console.WriteLine("CREATING BOQMETADATA TABLE ...");
			foreach (DataObjectDescriptor dataObjectDescriptor in arrayOfDataObjectDescriptor)
			{
			  BoqMetadataTable boqMetadataTable = new BoqMetadataTable();
			  boqMetadataTable.ColumnName = dataObjectDescriptor.ColumnName;
			  boqMetadataTable.FieldName = dataObjectDescriptor.FieldName;
			  boqMetadataTable.InitialDisplayName = dataObjectDescriptor.DisplayName;
			  boqMetadataTable.FieldKey = dataObjectDescriptor.FieldKey;
			  long? long = (long?)session.save(boqMetadataTable);
			}
			transaction.commit();
			Console.WriteLine("BOQMETADATA table Created");
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
		else if (number.intValue() != 0)
		{
		  System.Collections.IList list = session.createQuery("from BoqMetadataTable").list();
		  Transaction transaction = session.beginTransaction();
		  try
		  {
			Hashtable hashMap = new Hashtable();
			foreach (BoqMetadataTable boqMetadataTable in list)
			{
			  hashMap[boqMetadataTable.FieldName] = boqMetadataTable;
			}
			foreach (DataObjectDescriptor dataObjectDescriptor in arrayOfDataObjectDescriptor)
			{
			  if (!hashMap.ContainsKey(dataObjectDescriptor.FieldName))
			  {
				BoqMetadataTable boqMetadataTable = new BoqMetadataTable();
				boqMetadataTable.ColumnName = dataObjectDescriptor.ColumnName;
				boqMetadataTable.FieldName = dataObjectDescriptor.FieldName;
				boqMetadataTable.InitialDisplayName = dataObjectDescriptor.DisplayName;
				boqMetadataTable.FieldKey = dataObjectDescriptor.FieldKey;
				long? long = (long?)session.save(boqMetadataTable);
			  }
			}
			transaction.commit();
		  }
		  catch (Exception exception)
		  {
			transaction.rollback();
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  paramSessionInterface.closeSession();
		}
	  }

	  public class UserData
	  {
		internal string userId;

		internal string userName;

		public UserData()
		{
		}

		public UserData(string param1String1, string param1String2)
		{
		  this.userId = param1String1;
		  this.userName = param1String2;
		}

		public virtual string UserId
		{
			get
			{
				return this.userId;
			}
			set
			{
				this.userId = value;
			}
		}


		public virtual string UserName
		{
			get
			{
				return this.userName;
			}
			set
			{
				this.userName = value;
			}
		}

	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\SchemaUpdateUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}