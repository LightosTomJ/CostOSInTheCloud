using System;
using System.Collections.Generic;

namespace Models.utils
{

	using BaseTable = nomitech.common.@base.BaseTable;
	using DatabaseTable = nomitech.common.@base.DatabaseTable;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using ResourceToResourceTable = nomitech.common.@base.ResourceToResourceTable;
	using ResourceWithAssignmentsTable = nomitech.common.@base.ResourceWithAssignmentsTable;
	using AssemblyAssemblyTable = nomitech.common.db.local.AssemblyAssemblyTable;
	using AssemblyConsumableTable = nomitech.common.db.local.AssemblyConsumableTable;
	using AssemblyEquipmentTable = nomitech.common.db.local.AssemblyEquipmentTable;
	using AssemblyLaborTable = nomitech.common.db.local.AssemblyLaborTable;
	using AssemblyMaterialTable = nomitech.common.db.local.AssemblyMaterialTable;
	using AssemblySubcontractorTable = nomitech.common.db.local.AssemblySubcontractorTable;
	using AssemblyTable = nomitech.common.db.local.AssemblyTable;
	using ParamItemTable = nomitech.common.db.local.ParamItemTable;
	using BoqItemAssemblyTable = nomitech.common.db.project.BoqItemAssemblyTable;
	using BoqItemConditionTable = nomitech.common.db.project.BoqItemConditionTable;
	using BoqItemConsumableTable = nomitech.common.db.project.BoqItemConsumableTable;
	using BoqItemEquipmentTable = nomitech.common.db.project.BoqItemEquipmentTable;
	using BoqItemLaborTable = nomitech.common.db.project.BoqItemLaborTable;
	using BoqItemMaterialTable = nomitech.common.db.project.BoqItemMaterialTable;
	using BoqItemSubcontractorTable = nomitech.common.db.project.BoqItemSubcontractorTable;
	using BoqItemTable = nomitech.common.db.project.BoqItemTable;
	using QuoteItemTable = nomitech.common.db.project.QuoteItemTable;
	using UIProgress = nomitech.common.ui.UIProgress;

	using Query = org.hibernate.Query;
	using Session = org.hibernate.Session;
	using ResultTransformer = org.hibernate.transform.ResultTransformer;
	using Transformers = org.hibernate.transform.Transformers;

	public class DeepLoadItemsUtil
	{

		private static ICollection<BaseTable> listBaseTableQuery(UIProgress prgDialog, Session session, long? projectId, string qs, IList<long> ids, bool cloneResult)
		{
			return listBaseTableQuery(prgDialog, session, projectId, qs, null, ids, cloneResult);
		}

		private static ICollection<BaseTable> listBaseTableQuery(UIProgress prgDialog, Session session, long? projectId, string qs, Type bindClass, ICollection<long> ids, bool cloneResult)
		{
			IList<BaseTable> resList = new List<BaseTable>(ids.Count);
			ICollection<ICollection<long>> chunks = splitIntoChunks(ids, 1900);
			if (prgDialog != null)
			{
				prgDialog.Indeterminate = false;
				prgDialog.TotalTimes = chunks.Count;
				prgDialog.setProgress("Loading items...",0);
			}

			ResultTransformer rt = null;

			if (bindClass != null)
			{
				rt = Transformers.aliasToBean(bindClass);
			}
			foreach (ICollection<long> chunk in chunks)
			{
				Query q = session.createQuery(qs).setCacheable(false).setParameterList("ids", chunk);
				if (projectId != null)
				{
					q.setLong("prjId", projectId);
				}
				if (rt != null)
				{
					 q = q.setResultTransformer(rt);
				}
				IList<BaseTable> objs = q.list();

				foreach (BaseTable obj in objs)
				{
					if (cloneResult)
					{
						obj = (BaseTable)obj.clone();
					}
					resList.Add(obj);
				}

				if (prgDialog != null)
				{
					prgDialog.incrementProgress(1);
				}
			}

			return resList;
		}

		public static IDictionary<long, BaseTable> listBaseTableQueryMap(UIProgress prgDialog, Session session, string qs, IList<long> ids, bool cloneResult)
		{
			IDictionary<long, BaseTable> resMap = new Dictionary<long, BaseTable>(ids.Count);
			ICollection<ICollection<long>> chunks = splitIntoChunks(ids, 1900);
			if (prgDialog != null)
			{
				prgDialog.Indeterminate = false;
				prgDialog.TotalTimes = chunks.Count;
			}
			foreach (ICollection<long> chunk in chunks)
			{
				IList<BaseTable> objs = session.createQuery(qs).setCacheable(false).setParameterList("ids", chunk).list();

				foreach (BaseTable obj in objs)
				{
					if (cloneResult)
					{
						obj = (BaseTable)obj.clone();
					}
					resMap[obj.Id] = obj;
				}
				if (prgDialog != null)
				{
					prgDialog.incrementProgress(1);
				}
			}

			return resMap;
		}

