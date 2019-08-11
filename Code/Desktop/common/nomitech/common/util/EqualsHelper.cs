namespace Desktop.common.nomitech.common.util
{
	public sealed class EqualsHelper
	{
	  public static bool Equals(object paramObject1, object paramObject2)
	  {
		  return (paramObject1 == paramObject2 || (paramObject1 != null && paramObject2 != null && paramObject1.Equals(paramObject2)));
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\EqualsHelper.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}