using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common
{
	using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;
	using ProjectUrlTable = Desktop.common.nomitech.common.db.local.ProjectUrlTable;
	using StringUtils = Desktop.common.nomitech.common.util.StringUtils;
	using CallbackException = org.hibernate.CallbackException;
	using EmptyInterceptor = org.hibernate.EmptyInterceptor;
	using Type = org.hibernate.type.Type;

	public class ProjectDBInterceptor : EmptyInterceptor
	{
	  private const string PROJECT_VIEW = "--#PRJ#--";

	  private ProjectDBUtil prjDBUtil = null;

	  private ProjectUrlTable urlTable = null;

	  private IDictionary<Type, int> prjIdIdxMap = new Hashtable();

	  public ProjectDBInterceptor(ProjectDBUtil paramProjectDBUtil)
	  {
		  this.prjDBUtil = paramProjectDBUtil;
	  }

	  public ProjectDBInterceptor(ProjectUrlTable paramProjectUrlTable)
	  {
		  this.urlTable = paramProjectUrlTable;
	  }

	  private long? ProjectUrlId
	  {
		  get
		  {
			  return (this.prjDBUtil != null) ? this.prjDBUtil.ProjectUrlId : this.urlTable.ProjectUrlId;
		  }
	  }

	  private int findIndexOfProjectId(ProjectIdEntity paramProjectIdEntity, string[] paramArrayOfString)
	  {
		int? integer = (int?)this.prjIdIdxMap[paramProjectIdEntity.GetType()];
		if (integer == null)
		{
		  integer = StringUtils.IndexOf(paramArrayOfString, "projectId");
		  this.prjIdIdxMap[paramProjectIdEntity.GetType()] = integer.Value;
		}
		return integer.Value;
	  }

	  public virtual string onPrepareStatement(string paramString)
	  {
		if (paramString.IndexOf("--#PRJ#--", StringComparison.Ordinal) != -1)
		{
		  paramString = StringUtils.replaceAll(paramString, "#prjId", ProjectUrlId.ToString());
		}
		return paramString;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public boolean onSave(Object paramObject, java.io.Serializable paramSerializable, Object[] paramArrayOfObject, String[] paramArrayOfString, org.hibernate.type.Type[] paramArrayOfType) throws org.hibernate.CallbackException
	  public virtual bool onSave(object paramObject, Serializable paramSerializable, object[] paramArrayOfObject, string[] paramArrayOfString, Type[] paramArrayOfType)
	  {
		if (paramObject is ProjectIdEntity)
		{
		  ProjectIdEntity projectIdEntity = (ProjectIdEntity)paramObject;
		  int i = findIndexOfProjectId(projectIdEntity, paramArrayOfString);
		  paramArrayOfObject[i] = ProjectUrlId;
		  return true;
		}
		return false;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ProjectDBInterceptor.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}