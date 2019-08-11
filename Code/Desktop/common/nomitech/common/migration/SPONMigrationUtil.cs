using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Numerics;

namespace Desktop.common.nomitech.common.migration
{
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using AssemblyEquipmentTable = nomitech.common.db.local.AssemblyEquipmentTable;
	using AssemblyMaterialTable = nomitech.common.db.local.AssemblyMaterialTable;
	using AssemblySubcontractorTable = nomitech.common.db.local.AssemblySubcontractorTable;
	using AssemblyTable = nomitech.common.db.local.AssemblyTable;
	using EquipmentTable = nomitech.common.db.local.EquipmentTable;
	using GroupCodeTable = nomitech.common.db.local.GroupCodeTable;
	using MaterialTable = nomitech.common.db.local.MaterialTable;
	using SubcontractorTable = nomitech.common.db.local.SubcontractorTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using BlankResourceInitializer = nomitech.common.expr.boqitem.BlankResourceInitializer;
	using SponLineItem = Desktop.common.nomitech.common.migration.spon.SponLineItem;
	using SponLineTimeLoader = Desktop.common.nomitech.common.migration.spon.SponLineTimeLoader;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using Session = org.hibernate.Session;
	using Transaction = org.hibernate.Transaction;

	public class SPONMigrationUtil
	{
	  private const string CODE_PREFIX = "C";

	  private const double HOURS_OF_DAY = 8.0D;

	  private const double HOURS_OF_WEEK = 40.0D;

	  private const double HOURS_OF_MONTH = 160.0D;

	  private IList<SponLineItem> sponLineItemList = null;

	  private DefaultMutableTreeNode rootNode = null;

	  private Timestamp lastUpdate = new Timestamp(DateTimeHelper.CurrentUnixTimeMillis());

	  private IDictionary<string, string> unitMap = new Hashtable();