	//	public static Map<Long,BaseTable> bulkLoadResourcesMap(UIProgress prgDialog, Session session, DatabaseTableDefinition tableDefinition, List ids, boolean cloneResult) {		
	//		String idFieldName = null;
	//		if ( tableDefinition instanceof GroupTableDefinition ) {
	//			idFieldName = ((GroupTableDefinition) tableDefinition).getTableFieldName()+"Id";
	//		}
	//		else {
	//			idFieldName = ((ResourceTableDefinition) tableDefinition).getTableIdFieldName();
	//		}
	//		String qs = "from "+tableDefinition.getTableName()+" as o where o."+idFieldName+" in (:ids)";		
	//		
	//		if ( tableDefinition.getTableName().equals("BoqItemTable") ) {
	//			qs = "from BoqItemTable as o left join fetch o.paramItemTable as p where o.boqitemId in (:ids)";
	//		}
	//		
	//		return listBaseTableQueryMap(prgDialog,session,qs,ids,cloneResult);
	//	}

		//	public static String generateDeepLoadLineItems(Session session, List ids) {
		//		List<LevelDetails> levelDetailsList = investigateLineAssignments(session, ids);
		//
		//		if ( levelDetailsList.size() == 0 ) { /* Nothing below the selected lines! */
		//			return "from AssemblyTable as o where o.assemblyId in (:ids)";
		//		}
		//
		//		String qs = "from AssemblyTable as o0 ";
		//
		//		for ( int i = 0; i < levelDetailsList.size(); i++ ) {
		//			LevelDetails levelDetails = levelDetailsList.get(i);
		//			String curVar = "o"+i;
		//
		//			if ( levelDetails.idsOfLabor.size() != 0 ) {
		//				//left join fetch o.boqItemLaborSet as l left join fetch l.laborTable
		//				String leftVar = "lab"+i;
		//				qs = qs + "\nleft join fetch "+curVar+".assemblyLaborSet as "+leftVar+" left join fetch "+leftVar+".laborTable ";
		//			}
		//			if ( levelDetails.idsOfSubcontractor.size() != 0 ) {
		//				//left join fetch o.boqItemLaborSet as l left join fetch l.laborTable
		//				String leftVar = "sub"+i;
		//				qs = qs + "\nleft join fetch "+curVar+".assemblySubcontractorSet as "+leftVar+" left join fetch "+leftVar+".subcontractorTable ";
		//			}
		//			if ( levelDetails.idsOfMaterial.size() != 0 ) {
		//				//left join fetch o.boqItemLaborSet as l left join fetch l.laborTable
		//				String leftVar = "mat"+i;				
		//				qs = qs + "\nleft join fetch "+curVar+".assemblyMaterialSet as "+leftVar+" left join fetch "+leftVar+".materialTable ";
		//			}
		//			if ( levelDetails.idsOfEquipment.size() != 0 ) {
		//				//left join fetch o.boqItemLaborSet as l left join fetch l.laborTable
		//				String leftVar = "equ"+i;
		//				qs = qs + "\nleft join fetch "+curVar+".assemblyEquipmentSet as "+leftVar+" left join fetch "+leftVar+".equipmentTable ";
		//			}
		//			if ( levelDetails.idsOfConsumable.size() != 0 ) {
		//				//left join fetch o.boqItemLaborSet as l left join fetch l.laborTable
		//				String leftVar = "con"+i;
		//				qs = qs + "\nleft join fetch "+curVar+".assemblyConsumableSet as "+leftVar+" left join fetch "+leftVar+".consumableTable ";
		//			}
		//
		//			if ( levelDetails.idsOfLineItems.size() != 0 ) {
		//				String leftVar = "ass"+i;
		//				qs = qs + "\nleft join fetch "+curVar+".assemblyChildSet as "+leftVar+" left join fetch "+leftVar+".childTable as o"+(i+1);					
		//			}
		//		}
		//
		//		qs = qs+"\n where o0.assemblyId in (:ids)";
		//		//System.out.println("QUERY IS: "+qs);
		//		return qs;
		//	}

		public static IList<DatabaseTable> deepLoadAssemblies(UIProgress prgDialog, Session session, long? projectId, System.Collections.IList ids, bool nullifyId)
		{
			return deepLoadAssemblies(prgDialog, session, projectId, false, ids, nullifyId);
		}

		public static IList<DatabaseTable> deepLoadAssemblies(UIProgress prgDialog, Session session, long? projectId, bool cyclic, System.Collections.IList ids, bool nullifyId)
		{
			IList<LevelDetails> levelDetailsList = fetchLineItemAssignments(session, projectId, ids);

			string qs = "from AssemblyTable as o where o.assemblyId in (:ids)";
			if (projectId != null)
			{
				qs = "from AssemblyTable as o where o.projectId = :prjId and o.assemblyId in (:ids)";
			}

			ICollection<BaseTable> boqs = listBaseTableQuery(prgDialog, session, projectId, qs, ids, false);
			IList<DatabaseTable> resultBoqs = new List<DatabaseTable>(boqs.Count);

			foreach (BaseTable dbBoq in boqs)
			{
				AssemblyTable boq = (AssemblyTable)dbBoq.clone();

				deepFillResourceItem(levelDetailsList, boq, cyclic, 0, nullifyId);

				resultBoqs.Add(boq);
			}
			//System.out.println("QUERY IS: "+qs);
			return resultBoqs;
		}

