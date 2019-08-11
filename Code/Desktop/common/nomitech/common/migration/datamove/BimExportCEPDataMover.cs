using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common.migration.datamove
{
	using ObjectMapper = com.fasterxml.jackson.databind.ObjectMapper;
	using BimModelMetadata = Desktop.common.nomitech.common.migration.datamove.metadata.BimModelMetadata;
	using BimProjectMetadata = Desktop.common.nomitech.common.migration.datamove.metadata.BimProjectMetadata;
	using BaseEntityMetadataKeeper = Desktop.common.nomitech.common.migration.datamove.metadataKeeper.BaseEntityMetadataKeeper;
	using ExtractedData = Desktop.common.nomitech.common.migration.datamove.metadataKeeper.ExtractedData;
	using BimSchemaHelper = Desktop.common.nomitech.common.migration.datamove.schemaHelper.BimSchemaHelper;
	using UIProgress = nomitech.common.ui.UIProgress;
	using SQLQuery = org.hibernate.SQLQuery;
	using Session = org.hibernate.Session;

	public class BimExportCEPDataMover : BaseDBDataMover
	{
	  internal Session destSession;

	  internal Session sourceSession;

	  internal long? modelId;

	  internal BimExportCEPDataMover(UIProgress paramUIProgress, long? paramLong, Session paramSession1, Session paramSession2)
	  {
		this.progress = paramUIProgress;
		this.modelId = paramLong;
		this.helper = new BimSchemaHelper(paramLong);
		this.sourceDbms = ProjectDBUtil.SQLSERVER_DBMS;
		this.destDbms = ProjectDBUtil.HSQL_DBMS;
		this.destSession = paramSession2;
		this.destConnection = paramSession2.connection();
		this.sourceSession = paramSession1;
		this.sourceConnection = paramSession1.connection();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.Map<long, long> moveModelsToCEP(nomitech.common.ui.UIProgress paramUIProgress, nomitech.common.CostOSBimEngineFileDBUtil paramCostOSBimEngineFileDBUtil, java.util.List<long> paramList) throws Exception
	  public static IDictionary<long, long> moveModelsToCEP(UIProgress paramUIProgress, CostOSBimEngineFileDBUtil paramCostOSBimEngineFileDBUtil, IList<long> paramList)
	  {
		Hashtable hashMap = new Hashtable();
		List<object> arrayList = new List<object>();
		Session session1 = null;
		Session session2 = null;
		try
		{
		  session1 = DatabaseDBUtil.currentSession();
		  session2 = paramCostOSBimEngineFileDBUtil.createSession();
		  Session session3 = session1;
		  Session session4 = session2;
		  paramList.ForEach(paramLong =>
		  {
		  try
		  {
			  BimExportCEPDataMover bimExportCEPDataMover = new BimExportCEPDataMover(paramUIProgress, paramLong, paramSession1, paramSession2);
			  long? long = bimExportCEPDataMover.moveModelsToCEP();
			  if (long == null)
			  {
				  return;
			  }
			  BimModelMetadata bimModelMetadata = gatherMetadata(paramSession1, paramLong, long);
			  if (bimModelMetadata == null)
			  {
				  return;
			  }
			  paramList.Add(bimModelMetadata);
			  paramMap.put(paramLong, long);
		  }
		  catch (Exception throwable)
		  {
			  Console.WriteLine(throwable.ToString());
			  Console.Write(throwable.StackTrace);
		  }
		  });
		  cleanup(session2);
		  saveMetadata(paramCostOSBimEngineFileDBUtil.ProjectFolder, arrayList);
		}
		catch (Exception)
		{
		  if (session1 != null)
		  {
			session1.close();
		  }
		  if (session2 != null)
		  {
			session2.close();
		  }
		}
		return hashMap;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static void saveMetadata(String paramString, java.util.List<Desktop.common.nomitech.common.migration.datamove.metadata.BimModelMetadata> paramList) throws java.io.IOException
	  private static void saveMetadata(string paramString, IList<BimModelMetadata> paramList)
	  {
		ObjectMapper objectMapper = new ObjectMapper();
		File file = new File(paramString, "modelDB.json");
		using (StreamWriter null = new StreamWriter(file))
		{
		  objectMapper.writeValue(fileWriter, paramList);
		}
	  }

	  private static BimModelMetadata gatherMetadata(Session paramSession, long? paramLong1, long? paramLong2)
	  {
		SQLQuery sQLQuery = paramSession.createSQLQuery("SELECT NAME, GLOBALID, PROJECT_ID from BC_MODEL where ID = :id");
		sQLQuery.setLong("id", paramLong1.Value);
		System.Collections.IList list = sQLQuery.list();
		if (list.Count == 0)
		{
		  return null;
		}
		object[] arrayOfObject = (object[])list[0];
		string str1 = (string)arrayOfObject[0];
		string str2 = (string)arrayOfObject[1];
		Number number = (Number)arrayOfObject[2];
		BimModelMetadata bimModelMetadata = new BimModelMetadata();
		bimModelMetadata.GlobalId = str2;
		bimModelMetadata.Id = paramLong2;
		bimModelMetadata.Name = str1;
		bimModelMetadata.OriginalId = paramLong1;
		if (number != null)
		{
		  bimModelMetadata.Project = gatherProjectMetadata(paramSession, number.longValue());
		}
		return bimModelMetadata;
	  }

	  private static BimProjectMetadata gatherProjectMetadata(Session paramSession, long paramLong)
	  {
		SQLQuery sQLQuery = paramSession.createSQLQuery("SELECT NAME, GLOBALID, PARENT_ID from BC_PROJECT where ID = :id");
		sQLQuery.setLong("id", paramLong);
		System.Collections.IList list = sQLQuery.list();
		if (list.Count == 0)
		{
		  return null;
		}
		object[] arrayOfObject = (object[])list[0];
		string str1 = (string)arrayOfObject[0];
		string str2 = (string)arrayOfObject[1];
		Number number = (Number)arrayOfObject[2];
		BimProjectMetadata bimProjectMetadata = new BimProjectMetadata();
		bimProjectMetadata.GlobalId = str2;
		bimProjectMetadata.Name = str1;
		if (number != null)
		{
		  bimProjectMetadata.Parent = gatherProjectMetadata(paramSession, number.longValue());
		}
		return bimProjectMetadata;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private System.Nullable<long> moveModelsToCEP() throws Exception
	  private long? moveModelsToCEP()
	  {
		this.progress.Indeterminate = true;
		long? long = null;
		try
		{
		  createMappingTable();
		  System.Collections.IList list1 = this.helper.listEntities();
		  System.Collections.IList list2 = this.helper.listEntitiesWithForeignKeys();
		  this.progress.Indeterminate = false;
		  this.progress.TotalTimes = list1.Count * 3 + list2.Count;
		  foreach (BaseEntityMetadataKeeper baseEntityMetadataKeeper in list1)
		  {
			string str1 = baseEntityMetadataKeeper.TableName;
			try
			{
			  long? long1 = Convert.ToInt64(executeCountQuery(this.destConnection, baseEntityMetadataKeeper.getIdRefColumnExistsStatement(this.destDbms)));
			  if (long1.Value == 0L)
			  {
				executeUpdateQuery(this.destConnection, baseEntityMetadataKeeper.getAlterIdRefColumnStatement(this.destDbms));
				long? long2 = Convert.ToInt64(executeCountQuery(this.destConnection, baseEntityMetadataKeeper.getIdRefColumnIndexExistsStatement(this.destDbms, true)));
				if (long2.Value == 0L)
				{
				  executeUpdateQuery(this.destConnection, baseEntityMetadataKeeper.getIdRefColumnIndexCreateStatement(this.destDbms, true));
				}
			  }
			}
			catch (Exception exception)
			{
			  logger.error("COULD NOT EXECUTE ALTER: " + baseEntityMetadataKeeper.getAlterIdRefColumnStatement(this.destDbms), exception);
			}
			if (str1.Equals("BC_MODEL", StringComparison.OrdinalIgnoreCase))
			{
			  ResultSet resultSet1 = executeSelectQuery(this.sourceConnection, baseEntityMetadataKeeper.SelectEverythingStatement);
			  resultSet1.next();
			  ExtractedData extractedData = baseEntityMetadataKeeper.extractRow(null, resultSet1);
			  string str = baseEntityMetadataKeeper.getInsertDataStatement(this.destDbms);
			  long = executeInsertStatement(this.destConnection, str, extractedData.DataValues);
			  continue;
			}
			setProgress(this.progress, "Selecting [" + str1 + "]");
			ResultSet resultSet = executeSelectQuery(this.sourceConnection, baseEntityMetadataKeeper.SelectEverythingStatement);
			long l = executeCountQuery(this.sourceConnection, baseEntityMetadataKeeper.CountStatement);
			resultSet.FetchSize = 2000;
			sbyte b1 = 0;
			List<object> arrayList1 = new List<object>(2000);
			List<object> arrayList2 = baseEntityMetadataKeeper.hasForeignKeys() ? new List<object>(2000) : null;
			string str2 = baseEntityMetadataKeeper.getInsertDataStatement(this.destDbms);
			string str3 = baseEntityMetadataKeeper.getInsertForeignKeysToMappingTableStatement(Convert.ToInt32(this.destDbms));
			setProgress(this.progress, "INSERT [" + str1 + "] ");
			this.progress.incrementProgress(1);
			sbyte b2 = 0;
			while (resultSet.next())
			{
			  ExtractedData extractedData = baseEntityMetadataKeeper.extractRow(long, resultSet);
			  arrayList1.Add(extractedData.DataValues);
			  if (baseEntityMetadataKeeper.hasForeignKeys())
			  {
				ExtractedData.ExtractedFKData[] arrayOfExtractedFKData = extractedData.FkValues;
				foreach (ExtractedData.ExtractedFKData extractedFKData in arrayOfExtractedFKData)
				{
				  arrayList2.Add(extractedFKData.DataValues);
				}
			  }
			  b1++;
			  b2++;
			  if (b1 % 'ߐ' == '\x0000')
			  {
				setProgress(this.progress, "INSERT DATA [" + str1 + "] " + b2);
				executeInsertStatement(this.destConnection, str2, arrayList1);
				arrayList1.Clear();
				if (baseEntityMetadataKeeper.hasForeignKeys())
				{
				  setProgress(this.progress, "INSERT FOREIGN KEYS [" + str1 + "] " + b2);
				  logger.debug("FK STATEMENT: " + str3);
				  executeInsertStatement(this.destConnection, str3, arrayList2);
				  arrayList2.Clear();
				}
				b1 = 0;
			  }
			}
			if (b1 != 0)
			{
			  setProgress(this.progress, "INSERT DATA [" + str1 + "] " + b2);
			  executeInsertStatement(this.destConnection, str2, arrayList1);
			  arrayList1.Clear();
			  if (baseEntityMetadataKeeper.hasForeignKeys())
			  {
				setProgress(this.progress, "INSERT FOREIGN KEYS [" + str1 + "] " + b2);
				logger.debug("FK STATEMENT: " + str3);
				executeInsertStatement(this.destConnection, str3, arrayList2);
				arrayList2.Clear();
			  }
			}
			resultSet.close();
			save(this.destSession);
			this.progress.incrementProgress(1);
		  }
		  foreach (BaseEntityMetadataKeeper baseEntityMetadataKeeper in list2)
		  {
			string str = baseEntityMetadataKeeper.getUpdateBySelectForeignKeysMappingTableStatement(Convert.ToInt32(this.destDbms), long);
			if (string.ReferenceEquals(str, null))
			{
			  continue;
			}
			logger.debug("\nFK UPDATE: " + str);
			setProgress(this.progress, "UPDATE FOREIGN KEYS [" + baseEntityMetadataKeeper.TableName + "]");
			executeUpdateQuery(this.destConnection, str);
			this.progress.incrementProgress(1);
		  }
		  this.progress.Indeterminate = true;
		  setProgress(this.progress, "CLEANING UP");
		  BimDataMoverUtils.fixSerializedData(this.destConnection, long);
		}
		catch (Exception exception)
		{
		  logger.error("An error occured while doing stuff", exception);
		  throw exception;
		}
		return long;
	  }

	  private static void cleanup(Session paramSession)
	  {
		try
		{
		  save(paramSession);
		  paramSession.createSQLQuery("SHUTDOWN").executeUpdate();
		}
		catch (SQLException sQLException)
		{
		  logger.error("Error cleaning up", sQLException);
		}
	  }

	  private static void save(Session paramSession)
	  {
		paramSession.createSQLQuery("COMMIT").executeUpdate();
		paramSession.flush();
		paramSession.clear();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\BimExportCEPDataMover.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}