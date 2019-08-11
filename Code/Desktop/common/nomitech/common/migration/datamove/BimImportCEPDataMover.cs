using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.migration.datamove
{
	using BaseEntityMetadataKeeper = Desktop.common.nomitech.common.migration.datamove.metadataKeeper.BaseEntityMetadataKeeper;
	using ExtractedData = Desktop.common.nomitech.common.migration.datamove.metadataKeeper.ExtractedData;
	using BimSchemaHelper = Desktop.common.nomitech.common.migration.datamove.schemaHelper.BimSchemaHelper;
	using UILanguage = nomitech.common.ui.UILanguage;
	using UIProgress = nomitech.common.ui.UIProgress;
	using Session = org.hibernate.Session;

	public class BimImportCEPDataMover : BaseDBDataMover
	{
	  internal Session destSession;

	  internal Session sourceSession;

	  internal long? modelId;

	  internal long? targetProjectId;

	  internal BimImportCEPDataMover(UIProgress paramUIProgress, long? paramLong1, long? paramLong2, Session paramSession1, Session paramSession2)
	  {
		this.progress = paramUIProgress;
		this.modelId = paramLong1;
		this.targetProjectId = paramLong2;
		this.helper = new BimSchemaHelper(paramLong1);
		this.sourceDbms = ProjectDBUtil.HSQL_DBMS;
		this.destDbms = ProjectDBUtil.SQLSERVER_DBMS;
		this.destSession = paramSession2;
		this.destConnection = paramSession2.connection();
		this.sourceSession = paramSession1;
		this.sourceConnection = paramSession1.connection();
	  }

	  public static IDictionary<long, long> moveModelsFromCEP(UIProgress paramUIProgress, CostOSBimEngineFileDBUtil paramCostOSBimEngineFileDBUtil, IDictionary<long, long> paramMap)
	  {
		Hashtable hashMap = new Hashtable();
		Session session1 = null;
		Session session2 = null;
		try
		{
		  session1 = paramCostOSBimEngineFileDBUtil.createSession();
		  session2 = DatabaseDBUtil.currentSession();
		  Session session3 = session1;
		  Session session4 = session2;
		  paramMap.forEach((paramLong1, paramLong2) =>
		  {
		  try
		  {
			  BimImportCEPDataMover bimImportCEPDataMover = new BimImportCEPDataMover(paramUIProgress, paramLong1, paramLong2, paramSession1, paramSession2);
			  long? long = bimImportCEPDataMover.moveModelsFromCEP();
			  paramMap[paramLong1] = long.Value;
		  }
		  catch (Exception throwable)
		  {
			  Console.WriteLine(throwable.ToString());
			  Console.Write(throwable.StackTrace);
		  }
		  });
		  cleanup(session2);
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
		  cleanup(session2);
		}
		return hashMap;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private System.Nullable<long> moveModelsFromCEP() throws Exception
	  private long? moveModelsFromCEP()
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
			string str = baseEntityMetadataKeeper.TableName;
			try
			{
			  long? long1 = Convert.ToInt64(executeCountQuery(this.destConnection, baseEntityMetadataKeeper.getIdRefColumnExistsStatement(this.destDbms)));
			  if (long1.Value == 0L)
			  {
				executeUpdateQuery(this.destConnection, baseEntityMetadataKeeper.getAlterIdRefColumnStatement(this.destDbms));
			  }
			  long? long2 = Convert.ToInt64(executeCountQuery(this.destConnection, baseEntityMetadataKeeper.getIdRefColumnIndexExistsStatement(this.destDbms, false)));
			  if (long2.Value == 0L)
			  {
				executeUpdateQuery(this.destConnection, baseEntityMetadataKeeper.getIdRefColumnIndexCreateStatement(this.destDbms, false));
			  }
			}
			catch (Exception exception)
			{
			  logger.error("COULD NOT ADD REFIF IN : " + str, exception);
			}
		  }
		  foreach (BaseEntityMetadataKeeper baseEntityMetadataKeeper in list1)
		  {
			string str1 = baseEntityMetadataKeeper.TableName;
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
			  if (str1.Equals("BC_GEOMFILE", StringComparison.OrdinalIgnoreCase))
			  {
				int i = baseEntityMetadataKeeper.getColumnIndex("FGUID").Value;
				if (i > 0)
				{
				  string str = System.Guid.randomUUID().ToString();
				  extractedData.DataValues[i - 1] = str;
				}
			  }
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
		  updateFixedReferences(this.destConnection);
		  dropMappingTable();
		  setupModelProject(long);
		  BimDataMoverUtils.fixSerializedData(this.destConnection, long);
		}
		catch (Exception exception)
		{
		  logger.error("An error occured while doing stuff", exception);
		  throw exception;
		}
		return long;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void setupModelProject(System.Nullable<long> paramLong) throws Exception
	  private void setupModelProject(long? paramLong)
	  {
		long? long;
		if (this.targetProjectId == null)
		{
		  long = OrCreateImportedModelsProject;
		}
		else
		{
		  long = this.targetProjectId;
		}
		string str = "update BC_MODEL set PROJECT_ID = " + long + " where ID = " + paramLong;
		executeUpdateQuery(this.destConnection, str);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private System.Nullable<long> getOrCreateImportedModelsProject() throws Exception
	  private long? OrCreateImportedModelsProject
	  {
		  get
		  {
			long? long = null;
			string str1 = UILanguage.get("import.cep.project.bimcity.imported.models");
			string str2 = "SELECT count(1) from BC_PROJECT where NAME = '" + str1 + "' AND (DELETED = 0 or DELETED is null)";
			long l = executeCountQuery(this.destConnection, str2);
			if (l > 0L)
			{
			  string str = "SELECT ID from BC_PROJECT where NAME = '" + str1 + "' AND (DELETED = 0 or DELETED is null)";
			  ResultSet resultSet = executeSelectQuery(this.destConnection, str);
			  if (resultSet.next())
			  {
				long = Convert.ToInt64(resultSet.getLong(1));
			  }
			  resultSet.close();
			}
			if (long == null)
			{
			  string str3 = "insert into BC_PROJECT (NAME, GLOBALID, DELETED, CODE) values (?, ?, ?, ?)";
			  string str4 = System.Guid.randomUUID().ToString();
			  long = executeInsertStatement(this.destConnection, str3, new object[] {str1, str4, Convert.ToInt32(0), str1});
			}
			return long;
		  }
	  }

	  private static void cleanup(Session paramSession)
	  {
		try
		{
		  save(paramSession);
		}
		catch (SQLException sQLException)
		{
		  logger.error("Error cleaning up", sQLException);
		}
	  }

	  private static void save(Session paramSession)
	  {
		paramSession.flush();
		paramSession.clear();
	  }

	  private void updateFixedReferences(Connection paramConnection)
	  {
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\BimImportCEPDataMover.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}