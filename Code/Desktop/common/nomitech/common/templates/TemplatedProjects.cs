using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common.templates
{
	using XStream = com.thoughtworks.xstream.XStream;

	public class TemplatedProjects
	{
	  private const string TEMPLATES_DIR = "templates";

	  private const string TEMPLATE_DESCRIPTOR = "template-info.xml";

	  private const string TEMPLATE_CEP = "template.cep";

	  private const string BLANK_TEMPLATE = "Blank";

	  private static TemplatedProjects s_instance = null;

	  private System.Collections.IDictionary o_descMap = new Hashtable();

	  private System.Collections.IDictionary o_groupMap = new Hashtable();

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private TemplatedProjects() throws Exception
	  private TemplatedProjects()
	  {
		  loadProjects();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadProjects() throws Exception
	  private void loadProjects()
	  {
		File file = new File("templates");
		if (!file.Directory)
		{
		  file.mkdir();
		}
		File[] arrayOfFile = file.listFiles(new TemplateFileFilter(this, null));
		foreach (File file1 in arrayOfFile)
		{
		  File file2 = null;
		  File file3 = null;
		  File[] arrayOfFile1 = file1.listFiles();
		  foreach (File file4 in arrayOfFile1)
		  {
			if (file4.Name.ToLower().Equals("template-info.xml"))
			{
			  file2 = file4;
			}
			else if (file4.Name.ToLower().Equals("template.cep"))
			{
			  file3 = file4;
			}
		  }
		  XStream xStream = new XStream();
		  ProjectTemplate.FieldAliases = xStream;
		  StreamReader fileReader = new StreamReader(file2);
		  ProjectTemplate projectTemplate = (ProjectTemplate)xStream.fromXML(fileReader);
		  projectTemplate.ProjectCEPFile = file3;
		  this.o_descMap[file1.Name] = projectTemplate;
		  fileReader.Close();
		  if (!string.ReferenceEquals(projectTemplate.ProjectGroup, null) && !projectTemplate.ProjectGroup.Equals(""))
		  {
			List<object> vector = (List<object>)this.o_groupMap[projectTemplate.ProjectGroup];
			if (vector == null)
			{
			  vector = new List<object>();
			  this.o_groupMap[projectTemplate.ProjectGroup] = vector;
			}
			vector.Add(projectTemplate);
		  }
		}
	  }

	  public virtual ProjectTemplate[] ProjectTemplates
	  {
		  get
		  {
			string[] arrayOfString = ProjectTemplateKeys;
			ProjectTemplate[] arrayOfProjectTemplate = new ProjectTemplate[arrayOfString.Length];
			for (sbyte b = 0; b < arrayOfProjectTemplate.Length; b++)
			{
			  arrayOfProjectTemplate[b] = getProjectTemplate(arrayOfString[b]);
			}
			return arrayOfProjectTemplate;
		  }
	  }

	  public virtual string[] ProjectTemplateGroupKeys
	  {
		  get
		  {
			string[] arrayOfString = (string[])this.o_groupMap.Keys.toArray(new string[0]);
			Arrays.sort(arrayOfString);
			return arrayOfString;
		  }
	  }

	  public virtual ProjectTemplate[] getProjectTemplateGroup(string paramString)
	  {
		List<object> vector = (List<object>)this.o_groupMap[paramString];
		ProjectTemplate[] arrayOfProjectTemplate = (ProjectTemplate[])vector.ToArray(typeof(ProjectTemplate));
		Arrays.sort(arrayOfProjectTemplate);
		return arrayOfProjectTemplate;
	  }

	  public virtual string[] ProjectTemplateKeys
	  {
		  get
		  {
			string[] arrayOfString = (string[])this.o_descMap.Keys.toArray(new string[0]);
			Arrays.sort(arrayOfString);
			return arrayOfString;
		  }
	  }

	  public virtual ProjectTemplate getProjectTemplate(string paramString)
	  {
		  return (ProjectTemplate)this.o_descMap[paramString];
	  }

	  public virtual ProjectTemplate BlankTemplate
	  {
		  get
		  {
			  return getProjectTemplate("Blank");
		  }
	  }

	  public virtual bool isBlankTemplate(ProjectTemplate paramProjectTemplate)
	  {
		  return paramProjectTemplate.ProjectName.Equals(BlankTemplate.ProjectName);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void createNewTemplateXML(String paramString) throws Exception
	  public virtual void createNewTemplateXML(string paramString)
	  {
		ProjectTemplate projectTemplate = new ProjectTemplate();
		projectTemplate.ProjectName = paramString;
		projectTemplate.ProjectDescription = paramString + " description";
		projectTemplate.ProjectBasementSqm = 0.0D;
		projectTemplate.ProjectMainSqm = 0.0D;
		projectTemplate.ProjectType = "construction";
		projectTemplate.ProjectSubtype = "office";
		File file1 = new File("templates" + File.separator + paramString);
		file1.mkdirs();
		File file2 = new File("templates" + File.separator + paramString + File.separator + "template-info.xml");
		file2.createNewFile();
		XStream xStream = new XStream();
		ProjectTemplate.FieldAliases = xStream;
		StreamWriter fileWriter = new StreamWriter(file2);
		xStream.toXML(projectTemplate, fileWriter);
		fileWriter.Flush();
		fileWriter.Close();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static TemplatedProjects getInstance() throws Exception
	  public static TemplatedProjects Instance
	  {
		  get
		  {
			if (s_instance == null)
			{
			  s_instance = new TemplatedProjects();
			}
			return s_instance;
		  }
	  }

	  private class TemplateFileFilter : FileFilter
	  {
		  private readonly TemplatedProjects outerInstance;

		internal TemplateFileFilter(TemplatedProjects outerInstance)
		{
			this.outerInstance = outerInstance;
		}

		public virtual bool accept(File param1File)
		{
		  bool bool1 = false;
		  bool bool2 = false;
		  if (param1File.Directory)
		  {
			File[] arrayOfFile = param1File.listFiles();
			foreach (File file in arrayOfFile)
			{
			  if (file.Name.ToLower().Equals("template-info.xml"))
			  {
				bool1 = true;
			  }
			  else if (file.Name.ToLower().Equals("template.cep"))
			  {
				bool2 = true;
			  }
			}
		  }
		  return (bool1 && bool2);
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\templates\TemplatedProjects.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}