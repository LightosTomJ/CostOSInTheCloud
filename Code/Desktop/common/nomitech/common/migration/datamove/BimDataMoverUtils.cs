using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common.migration.datamove
{
	using Kryo = com.esotericsoftware.kryo.Kryo;
	using ObjectMapper = com.fasterxml.jackson.databind.ObjectMapper;
	using GeometryFileTable = nomitech.bimengine.model.data.GeometryFileTable;
	using Element = nomitech.bimengine.model.geom.cryov2.Element;
	using GeometryGroup = nomitech.bimengine.model.geom.cryov2.GeometryGroup;
	using SerializationUtil = nomitech.bimengine.util.SerializationUtil;
	using BimModelMetadata = Desktop.common.nomitech.common.migration.datamove.metadata.BimModelMetadata;
	using BimModelWithProposedProject = Desktop.common.nomitech.common.migration.datamove.metadata.BimModelWithProposedProject;
	using BimProject = Desktop.common.nomitech.common.migration.datamove.metadata.BimProject;
	using BimProjectMetadata = Desktop.common.nomitech.common.migration.datamove.metadata.BimProjectMetadata;
	using UILanguage = nomitech.common.ui.UILanguage;
	using UIProgress = nomitech.common.ui.UIProgress;
	using LogManager = org.apache.log4j.LogManager;
	using Logger = org.apache.log4j.Logger;
	using SQLQuery = org.hibernate.SQLQuery;
	using Session = org.hibernate.Session;

	public class BimDataMoverUtils
	{
	  internal static readonly Logger logger = LogManager.getLogger(typeof(BimDataMoverUtils));

	  public static IDictionary<long, string> getModelsReferedInProject(UIProgress paramUIProgress, Session paramSession, long? paramLong)
	  {
		Session session = DatabaseDBUtil.currentSession();
		SQLQuery sQLQuery1 = paramSession.createSQLQuery("SELECT DISTINCT DBNAME from CNDON where PRJID = :id and TAKEOFFTYPE = :type");
		sQLQuery1.setLong("id", paramLong.Value);
		sQLQuery1.setString("type", "BIM");
		System.Collections.IList list1 = sQLQuery1.list();
		List<object> arrayList = new List<object>();
		list1.ForEach(paramString =>
		{
		try
		{
			paramList.add(Convert.ToInt64(long.Parse(paramString)));
		}
		catch (Exception throwable)
		{
			logger.error(throwable);
		}
		});
		SQLQuery sQLQuery2 = session.createSQLQuery("select BC_MODEL.ID, BC_MODEL.NAME, BC_MODEL.REV, BC_MODEL.APPNAME, SUM(LEN(BC_GEOMFILE.FDATA)) as SIZE from BC_MODEL JOIN BC_GEOMFILE ON BC_GEOMFILE.MODEL_ID = BC_MODEL.ID where BC_MODEL.ID in (:ids) group by BC_MODEL.ID, BC_MODEL.NAME, BC_MODEL.REV, BC_MODEL.APPNAME");
		sQLQuery2.setParameterList("ids", arrayList);
		System.Collections.IList list2 = sQLQuery2.list();
		Hashtable hashMap = new Hashtable(list2.Count);
		list2.ForEach(paramArrayOfObject =>
		{
		long? long = Convert.ToInt64(((Number)paramArrayOfObject[0]).longValue());
		string str1 = (string)paramArrayOfObject[1];
		string str2 = (string)paramArrayOfObject[2];
		string str3 = (string)paramArrayOfObject[3];
		Number number = (Number)paramArrayOfObject[4];
		double d = number.doubleValue() / 1048576.0D;
		paramMap.put(long, string.Format("{0} {1:F2} MB", new object[] {str1, Convert.ToDouble(d)}));
		});
		return hashMap;
	  }

	  public static bool projectRefersToModels(UIProgress paramUIProgress, Session paramSession, long? paramLong)
	  {
		paramUIProgress.Progress = UILanguage.get("tab.project.processing.model.check");
		SQLQuery sQLQuery = paramSession.createSQLQuery("SELECT count(1) from CNDON where PRJID = :id and TAKEOFFTYPE = :type");
		sQLQuery.setLong("id", paramLong.Value);
		sQLQuery.setString("type", "BIM");
		Number number = (Number)sQLQuery.list().get(0);
		return (number.intValue() != 0);
	  }

	  internal static IList<IList<long>> listToBatches(IList<long> paramList, int paramInt)
	  {
		if (paramInt <= 0)
		{
		  throw new System.ArgumentException("Batch Size cannot be less than 1");
		}
		if (paramList == null)
		{
		  return null;
		}
		List<object> arrayList = new List<object>();
		for (int i = 0; i < paramList.Count; i += paramInt)
		{
		  int j = Math.Min(i + paramInt, paramList.Count);
		  arrayList.Add(paramList.subList(i, j));
		}
		return arrayList;
	  }

	  public static BimModelMetadata[] getModelMetadataInCEP(File paramFile)
	  {
		BimModelMetadata[] arrayOfBimModelMetadata = null;
		File file = new File(paramFile, "modelDB.json");
		if (!file.exists())
		{
		  return arrayOfBimModelMetadata;
		}
		ObjectMapper objectMapper = new ObjectMapper();
		try
		{
				using (StreamReader null = new StreamReader(file))
				{
			  arrayOfBimModelMetadata = (BimModelMetadata[])objectMapper.readValue(fileReader, typeof(BimModelMetadata[]));
				}
		}
		catch (IOException iOException)
		{
		  logger.error("Cannot read BimModel info", iOException);
		}
		return arrayOfBimModelMetadata;
	  }

	  public static IList<BimModelWithProposedProject> getModelsInCEP(Session paramSession, File paramFile)
	  {
		List<object> arrayList = new List<object>();
		BimModelMetadata[] arrayOfBimModelMetadata = getModelMetadataInCEP(paramFile);
		if (arrayOfBimModelMetadata == null || arrayOfBimModelMetadata.Length == 0)
		{
		  return arrayList;
		}
		foreach (BimModelMetadata bimModelMetadata in arrayOfBimModelMetadata)
		{
		  if (!modelAlreadyExists(paramSession, bimModelMetadata.GlobalId))
		  {
			BimModelWithProposedProject bimModelWithProposedProject = new BimModelWithProposedProject();
			bimModelWithProposedProject.ModelId = bimModelMetadata.Id;
			bimModelWithProposedProject.ModelName = bimModelMetadata.Name;
			bimModelWithProposedProject.ProposedProjectId = proposeProjectLocationId(paramSession, bimModelMetadata.Project);
			arrayList.Add(bimModelWithProposedProject);
		  }
		}
		return arrayList;
	  }

	  public static IList<BimProject> listProjects(Session paramSession)
	  {
		string str = "\tSELECT ID, NAME FROM BC_PROJECT WHERE DELETED = 0 or DELETED is null";
		System.Collections.IList list = paramSession.createSQLQuery(str).list();
		List<object> arrayList = new List<object>();
		list.ForEach(paramArrayOfObject =>
		{
		Number number = (Number)paramArrayOfObject[0];
		string str = (string)paramArrayOfObject[1];
		BimProject bimProject = new BimProject();
		bimProject.Id = Convert.ToInt64(number.longValue());
		bimProject.Name = str;
		paramList.add(bimProject);
		});
		return arrayList;
	  }

	  private static long? proposeProjectLocationId(Session paramSession, BimProjectMetadata paramBimProjectMetadata)
	  {
		if (paramBimProjectMetadata == null)
		{
		  return null;
		}
		string str1 = paramBimProjectMetadata.GlobalId;
		string str2 = paramBimProjectMetadata.Name;
		if (string.ReferenceEquals(str1, null) || str1.Trim().Length == 0)
		{
		  System.Collections.IList list1 = paramSession.createSQLQuery("select ID from BC_PROJECT where NAME = :name and (DELETED = 0 or DELETED is null)").setString("name", str2).list();
		  return list1.Count == 0 ? null : Convert.ToInt64(((Number)list1[0]).longValue());
		}
		System.Collections.IList list = paramSession.createSQLQuery("select ID from BC_PROJECT where GLOBALID = :globalId and (DELETED = 0 or DELETED is null)").setString("globalId", str1).list();
		return list.Count == 0 ? null : Convert.ToInt64(((Number)list[0]).longValue());
	  }

	  private static bool modelAlreadyExists(Session paramSession, string paramString)
	  {
		if (string.ReferenceEquals(paramString, null) || paramString.Trim().Length == 0)
		{
		  return false;
		}
		System.Collections.IList list = paramSession.createSQLQuery("select count(1) from BC_MODEL where STATUS = :status AND GLOBALID = :globalId").setString("globalId", paramString).setByte("status", (sbyte)2).list();
		return (((Number)list[0]).longValue() != 0L);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: static void fixSerializedData(java.sql.Connection paramConnection, System.Nullable<long> paramLong) throws java.sql.SQLException, java.io.IOException
	  internal static void fixSerializedData(Connection paramConnection, long? paramLong)
	  {
		Hashtable hashMap = new Hashtable();
		string str1 = "select ID, GLOBALID from BC_GEOMETRY where MODEL_ID = ?";
		string str2 = "SELECT ID, FDATA, SERIALIZATION_TYPE FROM BC_GEOMFILE WHERE FTYPE = ? AND MODEL_ID = ?";
		string str3 = "update BC_GEOMFILE set FDATA = ?, SERIALIZATION_TYPE = ? where id = ?";
		using (PreparedStatement null = paramConnection.prepareStatement(str1))
		{
		  preparedStatement.setLong(1, paramLong.Value);
		  using (ResultSet null = preparedStatement.executeQuery())
		  {
			while (resultSet.next())
			{
			  string str = resultSet.getString(2);
			  long l = resultSet.getLong(1);
			  hashMap[str] = Convert.ToInt64(l);
			}
		  }
		}
		using (PreparedStatement null = paramConnection.prepareStatement(str2))
		{
		  preparedStatement.setInt(1, GeometryFileTable.TYPE.BINARY_MODEL.ordinal());
		  preparedStatement.setLong(2, paramLong.Value);
		  using (ResultSet null = preparedStatement.executeQuery())
		  {
			while (resultSet.next())
			{
			  long l = resultSet.getLong(1);
			  Blob blob = resultSet.getBlob(2);
			  int i = resultSet.getInt(3);
			  GeometryFileTable.SERIALIZATION sERIALIZATION1 = GeometryFileTable.SERIALIZATION.values()[i];
			  sbyte[] arrayOfByte1 = blob.getBytes(1L, (int)blob.length());
			  GeometryGroup geometryGroup = SerializationUtil.deserializeGeomGroupDataCryoV2(arrayOfByte1, sERIALIZATION1);
			  geometryGroup.ModelId = paramLong.Value;
			  foreach (Element element in geometryGroup.Elements)
			  {
				string str = element.GlobalId;
				long l1 = ((long?)hashMap[str]).Value;
				element.Id = l1;
			  }
			  GeometryFileTable.SERIALIZATION sERIALIZATION2 = GeometryFileTable.SERIALIZATION.CRYO_V2;
			  int j = sERIALIZATION2.ordinal();
			  Kryo kryo = SerializationUtil.getKryoSerializer(sERIALIZATION2);
			  sbyte[] arrayOfByte2 = SerializationUtil.serializeToByteArray(kryo, sERIALIZATION2, geometryGroup);
			  using (PreparedStatement null = paramConnection.prepareStatement(str3))
			  {
				preparedStatement1.setBytes(1, arrayOfByte2);
				preparedStatement1.setInt(2, j);
				preparedStatement1.setLong(3, l);
				preparedStatement1.executeUpdate();
			  }
			}
		  }
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void fixConditionDatabaseIds(java.sql.Connection paramConnection, System.Nullable<long> paramLong, java.util.Map<long, long> paramMap) throws java.sql.SQLException
	  public static void fixConditionDatabaseIds(Connection paramConnection, long? paramLong, IDictionary<long, long> paramMap)
	  {
		if (paramMap.Count == 0)
		{
		  return;
		}
		string str = "update CNDON set DBNAME = ? where DBNAME = ? and PRJID ";
		if (paramLong == null)
		{
		  str = str + " is null";
		}
		else
		{
		  str = str + " = ?";
		}
		using (PreparedStatement null = paramConnection.prepareStatement(str))
		{
		  paramMap.forEach((paramLong2, paramLong3) =>
		  {
		  try
		  {
			  paramPreparedStatement.setString(1, paramLong3.ToString());
			  paramPreparedStatement.setString(2, paramLong2.ToString());
			  if (paramLong1 != null)
			  {
				  paramPreparedStatement.setLong(3, paramLong1.longValue());
			  }
			  paramPreparedStatement.addBatch();
		  }
		  catch (SQLException sQLException)
		  {
			  Console.WriteLine(sQLException.ToString());
			  Console.Write(sQLException.StackTrace);
		  }
		  });
		  preparedStatement.executeBatch();
		}
	  }

	  public static IDictionary<long, long> fillExistingModelIds(Session paramSession, IDictionary<long, long> paramMap, File paramFile)
	  {
		Hashtable hashMap1 = new Hashtable();
		if (paramMap != null)
		{
//JAVA TO C# CONVERTER TODO TASK: There is no .NET Dictionary equivalent to the Java 'putAll' method:
		  hashMap1.putAll(paramMap);
		}
		if (paramFile == null)
		{
		  return hashMap1;
		}
		BimModelMetadata[] arrayOfBimModelMetadata = getModelMetadataInCEP(paramFile);
		if (arrayOfBimModelMetadata == null || arrayOfBimModelMetadata.Length == 0)
		{
		  return hashMap1;
		}
		Hashtable hashMap2 = new Hashtable();
		foreach (BimModelMetadata bimModelMetadata in arrayOfBimModelMetadata)
		{
		  string str = bimModelMetadata.GlobalId;
		  if (!string.ReferenceEquals(str, null) && str.Trim().Length > 0)
		  {
			hashMap2[bimModelMetadata.Id] = str;
		  }
		}
		Hashtable hashMap3 = new Hashtable();
		System.Collections.IList list = paramSession.createSQLQuery("select ID, GLOBALID from BC_MODEL where STATUS = :status AND GLOBALID in (:globalIds)").setByte("status", (sbyte)2).setParameterList("globalIds", hashMap2.Values).list();
		foreach (object @object in list)
		{
		  long l = ((Number)(object[])@object[0]).longValue();
		  string str = (string)(object[])@object[1];
		  hashMap3[str] = Convert.ToInt64(l);
		}
		hashMap2.forEach((paramLong, paramString) =>
		{
		if (paramMap1.containsKey(paramLong))
		{
			return;
		}
		if (paramMap2.containsKey(paramString))
		{
			paramMap1.put(paramLong, paramMap2.get(paramString));
		}
		else
		{
			paramMap1.put(paramLong, null);
		}
		});
		return hashMap1;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\BimDataMoverUtils.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}