	//	public static List<DatabaseTable> deepLoadBoqItems(UIProgress prgDialog, Session session, boolean fetchResources, boolean fetchConditions, boolean fetchQuoteItems, Collection ids) {
	//		return deepLoadBoqItems(prgDialog, session, fetchResources, fetchConditions, fetchQuoteItems, false, ids);
	//	}
	//
	//	public static List<DatabaseTable> deepLoadBoqItems(UIProgress prgDialog, Session session,  boolean fetchResources, boolean fetchConditions, boolean fetchQuoteItems, boolean cyclic, boolean fetchPredicted, Collection ids) {
	//		String qs = "from BoqItemTable as o left join fetch o.paramItemTable as p where o.boqitemId in (:ids)";
	//		return deepLoadBoqItems(prgDialog, session, qs, null, fetchResources, fetchConditions, fetchQuoteItems, false, cyclic, fetchPredicted, ids);
	//	}

		public static IList<DatabaseTable> deepLoadBoqItems(UIProgress prgDialog, Session session, long? projectId, bool fetchResources, bool fetchConditions, bool fetchQuoteItems, bool cyclic, bool fetchPredicted, System.Collections.ICollection ids, bool nullifyId)
		{
			string qs = "from BoqItemTable as o left join fetch o.paramItemTable as p where o.projectId = :prjId and o.boqitemId in (:ids)";
			return deepLoadBoqItems(prgDialog, session, projectId, qs, null, fetchResources, fetchConditions, fetchQuoteItems, cyclic, fetchPredicted, ids, nullifyId);
		}

		public static IList<DatabaseTable> deepLoadBoqItems(UIProgress prgDialog, Session session, long? projectId, string qs, Type bindClass, bool fetchResources, bool fetchConditions, bool fetchQuoteItems, bool cyclic, bool fetchPredicted, System.Collections.ICollection ids, bool nullifyId)
		{
			if (ids.Count == 0)
			{
				return Collections.EMPTY_LIST;
			}
			IList<LevelDetails> levelDetailsList = fetchBoqItemAssignments(session, projectId, fetchResources, fetchConditions, fetchQuoteItems, cyclic, fetchPredicted, ids);
			//System.out.println("LEVEL IS "+levelDetailsList.size()+" deep.");
			ICollection<BaseTable> boqs = listBaseTableQuery(prgDialog, session, projectId, qs, bindClass, ids, false);
			//List<BoqItemTable> boqs = session.createQuery(qs).setCacheable(false).setParameterList("ids", ids).list();
			IList<DatabaseTable> resultBoqs = new List<DatabaseTable>(boqs.Count);

			foreach (BaseTable dbBt in boqs)
			{
				BoqItemTable dbBoq = (BoqItemTable) dbBt;
				BoqItemTable boq = (BoqItemTable)dbBoq.clone();

				if (dbBoq.ParamItemTable != null)
				{
					boq.ParamItemTable = (ParamItemTable)dbBoq.ParamItemTable.clone();
				}

				deepFillResourceItem(levelDetailsList, boq, cyclic, 0, nullifyId);

				resultBoqs.Add(boq);
			}
			//System.out.println("QUERY IS: "+qs);
			return resultBoqs;
		}

		public static IDictionary<long, DatabaseTable> deepLoadBoqItemsMap(UIProgress prgDialog, Session session, long? projectId, bool fetchResources, bool fetchConditions, bool fetchQuoteItems, bool fetchPredicted, System.Collections.IList ids, bool nullifyId)
		{
			return deepLoadBoqItemsMap(prgDialog, session, projectId, fetchResources, fetchConditions, fetchQuoteItems, false,fetchPredicted, ids, nullifyId);
		}

		public static IDictionary<long, DatabaseTable> deepLoadBoqItemsMap(UIProgress prgDialog, Session session, long? projectId, bool fetchResources, bool fetchConditions, bool fetchQuoteItems, bool cyclic, bool fetchPredicted, System.Collections.IList ids, bool nullifyId)
		{
			string qs = "from BoqItemTable as o left join fetch o.paramItemTable as p where o.projectId = :prjId and o.boqitemId in (:ids)";
			return deepLoadBoqItemsMap(prgDialog, session, projectId, qs, null, fetchResources, fetchConditions, fetchQuoteItems, cyclic,fetchPredicted, ids, nullifyId);
		}

		public static IDictionary<long, DatabaseTable> deepLoadBoqItemsMap(UIProgress prgDialog, Session session, long? projectId, string qs, Type bindClass, bool fetchResources, bool fetchConditions, bool fetchQuoteItems, bool cyclic, bool fetchPredicted, System.Collections.IList ids, bool nullifyId)
		{
			if (ids.Count == 0)
			{
				return Collections.EMPTY_MAP;
			}
			IList<LevelDetails> levelDetailsList = fetchBoqItemAssignments(session, projectId, fetchResources, fetchConditions, fetchQuoteItems, cyclic, fetchPredicted, ids);
			//System.out.println("LEVEL IS "+levelDetailsList.size()+" deep.");
			ICollection<BaseTable> boqs = listBaseTableQuery(prgDialog, session, projectId, qs, bindClass, ids, false);
			//List<BoqItemTable> boqs = session.createQuery(qs).setCacheable(false).setParameterList("ids", ids).list();
			IDictionary<long, DatabaseTable> resultMap = new Dictionary<long, DatabaseTable>(boqs.Count);

			foreach (BaseTable dbBt in boqs)
			{
				BoqItemTable dbBoq = (BoqItemTable) dbBt;
				BoqItemTable boq = (BoqItemTable)dbBoq.clone();

				if (dbBoq.ParamItemTable != null)
				{
					boq.ParamItemTable = (ParamItemTable)dbBoq.ParamItemTable.clone();
				}

				deepFillResourceItem(levelDetailsList, boq, cyclic, 0, nullifyId);

				resultMap[boq.Id] = boq;
			}
			//System.out.println("QUERY IS: "+qs);
			return resultMap;
		}

