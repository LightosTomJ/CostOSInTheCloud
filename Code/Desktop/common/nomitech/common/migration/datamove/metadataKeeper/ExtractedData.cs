using System.Text;

namespace Desktop.common.nomitech.common.migration.datamove.metadataKeeper
{
	using Column = org.hibernate.mapping.Column;

	public class ExtractedData
	{
	  internal BaseEntityMetadataKeeper owner;

	  internal object[] dataValues;

	  internal ExtractedFKData[] fkValues;

	  public ExtractedData(BaseEntityMetadataKeeper paramBaseEntityMetadataKeeper)
	  {
		  this.owner = paramBaseEntityMetadataKeeper;
	  }

	  public virtual object[] DataValues
	  {
		  get
		  {
			  return this.dataValues;
		  }
		  set
		  {
			  this.dataValues = value;
		  }
	  }


	  public virtual ExtractedFKData[] FkValues
	  {
		  get
		  {
			  return this.fkValues;
		  }
		  set
		  {
			  this.fkValues = value;
		  }
	  }


	  public override string ToString()
	  {
		StringBuilder stringBuilder = new StringBuilder();
		if (this.dataValues != null)
		{
		  for (sbyte b = 0; b < this.dataValues.Length; b++)
		  {
			stringBuilder.Append(((Column)this.owner.columns[b]).Name).Append(":").Append(this.dataValues[b]);
		  }
		}
		return stringBuilder.ToString();
	  }

	  public class ExtractedFKData
	  {
		internal object[] dataValues;

		public virtual object[] DataValues
		{
			get
			{
				return this.dataValues;
			}
			set
			{
				this.dataValues = value;
			}
		}

	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\metadataKeeper\ExtractedData.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}