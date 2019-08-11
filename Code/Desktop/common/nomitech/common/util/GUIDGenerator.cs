using System;
using System.Text;

namespace Desktop.common.nomitech.common.util
{

	public class GUIDGenerator
	{
	  private static string s_bytes = null;

	  private static SecureRandom s_rand = new SecureRandom();

	  private static string hexFormat(int paramInt)
	  {
		string str = paramInt.ToString("x");
		StringBuilder stringBuffer = new StringBuilder(8);
		for (int i = str.Length; i < 8; i++)
		{
		  stringBuffer.Append('0');
		}
		return stringBuffer + str;
	  }

	  private static string rowIpToHex(sbyte[] paramArrayOfByte)
	  {
		string str = "";
		for (sbyte b = 0; b < paramArrayOfByte.Length; b++)
		{
		  str = str + (paramArrayOfByte[b] & 0xFF).ToString("x");
		}
		return str;
	  }

	  private static string getUUIDMiddleValue(object paramObject)
	  {
		if (string.ReferenceEquals(s_bytes, null))
		{
		  try
		  {
			InetAddress inetAddress = InetAddress.LocalHost;
			sbyte[] arrayOfByte = inetAddress.Address;
			s_bytes = rowIpToHex(arrayOfByte);
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
		  }
		}
		return s_bytes + hexFormat(System.identityHashCode(paramObject));
	  }

	  public static string makeGUID(object paramObject)
	  {
		  return hexFormat((int)DateTimeHelper.CurrentUnixTimeMillis() & 0xFFFFFF) + getUUIDMiddleValue(paramObject) + hexFormat(s_rand.Next());
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\GUIDGenerator.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}