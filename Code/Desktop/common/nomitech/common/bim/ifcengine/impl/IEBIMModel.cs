using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.bim.ifcengine.impl
{
	using ModelTable  = Desktop.common.nomitech..bimengine.model.data.ModelTable;

	public class IEBIMModel : BIMModel
	{
	  private long? id;

	  public IEBIMModel(ModelTable paramModelTable, File paramFile)
	  {
		ApplicationName = paramModelTable.ApplicationName;
		string str = removeExtension(paramFile.Name);
		Name = str;
		ShortName = str;
		DisplayName = removeExtension(paramFile.Name);
		FileName = paramFile.Name;
		Buildings = new List<object>();
		Groups = new List<object>();
		Sites = new List<object>();
		Id = Convert.ToInt64(DateTimeHelper.CurrentUnixTimeMillis() / 2L);
		this.offsetZ = (this.offsetY = (this.offsetX = (this.vertexConversionFactor = Convert.ToDouble((paramModelTable.VertexConversionFactor == null) ? 1.0D : paramModelTable.VertexConversionFactor.doubleValue())).valueOf((paramModelTable.OffsetX == null) ? 0.0D : paramModelTable.OffsetX.doubleValue())).valueOf((paramModelTable.OffsetY == null) ? 0.0D : paramModelTable.OffsetY.doubleValue())).valueOf((paramModelTable.OffsetZ == null) ? 0.0D : paramModelTable.OffsetZ.doubleValue());
	  }

	  public override long? Id
	  {
		  get
		  {
			  return this.id;
		  }
	  }

	  public static string removeExtension(string paramString)
	  {
		if (string.ReferenceEquals(paramString, null))
		{
		  return null;
		}
		int i = indexOfExtension(paramString);
		return (i == -1) ? paramString : paramString.Substring(0, i);
	  }

	  public static int indexOfExtension(string paramString)
	  {
		if (string.ReferenceEquals(paramString, null))
		{
		  return -1;
		}
		int i = paramString.LastIndexOf('.');
		int j = indexOfLastSeparator(paramString);
		return (j > i) ? -1 : i;
	  }

	  public static int indexOfLastSeparator(string paramString)
	  {
		if (string.ReferenceEquals(paramString, null))
		{
		  return -1;
		}
		int i = paramString.LastIndexOf('/');
		int j = paramString.LastIndexOf('\\');
		return Math.Max(i, j);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\ifcengine\impl\IEBIMModel.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}