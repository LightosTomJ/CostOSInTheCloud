namespace Desktop.common.nomitech.common.management
{
	public interface ServiceMBean : ServiceLifecycle
	{

	  int State {get;}

	  string Name {get;}

	  string StateString {get;}
	}

	public static class ServiceMBean_Fields
	{
	  public static readonly string[] states = new string[] {"Stopped", "Stopping", "Starting", "Started", "Failed", "Destroyed"};
	  public const int STOPPED = 0;
	  public const int STOPPING = 1;
	  public const int STARTING = 2;
	  public const int STARTED = 3;
	  public const int FAILED = 4;
	  public const int DESTROYED = 5;
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\management\ServiceMBean.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}