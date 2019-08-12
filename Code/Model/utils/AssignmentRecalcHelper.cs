using System;
using System.Collections.Generic;

namespace Model.utils
{

	using ResourceTableDefinition = nomitech.common.data.definition.ResourceTableDefinition;
	using LayoutTable = nomitech.common.db.layout.LayoutTable;
	using AssemblyTable = nomitech.common.db.local.AssemblyTable;
	using ConsumableTable = nomitech.common.db.local.ConsumableTable;
	using EquipmentTable = nomitech.common.db.local.EquipmentTable;
	using LaborTable = nomitech.common.db.local.LaborTable;
	using MaterialTable = nomitech.common.db.local.MaterialTable;
	using SubcontractorTable = nomitech.common.db.local.SubcontractorTable;
	using RateBuildUpColumnsTable = nomitech.common.db.project.RateBuildUpColumnsTable;
	using UIProgress = nomitech.common.ui.UIProgress;
	using StringUtils = nomitech.common.util.StringUtils;

	using Session = org.hibernate.Session;

	public class AssignmentRecalcHelper
	{

		public static void bottomUpRecalculate(UIProgress prgDialog, Session session, long? projectId, ResourceTableDefinition tableDefinition, ICollection<long> recalcIds, bool updateBuildUps)
		{

			//AssignmentTableDefinition assignmentTableDefinition = tableDefinition.getAssignmentTableDefinition();		
			if (tableDefinition.TableClass.Equals(typeof(SubcontractorTable)))
			{
				recalculateSubcontractorParents(session, projectId, recalcIds,updateBuildUps);
			}
			else if (tableDefinition.TableClass.Equals(typeof(MaterialTable)))
			{
				recalculateMaterialParents(session, projectId, recalcIds,updateBuildUps);
			}
			else if (tableDefinition.TableClass.Equals(typeof(ConsumableTable)))
			{
				recalculateConsumableParents(session, projectId, recalcIds,updateBuildUps);
			}
			else if (tableDefinition.TableClass.Equals(typeof(LaborTable)))
			{
				recalculateLaborParents(session, projectId, recalcIds,updateBuildUps);
			}
			else if (tableDefinition.TableClass.Equals(typeof(EquipmentTable)))
			{
				recalculateEquipmentParents(session, projectId, recalcIds,updateBuildUps);
			}
			else if (tableDefinition.TableClass.Equals(typeof(AssemblyTable)))
			{
				recalculateAssemblies(session, projectId, recalcIds);
			}
		}

		public static ICollection<long> findRelatedBoqItems(UIProgress progressDialog, Session session, long? projectId, ResourceTableDefinition tableDefinition, ICollection<long> resourceIds)
		{

			if (tableDefinition.TableClass.Equals(typeof(SubcontractorTable)))
			{
				return findRelatedBoqItems(session, projectId, "SubcontractorTable", "subcontractorTable", "subcontractorId", resourceIds);
			}
			else if (tableDefinition.TableClass.Equals(typeof(MaterialTable)))
			{
				return findRelatedBoqItems(session, projectId,"MaterialTable", "materialTable", "materialId", resourceIds);
			}
			else if (tableDefinition.TableClass.Equals(typeof(ConsumableTable)))
			{
				return findRelatedBoqItems(session,projectId,"ConsumableTable", "consumableTable", "consumableId", resourceIds);
			}
			else if (tableDefinition.TableClass.Equals(typeof(LaborTable)))
			{
				return findRelatedBoqItems(session,projectId,"LaborTable", "laborTable", "laborId", resourceIds);
			}
			else if (tableDefinition.TableClass.Equals(typeof(EquipmentTable)))
			{
				return findRelatedBoqItems(session,projectId,"EquipmentTable", "equipmentTable", "equipmentId", resourceIds);
			}
			else if (tableDefinition.TableClass.Equals(typeof(AssemblyTable)))
			{
				return findRelatedBoqItems(session,projectId,"AssemblyTable", "assemblyTable", "assemblyId", resourceIds);
			}

			return Collections.EMPTY_LIST;
		}

		private static string buildUpUpdateQueryForResource(long? projectId, string tableName, string totalField, RateBuildUpColumnsTable col)
		{
			string formula = col.RowFormula;
			formula = StringUtils.replaceAll(formula, "BUR_RESOURCE_RATE", totalField);

			for (int i = 0; i < 20; i++)
			{
				formula = StringUtils.replaceAll(formula, "BUR_COLUMN" + i, "o.RATE" + i);
			}

			return "update " + tableName + " SET BURATE = (select " + formula + " from RATEBUILDUP as o JOIN PROJECTTEMPLATE as p ON o.TEMPLATEID=p.id where o.PRJID = " + projectId + " AND o.RESTYPE = '" + tableName.ToLower() + "' AND o.RESPRJID = " + tableName + "ID AND p.selected=1) "+
					"where PRJID = " + projectId;
		}

		private static void recalculateSubcontractorParents(Session session, long? projectId, ICollection<long> recalcIds, bool updateBuildUps)
		{
			if (recalcIds != null && recalcIds.Count == 0)
			{
				return;
			}

			string qs = null;
			if (updateBuildUps)
			{
				RateBuildUpColumnsTable colTable = (RateBuildUpColumnsTable)session.createQuery("from RateBuildUpColumnsTable as o where o.projectId = " + projectId + " and o.resourceType = :rt and projectTemplateTable.selected=1").setString("rt",LayoutTable.SUBCONTRACTOR).uniqueResult();
				if (colTable != null)
				{
					qs = buildUpUpdateQueryForResource(projectId, "SUBCONTRACTOR","TOTALRATE",colTable);
					if (recalcIds != null)
					{
						qs = qs + " AND SUBCONTRACTORID in (:ids)";
					}
					bulkUpdateIds(session,qs,recalcIds);
				}
			}


			//		String qs = "update AssemblySubcontractorTable as o set " +
			//				"o.finalRate = (o.subcontractorTable.totalRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit), " +
			//				"o.finalIKARate = (o.subcontractorTable.IKA*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit) " +
			//				"where o.subcontractorTable.subcontractorId in (:ids)";
			qs = "update o set " +
					"o.FRATE = (ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.QTYPUNIT), " +
					"o.FIKARATE = (c.IKA*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.QTYPUNIT), " +
					"o.FINALFIXEDCOST = ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE " +
					"FROM ASSEMBLY_SUBCONTRACTOR as o JOIN SUBCONTRACTOR as c ON o.SUBCONTRACTORID = c.SUBCONTRACTORID "+
					"where o.PRJID = " + projectId;

			if (recalcIds != null)
			{
				qs = qs + " AND o.SUBCONTRACTORID in (:ids)";
			}

			bulkUpdateIds(session,qs,recalcIds);

			IList<long> parentIds = longIdsQuery(session,"select o.assemblyTable.assemblyId from AssemblySubcontractorTable as o where o.projectId = " + projectId + " and o.subcontractorTable.subcontractorId in (:ids)",recalcIds);
			recalculateAssemblies(session, projectId, parentIds);

			//		qs = "update BoqItemSubcontractorTable as o set " +
			//				"o.TOTALUNITS = o.boqItemTable.quantity*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.quantityPerUnit " +				
			//				"o.finalRate = o.subcontractorTable.totalRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//				"o.totalCost = o.subcontractorTable.totalRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit*o.boqItemTable.quantity " +
			//				"where o.subcontractorTable.subcontractorId in (:ids)";		
			qs = "update o set " +
					"o.TOTALUNITS = p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT, " +
					"o.FRATE = ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +
					"o.FINALFIXEDCOST = ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER, " +
					"o.VARIABLECOST = ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY, " +
					"o.TOTALCOST = ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY + (ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER) " +
					"FROM BOQITEM_SUBCONTRACTOR as o JOIN SUBCONTRACTOR as c ON o.SUBCONTRACTORID = c.SUBCONTRACTORID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID "+
					"where o.PRJID = " + projectId;

			if (recalcIds != null)
			{
				qs = qs + " AND o.SUBCONTRACTORID in (:ids)";
			}

			bulkUpdateIds(session,qs,recalcIds);

			parentIds = longIdsQuery(session,"select o.boqItemTable.boqitemId from BoqItemSubcontractorTable as o where o.projectId = " + projectId + " and o.subcontractorTable.subcontractorId in (:ids)",recalcIds);
			recalculateBoqItems(session, projectId, parentIds);
		}