		private static void deepFillResourceItem(IList<LevelDetails> levelDetailsList, ResourceWithAssignmentsTable parentTable, bool cyclic, int level, bool nullifyId)
		{
			if (levelDetailsList.Count <= level)
			{
				if (parentTable is BoqItemTable)
				{
					BoqItemTable boqTable = (BoqItemTable)parentTable;
					boqTable.BoqItemMaterialSet = Collections.EMPTY_SET;
					boqTable.BoqItemLaborSet = Collections.EMPTY_SET;
					boqTable.BoqItemEquipmentSet = Collections.EMPTY_SET;
					boqTable.BoqItemConsumableSet = Collections.EMPTY_SET;
					boqTable.BoqItemSubcontractorSet = Collections.EMPTY_SET;
					boqTable.BoqItemAssemblySet = Collections.EMPTY_SET;
					boqTable.BoqItemConditionSet = Collections.EMPTY_SET;
					boqTable.QuoteItemSet = Collections.EMPTY_SET;
				}
				else if (parentTable is AssemblyTable)
				{
					AssemblyTable assTable = (AssemblyTable)parentTable;
					assTable.AssemblyMaterialSet = Collections.EMPTY_SET;
					assTable.AssemblyLaborSet = Collections.EMPTY_SET;
					assTable.AssemblyEquipmentSet = Collections.EMPTY_SET;
					assTable.AssemblyConsumableSet = Collections.EMPTY_SET;
					assTable.AssemblySubcontractorSet = Collections.EMPTY_SET;
					assTable.AssemblyChildSet = Collections.EMPTY_SET;
				}
				return;
			}
			LevelDetails levelDetails = levelDetailsList[level];
			long? parentId = parentTable.Id;

			IList<AssignmentWithResource> materials = notNullList(levelDetails.objsOfMaterial[parentId]);
			IList<AssignmentWithResource> labors = notNullList(levelDetails.objsOfLabor[parentId]);
			IList<AssignmentWithResource> equipments = notNullList(levelDetails.objsOfEquipment[parentId]);
			IList<AssignmentWithResource> consumables = notNullList(levelDetails.objsOfConsumable[parentId]);
			IList<AssignmentWithResource> subcontractors = notNullList(levelDetails.objsOfSubcontractor[parentId]);
			IList<AssignmentWithResource> conditions = notNullList(levelDetails.objsOfConditions[parentId]);
			IList<AssignmentWithResource> quoteItems = notNullList(levelDetails.objsOfQuoteItems[parentId]);
			IList<AssignmentWithResource> lineItems = notNullList(levelDetails.objsOfLineItems[parentId]);

			if (parentTable is BoqItemTable)
			{
				BoqItemTable boqTable = (BoqItemTable)parentTable;

				boqTable.BoqItemMaterialSet = new HashSet<BoqItemMaterialTable>(materials.Count);
				fillAssignmentSetWithData(boqTable,boqTable.BoqItemMaterialSet,materials,cyclic);

				boqTable.BoqItemLaborSet = new HashSet<BoqItemLaborTable>(labors.Count);
				fillAssignmentSetWithData(boqTable,boqTable.BoqItemLaborSet,labors,cyclic);

				boqTable.BoqItemEquipmentSet = new HashSet<BoqItemEquipmentTable>(equipments.Count);
				fillAssignmentSetWithData(boqTable,boqTable.BoqItemEquipmentSet,equipments,cyclic);

				boqTable.BoqItemSubcontractorSet = new HashSet<BoqItemSubcontractorTable>(subcontractors.Count);
				fillAssignmentSetWithData(boqTable,boqTable.BoqItemSubcontractorSet,subcontractors,cyclic);

				boqTable.BoqItemConsumableSet = new HashSet<BoqItemConsumableTable>(consumables.Count);
				fillAssignmentSetWithData(boqTable,boqTable.BoqItemConsumableSet,consumables,cyclic);

				boqTable.BoqItemConditionSet = new HashSet<BoqItemConditionTable>(conditions.Count);
				fillAssignmentSetWithData(boqTable,boqTable.BoqItemConditionSet,conditions,cyclic);

				boqTable.QuoteItemSet = new HashSet<QuoteItemTable>(quoteItems.Count);
				fillAssignmentSetWithData(boqTable,boqTable.QuoteItemSet,quoteItems,cyclic);

				boqTable.BoqItemAssemblySet = new HashSet<BoqItemAssemblyTable>(lineItems.Count);
				fillAssignmentSetWithData(boqTable,levelDetailsList,level, boqTable.BoqItemAssemblySet,lineItems,cyclic, nullifyId);
			}
			else if (parentTable is AssemblyTable)
			{
				AssemblyTable assemblyTable = (AssemblyTable)parentTable;
				if (nullifyId)
				{
					//System.out.println("SETTING NULL TO: "+parentTable.getTitle());
					assemblyTable.Id = null;
				}
				assemblyTable.AssemblyMaterialSet = new HashSet<AssemblyMaterialTable>(materials.Count);
				fillAssignmentSetWithData(assemblyTable, assemblyTable.AssemblyMaterialSet,materials,cyclic);

				assemblyTable.AssemblyLaborSet = new HashSet<AssemblyLaborTable>(labors.Count);
				fillAssignmentSetWithData(assemblyTable, assemblyTable.AssemblyLaborSet,labors,cyclic);

				assemblyTable.AssemblyEquipmentSet = new HashSet<AssemblyEquipmentTable>(equipments.Count);
				fillAssignmentSetWithData(assemblyTable, assemblyTable.AssemblyEquipmentSet,equipments,cyclic);

				assemblyTable.AssemblySubcontractorSet = new HashSet<AssemblySubcontractorTable>(subcontractors.Count);
				fillAssignmentSetWithData(assemblyTable, assemblyTable.AssemblySubcontractorSet,subcontractors,cyclic);

				assemblyTable.AssemblyConsumableSet = new HashSet<AssemblyConsumableTable>(consumables.Count);
				fillAssignmentSetWithData(assemblyTable, assemblyTable.AssemblyConsumableSet,consumables,cyclic);

				assemblyTable.AssemblyChildSet = new HashSet<AssemblyAssemblyTable>(lineItems.Count);
				fillAssignmentSetWithData(assemblyTable, levelDetailsList,level, assemblyTable.AssemblyChildSet,lineItems,cyclic, nullifyId);
			}
		}

