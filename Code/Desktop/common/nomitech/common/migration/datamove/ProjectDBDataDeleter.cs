using System;

namespace Desktop.common.nomitech.common.migration.datamove
{
	using ProjectUrlTable = nomitech.common.db.local.ProjectUrlTable;
	using ProjectEntityMetadataKeeper = Desktop.common.nomitech.common.migration.datamove.metadataKeeper.ProjectEntityMetadataKeeper;
	using ProjectDBSchemaHelper = Desktop.common.nomitech.common.migration.datamove.schemaHelper.ProjectDBSchemaHelper;
	using UIProgress = nomitech.common.ui.UIProgress;

	public class ProjectDBDataDeleter
	{
	  private ProjectUrlTable urlTable;

	  private UIProgress progress;

	  private Connection connection;

	  private ProjectDBSchemaHelper helper;

	  private ProjectDBDataDeleter(UIProgress paramUIProgress, ProjectUrlTable paramProjectUrlTable)
	  {
		this.progress = paramUIProgress;
		this.urlTable = paramProjectUrlTable;
		this.helper = new ProjectDBSchemaHelper(paramProjectUrlTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void initialize() throws Exception
	  private void initialize()
	  {
		this.progress.Indeterminate = true;
		this.connection = ProjectSessionFactory.getConnection(this.urlTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public int executeUpdateQuery(java.sql.Connection paramConnection, String paramString) throws Exception
	  public virtual int executeUpdateQuery(Connection paramConnection, string paramString)
	  {
		Statement statement = null;
		try
		{
		  statement = paramConnection.createStatement();
		  return statement.executeUpdate(paramString);
		}
		catch (SQLException sQLException)
		{
		  throw new Exception(sQLException);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void cleanUp() throws Exception
	  private void cleanUp()
	  {
		this.progress.Indeterminate = true;
		this.connection.close();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void deleteProjectData() throws Exception
	  private void deleteProjectData()
	  {
		initialize();
		System.Collections.IList list1 = this.helper.listEntitiesWithForeignKeys();
		System.Collections.IList list2 = this.helper.listEntities();
		this.progress.Indeterminate = false;
		this.progress.TotalTimes = list1.Count + list2.Count;
		foreach (ProjectEntityMetadataKeeper projectEntityMetadataKeeper in list1)
		{
		  executeUpdateQuery(this.connection, projectEntityMetadataKeeper.UpdateForeignKeysWithNullsStatement);
		  this.progress.incrementProgress(1);
		}
		foreach (ProjectEntityMetadataKeeper projectEntityMetadataKeeper in list2)
		{
		  executeUpdateQuery(this.connection, projectEntityMetadataKeeper.DeleteStatement);
		  this.progress.incrementProgress(1);
		}
		cleanUp();
	  }

	  public static void deleteProjectData(UIProgress paramUIProgress, ProjectUrlTable paramProjectUrlTable)
	  {
		ProjectDBDataDeleter projectDBDataDeleter = new ProjectDBDataDeleter(paramUIProgress, paramProjectUrlTable);
		projectDBDataDeleter.deleteProjectData();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\ProjectDBDataDeleter.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}