		private static void recalculateEquipmentParents(Session session, long? projectId, ICollection<long> recalcIds, bool updateBuildUps)
		{
			if (recalcIds.Count == 0)
			{
				return;
			}

			string qs = null;
			if (updateBuildUps)
			{
				RateBuildUpColumnsTable colTable = (RateBuildUpColumnsTable)session.createQuery("from RateBuildUpColumnsTable as o where o.projectId = " + projectId + " and o.resourceType = :rt and projectTemplateTable.selected=1").setString("rt",LayoutTable.EQUIPMENT).uniqueResult();
				if (colTable != null)
				{
					qs = buildUpUpdateQueryForResource(projectId, "EQUIPMENT","TOTALRATE",colTable) + " AND EQUIPMENTID in (:ids)";
					bulkUpdateIds(session,qs,recalcIds);
				}
			}

			//		String qs = "update AssemblyEquipmentTable as o set " +
			//				"o.finalRate = (o.equipmentTable.totalRate+o.equipmentTable.fuelRate)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit " +
			//				"where o.equipmentTable.equipmentId in (:ids)";

			qs = "update o set " +
					"o.FRATE = (ISNULL(c.BURATE,c.TOTALRATE)/o.UNITHOURS)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*(CASE WHEN p.ACTBASED = 0 THEN o.QTYPUNIT WHEN p.ACTBASED = 1 THEN CASE WHEN 1/NULLIF(p.PRODUCTIVITY,0)  is null THEN 0 ELSE 1/p.PRODUCTIVITY END END), " +
					"o.FINALFIXEDCOST = ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE " +
					"FROM ASSEMBLY_EQUIPMENT as o JOIN EQUIPMENT as c ON o.EQUIPMENTID = c.EQUIPMENTID left JOIN ASSEMBLY as p ON p.ASSEMBLYID = o.ASSEMBLYID " +
					"where o.PRJID = " + projectId + " AND c.EQUIPMENTID in (:ids)";
			bulkUpdateIds(session,qs,recalcIds);

			IList<long> parentIds = longIdsQuery(session,"select o.assemblyTable.assemblyId from AssemblyEquipmentTable as o where o.projectId = " + projectId + " and o.equipmentTable.equipmentId in (:ids)",recalcIds);
			recalculateAssemblies(session, projectId, parentIds);

			//		qs = "update BoqItemEquipmentTable as o set " +
			//				"o.TOTALUNITS = (case when o.boqItemTable.activityBased = false then (o.boqItemTable.quantity*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.quantityPerUnit) else (o.boqItemTable.DURATION*o.FACTOR1*o.FACTOR2*o.FACTOR3) end), "+
			//				"o.finalRate = o.laborTable.totalRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//				"o.totalCost = o.laborTable.totalRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit*o.boqItemTable.quantity " +
			//				"where o.equipmentTable.equipmentId in (:ids)";		

			qs = "update o set " +
					"o.TOTALUNITS =(CASE WHEN p.ACTBASED = 0 THEN p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT ELSE p.DURATION*o.FACTOR1*o.FACTOR2*o.FACTOR3 END)," +
					// equipmentRate*totalUnits / quantity
					"o.FRATE = (CASE WHEN o.QTYPUNIT = 0 then 0 else ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then o.FACTOR1*o.FACTOR2*o.FACTOR3*(o.QTYPUNIT/o.UNITHOURS)*o.LOCALFACTOR*o.COSTCENTER ELSE (o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER)*(1/NULLIF(p.ADJPROD*o.UNITHOURS,0)) END) END), " +
					// equipmentRate*totalUnits
					"o.FINALFIXEDCOST = ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER, " +
					"o.VARIABLECOST = ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT*o.LOCALFACTOR*o.COSTCENTER ELSE o.UNITHOURS*p.DURATION*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER end), " +
					"o.TOTALCOST = (CASE WHEN o.QTYPUNIT = 0 then 0 else ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then o.FACTOR1*o.FACTOR2*o.FACTOR3*(o.QTYPUNIT/o.UNITHOURS)*o.LOCALFACTOR*o.COSTCENTER ELSE  (o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER)*(1/NULLIF(p.ADJPROD*o.UNITHOURS,0)) END) END) * p.QUANTITY + (ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER) " +
					"FROM BOQITEM_EQUIPMENT as o JOIN EQUIPMENT as c ON o.EQUIPMENTID = c.EQUIPMENTID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID " +
					"where o.PRJID = " + projectId + " AND o.EQUIPMENTID in (:ids)";
			bulkUpdateIds(session,qs,recalcIds);


			parentIds = longIdsQuery(session,"select o.boqItemTable.boqitemId from BoqItemEquipmentTable as o where o.projectId = " + projectId + " and o.equipmentTable.equipmentId in (:ids)",recalcIds);
			recalculateBoqItems(session, projectId, parentIds);
		}

