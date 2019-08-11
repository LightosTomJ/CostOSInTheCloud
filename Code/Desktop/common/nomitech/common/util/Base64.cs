using System;

namespace Desktop.common.nomitech.common.util
{
	public sealed class Base64
	{
	  public const int NO_OPTIONS = 0;

	  public const int ENCODE = 1;

	  public const int DECODE = 0;

	  public const int DO_BREAK_LINES = 8;

	  public const int URL_SAFE = 16;

	  public const int ORDERED = 32;

	  private const int MAX_LINE_LENGTH = 76;

	  private const sbyte EQUALS_SIGN = 61;

	  private const sbyte NEW_LINE = 10;

	  private const sbyte WHITE_SPACE_ENC = -5;

	  private const sbyte EQUALS_SIGN_ENC = -1;

	  private static readonly sbyte[] _STANDARD_ALPHABET = new sbyte[] {65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 43, 47};

	  private static readonly sbyte[] _STANDARD_DECODABET = new sbyte[] {-9, -9, -9, -9, -9, -9, -9, -9, -9, -5, -5, -9, -9, -5, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -5, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 62, -9, -9, -9, 63, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, -9, -9, -9, -1, -9, -9, -9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, -9, -9, -9, -9, -9, -9, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9};

	  private static readonly sbyte[] _URL_SAFE_ALPHABET = new sbyte[] {65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 45, 95};

	  private static readonly sbyte[] _URL_SAFE_DECODABET = new sbyte[] {-9, -9, -9, -9, -9, -9, -9, -9, -9, -5, -5, -9, -9, -5, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -5, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 62, -9, -9, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, -9, -9, -9, -1, -9, -9, -9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, -9, -9, -9, -9, 63, -9, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9};

	  private static readonly sbyte[] _ORDERED_ALPHABET = new sbyte[] {45, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 95, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122};

	  private static readonly sbyte[] _ORDERED_DECODABET = new sbyte[] {-9, -9, -9, -9, -9, -9, -9, -9, -9, -5, -5, -9, -9, -5, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -5, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, 0, -9, -9, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -9, -9, -9, -1, -9, -9, -9, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, -9, -9, -9, -9, 37, -9, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9};

	  public static sbyte[] decode(sbyte[] paramArrayOfByte)
	  {
		  return decode(paramArrayOfByte, 0, paramArrayOfByte.Length, 0);
	  }

	  public static sbyte[] encode(sbyte[] paramArrayOfByte)
	  {
		  return encodeBytesToBytes(paramArrayOfByte, 0, paramArrayOfByte.Length, 0);
	  }

	  public static bool isBase64(sbyte[] paramArrayOfByte)
	  {
		try
		{
		  decode(paramArrayOfByte);
		}
		catch (InvalidBase64CharacterException)
		{
		  return false;
		}
		return true;
	  }

	  private static sbyte[] getAlphabet(int paramInt)
	  {
		  return ((paramInt & 0x10) == 16) ? _URL_SAFE_ALPHABET : (((paramInt & 0x20) == 32) ? _ORDERED_ALPHABET : _STANDARD_ALPHABET);
	  }

	  private static sbyte[] getDecodabet(int paramInt)
	  {
		  return ((paramInt & 0x10) == 16) ? _URL_SAFE_DECODABET : (((paramInt & 0x20) == 32) ? _ORDERED_DECODABET : _STANDARD_DECODABET);
	  }