		private static IList<AssignmentWithResource> notNullList(IList<AssignmentWithResource> list)
		{
			if (list != null)
			{
				return list;
			}
			return Collections.EMPTY_LIST;
		}

		private static void fillAssignmentSetWithData(ResourceWithAssignmentsTable parentTable, IList<LevelDetails> levelDetailsList, int level, ISet<object> assignmentSet, IList<AssignmentWithResource> assignments, bool cyclic, bool nullifyId)
		{
			foreach (AssignmentWithResource assignment in assignments)
			{
				if (cyclic)
				{
					assignment.assignmentTable.ResourceTable = parentTable;
				}
				assignmentSet.Add(assignment.assignmentTable);
				deepFillResourceItem(levelDetailsList, (ResourceWithAssignmentsTable) assignment.assignmentTable.AssignmentResourceTable, cyclic, level + 1, nullifyId);

			}
		}

		private static void fillAssignmentSetWithData(ResourceWithAssignmentsTable parentTable, ISet<object> assignmentSet, IList<AssignmentWithResource> assignments, bool cyclic)
		{
			foreach (AssignmentWithResource assignment in assignments)
			{
				if (cyclic)
				{
					assignment.assignmentTable.ResourceTable = parentTable;
				}
				assignmentSet.Add(assignment.assignmentTable);
			}
		}