		private static void recalculateLaborParents(Session session, long? projectId, ICollection<long> recalcIds, bool updateBuildUps)
		{
			if (recalcIds.Count == 0)
			{
				return;
			}

			string qs = null;
			if (updateBuildUps)
			{
				RateBuildUpColumnsTable colTable = (RateBuildUpColumnsTable)session.createQuery("from RateBuildUpColumnsTable as o where o.projectId = " + projectId + " and o.resourceType = :rt and projectTemplateTable.selected=1").setString("rt",LayoutTable.LABOR).uniqueResult();
				if (colTable != null)
				{
					qs = buildUpUpdateQueryForResource(projectId, "LABOR","TOTALRATE",colTable) + " AND LABORID in (:ids)";
					bulkUpdateIds(session,qs,recalcIds);
				}
			}

			qs = "update o set " +

					"o.FRATE = (ISNULL(c.BURATE,c.TOTALRATE)/o.UNITHOURS)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*(CASE WHEN p.ACTBASED = 0 THEN o.QTYPUNIT WHEN p.ACTBASED = 1 THEN CASE WHEN 1/NULLIF(p.PRODUCTIVITY,0)  is null THEN 0 ELSE 1/p.PRODUCTIVITY END END), " +

					"o.FIKARATE = (c.IKA/o.UNITHOURS)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*(CASE WHEN p.ACTBASED = 0 THEN o.QTYPUNIT WHEN p.ACTBASED = 1 THEN CASE WHEN 1/NULLIF(p.PRODUCTIVITY,0)  is null THEN 0 ELSE 1/p.PRODUCTIVITY END END), " +

					"o.FINALFIXEDCOST = ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE " +

					"FROM ASSEMBLY_LABOR as o JOIN LABOR as c ON o.LABORID = c.LABORID left JOIN ASSEMBLY as p ON p.ASSEMBLYID = o.ASSEMBLYID " +

					"where o.PRJID = " + projectId + " AND o.LABORID in (:ids)";
			bulkUpdateIds(session,qs,recalcIds);

			IList<long> parentIds = longIdsQuery(session,"select o.assemblyTable.assemblyId from AssemblyLaborTable as o where o.projectId = " + projectId + " and o.laborTable.laborId in (:ids)",recalcIds);
			recalculateAssemblies(session, projectId, parentIds);

			qs = "update o set " +

					"o.TOTALUNITS = (CASE WHEN p.ACTBASED = 0 THEN p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT ELSE p.DURATION*o.FACTOR1*o.FACTOR2*o.FACTOR3 END), " +

					"o.FRATE = (CASE WHEN o.QTYPUNIT = 0 then 0 else ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then o.FACTOR1*o.FACTOR2*o.FACTOR3*(o.QTYPUNIT/o.UNITHOURS)*o.LOCALFACTOR*o.COSTCENTER ELSE (o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER)*(1/NULLIF(p.ADJPROD*o.UNITHOURS,0)) END) END), " +

					"o.FINALFIXEDCOST = ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER, " +

					"o.VARIABLECOST = ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT ELSE o.UNITHOURS*p.DURATION*o.FACTOR1*o.FACTOR2*o.FACTOR3 end), " +

					"o.TOTALCOST = (CASE WHEN o.QTYPUNIT = 0 then 0 else ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then o.FACTOR1*o.FACTOR2*o.FACTOR3*(o.QTYPUNIT/o.UNITHOURS)*o.LOCALFACTOR*o.COSTCENTER ELSE  (o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER)*(1/NULLIF(p.ADJPROD*o.UNITHOURS,0)) END) END) * p.QUANTITY + (ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER)" +

					"FROM BOQITEM_LABOR as o JOIN LABOR as c ON o.LABORID = c.LABORID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID " +
					"where o.PRJID = " + projectId + " AND o.LABORID in (:ids)";

			bulkUpdateIds(session,qs,recalcIds);

			parentIds = longIdsQuery(session,"select o.boqItemTable.boqitemId from BoqItemLaborTable as o where o.projectId = " + projectId + " and o.laborTable.laborId in (:ids)",recalcIds);
			recalculateBoqItems(session, projectId, parentIds);

			Console.WriteLine("PASSED: LABORS ................");
		}

		private static void recalculateMaterialParents(Session session, long? projectId, ICollection<long> recalcIds, bool updateBuildUps)
		{
			if (recalcIds.Count == 0)
			{
				return;
			}

			string qs = null;
			if (updateBuildUps)
			{
				RateBuildUpColumnsTable colTable = (RateBuildUpColumnsTable)session.createQuery("from RateBuildUpColumnsTable as o where o.projectId = " + projectId + " and o.resourceType = :rt and projectTemplateTable.selected=1").setString("rt",LayoutTable.MATERIAL).uniqueResult();
				if (colTable != null)
				{
					qs = buildUpUpdateQueryForResource(projectId, "MATERIAL","TOTALRATE",colTable) + " AND MATERIALID in (:ids)";
					bulkUpdateIds(session,qs,recalcIds);
				}
			}

			//		String qs = "update AssemblyMaterialTable as o set " +
			//				"o.finalRate = o.materialTable.totalRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit " +
			//				"where o.materialTable.materialId in (:ids)";

			qs = "update o set " +
					"o.FRATE = (ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.EXCHANGERATE*o.QTYPUNIT), " +
					"o.FINALFIXEDCOST = ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.EXCHANGERATE " +
					"FROM ASSEMBLY_MATERIAL as o JOIN MATERIAL as c ON o.MATERIALID = c.MATERIALID " +
					"where o.PRJID = " + projectId + " AND o.MATERIALID in (:ids)";
			bulkUpdateIds(session,qs,recalcIds);

			//		qs = "update BoqItemMaterialTable as o set " +
			//				"o.TOTALUNITS = o.boqItemTable.quantity*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.quantityPerUnit " +				
			//				"o.finalRate = o.materialTable.totalRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//				"o.totalCost = o.materialTable.totalRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit*o.boqItemTable.quantity " +
			////				"o.finalMaterialRate = o.materialTable.rate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			////				"o.finalShipmentRate = o.materialTable.shipmentRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			////				"o.finalFabricationRate = o.materialTable.fabricationRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			////				"o.finalEscalationRate = o.materialTable.rate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//				"where o.materialTable.materialId in (:ids)";		

			qs = "update o set " +
					"o.TOTALUNITS = p.QUANTITY*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.QTYPUNIT, " +
					"o.FRATE = ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +
					"o.FINALFIXEDCOST = ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER, " +
					"o.VARIABLECOST = ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY, " +
					"o.TOTALCOST = ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY + (ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER) " +
					"FROM BOQITEM_MATERIAL as o JOIN MATERIAL as c ON o.MATERIALID = c.MATERIALID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID " +
					"where o.PRJID = " + projectId + " AND c.MATERIALID in (:ids)";
			bulkUpdateIds(session,qs,recalcIds);

			IList<long> parentIds = longIdsQuery(session,"select o.assemblyTable.assemblyId from AssemblyMaterialTable as o where o.projectId = " + projectId + " and o.materialTable.materialId in (:ids)",recalcIds);
			recalculateAssemblies(session,projectId, parentIds);

			parentIds = longIdsQuery(session,"select o.boqItemTable.boqitemId from BoqItemMaterialTable as o where o.projectId = " + projectId + " and o.materialTable.materialId in (:ids)",recalcIds);
			recalculateBoqItems(session,projectId, parentIds);
		}

		private static void recalculateConsumableParents(Session session, long? projectId, ICollection<long> recalcIds, bool updateBuildUps)
		{
			if (recalcIds.Count == 0)
			{
				return;
			}

			string qs = null;
			if (updateBuildUps)
			{
				RateBuildUpColumnsTable colTable = (RateBuildUpColumnsTable)session.createQuery("from RateBuildUpColumnsTable as o where o.projectId = " + projectId + " and o.resourceType = :rt and projectTemplateTable.selected=1").setString("rt",LayoutTable.CONSUMABLE).uniqueResult();
				if (colTable != null)
				{
					qs = buildUpUpdateQueryForResource(projectId,"CONSUMABLE","RATE",colTable) + " AND CONSUMABLEID in (:ids)";
					bulkUpdateIds(session,qs,recalcIds);
				}
			}

			//		String qs = "update AssemblyConsumableTable as o set " +
			//				"o.finalRate = o.consumableTable.rate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit " +
			//				"where o.consumableTable.consumableId in (:ids)";
			qs = "update o set " +
					"o.FRATE = (ISNULL(c.BURATE,c.RATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.EXCHANGERATE*o.QTYPUNIT), " +
					"o.FINALFIXEDCOST = ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.EXCHANGERATE " +
					"FROM ASSEMBLY_CONSUMABLE as o JOIN CONSUMABLE as c ON o.CONSUMABLEID = c.CONSUMABLEID " +
					"where o.PRJID = " + projectId + " AND o.CONSUMABLEID in (:ids)";

			//		System.out.println("\nEXECUTING1\n: "+qs+" ids: ("+recalcIds+")");
			bulkUpdateIds(session,qs,recalcIds);

			IList<long> parentIds = longIdsQuery(session,"select o.assemblyTable.assemblyId from AssemblyConsumableTable as o where o.projectId = " + projectId + " and o.consumableTable.consumableId in (:ids)",recalcIds);
			//		System.out.println("those consumable line item parents: "+parentIds);
			recalculateAssemblies(session, projectId, parentIds);

			//		qs = "update BoqItemConsumableTable as o set " +
			//				"o.TOTALUNITS = o.boqItemTable.quantity*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.quantityPerUnit " +				
			//				"o.finalRate = o.materialTable.rate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//				"o.totalCost = o.materialTable.rate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit*o.boqItemTable.quantity " +
			//				"where o.consumableTable.consumableId in (:ids)";		

			qs = "update o set " +
					"o.TOTALUNITS = p.QUANTITY*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.QTYPUNIT, " +
					"o.FRATE = ISNULL(c.BURATE,c.RATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +
					"o.FINALFIXEDCOST = ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER, " +
					"o.VARIABLECOST = ISNULL(c.BURATE,c.RATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY, " +
					"o.TOTALCOST = ISNULL(c.BURATE,c.RATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY + (ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER) " +
					"FROM BOQITEM_CONSUMABLE as o JOIN CONSUMABLE as c ON o.CONSUMABLEID = c.CONSUMABLEID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID " +
					"where o.PRJID = " + projectId + " AND o.CONSUMABLEID in (:ids)";

			//		System.out.println("\nEXECUTING2\n: "+qs);

			bulkUpdateIds(session,qs,recalcIds);


			parentIds = longIdsQuery(session,"select o.boqItemTable.boqitemId from BoqItemConsumableTable as o where o.projectId = " + projectId + " and o.consumableTable.consumableId in (:ids)",recalcIds);
			//		System.out.println("those consumable boq parents: "+parentIds);
			recalculateBoqItems(session, projectId, parentIds);
		}

