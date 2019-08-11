using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common.migration
{
	using GroupCode = nomitech.common.@base.GroupCode;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using AssemblyAssemblyTable = nomitech.common.db.local.AssemblyAssemblyTable;
	using AssemblyConsumableTable = nomitech.common.db.local.AssemblyConsumableTable;
	using AssemblyEquipmentTable = nomitech.common.db.local.AssemblyEquipmentTable;
	using AssemblyLaborTable = nomitech.common.db.local.AssemblyLaborTable;
	using AssemblyMaterialTable = nomitech.common.db.local.AssemblyMaterialTable;
	using AssemblySubcontractorTable = nomitech.common.db.local.AssemblySubcontractorTable;
	using AssemblyTable = nomitech.common.db.local.AssemblyTable;
	using ConsumableTable = nomitech.common.db.local.ConsumableTable;
	using EquipmentTable = nomitech.common.db.local.EquipmentTable;
	using GekCodeTable = nomitech.common.db.local.GekCodeTable;
	using GroupCodeTable = nomitech.common.db.local.GroupCodeTable;
	using LaborTable = nomitech.common.db.local.LaborTable;
	using MaterialTable = nomitech.common.db.local.MaterialTable;
	using SubcontractorTable = nomitech.common.db.local.SubcontractorTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using BlankResourceInitializer = nomitech.common.expr.boqitem.BlankResourceInitializer;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using StringUtils = nomitech.common.util.StringUtils;
	using HSSFCell = org.apache.poi.hssf.usermodel.HSSFCell;
	using HSSFRow = org.apache.poi.hssf.usermodel.HSSFRow;
	using HSSFSheet = org.apache.poi.hssf.usermodel.HSSFSheet;
	using HSSFWorkbook = org.apache.poi.hssf.usermodel.HSSFWorkbook;
	using POIFSFileSystem = org.apache.poi.poifs.filesystem.POIFSFileSystem;
	using CellValue = org.apache.poi.ss.usermodel.CellValue;
	using FormulaEvaluator = org.apache.poi.ss.usermodel.FormulaEvaluator;
	using Session = org.hibernate.Session;

	public class CCCMigrationUtil
	{
	  private int rowsToCommit = 100;

	  private FormulaEvaluator o_evaluator;

	  private DateTime lastUpdate = DateTime.Now;

	  private IDictionary<string, string> csi95Map = new Hashtable();

	  private IDictionary<string, ResourceTable> resourcesMap = new Hashtable();

	  private IDictionary<string, AssemblyTable> operationsMap = new Hashtable();

	  private CCCMigrationUtil(string paramString1, string paramString2, string paramString3)
	  {
		Session session = DatabaseDBUtil.currentSession();
		session.beginTransaction();
		try
		{
		  Console.WriteLine("Starting Importing...");
		  session.Transaction.commit();
		  session.beginTransaction();
		  loadCSI95(session, paramString1);
		  session.Transaction.commit();
		  session.beginTransaction();
		  loadResourceCodes(session);
		  session.Transaction.commit();
		  session.beginTransaction();
		  loadResources(session, paramString3);
		  session.Transaction.commit();
		  session.beginTransaction();
		  loadOperations(session, paramString3);
		  session.Transaction.commit();
		  session.beginTransaction();
		  loadWorkgroups(session, paramString3);
		  session.Transaction.commit();
		  session.beginTransaction();
		}
		catch (Exception exception)
		{
		  if (session.Transaction.Active)
		  {
			session.Transaction.rollback();
		  }
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		DatabaseDBUtil.closeSession();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadWorkgroups(org.hibernate.Session paramSession, String paramString) throws Exception
	  private void loadWorkgroups(Session paramSession, string paramString)
	  {
		Console.WriteLine("\n\n\n\nLoading Workgroups");
		POIFSFileSystem pOIFSFileSystem = new POIFSFileSystem(new FileStream(paramString, FileMode.Open, FileAccess.Read));
		HSSFWorkbook hSSFWorkbook = new HSSFWorkbook(pOIFSFileSystem);
		this.o_evaluator = hSSFWorkbook.CreationHelper.createFormulaEvaluator();
		HSSFSheet hSSFSheet = hSSFWorkbook.getSheetAt(4);
		int i = getRealNumberOfRows(hSSFSheet);
		int j;
		for (j = 1; j < i; j++)
		{
		  if (j % this.rowsToCommit == 0)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
			Console.WriteLine("Processing next " + this.rowsToCommit + "...");
		  }
		  HSSFRow hSSFRow = hSSFSheet.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(0));
		  string str2 = notNull(hSSFRow.getCell(1));
		  string str3 = toCostOSUoM(notNull(hSSFRow.getCell(2)));
		  decimal bigDecimal1 = notNullBigDecimal(hSSFRow.getCell(3), 0.0D);
		  decimal bigDecimal2 = notNullBigDecimal(hSSFRow.getCell(4), 1.0D);
		  string str4 = notNull(hSSFRow.getCell(5));
		  string str5 = notNull(hSSFRow.getCell(8));
		  string str6 = "";
		  if (str5.Length >= 2 && !StringUtils.isBlank(str5))
		  {
			str6 = "0" + str5.Substring(0, 2) + "00";
		  }
		  if (acceptProject(str1))
		  {
			AssemblyTable assemblyTable = BlankResourceInitializer.createBlankAssembly(null);
			assemblyTable.ItemCode = str2;
			assemblyTable.Title = str4;
			assemblyTable.Unit = str3;
			assemblyTable.Quantity = bigDecimal1;
			assemblyTable.Project = str1;
			assemblyTable.Currency = "USD";
			assemblyTable.ActivityBased = false;
			assemblyTable.AssemblyChildSet = new HashSet<object>();
			assemblyTable.AssemblyEquipmentSet = new HashSet<object>();
			assemblyTable.AssemblySubcontractorSet = new HashSet<object>();
			assemblyTable.AssemblyLaborSet = new HashSet<object>();
			assemblyTable.AssemblyMaterialSet = new HashSet<object>();
			assemblyTable.AssemblyConsumableSet = new HashSet<object>();
			assemblyTable.EditorId = "ccc";
			assemblyTable.CreateUserId = "ccc";
			assemblyTable.LastUpdate = this.lastUpdate;
			assemblyTable.CreateDate = this.lastUpdate;
			assemblyTable.CustomText1 = "Workgroup";
			if (this.csi95Map.ContainsKey(str6))
			{
			  assemblyTable.GroupCode = (string)this.csi95Map[str6];
			}
			else if (!StringUtils.isBlank(str6))
			{
			  Console.WriteLine("CSI Not Found: " + str6);
			}
			long? long = (long?)paramSession.save(assemblyTable);
			assemblyTable = (AssemblyTable)paramSession.load(assemblyTable.GetType(), long);
			this.operationsMap[str1 + str2] = assemblyTable;
		  }
		}
		hSSFSheet = hSSFWorkbook.getSheetAt(3);
		i = getRealNumberOfRows(hSSFSheet);
		for (j = 1; j < i; j++)
		{
		  if (j % this.rowsToCommit == 0)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
			Console.WriteLine("Processing next " + this.rowsToCommit + " - " + j + "/" + i + "...");
		  }
		  HSSFRow hSSFRow = hSSFSheet.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(0));
		  string str2 = notNull(hSSFRow.getCell(1));
		  string str3 = notNull(hSSFRow.getCell(2));
		  string str4 = notNull(hSSFRow.getCell(3));
		  string str5 = notNull(hSSFRow.getCell(4));
		  decimal bigDecimal = notNullBigDecimal(hSSFRow.getCell(5), 0.0D);
		  AssemblyTable assemblyTable = (AssemblyTable)this.operationsMap[str1 + str2];
		  ResourceTable resourceTable = (ResourceTable)this.resourcesMap[str1 + str3];
		  if (assemblyTable == null)
		  {
			Console.Error.WriteLine("Workgroup not found: " + str2 + ", project: " + str1);
			continue;
		  }
		  if (resourceTable == null)
		  {
			resourceTable = (ResourceTable)this.operationsMap[str1 + str3];
			if (resourceTable == null)
			{
			  Console.Error.WriteLine("Operation or Resource not found: " + str3 + ", project: " + str1);
			  continue;
			}
		  }
		  if (BigDecimalMath.cmp(BigDecimalMath.ZERO, assemblyTable.Quantity) == 0)
		  {
			Console.WriteLine("Divide by zero error on workgroup: " + str2 + ", operation or resource: " + str3 + ", project: " + str1);
			bigDecimal = BigDecimalMath.ONE;
		  }
		  else
		  {
			bigDecimal = BigDecimalMath.div(bigDecimal, assemblyTable.Quantity);
		  }
		  assignToResource(paramSession, assemblyTable, resourceTable, bigDecimal);
		  paramSession.flush();
		  assemblyTable = (AssemblyTable)paramSession.load(assemblyTable.GetType(), assemblyTable.Id);
		  assemblyTable.recalculate();
		  paramSession.update(assemblyTable);
		  continue;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadOperations(org.hibernate.Session paramSession, String paramString) throws Exception
	  private void loadOperations(Session paramSession, string paramString)
	  {
		Console.WriteLine("\n\n\n\nLoading OPERATIONS");
		POIFSFileSystem pOIFSFileSystem = new POIFSFileSystem(new FileStream(paramString, FileMode.Open, FileAccess.Read));
		HSSFWorkbook hSSFWorkbook = new HSSFWorkbook(pOIFSFileSystem);
		this.o_evaluator = hSSFWorkbook.CreationHelper.createFormulaEvaluator();
		HSSFSheet hSSFSheet = hSSFWorkbook.getSheetAt(2);
		int i = getRealNumberOfRows(hSSFSheet);
		int j;
		for (j = 1; j < i; j++)
		{
		  if (j % this.rowsToCommit == 0)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
			Console.WriteLine("Processing next " + this.rowsToCommit + "...");
		  }
		  HSSFRow hSSFRow = hSSFSheet.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(0));
		  string str2 = notNull(hSSFRow.getCell(1));
		  string str3 = toCostOSUoM(notNull(hSSFRow.getCell(2)));
		  decimal bigDecimal1 = notNullBigDecimal(hSSFRow.getCell(3), 0.0D);
		  decimal bigDecimal2 = notNullBigDecimal(hSSFRow.getCell(4), 1.0D);
		  string str4 = notNull(hSSFRow.getCell(5));
		  string str5 = notNull(hSSFRow.getCell(8));
		  string str6 = "";
		  if (str5.Length >= 2 && !StringUtils.isBlank(str5))
		  {
			str6 = "0" + str5.Substring(0, 2) + "00";
		  }
		  if (acceptProject(str1))
		  {
			AssemblyTable assemblyTable = BlankResourceInitializer.createBlankAssembly(null);
			assemblyTable.ItemCode = str2;
			assemblyTable.Title = str4;
			assemblyTable.Unit = str3;
			assemblyTable.Quantity = bigDecimal1;
			assemblyTable.Project = str1;
			assemblyTable.Currency = "USD";
			assemblyTable.ActivityBased = false;
			assemblyTable.AssemblyChildSet = new HashSet<object>();
			assemblyTable.AssemblyEquipmentSet = new HashSet<object>();
			assemblyTable.AssemblySubcontractorSet = new HashSet<object>();
			assemblyTable.AssemblyLaborSet = new HashSet<object>();
			assemblyTable.AssemblyMaterialSet = new HashSet<object>();
			assemblyTable.AssemblyConsumableSet = new HashSet<object>();
			assemblyTable.EditorId = "ccc";
			assemblyTable.CreateUserId = "ccc";
			assemblyTable.LastUpdate = this.lastUpdate;
			assemblyTable.CreateDate = this.lastUpdate;
			assemblyTable.CustomText1 = "Operation";
			if (this.csi95Map.ContainsKey(str6))
			{
			  assemblyTable.GroupCode = (string)this.csi95Map[str6];
			}
			else if (!StringUtils.isBlank(str6))
			{
			  Console.WriteLine("CSI Not Found: " + str6);
			}
			long? long = (long?)paramSession.save(assemblyTable);
			assemblyTable = (AssemblyTable)paramSession.load(assemblyTable.GetType(), long);
			this.operationsMap[str1 + str2] = assemblyTable;
		  }
		}
		hSSFSheet = hSSFWorkbook.getSheetAt(1);
		i = getRealNumberOfRows(hSSFSheet);
		for (j = 1; j < i; j++)
		{
		  if (j % this.rowsToCommit == 0)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
			Console.WriteLine("Processing next " + this.rowsToCommit + "...");
		  }
		  HSSFRow hSSFRow = hSSFSheet.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(0));
		  string str2 = notNull(hSSFRow.getCell(1));
		  string str3 = notNull(hSSFRow.getCell(2));
		  string str4 = notNull(hSSFRow.getCell(3));
		  string str5 = notNull(hSSFRow.getCell(4));
		  decimal bigDecimal = notNullBigDecimal(hSSFRow.getCell(5), 0.0D);
		  AssemblyTable assemblyTable = (AssemblyTable)this.operationsMap[str1 + str2];
		  ResourceTable resourceTable = (ResourceTable)this.resourcesMap[str1 + str3];
		  if (assemblyTable == null)
		  {
			Console.Error.WriteLine("Operation not found: " + str2 + ", project: " + str1);
		  }
		  else if (resourceTable == null)
		  {
			Console.Error.WriteLine("Resource not found: " + str3 + ", project: " + str1);
		  }
		  else
		  {
			if (BigDecimalMath.cmp(BigDecimalMath.ZERO, assemblyTable.Quantity) == 0)
			{
			  Console.WriteLine("Divide by zero error on operation: " + str2 + ", resource: " + str3 + ", project: " + str1);
			  bigDecimal = BigDecimalMath.ONE;
			}
			else
			{
			  bigDecimal = BigDecimalMath.div(bigDecimal, assemblyTable.Quantity);
			}
			assignToResource(paramSession, assemblyTable, resourceTable, bigDecimal);
			paramSession.flush();
			assemblyTable = (AssemblyTable)paramSession.load(assemblyTable.GetType(), assemblyTable.Id);
			assemblyTable.recalculate();
			paramSession.update(assemblyTable);
		  }
		}
	  }

	  private void assignToResource(Session paramSession, AssemblyTable paramAssemblyTable, ResourceTable paramResourceTable, decimal paramBigDecimal)
	  {
		AssemblyConsumableTable assemblyConsumableTable;
		if (paramResourceTable is AssemblyTable)
		{
		  assemblyConsumableTable = new AssemblyAssemblyTable();
		  ((AssemblyAssemblyTable)assemblyConsumableTable).LastUpdate = this.lastUpdate;
		}
		else if (paramResourceTable is EquipmentTable)
		{
		  assemblyConsumableTable = new AssemblyEquipmentTable();
		  ((AssemblyEquipmentTable)assemblyConsumableTable).LastUpdate = this.lastUpdate;
		}
		else if (paramResourceTable is SubcontractorTable)
		{
		  assemblyConsumableTable = new AssemblySubcontractorTable();
		  ((AssemblySubcontractorTable)assemblyConsumableTable).LastUpdate = this.lastUpdate;
		}
		else if (paramResourceTable is LaborTable)
		{
		  assemblyConsumableTable = new AssemblyLaborTable();
		  ((AssemblyLaborTable)assemblyConsumableTable).LastUpdate = this.lastUpdate;
		}
		else if (paramResourceTable is MaterialTable)
		{
		  assemblyConsumableTable = new AssemblyMaterialTable();
		  ((AssemblyMaterialTable)assemblyConsumableTable).LastUpdate = this.lastUpdate;
		}
		else if (paramResourceTable is ConsumableTable)
		{
		  assemblyConsumableTable = new AssemblyConsumableTable();
		  ((AssemblyConsumableTable)assemblyConsumableTable).LastUpdate = this.lastUpdate;
		}
		else
		{
		  return;
		}
		assemblyConsumableTable.ExchangeRate = BigDecimalMath.ONE;
		assemblyConsumableTable.LocalStateProvince = "";
		assemblyConsumableTable.LocalCountry = "";
		assemblyConsumableTable.LocalFactor = BigDecimalMath.ONE;
		assemblyConsumableTable.Factor1 = BigDecimalMath.ONE;
		assemblyConsumableTable.Factor2 = BigDecimalMath.ONE;
		assemblyConsumableTable.Factor3 = BigDecimalMath.ONE;
		assemblyConsumableTable.QuantityPerUnit = paramBigDecimal;
		assemblyConsumableTable.QuantityPerUnitFormula = "";
		assemblyConsumableTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
		long? long = (long?)paramSession.save(assemblyConsumableTable);
		ResourceToAssignmentTable resourceToAssignmentTable = (ResourceToAssignmentTable)paramSession.load(assemblyConsumableTable.GetType(), long);
		if (paramResourceTable is AssemblyTable)
		{
		  paramAssemblyTable.AssemblyChildSet.Add((AssemblyAssemblyTable)resourceToAssignmentTable);
		}
		else if (paramResourceTable is EquipmentTable)
		{
		  paramAssemblyTable.AssemblyEquipmentSet.Add((AssemblyEquipmentTable)resourceToAssignmentTable);
		}
		else if (paramResourceTable is SubcontractorTable)
		{
		  paramAssemblyTable.AssemblySubcontractorSet.Add((AssemblySubcontractorTable)resourceToAssignmentTable);
		}
		else if (paramResourceTable is LaborTable)
		{
		  paramAssemblyTable.AssemblyLaborSet.Add((AssemblyLaborTable)resourceToAssignmentTable);
		}
		else if (paramResourceTable is MaterialTable)
		{
		  paramAssemblyTable.AssemblyMaterialSet.Add((AssemblyMaterialTable)resourceToAssignmentTable);
		}
		else if (paramResourceTable is ConsumableTable)
		{
		  paramAssemblyTable.AssemblyConsumableSet.Add((AssemblyConsumableTable)resourceToAssignmentTable);
		}
		resourceToAssignmentTable.setResourceTable(paramAssemblyTable);
		resourceToAssignmentTable.AssignmentResourceTable = paramResourceTable;
		paramSession.update(paramAssemblyTable);
		paramSession.update(paramResourceTable);
		paramSession.update(resourceToAssignmentTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadResources(org.hibernate.Session paramSession, String paramString) throws Exception
	  private void loadResources(Session paramSession, string paramString)
	  {
		Console.WriteLine("\n\n\n\nLoading RESOURSES");
		POIFSFileSystem pOIFSFileSystem = new POIFSFileSystem(new FileStream(paramString, FileMode.Open, FileAccess.Read));
		HSSFWorkbook hSSFWorkbook = new HSSFWorkbook(pOIFSFileSystem);
		this.o_evaluator = hSSFWorkbook.CreationHelper.createFormulaEvaluator();
		HSSFSheet hSSFSheet = hSSFWorkbook.getSheetAt(0);
		int i = getRealNumberOfRows(hSSFSheet);
		for (int j = 1; j < i; j++)
		{
		  if (j % this.rowsToCommit == 0)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
			Console.WriteLine("Processing next " + this.rowsToCommit + "...");
		  }
		  HSSFRow hSSFRow = hSSFSheet.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(0));
		  string str2 = notNull(hSSFRow.getCell(1));
		  string str3 = notNull(hSSFRow.getCell(2));
		  string str4 = toCostOSUoM(notNull(hSSFRow.getCell(3)));
		  decimal bigDecimal1 = notNullBigDecimal(hSSFRow.getCell(4), 0.0D);
		  string str5 = notNull(hSSFRow.getCell(7));
		  decimal bigDecimal2 = notNullBigDecimal(hSSFRow.getCell(17), 0.0D);
		  string str6 = notNull(hSSFRow.getCell(14));
		  string str7 = "";
		  if (str6.Length >= 2 && !StringUtils.isBlank(str6))
		  {
			str7 = "0" + str6.Substring(0, 2) + "00";
		  }
		  if (acceptProject(str1) && !str4.Equals(""))
		  {
			SubcontractorTable subcontractorTable = null;
			if (str5.Equals("F&O"))
			{
			  subcontractorTable = BlankResourceInitializer.createBlankEquipment(null);
			  ((EquipmentTable)subcontractorTable).Currency = "USD";
			  ((EquipmentTable)subcontractorTable).FuelRate = bigDecimal1;
			}
			else if (str5.Equals("LAB") && str4.Equals("HOUR"))
			{
			  LaborTable laborTable = BlankResourceInitializer.createBlankLabor(null);
			  ((LaborTable)laborTable).Currency = "USD";
			  ((LaborTable)laborTable).Rate = bigDecimal1;
			}
			else if (str5.Equals("STF") && str4.Equals("DAY"))
			{
			  LaborTable laborTable = BlankResourceInitializer.createBlankLabor(null);
			  ((LaborTable)laborTable).Currency = "USD";
			  ((LaborTable)laborTable).Rate = bigDecimal1;
			}
			else if (str5.Equals("STF") && str4.Equals("MONTH"))
			{
			  LaborTable laborTable = BlankResourceInitializer.createBlankLabor(null);
			  ((LaborTable)laborTable).Currency = "USD";
			  ((LaborTable)laborTable).Rate = bigDecimal1;
			}
			else if (str5.Equals("GEN") || str5.Equals("REC"))
			{
			  ConsumableTable consumableTable = BlankResourceInitializer.createBlankConsumable(null);
			  ((ConsumableTable)consumableTable).Currency = "USD";
			  ((ConsumableTable)consumableTable).Rate = bigDecimal1;
			}
			else if (str5.Equals("LOC") || str5.Equals("IMP"))
			{
			  MaterialTable materialTable = BlankResourceInitializer.createBlankMaterial(null);
			  ((MaterialTable)materialTable).Currency = "USD";
			  ((MaterialTable)materialTable).Rate = bigDecimal1;
			}
			else if (str5.Equals("S/C"))
			{
			  SubcontractorTable subcontractorTable1 = BlankResourceInitializer.createBlankSubcontractor(null);
			  ((SubcontractorTable)subcontractorTable1).Currency = "USD";
			  ((SubcontractorTable)subcontractorTable1).Rate = bigDecimal1;
			}
			else if (str5.Equals("PLA"))
			{
			  subcontractorTable = BlankResourceInitializer.createBlankEquipment(null);
			  ((EquipmentTable)subcontractorTable).Currency = "USD";
			  ((EquipmentTable)subcontractorTable).ReservationRate = bigDecimal1;
			}
			else
			{
			  subcontractorTable = BlankResourceInitializer.createBlankSubcontractor(null);
			  ((SubcontractorTable)subcontractorTable).Currency = "USD";
			  ((SubcontractorTable)subcontractorTable).Rate = bigDecimal1;
			}
			subcontractorTable.ItemCode = str2;
			subcontractorTable.Title = str3;
			subcontractorTable.Project = str1;
			subcontractorTable.Quantity = bigDecimal2;
			subcontractorTable.Unit = str4;
			subcontractorTable.GekCode = str5 + " - " + str5;
			if (this.csi95Map.ContainsKey(str7))
			{
			  subcontractorTable.GroupCode = (string)this.csi95Map[str7];
			}
			else if (!StringUtils.isBlank(str7))
			{
			  Console.WriteLine("CSI Not Found: " + str7);
			}
			subcontractorTable.LastUpdate = this.lastUpdate;
			subcontractorTable.CreateDate = this.lastUpdate;
			subcontractorTable.EditorId = "ccc";
			subcontractorTable.CreateUserId = "ccc";
			long? long = (long?)paramSession.save(subcontractorTable);
			ResourceTable resourceTable = (ResourceTable)paramSession.load(subcontractorTable.GetType(), long);
			this.resourcesMap[str1 + str2] = resourceTable;
		  }
		}
	  }

	  private string toCostOSUoM(string paramString)
	  {
		paramString = StringUtils.replaceAll(paramString, " ", "");
		paramString = paramString.ToUpper();
		if (paramString.Equals("m³") || paramString.Equals("LM3"))
		{
		  paramString = "M3";
		}
		else if (paramString.Equals("m²") || paramString.Equals("M2/D"))
		{
		  paramString = "M2";
		}
		else if (paramString.Equals("M"))
		{
		  paramString = "LM";
		}
		else if (paramString.Equals("HR"))
		{
		  paramString = "HOUR";
		}
		else if (paramString.Equals("INCH"))
		{
		  paramString = "IN";
		}
		else if (paramString.Equals("MONT") || paramString.Equals("MT") || paramString.Equals("MTH"))
		{
		  paramString = "MONTH";
		}
		else if (paramString.Equals("NR") || paramString.Equals("NOS") || paramString.Equals("NO"))
		{
		  paramString = "NUM";
		}
		else if (paramString.Equals("PC") || paramString.Equals("PER"))
		{
		  paramString = "PCS";
		}
		else if (paramString.Equals("RO") || paramString.Equals(""))
		{
		  paramString = "EACH";
		}
		return paramString;
	  }

	  private bool acceptProject(string paramString)
	  {
		  return true;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadResourceCodes(org.hibernate.Session paramSession) throws Exception
	  private void loadResourceCodes(Session paramSession)
	  {
		Console.WriteLine("\n\n\n\nLoading Resource Codes");
		paramSession.save(addGroupCode2("F&O", "F&O", ""));
		paramSession.save(addGroupCode2("LAB", "LAB", ""));
		paramSession.save(addGroupCode2("LOC", "LOC", ""));
		paramSession.save(addGroupCode2("PLA", "PLA", ""));
		paramSession.save(addGroupCode2("S/C", "S/C", ""));
		paramSession.save(addGroupCode2("STF", "STF", ""));
		paramSession.save(addGroupCode2("REC", "REC", ""));
		paramSession.save(addGroupCode2("IMP", "IMP", ""));
		paramSession.save(addGroupCode2("GEN", "GEN", ""));
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadCSI95(org.hibernate.Session paramSession, String paramString) throws Exception
	  private void loadCSI95(Session paramSession, string paramString)
	  {
		Console.WriteLine("\n\n\n\nLoading CSI 1995");
		POIFSFileSystem pOIFSFileSystem = new POIFSFileSystem(new FileStream(paramString, FileMode.Open, FileAccess.Read));
		HSSFWorkbook hSSFWorkbook = new HSSFWorkbook(pOIFSFileSystem);
		this.o_evaluator = hSSFWorkbook.CreationHelper.createFormulaEvaluator();
		HSSFSheet hSSFSheet = hSSFWorkbook.getSheetAt(0);
		int i = getRealNumberOfRows(hSSFSheet);
		for (int j = 1; j < i; j++)
		{
		  string str4;
		  string str3;
		  string str2;
		  if (j % this.rowsToCommit == 0)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
			Console.WriteLine("Processing next " + this.rowsToCommit + "...");
		  }
		  HSSFRow hSSFRow = hSSFSheet.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(1));
		  if (StringUtils.isEmpty(str1))
		  {
			string str = notNull(hSSFRow.getCell(3));
			int k = str.IndexOf(" -- ", StringComparison.Ordinal);
			if (k == -1)
			{
			  continue;
			}
			str2 = str.Substring(0, k);
			str2 = StringUtils.replaceAll(str2, "Division ", "");
			if (str2.Length == 1)
			{
			  str2 = "0" + str2;
			}
			str3 = StringUtils.replaceAll(str, " -- ", " ");
			str4 = str2 + "000";
		  }
		  else if (str1.Equals("00"))
		  {
			str2 = str4 = notNull(hSSFRow.getCell(2));
			str3 = notNull(hSSFRow.getCell(4));
			str2 = str4.Substring(0, 2) + "." + str4.Substring(2, 1);
			str3 = StringUtils.replaceAll(str3, " - ", " ");
		  }
		  else
		  {
			str2 = str4 = notNull(hSSFRow.getCell(2));
			str3 = notNull(hSSFRow.getCell(5));
			string str = str2.Substring(2, 1);
			str = str + ".";
			str2 = str4.Substring(0, 2) + "." + str + str4.Substring(3, 2);
			str3 = StringUtils.replaceAll(str3, " - ", " ");
		  }
		  GroupCodeTable groupCodeTable = (GroupCodeTable)addGroupCode1(str2, str3, str4);
		  long? long = (long?)paramSession.save(groupCodeTable);
		  groupCodeTable.GroupCodeId = long;
		  this.csi95Map[str4] = groupCodeTable.ToString();
		  Console.WriteLine(str2 + " = " + str4 + " = " + str3);
		  continue;
		}
	  }

	  private int getRealNumberOfRows(HSSFSheet paramHSSFSheet)
	  {
		int i = paramHSSFSheet.PhysicalNumberOfRows;
		for (sbyte b = 1; b < i; b++)
		{
		  if (paramHSSFSheet.getRow(b) == null)
		  {
			return b;
		  }
		  int j = paramHSSFSheet.getRow(0).PhysicalNumberOfCells;
		  bool @bool = true;
		  for (sbyte b1 = 0; b1 < j; b1++)
		  {
			string str = null;
			str = notNull(paramHSSFSheet.getRow(b).getCell(b1));
			if (!str.Equals(""))
			{
			  @bool = false;
			}
		  }
		  if (@bool)
		  {
			return b;
		  }
		}
		return i;
	  }

	  private GroupCode addGroupCode1(string paramString1, string paramString2, string paramString3)
	  {
		GroupCodeTable groupCodeTable = new GroupCodeTable();
		groupCodeTable.GroupCode = paramString1;
		groupCodeTable.Title = paramString2;
		groupCodeTable.Notes = "";
		groupCodeTable.Unit = "";
		groupCodeTable.UnitFactor = BigDecimalMath.ONE;
		groupCodeTable.Unit = "";
		groupCodeTable.EditorId = "admin";
		groupCodeTable.Description = "";
		groupCodeTable.Notes = paramString3;
		groupCodeTable.LastUpdate = this.lastUpdate;
		return groupCodeTable;
	  }

	  private GroupCode addGroupCode2(string paramString1, string paramString2, string paramString3)
	  {
		GekCodeTable gekCodeTable = new GekCodeTable();
		gekCodeTable.GroupCode = paramString1;
		gekCodeTable.Title = paramString2;
		gekCodeTable.Notes = "";
		gekCodeTable.Unit = "";
		gekCodeTable.UnitFactor = BigDecimalMath.ONE;
		gekCodeTable.Unit = "";
		gekCodeTable.EditorId = "admin";
		gekCodeTable.Description = "";
		gekCodeTable.Notes = paramString3;
		gekCodeTable.LastUpdate = this.lastUpdate;
		return gekCodeTable;
	  }

	  private string notNull(HSSFCell paramHSSFCell)
	  {
		string str = "";
		if (paramHSSFCell == null)
		{
		  return "";
		}
		if (paramHSSFCell != null && paramHSSFCell.CellType == 0)
		{
		  str = "" + paramHSSFCell.NumericCellValue;
		  if (str.EndsWith(".0", StringComparison.Ordinal))
		  {
			str = "" + (long)paramHSSFCell.NumericCellValue;
		  }
		}
		else if (paramHSSFCell != null && paramHSSFCell.CellType == 2)
		{
		  CellValue cellValue = null;
		  try
		  {
			cellValue = this.o_evaluator.evaluate(paramHSSFCell);
		  }
		  catch (Exception)
		  {
			Console.WriteLine("Could not evaluate: " + paramHSSFCell);
			return paramHSSFCell.ToString();
		  }
		  if (cellValue.CellType == 0)
		  {
			str = "" + cellValue.NumberValue;
		  }
		  else if (cellValue.CellType == 1)
		  {
			str = cellValue.StringValue;
		  }
		  else
		  {
			return "";
		  }
		}
		else
		{
		  str = paramHSSFCell.RichStringCellValue.String;
		}
		return (string.ReferenceEquals(str, null)) ? "" : str;
	  }

	  private decimal notNullBigDecimal(HSSFCell paramHSSFCell, double paramDouble)
	  {
		decimal bigDecimal = new BigDecimalFixed("" + paramDouble);
		if (paramHSSFCell == null)
		{
		  return bigDecimal;
		}
		if (paramHSSFCell.CellType == 0)
		{
		  bigDecimal = new BigDecimalFixed("" + paramHSSFCell.NumericCellValue);
		}
		else if (paramHSSFCell.CellType == 2)
		{
		  CellValue cellValue = this.o_evaluator.evaluate(paramHSSFCell);
		  if (cellValue.CellType == 0)
		  {
			bigDecimal = new BigDecimalFixed("" + cellValue.NumberValue);
		  }
		}
		else
		{
		  try
		  {
			bigDecimal = new decimal(paramHSSFCell.RichStringCellValue.String);
		  }
		  catch (Exception)
		  {
			return bigDecimal;
		  }
		}
		return bigDecimal;
	  }

	  public static void migrate(string paramString1, string paramString2, string paramString3)
	  {
		  new CCCMigrationUtil(paramString1, paramString2, paramString3);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\CCCMigrationUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}