		private static IList<LevelDetails> fetchLineItemAssignments(Session session, long? projectId, System.Collections.IList ids)
		{
			string projectQuery = "";
			if (projectId != null)
			{
				projectQuery = "o.projectId = :prjId and ";
			}
			IList<LevelDetails> levelDetailsList = new List<DeepLoadItemsUtil.LevelDetails>();
			LevelDetails firstLevelDetails = new LevelDetails();

			ICollection<long> idsOfLineItems = Collections.EMPTY_LIST;

			idsOfLineItems = longIdsQuery(session, "select distinct o.childTable.assemblyId from AssemblyAssemblyTable as o where " + projectQuery + "o.parentTable.assemblyId in (:ids)",projectId, ids);
			((IList<long>)firstLevelDetails.idsOfLineItems).AddRange(idsOfLineItems);
			if (idsOfLineItems.Count > 0)
			{
				firstLevelDetails.objsOfLineItems = listObjectsQuery(session,projectId, "select o.parentTable.assemblyId, o, o.childTable from AssemblyAssemblyTable as o left join fetch o.childTable where " + projectQuery + "o.parentTable.assemblyId in (:ids)", ids, false);
			}
			firstLevelDetails.objsOfEquipment = listObjectsQuery(session,projectId, "select o.assemblyTable.assemblyId, o, o.equipmentTable from AssemblyEquipmentTable as o left join fetch o.equipmentTable where " + projectQuery + "o.assemblyTable.assemblyId in (:ids)", ids, false);
			firstLevelDetails.objsOfLabor = listObjectsQuery(session,projectId, "select o.assemblyTable.assemblyId, o, o.laborTable from AssemblyLaborTable as o left join fetch o.laborTable where " + projectQuery + "o.assemblyTable.assemblyId in (:ids)", ids, false);

	//		if ( firstLevelDetails.objsOfLabor.size() > 0 ) {
	//			System.out.println("FATCH RATE IS: "+((LaborTable)firstLevelDetails.objsOfLabor.get(2)).getRate());
	//		}

			firstLevelDetails.objsOfMaterial = listObjectsQuery(session,projectId, "select o.assemblyTable.assemblyId, o, o.materialTable from AssemblyMaterialTable as o left join fetch o.materialTable as m left join fetch m.supplierTable where " + projectQuery + "o.assemblyTable.assemblyId in (:ids)", ids, false);
			firstLevelDetails.objsOfSubcontractor = listObjectsQuery(session,projectId, "select o.assemblyTable.assemblyId, o, o.subcontractorTable from AssemblySubcontractorTable as o left join fetch o.subcontractorTable where " + projectQuery + "o.assemblyTable.assemblyId in (:ids)", ids, false);
			firstLevelDetails.objsOfConsumable = listObjectsQuery(session,projectId, "select o.assemblyTable.assemblyId, o, o.consumableTable from AssemblyConsumableTable as o left join fetch o.consumableTable where " + projectQuery + "o.assemblyTable.assemblyId in (:ids)", ids, false);

			if (!firstLevelDetails.Empty)
			{
				levelDetailsList.Add(firstLevelDetails);
			}

			if (idsOfLineItems.Count != 0)
			{
				LevelDetails levelDetails = firstLevelDetails;
				do
				{
					levelDetails = new LevelDetails();
					levelDetails.objsOfEquipment = listObjectsQuery(session,projectId, "select o.assemblyTable.assemblyId, o, o.equipmentTable from AssemblyEquipmentTable as o left join fetch o.equipmentTable where " + projectQuery + "o.assemblyTable.assemblyId in (:ids)", idsOfLineItems, false);
					levelDetails.objsOfLabor = listObjectsQuery(session,projectId, "select o.assemblyTable.assemblyId, o, o.laborTable from AssemblyLaborTable as o left join fetch o.laborTable where " + projectQuery + "o.assemblyTable.assemblyId in (:ids)", idsOfLineItems, false);


					levelDetails.objsOfMaterial = listObjectsQuery(session,projectId, "select o.assemblyTable.assemblyId, o, o.materialTable from AssemblyMaterialTable as o left join fetch o.materialTable as m left join fetch m.supplierTable where " + projectQuery + "o.assemblyTable.assemblyId in (:ids)", idsOfLineItems, false);
					levelDetails.objsOfSubcontractor = listObjectsQuery(session,projectId, "select o.assemblyTable.assemblyId, o, o.subcontractorTable from AssemblySubcontractorTable as o left join fetch o.subcontractorTable where " + projectQuery + "o.assemblyTable.assemblyId in (:ids)", idsOfLineItems, false);
					levelDetails.objsOfConsumable = listObjectsQuery(session,projectId, "select o.assemblyTable.assemblyId, o, o.consumableTable from AssemblyConsumableTable as o left join fetch o.consumableTable where " + projectQuery + "o.assemblyTable.assemblyId in (:ids)", idsOfLineItems, false);
					levelDetails.objsOfLineItems = listObjectsQuery(session,projectId, "select o.parentTable.assemblyId, o, o.childTable from AssemblyAssemblyTable as o left join fetch o.childTable where " + projectQuery + "o.parentTable.assemblyId in (:ids)", idsOfLineItems, false);

					idsOfLineItems = longIdsQuery(session, "select distinct o.childTable.assemblyId from AssemblyAssemblyTable as o where " + projectQuery + "o.parentTable.assemblyId in (:ids)",projectId, idsOfLineItems);
					((IList<long>)levelDetails.idsOfLineItems).AddRange(idsOfLineItems);

					if (!levelDetails.Empty)
					{
						levelDetailsList.Add(levelDetails);
					}
				} while (levelDetails.idsOfLineItems.Count != 0);
			}

			return levelDetailsList;
		}

