using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.util
{

	public class CryptUtil
	{
	  private static CryptUtil s_instance = null;

	  private static readonly sbyte[] DEFAULT_KEY = new sbyte[] {1, -29, -94, 24, 87, -67, -104, -84};

	  private SecretKeySpec keySpec;

	  private sbyte[] key;

	  private string algorithm;

	  public CryptUtil(sbyte[] paramArrayOfByte, string paramString)
	  {
		this.key = paramArrayOfByte;
		this.algorithm = paramString;
		this.keySpec = new SecretKeySpec(this.key, this.algorithm);
	  }

	  public virtual sbyte[] encryptString(string paramString)
	  {
		try
		{
		  Cipher cipher = Cipher.getInstance(this.algorithm);
		  cipher.init(1, this.keySpec);
		  return cipher.doFinal(paramString.GetBytes());
		}
		catch (Exception)
		{
		  return null;
		}
	  }

	  public virtual string decryptString(sbyte[] paramArrayOfByte)
	  {
		try
		{
		  Cipher cipher = Cipher.getInstance(this.algorithm);
		  cipher.init(2, this.keySpec);
		  return new string(cipher.doFinal(paramArrayOfByte));
		}
		catch (Exception)
		{
		  return null;
		}
	  }

	  public virtual string encryptHexString(string paramString)
	  {
		  return toHex(encryptString(paramString));
	  }

	  public virtual string decryptHexString(string paramString)
	  {
		  return (string.ReferenceEquals(paramString, null)) ? "" : decryptString(toByteArray(paramString));
	  }

	  private string toHex(sbyte[] paramArrayOfByte)
	  {
		string str = "";
		for (sbyte b = 0; b < paramArrayOfByte.Length; b++)
		{
		  sbyte b1 = paramArrayOfByte[b];
		  if (b1 < 0)
		  {
			str = str + "-";
			b1 = -b1;
		  }
		  if (b1 < 16)
		  {
			str = str + "0";
		  }
		  str = str + b1.ToString("x").ToUpper();
		}
		return str;
	  }

	  private sbyte[] toByteArray(string paramString)
	  {
		List<object> vector = new List<object>();
		sbyte b1 = 0;
		sbyte b2 = 0;
		while (b1 < paramString.Length)
		{
		  b2 = paramString.Substring(b1, true).Equals("-") ? 3 : 2;
		  string str = paramString.Substring(b1, b2);
		  b1 += b2;
		  int i = Convert.ToInt32(str, 16);
		  vector.Add(new sbyte?((sbyte)i));
		}
		if (vector.Count > 0)
		{
		  sbyte[] arrayOfByte = new sbyte[vector.Count];
		  for (sbyte b = 0; b < vector.Count; b++)
		  {
			sbyte? byte = (sbyte?)vector[b];
			arrayOfByte[b] = byte.Value;
		  }
		  return arrayOfByte;
		}
		return null;
	  }

	  public static CryptUtil Instance
	  {
		  get
		  {
			if (s_instance == null)
			{
			  s_instance = new CryptUtil(DEFAULT_KEY, "DES");
			}
			return s_instance;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\CryptUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}