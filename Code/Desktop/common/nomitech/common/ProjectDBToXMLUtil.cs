using System;
using System.Text;
using System.IO;

namespace Desktop.common.nomitech.common
{
	using XStream = com.thoughtworks.xstream.XStream;
	using AbstractBasicConverter = com.thoughtworks.xstream.converters.basic.AbstractBasicConverter;
	using SqlTimestampConverter = com.thoughtworks.xstream.converters.extended.SqlTimestampConverter;
	using BaseTableList = Desktop.common.nomitech.common.@base.BaseTableList;
	using ResourceTable = Desktop.common.nomitech.common.@base.ResourceTable;
	using LayoutTable = Models.layout.LayoutTable;
	using ExternalDatasourceTable = Models.local.ExternalDatasourceTable;
	using FunctionTable = Models.local.FunctionTable;
	using BoqItemTable = Models.proj.BoqItemTable;
	using ProjectTemplateTable = Models.proj.ProjectTemplateTable;
	using WorksheetRevisionTable = Models.proj.WorksheetRevisionTable;
	using Session = org.hibernate.Session;
	using Transaction = org.hibernate.Transaction;

	public class ProjectDBToXMLUtil
	{
	  private static ProjectDBToXMLUtil s_instance = null;

	  private XStream o_xStream = null;

	  private ProjectDBToXMLUtil()
	  {
		this.o_xStream = new XStream();
		init();
	  }

	  public virtual string externalDatasourceToXML(ExternalDatasourceTable paramExternalDatasourceTable)
	  {
		  return this.o_xStream.toXML(paramExternalDatasourceTable);
	  }

	  public virtual ExternalDatasourceTable externalDatasourceFromXML(string paramString)
	  {
		  return (ExternalDatasourceTable)this.o_xStream.fromXML(paramString);
	  }

	  public virtual string layoutToXML(LayoutTable paramLayoutTable)
	  {
		  return this.o_xStream.toXML(paramLayoutTable);
	  }

	  public virtual LayoutTable layoutFromXML(string paramString)
	  {
		  return (LayoutTable)this.o_xStream.fromXML(paramString);
	  }

	  public virtual string toXML(ResourceTable paramResourceTable)
	  {
		  return this.o_xStream.toXML(paramResourceTable);
	  }

	  public virtual string objectToXML(object paramObject)
	  {
		  return this.o_xStream.toXML(paramObject);
	  }

	  public virtual ResourceTable fromXML(string paramString)
	  {
		  return (ResourceTable)this.o_xStream.fromXML(paramString);
	  }

	  public virtual object objectFromXML(string paramString)
	  {
		  return this.o_xStream.fromXML(paramString);
	  }

	  public virtual FunctionTable functionFromXML(string paramString)
	  {
		  return (FunctionTable)this.o_xStream.fromXML(paramString);
	  }

	  public virtual string functionToXML(FunctionTable paramFunctionTable)
	  {
		  return this.o_xStream.toXML(paramFunctionTable);
	  }