		private static IList<LevelDetails> fetchBoqItemAssignments(Session session, long? projectId, bool fetchResources, bool fetchConditions, bool fetchQuoteItems, bool cyclic, bool fetchPredicted, System.Collections.ICollection ids)
		{
			IList<LevelDetails> levelDetailsList = new List<DeepLoadItemsUtil.LevelDetails>();
			LevelDetails firstLevelDetails = new LevelDetails();

			ICollection<long> idsOfLineItems = Collections.EMPTY_LIST;
			if (fetchResources)
			{
				idsOfLineItems = longIdsQuery(session, "select distinct o.assemblyTable.assemblyId from BoqItemAssemblyTable as o where o.projectId = :prjId and o.boqItemTable.boqitemId in (:ids)", projectId, ids);
				((IList<long>)firstLevelDetails.idsOfLineItems).AddRange(idsOfLineItems);
				if (idsOfLineItems.Count > 0)
				{
					firstLevelDetails.objsOfLineItems = listObjectsQuery(session, projectId, "select o.boqItemTable.boqitemId, o, o.assemblyTable from BoqItemAssemblyTable as o left join fetch o.assemblyTable where o.projectId = :prjId and o.boqItemTable.boqitemId in (:ids)", ids, fetchPredicted);
				}
				firstLevelDetails.objsOfEquipment = listObjectsQuery(session, projectId,"select o.boqItemTable.boqitemId, o, o.equipmentTable from BoqItemEquipmentTable as o left join fetch o.equipmentTable where o.projectId = :prjId and o.boqItemTable.boqitemId in (:ids)", ids, fetchPredicted);
				firstLevelDetails.objsOfLabor = listObjectsQuery(session, projectId,"select o.boqItemTable.boqitemId, o, o.laborTable from BoqItemLaborTable as o left join fetch o.laborTable where o.projectId = :prjId and o.boqItemTable.boqitemId in (:ids)", ids, fetchPredicted);
				firstLevelDetails.objsOfMaterial = listObjectsQuery(session, projectId,"select o.boqItemTable.boqitemId, o, o.materialTable from BoqItemMaterialTable as o left join fetch o.materialTable as m left join fetch m.supplierTable where o.projectId = :prjId and o.boqItemTable.boqitemId in (:ids)", ids, fetchPredicted);
				firstLevelDetails.objsOfSubcontractor = listObjectsQuery(session, projectId,"select o.boqItemTable.boqitemId, o, o.subcontractorTable from BoqItemSubcontractorTable as o left join fetch o.subcontractorTable where o.projectId = :prjId and o.boqItemTable.boqitemId in (:ids)", ids, fetchPredicted);
				firstLevelDetails.objsOfConsumable = listObjectsQuery(session, projectId,"select o.boqItemTable.boqitemId, o, o.consumableTable from BoqItemConsumableTable as o left join fetch o.consumableTable where o.projectId = :prjId and o.boqItemTable.boqitemId in (:ids)", ids, fetchPredicted);
			}

			if (fetchConditions)
			{
				firstLevelDetails.objsOfConditions = listObjectsQuery(session, projectId, "select o.boqItemTable.boqitemId, o, o.conditionTable from BoqItemConditionTable as o left join fetch o.conditionTable where o.projectId = :prjId and o.boqItemTable.boqitemId in (:ids)", ids, false);
			}
			if (fetchQuoteItems)
			{
				firstLevelDetails.objsOfQuoteItems = listObjectsQuery(session, projectId, "select o.boqItemTable.boqitemId, o, o.quotationTable from QuoteItemTable as o left join fetch o.quotationTable where o.projectId = :prjId and o.boqItemTable.boqitemId in (:ids)", ids, false);
			}

			if (!firstLevelDetails.Empty)
			{
				levelDetailsList.Add(firstLevelDetails);
			}

			if (idsOfLineItems.Count != 0)
			{
				LevelDetails levelDetails = firstLevelDetails;
				do
				{
					levelDetails = new LevelDetails();
					levelDetails.objsOfEquipment = listObjectsQuery(session, projectId,"select o.assemblyTable.assemblyId, o, o.equipmentTable from AssemblyEquipmentTable as o left join fetch o.equipmentTable where o.projectId = :prjId and o.assemblyTable.assemblyId in (:ids)", idsOfLineItems, false);
					levelDetails.objsOfLabor = listObjectsQuery(session, projectId,"select o.assemblyTable.assemblyId, o, o.laborTable from AssemblyLaborTable as o left join fetch o.laborTable where o.projectId = :prjId and o.assemblyTable.assemblyId in (:ids)", idsOfLineItems, false);
					levelDetails.objsOfMaterial = listObjectsQuery(session, projectId,"select o.assemblyTable.assemblyId, o, o.materialTable from AssemblyMaterialTable as o left join fetch o.materialTable as m left join fetch m.supplierTable where o.projectId = :prjId and o.assemblyTable.assemblyId in (:ids)", idsOfLineItems, false);
					levelDetails.objsOfSubcontractor = listObjectsQuery(session, projectId,"select o.assemblyTable.assemblyId, o, o.subcontractorTable from AssemblySubcontractorTable as o left join fetch o.subcontractorTable where o.projectId = :prjId and o.assemblyTable.assemblyId in (:ids)", idsOfLineItems, false);
					levelDetails.objsOfConsumable = listObjectsQuery(session, projectId,"select o.assemblyTable.assemblyId, o, o.consumableTable from AssemblyConsumableTable as o left join fetch o.consumableTable where o.projectId = :prjId and o.assemblyTable.assemblyId in (:ids)", idsOfLineItems, false);
					levelDetails.objsOfLineItems = listObjectsQuery(session, projectId,"select o.parentTable.assemblyId, o, o.childTable from AssemblyAssemblyTable as o left join fetch o.childTable where o.projectId = :prjId and o.parentTable.assemblyId in (:ids)", idsOfLineItems, false);

					idsOfLineItems = longIdsQuery(session, "select distinct o.childTable.assemblyId from AssemblyAssemblyTable as o where o.projectId = :prjId and o.parentTable.assemblyId in (:ids)", projectId, idsOfLineItems);
					((IList<long>)levelDetails.idsOfLineItems).AddRange(idsOfLineItems);

					if (!levelDetails.Empty)
					{
						levelDetailsList.Add(levelDetails);
					}
				} while (levelDetails.idsOfLineItems.Count != 0);
			}
			return levelDetailsList;
		}


		/////////////////
		// UTIL METHODS:
		/////////////////
		private static ICollection<long> longIdsQuery(Session session, string qs, long? projectId, ICollection<long> ids)
		{
			IList<long> resList = new List<long>();
			ICollection<ICollection<long>> chunks = splitIntoChunks(ids, 1900);
			foreach (ICollection<long> chunk in chunks)
			{
				Query q = session.createQuery(qs).setCacheable(false);
				if (projectId != null)
				{
					q = q.setLong("prjId",projectId);
				}
				((IList<long>)resList).AddRange(q.setParameterList("ids", chunk).list());
			}
			return resList;
		}

