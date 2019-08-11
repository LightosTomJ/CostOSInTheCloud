namespace Desktop.common.nomitech.common.util
{
	public abstract class ProgressCallback
	{
	  protected internal int o_steps;

	  public virtual int NumProgressSteps
	  {
		  set
		  {
			  this.o_steps = value;
		  }
	  }

	  public virtual void progressStep(string paramString)
	  {
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\ProgressCallback.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}