	  private void init()
	  {
		  this.o_xStream.registerConverter(new SqlTimestampConverter());
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void toXML(ProjectDBUtil paramProjectDBUtil, java.io.File paramFile) throws Exception
	  public virtual void toXML(ProjectDBUtil paramProjectDBUtil, File paramFile)
	  {
		StreamWriter fileWriter = new StreamWriter(paramFile);
		Session session = paramProjectDBUtil.currentSession();
		Transaction transaction = session.beginTransaction();
		try
		{
		  System.Collections.IEnumerator iterator = session.createQuery("from BoqItemTable as o where o.projectId = :prjId order by boqitemId asc").setLong("prjId", paramProjectDBUtil.ProjectUrlId.Value).iterate();
		  while (iterator.MoveNext())
		  {
			this.o_xStream.toXML(((BoqItemTable)iterator.Current).deepCopy(false), fileWriter);
		  }
		  fileWriter.Flush();
		  fileWriter.Close();
		  transaction.commit();
		}
		catch (Exception exception)
		{
		  transaction.rollback();
		  paramProjectDBUtil.closeSession();
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw exception;
		}
		paramProjectDBUtil.closeSession();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void listToXML(java.util.List paramList, java.io.File paramFile) throws Exception
	  public virtual void listToXML(System.Collections.IList paramList, File paramFile)
	  {
		StreamWriter fileWriter = new StreamWriter(paramFile);
		try
		{
		  this.o_xStream.toXML(paramList, fileWriter);
		  fileWriter.Flush();
		  fileWriter.Close();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw exception;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.List listFromXML(java.io.File paramFile) throws Exception
	  public virtual System.Collections.IList listFromXML(File paramFile)
	  {
		StreamReader fileReader = new StreamReader(paramFile);
		try
		{
		  System.Collections.IList list = (System.Collections.IList)this.o_xStream.fromXML(fileReader);
		  fileReader.Close();
		  return list;
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw exception;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void worksheetTemplateToXML(Desktop.common.nomitech.common.db.project.WorksheetRevisionTable paramWorksheetRevisionTable, java.io.File paramFile) throws Exception
	  public virtual void worksheetTemplateToXML(WorksheetRevisionTable paramWorksheetRevisionTable, File paramFile)
	  {
		StreamWriter fileWriter = new StreamWriter(paramFile);
		try
		{
		  this.o_xStream.toXML(paramWorksheetRevisionTable, fileWriter);
		  fileWriter.Flush();
		  fileWriter.Close();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw exception;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void worksheetTemplateToSer(Desktop.common.nomitech.common.db.project.WorksheetRevisionTable paramWorksheetRevisionTable, java.io.File paramFile) throws Exception
	  public virtual void worksheetTemplateToSer(WorksheetRevisionTable paramWorksheetRevisionTable, File paramFile)
	  {
		FileStream fileOutputStream = new FileStream(paramFile, FileMode.Create, FileAccess.Write);
		BufferedOutputStream bufferedOutputStream = new BufferedOutputStream(fileOutputStream);
		ObjectOutputStream objectOutputStream = new ObjectOutputStream(bufferedOutputStream);
		try
		{
		  objectOutputStream.writeObject(paramWorksheetRevisionTable);
		}
		catch (Exception exception)
		{
		  objectOutputStream.close();
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw exception;
		}
		objectOutputStream.close();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void projectTemplateToXML(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, java.io.File paramFile) throws Exception
	  public virtual void projectTemplateToXML(ProjectTemplateTable paramProjectTemplateTable, File paramFile)
	  {
		StreamWriter fileWriter = new StreamWriter(paramFile);
		try
		{
		  this.o_xStream.toXML(paramProjectTemplateTable, fileWriter);
		  fileWriter.Flush();
		  fileWriter.Close();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw exception;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void projectTemplateToSer(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, java.io.File paramFile) throws Exception
	  public virtual void projectTemplateToSer(ProjectTemplateTable paramProjectTemplateTable, File paramFile)
	  {
		FileStream fileOutputStream = new FileStream(paramFile, FileMode.Create, FileAccess.Write);
		BufferedOutputStream bufferedOutputStream = new BufferedOutputStream(fileOutputStream);
		ObjectOutputStream objectOutputStream = new ObjectOutputStream(bufferedOutputStream);
		try
		{
		  objectOutputStream.writeObject(paramProjectTemplateTable);
		}
		catch (Exception exception)
		{
		  objectOutputStream.close();
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw exception;
		}
		objectOutputStream.close();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Desktop.common.nomitech.common.db.project.WorksheetRevisionTable worksheetTemplateFromXML(java.io.File paramFile) throws Exception
	  public virtual WorksheetRevisionTable worksheetTemplateFromXML(File paramFile)
	  {
		StreamReader fileReader = new StreamReader(paramFile);
		try
		{
		  WorksheetRevisionTable worksheetRevisionTable = (WorksheetRevisionTable)this.o_xStream.fromXML(fileReader);
		  fileReader.Close();
		  return worksheetRevisionTable;
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw exception;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Desktop.common.nomitech.common.db.project.WorksheetRevisionTable worksheetTemplateFromSer(java.io.File paramFile) throws Exception
	  public virtual WorksheetRevisionTable worksheetTemplateFromSer(File paramFile)
	  {
		FileStream fileInputStream = new FileStream(paramFile, FileMode.Open, FileAccess.Read);
		BufferedInputStream bufferedInputStream = new BufferedInputStream(fileInputStream);
		ObjectInputStream objectInputStream = new ObjectInputStream(bufferedInputStream);
		WorksheetRevisionTable worksheetRevisionTable = null;
		try
		{
		  worksheetRevisionTable = (WorksheetRevisionTable)objectInputStream.readObject();
		}
		catch (Exception exception)
		{
		  objectInputStream.close();
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw exception;
		}
		objectInputStream.close();
		return worksheetRevisionTable;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Desktop.common.nomitech.common.db.project.ProjectTemplateTable projectTemplateFromXML(java.io.File paramFile) throws Exception
	  public virtual ProjectTemplateTable projectTemplateFromXML(File paramFile)
	  {
		StreamReader fileReader = new StreamReader(paramFile);
		try
		{
		  ProjectTemplateTable projectTemplateTable = (ProjectTemplateTable)this.o_xStream.fromXML(fileReader);
		  fileReader.Close();
		  return projectTemplateTable;
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw exception;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Desktop.common.nomitech.common.db.project.ProjectTemplateTable projectTemplateFromSer(java.io.File paramFile) throws Exception
	  public virtual ProjectTemplateTable projectTemplateFromSer(File paramFile)
	  {
		FileStream fileInputStream = new FileStream(paramFile, FileMode.Open, FileAccess.Read);
		BufferedInputStream bufferedInputStream = new BufferedInputStream(fileInputStream);
		ObjectInputStream objectInputStream = new ObjectInputStream(bufferedInputStream);
		ProjectTemplateTable projectTemplateTable = null;
		try
		{
		  projectTemplateTable = (ProjectTemplateTable)objectInputStream.readObject();
		}
		catch (Exception exception)
		{
		  objectInputStream.close();
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw exception;
		}
		objectInputStream.close();
		return projectTemplateTable;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void resourcesToXML(Desktop.common.nomitech.common.base.BaseTableList paramBaseTableList, java.io.File paramFile) throws Exception
	  public virtual void resourcesToXML(BaseTableList paramBaseTableList, File paramFile)
	  {
		try
		{
		  StreamWriter outputStreamWriter = new StreamWriter(new FileStream(paramFile, FileMode.Create, FileAccess.Write), Encoding.UTF8);
		  this.o_xStream.toXML(paramBaseTableList, outputStreamWriter);
		  outputStreamWriter.Flush();
		  outputStreamWriter.Close();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw exception;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void resourcesToSer(Desktop.common.nomitech.common.base.BaseTableList paramBaseTableList, java.io.File paramFile) throws Exception
	  public virtual void resourcesToSer(BaseTableList paramBaseTableList, File paramFile)
	  {
		FileStream fileOutputStream = new FileStream(paramFile, FileMode.Create, FileAccess.Write);
		BufferedOutputStream bufferedOutputStream = new BufferedOutputStream(fileOutputStream);
		ObjectOutputStream objectOutputStream = new ObjectOutputStream(bufferedOutputStream);
		try
		{
		  objectOutputStream.writeObject(paramBaseTableList);
		}
		catch (Exception exception)
		{
		  objectOutputStream.close();
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw exception;
		}
		objectOutputStream.close();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Desktop.common.nomitech.common.base.BaseTableList resourcesFromXML(java.io.File paramFile) throws Exception
	  public virtual BaseTableList resourcesFromXML(File paramFile)
	  {
		try
		{
		  StreamReader inputStreamReader = new StreamReader(new FileStream(paramFile, FileMode.Open, FileAccess.Read), Encoding.UTF8);
		  BaseTableList baseTableList = (BaseTableList)this.o_xStream.fromXML(inputStreamReader);
		  inputStreamReader.Close();
		  return baseTableList;
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw exception;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Desktop.common.nomitech.common.base.BaseTableList resourcesFromSer(java.io.File paramFile) throws Exception
	  public virtual BaseTableList resourcesFromSer(File paramFile)
	  {
		FileStream fileInputStream = new FileStream(paramFile, FileMode.Open, FileAccess.Read);
		BufferedInputStream bufferedInputStream = new BufferedInputStream(fileInputStream);
		ObjectInputStream objectInputStream = new ObjectInputStream(bufferedInputStream);
		BaseTableList baseTableList = null;
		try
		{
		  baseTableList = (BaseTableList)objectInputStream.readObject();
		}
		catch (Exception exception)
		{
		  objectInputStream.close();
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw exception;
		}
		objectInputStream.close();
		return baseTableList;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public ProjectDBUtil fromXML(java.io.File paramFile) throws Exception
	  public virtual ProjectDBUtil fromXML(File paramFile)
	  {
		  return null;
	  }

	  public static ProjectDBToXMLUtil Instance
	  {
		  get
		  {
			if (s_instance == null)
			{
			  s_instance = new ProjectDBToXMLUtil();
			}
			return s_instance;
		  }
	  }

	  private class BigDecimalFixedConverter : AbstractBasicConverter
	  {
		  private readonly ProjectDBToXMLUtil outerInstance;

		  public BigDecimalFixedConverter(ProjectDBToXMLUtil outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		public virtual bool canConvert(Type param1Class)
		{
			return param1Class.Equals(typeof(Desktop.common.nomitech.common.db.types.BigDecimalFixed));
		}

		protected internal virtual object fromString(string param1String)
		{
			return new decimal(param1String);
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ProjectDBToXMLUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}