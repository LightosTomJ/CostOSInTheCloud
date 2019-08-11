using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim
{
	using IfcElementTable = nomitech.common.db.project.IfcElementTable;

	public abstract class BIMBuildingElement : BIMElement
	{
	  private string type;

	  private string material;

	  private string layer;

	  private bool plumbing = false;

	  private bool architecture = false;

	  private bool landscaping = false;

	  private bool airconditioning = false;

	  private bool heating = false;

	  private bool electrical = false;

	  private bool sprinkler = false;

	  private bool structural = false;

	  private bool ventilation = false;

	  private IList<BIMBuildingElement> decomposedElements;

	  private IList<BIMBuildingElement> connectedElements;

	  private IList<BIMGroup> bimGroup;

	  private BIMBuildingElement parent;

	  private BIMSpatialElement parentSpace;

	  private string materialAndTypeConcat = null;

	  public virtual string Type
	  {
		  get
		  {
			  return this.type;
		  }
		  set
		  {
			  this.type = value;
		  }
	  }


	  public virtual string Material
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


	  public virtual BIMBuildingElement ParentComposition
	  {
		  get
		  {
			  return this.parent;
		  }
		  set
		  {
			  this.parent = value;
		  }
	  }


	  public virtual string Layer
	  {
		  get
		  {
			  return this.layer;
		  }
		  set
		  {
			  this.layer = value;
		  }
	  }


	  public virtual bool Plumbing
	  {
		  get
		  {
			  return this.plumbing;
		  }
		  set
		  {
			  this.plumbing = value;
		  }
	  }


	  public virtual bool Architecture
	  {
		  get
		  {
			  return this.architecture;
		  }
		  set
		  {
			  this.architecture = value;
		  }
	  }


	  public virtual bool Landscaping
	  {
		  get
		  {
			  return this.landscaping;
		  }
		  set
		  {
			  this.landscaping = value;
		  }
	  }


	  public virtual bool Airconditioning
	  {
		  get
		  {
			  return this.airconditioning;
		  }
		  set
		  {
			  this.airconditioning = value;
		  }
	  }


	  public virtual bool Heating
	  {
		  get
		  {
			  return this.heating;
		  }
		  set
		  {
			  this.heating = value;
		  }
	  }


	  public virtual bool Electrical
	  {
		  get
		  {
			  return this.electrical;
		  }
		  set
		  {
			  this.electrical = value;
		  }
	  }


	  public virtual bool Sprinkler
	  {
		  get
		  {
			  return this.sprinkler;
		  }
		  set
		  {
			  this.sprinkler = value;
		  }
	  }


	  public virtual bool Structural
	  {
		  get
		  {
			  return this.structural;
		  }
		  set
		  {
			  this.structural = value;
		  }
	  }


	  public virtual bool Ventilation
	  {
		  get
		  {
			  return this.ventilation;
		  }
		  set
		  {
			  this.ventilation = value;
		  }
	  }


	  private string constructMaterialAndTypeConcat()
	  {
		  return (string.ReferenceEquals(this.type, null) && string.ReferenceEquals(this.material, null)) ? null : ((string.ReferenceEquals(this.type, null)) ? this.material : ((string.ReferenceEquals(this.material, null)) ? this.type : ((this.type.Equals("") && this.material.Equals("")) ? null : (this.type.Equals("") ? this.material : ((this.material.IndexOf(this.type, StringComparison.Ordinal) != -1) ? this.material : ((this.type.IndexOf(this.material, StringComparison.Ordinal) != -1) ? this.type : (this.material + ", " + this.type)))))));
	  }

	  public virtual string MaterialAndTypeConcat
	  {
		  get
		  {
			if (!string.ReferenceEquals(this.materialAndTypeConcat, null))
			{
			  return this.materialAndTypeConcat;
			}
			this.materialAndTypeConcat = constructMaterialAndTypeConcat();
			return this.materialAndTypeConcat;
		  }
	  }

	  public virtual IList<BIMBuildingElement> DecomposedElements
	  {
		  get
		  {
			  return this.decomposedElements;
		  }
		  set
		  {
			  this.decomposedElements = value;
		  }
	  }


	  public virtual IList<BIMGroup> BimGroup
	  {
		  get
		  {
			  return this.bimGroup;
		  }
		  set
		  {
			  this.bimGroup = value;
		  }
	  }


	  public virtual BIMSpatialElement ParentSpace
	  {
		  get
		  {
			  return this.parentSpace;
		  }
		  set
		  {
			  this.parentSpace = value;
		  }
	  }


	  public virtual IList<BIMBuildingElement> DecomposedElementsDeeply
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			if (DecomposedElements != null)
			{
			  foreach (BIMBuildingElement bIMBuildingElement in DecomposedElements)
			  {
				arrayList.Add(bIMBuildingElement);
				arrayList.AddRange(bIMBuildingElement.DecomposedElementsDeeply);
			  }
			}
			return arrayList;
		  }
	  }

	  public virtual IList<BIMBuildingElement> ConnectedElements
	  {
		  get
		  {
			  return this.connectedElements;
		  }
		  set
		  {
			  this.connectedElements = value;
		  }
	  }


	  private void processPipelineConnectedElements(IList<BIMBuildingElement> paramList)
	  {
		if (ConnectedElements == null)
		{
		  return;
		}
		foreach (BIMBuildingElement bIMBuildingElement in ConnectedElements)
		{
		  if (!paramList.Contains(bIMBuildingElement))
		  {
			paramList.Add(bIMBuildingElement);
			bIMBuildingElement.processPipelineConnectedElements(paramList);
		  }
		}
	  }

	  public virtual ICollection<BIMBuildingElement> PipelineConnectedElements
	  {
		  get
		  {
			LinkedList linkedList = new LinkedList();
			if (ConnectedElements == null)
			{
			  return linkedList;
			}
			foreach (BIMBuildingElement bIMBuildingElement in ConnectedElements)
			{
			  linkedList.AddLast(bIMBuildingElement);
			  bIMBuildingElement.processPipelineConnectedElements(linkedList);
			}
			return linkedList;
		  }
	  }

	  public override IfcElementTable convertToIfcElementTable()
	  {
		IfcElementTable ifcElementTable = base.convertToIfcElementTable();
		bool @bool = (DecomposedElements != null && DecomposedElements.Count > 0);
		ifcElementTable.IsDecomposed = Convert.ToBoolean(@bool);
		if (ParentComposition != null)
		{
		  ifcElementTable.ParentElementId = ParentComposition.GlobalId;
		}
		ifcElementTable.Material = Material;
		ifcElementTable.Type = Type;
		ifcElementTable.Layer = Layer;
		return ifcElementTable;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMBuildingElement.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}