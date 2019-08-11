using System;

namespace Desktop.common.nomitech.common.templates
{
	using XStream = com.thoughtworks.xstream.XStream;

	public class ProjectTemplate : IComparable
	{
	  private string projectName;

	  private string projectDescription;

	  private string projectGroup;

	  private string projectType;

	  private string projectSubtype;

	  private double projectBasementSqm;

	  private double projectMainSqm;

	  private string projectIcon;

	  private string projectLogo;

	  private string projectEPS;

	  private string projectContractorName;

	  private string projectContractorSignature;

	  private File projectCEPFile = null;

	  public virtual string ProjectName
	  {
		  get
		  {
			  return this.projectName;
		  }
		  set
		  {
			  this.projectName = value;
		  }
	  }


	  public virtual string ProjectDescription
	  {
		  get
		  {
			  return this.projectDescription;
		  }
		  set
		  {
			  this.projectDescription = value;
		  }
	  }


	  public virtual string ProjectEPS
	  {
		  get
		  {
			  return this.projectEPS;
		  }
		  set
		  {
			  this.projectEPS = value;
		  }
	  }


	  public virtual string ProjectType
	  {
		  get
		  {
			  return this.projectType;
		  }
		  set
		  {
			  this.projectType = value;
		  }
	  }


	  public virtual string ProjectSubtype
	  {
		  get
		  {
			  return this.projectSubtype;
		  }
		  set
		  {
			  this.projectSubtype = value;
		  }
	  }


	  public virtual double ProjectBasementSqm
	  {
		  get
		  {
			  return this.projectBasementSqm;
		  }
		  set
		  {
			  this.projectBasementSqm = value;
		  }
	  }


	  public virtual double ProjectMainSqm
	  {
		  get
		  {
			  return this.projectMainSqm;
		  }
		  set
		  {
			  this.projectMainSqm = value;
		  }
	  }


	  public virtual File ProjectCEPFile
	  {
		  get
		  {
			  return this.projectCEPFile;
		  }
		  set
		  {
			  this.projectCEPFile = value;
		  }
	  }


	  public virtual string ProjectIcon
	  {
		  get
		  {
			  return this.projectIcon;
		  }
		  set
		  {
			  this.projectIcon = value;
		  }
	  }


	  public virtual string ProjectLogo
	  {
		  get
		  {
			  return this.projectLogo;
		  }
		  set
		  {
			  this.projectLogo = value;
		  }
	  }


	  public virtual string ProjectContractorName
	  {
		  get
		  {
			  return this.projectContractorName;
		  }
		  set
		  {
			  this.projectContractorName = value;
		  }
	  }


	  public virtual string ProjectContractorSignature
	  {
		  get
		  {
			  return this.projectContractorSignature;
		  }
		  set
		  {
			  this.projectContractorSignature = value;
		  }
	  }


	  public virtual string ProjectGroup
	  {
		  get
		  {
			  return this.projectGroup;
		  }
		  set
		  {
			  this.projectGroup = value;
		  }
	  }


	  public override string ToString()
	  {
		  return this.projectName;
	  }

	  public override bool Equals(object paramObject)
	  {
		  return paramObject.ToString().Equals(ToString());
	  }

	  public virtual int CompareTo(object paramObject)
	  {
		  return paramObject.ToString().CompareTo(this.projectName.ToString());
	  }

	  public virtual string UIProjectTypeName
	  {
		  get
		  {
			  return "dialog.newproject.projecttype." + this.projectType.ToLower();
		  }
	  }

	  public virtual string UIProjectSubtypeName
	  {
		  get
		  {
			  return "dialog.newproject.projectsubtype." + this.projectType.ToLower() + "." + this.projectSubtype.ToLower();
		  }
	  }

	  public static XStream FieldAliases
	  {
		  set
		  {
			value.alias("project-template", typeof(ProjectTemplate));
			value.aliasField("name", typeof(ProjectTemplate), "projectName");
			value.aliasField("description", typeof(ProjectTemplate), "projectDescription");
			value.aliasField("category", typeof(ProjectTemplate), "projectType");
			value.aliasField("group", typeof(ProjectTemplate), "projectGroup");
			value.aliasField("subcategory", typeof(ProjectTemplate), "projectSubtype");
			value.aliasField("superstructure-sqm", typeof(ProjectTemplate), "projectMainSqm");
			value.aliasField("basement-sqm", typeof(ProjectTemplate), "projectBasementSqm");
			value.aliasField("icon", typeof(ProjectTemplate), "projectIcon");
			value.aliasField("logo", typeof(ProjectTemplate), "projectLogo");
			value.aliasField("contractor-name", typeof(ProjectTemplate), "projectContractorName");
			value.aliasField("contractor-signature", typeof(ProjectTemplate), "projectContractorSignature");
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\templates\ProjectTemplate.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}