	  private static sbyte[] encode3to4(sbyte[] paramArrayOfByte1, int paramInt1, int paramInt2, sbyte[] paramArrayOfByte2, int paramInt3, int paramInt4)
	  {
		sbyte[] arrayOfByte = getAlphabet(paramInt4);
		sbyte b = ((paramInt2 > 0) ? ((int)((uint)paramArrayOfByte1[paramInt1] << 24 >> 8)) : 0) | ((paramInt2 > 1) ? ((int)((uint)paramArrayOfByte1[paramInt1 + 1] << 24 >> 16)) : 0) | ((paramInt2 > 2) ? ((int)((uint)paramArrayOfByte1[paramInt1 + 2] << 24 >> 24)) : 0);
		switch (paramInt2)
		{
		  case 3:
			paramArrayOfByte2[paramInt3] = arrayOfByte[(int)((uint)b >> 18)];
			paramArrayOfByte2[paramInt3 + 1] = arrayOfByte[(int)((uint)b >> 12) & 0x3F];
			paramArrayOfByte2[paramInt3 + 2] = arrayOfByte[(int)((uint)b >> 6) & 0x3F];
			paramArrayOfByte2[paramInt3 + 3] = arrayOfByte[b & 0x3F];
			return paramArrayOfByte2;
		  case 2:
			paramArrayOfByte2[paramInt3] = arrayOfByte[(int)((uint)b >> 18)];
			paramArrayOfByte2[paramInt3 + 1] = arrayOfByte[(int)((uint)b >> 12) & 0x3F];
			paramArrayOfByte2[paramInt3 + 2] = arrayOfByte[(int)((uint)b >> 6) & 0x3F];
			paramArrayOfByte2[paramInt3 + 3] = 61;
			return paramArrayOfByte2;
		  case 1:
			paramArrayOfByte2[paramInt3] = arrayOfByte[(int)((uint)b >> 18)];
			paramArrayOfByte2[paramInt3 + 1] = arrayOfByte[(int)((uint)b >> 12) & 0x3F];
			paramArrayOfByte2[paramInt3 + 2] = 61;
			paramArrayOfByte2[paramInt3 + 3] = 61;
			return paramArrayOfByte2;
		}
		return paramArrayOfByte2;
	  }

	  private static sbyte[] encodeBytesToBytes(sbyte[] paramArrayOfByte, int paramInt1, int paramInt2, int paramInt3)
	  {
		if (paramArrayOfByte == null)
		{
		  throw new System.NullReferenceException("Cannot serialize a null array.");
		}
		if (paramInt1 < 0)
		{
		  throw new System.ArgumentException("Cannot have negative offset: " + paramInt1);
		}
		if (paramInt2 < 0)
		{
		  throw new System.ArgumentException("Cannot have length offset: " + paramInt2);
		}
		if (paramInt1 + paramInt2 > paramArrayOfByte.Length)
		{
		  throw new System.ArgumentException(string.Format("Cannot have offset of {0:D} and length of {1:D} with array of length {2:D}", new object[] {Convert.ToInt32(paramInt1), Convert.ToInt32(paramInt2), Convert.ToInt32(paramArrayOfByte.Length)}));
		}
		bool bool1 = ((paramInt3 & 0x8) > 0) ? 1 : 0;
		int i = paramInt2 / 3 * 4 + ((paramInt2 % 3 > 0) ? 4 : 0);
		if (bool1)
		{
		  i += i / 76;
		}
		sbyte[] arrayOfByte = new sbyte[i];
		int j = 0;
		sbyte b = 0;
		int k = paramInt2 - 2;
		bool bool2 = false;
		while (j < k)
		{
		  encode3to4(paramArrayOfByte, j + paramInt1, 3, arrayOfByte, b, paramInt3);
		  bool2 += true;
		  if (bool1 && bool2 >= 76)
		  {
			arrayOfByte[b + 4] = 10;
			b++;
			bool2 = false;
		  }
		  j += 3;
		  b += 4;
		}
		if (j < paramInt2)
		{
		  encode3to4(paramArrayOfByte, j + paramInt1, paramInt2 - j, arrayOfByte, b, paramInt3);
		  b += 4;
		}
		if (b <= arrayOfByte.Length - 1)
		{
		  sbyte[] arrayOfByte1 = new sbyte[b];
		  Array.Copy(arrayOfByte, 0, arrayOfByte1, 0, b);
		  return arrayOfByte1;
		}
		return arrayOfByte;
	  }

