using System;
using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common.bim.bimengine.impl
{
	using ModelTable = nomitech.bimengine.model.data.ModelTable;

	public class BEBIMModel : BIMModel
	{
	  private long? modelId;

	  private string revision;

	  public BEBIMModel()
	  {
	  }

	  public BEBIMModel(ModelTable paramModelTable)
	  {
		ApplicationName = paramModelTable.ApplicationName;
		DisplayName = paramModelTable.Project.Code + " " + paramModelTable.Name;
		ShortName = paramModelTable.Name;
		Name = paramModelTable.Name;
		FileName = Path.GetFileName(paramModelTable.FilePath);
		ModelId = paramModelTable.Id;
		Revision = paramModelTable.Revision;
		Groups = new LinkedList();
		Sites = new LinkedList();
		Buildings = new LinkedList();
		Id = paramModelTable.Id;
		this.offsetZ = (this.offsetY = (this.offsetX = (this.vertexConversionFactor = Convert.ToDouble((paramModelTable.VertexConversionFactor == null) ? 1.0D : paramModelTable.VertexConversionFactor.doubleValue())).valueOf((paramModelTable.OffsetX == null) ? 0.0D : paramModelTable.OffsetX.doubleValue())).valueOf((paramModelTable.OffsetY == null) ? 0.0D : paramModelTable.OffsetY.doubleValue())).valueOf((paramModelTable.OffsetZ == null) ? 0.0D : paramModelTable.OffsetZ.doubleValue());
	  }

	  public virtual long? ModelId
	  {
		  get
		  {
			  return this.modelId;
		  }
		  set
		  {
			  this.modelId = value;
		  }
	  }


	  public virtual string Revision
	  {
		  get
		  {
			  return this.revision;
		  }
		  set
		  {
			  this.revision = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\bimengine\impl\BEBIMModel.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}