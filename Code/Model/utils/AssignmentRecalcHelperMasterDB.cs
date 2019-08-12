using System;
using System.Collections.Generic;

namespace Model.utils
{

	using Session = org.hibernate.Session;

	using ResourceTableDefinition = nomitech.common.data.definition.ResourceTableDefinition;
	using AssemblyTable = nomitech.common.db.local.AssemblyTable;
	using EquipmentTable = nomitech.common.db.local.EquipmentTable;
	using LaborTable = nomitech.common.db.local.LaborTable;
	using UIProgress = nomitech.common.ui.UIProgress;

	public class AssignmentRecalcHelperMasterDB
	{

		public static void bottomUpRecalculate(UIProgress prgDialog, Session session, ResourceTableDefinition tableDefinition, ICollection<long> recalcIds)
		{

			if (tableDefinition.TableClass.Equals(typeof(LaborTable)))
			{
				recalculateLaborParents(session, recalcIds);
			}
			else if (tableDefinition.TableClass.Equals(typeof(EquipmentTable)))
			{
				recalculateEquipmentParents(session, recalcIds);
			}
			else if (tableDefinition.TableClass.Equals(typeof(AssemblyTable)))
			{
				recalculateAssemblies(session, recalcIds);
			}

		}

		private static void recalculateLaborParents(Session session, ICollection<long> recalcIds)
		{
			if (recalcIds.Count == 0)
			{
				return;
			}

			string qs = "update o set " +
					"o.FRATE = (c.TOTALRATE/o.UNITHOURS)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*(CASE WHEN p.ACTBASED = 0 THEN o.QTYPUNIT WHEN p.ACTBASED = 1 THEN CASE WHEN 1/NULLIF(p.PRODUCTIVITY,0)  is null THEN 0 ELSE 1/p.PRODUCTIVITY END END), " +

					"o.FIKARATE = (c.IKA/o.UNITHOURS)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*(CASE WHEN p.ACTBASED = 0 THEN o.QTYPUNIT WHEN p.ACTBASED = 1 THEN CASE WHEN 1/NULLIF(p.PRODUCTIVITY,0)  is null THEN 0 ELSE 1/p.PRODUCTIVITY END END), " +

					"o.FINALFIXEDCOST = ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE " +

					"FROM ASSEMBLY_LABOR as o JOIN LABOR as c ON o.LABORID = c.LABORID left JOIN ASSEMBLY as p ON p.ASSEMBLYID = o.ASSEMBLYID " +

					"where o.LABORID in (:ids)";

			bulkUpdateIds(session, qs, recalcIds);

			IList<long> parentIds = longIdsQuery(session,"select o.assemblyTable.assemblyId from AssemblyLaborTable as o where o.laborTable.laborId in (:ids)", recalcIds);
			recalculateAssemblies(session, parentIds);
		}

		private static void recalculateEquipmentParents(Session session, ICollection<long> recalcIds)
		{
			if (recalcIds.Count == 0)
			{
				return;
			}

			string qs = "update o set " +
					"o.FRATE = (c.TOTALRATE/o.UNITHOURS)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE*(CASE WHEN p.ACTBASED = 0 THEN o.QTYPUNIT WHEN p.ACTBASED = 1 THEN CASE WHEN 1/NULLIF(p.PRODUCTIVITY,0) is null THEN 0 ELSE 1/p.PRODUCTIVITY END END), " +

					"o.FINALFIXEDCOST = ISNULL(o.FIXEDCOST,0)*o.FACTOR1*o.FACTOR2*o.FACTOR3*o.LOCALFACTOR*o.EXCHANGERATE " +

					"FROM ASSEMBLY_EQUIPMENT as o JOIN EQUIPMENT as c ON o.EQUIPMENTID = c.EQUIPMENTID left JOIN ASSEMBLY as p ON p.ASSEMBLYID = o.ASSEMBLYID " +

					"where c.EQUIPMENTID in (:ids)";
			bulkUpdateIds(session, qs, recalcIds);

			IList<long> parentIds = longIdsQuery(session,"select o.assemblyTable.assemblyId from AssemblyEquipmentTable as o where o.equipmentTable.equipmentId in (:ids)", recalcIds);
			recalculateAssemblies(session, parentIds);
		}

		private static void recalculateAssemblies(Session session, ICollection<long> recalcIds)
		{
			if (recalcIds != null && recalcIds.Count == 0)
			{
				return;
			}

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

					"where o.ASSEMBLYID in (:ids)";


	//		System.out.println("Assembly Query is: "+qs);
			bulkUpdateIds(session,qs,recalcIds);

	//		System.out.println("AFTER RECALCULATION labor rate: "+session.createQuery("select o.laborRate from AssemblyTable o where o.assemblyId = "+ids.get(0)).uniqueResult());
	//		System.out.println("OR SUM ID: "+session.createSQLQuery("Select ISNULL(sum(s.FRATE),0) from ASSEMBLY_LABOR s where s.ASSEMBLYID = "+ids.get(0)).uniqueResult());

	//		System.out.println("Recalculated assemblies -> "+ids);
			recalculateAssemblyParents(session, recalcIds);
		}

		private static void recalculateAssemblyParents(Session session, ICollection<long> recalcIds)
		{
			if (recalcIds.Count == 0)
			{
				return;
			}

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
					"where o.CHILDID in (:ids)";

			bulkUpdateIds(session, qs, recalcIds);

			IList<long> parentIds = longIdsQuery(session,"select o.parentTable.assemblyId from AssemblyAssemblyTable as o where o.childTable.assemblyId in (:ids)", recalcIds);
			recalculateAssemblies(session, parentIds);
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
	}

}