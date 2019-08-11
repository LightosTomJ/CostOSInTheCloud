using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim
{
	using IfcElementTable = nomitech.common.db.project.IfcElementTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using StringUtils = nomitech.common.util.StringUtils;
	using BIMProperty = nomitech.ifcengine.props.BIMProperty;
	using BIMPropertySet = nomitech.ifcengine.props.BIMPropertySet;

	public abstract class BIMElement : BIMProduct
	{
	  private static readonly Color SELECTION_COLOR = Color.GREEN;

	  private static readonly Color ALTERNATIVE_TO_SELECTION_COLOR = new Color(125, 150, 125);

	  private long? id;

	  private DateTime lastUpdate;

	  private string name;

	  private string label;

	  private string groupType;

	  private Color color;

	  private double transparency = 0.0D;

	  private double qty1;

	  private string uom1;

	  private string qtyName1;

	  private double qty2;

	  private string uom2;

	  private string qtyName2;

	  private double qty3;

	  private string uom3;

	  private string qtyName3;

	  private double qtyF;

	  private string uomF;

	  private string qtyNameF;

	  private string title;

	  private string description;

	  private IList<BIMPropertySet> extensionProperties;

	  private BIMBuildingStorey storey;

	  private BIMGeometry geometryArray;

	  private Transform3D transform3D;

	  public virtual BIMGeometry BIMGeometry
	  {
		  get
		  {
			  return this.geometryArray;
		  }
		  set
		  {
			  this.geometryArray = value;
		  }
	  }


	  public virtual Transform3D Transform3D
	  {
		  get
		  {
			  return this.transform3D;
		  }
		  set
		  {
			  this.transform3D = value;
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


	  public virtual string GroupType
	  {
		  get
		  {
			  return this.groupType;
		  }
		  set
		  {
			  this.groupType = value;
		  }
	  }


	  public virtual BIMBuildingStorey Storey
	  {
		  get
		  {
			  return this.storey;
		  }
		  set
		  {
			  this.storey = value;
		  }
	  }


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


	  public virtual DateTime LastUpdate
	  {
		  get
		  {
			  return this.lastUpdate;
		  }
		  set
		  {
			  this.lastUpdate = value;
		  }
	  }


	  public virtual Color Color
	  {
		  get
		  {
			  return this.color;
		  }
		  set
		  {
			if (value.Equals(SELECTION_COLOR) || isCloseToGreen(value))
			{
			  this.color = ALTERNATIVE_TO_SELECTION_COLOR;
			}
			else
			{
			  this.color = value;
			}
		  }
	  }


	  private bool isCloseToGreen(Color paramColor)
	  {
		if (paramColor.Red < paramColor.Green && paramColor.Blue < paramColor.Green)
		{
		  int i = paramColor.Green - paramColor.Red;
		  int j = paramColor.Green - paramColor.Blue;
		  if (i > 80 && j > 80)
		  {
			return true;
		  }
		}
		return false;
	  }

	  public virtual double Qty1
	  {
		  get
		  {
			  return this.qty1;
		  }
		  set
		  {
			  this.qty1 = value;
		  }
	  }


	  public virtual string Uom1
	  {
		  get
		  {
			  return this.uom1;
		  }
		  set
		  {
			  this.uom1 = value;
		  }
	  }


	  public virtual double Qty2
	  {
		  get
		  {
			  return this.qty2;
		  }
		  set
		  {
			  this.qty2 = value;
		  }
	  }


	  public virtual string Uom2
	  {
		  get
		  {
			  return this.uom2;
		  }
		  set
		  {
			  this.uom2 = value;
		  }
	  }


	  public virtual double Qty3
	  {
		  get
		  {
			  return this.qty3;
		  }
		  set
		  {
			  this.qty3 = value;
		  }
	  }


	  public virtual string Uom3
	  {
		  get
		  {
			  return this.uom3;
		  }
		  set
		  {
			  this.uom3 = value;
		  }
	  }


	  public virtual string Title
	  {
		  get
		  {
			  return this.title;
		  }
		  set
		  {
			  this.title = value;
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


	  public override string ToString()
	  {
		  return Name;
	  }

	  public virtual IList<BIMPropertySet> ExtensionProperties
	  {
		  get
		  {
			  return this.extensionProperties;
		  }
		  set
		  {
			  this.extensionProperties = value;
		  }
	  }


	  public virtual BIMProperty findExtensionProperty(string paramString1, string paramString2)
	  {
		if (this.extensionProperties == null)
		{
		  return null;
		}
		foreach (BIMPropertySet bIMPropertySet in this.extensionProperties)
		{
		  if (!string.ReferenceEquals(paramString1, null) && !bIMPropertySet.Name.Equals(paramString1))
		  {
			continue;
		  }
		  foreach (BIMProperty bIMProperty in bIMPropertySet.Properties)
		  {
			if (bIMProperty.Name.Equals(paramString2))
			{
			  return bIMProperty;
			}
		  }
		}
		return null;
	  }

	  public virtual BIMProperty findExtensionProperty(string paramString)
	  {
		if (this.extensionProperties == null)
		{
		  return null;
		}
		foreach (BIMPropertySet bIMPropertySet in this.extensionProperties)
		{
		  foreach (BIMProperty bIMProperty in bIMPropertySet.Properties)
		  {
			if (bIMProperty.Name.Equals(paramString))
			{
			  return bIMProperty;
			}
		  }
		}
		return null;
	  }

	  public virtual BIMProperty findBaseQuantity(string paramString)
	  {
		  return findExtensionProperty("BaseQuantities", paramString);
	  }

	  public virtual double Transparency
	  {
		  get
		  {
			  return this.transparency;
		  }
		  set
		  {
			  this.transparency = value;
		  }
	  }


	  public virtual string QtyName1
	  {
		  get
		  {
			  return this.qtyName1;
		  }
		  set
		  {
			  this.qtyName1 = value;
		  }
	  }


	  public virtual string QtyName2
	  {
		  get
		  {
			  return this.qtyName2;
		  }
		  set
		  {
			  this.qtyName2 = value;
		  }
	  }


	  public virtual string QtyName3
	  {
		  get
		  {
			  return this.qtyName3;
		  }
		  set
		  {
			  this.qtyName3 = value;
		  }
	  }


	  public virtual double QtyF
	  {
		  get
		  {
			  return this.qtyF;
		  }
		  set
		  {
			  this.qtyF = value;
		  }
	  }


	  public virtual string UomF
	  {
		  get
		  {
			  return this.uomF;
		  }
		  set
		  {
			  this.uomF = value;
		  }
	  }


	  public virtual string QtyNameF
	  {
		  get
		  {
			  return this.qtyNameF;
		  }
		  set
		  {
			  this.qtyNameF = value;
		  }
	  }


	  public virtual string Label
	  {
		  get
		  {
			  return this.label;
		  }
		  set
		  {
			  this.label = value;
		  }
	  }


	  public virtual IfcElementTable convertToIfcElementTable()
	  {
		IfcElementTable ifcElementTable = new IfcElementTable();
		ifcElementTable.IsDecomposed = Convert.ToBoolean(false);
		if (string.ReferenceEquals(Title, null))
		{
		  ifcElementTable.Title = "";
		}
		else
		{
		  ifcElementTable.Title = StringUtils.makeShortTitle(Title, 255);
		}
		if (string.ReferenceEquals(Description, null))
		{
		  ifcElementTable.Description = "";
		}
		else
		{
		  ifcElementTable.Description = StringUtils.makeShortTitle(Description, 255);
		}
		ifcElementTable.Label = Label;
		ifcElementTable.Transparency = ifcElementTable.Transparency;
		ifcElementTable.GlobalId = GlobalId;
		ifcElementTable.ObjectType = GroupType;
		ifcElementTable.TopElevation = new BigDecimalFixed(TopElevation);
		ifcElementTable.BottomElevation = new BigDecimalFixed(BottomElevation);
		ifcElementTable.LastUpdate = LastUpdate;
		ifcElementTable.Qty1 = new BigDecimalFixed(Qty1);
		ifcElementTable.Qty2 = new BigDecimalFixed(Qty2);
		ifcElementTable.Qty3 = new BigDecimalFixed(Qty3);
		ifcElementTable.QtyName1 = QtyName1;
		ifcElementTable.QtyName2 = QtyName2;
		ifcElementTable.QtyName3 = QtyName3;
		ifcElementTable.Uom1 = Uom1;
		ifcElementTable.Uom2 = Uom2;
		ifcElementTable.Uom3 = Uom3;
		return ifcElementTable;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMElement.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}