		private static void recalculateAssemblyParents(Session session, long? projectId, ICollection<long> recalcIds)
		{
			if (recalcIds.Count == 0)
			{
				return;
			}

			//		String qs = "update AssemblyAssemblyTable as o set " +
			//				"o.finalRate = o.childTable.rate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit " +
			//				"where o.childTable.assemblyId in (:ids)";

			string qs = "update o set " +
					"o.FRATE = (c.RATE*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.EXCHANGERATE*o.QTYPUNIT), " +

					"o.FINALFIXEDCOST = "
					+ "( " +
					"(select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_SUBCONTRACTOR s where s.ASSEMBLYID = o.ASSEMBLYID) + " +
					"(select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID) + " +
					"(select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_MATERIAL s where s.ASSEMBLYID = o.ASSEMBLYID) + " +
					"(select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_CONSUMABLE s where s.ASSEMBLYID = o.ASSEMBLYID) + " +
					"(select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID)"
					+ " ) * o.EXCHANGERATE*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR " +

					"FROM ASSEMBLY_CHILD as o JOIN ASSEMBLY as c ON o.CHILDID = c.ASSEMBLYID " +
					"where o.PRJID = " + projectId + " AND o.CHILDID in (:ids)";

			bulkUpdateIds(session,qs,recalcIds);

			IList<long> parentIds = longIdsQuery(session,"select o.parentTable.assemblyId from AssemblyAssemblyTable as o where o.projectId = " + projectId + " and o.childTable.assemblyId in (:ids)",recalcIds);
			recalculateAssemblies(session, projectId, parentIds);

			//		qs = "update BoqItemAssemblyTable as o set " +
			//				"o.TOTALUNITS = o.boqItemTable.quantity*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.quantityPerUnit " +				
			//				"o.finalRate = o.assemblyTable.rate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//
			//				"o.totalCost = o.assemblyTable.rate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit*o.boqItemTable.quantity, " +
			//				"o.finalLaborRate = o.assemblyTable.laborRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//				"o.laborCost = o.assemblyTable.laborRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit*o.boqItemTable.quantity, " +
			//				"o.finalMaterialRate = o.assemblyTable.materialRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//				
			//				// Those 2 until one level??
			//				"o.finalShipmentRate = (select sum(s.materialTable.shipmentRate) from AssemblyMaterialTable s where s.assemblyTable.assemblyId = o.assemblyTable.assemblyId)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//				"o.finalFabricationRate = (select sum(s.materialTable.fabricationRate) from AssemblyMaterialTable s where s.assemblyTable.assemblyId = o.assemblyTable.assemblyId)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//				
			//				"o.materialCost = o.assemblyTable.materialRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit*o.boqItemTable.quantity, " +
			//				"o.finalSubcontractorRate = o.assemblyTable.subcontractorRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//				"o.subcontractorCost = o.assemblyTable.subcontractorRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit*o.boqItemTable.quantity, " +
			//				"o.finalEquipmentRate = o.assemblyTable.equipmentRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//				"o.equipmentCost = o.assemblyTable.equipmentRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit*o.boqItemTable.quantity, " +
			//				"o.finalConsumableRate = o.assemblyTable.consumableRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//				"o.consumableCost = o.assemblyTable.consumableRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit*o.boqItemTable.quantity " +
			//
			//				"where o.assemblyTable.assemblyId in (:ids)";		

	//		String q = "select c.RATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY + "
	//				+ "((select ISNULL(sum(s.FINALFIXEDCOST),0) from BOQITEM_CONSUMABLE s where s.BOQITEMID = o.BOQITEMID) + "
	//				+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from BOQITEM_EQUIPMENT s where s.BOQITEMID = o.BOQITEMID) + "
	//				+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from BOQITEM_LABOR s where s.BOQITEMID = o.BOQITEMID) + "
	//				+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from BOQITEM_MATERIAL s where s.BOQITEMID = o.BOQITEMID) + "
	//				+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from BOQITEM_SUBCONTRACTOR s where s.BOQITEMID = o.BOQITEMID))*o.COSTCENTER as FINALFIXEDCOST "
	//				+ " FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID " +
	//				"where o.PRJID = "+projectId+" AND o.ASSEMBLYID in (:ids)";
	//		
	//		session.createSQLQuery(q).

			qs = "update o set " +
					"o.TOTALUNITS = p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT, " +

					"o.FRATE = c.RATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +

					"o.FINALFIXEDCOST = "
					+ "((select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_CHILD s where s.ASSEMBLYID = o.ASSEMBLYID) + "
					+ "	(select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_CONSUMABLE s where s.ASSEMBLYID = o.ASSEMBLYID) + "
					+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID) + "
					+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID) + "
					+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_MATERIAL s where s.ASSEMBLYID = o.ASSEMBLYID) + "
					+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_SUBCONTRACTOR s where s.ASSEMBLYID = o.ASSEMBLYID)) "
					+ "  * o.COSTCENTER*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR, " +

					"o.VARIABLECOST = c.RATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY, " + // PREVIOUS TOTAL COST

					"o.TOTALCOST = (c.RATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY) + "
					+ "((select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_CHILD s where s.ASSEMBLYID = o.ASSEMBLYID) + "
					+ "	(select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_CONSUMABLE s where s.ASSEMBLYID = o.ASSEMBLYID) + "
					+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID) + "
					+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID) + "
					+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_MATERIAL s where s.ASSEMBLYID = o.ASSEMBLYID) + "
					+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_SUBCONTRACTOR s where s.ASSEMBLYID = o.ASSEMBLYID)) "
					+ " * o.COSTCENTER*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR, " +

					"o.FLABRATE = c.LABRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +

					"o.LABCOST = c.LABRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY," +

					"o.FMATRATE = c.MATRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +

					"o.MATTOTCOST = c.MATRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY," +

					"o.FSUBRATE = c.SUBRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +

					"o.SUBCOST = c.SUBRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY," +

					"o.FEQURATE = c.EQURATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +

					"o.EQUCOST = c.EQURATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY," +

					"o.FCONRATE = c.CONRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +

					"o.CONCOST = c.CONRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY " +

					"FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID " +

					"where o.PRJID = " + projectId + " AND o.ASSEMBLYID in (:ids)";

			bulkUpdateIds(session,qs,recalcIds);

			parentIds = longIdsQuery(session,"select o.boqItemTable.boqitemId from BoqItemAssemblyTable as o where o.projectId = " + projectId + " and o.assemblyTable.assemblyId in (:ids)",recalcIds);
			recalculateBoqItems(session, projectId, parentIds);
		}

		private static void recalculateAssemblies(Session session, long? projectId, ICollection<long> ids)
		{
			if (ids != null && ids.Count == 0)
			{
				return;
			}
			//		String qs = "update AssemblyTable as o " +
			//				" set o.unitManhours = (case when o.activityBased = true then (" +
			//					"(select sum(s.quantityPerUnit*s.FACTOR1*s.FACTOR2*s.FACTOR3) from AssemblyLaborTable s where s.assemblyTable.assemblyId = o.assemblyId)+" +
			//					"(select sum(s.childTable.unitManhours) from AssemblyAssemblyTable s where s.parentTable.assemblyId = o.assemblyId)" +				
			//				") else (CASE WHEN (1/NULLIF(o.PRODUCTIVITY,0)) is null THEN 1 ELSE 1/o.PRODUCTIVITY END) end), "+
			//				" set o.unitEquipmentHours = (case when o.activityBased = true then (" +
			//					"(select sum(s.quantityPerUnit*s.FACTOR1*s.FACTOR2*s.FACTOR3) from AssemblyEquipmentTable s where s.assemblyTable.assemblyId = o.assemblyId)+" +
			//					"(select sum(s.childTable.unitEquipmentHours) from AssemblyAssemblyTable s where s.parentTable.assemblyId = o.assemblyId)" +				
			//				") else (CASE WHEN (1/NULLIF(o.PRODUCTIVITY,0)) is null THEN 1 ELSE 1/o.PRODUCTIVITY END) end), "+					
			//				"o.rate = " +
			//				"(select sum(s.finalRate) from AssemblySubcontractorTable s where s.assemblyTable.assemblyId = o.assemblyId)+" +
			//				"(select sum(s.finalRate) from AssemblyLaborTable s where s.assemblyTable.assemblyId = o.assemblyId)+" +
			//				"(select sum(s.finalRate) from AssemblyMaterialTable s where s.assemblyTable.assemblyId = o.assemblyId)+" +
			//				"(select sum(s.finalRate) from AssemblyConsumableTable s where s.assemblyTable.assemblyId = o.assemblyId)+" +
			//				"(select sum(s.finalRate) from AssemblyEquipmentTable s where s.assemblyTable.assemblyId = o.assemblyId)+" +				
			//				"(select sum(s.childTable.finalLaborRate) from AssemblyAssemblyTable s where s.parentTable.assemblyId = o.assemblyId)+" +				
			//				"(select sum(s.childTable.finalSubcontractorRate) from AssemblyAssemblyTable s where s.parentTable.assemblyId = o.assemblyId)+" +
			//				"(select sum(s.childTable.finalMaterialRate) from AssemblyAssemblyTable s where s.parentTable.assemblyId = o.assemblyId)+" +
			//				"(select sum(s.childTable.finalConsumableRate) from AssemblyAssemblyTable s where s.parentTable.assemblyId = o.assemblyId)+ " +
			//				"(select sum(s.childTable.finalEquipmentRate) from AssemblyAssemblyTable s where s.parentTable.assemblyId = o.assemblyId)," +
			//				"o.laborRate = "+
			//				"(select sum(s.finalRate) from AssemblyLaborTable s where s.assemblyTable.assemblyId = o.assemblyId)+" +
			//				"(select sum(s.childTable.finalLaborRate) from AssemblyAssemblyTable s where s.parentTable.assemblyId = o.assemblyId)," +				
			//				"o.subcontactorRate = "+
			//				"(select sum(s.finalRate) from AssemblySubcontractorTable s where s.assemblyTable.assemblyId = o.assemblyId)+" +
			//				"(select sum(s.childTable.finalSubcontractorRate) from AssemblyAssemblyTable s where s.parentTable.assemblyId = o.assemblyId)," +
			//				"o.materialRate = "+
			//				"(select sum(s.finalRate) from AssemblyMaterialTable s where s.assemblyTable.assemblyId = o.assemblyId)+" +
			//				"(select sum(s.childTable.finalMaterialRate) from AssemblyAssemblyTable s where s.parentTable.assemblyId = o.assemblyId)," +
			//				"o.consumableRate = "+
			//				"(select sum(s.finalRate) from AssemblyConsumableTable s where s.assemblyTable.assemblyId = o.assemblyId)+" +
			//				"(select sum(s.childTable.finalConsumableRate) from AssemblyAssemblyTable s where s.parentTable.assemblyId = o.assemblyId), " +
			//				"o.equipmentRate = "+
			//				"(select sum(s.finalRate) from AssemblyEquipmentTable s where s.assemblyTable.assemblyId = o.assemblyId)+" +
			//				"(select sum(s.childTable.finalEquipmentRate) from AssemblyAssemblyTable s where s.parentTable.assemblyId = o.assemblyId) " +				
			//				"where o.assemblyId in (:ids)";

			string qs = "update o set " +

					"o.UMHOURS = case when o.ACTBASED = 0 then (" +
					"(select ISNULL(sum(s.QTYPUNIT*s.FACTOR1*s.FACTOR2*s.FACTOR3),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
					"(select ISNULL(sum(c.UMHOURS),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)" +
					") else (CASE WHEN (1/NULLIF(o.PRODUCTIVITY,0)) is null THEN 1.0 ELSE 1.0/o.PRODUCTIVITY END) end," +

					"o.UEHOURS = case when o.ACTBASED = 0 then (" +
					"(select ISNULL(sum(s.QTYPUNIT*s.FACTOR1*s.FACTOR2*s.FACTOR3),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
					"(select ISNULL(sum(c.UEHOURS),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)" +
					") else (CASE WHEN (1/NULLIF(o.PRODUCTIVITY,0)) is null THEN 1.0 ELSE 1.0/o.PRODUCTIVITY END) end," +

					"o.RATE = " +
					"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_SUBCONTRACTOR s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
					"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
					"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_MATERIAL s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
					"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_CONSUMABLE s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
					"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
					"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_CHILD s where s.ASSEMBLYID = o.ASSEMBLYID)," +

					"o.LABRATE = " +
					"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
					"(select ISNULL(sum(c.LABRATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)," +

					"o.EQURATE = " +
					"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
					"(select ISNULL(sum(c.EQURATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)," +

					"o.SUBRATE = " +
					"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_SUBCONTRACTOR s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
					"(select ISNULL(sum(c.SUBRATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)," +

					"o.MATRATE = " +
					"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_MATERIAL s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
					"(select ISNULL(sum(c.MATRATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)," +

					"o.CONRATE = " +
					"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_CONSUMABLE s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
					"(select ISNULL(sum(c.CONRATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID) " +

					"FROM ASSEMBLY as o " +

					"where o.PRJID = " + projectId + " AND o.ASSEMBLYID in (:ids)";


	//		System.out.println("Assembly Query is: "+qs);
			bulkUpdateIds(session,qs,ids);

			//		System.out.println("AFTER RECALCULATION labor rate: "+session.createQuery("select o.laborRate from AssemblyTable o where o.assemblyId = "+ids.get(0)).uniqueResult());
			//		System.out.println("OR SUM ID: "+session.createSQLQuery("Select ISNULL(sum(s.FRATE),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = "+ids.get(0)).uniqueResult());

			//		System.out.println("Recalculated assemblies -> "+ids);
			recalculateAssemblyParents(session, projectId, ids);
		}

		private static void recalculateBoqItems(Session session, long? projectId, ICollection<long> ids)
		{
			if (ids.Count == 0)
			{
				return;
			}
			//		String qs = "update BoqItemTable as o " +
			//				" set o.laborManhours = "+
			//					"(select sum(s.totalUnits) from BoqItemLaborTable s where s.boqItemTable.boqitemId = o.boqitemId)+" +
			//					"(select sum(s.assemblyTable.unitManhours*o.quantity) from BoqItemAssemblyTable s where s.boqItemTable.boqitemId = o.boqitemId), " +
			//				" set o.equipmentHours = " +
			//					"(select sum(s.totalUnits) from BoqItemEquipmentTable s where s.boqItemTable.boqitemId = o.boqitemId)+" +
			//					"(select sum(s.assemblyTable.unitEquipmentHours) from BoqItemAssemblyTable s where s.boqItemTable.boqitemId = o.boqitemId), " +					
			////				"o.rate = " +
			////				"(select sum(s.finalRate) from BoqItemSubcontractorTable s where s.boqItemTable.boqitemId = o.boqitemId)+" +
			////				"(select sum(s.finalRate) from BoqItemLaborTable s where s.boqItemTable.boqitemId = o.boqitemId)+" +
			////				"(select sum(s.finalRate) from BoqItemMaterialTable s where s.boqItemTable.boqitemId = o.boqitemId)+" +
			////				"(select sum(s.finalRate) from BoqItemConsumableTable s where s.boqItemTable.boqitemId = o.boqitemId)+" +
			////				"(select sum(s.finalRate) from BoqItemEquipmentTable s where s.boqItemTable.boqitemId = o.boqitemId)+" +				
			////				"(select sum(s.finalRate) from BoqItemAssemblyTable s where s.boqItemTable.boqitemId = o.boqitemId), " +
			////				"o.fabricationRate = "+
			////				"(select sum(s.materialTable.fabricationRate*s.FACTOR1*s.FACTOR2*s.FACTOR3*s.EXCHANGERATE*s.LOCALFACTOR) from BoqItemMaterialTable s where s.boqItemTable.boqitemId = o.boqitemId)+" +
			//				/* not storing assemblies fab rates recursively...*/
			//				"o.measuredQuantity = "+
			//				"(select sum(s.finalQuantity) from BoqItemConditionTable s where s.boqItemTable.boqitemId = o.boqitemId) " +
			//				
			//				"o.assemblyRate = "+
			//				"(select sum(s.finalRate) from BoqItemAssemblyTable s where s.boqItemTable.boqitemId = o.boqitemId), " +
			//				"o.laborRate = "+
			//				"(select sum(s.finalRate) from BoqItemLaborTable s where s.boqItemTable.boqitemId = o.boqitemId)+" +
			//				"(select sum(s.finalLaborRate) from BoqItemAssemblyTable s where s.boqItemTable.boqitemId = o.boqitemId)," +				
			//				"o.subcontactorRate = "+
			//				"(select sum(s.finalRate) from BoqItemSubcontractorTable s where s.boqItemTable.boqitemId = o.boqitemId)+" +
			//				"(select sum(s.finalSubcontractorRate) from BoqItemAssemblyTable s where s.boqItemTable.boqitemId = o.boqitemId)," +
			//				"o.materialRate = "+
			//				"(select sum(s.finalRate) from BoqItemMaterialTable s where s.boqItemTable.boqitemId = o.boqitemId)+" +
			//				"(select sum(s.childTable.finalMaterialRate) from BoqItemAssemblyTable s where s.boqItemTable.boqitemId = o.boqitemId)," +
			//				"o.consumableRate = "+
			//				"(select sum(s.finalRate) from BoqItemConsumableTable s where s.boqItemTable.boqitemId = o.boqitemId)+" +
			//				"(select sum(s.childTable.finalConsumableRate) from BoqItemAssemblyTable s where s.boqItemTable.boqitemId = o.boqitemId), " +
			//				"o.equipmentRate = "+
			//				"(select sum(s.finalRate) from BoqItemEquipmentTable s where s.boqItemTable.boqitemId = o.boqitemId)+" +
			//				"(select sum(s.childTable.finalEquipmentRate) from BoqItemAssemblyTable s where s.boqItemTable.boqitemId = o.boqitemId) " +				
			//				"where o.boqitemId in (:ids)";

	//		String qs = "update o set " +
	//				"o.MANHOURS = " +
	//				"(select ISNULL(sum(s.TOTALUNITS),0) from BOQITEM_LABOR s where s.BOQITEMID = o.BOQITEMID)+" +
	//				"(select ISNULL(sum(c.UMHOURS),0) from BOQITEM_ASSEMBLY s LEFT OUTER JOIN ASSEMBLY c ON s.ASSEMBLYID = c.ASSEMBLYID where s.BOQITEMID = o.BOQITEMID)*o.QUANTITY," +
	//				"o.EQUHOURS = " +
	//				"(select ISNULL(sum(s.TOTALUNITS),0) from BOQITEM_EQUIPMENT s where s.BOQITEMID = o.BOQITEMID)+" +
	//				"(select ISNULL(sum(c.UEHOURS),0) from BOQITEM_ASSEMBLY s LEFT OUTER JOIN ASSEMBLY c ON s.ASSEMBLYID = c.ASSEMBLYID where s.BOQITEMID = o.BOQITEMID)*o.QUANTITY," +
	//				//				"o.rate = " +
	//				//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_SUBCONTRACTOR s where s.BOQITEMID = o.BOQITEMID)+" +
	//				//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_LABOR s where s.BOQITEMID = o.BOQITEMID)+" +
	//				//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_MATERIAL s where s.BOQITEMID = o.BOQITEMID)+" +
	//				//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_CONSUMABLE s where s.BOQITEMID = o.BOQITEMID)+" +
	//				//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_EQUIPMENT s where s.BOQITEMID = o.BOQITEMID)+" +
	//				//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +
	//				"o.MEASQUANT = " +
	//				"(select ISNULL(sum(s.FQTY),0) from BOQITEM_CONDITION s where s.BOQITEMID = o.BOQITEMID)," +
	//				"o.ASSRATE = " +
	//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +
	//
	//				"o.LABRATE = " +
	//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_LABOR s where s.BOQITEMID = o.BOQITEMID)+" +
	//				"(select ISNULL(sum(s.FLABRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +
	//				"o.EQURATE = " +
	//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_EQUIPMENT s where s.BOQITEMID = o.BOQITEMID)+" +
	//				"(select ISNULL(sum(s.FEQURATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +
	//				"o.SUBRATE = " +
	//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_SUBCONTRACTOR s where s.BOQITEMID = o.BOQITEMID)+" +
	//				"(select ISNULL(sum(s.FSUBRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +
	//				"o.MATRATE = " +
	//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_MATERIAL s where s.BOQITEMID = o.BOQITEMID)+" +
	//				"(select ISNULL(sum(s.FMATRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +
	//				"o.CONRATE = " +
	//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_CONSUMABLE s where s.BOQITEMID = o.BOQITEMID)+" +
	//				"(select ISNULL(sum(s.FCONRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +
	//				"o.SUBQUOTERATE = (select ISNULL(sum(bs.FRATE),0) from BOQITEM_SUBCONTRACTOR bs JOIN SUBCONTRACTOR s on bs.SUBCONTRACTORID = s.SUBCONTRACTORID where bs.BOQITEMID = o.BOQITEMID AND s.ACCURACY like '"+SubcontractorTable.QUOTED_ACCURACY+"'), " +
	//				"o.MATQUOTERATE = (select ISNULL(sum(bs.FRATE),0) from BOQITEM_MATERIAL bs JOIN MATERIAL s on bs.MATERIALID = s.MATERIALID where bs.BOQITEMID = o.BOQITEMID AND s.ACCURACY like '"+MaterialTable.QUOTED_ACCURACY+"') " +
	//
	//				"FROM BOQITEM as o " +
	//				"where o.PRJID = "+projectId+" AND o.BOQITEMID in (:ids)";

			string qs = "update o set " +
	//		
	//				"o.MANHOURS = " +
	//				"(select ISNULL(sum(m.RESUNITS),0) FROM " +
	//					"(select sum(bl.TOTALUNITS) as ResUnits "
	//					+ "FROM BOQITEM as b "
	//					+ "INNER JOIN BOQITEM_LABOR AS bl ON b.BOQITEMID=bl.BOQITEMID "
	////					+ "INNER JOIN LABOR AS l ON l.LABORID=bl.LABORID "
	//					+ "WHERE b.PRJID = " + projectId + " AND b.BOQITEMID in (:ids) "
	//					
	//					+ "UNION ALL "
	//					
	//					+ "select case when a.ACTBASED=1 THEN (sum(b.quantity*ba.QTYPUNIT*ba.FACTOR1*ba.FACTOR2*ba.FACTOR3*(al.FACTOR1*al.FACTOR2*al.FACTOR3))/a.PRODUCTIVITY) "
	//					+ "else sum(al.QTYPUNIT*al.FACTOR1*al.FACTOR2*al.FACTOR3)*ba.TOTALUNITS END as ResUnits "
	//					+ "FROM BOQITEM as b "
	//					+ "left outer JOIN  BOQITEM_ASSEMBLY AS ba ON b.BOQITEMID=ba.BOQITEMID "
	//					+ "left outer JOIN ASSEMBLY AS a ON ba.ASSEMBLYID=a.ASSEMBLYID "
	//					+ "left outer JOIN ASSEMBLY_LABOR AS al ON ba.ASSEMBLYID=al.ASSEMBLYID "
	//					+ "left outer  JOIN LABOR AS l ON l.LABORID=al.LABORID "
	//					+ "WHERE b.PRJID =  " + projectId + " AND b.BOQITEMID in (:ids) "
	//					+ "group by a.PRODUCTIVITY,a.ACTBASED,ba.TOTALUNITS "
	//
	//  					+ "UNION ALL "
	//  					
	//  					+ "select case when a4.ACTBASED=1 THEN (sum(ba.TOTALUNITS*ac2.QTYPUNIT*ac2.FACTOR1*ac2.FACTOR2*ac2.DIVIDER*(al.FACTOR1*al.FACTOR2*al.FACTOR3))/a4.PRODUCTIVITY) "
	//  					+ "else sum(al.QTYPUNIT*al.FACTOR1*al.FACTOR2*al.FACTOR3)*ba.TOTALUNITS*ac2.QTYPUNIT*ac2.FACTOR1*ac2.FACTOR2*ac2.DIVIDER END as ResUnits "
	//  					+ "FROM BOQITEM AS b "
	//  					+ "inner join  BOQITEM_ASSEMBLY as ba ON b.BOQITEMID=ba.BOQITEMID "
	//  					+ "inner join  ASSEMBLY as a ON ba.ASSEMBLYID=a.ASSEMBLYID "
	//  					+ "inner join  ASSEMBLY_CHILD as ac2 ON a.ASSEMBLYID=ac2.ASSEMBLYID "
	//  					+ "inner join  ASSEMBLY as a4 ON ac2.CHILDID=a4.ASSEMBLYID "
	//  					+ "inner join  ASSEMBLY_LABOR as al ON a4.ASSEMBLYID=al.ASSEMBLYID "
	//  					+ "inner join  LABOR as l ON al.LABORID=l.LABORID "
	//  					+ "WHERE b.PRJID = " + projectId + " AND b.BOQITEMID in (:ids) "
	//  					+ "GROUP BY  ba.TOTALUNITS,a4.PRODUCTIVITY,a4.ACTBASED,ac2.QTYPUNIT,ac2.FACTOR1,ac2.FACTOR2,ac2.DIVIDER) AS m)," + 

					"o.MANHOURS = " +
					"(select ISNULL(sum(s.TOTALUNITS),0) from BOQITEM_LABOR s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(c.UMHOURS),0) from BOQITEM_ASSEMBLY s LEFT OUTER JOIN ASSEMBLY c ON s.ASSEMBLYID = c.ASSEMBLYID where s.BOQITEMID = o.BOQITEMID)*o.QUANTITY," +

					"o.EQUHOURS = " +
					"(select ISNULL(sum(s.TOTALUNITS),0) from BOQITEM_EQUIPMENT s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(c.UEHOURS),0) from BOQITEM_ASSEMBLY s LEFT OUTER JOIN ASSEMBLY c ON s.ASSEMBLYID = c.ASSEMBLYID where s.BOQITEMID = o.BOQITEMID)*o.QUANTITY," +

					"o.MEASQUANT = " +
					"(select ISNULL(sum(s.FQTY),0) from BOQITEM_CONDITION s where s.BOQITEMID = o.BOQITEMID)," +

					"o.ASSRATE = " +
					"(select ISNULL(sum(s.FRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +

					"o.LABRATE = " +
					"(select ISNULL(sum(s.FRATE),0) from BOQITEM_LABOR s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FLABRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +

					"o.EQURATE = " +
					"(select ISNULL(sum(s.FRATE),0) from BOQITEM_EQUIPMENT s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FEQURATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +

					"o.SUBRATE = " +
					"(select ISNULL(sum(s.FRATE),0) from BOQITEM_SUBCONTRACTOR s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FSUBRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +

					"o.MATRATE = " +
					"(select ISNULL(sum(s.FRATE),0) from BOQITEM_MATERIAL s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FMATRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +

					"o.CONRATE = " +
					"(select ISNULL(sum(s.FRATE),0) from BOQITEM_CONSUMABLE s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FCONRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +

					"o.SUBQUOTERATE = (select ISNULL(sum(bs.FRATE),0) from BOQITEM_SUBCONTRACTOR bs JOIN SUBCONTRACTOR s on bs.SUBCONTRACTORID = s.SUBCONTRACTORID where bs.BOQITEMID = o.BOQITEMID AND s.ACCURACY like '" + SubcontractorTable.QUOTED_ACCURACY + "'), " +
					"o.MATQUOTERATE = (select ISNULL(sum(bs.FRATE),0) from BOQITEM_MATERIAL bs JOIN MATERIAL s on bs.MATERIALID = s.MATERIALID where bs.BOQITEMID = o.BOQITEMID AND s.ACCURACY like '" + MaterialTable.QUOTED_ACCURACY + "'), " +

					"o.FIXEDCOST = " +
					"(select ISNULL(sum(s.FINALFIXEDCOST),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FINALFIXEDCOST),0) from BOQITEM_CONSUMABLE s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FINALFIXEDCOST),0) from BOQITEM_EQUIPMENT s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FINALFIXEDCOST),0) from BOQITEM_LABOR s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FINALFIXEDCOST),0) from BOQITEM_MATERIAL s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FINALFIXEDCOST),0) from BOQITEM_SUBCONTRACTOR s where s.BOQITEMID = o.BOQITEMID) " +

					"FROM BOQITEM as o " +
					"where o.PRJID = " + projectId + " AND o.BOQITEMID in (:ids)";


	//		String testManHoursQuery = 
	//				"(select ISNULL(sum(m.RESUNITS),0) FROM " +
	//						"(select sum(bl.TOTALUNITS) as ResUnits "
	//						+ "FROM BOQITEM as b "
	//						+ "INNER JOIN BOQITEM_LABOR AS bl ON b.BOQITEMID=bl.BOQITEMID "
	////						+ "INNER JOIN LABOR AS l ON l.LABORID=bl.LABORID "
	//						+ "WHERE b.PRJID = " + projectId + " AND b.BOQITEMID in (:ids) "
	//						
	//						+ "UNION ALL "
	//						
	//						+ "select case when a.ACTBASED=1 THEN (sum(b.quantity*ba.QTYPUNIT*ba.FACTOR1*ba.FACTOR2*ba.FACTOR3*(al.FACTOR1*al.FACTOR2*al.FACTOR3))/a.PRODUCTIVITY) "
	//						+ "else sum(al.QTYPUNIT*al.FACTOR1*al.FACTOR2*al.FACTOR3)*ba.TOTALUNITS END as ResUnits "
	//						+ "FROM BOQITEM as b "
	//						+ "left outer JOIN  BOQITEM_ASSEMBLY AS ba ON b.BOQITEMID=ba.BOQITEMID "
	//						+ "left outer JOIN ASSEMBLY AS a ON ba.ASSEMBLYID=a.ASSEMBLYID "
	//						+ "left outer JOIN ASSEMBLY_LABOR AS al ON ba.ASSEMBLYID=al.ASSEMBLYID "
	//						+ "left outer  JOIN LABOR AS l ON l.LABORID=al.LABORID "
	//						+ "WHERE b.PRJID =  " + projectId + " AND b.BOQITEMID in (:ids) "
	//						+ "group by a.PRODUCTIVITY,a.ACTBASED,ba.TOTALUNITS "
	//
	//	  					+ "UNION ALL "
	//	  					
	//	  					+ "select case when a4.ACTBASED=1 THEN (sum(ba.TOTALUNITS*ac2.QTYPUNIT*ac2.FACTOR1*ac2.FACTOR2*ac2.DIVIDER*(al.FACTOR1*al.FACTOR2*al.FACTOR3))/a4.PRODUCTIVITY) "
	//	  					+ "else sum(al.QTYPUNIT*al.FACTOR1*al.FACTOR2*al.FACTOR3)*ba.TOTALUNITS*ac2.QTYPUNIT*ac2.FACTOR1*ac2.FACTOR2*ac2.DIVIDER END as ResUnits "
	//	  					+ "FROM BOQITEM AS b "
	//	  					+ "inner join  BOQITEM_ASSEMBLY as ba ON b.BOQITEMID=ba.BOQITEMID "
	//	  					+ "inner join  ASSEMBLY as a ON ba.ASSEMBLYID=a.ASSEMBLYID "
	//	  					+ "inner join  ASSEMBLY_CHILD as ac2 ON a.ASSEMBLYID=ac2.ASSEMBLYID "
	//	  					+ "inner join  ASSEMBLY as a4 ON ac2.CHILDID=a4.ASSEMBLYID "
	//	  					+ "inner join  ASSEMBLY_LABOR as al ON a4.ASSEMBLYID=al.ASSEMBLYID "
	//	  					+ "inner join  LABOR as l ON al.LABORID=l.LABORID "
	//	  					+ "WHERE b.PRJID = " + projectId + " AND b.BOQITEMID in (:ids) "
	//	  					+ "GROUP BY  ba.TOTALUNITS,a4.PRODUCTIVITY,a4.ACTBASED,ac2.QTYPUNIT,ac2.FACTOR1,ac2.FACTOR2,ac2.DIVIDER) AS m)";


	//		bulkUpdateIdsTEST(session, testManHoursQuery, ids);

			bulkUpdateIds(session, qs, ids);

			//		System.out.println("Recalculated BOQITEMS -> "+ids);
		}

		public static void bulkUpdateIds(Session session, string qs, ICollection<long> recalcIds)
		{
			if (recalcIds == null)
			{
				session.createSQLQuery(qs).executeUpdate();
				session.flush();
				return;
			}

			recalcIds = new HashSet<long>(recalcIds);
			IList<System.Collections.IList> chunks = splitIntoChunks(recalcIds, 1000);

			foreach (System.Collections.IList c in chunks)
			{
				session.createSQLQuery(qs).setParameterList("ids", c).executeUpdate();
			}
			if (recalcIds.Count > 0)
			{
				session.flush();
			}
		}

		private static IList<long> longIdsQuery(Session session, string qs, ICollection<long> ids)
		{
			IList<long> resList = new List<long>();
			IList<System.Collections.IList> chunks = splitIntoChunks(ids, 1000);
			foreach (System.Collections.IList chunk in chunks)
			{
				((IList<long>)resList).AddRange(session.createQuery(qs).setParameterList("ids", chunk).list());
			}
			return resList;
		}

		private static IList<System.Collections.IList> splitIntoChunks(System.Collections.ICollection input, int partitionSize)
		{
			System.Collections.IList resList = new List<object>(input);

			IList<System.Collections.IList> partitions = new LinkedList<System.Collections.IList>();
			for (int i = 0; i < resList.Count; i += partitionSize)
			{
				System.Collections.IList subList = resList.subList(i, i + Math.Min(partitionSize, resList.Count - i));
				partitions.Add(subList);
			}

			return partitions;
		}

		private static ISet<long> findRelatedBoqItems(Session session, long? projectId, string tableName, string varName, string idName, ICollection<long> updIds)
		{
			if (updIds.Count == 0)
			{
				return Collections.EMPTY_SET;
			}

			ISet<long> updBoqItems = new HashSet<long>();
			updBoqItems.addAll(longIdsQuery(session, "select o.boqItemTable.boqitemId from BoqItem" + tableName + " as o where o.projectId = " + projectId + " and o." + varName + "." + idName + " in (:ids)", updIds));

			string qs = "select o.assemblyTable.assemblyId from Assembly" + tableName + " as o where o.projectId = " + projectId + " and o." + varName + "." + idName + " in (:ids)";
			if (tableName.Equals("AssemblyTable"))
			{
				qs = "select o.parentTable.assemblyId from AssemblyAssemblyTable as o where o.projectId = " + projectId + " and o.childTable.assemblyId in (:ids)";
			}
			IList<long> assIds = longIdsQuery(session, qs, updIds);

			while (assIds.Count != 0)
			{
				updBoqItems.addAll(longIdsQuery(session, "select o.boqItemTable.boqitemId from BoqItemAssemblyTable as o where o.projectId = " + projectId + " and o.assemblyTable.assemblyId in (:ids)", assIds));
				assIds = longIdsQuery(session, "select o.parentTable.assemblyId from AssemblyAssemblyTable as o where o.projectId = " + projectId + " and o.childTable.assemblyId in (:ids)", assIds);
			}

			return updBoqItems;
		}
	}


}