	  private static int decode4to3(sbyte[] paramArrayOfByte1, int paramInt1, sbyte[] paramArrayOfByte2, int paramInt2, int paramInt3)
	  {
		if (paramArrayOfByte1 == null)
		{
		  throw new System.NullReferenceException("Source array was null.");
		}
		if (paramArrayOfByte2 == null)
		{
		  throw new System.NullReferenceException("Destination array was null.");
		}
		if (paramInt1 < 0 || paramInt1 + 3 >= paramArrayOfByte1.Length)
		{
		  throw new System.ArgumentException(string.Format("Source array with length {0:D} cannot have offset of {1:D} and still process four bytes.", new object[] {Convert.ToInt32(paramArrayOfByte1.Length), Convert.ToInt32(paramInt1)}));
		}
		if (paramInt2 < 0 || paramInt2 + 2 >= paramArrayOfByte2.Length)
		{
		  throw new System.ArgumentException(string.Format("Destination array with length {0:D} cannot have offset of {1:D} and still store three bytes.", new object[] {Convert.ToInt32(paramArrayOfByte2.Length), Convert.ToInt32(paramInt2)}));
		}
		sbyte[] arrayOfByte = getDecodabet(paramInt3);
		if (paramArrayOfByte1[paramInt1 + 2] == 61)
		{
		  sbyte b1 = (arrayOfByte[paramArrayOfByte1[paramInt1]] & 0xFF) << 18 | (arrayOfByte[paramArrayOfByte1[paramInt1 + 1]] & 0xFF) << 12;
		  paramArrayOfByte2[paramInt2] = (sbyte)((int)((uint)b1 >> 16));
		  return 1;
		}
		if (paramArrayOfByte1[paramInt1 + 3] == 61)
		{
		  sbyte b1 = (arrayOfByte[paramArrayOfByte1[paramInt1]] & 0xFF) << 18 | (arrayOfByte[paramArrayOfByte1[paramInt1 + 1]] & 0xFF) << 12 | (arrayOfByte[paramArrayOfByte1[paramInt1 + 2]] & 0xFF) << 6;
		  paramArrayOfByte2[paramInt2] = (sbyte)((int)((uint)b1 >> 16));
		  paramArrayOfByte2[paramInt2 + 1] = (sbyte)((int)((uint)b1 >> 8));
		  return 2;
		}
		sbyte b = (arrayOfByte[paramArrayOfByte1[paramInt1]] & unchecked((sbyte)0xFF)) << 18 | (arrayOfByte[paramArrayOfByte1[paramInt1 + 1]] & unchecked((sbyte)0xFF)) << 12 | (arrayOfByte[paramArrayOfByte1[paramInt1 + 2]] & unchecked((sbyte)0xFF)) << 6 | arrayOfByte[paramArrayOfByte1[paramInt1 + 3]] & (sbyte)unchecked((sbyte)0xFF);
		paramArrayOfByte2[paramInt2] = (sbyte)(b >> 16);
		paramArrayOfByte2[paramInt2 + 1] = (sbyte)(b >> 8);
		paramArrayOfByte2[paramInt2 + 2] = (sbyte)b;
		return 3;
	  }

	  private static sbyte[] decode(sbyte[] paramArrayOfByte, int paramInt1, int paramInt2, int paramInt3)
	  {
		if (paramArrayOfByte == null)
		{
		  throw new System.NullReferenceException("Cannot decode null source array.");
		}
		if (paramInt1 < 0 || paramInt1 + paramInt2 > paramArrayOfByte.Length)
		{
		  throw new System.ArgumentException(string.Format("Source array with length {0:D} cannot have offset of {1:D} and process {2:D} bytes.", new object[] {Convert.ToInt32(paramArrayOfByte.Length), Convert.ToInt32(paramInt1), Convert.ToInt32(paramInt2)}));
		}
		if (paramInt2 == 0)
		{
		  return new sbyte[0];
		}
		if (paramInt2 < 4)
		{
		  throw new System.ArgumentException("Base64-encoded string must have at least four characters, but length specified was " + paramInt2);
		}
		sbyte[] arrayOfByte1 = getDecodabet(paramInt3);
		int i = paramInt2 * 3 / 4;
		sbyte[] arrayOfByte2 = new sbyte[i];
		int j = 0;
		sbyte[] arrayOfByte3 = new sbyte[4];
		sbyte b = 0;
		int k = 0;
		sbyte b1 = 0;
		for (k = paramInt1; k < paramInt1 + paramInt2; k++)
		{
		  b1 = arrayOfByte1[paramArrayOfByte[k] & 0xFF];
		  if (b1 >= -5)
		  {
			if (b1 >= -1)
			{
			  arrayOfByte3[b++] = paramArrayOfByte[k];
			  if (b > 3)
			  {
				j += decode4to3(arrayOfByte3, 0, arrayOfByte2, j, paramInt3);
				b = 0;
				if (paramArrayOfByte[k] == 61)
				{
				  break;
				}
			  }
			}
		  }
		  else
		  {
			throw new InvalidBase64CharacterException(string.Format("Bad Base64 input character decimal {0:D} in array position {1:D}", new object[] {Convert.ToInt32(paramArrayOfByte[k] & 0xFF), Convert.ToInt32(k)}));
		  }
		}
		sbyte[] arrayOfByte4 = new sbyte[j];
		Array.Copy(arrayOfByte2, 0, arrayOfByte4, 0, j);
		return arrayOfByte4;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\Base64.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}