	  private IDictionary<string, double> conversionMap = new Hashtable();

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private SPONMigrationUtil(String paramString1, String paramString2) throws Exception
	  private SPONMigrationUtil(string paramString1, string paramString2)
	  {
		initializeRateConverter();
		this.sponLineItemList = SponLineTimeLoader.loadLineItems(paramString1, paramString2);
		System.Collections.IEnumerator iterator1 = this.sponLineItemList.GetEnumerator();
		this.rootNode = new DefaultMutableTreeNode();
		sbyte b;
		for (b = 0; iterator1.MoveNext(); b++)
		{
		  SponLineItem sponLineItem = (SponLineItem)iterator1.Current;
		  sponLineItem.Index = b;
		  DefaultMutableTreeNode defaultMutableTreeNode = findParentForLineItem(sponLineItem, b);
		  defaultMutableTreeNode.add(sponLineItem);
		}
		System.Collections.IEnumerator enumeration = this.rootNode.children();
		LinkedList linkedList = new LinkedList();
		while (enumeration.MoveNext())
		{
		  linkedList.AddLast(enumeration.Current);
		}
		Hashtable hashMap = new Hashtable();
		foreach (SponLineItem sponLineItem1 in linkedList)
		{
		  SponLineItem sponLineItem2 = null;
		  LinkedList linkedList1 = null;
		  System.Collections.IEnumerator enumeration1 = sponLineItem1.children();
		  Console.WriteLine("" + sponLineItem1);
		  while (enumeration1.MoveNext())
		  {
			SponLineItem sponLineItem = (SponLineItem)enumeration1.Current;
			string str = sponLineItem.Code;
			if (str.IndexOf("/", StringComparison.Ordinal) != -1)
			{
			  if (str.IndexOf("N", StringComparison.Ordinal) == -1)
			  {
				str = StringHelper.SubstringSpecial(str, str.IndexOf("/", StringComparison.Ordinal) + 1, str.Length);
			  }
			  else
			  {
				str = StringHelper.SubstringSpecial(str, str.IndexOf("/", StringComparison.Ordinal), str.Length);
			  }
			}
			if (str.Length == 3)
			{
			  sponLineItem2 = sponLineItem;
			  linkedList1 = new LinkedList();
			  hashMap[sponLineItem2] = linkedList1;
			  Console.WriteLine(" " + sponLineItem);
			  continue;
			}
			if (linkedList1 == null)
			{
			  Console.WriteLine("I was trying;" + sponLineItem);
			}
			linkedList1.AddLast(sponLineItem);
		  }
		}
		foreach (SponLineItem sponLineItem in hashMap.Keys)
		{
		  foreach (SponLineItem sponLineItem1 in (System.Collections.IList)hashMap[sponLineItem])
		  {
			sponLineItem1.removeFromParent();
		  }
		  foreach (SponLineItem sponLineItem1 in (System.Collections.IList)hashMap[sponLineItem])
		  {
			sponLineItem.add(sponLineItem1);
		  }
		}
		Session session = DatabaseDBUtil.currentSession();
		Transaction transaction = session.beginTransaction();
		try
		{
		  Console.WriteLine("\n\n\n\n");
		  enumeration = this.rootNode.preorderEnumeration();
		  b = 0;
		  while (enumeration.MoveNext())
		  {
			DefaultMutableTreeNode defaultMutableTreeNode = (DefaultMutableTreeNode)enumeration.Current;
			if (defaultMutableTreeNode.Root)
			{
			  continue;
			}
			SponLineItem sponLineItem = (SponLineItem)defaultMutableTreeNode;
			string str1 = null;
			string str2 = sponLineItem.Code;
			if (++b % 'Ǵ' == '\x0000')
			{
			  Console.WriteLine("PROCESSED: " + b + " lines");
			  transaction.commit();
			  DatabaseDBUtil.closeSession();
			  session = DatabaseDBUtil.currentSession();
			  transaction = session.beginTransaction();
			}
			if (b % '✐' == '\x0000')
			{
			  Thread.Sleep(2000L);
			}
			if (sponLineItem.Composite)
			{
			  if (defaultMutableTreeNode.Path.length == 2)
			  {
				str1 = str2;
			  }
			  else if (defaultMutableTreeNode.Path.length == 3)
			  {
				str1 = str2.Substring(0, 1) + "." + str2.Substring(1, str2.Length - 1);
			  }
			  else if (defaultMutableTreeNode.Path.length == 4)
			  {
				string str4 = ((SponLineItem)defaultMutableTreeNode.Parent).WbsCode;
				string str5 = StringHelper.SubstringSpecial(str2, str4.Length - 1 - "C".Length, str2.Length);
				str1 = str4 + "." + str5;
			  }
			  else
			  {
				SponLineItem sponLineItem1 = (SponLineItem)defaultMutableTreeNode.Parent;
				string str = sponLineItem1.WbsCode;
				sbyte b2 = 1;
				System.Collections.IEnumerator enumeration1 = sponLineItem1.children();
				while (enumeration1.MoveNext())
				{
				  SponLineItem sponLineItem2 = (SponLineItem)enumeration1.Current;
				  if (sponLineItem2.Equals(sponLineItem))
				  {
					break;
				  }
				  b2++;
				}
				str1 = str + "." + b2;
			  }
			}
			string str3 = "";
			for (sbyte b1 = 1; b1 < defaultMutableTreeNode.Path.length; b1++)
			{
			  str3 = str3 + " ";
			}
			if (sponLineItem.Composite)
			{
			  if (sponLineItem.Depth == 1)
			  {
				System.Collections.IEnumerator enumeration1 = sponLineItem.children();
				while (enumeration1.MoveNext())
				{
				  SponLineItem sponLineItem1 = (SponLineItem)enumeration1.Current;
				  sponLineItem1.MoreDescription.Add(sponLineItem.Description);
				  if (!string.ReferenceEquals(sponLineItem.SecondDescription, null))
				  {
					sponLineItem1.MoreSecondDescription.Add(sponLineItem.SecondDescription);
				  }
				}
				continue;
			  }
			  if (sponLineItem.ChildCount == 0)
			  {
				bool @bool = sponLineItem.NoteItem;
				SponLineItem sponLineItem1 = (SponLineItem)defaultMutableTreeNode.Parent;
				System.Collections.IEnumerator enumeration1 = sponLineItem1.children();
				bool bool1 = false;
				while (enumeration1.MoveNext())
				{
				  SponLineItem sponLineItem2 = (SponLineItem)enumeration1.Current;
				  if (sponLineItem2.Equals(sponLineItem))
				  {
					bool1 = true;
					continue;
				  }
				  if (bool1 == true)
				  {
					if (@bool)
					{
					  sponLineItem2.Notes = sponLineItem.Description;
					  setNotesToAllSubItems(sponLineItem2, sponLineItem2.Notes);
					  continue;
					}
					if (sponLineItem2.NoteItem)
					{
					  string str = sponLineItem2.Description;
					  sponLineItem2.Description = sponLineItem.Description;
					  sponLineItem2.Notes = str;
					  setNotesToAllSubItems(sponLineItem2, sponLineItem2.Notes);
					  sponLineItem.Notes = sponLineItem2.Description;
					}
				  }
				}
				continue;
			  }
			  if (sponLineItem.NoteItem)
			  {
				setNotesToAllSubItems(sponLineItem, sponLineItem.Description);
			  }
			}
			if (!string.ReferenceEquals(str1, null))
			{
			  if (!str1.StartsWith("C", StringComparison.Ordinal))
			  {
				sponLineItem.WbsCode = "C" + str1;
			  }
			  else
			  {
				sponLineItem.WbsCode = str1;
			  }
			  GroupCodeTable groupCodeTable = new GroupCodeTable();
			  groupCodeTable.GroupCode = sponLineItem.WbsCode;
			  groupCodeTable.Title = sponLineItem.makeShortTitle();
			  groupCodeTable.Unit = "";
			  groupCodeTable.UnitFactor = BigDecimalMath.ONE;
			  groupCodeTable.Description = sponLineItem.Description + "\n" + sponLineItem.Notes;
			  groupCodeTable.Notes = sponLineItem.Code;
			  groupCodeTable.EditorId = "spon";
			  session.save(groupCodeTable);
			  continue;
			}
			processSponCostItem(sponLineItem, session);
		  }
		  transaction.commit();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  transaction.rollback();
		}
		DatabaseDBUtil.closeSession();
		Console.WriteLine("\n\n\n\nUNIT MAP TO CONVERT:");
		System.Collections.IEnumerator iterator2 = this.unitMap.Values.GetEnumerator();
		while (iterator2.MoveNext())
		{
		  Console.WriteLine(iterator2.Current);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void processSponCostItem(Desktop.common.nomitech.common.migration.spon.SponLineItem paramSponLineItem, org.hibernate.Session paramSession) throws Exception
	  private void processSponCostItem(SponLineItem paramSponLineItem, Session paramSession)
	  {
		MaterialTable materialTable = null;
		SubcontractorTable subcontractorTable = null;
		EquipmentTable equipmentTable = null;
		if (paramSponLineItem.Material != null && paramSponLineItem.Material.Value != 0.0D)
		{
		  materialTable = saveOrUpdateMaterialTable(paramSession, paramSponLineItem);
		}
		if (paramSponLineItem.Labor != null && paramSponLineItem.Labor.Value != 0.0D)
		{
		  subcontractorTable = saveOrSubcontractorTable(paramSession, paramSponLineItem, paramSponLineItem.Labor);
		}
		if (paramSponLineItem.Plant != null && paramSponLineItem.Plant.Value != 0.0D)
		{
		  equipmentTable = saveOrUpdateEquipmentTable(paramSession, paramSponLineItem);
		}
		if ((materialTable != null && subcontractorTable != null) || (materialTable != null && equipmentTable != null) || (equipmentTable != null && subcontractorTable != null))
		{
		  saveOrUpdateAssemblyTable(paramSession, paramSponLineItem, materialTable, subcontractorTable, equipmentTable);
		}
		else if (paramSponLineItem.Total != null && paramSponLineItem.Total.Value != 0.0D && materialTable == null && subcontractorTable == null && equipmentTable == null)
		{
		  saveOrSubcontractorTable(paramSession, paramSponLineItem, paramSponLineItem.Total);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void saveOrUpdateAssemblyTable(org.hibernate.Session paramSession, Desktop.common.nomitech.common.migration.spon.SponLineItem paramSponLineItem, nomitech.common.db.local.MaterialTable paramMaterialTable, nomitech.common.db.local.SubcontractorTable paramSubcontractorTable, nomitech.common.db.local.EquipmentTable paramEquipmentTable) throws Exception
	  private void saveOrUpdateAssemblyTable(Session paramSession, SponLineItem paramSponLineItem, MaterialTable paramMaterialTable, SubcontractorTable paramSubcontractorTable, EquipmentTable paramEquipmentTable)
	  {
		SponLineItem sponLineItem;
		for (sponLineItem = (SponLineItem)paramSponLineItem.Parent; string.ReferenceEquals(sponLineItem.WbsCode, null); sponLineItem = (SponLineItem)sponLineItem.Parent)
		{
			;
		}
		AssemblyTable assemblyTable = BlankResourceInitializer.createBlankAssembly(null);
		assemblyTable.AssemblyId = null;
		assemblyTable.Title = paramSponLineItem.makeShortTitle();
		string str = convertToCostOSUnit(paramSponLineItem.Unit);
		if (string.ReferenceEquals(str, null))
		{
		  throw new Exception("FATAL: UNIT WAS NULL FOR " + paramSponLineItem.Unit);
		}
		assemblyTable.GroupCode = sponLineItem.WbsCode + " - " + sponLineItem.makeShortTitle();
		assemblyTable.GekCode = "";
		assemblyTable.Unit = str;
		assemblyTable.EditorId = "spon";
		assemblyTable.StateProvince = "";
		assemblyTable.Country = "GB";
		assemblyTable.Currency = "GBP";
		assemblyTable.Productivity = BigDecimalMath.ZERO;
		assemblyTable.Project = "";
		assemblyTable.PublishedRate = new BigDecimalFixed("" + convertToCostOSRate(paramSponLineItem.Unit, paramSponLineItem.Total));
		assemblyTable.PublishedRevisionCode = paramSponLineItem.Code;
		assemblyTable.Notes = "SPON Major Rate";
		assemblyTable.Description = paramSponLineItem.makeFullDescription() + "\nCODE: " + paramSponLineItem.Code;
		assemblyTable.Virtual = false;
		assemblyTable.VirtualEquipment = false;
		assemblyTable.VirtualSubcontractor = false;
		assemblyTable.VirtualLabor = false;
		assemblyTable.VirtualMaterial = false;
		assemblyTable.VirtualConsumable = false;
		assemblyTable.LastUpdate = this.lastUpdate;
		assemblyTable.Quantity = new BigDecimalFixed("0");
		assemblyTable.Accuracy = "enum.quotation.accuracy.estimated";
		assemblyTable.CreateDate = assemblyTable.LastUpdate;
		assemblyTable.CreateUserId = "spon";
		Serializable serializable = assemblyTable.AssemblyId;
		if (serializable == null)
		{
		  serializable = paramSession.save(assemblyTable);
		}
		else
		{
		  paramSession.update(assemblyTable);
		}
		assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), serializable);
		if (paramSubcontractorTable != null)
		{
		  paramSubcontractorTable = (SubcontractorTable)DatabaseDBUtil.loadBulk(typeof(SubcontractorTable), new long?[] {paramSubcontractorTable.SubcontractorId})[0];
		  AssemblySubcontractorTable assemblySubcontractorTable = new AssemblySubcontractorTable();
		  assemblySubcontractorTable.Factor1 = BigDecimalMath.ONE;
		  assemblySubcontractorTable.Factor2 = BigDecimalMath.ONE;
		  assemblySubcontractorTable.Factor3 = BigDecimalMath.ONE;
		  assemblySubcontractorTable.QuantityPerUnit = BigDecimalMath.ONE;
		  assemblySubcontractorTable.QuantityPerUnitFormula = "";
		  assemblySubcontractorTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
		  assemblySubcontractorTable.LocalFactor = BigDecimalMath.ONE;
		  assemblySubcontractorTable.LocalCountry = "";
		  assemblySubcontractorTable.LocalStateProvince = "";
		  assemblySubcontractorTable.LastUpdate = assemblyTable.LastUpdate;
		  long? long = (long?)paramSession.save(assemblySubcontractorTable);
		  assemblySubcontractorTable.AssemblySubcontractorId = long;
		  if (DatabaseDBUtil.LocalCommunication)
		  {
			paramSubcontractorTable.AssemblySubcontractorSet.Add(assemblySubcontractorTable);
			paramSession.saveOrUpdate(paramSubcontractorTable);
			assemblyTable.AssemblySubcontractorSet.Add(assemblySubcontractorTable);
			paramSession.saveOrUpdate(assemblyTable);
			assemblySubcontractorTable.SubcontractorTable = paramSubcontractorTable;
			assemblySubcontractorTable.AssemblyTable = assemblyTable;
			paramSession.saveOrUpdate(assemblySubcontractorTable);
		  }
		  else
		  {
			assemblySubcontractorTable = (AssemblySubcontractorTable)DatabaseDBUtil.associateAssemblyResource(assemblyTable, paramSubcontractorTable, assemblySubcontractorTable);
			assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), assemblyTable.Id);
		  }
		}
		if (paramMaterialTable != null)
		{
		  paramMaterialTable = (MaterialTable)DatabaseDBUtil.loadBulk(typeof(MaterialTable), new long?[] {paramMaterialTable.MaterialId})[0];
		  AssemblyMaterialTable assemblyMaterialTable = new AssemblyMaterialTable();
		  assemblyMaterialTable.Factor1 = BigDecimalMath.ONE;
		  assemblyMaterialTable.Factor2 = BigDecimalMath.ONE;
		  assemblyMaterialTable.Factor3 = BigDecimalMath.ONE;
		  assemblyMaterialTable.QuantityPerUnit = BigDecimalMath.ONE;
		  assemblyMaterialTable.QuantityPerUnitFormula = "";
		  assemblyMaterialTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
		  assemblyMaterialTable.LocalFactor = BigDecimalMath.ONE;
		  assemblyMaterialTable.LocalCountry = "";
		  assemblyMaterialTable.LocalStateProvince = "";
		  assemblyMaterialTable.LastUpdate = assemblyTable.LastUpdate;
		  long? long = (long?)paramSession.save(assemblyMaterialTable);
		  assemblyMaterialTable.AssemblyMaterialId = long;
		  if (DatabaseDBUtil.LocalCommunication)
		  {
			paramMaterialTable.AssemblyMaterialSet.Add(assemblyMaterialTable);
			paramSession.saveOrUpdate(paramMaterialTable);
			assemblyTable.AssemblyMaterialSet.Add(assemblyMaterialTable);
			paramSession.saveOrUpdate(assemblyTable);
			assemblyMaterialTable.MaterialTable = paramMaterialTable;
			assemblyMaterialTable.AssemblyTable = assemblyTable;
			paramSession.saveOrUpdate(assemblyMaterialTable);
		  }
		  else
		  {
			assemblyMaterialTable = (AssemblyMaterialTable)DatabaseDBUtil.associateAssemblyResource(assemblyTable, paramMaterialTable, assemblyMaterialTable);
			assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), assemblyTable.Id);
		  }
		}
		if (paramEquipmentTable != null)
		{
		  paramEquipmentTable = (EquipmentTable)DatabaseDBUtil.loadBulk(typeof(EquipmentTable), new long?[] {paramEquipmentTable.EquipmentId})[0];
		  AssemblyEquipmentTable assemblyEquipmentTable = new AssemblyEquipmentTable();
		  assemblyEquipmentTable.Factor1 = BigDecimalMath.ONE;
		  assemblyEquipmentTable.Factor2 = BigDecimalMath.ONE;
		  assemblyEquipmentTable.Factor3 = BigDecimalMath.ONE;
		  assemblyEquipmentTable.QuantityPerUnit = BigDecimalMath.ONE;
		  assemblyEquipmentTable.QuantityPerUnitFormula = "";
		  assemblyEquipmentTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
		  assemblyEquipmentTable.LocalFactor = BigDecimalMath.ONE;
		  assemblyEquipmentTable.LocalCountry = "";
		  assemblyEquipmentTable.LocalStateProvince = "";
		  assemblyEquipmentTable.EnergyPrice = BigDecimalMath.ZERO;
		  assemblyEquipmentTable.FuelRate = BigDecimalMath.ZERO;
		  assemblyEquipmentTable.LastUpdate = assemblyTable.LastUpdate;
		  long? long = (long?)paramSession.save(assemblyEquipmentTable);
		  assemblyEquipmentTable.AssemblyEquipmentId = long;
		  if (DatabaseDBUtil.LocalCommunication)
		  {
			paramEquipmentTable.AssemblyEquipmentSet.Add(assemblyEquipmentTable);
			paramSession.saveOrUpdate(paramEquipmentTable);
			assemblyTable.AssemblyEquipmentSet.Add(assemblyEquipmentTable);
			paramSession.saveOrUpdate(assemblyTable);
			assemblyEquipmentTable.EquipmentTable = paramEquipmentTable;
			assemblyEquipmentTable.AssemblyTable = assemblyTable;
			paramSession.saveOrUpdate(assemblyEquipmentTable);
		  }
		  else
		  {
			assemblyEquipmentTable = (AssemblyEquipmentTable)DatabaseDBUtil.associateAssemblyResource(assemblyTable, paramEquipmentTable, assemblyEquipmentTable);
			assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), assemblyTable.Id);
		  }
		}
		assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), assemblyTable.Id);
		assemblyTable.recalculate();
		paramSession.update(assemblyTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private nomitech.common.db.local.MaterialTable saveOrUpdateMaterialTable(org.hibernate.Session paramSession, Desktop.common.nomitech.common.migration.spon.SponLineItem paramSponLineItem) throws Exception
	  private MaterialTable saveOrUpdateMaterialTable(Session paramSession, SponLineItem paramSponLineItem)
	  {
		SponLineItem sponLineItem;
		for (sponLineItem = (SponLineItem)paramSponLineItem.Parent; string.ReferenceEquals(sponLineItem.WbsCode, null); sponLineItem = (SponLineItem)sponLineItem.Parent)
		{
			;
		}
		null = BlankResourceInitializer.createBlankMaterial(null);
		null.MaterialId = null;
		null.Title = paramSponLineItem.makeShortTitle();
		string str = convertToCostOSUnit(paramSponLineItem.Unit);
		if (string.ReferenceEquals(str, null))
		{
		  throw new Exception("FATAL: UNIT WAS NULL FOR " + paramSponLineItem.Unit);
		}
		null.GroupCode = sponLineItem.WbsCode + " - " + sponLineItem.makeShortTitle();
		null.GekCode = "";
		null.ExtraCode1 = "";
		null.ExtraCode2 = "";
		null.ExtraCode3 = "";
		null.ExtraCode4 = "";
		null.ExtraCode5 = "";
		null.ExtraCode6 = "";
		null.ExtraCode7 = "";
		null.ExtraCode8 = "";
		null.ExtraCode9 = "";
		null.ExtraCode10 = "";
		null.Unit = str;
		null.EditorId = "spon";
		null.Weight = new BigDecimalFixed("0");
		null.WeightUnit = "KG";
		null.RawMaterial = "enum.rm.unspecified";
		null.RawMaterialReliance = new BigDecimalFixed("100");
		null.Rate = new BigDecimalFixed("" + convertToCostOSRate(paramSponLineItem.Unit, paramSponLineItem.Material));
		null.Project = "";
		null.Country = "GB";
		null.StateProvince = "";
		null.Currency = "GBP";
		null.Notes = "SPON Major Rate";
		null.Description = paramSponLineItem.makeFullDescription() + "\nCODE: " + paramSponLineItem.Code;
		null.LastUpdate = this.lastUpdate;
		null.Accuracy = "enum.quotation.accuracy.estimated";
		null.Inclusion = "enum.inclusion.matonly";
		null.Quantity = new BigDecimalFixed(0);
		null.DistanceToSite = new BigDecimalFixed(0);
		null.DistanceUnit = "MILE";
		null.ShipmentRate = new BigDecimalFixed(0);
		null.FabricationRate = new BigDecimalFixed(0);
		null.TotalRate = null.Rate;
		null.CreateDate = this.lastUpdate;
		null.CreateUserId = "spon";
		null.recalculate();
		long? long = null.MaterialId;
		if (long == null)
		{
		  long = (long?)paramSession.save(null);
		}
		else
		{
		  paramSession.update(null);
		}
		return (MaterialTable)DatabaseDBUtil.loadBulk(typeof(MaterialTable), new long?[] {long})[0];
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private nomitech.common.db.local.SubcontractorTable saveOrSubcontractorTable(org.hibernate.Session paramSession, Desktop.common.nomitech.common.migration.spon.SponLineItem paramSponLineItem, System.Nullable<double> paramDouble) throws Exception
	  private SubcontractorTable saveOrSubcontractorTable(Session paramSession, SponLineItem paramSponLineItem, double? paramDouble)
	  {
		SponLineItem sponLineItem;
		for (sponLineItem = (SponLineItem)paramSponLineItem.Parent; string.ReferenceEquals(sponLineItem.WbsCode, null); sponLineItem = (SponLineItem)sponLineItem.Parent)
		{
			;
		}
		null = BlankResourceInitializer.createBlankSubcontractor(null);
		null.SubcontractorId = null;
		null.Title = paramSponLineItem.makeShortTitle();
		string str = convertToCostOSUnit(paramSponLineItem.Unit);
		if (string.ReferenceEquals(str, null))
		{
		  throw new Exception("FATAL: UNIT WAS NULL FOR " + paramSponLineItem.Unit);
		}
		null.GroupCode = sponLineItem.WbsCode + " - " + sponLineItem.makeShortTitle();
		null.GekCode = "";
		null.ExtraCode1 = "";
		null.ExtraCode2 = "";
		null.ExtraCode3 = "";
		null.ExtraCode4 = "";
		null.ExtraCode5 = "";
		null.ExtraCode6 = "";
		null.ExtraCode7 = "";
		null.ExtraCode8 = "";
		null.ExtraCode9 = "";
		null.ExtraCode10 = "";
		null.Unit = str;
		null.EditorId = "spon";
		null.ContactPerson = "";
		null.PhoneNumber = "";
		null.MobileNumber = "";
		null.FaxNumber = "";
		null.Email = "";
		null.Url = "";
		null.Company = "";
		null.Performance = "8";
		null.Address = "";
		null.City = "";
		null.IKA = BigDecimalMath.ZERO;
		null.SubMaterialRate = BigDecimalMath.ZERO;
		null.Rate = new BigDecimalFixed("" + convertToCostOSRate(paramSponLineItem.Unit, paramDouble));
		null.Project = "";
		null.Country = "GB";
		null.StateProvince = "";
		null.Currency = "GBP";
		null.Accuracy = "enum.quotation.accuracy.estimated";
		null.Inclusion = "enum.inclusion.subonly";
		null.Quantity = new BigDecimalFixed(0);
		null.Notes = "SPON Major Rate";
		null.Description = paramSponLineItem.makeFullDescription() + "\nCODE: " + paramSponLineItem.Code;
		null.LastUpdate = this.lastUpdate;
		null.CreateDate = this.lastUpdate;
		null.CreateUserId = "spon";
		null.recalculate();
		long? long = null.SubcontractorId;
		if (long == null)
		{
		  long = (long?)paramSession.save(null);
		}
		else
		{
		  paramSession.update(null);
		}
		return (SubcontractorTable)DatabaseDBUtil.loadBulk(typeof(SubcontractorTable), new long?[] {long})[0];
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private nomitech.common.db.local.EquipmentTable saveOrUpdateEquipmentTable(org.hibernate.Session paramSession, Desktop.common.nomitech.common.migration.spon.SponLineItem paramSponLineItem) throws Exception
	  private EquipmentTable saveOrUpdateEquipmentTable(Session paramSession, SponLineItem paramSponLineItem)
	  {
		SponLineItem sponLineItem;
		for (sponLineItem = (SponLineItem)paramSponLineItem.Parent; string.ReferenceEquals(sponLineItem.WbsCode, null); sponLineItem = (SponLineItem)sponLineItem.Parent)
		{
			;
		}
		double? double = convertToCostOSRate(paramSponLineItem.Unit, paramSponLineItem.Plant);
		null = BlankResourceInitializer.createBlankEquipment(null);
		null.EquipmentId = null;
		string str1 = paramSponLineItem.makeShortTitle();
		null.Title = str1;
		null.Model = "";
		null.Make = "";
		string str2 = convertToCostOSUnit(paramSponLineItem.Unit);
		if (string.ReferenceEquals(str2, null))
		{
		  throw new Exception("FATAL: UNIT WAS NULL FOR " + paramSponLineItem.Unit);
		}
		null.GroupCode = sponLineItem.WbsCode + " - " + sponLineItem.makeShortTitle();
		null.GekCode = "";
		null.ExtraCode1 = "";
		null.ExtraCode2 = "";
		null.ExtraCode3 = "";
		null.ExtraCode4 = "";
		null.ExtraCode5 = "";
		null.ExtraCode6 = "";
		null.ExtraCode7 = "";
		null.ExtraCode8 = "";
		null.ExtraCode9 = "";
		null.ExtraCode10 = "";
		null.Country = "GB";
		null.StateProvince = "";
		null.Unit = str2;
		null.EditorId = "spon";
		null.Unit = "HOUR";
		if (str2.Equals("DAY"))
		{
		  double = Convert.ToDouble(double.Value * 0.125D);
		}
		else if (str2.Equals("WEEK"))
		{
		  double = Convert.ToDouble(double.Value * 0.025D);
		}
		else if (str2.Equals("MONTH"))
		{
		  double = Convert.ToDouble(double.Value * 0.00625D);
		}
		if (str1.ToLower().IndexOf("diesel", StringComparison.Ordinal) != -1)
		{
		  null.FuelType = "DIESEL";
		}
		else if (str1.ToLower().IndexOf("gas", StringComparison.Ordinal) != -1)
		{
		  null.FuelType = "PETROL";
		}
		else if (str1.ToLower().IndexOf("electric", StringComparison.Ordinal) != -1)
		{
		  null.FuelType = "ELECTRIC";
		}
		else
		{
		  null.FuelType = "OTHER";
		}
		null.DepreciationCalculationMethod = EquipmentTable.USER_DEFINED_METHOD;
		null.DepreciationYears = BigInteger.Parse("6");
		null.OccupationalFactor = new BigDecimalFixed("0.73");
		null.OccupationHoursPerMonth = new BigDecimalFixed("175.0");
		null.InitAquasitionPrice = new BigDecimalFixed("0.0");
		null.InterestRate = new BigDecimalFixed("0.065");
		null.LubricatesRate = new BigDecimalFixed("0");
		null.TiresRate = new BigDecimalFixed("0");
		null.FuelConsumption = new BigDecimalFixed("0");
		null.SparePartsRate = new BigDecimalFixed("0");
		null.ReservationRate = new BigDecimalFixed("" + double);
		null.DepreciationRate = new BigDecimalFixed("0");
		null.FuelRate = new BigDecimalFixed("0");
		null.TotalRate = new BigDecimalFixed("" + double);
		null.Currency = "GBP";
		null.Notes = "SPON Major Rate";
		null.Description = paramSponLineItem.makeFullDescription() + "\nCODE: " + paramSponLineItem.Code;
		null.LastUpdate = this.lastUpdate;
		null.CreateDate = this.lastUpdate;
		null.CreateUserId = "spon";
		null.recalculate();
		long? long = null.EquipmentId;
		if (long == null)
		{
		  long = (long?)paramSession.save(null);
		}
		else
		{
		  paramSession.update(null);
		}
		return (EquipmentTable)DatabaseDBUtil.loadBulk(typeof(EquipmentTable), new long?[] {long})[0];
	  }

	  private void initializeRateConverter()
	  {
		this.unitMap["nr"] = "EACH";
		this.unitMap["sheet"] = "EACH";
		this.unitMap["set"] = "SET";
		this.unitMap["pair"] = "PAIR";
		this.unitMap["hour"] = "HOUR";
		this.unitMap["item"] = "EACH";
		this.unitMap["tonne"] = "TN";
		this.unitMap["%"] = "EACH";
		this.unitMap["100 m2"] = "HM2";
		this.unitMap["m2"] = "M2";
		this.unitMap["m3"] = "M3";
		this.unitMap["10 m2"] = "M2";
		this.unitMap["m"] = "LM";
		this.unitMap["5 ltrs"] = "LT";
		this.unitMap["kg"] = "KG";
		this.unitMap["5litre"] = "LT";
		this.unitMap["25litr"] = "LT";
		this.unitMap["100 m"] = "HLM";
		this.unitMap["50 m"] = "LM";
		this.unitMap["1000"] = "THOUSAND";
		this.conversionMap["nr"] = new double?(1.0D);
		this.conversionMap["sheet"] = new double?(1.0D);
		this.conversionMap["set"] = new double?(1.0D);
		this.conversionMap["pair"] = new double?(1.0D);
		this.conversionMap["hour"] = new double?(1.0D);
		this.conversionMap["item"] = new double?(1.0D);
		this.conversionMap["tonne"] = new double?(1.0D);
		this.conversionMap["%"] = new double?(1.0D);
		this.conversionMap["100 m2"] = new double?(1.0D);
		this.conversionMap["m2"] = new double?(1.0D);
		this.conversionMap["m3"] = new double?(1.0D);
		this.conversionMap["10 m2"] = new double?(0.1D);
		this.conversionMap["m"] = new double?(1.0D);
		this.conversionMap["5 ltrs"] = new double?(0.2D);
		this.conversionMap["kg"] = new double?(1.0D);
		this.conversionMap["5litre"] = new double?(0.2D);
		this.conversionMap["25litr"] = new double?(0.04D);
		this.conversionMap["100 m"] = new double?(1.0D);
		this.conversionMap["50 m"] = new double?(0.02D);
		this.conversionMap["1000"] = new double?(1.0D);
	  }

	  private string convertToCostOSUnit(string paramString)
	  {
		if (string.ReferenceEquals(this.unitMap[paramString], null))
		{
		  Console.WriteLine("UNIT: " + paramString + " IS NULL");
		}
		return (string)this.unitMap[paramString];
	  }

	  private double? convertToCostOSRate(string paramString, double? paramDouble)
	  {
		if (this.conversionMap[paramString] == null)
		{
		  Console.WriteLine("UNIT: " + paramString + " IS NULL");
		}
		return Convert.ToDouble(paramDouble.Value * ((double?)this.conversionMap[paramString]).Value);
	  }

	  private void setNotesToAllSubItems(SponLineItem paramSponLineItem, string paramString)
	  {
		System.Collections.IEnumerator enumeration = paramSponLineItem.preorderEnumeration();
		while (enumeration.MoveNext())
		{
		  SponLineItem sponLineItem = (SponLineItem)enumeration.Current;
		  if (sponLineItem.Notes.Equals(""))
		  {
			sponLineItem.Notes = paramString;
			continue;
		  }
		  sponLineItem.Notes = sponLineItem.Notes + "; " + paramString;
		}
	  }

	  private DefaultMutableTreeNode findParentForLineItem(SponLineItem paramSponLineItem, int paramInt)
	  {
		string str1 = paramSponLineItem.Code;
		string str2 = str1;
		if (str2.IndexOf("/", StringComparison.Ordinal) != -1)
		{
		  if (str2.IndexOf("N", StringComparison.Ordinal) == -1)
		  {
			str2 = StringHelper.SubstringSpecial(str2, str2.IndexOf("/", StringComparison.Ordinal) + 1, str2.Length);
		  }
		  else
		  {
			str2 = StringHelper.SubstringSpecial(str2, str2.IndexOf("/", StringComparison.Ordinal), str2.Length);
		  }
		}
		if (paramSponLineItem.Composite && str2.Length == 1)
		{
		  return this.rootNode;
		}
		if (paramSponLineItem.Composite && str2.Length == 3)
		{
		  for (int i = paramInt;; i--)
		  {
			SponLineItem sponLineItem = (SponLineItem)this.sponLineItemList[i - 1];
			if (sponLineItem.Composite && sponLineItem.Code.Length == 1)
			{
			  return sponLineItem;
			}
		  }
		}
		if (paramSponLineItem.Composite)
		{
		  int i = paramInt;
		  bool @bool = false;
		  while (i > 0)
		  {
			SponLineItem sponLineItem = (SponLineItem)this.sponLineItemList[i - 1];
			if (sponLineItem.Composite)
			{
			  if (sponLineItem.Code.Length == 1)
			  {
				return this.rootNode;
			  }
			  if (!@bool)
			  {
				if (paramInt != this.sponLineItemList.Count - 1)
				{
				  SponLineItem sponLineItem1 = (SponLineItem)this.sponLineItemList[paramInt + 1];
				  if (sponLineItem1 != null && sponLineItem1.Composite)
				  {
					return (DefaultMutableTreeNode)sponLineItem.Parent;
				  }
				}
				return sponLineItem;
			  }
			  @bool = false;
			}
			else
			{
			  @bool = true;
			}
			i--;
		  }
		}
		else
		{
		  for (int i = paramInt;; i--)
		  {
			SponLineItem sponLineItem = (SponLineItem)this.sponLineItemList[i - 1];
			if (sponLineItem.Composite)
			{
			  return sponLineItem;
			}
		  }
		}
		return this.rootNode;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void migrateFromFile(String paramString1, String paramString2) throws Exception
	  public static void migrateFromFile(string paramString1, string paramString2)
	  {
		  new SPONMigrationUtil(paramString1, paramString2);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\SPONMigrationUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}