		private static IDictionary<long, IList<AssignmentWithResource>> listObjectsQuery(Session session, long? projectId, string qs, System.Collections.ICollection ids, bool fetchPredicted)
		{
			IDictionary<long, IList<AssignmentWithResource>> resMap = new Dictionary<long, IList<AssignmentWithResource>>();
			ICollection<ICollection<long>> chunks = splitIntoChunks(ids, 1900);

			foreach (ICollection<long> chunk in chunks)
			{
				Query q = session.createQuery(qs).setCacheable(false).setParameterList("ids", chunk);
				if (projectId != null)
				{
					q = q.setLong("prjId", projectId);
				}
				IList<object[]> objs = q.list();

				foreach (object[] obj in objs)
				{
					long? curId = (long?)obj[0];
					IList<AssignmentWithResource> assList = resMap[curId];
					if (assList == null)
					{
						assList = new LinkedList<DeepLoadItemsUtil.AssignmentWithResource>();
						resMap[curId] = assList;
					}
					assList.Add(new AssignmentWithResource(obj,fetchPredicted));
				}
			}

			return resMap;
		}

		private static ICollection<ICollection<long>> splitIntoChunks(ICollection<long> input, int partitionSize)
		{
			System.Collections.IList resList = new List<object>(input);
			ICollection<ICollection<long>> partitions = new LinkedList<ICollection<long>>();
			for (int i = 0; i < resList.Count; i += partitionSize)
			{
				IList<long> subList = resList.subList(i, i + Math.Min(partitionSize, resList.Count - i));
				partitions.Add(subList);
			}
			return partitions;
		}
		/////////////////////////////
		// UTIL CLASSES
		private class LevelDetails
		{
			internal IList<long> idsOfLineItems = new List<long>(0);

			internal IDictionary<long, IList<AssignmentWithResource>> objsOfLineItems = new Dictionary<long, IList<AssignmentWithResource>>(0);
			internal IDictionary<long, IList<AssignmentWithResource>> objsOfEquipment = new Dictionary<long, IList<AssignmentWithResource>>(0);
			internal IDictionary<long, IList<AssignmentWithResource>> objsOfLabor = new Dictionary<long, IList<AssignmentWithResource>>(0);
			internal IDictionary<long, IList<AssignmentWithResource>> objsOfSubcontractor = new Dictionary<long, IList<AssignmentWithResource>>(0);
			internal IDictionary<long, IList<AssignmentWithResource>> objsOfConsumable = new Dictionary<long, IList<AssignmentWithResource>>(0);
			internal IDictionary<long, IList<AssignmentWithResource>> objsOfMaterial = new Dictionary<long, IList<AssignmentWithResource>>(0);

			internal IDictionary<long, IList<AssignmentWithResource>> objsOfQuoteItems = new Dictionary<long, IList<AssignmentWithResource>>(0);
			internal IDictionary<long, IList<AssignmentWithResource>> objsOfConditions = new Dictionary<long, IList<AssignmentWithResource>>(0);

			public virtual bool Empty
			{
				get
				{
					return !(objsOfLineItems.Count != 0 || objsOfEquipment.Count != 0 || objsOfLabor.Count != 0 || objsOfSubcontractor.Count != 0 || objsOfConsumable.Count != 0 || objsOfMaterial.Count != 0 || objsOfQuoteItems.Count != 0 || objsOfConditions.Count != 0);
				}
			}

		}

		private class AssignmentWithResource
		{
			internal ResourceTable resourceTable;
			internal ResourceToAssignmentTable assignmentTable;
			//private Long parentId;

			internal AssignmentWithResource(object[] res, bool fetchPersisted)
			{
				//parentId = (Long)res[0];
				assignmentTable = (ResourceToAssignmentTable)res[1];
				resourceTable = (ResourceTable)res[2];

				assignmentTable = (ResourceToAssignmentTable)assignmentTable.clone(false, false);
				if (resourceTable is ResourceToResourceTable)
				{
					bool isPredicted = fetchPersisted && resourceTable.Predicted != null && resourceTable.Predicted.booleanValue();
					if (isPredicted)
					{
						// Very slow without fetching here:
						ISet<object> historySet = resourceTable.ResourceHistorySet;
						resourceTable = ((ResourceToResourceTable)resourceTable).copyWithParent();
						resourceTable.ResourceHistorySet = historySet;
					}
					else
					{
						resourceTable = ((ResourceToResourceTable)resourceTable).copyWithParent();
					}
				}
				else
				{
					bool isPredicted = fetchPersisted && resourceTable.Predicted != null && resourceTable.Predicted.booleanValue();
					if (isPredicted)
					{
						// Very slow without fetching here:
						ISet<object> historySet = resourceTable.ResourceHistorySet;
						resourceTable = (ResourceTable)resourceTable.clone();
						resourceTable.ResourceHistorySet = historySet;
					}
					else
					{
						resourceTable = (ResourceTable)resourceTable.clone();
					}

					//System.out.println("Loaded -> "+resourceTable.getTitle()+" -> "+resourceTable.getClass()+" -> "+resourceTable.getTableRate());
				}

				assignmentTable.AssignmentResourceTable = resourceTable;
			}


		}
	}

}