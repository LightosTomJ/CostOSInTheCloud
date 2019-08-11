using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.migration.datamove.schemaHelper
{
	using ProjectUrlTable = nomitech.common.db.local.ProjectUrlTable;
	using BaseEntityMetadataKeeper = nomitech.common.migration.datamove.metadataKeeper.BaseEntityMetadataKeeper;
	using ProjectEntityMetadataKeeper = nomitech.common.migration.datamove.metadataKeeper.ProjectEntityMetadataKeeper;
	using PersistentClass = org.hibernate.mapping.PersistentClass;

	public class ProjectDBSchemaHelper : BaseSchemaHelper<ProjectEntityMetadataKeeper>
	{
	  private ProjectUrlTable urlTable;

	  public ProjectDBSchemaHelper(ProjectUrlTable paramProjectUrlTable)
	  {
		this.urlTable = paramProjectUrlTable;
		this.allClasses = AllClasses;
		init();
	  }

	  public virtual ProjectUrlTable UrlTable
	  {
		  set
		  {
			  this.urlTable = value;
		  }
	  }

	  internal override ProjectEntityMetadataKeeper createMetadataKeeper(PersistentClass paramPersistentClass)
	  {
		  return new ProjectEntityMetadataKeeper(this, this.urlTable, paramPersistentClass);
	  }

	  internal static IList<PersistentClass> AllClasses
	  {
		  get
		  {
			System.Predicate predicate = paramPersistentClass =>
			{
			try
			{
			  Type clazz = Type.GetType(paramPersistentClass.ClassName);
			  return clazz.IsAssignableFrom(typeof(nomitech.common.@base.ProjectIdEntity));
			}
			catch (ClassNotFoundException classNotFoundException)
			{
			  Console.WriteLine(classNotFoundException.ToString());
			  Console.Write(classNotFoundException.StackTrace);
			  return false;
			}
			};
			return (System.Collections.IList)ProjectSessionFactory.listClasses().Where(predicate).ToList();
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\schemaHelper\ProjectDBSchemaHelper.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}