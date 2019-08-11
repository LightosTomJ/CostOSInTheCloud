namespace Desktop.common.nomitech.common.bim
{
	public class BIMElementWithModel
	{
	  private BIMModel model;

	  private BIMElement element;

	  public BIMElementWithModel(BIMModel paramBIMModel, BIMElement paramBIMElement)
	  {
		this.model = paramBIMModel;
		this.element = paramBIMElement;
	  }

	  public virtual BIMModel Model
	  {
		  get
		  {
			  return this.model;
		  }
		  set
		  {
			  this.model = value;
		  }
	  }


	  public virtual BIMElement Element
	  {
		  get
		  {
			  return this.element;
		  }
		  set
		  {
			  this.element = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\bim\BIMElementWithModel.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}