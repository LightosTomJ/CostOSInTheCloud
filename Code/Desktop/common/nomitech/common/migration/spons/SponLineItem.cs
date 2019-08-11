using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.migration.spon
{
	using StringUtils = nomitech.common.util.StringUtils;

	public class SponLineItem : DefaultMutableTreeNode
	{
	  private string bookCode;

	  private string code;

	  private string description;

	  private double? labor;

	  private double? material;

	  private double? plant;

	  private double? total;

	  private double? secondLabor;

	  private double? secondMaterial;

	  private double? secondPlant;

	  private double? secondTotal;

	  private string secondDescription;

	  private bool hasSecond = false;

	  private string wbsCode = null;

	  private int index = -1;

	  private string notes = "";

	  private IList<string> moreDescription = new List<object>();

	  private IList<string> moreSecondDescription = new List<object>();

	  private string unit;

	  public SponLineItem(string paramString1, string paramString2, string paramString3, double? paramDouble1, double? paramDouble2, double? paramDouble3, double? paramDouble4, string paramString4)
	  {
		this.bookCode = paramString1;
		this.code = paramString2;
		if (paramString3.IndexOf("\"", StringComparison.Ordinal) != -1)
		{
		  paramString3 = StringUtils.replaceAll(paramString3, "\"", "");
		}
		this.description = paramString3;
		this.labor = paramDouble1;
		this.material = paramDouble2;
		this.plant = paramDouble3;
		this.total = paramDouble4;
		this.unit = paramString4;
	  }

	  public SponLineItem(string paramString1, string paramString2, string paramString3, string paramString4, string paramString5, string paramString6, string paramString7, string paramString8)
	  {
		this.bookCode = paramString1;
		this.code = paramString2;
		if (paramString3.IndexOf("\"", StringComparison.Ordinal) != -1)
		{
		  paramString3 = StringUtils.replaceAll(paramString3, "\"", "");
		}
		this.description = paramString3;
		try
		{
		  this.labor = Convert.ToDouble(paramString4);
		}
		catch (Exception)
		{
		  this.labor = null;
		}
		try
		{
		  this.material = Convert.ToDouble(paramString5);
		}
		catch (Exception)
		{
		  this.material = null;
		}
		try
		{
		  this.plant = Convert.ToDouble(paramString6);
		}
		catch (Exception)
		{
		  this.plant = null;
		}
		try
		{
		  this.total = Convert.ToDouble(paramString7);
		}
		catch (Exception)
		{
		  if (!paramString7.Equals(""))
		  {
			Console.WriteLine("\n\n\nCould not parse: " + paramString7 + " for code " + paramString2);
		  }
		  this.total = null;
		}
		this.unit = paramString8;
	  }

	  public virtual string BookCode
	  {
		  get
		  {
			  return this.bookCode;
		  }
		  set
		  {
			  this.bookCode = value;
		  }
	  }


	  public virtual string Code
	  {
		  get
		  {
			  return this.code;
		  }
		  set
		  {
			  this.code = value;
		  }
	  }


	  public virtual string Description
	  {
		  get
		  {
			  return this.description;
		  }
		  set
		  {
			  this.description = value;
		  }
	  }


	  public virtual double? Labor
	  {
		  get
		  {
			  return this.labor;
		  }
		  set
		  {
			  this.labor = value;
		  }
	  }


	  public virtual double? Material
	  {
		  get
		  {
			  return this.material;
		  }
		  set
		  {
			  this.material = value;
		  }
	  }


	  public virtual double? Plant
	  {
		  get
		  {
			  return this.plant;
		  }
		  set
		  {
			  this.plant = value;
		  }
	  }


	  public virtual double? Total
	  {
		  get
		  {
			  return this.total;
		  }
		  set
		  {
			  this.total = value;
		  }
	  }


	  public virtual string Unit
	  {
		  get
		  {
			  return this.unit;
		  }
		  set
		  {
			  this.unit = value;
		  }
	  }


	  public virtual double? SecondLabor
	  {
		  get
		  {
			  return this.secondLabor;
		  }
		  set
		  {
			  this.secondLabor = value;
		  }
	  }


	  public virtual double? SecondMaterial
	  {
		  get
		  {
			  return this.secondMaterial;
		  }
		  set
		  {
			  this.secondMaterial = value;
		  }
	  }


	  public virtual double? SecondPlant
	  {
		  get
		  {
			  return this.secondPlant;
		  }
		  set
		  {
			  this.secondPlant = value;
		  }
	  }


	  public virtual double? SecondTotal
	  {
		  get
		  {
			  return this.secondTotal;
		  }
		  set
		  {
			  this.secondTotal = value;
		  }
	  }


	  public virtual string SecondDescription
	  {
		  get
		  {
			  return this.secondDescription;
		  }
		  set
		  {
			  this.secondDescription = value;
		  }
	  }


	  public virtual bool HasSecond
	  {
		  get
		  {
			  return this.hasSecond;
		  }
		  set
		  {
			  this.hasSecond = value;
		  }
	  }


	  public virtual bool NoteItem
	  {
		  get
		  {
			  return (!string.ReferenceEquals(this.description, null) && this.description.IndexOf("NOTE", StringComparison.Ordinal) != -1);
		  }
	  }

	  public virtual bool Composite
	  {
		  get
		  {
			  return !(!string.ReferenceEquals(this.unit, null) && !this.unit.Equals(""));
		  }
	  }

	  public override bool Equals(object paramObject)
	  {
		  return ((SponLineItem)paramObject).code.Equals(this.code);
	  }

	  public override string ToString()
	  {
		  return Composite ? (this.code + ". " + this.description) : (this.code + ". " + this.description + " " + this.labor + "+" + this.material + "+" + this.plant + "=" + this.total + " (" + this.unit + ")");
	  }

	  public virtual SponLineItem SecondItem
	  {
		  set
		  {
			this.secondLabor = value.labor;
			this.secondMaterial = value.material;
			this.secondPlant = value.plant;
			this.secondDescription = value.description;
			this.hasSecond = true;
		  }
	  }

	  public virtual string WbsCode
	  {
		  get
		  {
			  return this.wbsCode;
		  }
		  set
		  {
			  this.wbsCode = value;
		  }
	  }


	  public virtual IList<string> MoreDescription
	  {
		  get
		  {
			  return this.moreDescription;
		  }
		  set
		  {
			  this.moreDescription = value;
		  }
	  }


	  public virtual IList<string> MoreSecondDescription
	  {
		  get
		  {
			  return this.moreSecondDescription;
		  }
		  set
		  {
			  this.moreSecondDescription = value;
		  }
	  }


	  public virtual int Index
	  {
		  get
		  {
			  return this.index;
		  }
		  set
		  {
			  this.index = value;
		  }
	  }


	  public virtual string Notes
	  {
		  get
		  {
			  return this.notes;
		  }
		  set
		  {
			  this.notes = value;
		  }
	  }


	  public virtual string makeShortTitle()
	  {
		null = Description;
		if (!string.ReferenceEquals(this.secondDescription, null) && this.secondDescription.Length < null.length())
		{
		  null = this.secondDescription;
		}
		string str = "";
		foreach (string str1 in this.moreDescription)
		{
		  if (str1.IndexOf("NOTE", StringComparison.Ordinal) != -1)
		  {
			continue;
		  }
		  str = str + str1;
		}
		if (!str.Equals(""))
		{
		  string str1 = StringUtils.makeShortTitle(str, ";", 70);
		  if (str1.EndsWith("...", StringComparison.Ordinal))
		  {
			str1 = StringUtils.makeShortTitle(str, " ", 70);
		  }
		  null = str1 + "; " + null;
		}
		return StringUtils.makeShortTitle(null, " ", 140);
	  }

	  public virtual string makeFullDescription()
	  {
		string str1 = this.description;
		if (!string.ReferenceEquals(this.secondDescription, null) && this.secondDescription.Length > str1.Length)
		{
		  str1 = this.secondDescription;
		}
		string str2 = "";
		foreach (string str in this.moreDescription)
		{
		  str2 = str2 + str;
		}
		if (!str2.Equals(""))
		{
		  str1 = str2 + "; " + str1;
		}
		if (!string.ReferenceEquals(Notes, null) && !Notes.Equals(""))
		{
		  str1 = str1 + "\n" + Notes;
		}
		if (Level > 2)
		{
		  DefaultMutableTreeNode defaultMutableTreeNode = (DefaultMutableTreeNode)Parent.Parent;
		  if (!defaultMutableTreeNode.Root)
		  {
			SponLineItem sponLineItem = (SponLineItem)Parent.Parent;
			str1 = str1 + "\n\nCATEGORY DESCRIPTION: " + sponLineItem.Description;
		  }
		}
		return str1;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\spon\SponLineItem.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}