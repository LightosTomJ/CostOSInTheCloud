using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim
{
	using StringUtils = nomitech.common.util.StringUtils;

	public abstract class BIMModel
	{
		private bool InstanceFieldsInitialized = false;

		public BIMModel()
		{
			if (!InstanceFieldsInitialized)
			{
				InitializeInstanceFields();
				InstanceFieldsInitialized = true;
			}
		}

		private void InitializeInstanceFields()
		{
			offsetZ = (this.offsetY = (this.offsetX = (this.vertexConversionFactor = Convert.ToDouble(1.0D)).valueOf(0.0D)).valueOf(0.0D)).valueOf(0.0D);
		}

	  private string name;

	  private string displayName;

	  private string shortName;

	  private string applicationName;

	  private string fileName;

	  private BIMModelFile ifcFile;

	  private IList<BIMBuilding> buildings;

	  private IList<BIMGroup> groups;

	  private IList<BIMSite> sites;

	  private IDictionary<string, BIMElement> elementMap = new Hashtable();

	  protected internal double? vertexConversionFactor;

	  protected internal double? offsetX;

	  protected internal double? offsetY;

	  protected internal double? offsetZ;

	  private long? id;

	  public virtual long? Id
	  {
		  get
		  {
			  return this.id;
		  }
		  set
		  {
			  this.id = value;
		  }
	  }


	  public virtual double? VertexConversionFactor
	  {
		  get
		  {
			  return this.vertexConversionFactor;
		  }
	  }

	  public virtual double? OffsetX
	  {
		  get
		  {
			  return this.offsetX;
		  }
	  }

	  public virtual double? OffsetY
	  {
		  get
		  {
			  return this.offsetY;
		  }
	  }

	  public virtual double? OffsetZ
	  {
		  get
		  {
			  return this.offsetZ;
		  }
	  }

	  public virtual string Name
	  {
		  get
		  {
			  return this.name;
		  }
		  set
		  {
			  this.name = value;
		  }
	  }


	  public virtual string ShortName
	  {
		  get
		  {
			  return this.shortName;
		  }
		  set
		  {
			  this.shortName = value;
		  }
	  }


	  public virtual string ApplicationName
	  {
		  get
		  {
			  return this.applicationName;
		  }
		  set
		  {
			  this.applicationName = value;
		  }
	  }


	  public virtual IList<BIMBuilding> Buildings
	  {
		  get
		  {
			  return this.buildings;
		  }
		  set
		  {
			  this.buildings = value;
		  }
	  }


	  public virtual string DisplayName
	  {
		  get
		  {
			  return this.displayName;
		  }
		  set
		  {
			  this.displayName = value;
		  }
	  }


	  public virtual string FileName
	  {
		  get
		  {
			  return this.fileName;
		  }
		  set
		  {
			this.fileName = value;
			if (this.id == null)
			{
			  this.id = StringUtils.textToLong(value);
			}
		  }
	  }


	  public override string ToString()
	  {
		  return (this.displayName.Length > 0 && !this.displayName.Equals("untitled", StringComparison.OrdinalIgnoreCase)) ? this.displayName : this.fileName;
	  }

	  public virtual IDictionary<string, BIMElement> GlobalIdToElementMap
	  {
		  get
		  {
			if (this.elementMap.Count == 0)
			{
			  constructGlobalIdToElementMap();
			}
			return this.elementMap;
		  }
	  }

	  public virtual IDictionary<string, BIMElement> constructGlobalIdToElementMap()
	  {
		this.elementMap.Clear();
		foreach (BIMBuilding bIMBuilding in this.buildings)
		{
		  foreach (BIMBuildingStorey bIMBuildingStorey in bIMBuilding.Storeys)
		  {
			foreach (BIMElement bIMElement in bIMBuildingStorey.Elements)
			{
			  this.elementMap[bIMElement.GlobalId] = bIMElement;
			}
		  }
		}
		return this.elementMap;
	  }

	  public virtual IList<BIMElement> Elements
	  {
		  get
		  {
			LinkedList linkedList = new LinkedList();
			foreach (BIMBuilding bIMBuilding in this.buildings)
			{
			  foreach (BIMBuildingStorey bIMBuildingStorey in bIMBuilding.Storeys)
			  {
				foreach (BIMElement bIMElement in bIMBuildingStorey.Elements)
				{
				  linkedList.AddLast(bIMElement);
				}
			  }
			}
			return linkedList;
		  }
	  }

	  public virtual void sortBuildingList()
	  {
		BIMBuilding[] arrayOfBIMBuilding = (BIMBuilding[])Buildings.ToArray();
		Arrays.sort(arrayOfBIMBuilding, new ComparatorAnonymousInnerClass(this));
		Buildings.Clear();
		foreach (BIMBuilding bIMBuilding in arrayOfBIMBuilding)
		{
		  bIMBuilding.sortStoreys();
		  Buildings.Add(bIMBuilding);
		}
	  }

	  private class ComparatorAnonymousInnerClass : IComparer<BIMBuilding>
	  {
		  private readonly BIMModel outerInstance;

		  public ComparatorAnonymousInnerClass(BIMModel outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public int compare(BIMBuilding param1BIMBuilding1, BIMBuilding param1BIMBuilding2)
		  {
			  return param1BIMBuilding1.Name.CompareTo(param1BIMBuilding2.Name);
		  }
	  }

	  public virtual BIMModelFile IfcFile
	  {
		  get
		  {
			  return this.ifcFile;
		  }
		  set
		  {
			  this.ifcFile = value;
		  }
	  }


	  public virtual IList<BIMGroup> Groups
	  {
		  get
		  {
			  return this.groups;
		  }
		  set
		  {
			  this.groups = value;
		  }
	  }


	  public virtual IList<BIMSite> Sites
	  {
		  get
		  {
			  return this.sites;
		  }
		  set
		  {
			  this.sites = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMModel.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}