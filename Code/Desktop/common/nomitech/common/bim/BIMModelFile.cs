using System;

namespace Desktop.common.nomitech.common.bim
{

	public class BIMModelFile : IComparable
	{
	  private long? modelId;

	  private File filePath;

	  public BIMModelFile(long? paramLong)
	  {
		  this.modelId = paramLong;
	  }

	  public BIMModelFile(File paramFile)
	  {
		  this.filePath = paramFile;
	  }

	  public virtual long? ModelId
	  {
		  get
		  {
			  return this.modelId;
		  }
	  }

	  public virtual File FilePath
	  {
		  get
		  {
			  return this.filePath;
		  }
	  }

	  public virtual bool LocalFile
	  {
		  get
		  {
			  return (this.filePath != null);
		  }
	  }

	  public virtual string Identity
	  {
		  get
		  {
			  return LocalFile ? FilePath.AbsolutePath : ("" + this.modelId);
		  }
	  }

	  public override bool Equals(object paramObject)
	  {
		if (paramObject is BIMModelFile)
		{
		  BIMModelFile bIMModelFile = (BIMModelFile)paramObject;
		  if (bIMModelFile.LocalFile && LocalFile)
		  {
			return bIMModelFile.FilePath.AbsoluteFile.Equals(FilePath.AbsoluteFile);
		  }
		  if (!bIMModelFile.LocalFile && !LocalFile)
		  {
			return (bIMModelFile.ModelId.Value == ModelId.Value);
		  }
		}
		return false;
	  }

	  public virtual string Name
	  {
		  get
		  {
			  return LocalFile ? FilePath.Name : ("BIM-Model: " + ModelId);
		  }
	  }

	  public override string ToString()
	  {
		  return Name;
	  }

	  public virtual string TakeOffType
	  {
		  get
		  {
			  return LocalFile ? "IFC File" : "BIM";
		  }
	  }

	  public virtual int CompareTo(object paramObject)
	  {
		if (paramObject.Equals(this))
		{
		  return 0;
		}
		if (paramObject is BIMModelFile)
		{
		  BIMModelFile bIMModelFile = (BIMModelFile)paramObject;
		  return ((BIMModelFile)paramObject).Name.CompareTo(Name);
		}
		return -1;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMModelFile.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}