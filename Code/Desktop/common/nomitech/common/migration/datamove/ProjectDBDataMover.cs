using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Desktop.common.nomitech.common.migration.datamove
{
	using ProjectDbmsTable = nomitech.common.db.local.ProjectDbmsTable;
	using ProjectUrlTable = nomitech.common.db.local.ProjectUrlTable;
	using ExtractedData = Desktop.common.nomitech.common.migration.datamove.metadataKeeper.ExtractedData;
	using ProjectEntityMetadataKeeper = Desktop.common.nomitech.common.migration.datamove.metadataKeeper.ProjectEntityMetadataKeeper;
	using ProjectDBSchemaHelper = Desktop.common.nomitech.common.migration.datamove.schemaHelper.ProjectDBSchemaHelper;
	using UIProgress = nomitech.common.ui.UIProgress;
	using StringUtils = nomitech.common.util.StringUtils;

	public class ProjectDBDataMover : BaseDBDataMover
	{
	  private ProjectUrlTable source;

	  private ProjectUrlTable dest;

	  private IDictionary<long, long> oldModelIdsToNew;

	  private ProjectDBDataMover(UIProgress paramUIProgress)
	  {
		  this.progress = paramUIProgress;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private ProjectDBDataMover(nomitech.common.ui.UIProgress paramUIProgress, nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable1, nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable2) throws Exception
	  private ProjectDBDataMover(UIProgress paramUIProgress, ProjectUrlTable paramProjectUrlTable1, ProjectUrlTable paramProjectUrlTable2) : base(paramProjectUrlTable1.Dbms.Value, paramProjectUrlTable2.Dbms.Value)
	  {
		this.progress = paramUIProgress;
		this.source = paramProjectUrlTable1;
		this.dest = paramProjectUrlTable2;
		this.helper = new ProjectDBSchemaHelper(paramProjectUrlTable1);
	  }

	  private bool initialize(ProjectUrlTable paramProjectUrlTable1, ProjectUrlTable paramProjectUrlTable2)
	  {
		this.sourceDbms = paramProjectUrlTable1.Dbms.Value;
		this.source = paramProjectUrlTable1;
		this.destDbms = paramProjectUrlTable2.Dbms.Value;
		this.dest = paramProjectUrlTable2;
		if (this.helper == null)
		{
		  this.helper = new ProjectDBSchemaHelper(this.source);
		}
		else
		{
		  ((ProjectDBSchemaHelper)this.helper).UrlTable = paramProjectUrlTable1;
		}
		this.sourceConnection = null;
		this.destConnection = null;
		return true;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void initialize() throws Exception
	  private void initialize()
	  {
		this.progress.Indeterminate = true;
		string str = "";
		if (this.sourceConnection != null || this.destConnection != null)
		{
		  str = ";useLOBs=false";
		}
		if (this.sourceConnection == null)
		{
		  this.sourceConnection = ProjectSessionFactory.getConnection(this.source.Url + str, this.source.Username, this.source.Password);
		  this.sourceConnection.AutoCommit = false;
		}
		if (this.destConnection == null)
		{
		  this.destConnection = ProjectSessionFactory.getConnection(this.dest.Url + str, this.dest.Username, this.dest.Password);
		  this.destConnection.AutoCommit = false;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void cleanUp() throws Exception
	  private void cleanUp()
	  {
		logger.trace("Cleaning up");
		this.progress.Indeterminate = true;
		try
		{
		  this.sourceConnection.close();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		try
		{
		  this.destConnection.close();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void moveDataSameInstance() throws Exception
	  private void moveDataSameInstance()
	  {
		this.progress.Indeterminate = true;
		bool @bool = (this.sourceConnection != null) ? 1 : 0;
		if (!@bool)
		{
		  this.sourceConnection = ProjectSessionFactory.getConnection(this.source);
		  this.sourceConnection.AutoCommit = false;
		}
		try
		{
		  System.Collections.IList list1 = this.helper.listEntities();
		  System.Collections.IList list2 = this.helper.listEntitiesWithForeignKeys();
		  this.progress.Indeterminate = false;
		  this.progress.TotalTimes = list1.Count * 2 + list2.Count;
		  logger.trace("SOURCE ID: " + this.source.ProjectUrlId + " DEST ID: " + this.dest.ProjectUrlId);
		  foreach (ProjectEntityMetadataKeeper projectEntityMetadataKeeper in list1)
		  {
			try
			{
			  executeUpdateQuery(this.sourceConnection, projectEntityMetadataKeeper.getAlterIdRefColumnStatement(this.dest));
			}
			catch (Exception)
			{
			  logger.trace("COULD NOT EXECUTE ALTER: " + projectEntityMetadataKeeper.getAlterIdRefColumnStatement(this.dest));
			}
			this.progress.incrementProgress(1);
			string str = projectEntityMetadataKeeper.getInsertIntoBySelectNoForeignKeysStatement(this.dest);
			logger.trace("\nINSERT: " + str);
			executeUpdateQuery(this.sourceConnection, str);
			this.progress.incrementProgress(1);
		  }
		  foreach (ProjectEntityMetadataKeeper projectEntityMetadataKeeper in list2)
		  {
			string str = projectEntityMetadataKeeper.getUpdateBySelectForeignKeysStatement(this.dest);
			logger.trace("\nFK UPDATE: " + str);
			executeUpdateQuery(this.sourceConnection, str);
			this.progress.incrementProgress(1);
		  }
		  updateFixedReferences(this.sourceConnection);
		}
		catch (Exception exception)
		{
		  this.progress.Indeterminate = true;
		  this.sourceConnection.close();
		  throw exception;
		}
		this.progress.Indeterminate = true;
		if (!@bool)
		{
		  this.sourceConnection.close();
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void moveDataSameInstanceAppendProjects() throws Exception
	  private void moveDataSameInstanceAppendProjects()
	  {
		this.progress.Indeterminate = true;
		bool @bool = (this.sourceConnection != null) ? 1 : 0;
		if (!@bool)
		{
		  this.sourceConnection = ProjectSessionFactory.getConnection(this.source);
		  this.sourceConnection.AutoCommit = false;
		}
		try
		{
		  System.Collections.IList list1 = this.helper.listEntities();
		  System.Collections.IList list2 = this.helper.listEntitiesWithForeignKeys();
		  this.progress.Indeterminate = false;
		  this.progress.TotalTimes = list1.Count * 2 + list2.Count;
		  logger.trace("SOURCE ID: " + this.source.ProjectUrlId + " DEST ID: " + this.dest.ProjectUrlId);
		  foreach (ProjectEntityMetadataKeeper projectEntityMetadataKeeper in list1)
		  {
			if (projectEntityMetadataKeeper.TableName.Equals("XCELLFILE") || projectEntityMetadataKeeper.TableName.Equals("PROJECTTEMPLATE") || projectEntityMetadataKeeper.TableName.Equals("PROJECTSPECVAR") || projectEntityMetadataKeeper.TableName.Equals("RATEBUILDUP") || projectEntityMetadataKeeper.TableName.Equals("RATEBUILDUPCOLS") || projectEntityMetadataKeeper.TableName.Equals("RATEDISTRIB") || projectEntityMetadataKeeper.TableName.Equals("PROJECTWBS") || projectEntityMetadataKeeper.TableName.Equals("PROJECTWBS2") || projectEntityMetadataKeeper.TableName.Equals("PRJPROP") || projectEntityMetadataKeeper.TableName.Equals("PRJUSERPROP"))
			{
			  continue;
			}
			try
			{
			  executeUpdateQuery(this.sourceConnection, projectEntityMetadataKeeper.getAlterIdRefColumnStatement(this.dest));
			}
			catch (Exception)
			{
			  logger.trace("COULD NOT EXECUTE ALTER: " + projectEntityMetadataKeeper.getAlterIdRefColumnStatement(this.dest));
			}
			this.progress.incrementProgress(1);
			string str = projectEntityMetadataKeeper.getInsertIntoBySelectNoForeignKeysStatementAppendProjects(this.dest);
			logger.trace("\nINSERT: " + str);
			executeUpdateQuery(this.sourceConnection, str);
			this.progress.incrementProgress(1);
		  }
		  foreach (ProjectEntityMetadataKeeper projectEntityMetadataKeeper in list2)
		  {
			if (projectEntityMetadataKeeper.TableName.Equals("XCELLFILE") || projectEntityMetadataKeeper.TableName.Equals("PROJECTTEMPLATE") || projectEntityMetadataKeeper.TableName.Equals("PROJECTSPECVAR") || projectEntityMetadataKeeper.TableName.Equals("RATEBUILDUP") || projectEntityMetadataKeeper.TableName.Equals("RATEBUILDUPCOLS") || projectEntityMetadataKeeper.TableName.Equals("RATEDISTRIB") || projectEntityMetadataKeeper.TableName.Equals("PROJECTWBS") || projectEntityMetadataKeeper.TableName.Equals("PROJECTWBS2") || projectEntityMetadataKeeper.TableName.Equals("PRJPROP") || projectEntityMetadataKeeper.TableName.Equals("PRJUSERPROP"))
			{
			  continue;
			}
			string str = projectEntityMetadataKeeper.getUpdateBySelectForeignKeysStatement(this.dest);
			logger.trace("\nFK UPDATE: " + str);
			executeUpdateQuery(this.sourceConnection, str);
			this.progress.incrementProgress(1);
		  }
		}
		catch (Exception exception)
		{
		  this.progress.Indeterminate = true;
		  this.sourceConnection.close();
		  throw exception;
		}
		this.progress.Indeterminate = true;
		if (!@bool)
		{
		  this.sourceConnection.close();
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void moveDataNotSameInstance() throws Exception
	  private void moveDataNotSameInstance()
	  {
		this.progress.Indeterminate = true;
		initialize();
		try
		{
		  createMappingTable();
		  System.Collections.IList list1 = this.helper.listEntities();
		  System.Collections.IList list2 = this.helper.listEntitiesWithForeignKeys();
		  this.progress.Indeterminate = false;
		  this.progress.TotalTimes = list1.Count * 3 + list2.Count;
		  logger.trace("SOURCE ID: " + this.source.ProjectUrlId + " DEST ID: " + this.dest.ProjectUrlId);
		  foreach (ProjectEntityMetadataKeeper projectEntityMetadataKeeper in list1)
		  {
			try
			{
			  executeUpdateQuery(this.destConnection, projectEntityMetadataKeeper.getAlterIdRefColumnStatement(this.dest));
			}
			catch (Exception)
			{
			  logger.trace("COULD NOT EXECUTE ALTER: " + projectEntityMetadataKeeper.getAlterIdRefColumnStatement(this.dest));
			}
			if (projectEntityMetadataKeeper.TableName.Equals("PRJPROP", StringComparison.OrdinalIgnoreCase) || projectEntityMetadataKeeper.TableName.Equals("PRJUSERPROP", StringComparison.OrdinalIgnoreCase))
			{
			  continue;
			}
			setProgress(this.progress, "Selecting [" + projectEntityMetadataKeeper.TableName + "]");
			ResultSet resultSet = executeSelectQuery(this.sourceConnection, projectEntityMetadataKeeper.SelectEverythingStatement);
			long l = executeCountQuery(this.sourceConnection, projectEntityMetadataKeeper.CountStatement);
			resultSet.FetchSize = 2000;
			sbyte b1 = 0;
			List<object> arrayList1 = new List<object>(2000);
			List<object> arrayList2 = projectEntityMetadataKeeper.hasForeignKeys() ? new List<object>(2000) : null;
			string str1 = projectEntityMetadataKeeper.getInsertDataStatement(this.dest);
			string str2 = projectEntityMetadataKeeper.getInsertForeignKeysToMappingTableStatement(this.dest);
			setProgress(this.progress, "INSERT [" + projectEntityMetadataKeeper.TableName + "] ");
			this.progress.incrementProgress(1);
			sbyte b2 = 0;
			while (resultSet.next())
			{
			  ExtractedData extractedData = projectEntityMetadataKeeper.extractRow(this.dest, resultSet);
			  arrayList1.Add(extractedData.DataValues);
			  if (projectEntityMetadataKeeper.hasForeignKeys())
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
				setProgress(this.progress, "INSERT DATA [" + projectEntityMetadataKeeper.TableName + "] " + b2);
				executeInsertStatement(this.destConnection, str1, arrayList1);
				arrayList1.Clear();
				if (projectEntityMetadataKeeper.hasForeignKeys())
				{
				  setProgress(this.progress, "INSERT FOREIGN KEYS [" + projectEntityMetadataKeeper.TableName + "] " + b2);
				  logger.trace("FK STATEMENT: " + str2);
				  executeInsertStatement(this.destConnection, str2, arrayList2);
				  arrayList2.Clear();
				}
				b1 = 0;
			  }
			}
			if (b1 != 0)
			{
			  setProgress(this.progress, "INSERT DATA [" + projectEntityMetadataKeeper.TableName + "] " + b2);
			  executeInsertStatement(this.destConnection, str1, arrayList1);
			  arrayList1.Clear();
			  if (projectEntityMetadataKeeper.hasForeignKeys())
			  {
				setProgress(this.progress, "INSERT FOREIGN KEYS [" + projectEntityMetadataKeeper.TableName + "] " + b2);
				logger.trace("FK STATEMENT: " + str2);
				executeInsertStatement(this.destConnection, str2, arrayList2);
				arrayList2.Clear();
			  }
			}
			resultSet.close();
			this.progress.incrementProgress(1);
		  }
		  foreach (ProjectEntityMetadataKeeper projectEntityMetadataKeeper in list2)
		  {
			logger.trace("\nFK UPDATE: " + projectEntityMetadataKeeper.getUpdateBySelectForeignKeysMappingTableStatement(this.dest));
			setProgress(this.progress, "UPDATE FOREIGN KEYS [" + projectEntityMetadataKeeper.TableName + "]");
			executeUpdateQuery(this.destConnection, projectEntityMetadataKeeper.getUpdateBySelectForeignKeysMappingTableStatement(this.dest));
			this.progress.incrementProgress(1);
		  }
		  this.progress.Indeterminate = true;
		  setProgress(this.progress, "CLEANING UP");
		  updateFixedReferences(this.destConnection);
		  dropMappingTable();
		}
		catch (Exception exception)
		{
		  logger.error("An error occured while doing stuff", exception);
		  cleanUp();
		  throw exception;
		}
		cleanUp();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void moveDataNotSameInstanceAppendProjects() throws Exception
	  private void moveDataNotSameInstanceAppendProjects()
	  {
		this.progress.Indeterminate = true;
		initialize();
		try
		{
		  createMappingTable();
		  System.Collections.IList list1 = this.helper.listEntities();
		  System.Collections.IList list2 = this.helper.listEntitiesWithForeignKeys();
		  this.progress.Indeterminate = false;
		  this.progress.TotalTimes = list1.Count * 3 + list2.Count;
		  logger.trace("SOURCE ID: " + this.source.ProjectUrlId + " DEST ID: " + this.dest.ProjectUrlId);
		  foreach (ProjectEntityMetadataKeeper projectEntityMetadataKeeper in list1)
		  {
			if (projectEntityMetadataKeeper.TableName.Equals("PROJECTWBS") || projectEntityMetadataKeeper.TableName.Equals("PROJECTWBS2"))
			{
			  continue;
			}
			try
			{
			  executeUpdateQuery(this.destConnection, projectEntityMetadataKeeper.getAlterIdRefColumnStatement(this.dest));
			}
			catch (Exception)
			{
			  logger.trace("COULD NOT EXECUTE ALTER: " + projectEntityMetadataKeeper.getAlterIdRefColumnStatement(this.dest));
			}
			if (projectEntityMetadataKeeper.TableName.Equals("PRJPROP", StringComparison.OrdinalIgnoreCase) || projectEntityMetadataKeeper.TableName.Equals("PRJUSERPROP", StringComparison.OrdinalIgnoreCase))
			{
			  continue;
			}
			setProgress(this.progress, "Selecting [" + projectEntityMetadataKeeper.TableName + "]");
			ResultSet resultSet = executeSelectQuery(this.sourceConnection, projectEntityMetadataKeeper.SelectEverythingStatementAppendProjects);
			long l = executeCountQuery(this.sourceConnection, projectEntityMetadataKeeper.CountStatement);
			resultSet.FetchSize = 2000;
			sbyte b1 = 0;
			List<object> arrayList1 = new List<object>(2000);
			List<object> arrayList2 = projectEntityMetadataKeeper.hasForeignKeys() ? new List<object>(2000) : null;
			string str1 = projectEntityMetadataKeeper.getInsertDataStatementAppendProjects(this.dest);
			string str2 = projectEntityMetadataKeeper.getInsertForeignKeysToMappingTableStatement(this.dest);
			setProgress(this.progress, "INSERT [" + projectEntityMetadataKeeper.TableName + "] ");
			this.progress.incrementProgress(1);
			sbyte b2 = 0;
			while (resultSet.next())
			{
			  ExtractedData extractedData = projectEntityMetadataKeeper.extractRow(this.dest, resultSet);
			  arrayList1.Add(extractedData.DataValues);
			  if (projectEntityMetadataKeeper.hasForeignKeys())
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
				setProgress(this.progress, "INSERT DATA [" + projectEntityMetadataKeeper.TableName + "] " + b2);
				executeInsertStatement(this.destConnection, str1, arrayList1);
				arrayList1.Clear();
				if (projectEntityMetadataKeeper.hasForeignKeys())
				{
				  setProgress(this.progress, "INSERT FOREIGN KEYS [" + projectEntityMetadataKeeper.TableName + "] " + b2);
				  logger.trace("FK STATEMENT: " + str2);
				  executeInsertStatement(this.destConnection, str2, arrayList2);
				  arrayList2.Clear();
				}
				b1 = 0;
			  }
			}
			if (b1 != 0)
			{
			  setProgress(this.progress, "INSERT DATA [" + projectEntityMetadataKeeper.TableName + "] " + b2);
			  executeInsertStatement(this.destConnection, str1, arrayList1);
			  arrayList1.Clear();
			  if (projectEntityMetadataKeeper.hasForeignKeys())
			  {
				setProgress(this.progress, "INSERT FOREIGN KEYS [" + projectEntityMetadataKeeper.TableName + "] " + b2);
				logger.trace("FK STATEMENT: " + str2);
				executeInsertStatement(this.destConnection, str2, arrayList2);
				arrayList2.Clear();
			  }
			}
			resultSet.close();
			this.progress.incrementProgress(1);
		  }
		  foreach (ProjectEntityMetadataKeeper projectEntityMetadataKeeper in list2)
		  {
			logger.trace("\nFK UPDATE: " + projectEntityMetadataKeeper.getUpdateBySelectForeignKeysMappingTableStatement(this.dest));
			setProgress(this.progress, "UPDATE FOREIGN KEYS [" + projectEntityMetadataKeeper.TableName + "]");
			executeUpdateQuery(this.destConnection, projectEntityMetadataKeeper.getUpdateBySelectForeignKeysMappingTableStatement(this.dest));
			this.progress.incrementProgress(1);
		  }
		  this.progress.Indeterminate = true;
		  setProgress(this.progress, "CLEANING UP");
		  updateFixedReferences(this.destConnection);
		  dropMappingTable();
		}
		catch (Exception exception)
		{
		  logger.error("An error occured while doing stuff", exception);
		  cleanUp();
		  throw exception;
		}
		cleanUp();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void updateFixedReferences(java.sql.Connection paramConnection) throws Exception
	  private void updateFixedReferences(Connection paramConnection)
	  {
		try
		{
		  long? long = this.dest.ProjectUrlId;
		  string str = "";
		  if (this.dest.Dbms.Value == ProjectServerDBUtil.SQLSERVER_DBMS)
		  {
			string str1 = this.dest.DatabaseName;
			if (!string.ReferenceEquals(str1, null) && str1.Trim().Length > 0)
			{
			  str = str1 + ".dbo.";
			}
		  }
		  executeUpdateQuery(paramConnection, "UPDATE " + str + "RATEBUILDUP SET RESPRJID = (SELECT LABORID FROM " + str + "LABOR WHERE LABOR.PRJID = " + long + " AND LABOR.REF__ID = RESPRJID) WHERE RESTYPE = 'labor' AND PRJID = " + long);
		  executeUpdateQuery(paramConnection, "UPDATE " + str + "RATEBUILDUP SET RESPRJID = (SELECT SUBCONTRACTORID FROM " + str + "SUBCONTRACTOR WHERE SUBCONTRACTOR.PRJID = " + long + " AND SUBCONTRACTOR.REF__ID = RESPRJID) WHERE RESTYPE = 'subcontractor' AND PRJID = " + long);
		  executeUpdateQuery(paramConnection, "UPDATE " + str + "RATEBUILDUP SET RESPRJID = (SELECT MATERIALID FROM " + str + "MATERIAL WHERE MATERIAL.PRJID = " + long + " AND MATERIAL.REF__ID = RESPRJID) WHERE RESTYPE = 'material' AND PRJID = " + long);
		  executeUpdateQuery(paramConnection, "UPDATE " + str + "RATEBUILDUP SET RESPRJID = (SELECT ASSEMBLYID FROM " + str + "ASSEMBLY WHERE ASSEMBLY.PRJID = " + long + " AND ASSEMBLY.REF__ID = RESPRJID) WHERE RESTYPE = 'assembly' AND PRJID = " + long);
		  executeUpdateQuery(paramConnection, "UPDATE " + str + "RATEBUILDUP SET RESPRJID = (SELECT EQUIPMENTID FROM " + str + "EQUIPMENT WHERE EQUIPMENT.PRJID = " + long + " AND EQUIPMENT.REF__ID = RESPRJID) WHERE RESTYPE = 'equipment' AND PRJID = " + long);
		  executeUpdateQuery(paramConnection, "UPDATE " + str + "RATEBUILDUP SET RESPRJID = (SELECT CONSUMABLEID FROM " + str + "CONSUMABLE WHERE CONSUMABLE.PRJID = " + long + " AND CONSUMABLE.REF__ID = RESPRJID) WHERE RESTYPE = 'consumable' AND PRJID = " + long);
		  ResultSet resultSet = executeSelectQuery(paramConnection, "SELECT ID, DISTRANGES FROM " + str + "RATEDISTRIB WHERE DISTTYPE = 0 AND PRJID = " + long);
		  while (resultSet.next())
		  {
			long? long1 = Convert.ToInt64(resultSet.getLong(1));
			string str1 = resultSet.getString(2);
			if (StringUtils.isNullOrBlank(str1))
			{
			  continue;
			}
			bool @bool = false;
			string str2 = StringUtils.replaceAll(str1, "\n", ",");
			if (str2.EndsWith(",", StringComparison.Ordinal))
			{
			  str2 = str2.Substring(0, str2.Length - 1);
			  @bool = true;
			}
			ResultSet resultSet1 = executeSelectQuery(paramConnection, "SELECT o.BOQITEMID FROM " + str + "BOQITEM AS o WHERE o.PRJID=" + long + " AND o.REF__ID IN (" + str2 + ")");
			StringBuilder stringBuffer = new StringBuilder();
			while (resultSet1.next())
			{
			  long? long2 = Convert.ToInt64(resultSet1.getLong(1));
			  if (stringBuffer.Length != 0)
			  {
				stringBuffer.Append("\n");
			  }
			  stringBuffer.Append(long2);
			}
			if (@bool)
			{
			  stringBuffer.Append("\n");
			}
			string str3 = "UPDATE " + str + "RATEDISTRIB SET DISTRANGES = '" + stringBuffer + "' WHERE ID = " + long1;
			executeUpdateQuery(paramConnection, str3);
		  }
		  if (this.oldModelIdsToNew != null && this.oldModelIdsToNew.Count > 0)
		  {
			string str1 = "update " + str + "CNDON set DBNAME = ? where DBNAME = ? and PRJID = ?";
			using (PreparedStatement null = paramConnection.prepareStatement(str1))
			{
			  this.oldModelIdsToNew.forEach((paramLong2, paramLong3) =>
			  {
			  try
			  {
				  string str1 = (paramLong3 != null) ? paramLong3.ToString() : null;
				  string str2 = (paramLong2 != null) ? paramLong2.ToString() : null;
				  paramPreparedStatement.setString(1, str1);
				  paramPreparedStatement.setString(2, str2);
				  paramPreparedStatement.setLong(3, paramLong1.longValue());
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
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw exception;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void moveDataSameInstance(nomitech.common.ui.UIProgress paramUIProgress, nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable1, nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable2) throws Exception
	  public static void moveDataSameInstance(UIProgress paramUIProgress, ProjectUrlTable paramProjectUrlTable1, ProjectUrlTable paramProjectUrlTable2)
	  {
		ProjectDBDataMover projectDBDataMover = new ProjectDBDataMover(paramUIProgress, paramProjectUrlTable1, paramProjectUrlTable2);
		projectDBDataMover.moveDataSameInstance();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void moveDataSameInstanceAppendProjects(nomitech.common.ui.UIProgress paramUIProgress, nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable1, nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable2) throws Exception
	  public static void moveDataSameInstanceAppendProjects(UIProgress paramUIProgress, ProjectUrlTable paramProjectUrlTable1, ProjectUrlTable paramProjectUrlTable2)
	  {
		ProjectDBDataMover projectDBDataMover = new ProjectDBDataMover(paramUIProgress, paramProjectUrlTable1, paramProjectUrlTable2);
		projectDBDataMover.moveDataSameInstanceAppendProjects();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void moveDataNotSameInstance(nomitech.common.ui.UIProgress paramUIProgress, nomitech.common.ProjectDBUtil paramProjectDBUtil1, nomitech.common.ProjectDBUtil paramProjectDBUtil2) throws Exception
	  public static void moveDataNotSameInstance(UIProgress paramUIProgress, ProjectDBUtil paramProjectDBUtil1, ProjectDBUtil paramProjectDBUtil2)
	  {
		  moveDataNotSameInstance(paramUIProgress, paramProjectDBUtil1, paramProjectDBUtil2, null);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void moveDataNotSameInstance(nomitech.common.ui.UIProgress paramUIProgress, nomitech.common.ProjectDBUtil paramProjectDBUtil1, nomitech.common.ProjectDBUtil paramProjectDBUtil2, java.util.Map<long, long> paramMap) throws Exception
	  public static void moveDataNotSameInstance(UIProgress paramUIProgress, ProjectDBUtil paramProjectDBUtil1, ProjectDBUtil paramProjectDBUtil2, IDictionary<long, long> paramMap)
	  {
		ProjectUrlTable projectUrlTable = paramProjectDBUtil2.ProjectUrl;
		if (projectUrlTable.ProjectUrlId == null)
		{
		  projectUrlTable.ProjectUrlId = Convert.ToInt64(DateTimeHelper.CurrentUnixTimeMillis());
		}
		ProjectDBDataMover projectDBDataMover = new ProjectDBDataMover(paramUIProgress, paramProjectDBUtil1.ProjectUrl, paramProjectDBUtil2.ProjectUrl);
		if (paramProjectDBUtil1 is nomitech.common.ProjectFileDBUtil)
		{
		  projectDBDataMover.sourceConnection = paramProjectDBUtil1.createJdbcConnection();
		  projectDBDataMover.sourceConnection.AutoCommit = false;
		}
		if (paramProjectDBUtil2 is nomitech.common.ProjectFileDBUtil)
		{
		  projectDBDataMover.destConnection = paramProjectDBUtil2.createJdbcConnection();
		  projectDBDataMover.destConnection.AutoCommit = false;
		}
		projectDBDataMover.oldModelIdsToNew = paramMap;
		projectDBDataMover.moveDataNotSameInstance();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void moveDataNotSameInstanceAppendProjects(nomitech.common.ui.UIProgress paramUIProgress, nomitech.common.ProjectDBUtil paramProjectDBUtil1, nomitech.common.ProjectDBUtil paramProjectDBUtil2) throws Exception
	  public static void moveDataNotSameInstanceAppendProjects(UIProgress paramUIProgress, ProjectDBUtil paramProjectDBUtil1, ProjectDBUtil paramProjectDBUtil2)
	  {
		ProjectUrlTable projectUrlTable = paramProjectDBUtil2.ProjectUrl;
		if (projectUrlTable.ProjectUrlId == null)
		{
		  projectUrlTable.ProjectUrlId = Convert.ToInt64(DateTimeHelper.CurrentUnixTimeMillis());
		}
		ProjectDBDataMover projectDBDataMover = new ProjectDBDataMover(paramUIProgress, paramProjectDBUtil1.ProjectUrl, paramProjectDBUtil2.ProjectUrl);
		if (paramProjectDBUtil1 is nomitech.common.ProjectFileDBUtil)
		{
		  projectDBDataMover.sourceConnection = paramProjectDBUtil1.createJdbcConnection();
		  projectDBDataMover.sourceConnection.AutoCommit = false;
		}
		if (paramProjectDBUtil2 is nomitech.common.ProjectFileDBUtil)
		{
		  projectDBDataMover.destConnection = paramProjectDBUtil2.createJdbcConnection();
		  projectDBDataMover.destConnection.AutoCommit = false;
		}
		projectDBDataMover.moveDataNotSameInstanceAppendProjects();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private java.util.List<nomitech.common.db.local.ProjectUrlTable> getAllProjectUrls(java.sql.Connection paramConnection, java.util.Set<String> paramSet, boolean paramBoolean) throws Exception
	  private IList<ProjectUrlTable> getAllProjectUrls(Connection paramConnection, ISet<string> paramSet, bool paramBoolean)
	  {
		List<object> arrayList = new List<object>();
		try
		{
		  ResultSet resultSet = executeSelectQuery(paramConnection, "SELECT PROJECTURLID, URL, DBUSR, DBPSWD, DBNAME, NAME, DBSRV, DBSINGLE, DBHOST, DBPORT FROM PROJECTURL WHERE DBSINGLE = 1 AND DBSRV = 3" + (paramBoolean ? " OR DBSRV = 0" : ""));
		  while (resultSet.next())
		  {
			string str = resultSet.getString(5);
			if (paramSet != null && paramSet.Count > 0 && !paramSet.Contains(str))
			{
			  continue;
			}
			ProjectUrlTable projectUrlTable = new ProjectUrlTable();
			projectUrlTable.ProjectUrlId = Convert.ToInt64(resultSet.getLong(1));
			projectUrlTable.Url = resultSet.getString(2);
			projectUrlTable.Username = resultSet.getString(3);
			projectUrlTable.Password = resultSet.getString(4);
			projectUrlTable.DatabaseName = resultSet.getString(5);
			projectUrlTable.Name = resultSet.getString(6);
			projectUrlTable.Dbms = Convert.ToInt32(resultSet.getInt(7));
			projectUrlTable.CreatesNewDatabases = Convert.ToBoolean(resultSet.getBoolean(8));
			projectUrlTable.Hostname = resultSet.getString(9);
			projectUrlTable.Port = resultSet.getString(10);
			arrayList.Add(projectUrlTable);
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		return arrayList;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private java.sql.Connection loginDatabase(String paramString1, String paramString2, String paramString3) throws Exception
	  private Connection loginDatabase(string paramString1, string paramString2, string paramString3)
	  {
		Connection connection = DriverManager.getConnection(paramString1, paramString2, paramString3);
		connection.AutoCommit = false;
		return connection;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private java.util.Collection<nomitech.common.db.local.ProjectUrlTable> filterOutUrlsAlreadyInTarget(java.sql.Connection paramConnection, java.util.Collection<nomitech.common.db.local.ProjectUrlTable> paramCollection) throws Exception
	  private ICollection<ProjectUrlTable> filterOutUrlsAlreadyInTarget(Connection paramConnection, ICollection<ProjectUrlTable> paramCollection)
	  {
		HashSet<object> hashSet = new HashSet<object>(paramCollection.Count);
		List<object> arrayList = new List<object>();
		StringBuilder stringBuffer = new StringBuilder();
		Hashtable hashMap = new Hashtable();
		foreach (ProjectUrlTable projectUrlTable in paramCollection)
		{
		  if (stringBuffer.Length != 0)
		  {
			stringBuffer.Append(",");
		  }
		  stringBuffer.Append(projectUrlTable.Id);
		  hashMap[projectUrlTable.Id] = projectUrlTable;
		}
		ResultSet resultSet = executeSelectQuery(paramConnection, "SELECT o.PRJID FROM (SELECT DISTINCT PRJID FROM PRJPROP) AS o WHERE o.PRJID IN (" + stringBuffer.ToString() + ") ");
		while (resultSet.next())
		{
		  long? long = Convert.ToInt64(resultSet.getLong(1));
		  hashMap.Remove(long);
		}
		return hashMap.Values;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void mergeProjectsInOneDatabase(nomitech.common.ui.UIProgress paramUIProgress, String paramString1, String paramString2, String paramString3, nomitech.common.db.local.ProjectDbmsTable paramProjectDbmsTable, String paramString4, String paramString5, java.util.Set<String> paramSet, boolean paramBoolean1, boolean paramBoolean2) throws Exception
	  public static void mergeProjectsInOneDatabase(UIProgress paramUIProgress, string paramString1, string paramString2, string paramString3, ProjectDbmsTable paramProjectDbmsTable, string paramString4, string paramString5, ISet<string> paramSet, bool paramBoolean1, bool paramBoolean2)
	  {
		ProjectDBUtil.initDriver(ProjectDBUtil.SQLSERVER_DBMS);
		ProjectDBDataMover projectDBDataMover;
		(projectDBDataMover = new ProjectDBDataMover(paramUIProgress)).setProgress(paramUIProgress, "Connecting to master database " + paramString1 + " port " + paramString2 + "...");
		string str = ProjectDBUtil.createJdbcUrl(paramString1, paramString3, paramString2, ProjectDBUtil.SQLSERVER_DBMS);
		Connection connection1 = DriverManager.getConnection(str + ";useLOBs=false", paramString4, paramString5);
		connection1.AutoCommit = false;
		setProgress(paramUIProgress, "Connecting to project database " + paramString1 + " port " + paramString2 + "...");
		str = ProjectDBUtil.createJdbcUrl(paramProjectDbmsTable.HostName, paramProjectDbmsTable.DatabaseName, paramProjectDbmsTable.HostPort, ProjectDBUtil.SQLSERVER_DBMS);
		Connection connection2 = projectDBDataMover.loginDatabase(str + ";useLOBs=false", paramString4, paramString5);
		connection2.AutoCommit = false;
		setProgress(paramUIProgress, "Loading databases from master...");
		System.Collections.IList list = projectDBDataMover.getAllProjectUrls(connection1, paramSet, false);
		ProjectUrlTable projectUrlTable = new ProjectUrlTable();
		projectUrlTable.Dbms = Convert.ToInt32(ProjectDBUtil.SQLSERVER_DBMS);
		projectUrlTable.DatabaseName = paramProjectDbmsTable.DatabaseName;
		projectUrlTable.Hostname = paramProjectDbmsTable.HostName;
		projectUrlTable.Port = paramProjectDbmsTable.HostPort;
		projectUrlTable.DbmsName = paramProjectDbmsTable.InstanceName;
		projectUrlTable.CreatesNewDatabases = Convert.ToBoolean(false);
		projectUrlTable.Username = paramProjectDbmsTable.HostUsername;
		projectUrlTable.Password = paramProjectDbmsTable.HostPassword;
		projectUrlTable.Url = str;
		setProgress(paramUIProgress, "Processing " + list.Count + " databases...");
		System.Collections.ICollection collection = projectDBDataMover.filterOutUrlsAlreadyInTarget(connection2, list);
		connection2.close();
		setProgress(paramUIProgress, "Target Database is " + projectUrlTable.DatabaseName + " and " + collection.Count + " will be processed...");
		foreach (ProjectUrlTable projectUrlTable1 in collection)
		{
		  if (projectUrlTable1.DatabaseName.Equals(projectUrlTable.DatabaseName, StringComparison.OrdinalIgnoreCase))
		  {
			continue;
		  }
		  projectUrlTable.ProjectUrlId = projectUrlTable1.ProjectUrlId;
		  setProgress(paramUIProgress, "\nMerging Database: " + projectUrlTable1.DatabaseName + ", Project ID: " + projectUrlTable1.Id + ", Name: " + projectUrlTable1.Name + " ...");
		  try
		  {
			if (projectUrlTable1.Dbms == projectUrlTable.Dbms && projectUrlTable1.Hostname.Equals(projectUrlTable.Hostname))
			{
			  projectDBDataMover.initialize(projectUrlTable1, projectUrlTable);
			  projectDBDataMover.moveDataSameInstance();
			}
			else
			{
			  projectDBDataMover.initialize(projectUrlTable1, projectUrlTable);
			  projectDBDataMover.moveDataNotSameInstance();
			}
			projectDBDataMover.executeUpdateQuery(connection1, "UPDATE PROJECTURL SET DBSINGLE=0, DBNAME= '" + projectUrlTable.DatabaseName + "', DBSRV = " + projectUrlTable.Dbms + ", DBSRVNAME= '" + projectUrlTable.DbmsName + "', DBUSR= '" + projectUrlTable.Username + "', DBPSWD= '" + projectUrlTable.Password + "', URL = '" + projectUrlTable.Url + "' WHERE PROJECTURLID=" + projectUrlTable.ProjectUrlId);
			setProgress(paramUIProgress, "Done");
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine("Could not merge " + projectUrlTable1.DatabaseName + " to " + projectUrlTable.DatabaseName);
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		  if (paramBoolean2 && projectUrlTable1.Dbms.Value == ProjectDBUtil.SQLSERVER_DBMS)
		  {
			try
			{
			  setProgress(paramUIProgress, "Dropping " + projectUrlTable1.DatabaseName + " ...");
			  projectDBDataMover.executeUpdateQuery(connection1, "DROP DATABASE [" + projectUrlTable1.DatabaseName + "]");
			  setProgress(paramUIProgress, "Done");
			}
			catch (Exception)
			{
			  Console.WriteLine("Could not drop " + projectUrlTable1.DatabaseName);
			}
		  }
		}
		connection1.close();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\ProjectDBDataMover.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}