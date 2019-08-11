using System.Collections.Generic;

namespace Desktop.common.nomitech.costos.plugin.api
{
	using ProjectDBUtil = nomitech.common.ProjectDBUtil;
	using BaseTableList = nomitech.common.@base.BaseTableList;
	using UIProgress = nomitech.common.ui.UIProgress;

	public abstract class IProjectExtension : IExtension
	{
		public abstract string Name {get;}
		public abstract void loadExtension(javax.swing.JFrame paramJFrame, Properties paramProperties);
	  protected internal ProjectContextKeeper projectContext;

	  protected internal ResourceContextKeeper resourceContext;

	  public virtual IList<ExtensionPropertyDefinition> loadProperties(Properties paramProperties)
	  {
		  return Collections.EMPTY_LIST;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void setNewProperties(java.util.Properties paramProperties) throws IllegalArgumentException
	  public virtual Properties NewProperties
	  {
		  set
		  {
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void projectOpening(nomitech.common.ui.UIProgress paramUIProgress, nomitech.common.ProjectDBUtil paramProjectDBUtil) throws Exception
	  public virtual void projectOpening(UIProgress paramUIProgress, ProjectDBUtil paramProjectDBUtil)
	  {
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void projectSaving(nomitech.common.ui.UIProgress paramUIProgress, nomitech.common.ProjectDBUtil paramProjectDBUtil) throws Exception
	  public virtual void projectSaving(UIProgress paramUIProgress, ProjectDBUtil paramProjectDBUtil)
	  {
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void projectClosing(nomitech.common.ui.UIProgress paramUIProgress, nomitech.common.ProjectDBUtil paramProjectDBUtil, boolean paramBoolean) throws Exception
	  public virtual void projectClosing(UIProgress paramUIProgress, ProjectDBUtil paramProjectDBUtil, bool paramBoolean)
	  {
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void projectCopying(nomitech.common.ui.UIProgress paramUIProgress, nomitech.common.ProjectDBUtil paramProjectDBUtil1, nomitech.common.ProjectDBUtil paramProjectDBUtil2) throws Exception
	  public virtual void projectCopying(UIProgress paramUIProgress, ProjectDBUtil paramProjectDBUtil1, ProjectDBUtil paramProjectDBUtil2)
	  {
	  }

	  public virtual ResourceContext ResourceContext
	  {
		  get
		  {
			  return this.resourceContext.currentResourceContext();
		  }
	  }

	  public virtual ResourceContextKeeper ResourceContextKeeper
	  {
		  set
		  {
			  this.resourceContext = value;
		  }
	  }

	  public virtual ProjectContextKeeper ProjectContextKeeper
	  {
		  set
		  {
			  this.projectContext = value;
		  }
	  }

	  public virtual ProjectContext ProjectContext
	  {
		  get
		  {
			  return this.projectContext.currentProjectContext();
		  }
	  }

	  public virtual bool supportsDataSync()
	  {
		  return false;
	  }

	  public virtual void unloadExtension()
	  {
	  }

	  public virtual bool checkDropDataAvailable(string paramString)
	  {
		  return false;
	  }

	  public virtual BaseTableList getBoqItemTableList(string paramString)
	  {
		  return null;
	  }

	  public virtual BaseTableList getConditionTableList(string paramString)
	  {
		  return null;
	  }

	  public virtual object callExtension(string paramString, long? paramLong)
	  {
		  return null;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\IProjectExtension.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}