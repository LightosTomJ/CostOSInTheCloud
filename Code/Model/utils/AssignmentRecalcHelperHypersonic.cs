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

	public class AssignmentRecalcHelperHypersonic
	{

		public static void bottomUpRecalculate(UIProgress prgDialog, Session session, ResourceTableDefinition tableDefinition, ICollection<long> recalcIds, bool updateBuildUps)
		{

			//AssignmentTableDefinition assignmentTableDefinition = tableDefinition.getAssignmentTableDefinition();		
			if (tableDefinition.TableClass.Equals(typeof(SubcontractorTable)))
			{
				recalculateSubcontractorParents(session, recalcIds,updateBuildUps);
				Console.WriteLine("recalculateSubcontractorParents");
			}
			else if (tableDefinition.TableClass.Equals(typeof(MaterialTable)))
			{
				recalculateMaterialParents(session, recalcIds,updateBuildUps);
				Console.WriteLine("recalculateMaterialParents");
			}
			else if (tableDefinition.TableClass.Equals(typeof(ConsumableTable)))
			{
				recalculateConsumableParents(session, recalcIds,updateBuildUps);
				Console.WriteLine("recalculateConsumableParents");
			}
			else if (tableDefinition.TableClass.Equals(typeof(LaborTable)))
			{
				recalculateLaborParents(session, recalcIds,updateBuildUps);
				Console.WriteLine("recalculateLaborParents");
			}
			else if (tableDefinition.TableClass.Equals(typeof(EquipmentTable)))
			{
				recalculateEquipmentParents(session, recalcIds,updateBuildUps);
				Console.WriteLine("recalculateEquipmentParents");
			}
			else if (tableDefinition.TableClass.Equals(typeof(AssemblyTable)))
			{
				recalculateAssemblies(session, recalcIds);
				Console.WriteLine("recalculateAssemblies");
			}
		}

		public static ICollection<long> findRelatedBoqItems(UIProgress progressDialog, Session session, ResourceTableDefinition tableDefinition, ICollection<long> resourceIds)
		{

			if (tableDefinition.TableClass.Equals(typeof(SubcontractorTable)))
			{
				return findRelatedBoqItems(session,"SubcontractorTable", "subcontractorTable", "subcontractorId", resourceIds);
			}
			else if (tableDefinition.TableClass.Equals(typeof(MaterialTable)))
			{
				return findRelatedBoqItems(session,"MaterialTable", "materialTable", "materialId", resourceIds);
			}
			else if (tableDefinition.TableClass.Equals(typeof(ConsumableTable)))
			{
				return findRelatedBoqItems(session,"ConsumableTable", "consumableTable", "consumableId", resourceIds);
			}
			else if (tableDefinition.TableClass.Equals(typeof(LaborTable)))
			{
				return findRelatedBoqItems(session,"LaborTable", "laborTable", "laborId", resourceIds);
			}
			else if (tableDefinition.TableClass.Equals(typeof(EquipmentTable)))
			{
				return findRelatedBoqItems(session,"EquipmentTable", "equipmentTable", "equipmentId", resourceIds);
			}
			else if (tableDefinition.TableClass.Equals(typeof(AssemblyTable)))
			{
				return findRelatedBoqItems(session,"AssemblyTable", "assemblyTable", "assemblyId", resourceIds);
			}

			return Collections.EMPTY_LIST;
		}

		private static string buildUpUpdateQueryForResource(string tableName, string totalField, RateBuildUpColumnsTable col)
		{
			string formula = col.RowFormula;
			formula = StringUtils.replaceAll(formula, "BUR_RESOURCE_RATE", totalField);

			for (int i = 0; i < 20; i++)
			{
				formula = StringUtils.replaceAll(formula, "BUR_COLUMN" + i, "o.RATE" + i);
			}

			return "update " + tableName + " SET BURATE = (select " + formula + " from RATEBUILDUP as o where o.RESTYPE = '" + tableName.ToLower() + "' and o.RESPRJID = " + tableName + "ID)";
		}

		private static void recalculateSubcontractorParents(Session session, ICollection<long> recalcIds, bool updateBuildUps)
		{
			if (recalcIds != null && recalcIds.Count == 0)
			{
				return;
			}

			string qs = null;
			if (updateBuildUps)
			{
				RateBuildUpColumnsTable colTable = (RateBuildUpColumnsTable)session.createQuery("from RateBuildUpColumnsTable as o where o.resourceType = :rt").setString("rt",LayoutTable.SUBCONTRACTOR).uniqueResult();
				if (colTable != null)
				{
					qs = buildUpUpdateQueryForResource("SUBCONTRACTOR","TOTALRATE",colTable);
					if (recalcIds != null)
					{
						qs = qs + " where SUBCONTRACTORID in (:ids)";
					}
					bulkUpdateIds(session,qs,recalcIds);
				}
			}


			//		String qs = "update AssemblySubcontractorTable as o set " +
			//				"o.finalRate = (o.subcontractorTable.totalRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit), " +
			//				"o.finalIKARate = (o.subcontractorTable.IKA*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit) " +
			//				"where o.subcontractorTable.subcontractorId in (:ids)";
			//		qs = "update o set " +
			//				"o.FRATE = (ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.QTYPUNIT), " +
			//				"o.FIKARATE = (c.IKA*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.QTYPUNIT) " +
			//				"FROM ASSEMBLY_SUBCONTRACTOR as o JOIN SUBCONTRACTOR as c ON o.SUBCONTRACTORID = c.SUBCONTRACTORID ";
			//		qs = "update o set " +
			//				"o.FRATE = (ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.QTYPUNIT), " +
			//				"o.FIKARATE = (c.IKA*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.QTYPUNIT) " +
			//				"FROM ASSEMBLY_SUBCONTRACTOR as o JOIN SUBCONTRACTOR as c ON o.SUBCONTRACTORID = c.SUBCONTRACTORID ";

			qs = "update ASSEMBLY_SUBCONTRACTOR ss set "
					+ "FRATE = ( select (ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.QTYPUNIT) FROM ASSEMBLY_SUBCONTRACTOR as o JOIN SUBCONTRACTOR as c ON o.SUBCONTRACTORID = c.SUBCONTRACTORID where o.ASSEMBLYSUBCONTRACTORID = ss.ASSEMBLYSUBCONTRACTORID  ), "
					+ "FIKARATE = ( select (c.IKA*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.QTYPUNIT) FROM ASSEMBLY_SUBCONTRACTOR as o JOIN SUBCONTRACTOR as c ON o.SUBCONTRACTORID = c.SUBCONTRACTORID where o.ASSEMBLYSUBCONTRACTORID = ss.ASSEMBLYSUBCONTRACTORID ), "
					+ "FINALFIXEDCOST = ( select (ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE)  FROM ASSEMBLY_SUBCONTRACTOR as o JOIN SUBCONTRACTOR as c ON o.SUBCONTRACTORID = c.SUBCONTRACTORID where o.ASSEMBLYSUBCONTRACTORID = ss.ASSEMBLYSUBCONTRACTORID ) "
					+ "where ss.SUBCONTRACTORID in (:ids)";

			bulkUpdateIds(session,qs,recalcIds);

			IList<long> parentIds = longIdsQuery(session,"select o.assemblyTable.assemblyId from AssemblySubcontractorTable as o where o.subcontractorTable.subcontractorId in (:ids)",recalcIds);
			recalculateAssemblies(session, parentIds);

			//		qs = "update BoqItemSubcontractorTable as o set " +
			//				"o.TOTALUNITS = o.boqItemTable.quantity*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.quantityPerUnit " +				
			//				"o.finalRate = o.subcontractorTable.totalRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//				"o.totalCost = o.subcontractorTable.totalRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit*o.boqItemTable.quantity " +
			//				"where o.subcontractorTable.subcontractorId in (:ids)";		

			qs = " update BOQITEM_SUBCONTRACTOR bs set "

					+ "TOTALUNITS =  "
					+ "( SELECT ( p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT ) "
					+ "FROM BOQITEM_SUBCONTRACTOR as o JOIN SUBCONTRACTOR as c ON o.SUBCONTRACTORID = c.SUBCONTRACTORID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID "
					+ "WHERE bs.BOQITEMSUBCONTRACTORID = o.BOQITEMSUBCONTRACTORID),"

					+ "FRATE = "
					+ "( SELECT ( ISNULL( c.BURATE , c.TOTALRATE ) * o.FACTOR1* o.FACTOR2 * o.FACTOR3 * o.LOCALFACTOR * o.COSTCENTER * o.QTYPUNIT) "
					+ "FROM BOQITEM_SUBCONTRACTOR as o JOIN SUBCONTRACTOR as c ON o.SUBCONTRACTORID = c.SUBCONTRACTORID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID "
					+ "WHERE bs.BOQITEMSUBCONTRACTORID = o.BOQITEMSUBCONTRACTORID), "

					+ "FINALFIXEDCOST = "
					+ "( SELECT ( ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER) "
					+ "FROM BOQITEM_SUBCONTRACTOR as o JOIN SUBCONTRACTOR as c ON o.SUBCONTRACTORID = c.SUBCONTRACTORID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID "
					+ "WHERE bs.BOQITEMSUBCONTRACTORID = o.BOQITEMSUBCONTRACTORID), "

					+ "VARIABLECOST = "
					+ "( SELECT (ISNULL(c.BURATE , c.TOTALRATE ) * o.FACTOR1 * o.FACTOR2 * o.FACTOR3 * o.LOCALFACTOR * o.COSTCENTER * o.QTYPUNIT * p.QUANTITY ) "
					+ "FROM BOQITEM_SUBCONTRACTOR as o JOIN SUBCONTRACTOR as c ON o.SUBCONTRACTORID = c.SUBCONTRACTORID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID "
					+ "WHERE bs.BOQITEMSUBCONTRACTORID = o.BOQITEMSUBCONTRACTORID), "

					+ "TOTALCOST = "
					+ "( SELECT (ISNULL(c.BURATE,c.TOTALRATE )*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY) + "
					+ "( ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER) "
					+ "FROM BOQITEM_SUBCONTRACTOR as o JOIN SUBCONTRACTOR as c ON o.SUBCONTRACTORID = c.SUBCONTRACTORID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID "
					+ "WHERE bs.BOQITEMSUBCONTRACTORID = o.BOQITEMSUBCONTRACTORID) "

					+ "WHERE bs.SUBCONTRACTORID in (:ids)";

			/*qs = "update o set " +
				"o.TOTALUNITS = p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT, " +
				"o.FRATE = ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +
				"o.TOTALCOST = ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY " +
				"FROM BOQITEM_SUBCONTRACTOR as o JOIN SUBCONTRACTOR as c ON o.SUBCONTRACTORID = c.SUBCONTRACTORID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID "*/
				;


				bulkUpdateIds(session,qs,recalcIds);

				parentIds = longIdsQuery(session,"select o.boqItemTable.boqitemId from BoqItemSubcontractorTable as o where o.subcontractorTable.subcontractorId in (:ids)",recalcIds);
				recalculateBoqItems(session, parentIds);
		}

		private static void recalculateEquipmentParents(Session session, ICollection<long> recalcIds, bool updateBuildUps)
		{
			if (recalcIds.Count == 0)
			{
				return;
			}

			string qs = null;
			if (updateBuildUps)
			{
				RateBuildUpColumnsTable colTable = (RateBuildUpColumnsTable)session.createQuery("from RateBuildUpColumnsTable as o where o.resourceType = :rt").setString("rt",LayoutTable.EQUIPMENT).uniqueResult();
				if (colTable != null)
				{
					qs = buildUpUpdateQueryForResource("EQUIPMENT","TOTALRATE",colTable) + " where EQUIPMENTID in (:ids)";
					bulkUpdateIds(session,qs,recalcIds);
				}
			}

			//		String qs = "update AssemblyEquipmentTable as o set " +
			//				"o.finalRate = (o.equipmentTable.totalRate+o.equipmentTable.fuelRate)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit " +
			//				"where o.equipmentTable.equipmentId in (:ids)";

			qs = "update ASSEMBLY_EQUIPMENT ae "

					+ "set FRATE = ( SELECT (ISNULL(c.BURATE,c.TOTALRATE)/o.UNITHOURS)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*(CASE WHEN p.ACTBASED = 0 THEN o.QTYPUNIT WHEN p.ACTBASED = 1 THEN CASE WHEN 1/NULLIF(p.PRODUCTIVITY,0)  is null THEN 0 ELSE 1/p.PRODUCTIVITY END END) "
					+ "FROM ASSEMBLY_EQUIPMENT as o JOIN EQUIPMENT as c ON o.EQUIPMENTID = c.EQUIPMENTID left JOIN ASSEMBLY as p ON p.ASSEMBLYID = o.ASSEMBLYID where ae.ASSEMBLYEQUIPMENTID = o.ASSEMBLYEQUIPMENTID ), "

					+ "FINALFIXEDCOST = ( SELECT ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE "
					+ "FROM ASSEMBLY_EQUIPMENT as o JOIN EQUIPMENT as c ON o.EQUIPMENTID = c.EQUIPMENTID left JOIN ASSEMBLY as p ON p.ASSEMBLYID = o.ASSEMBLYID where ae.ASSEMBLYEQUIPMENTID = o.ASSEMBLYEQUIPMENTID ) "

					+ "where ae.EQUIPMENTID in (:ids)";

			bulkUpdateIds(session,qs,recalcIds);

			IList<long> parentIds = longIdsQuery(session,"select o.assemblyTable.assemblyId from AssemblyEquipmentTable as o where o.equipmentTable.equipmentId in (:ids)",recalcIds);
			recalculateAssemblies(session, parentIds);

			//		qs = "update BoqItemEquipmentTable as o set " +
			//				"o.TOTALUNITS = (case when o.boqItemTable.activityBased = false then (o.boqItemTable.quantity*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.quantityPerUnit) else (o.boqItemTable.duration*o.FACTOR1*o.FACTOR2*o.FACTOR3) end), "+
			//				"o.finalRate = o.laborTable.totalRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//				"o.totalCost = o.laborTable.totalRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit*o.boqItemTable.quantity " +
			//				"where o.equipmentTable.equipmentId in (:ids)";		


			qs = "update BOQITEM_EQUIPMENT be set "
					+ "TOTALUNITS = ( SELECT (case when p.ACTBASED = 0 then p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT ELSE p.duration*o.FACTOR1*o.FACTOR2*o.FACTOR3 end) "
					+ " FROM BOQITEM_EQUIPMENT as o JOIN EQUIPMENT as c ON o.EQUIPMENTID = c.EQUIPMENTID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID where be.BOQITEMEQUIPMENTID = o.BOQITEMEQUIPMENTID ), "
					//				+ "FRATE = ( SELECT ISNULL(c.BURATE,c.TOTALRATE)*be.FACTOR1*be.FACTOR2*be.FACTOR3*be.LOCALFACTOR*be.COSTCENTER*be.QTYPUNIT where c.EQUIPMENTID in (:ids) and be.EQUIPMENTID = c.EQUIPMENTID ),  "
					+" FRATE = ( SELECT (CASE WHEN o.QTYPUNIT = 0 then 0 else ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then o.FACTOR1*o.FACTOR2*o.FACTOR3*(o.QTYPUNIT/o.UNITHOURS)*o.LOCALFACTOR*o.COSTCENTER ELSE (o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER)*(1/NULLIF(p.ADJPROD*o.UNITHOURS,0)) END) END) "
					+ " FROM BOQITEM_EQUIPMENT as o JOIN EQUIPMENT as c ON o.EQUIPMENTID = c.EQUIPMENTID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID where be.BOQITEMEQUIPMENTID = o.BOQITEMEQUIPMENTID  ), "
					//				+ "TOTALCOST = ( SELECT ISNULL(c.BURATE,c.TOTALRATE)*be.FACTOR1*be.FACTOR2*be.FACTOR3*be.LOCALFACTOR*be.COSTCENTER*be.QTYPUNIT*p.QUANTITY ) FROM EQUIPMENT as c left JOIN BOQITEM as p ON p.BOQITEMID = be.BOQITEMID where c.EQUIPMENTID in (:ids) and be.EQUIPMENTID = c.EQUIPMENTID "

					+ "FINALFIXEDCOST = "
					+ "( SELECT ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER "
					+ "FROM BOQITEM_EQUIPMENT as o JOIN EQUIPMENT as c ON o.EQUIPMENTID = c.EQUIPMENTID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID where be.BOQITEMEQUIPMENTID = o.BOQITEMEQUIPMENTID), "

					+ "VARIABLECOST = "
					+ "( SELECT ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT*o.LOCALFACTOR*o.COSTCENTER ELSE o.UNITHOURS*p.DURATION*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER end) "
					+ "FROM BOQITEM_EQUIPMENT as o JOIN EQUIPMENT as c ON o.EQUIPMENTID = c.EQUIPMENTID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID where be.BOQITEMEQUIPMENTID = o.BOQITEMEQUIPMENTID), "

					+ "TOTALCOST = "
					+ "( SELECT (CASE WHEN o.QTYPUNIT = 0 then 0 else ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then o.FACTOR1*o.FACTOR2*o.FACTOR3*(o.QTYPUNIT/o.UNITHOURS)*o.LOCALFACTOR*o.COSTCENTER ELSE  (o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER)*(1/NULLIF(p.ADJPROD*o.UNITHOURS,0)) END) END) * p.QUANTITY + (ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER) "
					+ "FROM BOQITEM_EQUIPMENT as o JOIN EQUIPMENT as c ON o.EQUIPMENTID = c.EQUIPMENTID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID where be.BOQITEMEQUIPMENTID = o.BOQITEMEQUIPMENTID) "

					//TODO CHANGE ABOVE 2 LINES TO THAT BELOW:
					//"o.FRATE = (case when p.QUANTITY = 0 then 0 else ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT*o.LOCALFACTOR*o.COSTCENTER ELSE p.duration*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER end)/p.QUANTITY end), " +
					//"o.TOTALCOST = ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT*o.LOCALFACTOR*o.COSTCENTER ELSE p.duration*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER end) " +
					+ "where be.EQUIPMENTID in (:ids)";

			//		qs = "update o set " +
			//			"o.TOTALUNITS = (case when p.ACTBASED = 0 then p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT ELSE p.duration*o.FACTOR1*o.FACTOR2*o.FACTOR3 end)," +
			//			"o.FRATE = ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +
			//			"o.TOTALCOST = ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY " +
			//			"FROM BOQITEM_EQUIPMENT as o JOIN EQUIPMENT as c ON o.EQUIPMENTID = c.EQUIPMENTID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID " +
			//			"where c.EQUIPMENTID in (:ids)";
			//		
			bulkUpdateIds(session,qs,recalcIds);

			Console.WriteLine("PASSED: EQUIPMENTS");

			parentIds = longIdsQuery(session,"select o.boqItemTable.boqitemId from BoqItemEquipmentTable as o where o.equipmentTable.equipmentId in (:ids)",recalcIds);
			recalculateBoqItems(session, parentIds);
		}

		private static void recalculateLaborParents(Session session, ICollection<long> recalcIds, bool updateBuildUps)
		{
			if (recalcIds.Count == 0)
			{
				return;
			}

			string qs = null;
			if (updateBuildUps)
			{
				RateBuildUpColumnsTable colTable = (RateBuildUpColumnsTable)session.createQuery("from RateBuildUpColumnsTable as o where o.resourceType = :rt").setString("rt",LayoutTable.LABOR).uniqueResult();
				if (colTable != null)
				{
					qs = buildUpUpdateQueryForResource("LABOR","TOTALRATE",colTable) + " where LABORID in (:ids)";
					bulkUpdateIds(session,qs,recalcIds);
				}
			}

			//		String qs = "update AssemblyLaborTable as o set " +
			//				"o.finalRate = o.laborTable.totalRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//				"o.finalIKARate = o.laborTable.IKA*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit " +
			//				"where o.laborTable.laborId in (:ids)";

			qs = "update ASSEMBLY_LABOR al set "
					+ "FRATE = ( SELECT (ISNULL(c.BURATE,c.TOTALRATE)/o.UNITHOURS)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*(CASE WHEN p.ACTBASED = 0 THEN o.QTYPUNIT WHEN p.ACTBASED = 1 THEN CASE WHEN 1/NULLIF(p.PRODUCTIVITY,0)  is null THEN 0 ELSE 1/p.PRODUCTIVITY END END) "
					+ "FROM ASSEMBLY_LABOR as o JOIN LABOR as c ON o.LABORID = c.LABORID left JOIN ASSEMBLY as p ON p.ASSEMBLYID = o.ASSEMBLYID where al.ASSEMBLYLABORID = o.ASSEMBLYLABORID ), "

					+ "FIKARATE = ( SELECT (c.IKA/o.UNITHOURS)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*(CASE WHEN p.ACTBASED = 0 THEN o.QTYPUNIT WHEN p.ACTBASED = 1 THEN CASE WHEN 1/NULLIF(p.PRODUCTIVITY,0)  is null THEN 0 ELSE 1/p.PRODUCTIVITY END END) "
					+ "FROM ASSEMBLY_LABOR as o JOIN LABOR as c ON o.LABORID = c.LABORID left JOIN ASSEMBLY as p ON p.ASSEMBLYID = o.ASSEMBLYID where al.ASSEMBLYLABORID = o.ASSEMBLYLABORID ), "
					//+ "FRATE = (SELECT ISNULL(c.BURATE,c.TOTALRATE)*al.FACTOR1*al.FACTOR2*al.FACTOR3*al.LOCALFACTOR*al.EXCHANGERATE*(case when p.ACTBASED = 0 then QTYPUNIT ELSE (CASE WHEN (1/NULLIF(p.PRODUCTIVITY,0)) is null THEN 0 ELSE 1/p.PRODUCTIVITY end) end) FROM LABOR as c left JOIN ASSEMBLY as p ON p.ASSEMBLYID = al.ASSEMBLYID  where al.LABORID = c.LABORID  ), "
					//+ "FIKARATE = (SELECT c.IKA*al.FACTOR1*al.FACTOR2*al.FACTOR3*al.LOCALFACTOR*al.EXCHANGERATE*(case when p.ACTBASED = 0 then al.QTYPUNIT ELSE (CASE WHEN (1/NULLIF(p.PRODUCTIVITY,0)) is null THEN 0 ELSE 1/p.PRODUCTIVITY end) end) FROM LABOR as c left JOIN ASSEMBLY as p ON p.ASSEMBLYID = al.ASSEMBLYID  where al.LABORID = c.LABORID  ) "

					+ "FINALFIXEDCOST = (SELECT ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE "
					+ "FROM ASSEMBLY_LABOR as o JOIN LABOR as c ON o.LABORID = c.LABORID left JOIN ASSEMBLY as p ON p.ASSEMBLYID = o.ASSEMBLYID where al.ASSEMBLYLABORID = o.ASSEMBLYLABORID ) "

					+ "where al.LABORID in (:ids)";

			//System.out.println("executing: "+qs);
			//		qs = "update o set " +
			//				"o.FRATE = ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*(case when p.ACTBASED = 0 then o.QTYPUNIT ELSE (CASE WHEN (1/NULLIF(p.PRODUCTIVITY,0)) is null THEN 0 ELSE 1/p.PRODUCTIVITY end) end), " +
			//				"o.FIKARATE = c.IKA*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*(case when p.ACTBASED = 0 then o.QTYPUNIT ELSE (CASE WHEN (1/NULLIF(p.PRODUCTIVITY,0)) is null THEN 0 ELSE 1/p.PRODUCTIVITY end) end) " +
			//				"FROM ASSEMBLY_LABOR as o JOIN LABOR as c ON o.LABORID = c.LABORID left JOIN ASSEMBLY as p ON p.ASSEMBLYID = o.ASSEMBLYID " +
			//				"where c.LABORID in (:ids)";
			bulkUpdateIds(session,qs,recalcIds);

			IList<long> parentIds = longIdsQuery(session,"select o.assemblyTable.assemblyId from AssemblyLaborTable as o where o.laborTable.laborId in (:ids)",recalcIds);
			recalculateAssemblies(session, parentIds);

			//		qs = "update BoqItemLaborTable as o set " +
			//				"o.TOTALUNITS = (case when o.boqItemTable.activityBased = false then (o.boqItemTable.quantity*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.quantityPerUnit) else (o.boqItemTable.duration*o.FACTOR1*o.FACTOR2*o.FACTOR3) end), "+
			//				"o.finalRate = o.laborTable.totalRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//				"o.totalCost = o.laborTable.totalRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit*o.boqItemTable.quantity " +
			//				"where o.laborTable.laborId in (:ids)";		

			qs = "update BOQITEM_LABOR bl set  "
					+ "TOTALUNITS = (SELECT (case when p.ACTBASED = 0 then p.QUANTITY*bl.FACTOR1*bl.FACTOR2*o.FACTOR3*o.QTYPUNIT ELSE p.duration*o.FACTOR1*o.FACTOR2*o.FACTOR3 end) "
					+ "FROM BOQITEM_LABOR as o JOIN LABOR as c ON o.LABORID = c.LABORID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID where bl.BOQITEMLABORID = o.BOQITEMLABORID  ) , "

					+ "FRATE = ( SELECT (CASE WHEN o.QTYPUNIT = 0 then 0 else ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then o.FACTOR1*o.FACTOR2*o.FACTOR3*(o.QTYPUNIT/o.UNITHOURS)*o.LOCALFACTOR*o.COSTCENTER ELSE (o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER)*(1/NULLIF(p.ADJPROD*o.UNITHOURS,0)) END) END) "
					+ "FROM BOQITEM_LABOR as o JOIN LABOR as c ON o.LABORID = c.LABORID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID where bl.BOQITEMLABORID = o.BOQITEMLABORID ), "

					+ "FINALFIXEDCOST = (SELECT ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER "
					+ "FROM BOQITEM_LABOR as o JOIN LABOR as c ON o.LABORID = c.LABORID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID where bl.BOQITEMLABORID = o.BOQITEMLABORID), "

					+ "VARIABLECOST = ( SELECT ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT ELSE o.UNITHOURS*p.DURATION*o.FACTOR1*o.FACTOR2*o.FACTOR3 end) "
					+ "FROM BOQITEM_LABOR as o JOIN LABOR as c ON o.LABORID = c.LABORID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID where bl.BOQITEMLABORID = o.BOQITEMLABORID ),  "

					+ "TOTALCOST = "
					+ "( SELECT (CASE WHEN o.QTYPUNIT = 0 then 0 else ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then o.FACTOR1*o.FACTOR2*o.FACTOR3*(o.QTYPUNIT/o.UNITHOURS)*o.LOCALFACTOR*o.COSTCENTER ELSE (o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER)*(1/NULLIF(p.ADJPROD*o.UNITHOURS,0)) END) END) * p.QUANTITY + (ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER) "
					+ "FROM BOQITEM_LABOR as o JOIN LABOR as c ON o.LABORID = c.LABORID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID where bl.BOQITEMLABORID = o.BOQITEMLABORID )  "

	//				+ "TOTALUNITS = (SELECT (case when p.ACTBASED = 0 then p.QUANTITY*bl.FACTOR1*bl.FACTOR2*bl.FACTOR3*bl.QTYPUNIT ELSE p.duration*bl.FACTOR1*bl.FACTOR2*bl.FACTOR3 end) FROM LABOR as c left JOIN BOQITEM as p ON p.BOQITEMID = bl.BOQITEMID  where c.LABORID in (:ids) and bl.LABORID = c.LABORID  ) , "				
	//				+ "FRATE = (SELECT (case when p.QUANTITY = 0 then 0 else ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then p.QUANTITY*bl.FACTOR1*bl.FACTOR2*bl.FACTOR3*bl.QTYPUNIT*bl.LOCALFACTOR*bl.COSTCENTER ELSE p.duration*bl.FACTOR1*bl.FACTOR2*bl.FACTOR3*bl.LOCALFACTOR*bl.COSTCENTER end)/p.QUANTITY end) FROM LABOR as c left JOIN BOQITEM as p ON p.BOQITEMID = bl.BOQITEMID where c.LABORID in (:ids) and bl.LABORID = c.LABORID  ) , "
	//				+ "TOTALCOST = (SELECT ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then p.QUANTITY*bl.FACTOR1*bl.FACTOR2*bl.FACTOR3*bl.LOCALFACTOR*bl.COSTCENTER*bl.QTYPUNIT ELSE p.duration*bl.FACTOR1*bl.FACTOR2*bl.FACTOR3*bl.LOCALFACTOR*bl.COSTCENTER end) FROM LABOR as c left JOIN BOQITEM as p ON p.BOQITEMID = bl.BOQITEMID where c.LABORID in (:ids) and bl.LABORID = c.LABORID )  "
					// TODO CHANGE ABOVE 2 LINES TO THAT BELOW:
					//"o.FRATE = (case when p.QUANTITY = 0 then 0 else ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT*o.LOCALFACTOR*o.COSTCENTER ELSE p.duration*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER end)/p.QUANTITY end), " +
					//"o.TOTALCOST = ISNULL(c.BURATE,c.TOTALRATE)*(case when p.ACTBASED = 0 then p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT ELSE p.duration*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER end) " +				
					+ " where bl.LABORID in (:ids) ";
			//		qs = "update o set " +
			//				"o.TOTALUNITS = (case when p.ACTBASED = 0 then p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT ELSE p.duration*o.FACTOR1*o.FACTOR2*o.FACTOR3 end), " +
			//				"o.FRATE = ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +
			//				"o.TOTALCOST = ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY " +
			//				"FROM BOQITEM_LABOR as o JOIN LABOR as c ON o.LABORID = c.LABORID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID " +
			//				"where c.LABORID in (:ids)";

			bulkUpdateIds(session,qs,recalcIds);

			Console.WriteLine("PASSED: LABORS");

			parentIds = longIdsQuery(session,"select o.boqItemTable.boqitemId from BoqItemLaborTable as o where o.laborTable.laborId in (:ids)",recalcIds);
			recalculateBoqItems(session, parentIds);
		}

		private static void recalculateMaterialParents(Session session, ICollection<long> recalcIds, bool updateBuildUps)
		{
			if (recalcIds.Count == 0)
			{
				return;
			}

			string qs = null;
			if (updateBuildUps)
			{
				RateBuildUpColumnsTable colTable = (RateBuildUpColumnsTable)session.createQuery("from RateBuildUpColumnsTable as o where o.resourceType = :rt").setString("rt",LayoutTable.MATERIAL).uniqueResult();
				if (colTable != null)
				{
					qs = buildUpUpdateQueryForResource("MATERIAL","TOTALRATE",colTable) + " where MATERIALID in (:ids)";
					bulkUpdateIds(session,qs,recalcIds);
				}
			}

			//		String qs = "update AssemblyMaterialTable as o set " +
			//				"o.finalRate = o.materialTable.totalRate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit " +
			//				"where o.materialTable.materialId in (:ids)";

			qs = "update ASSEMBLY_MATERIAL am set "

					+ "FRATE = ( SELECT (ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.EXCHANGERATE*o.QTYPUNIT) "
					+ "FROM ASSEMBLY_MATERIAL as o JOIN MATERIAL as c ON o.MATERIALID = c.MATERIALID where am.ASSEMBLYMATERIALID = o.ASSEMBLYMATERIALID), "

					+ "FINALFIXEDCOST = ( SELECT ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.EXCHANGERATE "
					+ "FROM ASSEMBLY_MATERIAL as o JOIN MATERIAL as c ON o.MATERIALID = c.MATERIALID where am.ASSEMBLYMATERIALID = o.ASSEMBLYMATERIALID ) "

					+ "WHERE am.MATERIALID in (:ids)";

			//		qs = "update o set " +
			//				"o.FRATE = (ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.EXCHANGERATE*o.QTYPUNIT) " +
			//				"FROM ASSEMBLY_MATERIAL as o JOIN MATERIAL as c ON o.MATERIALID = c.MATERIALID " +
			//				"where c.MATERIALID in (:ids)";

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

			qs = " update BOQITEM_MATERIAL bm set "
					+ "TOTALUNITS = ( SELECT p.QUANTITY*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.QTYPUNIT FROM BOQITEM_MATERIAL as o JOIN MATERIAL as c ON o.MATERIALID = c.MATERIALID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID  where bm.BOQITEMMATERIALID = o.BOQITEMMATERIALID ), "

					+ " FRATE = ( SELECT ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT "
					+ "FROM BOQITEM_MATERIAL as o JOIN MATERIAL as c ON o.MATERIALID = c.MATERIALID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID  where bm.BOQITEMMATERIALID = o.BOQITEMMATERIALID ), "

					+ " FINALFIXEDCOST = ( SELECT ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER "
					+ " FROM BOQITEM_MATERIAL as o JOIN MATERIAL as c ON o.MATERIALID = c.MATERIALID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID  where bm.BOQITEMMATERIALID = o.BOQITEMMATERIALID ), "

					+ " VARIABLECOST = ( SELECT ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY "
					+ " FROM BOQITEM_MATERIAL as o JOIN MATERIAL as c ON o.MATERIALID = c.MATERIALID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID where bm.BOQITEMMATERIALID = o.BOQITEMMATERIALID ), "

					+ " TOTALCOST = "
					+ " ( SELECT ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY + "
					+ " ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER "
					+ " FROM BOQITEM_MATERIAL as o JOIN MATERIAL as c ON o.MATERIALID = c.MATERIALID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID where bm.BOQITEMMATERIALID = o.BOQITEMMATERIALID ) "

					+ " where bm.MATERIALID in (:ids)";

			//		qs = "update o set " +
			//			"o.TOTALUNITS = p.QUANTITY*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.QTYPUNIT, " +
			//			"o.FRATE = ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +
			//			"o.TOTALCOST = ISNULL(c.BURATE,c.TOTALRATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY " +
			//			"FROM BOQITEM_MATERIAL as o JOIN MATERIAL as c ON o.MATERIALID = c.MATERIALID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID " +
			//			"where c.MATERIALID in (:ids)";
			bulkUpdateIds(session,qs,recalcIds);

			IList<long> parentIds = longIdsQuery(session,"select o.assemblyTable.assemblyId from AssemblyMaterialTable as o where o.materialTable.materialId in (:ids)",recalcIds);
			recalculateAssemblies(session, parentIds);

			parentIds = longIdsQuery(session,"select o.boqItemTable.boqitemId from BoqItemMaterialTable as o where o.materialTable.materialId in (:ids)",recalcIds);
			recalculateBoqItems(session, parentIds);
		}

		private static void recalculateConsumableParents(Session session, ICollection<long> recalcIds, bool updateBuildUps)
		{
			if (recalcIds.Count == 0)
			{
				return;
			}

			string qs = null;
			if (updateBuildUps)
			{
				RateBuildUpColumnsTable colTable = (RateBuildUpColumnsTable)session.createQuery("from RateBuildUpColumnsTable as o where o.resourceType = :rt").setString("rt",LayoutTable.CONSUMABLE).uniqueResult();
				if (colTable != null)
				{
					qs = buildUpUpdateQueryForResource("CONSUMABLE","RATE",colTable) + " where CONSUMABLEID in (:ids)";
					bulkUpdateIds(session,qs,recalcIds);
				}
			}

			//		String qs = "update AssemblyConsumableTable as o set " +
			//				"o.finalRate = o.consumableTable.rate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit " +
			//				"where o.consumableTable.consumableId in (:ids)";

			qs = "update ASSEMBLY_CONSUMABLE am set "
					+ "FRATE = ( SELECT (ISNULL(c.BURATE,c.RATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.EXCHANGERATE*o.QTYPUNIT) "
					+ "FROM ASSEMBLY_CONSUMABLE as o JOIN CONSUMABLE as c ON o.CONSUMABLEID = c.CONSUMABLEID where am.ASSEMBLYCONSUMABLEID = o.ASSEMBLYCONSUMABLEID), "

					+ "FINALFIXEDCOST = ( SELECT ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.EXCHANGERATE "
					+ "FROM ASSEMBLY_CONSUMABLE as o JOIN CONSUMABLE as c ON o.CONSUMABLEID = c.CONSUMABLEID where am.ASSEMBLYCONSUMABLEID = o.ASSEMBLYCONSUMABLEID) "

					+ "WHERE am.CONSUMABLEID in (:ids)";

			//		qs = "update o set " +
			//				"o.FRATE = (ISNULL(c.BURATE,c.RATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.EXCHANGERATE*o.QTYPUNIT) " +
			//				"FROM ASSEMBLY_CONSUMABLE as o JOIN CONSUMABLE as c ON o.CONSUMABLEID = c.CONSUMABLEID " +
			//				"where c.CONSUMABLEID in (:ids)";	
			//		
			//		System.out.println("\nEXECUTING1\n: "+qs+" ids: ("+recalcIds+")");
			bulkUpdateIds(session,qs,recalcIds);

			IList<long> parentIds = longIdsQuery(session,"select o.assemblyTable.assemblyId from AssemblyConsumableTable as o where o.consumableTable.consumableId in (:ids)",recalcIds);
			//		System.out.println("those consumable line item parents: "+parentIds);
			recalculateAssemblies(session, parentIds);

			//		qs = "update BoqItemConsumableTable as o set " +
			//				"o.TOTALUNITS = o.boqItemTable.quantity*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.quantityPerUnit " +				
			//				"o.finalRate = o.materialTable.rate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit, " +
			//				"o.totalCost = o.materialTable.rate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit*o.boqItemTable.quantity " +
			//				"where o.consumableTable.consumableId in (:ids)";		

			//		qs = "update o set " +
			//			"o.TOTALUNITS = p.QUANTITY*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.QTYPUNIT, " +
			//			"o.FRATE = ISNULL(c.BURATE,c.RATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +
			//			"o.TOTALCOST = ISNULL(c.BURATE,c.RATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY " +
			//			"FROM BOQITEM_CONSUMABLE as o JOIN CONSUMABLE as c ON o.CONSUMABLEID = c.CONSUMABLEID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID " +
			//			"where c.CONSUMABLEID in (:ids)";

			qs = "update BOQITEM_CONSUMABLE  bc set "
					+ "TOTALUNITS = ( SELECT p.QUANTITY*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.QTYPUNIT "
					+ "FROM BOQITEM_CONSUMABLE as o JOIN CONSUMABLE as c ON o.CONSUMABLEID = c.CONSUMABLEID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID where bc.BOQITEMCONSUMABLEID = o.BOQITEMCONSUMABLEID  ), "

					+ "FRATE = ( SELECT ISNULL(c.BURATE,c.RATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT "
					+ "FROM BOQITEM_CONSUMABLE as o JOIN CONSUMABLE as c ON o.CONSUMABLEID = c.CONSUMABLEID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID where bc.BOQITEMCONSUMABLEID = o.BOQITEMCONSUMABLEID ), "

					+ "FINALFIXEDCOST = ( SELECT ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER "
					+ "FROM BOQITEM_CONSUMABLE as o JOIN CONSUMABLE as c ON o.CONSUMABLEID = c.CONSUMABLEID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID where bc.BOQITEMCONSUMABLEID = o.BOQITEMCONSUMABLEID ), "

					+ "VARIABLECOST = (SELECT ISNULL(c.BURATE,c.RATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY  "
					+ "FROM BOQITEM_CONSUMABLE as o JOIN CONSUMABLE as c ON o.CONSUMABLEID = c.CONSUMABLEID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID where bc.BOQITEMCONSUMABLEID = o.BOQITEMCONSUMABLEID ), "

					+ "TOTALCOST = "
					+ "(SELECT ISNULL(c.BURATE,c.RATE)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY + "
					+ "ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.COSTCENTER "
					+ "FROM BOQITEM_CONSUMABLE as o JOIN CONSUMABLE as c ON o.CONSUMABLEID = c.CONSUMABLEID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID where bc.BOQITEMCONSUMABLEID = o.BOQITEMCONSUMABLEID ) "

					+ "where bc.CONSUMABLEID in (:ids)";

			//		System.out.println("\nEXECUTING2\n: "+qs);

			bulkUpdateIds(session,qs,recalcIds);


			parentIds = longIdsQuery(session,"select o.boqItemTable.boqitemId from BoqItemConsumableTable as o where o.consumableTable.consumableId in (:ids)",recalcIds);
			//		System.out.println("those consumable boq parents: "+parentIds);
			recalculateBoqItems(session, parentIds);
		}

		private static void recalculateAssemblyParents(Session session, ICollection<long> recalcIds)
		{
			if (recalcIds.Count == 0)
			{
				return;
			}

			//		String qs = "update AssemblyAssemblyTable as o set " +
			//				"o.finalRate = o.childTable.rate*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*o.quantityPerUnit " +
			//				"where o.childTable.assemblyId in (:ids)";

			string qs = "update ASSEMBLY_CHILD ac set "

					+ "FRATE = (SELECT (c.RATE*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.EXCHANGERATE*o.QTYPUNIT) "
					+ "FROM ASSEMBLY_CHILD as o JOIN ASSEMBLY as c ON o.CHILDID = c.ASSEMBLYID where ac.ASSEMBLYCHILDID = o.ASSEMBLYCHILDID ), "

					+ "FINALFIXEDCOST = "
					+ "(SELECT ( " +
						"(select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_CHILD s where s.ASSEMBLYID = o.ASSEMBLYID) + " +
						"(select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_SUBCONTRACTOR s where s.ASSEMBLYID = o.ASSEMBLYID) + " +
						"(select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID) + " +
						"(select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_MATERIAL s where s.ASSEMBLYID = o.ASSEMBLYID) + " +
						"(select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_CONSUMABLE s where s.ASSEMBLYID = o.ASSEMBLYID) + " +
						"(select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID)"
						+ " ) * o.EXCHANGERATE*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR "
					+ "FROM ASSEMBLY_CHILD as o JOIN ASSEMBLY as c ON o.CHILDID = c.ASSEMBLYID where ac.ASSEMBLYCHILDID = o.ASSEMBLYCHILDID ) "

					+ "where ac.CHILDID in (:ids)";
			//		String qs = "update o set " +
			//				"o.FRATE = (c.RATE*o.FACTOR1*o.FACTOR2*o.DIVIDER*o.LOCALFACTOR*o.EXCHANGERATE*o.QTYPUNIT) " +
			//				
			//				"FROM ASSEMBLY_CHILD as o JOIN ASSEMBLY as c ON o.CHILDID = c.ASSEMBLYID " +
			//				"where c.ASSEMBLYID in (:ids)";

			bulkUpdateIds(session,qs,recalcIds);

			IList<long> parentIds = longIdsQuery(session,"select o.parentTable.assemblyId from AssemblyAssemblyTable as o where o.childTable.assemblyId in (:ids)",recalcIds);
			recalculateAssemblies(session, parentIds);

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

			//		qs = "update o set " +
			//			"o.TOTALUNITS = p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT, " +
			//			"o.FRATE = c.RATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +
			//			"o.TOTALCOST = c.RATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY, " +
			//			"o.FLABRATE = c.LABRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +
			//			"o.LABCOST = c.LABRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY," +
			//			"o.FMATRATE = c.MATRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +
			//			"o.MATTOTCOST = c.MATRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY," +
			//			"o.FSUBRATE = c.SUBRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +
			//			"o.SUBCOST = c.SUBRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY," +
			//			"o.FEQURATE = c.EQURATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +
			//			"o.EQUCOST = c.EQURATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY," +
			//			"o.FCONRATE = c.CONRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT, " +
			//			"o.CONCOST = c.CONRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY " +
			//			"FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID " +
			//			"where c.ASSEMBLYID in (:ids)";

			qs = "update BOQITEM_ASSEMBLY  ba set "
					+ "TOTALUNITS = (SELECT p.QUANTITY*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.QTYPUNIT "
					+ "FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID WHERE ba.BOQITEMASSEMBLYID = o.BOQITEMASSEMBLYID  ),  "

					+ "FRATE = (SELECT  c.RATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT "
					+ "FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID WHERE ba.BOQITEMASSEMBLYID = o.BOQITEMASSEMBLYID ),  "

					+ "FINALFIXEDCOST = (SELECT "
					+ "((select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_CHILD s where s.ASSEMBLYID = o.ASSEMBLYID) + "
					+ "	(select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_CONSUMABLE s where s.ASSEMBLYID = o.ASSEMBLYID) + "
					+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID) + "
					+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID) + "
					+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_MATERIAL s where s.ASSEMBLYID = o.ASSEMBLYID) + "
					+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_SUBCONTRACTOR s where s.ASSEMBLYID = o.ASSEMBLYID))*o.COSTCENTER*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR "
					+ "FROM BOQITEM_ASSEMBLY as o /*JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID*/ WHERE ba.BOQITEMASSEMBLYID = o.BOQITEMASSEMBLYID), "

					+ "VARIABLECOST = (SELECT c.RATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY "
					+ "FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID WHERE ba.BOQITEMASSEMBLYID = o.BOQITEMASSEMBLYID),  "

	//				+ "TOTALCOST = "
	////				+ "0 + ("
	//				+ "(SELECT c.RATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY "
	////				+ "FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID WHERE ba.BOQITEMASSEMBLYID = o.BOQITEMASSEMBLYID) "
	//				+ " + "
	////				+ "( SELECT ( ( "
	//				+ "( (select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_CHILD s where s.ASSEMBLYID = o.ASSEMBLYID) + "
	//				+ "	(select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_CONSUMABLE s where s.ASSEMBLYID = o.ASSEMBLYID) + "
	//				+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID) + "
	//				+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID) + "
	//				+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_MATERIAL s where s.ASSEMBLYID = o.ASSEMBLYID) + "
	//				+ " (select ISNULL(sum(s.FINALFIXEDCOST),0) from ASSEMBLY_SUBCONTRACTOR s where s.ASSEMBLYID = o.ASSEMBLYID) ) * o.COSTCENTER "
	////				+ ") "
	//				+ "FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID WHERE ba.BOQITEMASSEMBLYID = o.BOQITEMASSEMBLYID), "
	////				+ "), "

					+ "FLABRATE = (SELECT  c.LABRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID WHERE ba.BOQITEMASSEMBLYID = o.BOQITEMASSEMBLYID  ),  "
					+ "LABCOST = (SELECT  c.LABRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID WHERE ba.BOQITEMASSEMBLYID = o.BOQITEMASSEMBLYID  ), "
					+ "FMATRATE = (SELECT  c.MATRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID WHERE ba.BOQITEMASSEMBLYID = o.BOQITEMASSEMBLYID  ),  "
					+ "MATTOTCOST = (SELECT  c.MATRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID WHERE ba.BOQITEMASSEMBLYID = o.BOQITEMASSEMBLYID  ), "
					+ "FSUBRATE = (SELECT  c.SUBRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID WHERE ba.BOQITEMASSEMBLYID = o.BOQITEMASSEMBLYID  ),  "
					+ "SUBCOST = (SELECT  c.SUBRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID WHERE ba.BOQITEMASSEMBLYID = o.BOQITEMASSEMBLYID ), "
					+ "FEQURATE = (SELECT  c.EQURATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID WHERE ba.BOQITEMASSEMBLYID = o.BOQITEMASSEMBLYID ),  "
					+ "EQUCOST = (SELECT  c.EQURATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID WHERE ba.BOQITEMASSEMBLYID = o.BOQITEMASSEMBLYID  ), "
					+ "FCONRATE = (SELECT  c.CONRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID WHERE ba.BOQITEMASSEMBLYID = o.BOQITEMASSEMBLYID ),  "
					+ "CONCOST = (SELECT  c.CONRATE*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.COSTCENTER*o.QTYPUNIT*p.QUANTITY FROM BOQITEM_ASSEMBLY as o JOIN ASSEMBLY as c ON o.ASSEMBLYID = c.ASSEMBLYID left JOIN BOQITEM as p ON p.BOQITEMID = o.BOQITEMID WHERE ba.BOQITEMASSEMBLYID = o.BOQITEMASSEMBLYID ) "
					+ "where ba.ASSEMBLYID in (:ids)";

			bulkUpdateIds(session,qs,recalcIds);

			// TOTAL COST:
			string qsTotalCost = "update BOQITEM_ASSEMBLY  ba set "
					+ "TOTALCOST = FINALFIXEDCOST + VARIABLECOST "
					+ "where ba.ASSEMBLYID in (:ids)";
			bulkUpdateIds(session,qsTotalCost,recalcIds);



		IList<object[]> varCost = (IList<object[]>) session.createSQLQuery("SELECT VARIABLECOST, FINALFIXEDCOST, (VARIABLECOST + FINALFIXEDCOST) AS TOTALCOST FROM BOQITEM_ASSEMBLY as o WHERE o.ASSEMBLYID in (:ids)").setParameterList("ids", recalcIds).list();
			foreach (object[] o in varCost)
			{
				Console.WriteLine("VARIABLECOST: " + o[0] + ", FINALFIXEDCOST: " + o[1] + ", TOTALCOST: " + o[2]);
			}

	//		bulkUpdateIds(session, qsTotalCost, recalcIds);

			parentIds = longIdsQuery(session,"select o.boqItemTable.boqitemId from BoqItemAssemblyTable as o where o.assemblyTable.assemblyId in (:ids)",recalcIds);
			recalculateBoqItems(session, parentIds);
		}

		private static void recalculateAssemblies(Session session, ICollection<long> ids)
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

			//		String qs = "update o set " +
			//				"o.UMHOURS = case when o.ACTBASED = 0 then (" +
			//				"(select ISNULL(sum(s.QTYPUNIT*s.FACTOR1*s.FACTOR2*s.FACTOR3),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
			//				"(select ISNULL(sum(c.UMHOURS),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)" +
			//				") else (CASE WHEN (1/NULLIF(o.PRODUCTIVITY,0)) is null THEN 1.0 ELSE 1.0/o.PRODUCTIVITY END) end," +
			//				"o.UEHOURS = case when o.ACTBASED = 0 then (" +
			//				"(select ISNULL(sum(s.QTYPUNIT*s.FACTOR1*s.FACTOR2*s.FACTOR3),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
			//				"(select ISNULL(sum(c.UEHOURS),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)" +
			//				") else (CASE WHEN (1/NULLIF(o.PRODUCTIVITY,0)) is null THEN 1.0 ELSE 1.0/o.PRODUCTIVITY END) end," +
			//				"o.rate = " +
			//				"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_SUBCONTRACTOR s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
			//				"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
			//				"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_MATERIAL s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
			//				"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_CONSUMABLE s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
			//				"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
			//				"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_CHILD s where s.ASSEMBLYID = o.ASSEMBLYID)," +
			//				"o.LABRATE = " +
			//				"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
			//				"(select ISNULL(sum(c.LABRATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)," +
			//				"o.EQURATE = " +
			//				"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
			//				"(select ISNULL(sum(c.EQURATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)," +
			//				"o.SUBRATE = " +
			//				"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_SUBCONTRACTOR s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
			//				"(select ISNULL(sum(c.SUBRATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)," +
			//				"o.MATRATE = " +
			//				"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_MATERIAL s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
			//				"(select ISNULL(sum(c.MATRATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)," +
			//				"o.CONRATE = " +
			//				"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_CONSUMABLE s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
			//				"(select ISNULL(sum(c.CONRATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)" +
			//				"FROM ASSEMBLY as o " +
			//				"where o.ASSEMBLYID in (:ids)";
			///OLD QUERY 


			string qs = "update ASSEMBLY o set " +
							"UMHOURS = case when o.ACTBASED = 0 then (0+" +
							"(select ISNULL(sum(s.QTYPUNIT*s.FACTOR1*s.FACTOR2*s.FACTOR3),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
							"(select ISNULL(sum(c.UMHOURS),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)" +
							") else (CASE WHEN (1/NULLIF(o.PRODUCTIVITY,0)) is null THEN 1.0 ELSE 1.0/o.PRODUCTIVITY END) end," +
							"UEHOURS = case when o.ACTBASED = 0 then (0+" +
							"(select ISNULL(sum(s.QTYPUNIT*s.FACTOR1*s.FACTOR2*s.FACTOR3),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
							"(select ISNULL(sum(c.UEHOURS),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)" +
							") else (CASE WHEN (1/NULLIF(o.PRODUCTIVITY,0)) is null THEN 1.0 ELSE 1.0/o.PRODUCTIVITY END) end," +
							"RATE = 0+" +
							"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_SUBCONTRACTOR s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
							"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
							"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_MATERIAL s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
							"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_CONSUMABLE s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
							"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
							"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_CHILD s where s.ASSEMBLYID = o.ASSEMBLYID)," +
							"LABRATE = 0+" +
							"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
							"(select ISNULL(sum(c.LABRATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)," +
							"EQURATE = 0+" +
							"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
							"(select ISNULL(sum(c.EQURATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)," +
							"SUBRATE = 0+" +
							"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_SUBCONTRACTOR s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
							"(select ISNULL(sum(c.SUBRATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)," +
							"MATRATE = 0+" +
							"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_MATERIAL s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
							"(select ISNULL(sum(c.MATRATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID)," +
							"CONRATE = 0+" +
							"(select ISNULL(sum(s.FRATE),0) from ASSEMBLY_CONSUMABLE s where s.ASSEMBLYID = o.ASSEMBLYID)+" +
							"(select ISNULL(sum(c.CONRATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID) " +
							"where o.ASSEMBLYID in (:ids)";

			//System.out.println("\n\n\n\n\nUPDATEQUERY: \n"+qs);
	//		String qs =  "update ASSEMBLY o set " +
	//				"UMHOURS = case when o.ACTBASED = 0 then (" +
	//				"( CONVERT((select ISNULL(sum(s.QTYPUNIT*s.FACTOR1*s.FACTOR2*s.FACTOR3),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL) )+" +
	//				"( CONVERT((select ISNULL(sum(c.UMHOURS),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL) )" +
	//				") else (CASE WHEN (1/NULLIF(o.PRODUCTIVITY,0)) is null THEN 1.0 ELSE 1.0/o.PRODUCTIVITY END) end," +
	//				"UEHOURS = case when o.ACTBASED = 0 then (" +
	//				"( CONVERT((select ISNULL(sum(s.QTYPUNIT*s.FACTOR1*s.FACTOR2*s.FACTOR3),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL)  )+" +
	//				"( CONVERT((select ISNULL(sum(c.UEHOURS),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL)  )" +
	//				") else (CASE WHEN (1/NULLIF(o.PRODUCTIVITY,0)) is null THEN 1.0 ELSE 1.0/o.PRODUCTIVITY END) end";
			/*+ "," +
					"rate = " +
					"( CONVERT((select ISNULL(sum(s.FRATE),0) from ASSEMBLY_SUBCONTRACTOR s where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL) )+" +
					"(CONVERT((select ISNULL(sum(s.FRATE),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL)  )+" +
					"(CONVERT((select ISNULL(sum(s.FRATE),0) from ASSEMBLY_MATERIAL s where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL)  )+" +
					"(CONVERT((select ISNULL(sum(s.FRATE),0) from ASSEMBLY_CONSUMABLE s where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL)  )+" +
					"(CONVERT((select ISNULL(sum(s.FRATE),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL)  )+" +
					"(CONVERT((select ISNULL(sum(s.FRATE),0) from ASSEMBLY_CHILD s where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL)  )," +
					"LABRATE = " +
					"(CONVERT((select ISNULL(sum(s.FRATE),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL))+" +
					"(CONVERT((select ISNULL(sum(c.LABRATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL))," +
					"EQURATE = " +
					"(CONVERT((select ISNULL(sum(s.FRATE),0) from ASSEMBLY_EQUIPMENT s where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL))+" +
					"(CONVERT((select ISNULL(sum(c.EQURATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL))," +
					"SUBRATE = " +
					"(CONVERT((select ISNULL(sum(s.FRATE),0) from ASSEMBLY_SUBCONTRACTOR s where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL))+" +
					"(CONVERT((select ISNULL(sum(c.SUBRATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL))," +
					"MATRATE = " +
					"(CONVERT((select ISNULL(sum(s.FRATE),0) from ASSEMBLY_MATERIAL s where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL))+" +
					"(CONVERT((select ISNULL(sum(c.MATRATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL))," +
					"CONRATE = " +
					"(CONVERT((select ISNULL(sum(s.FRATE),0) from ASSEMBLY_CONSUMABLE s where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL))+" +
					"(CONVERT((select ISNULL(sum(c.CONRATE*s.FACTOR1*s.FACTOR2*s.DIVIDER*s.LOCALFACTOR*s.EXCHANGERATE*s.QTYPUNIT),0) from ASSEMBLY_CHILD s JOIN ASSEMBLY c ON s.CHILDID = c.ASSEMBLYID where s.ASSEMBLYID = o.ASSEMBLYID AND o.ASSEMBLYID in (:ids)),SQL_DECIMAL) )" ;
			 */
			//System.out.println("\n\n\n\n\nUPDATEQUERY: \n"+qs);
			//System.out.println("Assembly Query is: "+qs);
			//System.out.println("query is "+qs);

			bulkUpdateIds(session,qs,ids);

			//		System.out.println("AFTER RECALCULATION labor rate: "+session.createQuery("select o.laborRate from AssemblyTable o where o.assemblyId = "+ids.get(0)).uniqueResult());
			//		System.out.println("OR SUM ID: "+session.createSQLQuery("Select ISNULL(sum(s.FRATE),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = "+ids.get(0)).uniqueResult());

			//		System.out.println("Recalculated assemblies -> "+ids);
			recalculateAssemblyParents(session, ids);
		}

		private static void recalculateBoqItems(Session session, ICollection<long> ids)
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

			string qs = "update BOQITEM o set " +
					"MANHOURS = 0+" +
					"(select ISNULL(sum(s.TOTALUNITS),0) from BOQITEM_LABOR s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(c.UMHOURS),0) from BOQITEM_ASSEMBLY s LEFT OUTER JOIN ASSEMBLY c ON s.ASSEMBLYID = c.ASSEMBLYID where s.BOQITEMID = o.BOQITEMID)*o.QUANTITY," +
					"EQUHOURS = 0+" +
					"(select ISNULL(sum(s.TOTALUNITS),0) from BOQITEM_EQUIPMENT s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(c.UEHOURS),0) from BOQITEM_ASSEMBLY s LEFT OUTER JOIN ASSEMBLY c ON s.ASSEMBLYID = c.ASSEMBLYID where s.BOQITEMID = o.BOQITEMID)*o.QUANTITY," +
					//				"o.rate = " +
					//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_SUBCONTRACTOR s where s.BOQITEMID = o.BOQITEMID)+" +
					//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_LABOR s where s.BOQITEMID = o.BOQITEMID)+" +
					//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_MATERIAL s where s.BOQITEMID = o.BOQITEMID)+" +
					//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_CONSUMABLE s where s.BOQITEMID = o.BOQITEMID)+" +
					//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_EQUIPMENT s where s.BOQITEMID = o.BOQITEMID)+" +
					//				"(select ISNULL(sum(s.FRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +
					"MEASQUANT = 0+" +
					"(select ISNULL(sum(s.FQTY),0) from BOQITEM_CONDITION s where s.BOQITEMID = o.BOQITEMID)," +
					"ASSRATE = 0+" +
					"(select ISNULL(sum(s.FRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +

					"LABRATE = 0+" +
					"(select ISNULL(sum(s.FRATE),0) from BOQITEM_LABOR s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FLABRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +
					"EQURATE = 0+" +
					"(select ISNULL(sum(s.FRATE),0) from BOQITEM_EQUIPMENT s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FEQURATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +
					"SUBRATE = 0+" +
					"(select ISNULL(sum(s.FRATE),0) from BOQITEM_SUBCONTRACTOR s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FSUBRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +
					"MATRATE = 0+" +
					"(select ISNULL(sum(s.FRATE),0) from BOQITEM_MATERIAL s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FMATRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +
					"CONRATE = 0+" +
					"(select ISNULL(sum(s.FRATE),0) from BOQITEM_CONSUMABLE s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FCONRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)," +
					"SUBQUOTERATE = 0+(select ISNULL(sum(bs.FRATE),0) from BOQITEM_SUBCONTRACTOR bs JOIN SUBCONTRACTOR s on bs.SUBCONTRACTORID = s.SUBCONTRACTORID where bs.BOQITEMID = o.BOQITEMID AND s.ACCURACY like '" + SubcontractorTable.QUOTED_ACCURACY + "'), " +
					"MATQUOTERATE = 0+(select ISNULL(sum(bs.FRATE),0) from BOQITEM_MATERIAL bs JOIN MATERIAL s on bs.MATERIALID = s.MATERIALID where bs.BOQITEMID = o.BOQITEMID AND s.ACCURACY like '" + MaterialTable.QUOTED_ACCURACY + "'), " +

					"FIXEDCOST = 0+" +
					"(select ISNULL(sum(s.FINALFIXEDCOST),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FINALFIXEDCOST),0) from BOQITEM_CONSUMABLE s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FINALFIXEDCOST),0) from BOQITEM_EQUIPMENT s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FINALFIXEDCOST),0) from BOQITEM_LABOR s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FINALFIXEDCOST),0) from BOQITEM_MATERIAL s where s.BOQITEMID = o.BOQITEMID)+" +
					"(select ISNULL(sum(s.FINALFIXEDCOST),0) from BOQITEM_SUBCONTRACTOR s where s.BOQITEMID = o.BOQITEMID) " +

					"where o.BOQITEMID in (:ids)";

	//		String qs = "update BOQITEM o set MANHOURS = ( CONVERT(( select ISNULL(sum(s.TOTALUNITS),0) from BOQITEM_LABOR s where s.BOQITEMID = o.BOQITEMID AND o.BOQITEMID in (:ids)),SQL_DECIMAL) )+(CONVERT((select ISNULL(sum(c.UMHOURS),0) from BOQITEM_ASSEMBLY s LEFT OUTER JOIN ASSEMBLY c ON s.ASSEMBLYID = c.ASSEMBLYID where s.BOQITEMID = o.BOQITEMID AND o.BOQITEMID in (:ids)),SQL_DECIMAL)   )*QUANTITY,"
	//				+ "EQUHOURS = "
	//				+ "( CONVERT(( select ISNULL(sum(s.TOTALUNITS),0) from BOQITEM_EQUIPMENT s where s.BOQITEMID = o.BOQITEMID  AND o.BOQITEMID in (:ids)),SQL_DECIMAL) )+"
	//				+ "( CONVERT(( select ISNULL(sum(c.UEHOURS),0) from BOQITEM_ASSEMBLY s LEFT OUTER JOIN ASSEMBLY c ON s.ASSEMBLYID = c.ASSEMBLYID where s.BOQITEMID = o.BOQITEMID  AND o.BOQITEMID in (:ids) ),SQL_DECIMAL))*QUANTITY,"
	//				+ "MEASQUANT = "
	//				+ "( CONVERT(( select ISNULL(sum(s.FQTY),0) from BOQITEM_CONDITION s where s.BOQITEMID = o.BOQITEMID AND o.BOQITEMID in (:ids) ),SQL_DECIMAL) ),"
	//				+ "ASSRATE = "
	//				+ "( CONVERT(( select ISNULL(sum(s.FRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID AND o.BOQITEMID in (:ids) ),SQL_DECIMAL) ),"
	//				+ "LABRATE = "
	//				+ "( CONVERT(( select ISNULL(sum(s.FRATE),0) from BOQITEM_LABOR s where s.BOQITEMID = o.BOQITEMID AND o.BOQITEMID in (:ids) ),SQL_DECIMAL)  )+"
	//				+ "( CONVERT(( select ISNULL(sum(s.FLABRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID AND o.BOQITEMID in (:ids) ),SQL_DECIMAL)  ),"
	//				+ "EQURATE = "
	//				+ "( CONVERT(( select ISNULL(sum(s.FRATE),0) from BOQITEM_EQUIPMENT s where s.BOQITEMID = o.BOQITEMID AND o.BOQITEMID in (:ids) ),SQL_DECIMAL)  )+"
	//				+ "( CONVERT(( select ISNULL(sum(s.FEQURATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID  AND o.BOQITEMID in (:ids) ),SQL_DECIMAL)  ),"
	//				+ "SUBRATE = "
	//
	//
	//
	//
	//
	//
	//
	//
	//
	//				+ "( CONVERT(( select ISNULL(sum(s.FRATE),0) from BOQITEM_SUBCONTRACTOR s where s.BOQITEMID = o.BOQITEMID AND o.BOQITEMID in (:ids) ),SQL_DECIMAL)   )+"
	//				+ "( CONVERT(( select ISNULL(sum(s.FSUBRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID AND o.BOQITEMID in (:ids) ),SQL_DECIMAL) ),"
	//				+ "MATRATE = "
	//				+ "( CONVERT(( select ISNULL(sum(s.FRATE),0) from BOQITEM_MATERIAL s where s.BOQITEMID = o.BOQITEMID AND o.BOQITEMID in (:ids) ),SQL_DECIMAL) )+"
	//				+ "( CONVERT(( select ISNULL(sum(s.FMATRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID AND o.BOQITEMID in (:ids) ),SQL_DECIMAL)  ),"
	//				+ "CONRATE = "
	//				+ "( CONVERT(( select ISNULL(sum(s.FRATE),0) from BOQITEM_CONSUMABLE s where s.BOQITEMID = o.BOQITEMID AND o.BOQITEMID in (:ids) ),SQL_DECIMAL) )+"
	//				+ "( CONVERT(( select ISNULL(sum(s.FCONRATE),0) from BOQITEM_ASSEMBLY s where s.BOQITEMID = o.BOQITEMID  AND o.BOQITEMID in (:ids) ),SQL_DECIMAL) ),"
	//				+ "SUBQUOTERATE = ( CONVERT(( select ISNULL(sum(bs.FRATE),0) from BOQITEM_SUBCONTRACTOR bs JOIN SUBCONTRACTOR s on bs.SUBCONTRACTORID = s.SUBCONTRACTORID where bs.BOQITEMID = o.BOQITEMID AND s.ACCURACY like '"+SubcontractorTable.QUOTED_ACCURACY+"' AND o.BOQITEMID in (:ids) ),SQL_DECIMAL)  ), "
	//				+ "MATQUOTERATE = ( CONVERT(( select ISNULL(sum(bs.FRATE),0) from BOQITEM_MATERIAL bs JOIN MATERIAL s on bs.MATERIALID = s.MATERIALID where bs.BOQITEMID = o.BOQITEMID AND s.ACCURACY like '"+MaterialTable.QUOTED_ACCURACY+"' AND o.BOQITEMID in (:ids) ),SQL_DECIMAL)  ) ";
			bulkUpdateIds(session,qs,ids);

					Console.WriteLine("Recalculated BOQITEMS -> " + ids);
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
			IList<System.Collections.IList> chunks = splitIntoChunks(recalcIds, 1999);

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
			IList<System.Collections.IList> chunks = splitIntoChunks(ids, 1999);
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

		private static ISet<long> findRelatedBoqItems(Session session, string tableName, string varName, string idName, ICollection<long> updIds)
		{
			if (updIds.Count == 0)
			{
				return Collections.EMPTY_SET;
			}

			ISet<long> updBoqItems = new HashSet<long>();
			updBoqItems.addAll(longIdsQuery(session, "select o.boqItemTable.boqitemId from BoqItem" + tableName + " as o where o." + varName + "." + idName + " in (:ids)", updIds));

			string qs = "select o.assemblyTable.assemblyId from Assembly" + tableName + " as o where o." + varName + "." + idName + " in (:ids)";
			if (tableName.Equals("AssemblyTable"))
			{
				qs = "select o.parentTable.assemblyId from AssemblyAssemblyTable as o where o.childTable.assemblyId in (:ids)";
			}
			IList<long> assIds = longIdsQuery(session, qs, updIds);

			while (assIds.Count != 0)
			{
				updBoqItems.addAll(longIdsQuery(session, "select o.boqItemTable.boqitemId from BoqItemAssemblyTable as o where o.assemblyTable.assemblyId in (:ids)", assIds));
				assIds = longIdsQuery(session, "select o.parentTable.assemblyId from AssemblyAssemblyTable as o where o.childTable.assemblyId in (:ids)", assIds);
			}

			return updBoqItems;
		}
	}


}