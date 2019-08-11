using System.Collections.Generic;

namespace Desktop.common.nomitech.common.migration.datamove.schemaHelper
{
	using BaseEntityMetadataKeeper = nomitech.common.migration.datamove.metadataKeeper.BaseEntityMetadataKeeper;
	using PersistentClass = org.hibernate.mapping.PersistentClass;

	public abstract class BaseSchemaHelper<T> : object where T : nomitech.common.migration.datamove.metadataKeeper.BaseEntityMetadataKeeper
	{
	  internal IList<PersistentClass> allClasses;

	  internal IList<T> entities = null;

	  internal IDictionary<string, T> entitiesByTableName;

	  internal BaseSchemaHelper()
	  {
	  }

	  internal BaseSchemaHelper(IList<PersistentClass> paramList)
	  {
		this.allClasses = paramList;
		init();
	  }

	  internal virtual void init()
	  {
		this.entities = (System.Collections.IList)this.allClasses.Select(paramPersistentClass => createMetadataKeeper(paramPersistentClass)).ToList();
		this.entitiesByTableName = (System.Collections.IDictionary)this.entities.ToDictionary(paramBaseEntityMetadataKeeper => paramBaseEntityMetadataKeeper.TableName, paramBaseEntityMetadataKeeper => paramBaseEntityMetadataKeeper);
	  }

	  internal abstract T createMetadataKeeper(PersistentClass paramPersistentClass);

	  public virtual IList<T> listEntitiesWithForeignKeys()
	  {
		List<object> arrayList = new List<object>();
		foreach (BaseEntityMetadataKeeper baseEntityMetadataKeeper in this.entities)
		{
		  if (baseEntityMetadataKeeper.hasForeignKeys())
		  {
			arrayList.Add(baseEntityMetadataKeeper);
		  }
		}
		return arrayList;
	  }

	  public virtual IList<T> listEntities()
	  {
		  return this.entities;
	  }

	  public virtual T getEntity(string paramString)
	  {
		  return (T)(BaseEntityMetadataKeeper)this.entitiesByTableName.get(paramString);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\schemaHelper\BaseSchemaHelper.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}