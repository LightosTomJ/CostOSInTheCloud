using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Desktop.common.nomitech.common.util
{

	public class StringUtils
	{
	  private const long POLY64REV = -2882303761517117440L;

	  private static readonly long[] LOOKUPTABLE = new long[256];

	  private static readonly string[] INVALID_CHARS;

	  private static readonly string[] ALPHABET;

	  private static readonly Pattern regex;

	  public static bool checkValidVariableName(string paramString)
	  {
		  return paramString.matches("^[a-zA-Z][a-zA-Z0-9]*?$");
	  }

	  public static bool isOlderVersionFrom(string paramString1, string paramString2)
	  {
		  return (versionCompare(paramString1, paramString2) < 0);
	  }

	  private static int versionCompare(string paramString1, string paramString2)
	  {
		string[] arrayOfString1 = paramString1.Split("\\.", true);
		string[] arrayOfString2 = paramString2.Split("\\.", true);
		sbyte b;
		for (b = 0; b < arrayOfString1.Length && b < arrayOfString2.Length && arrayOfString1[b].Equals(arrayOfString2[b]); b++)
		{
			;
		}
		return (b < arrayOfString1.Length && b < arrayOfString2.Length) ? Convert.ToInt32(arrayOfString1[b]).compareTo(Convert.ToInt32(arrayOfString2[b])) : (arrayOfString1.Length - arrayOfString2.Length);
	  }

	  public static string convertToValidVariable(string paramString)
	  {
		StringBuilder stringBuilder = new StringBuilder();
		if (!Character.isJavaIdentifierStart(paramString[0]))
		{
		  stringBuilder.Append("_");
		}
		foreach (char c in paramString.ToCharArray())
		{
		  if (!Character.isJavaIdentifierPart(c))
		  {
			stringBuilder.Append("_");
		  }
		  else
		  {
			stringBuilder.Append(c);
		  }
		}
		return stringBuilder.ToString();
	  }

	  public static string replace(string paramString1, string paramString2, string paramString3)
	  {
		if (paramString2.Equals(paramString3))
		{
		  return paramString1;
		}
		if (paramString1.IndexOf(paramString2, StringComparison.Ordinal) == -1)
		{
		  return paramString1;
		}
		int i = paramString1.Length + paramString3.Length;
		StringBuilder stringBuffer = new StringBuilder(i);
		stringBuffer.Append(paramString1);
		int j = paramString1.IndexOf(paramString2, StringComparison.Ordinal);
		int k = j + paramString2.Length;
		stringBuffer.Remove(j, k - j).Insert(j, paramString3);
		return stringBuffer.ToString();
	  }

	  public static string replaceLast(string paramString1, string paramString2, string paramString3)
	  {
		int i = paramString1.LastIndexOf(paramString2, StringComparison.Ordinal);
		return (i > -1) ? (paramString1.Substring(0, i) + paramString3 + StringHelper.SubstringSpecial(paramString1, i + paramString2.Length, paramString1.Length)) : paramString1;
	  }

	  public static string convert8digitCodetoDotit(string paramString)
	  {
		StringBuilder stringBuilder = new StringBuilder();
		string[] arrayOfString = paramString.Split("(?<=\\G..)", true);
		if (arrayOfString.Length != 4)
		{
		  Console.WriteLine("ERR. NOT 8 digits");
		  return paramString;
		}
		for (sbyte b = 0; b < arrayOfString.Length; b++)
		{
		  string str = arrayOfString[b];
		  if (!str.Equals("00"))
		  {
			if (isNotNullNotEmptyNotWhiteSpace(stringBuilder.ToString()))
			{
			  stringBuilder.Append(".");
			}
			stringBuilder.Append(str);
		  }
		}
		Console.WriteLine("new DOTIT CODE: " + paramString + " TO  : " + stringBuilder.ToString());
		return stringBuilder.ToString();
	  }

	  public static bool isNotNullNotEmptyNotWhiteSpace(string paramString)
	  {
		  return (!string.ReferenceEquals(paramString, null) && paramString.Length > 0 && paramString.Trim().Length > 0);
	  }

	  public static bool isEmpty(string paramString)
	  {
		  return (string.ReferenceEquals(paramString, null) || paramString.Length == 0);
	  }

	  private static string replaceAll3(string paramString1, string paramString2, string paramString3, int paramInt)
	  {
		if (isEmpty(paramString1) || isEmpty(paramString2) || string.ReferenceEquals(paramString3, null) || paramInt == 0)
		{
		  return paramString1;
		}
		int i = 0;
		int j = paramString1.IndexOf(paramString2, i, StringComparison.Ordinal);
		if (j == -1)
		{
		  return paramString1;
		}
		int k = paramString2.Length;
		int m = paramString3.Length - k;
		m = (m < 0) ? 0 : m;
		m *= ((paramInt < 0) ? 16 : ((paramInt > 64) ? 64 : paramInt));
		StringBuilder stringBuffer = new StringBuilder(paramString1.Length + m);
		while (j != -1)
		{
		  stringBuffer.Append(paramString1.Substring(i, j - i)).Append(paramString3);
		  i = j + k;
		  if (--paramInt == 0)
		  {
			break;
		  }
		  j = paramString1.IndexOf(paramString2, i, StringComparison.Ordinal);
		}
		stringBuffer.Append(paramString1.Substring(i));
		return stringBuffer.ToString();
	  }

	  public static string removeSpaces(string paramString)
	  {
		  return paramString.replaceAll("\\s+", "");
	  }

	  public static string replaceAll(string paramString1, string paramString2, string paramString3)
	  {
		  return (paramString2.Equals(paramString3) || paramString2.Equals("")) ? paramString1 : ((paramString2.Equals(" ") && paramString3.Equals("")) ? removeSpaces(paramString1) : replaceAll3(paramString1, paramString2, paramString3, -1));
	  }

	  public static string decodeEscapeChars(string paramString)
	  {
		if (string.ReferenceEquals(paramString, null))
		{
		  return null;
		}
		int i = paramString.Length;
		StringBuilder stringBuffer = new StringBuilder(i);
		for (sbyte b = 0; b < i; b++)
		{
		  char c = paramString[b];
		  if (c == '\\')
		  {
			try
			{
			  c = paramString[++b];
			}
			catch (System.IndexOutOfRangeException)
			{
			  throw new System.ArgumentException("cannot match escape character \\ in string: " + paramString);
			}
			switch (c)
			{
			  case 't':
				stringBuffer.Append('\t');
				break;
			  case 'n':
				stringBuffer.Append('\n');
				break;
			  case 'r':
				stringBuffer.Append('\r');
				break;
			  case 'f':
				stringBuffer.Append('\f');
				break;
			  case 'b':
				stringBuffer.Append('\b');
				break;
			  case '\\':
				stringBuffer.Append('\\');
				break;
			  case '\'':
				stringBuffer.Append('\'');
				break;
			  case '"':
				stringBuffer.Append('"');
				break;
			  default:
				throw new System.ArgumentException("escape character missing from string: " + paramString);
			}
		  }
		  else
		  {
			stringBuffer.Append(c);
		  }
		}
		return stringBuffer.ToString();
	  }

	  public static string encodeEscapeChars(string paramString)
	  {
		if (string.ReferenceEquals(paramString, null))
		{
		  return null;
		}
		int i = paramString.Length;
		StringBuilder stringBuffer = new StringBuilder(i * 2);
		for (sbyte b = 0; b < i; b++)
		{
		  char c = paramString[b];
		  switch (c)
		  {
			case '\t':
			  stringBuffer.Append("\\t");
			  break;
			case '\n':
			  stringBuffer.Append("\\n");
			  break;
			case '\r':
			  stringBuffer.Append("\\r");
			  break;
			case '\f':
			  stringBuffer.Append("\\f");
			  break;
			case '\b':
			  stringBuffer.Append("\\b");
			  break;
			case '\\':
			  stringBuffer.Append("\\\\");
			  break;
			case '\'':
			  stringBuffer.Append("\\'");
			  break;
			case '"':
			  stringBuffer.Append("\\\"");
			  break;
			default:
			  stringBuffer.Append(c);
			  break;
		  }
		}
		return stringBuffer.ToString();
	  }

	  public static string textBetween(string paramString1, string paramString2, string paramString3)
	  {
		int i = paramString1.IndexOf(paramString2, StringComparison.Ordinal);
		int j = i + paramString2.Length;
		i = j;
		j = paramString1.IndexOf(paramString3, StringComparison.Ordinal);
		Console.WriteLine("start " + i + " end " + j);
		return paramString1.Substring(i, j - i);
	  }

	  public static string nativeToAscii(string paramString)
	  {
		if (string.ReferenceEquals(paramString, null))
		{
		  return null;
		}
		StringBuilder stringBuffer = new StringBuilder(paramString.Length + 60);
		for (sbyte b = 0; b < paramString.Length; b++)
		{
		  char c = paramString[b];
		  if (c <= '~')
		  {
			stringBuffer.Append(c);
		  }
		  else
		  {
			stringBuffer.Append("\\u");
			string str = c.ToString("x");
			for (int i = str.Length; i < 4; i++)
			{
			  stringBuffer.Append('0');
			}
			stringBuffer.Append(str);
		  }
		}
		return stringBuffer.ToString();
	  }

	  public static string asciiToNative(string paramString)
	  {
		if (string.ReferenceEquals(paramString, null))
		{
		  return null;
		}
		StringBuilder stringBuffer = new StringBuilder(paramString.Length);
		bool @bool = false;
		for (sbyte b = 0; b < paramString.Length; b++)
		{
		  char c = paramString[b];
		  if (@bool)
		  {
			string str;
			switch (c)
			{
			  case 'f':
				c = '\f';
				break;
			  case 'n':
				c = '\n';
				break;
			  case 'r':
				c = '\r';
				break;
			  case 't':
				c = '\t';
				break;
			  case 'u':
				str = paramString.Substring(b + 1, (b + 5) - (b + 1));
				c = (char)Convert.ToInt32(str, 16);
				b += 4;
				break;
			}
			@bool = false;
		  }
		  else
		  {
			@bool = (c == '\\') ? 1 : 0;
		  }
		  if (!@bool)
		  {
			stringBuffer.Append(c);
		  }
		}
		return stringBuffer.ToString();
	  }

	  public static string[] fillInArray(string[] paramArrayOfString, int paramInt)
	  {
		string[] arrayOfString = new string[paramArrayOfString.Length * paramInt];
		sbyte b1 = 0;
		for (sbyte b2 = 0; b2 < paramInt; b2++)
		{
		  foreach (string str in paramArrayOfString)
		  {
			arrayOfString[b1++] = str;
		  }
		}
		return arrayOfString;
	  }

	  public static string toValidFileName(string paramString)
	  {
		string str = paramString;
		for (sbyte b = 0; b < INVALID_CHARS.Length; b++)
		{
		  str = replaceAll(str, INVALID_CHARS[b], " ");
		}
		return str;
	  }

	  public static bool containsAnyDots(string paramString)
	  {
		  return (!string.ReferenceEquals(paramString, null) && paramString.IndexOf(".", StringComparison.Ordinal) != -1);
	  }

	  public static string removeZerosAfterDots(string paramString)
	  {
		string str = replaceAll(paramString, " ", "");
		int i = str.LastIndexOf(".", StringComparison.Ordinal);
		while (i != -1)
		{
		  string str1 = removeZerosFromEnd(str.Substring(i));
		  if (str1.Length <= 1)
		  {
			str = str.Substring(0, i);
			i = str.LastIndexOf(".", StringComparison.Ordinal);
		  }
		}
		return str;
	  }

	  public static string removeZerosFromEnd(string paramString)
	  {
		while (paramString.EndsWith("0", StringComparison.Ordinal) && paramString.Length != 0)
		{
		  paramString = paramString.Substring(0, paramString.LastIndexOf("0", StringComparison.Ordinal));
		}
		return paramString;
	  }

	  public static string removeZerosFromEndAndStart(string paramString)
	  {
		while (paramString.EndsWith("0", StringComparison.Ordinal) && paramString.Length != 0)
		{
		  paramString = paramString.Substring(0, paramString.LastIndexOf("0", StringComparison.Ordinal));
		}
		while (paramString.StartsWith("0", StringComparison.Ordinal) && paramString.Length != 0)
		{
		  paramString = paramString.Substring(1);
		}
		return paramString;
	  }

	  public static string toProperCaseMultiword(string paramString, int paramInt)
	  {
		if (isNullOrBlank(paramString))
		{
		  return paramString;
		}
		if (paramString.Length <= paramInt)
		{
		  return paramString;
		}
		string[] arrayOfString = paramString.Split(" ", true);
		StringBuilder stringBuffer = new StringBuilder();
		for (sbyte b = 0; b < arrayOfString.Length; b++)
		{
		  string str = arrayOfString[b];
		  if (paramString.Length <= paramInt)
		  {
			stringBuffer = stringBuffer.Append(str);
		  }
		  else
		  {
			stringBuffer = stringBuffer.Append(toProperCase(str));
		  }
		  if (b != arrayOfString.Length - 1)
		  {
			stringBuffer = stringBuffer.Append(" ");
		  }
		}
		return stringBuffer.ToString();
	  }

	  public static string proper(string paramString)
	  {
		  return isNullOrBlank(paramString) ? paramString : (char.IsLower(paramString[0]) ? (("" + paramString[0]).ToUpper() + paramString.Substring(1)) : paramString);
	  }

	  public static string removeSpacesFromStartAndEnd(string paramString)
	  {
		  return removeSpacesFromEnd(removeSpacesFromStart(paramString));
	  }

	  public static string removeSpacesFromEnd(string paramString)
	  {
		while (paramString.EndsWith(" ", StringComparison.Ordinal) && paramString.Length != 0)
		{
		  paramString = paramString.Substring(0, paramString.LastIndexOf(" ", StringComparison.Ordinal));
		}
		return paramString;
	  }

	  public static string removeSpacesFromStart(string paramString)
	  {
		while (paramString.StartsWith(" ", StringComparison.Ordinal) && paramString.Length != 0)
		{
		  paramString = paramString.Substring(1, paramString.Length - 1);
		}
		return paramString;
	  }

	  public static string removeAllSpaces(string paramString)
	  {
		  return replaceAll(paramString, " ", "");
	  }

	  public static bool containsWhiteSpace(string paramString)
	  {
		Pattern pattern = Pattern.compile("\\s");
		Matcher matcher = pattern.matcher(paramString);
		return matcher.find();
	  }

	  public static string removeNewLines(string paramString)
	  {
		  return replaceAll(paramString, "\n", " ");
	  }

	  public static string makeShortTitle(string paramString)
	  {
		  return makeShortTitle(paramString, 250);
	  }

	  public static string makeShortTitle(string paramString, int paramInt)
	  {
		  return makeShortTitle(paramString, ",", paramInt);
	  }

	  public static string makeShortTitle(string paramString1, string paramString2, int paramInt)
	  {
		string str = paramString1;
		if (str.Length < paramInt)
		{
		  return str;
		}
		if (paramInt <= 0)
		{
		  return "";
		}
		if (str.IndexOf(paramString2, StringComparison.Ordinal) == -1)
		{
		  if (str.Length > paramInt)
		  {
			str = str.Substring(0, paramInt) + "...";
		  }
		  return str;
		}
		int i = 0;
		while (str.IndexOf(paramString2, StringComparison.Ordinal) != -1)
		{
		  i += str.IndexOf(paramString2, StringComparison.Ordinal) + 1;
		  if (i >= 110)
		  {
			break;
		  }
		  str = StringHelper.SubstringSpecial(str, str.IndexOf(paramString2, StringComparison.Ordinal) + 1, str.Length);
		}
		str = paramString1.Substring(0, i);
		if (str.EndsWith(paramString2, StringComparison.Ordinal))
		{
		  str = paramString1.Substring(0, str.Length - 1);
		}
		return str;
	  }

	  public static string makeShortTitleAfterToken(string paramString1, string paramString2)
	  {
		int i = paramString1.IndexOf(paramString2, StringComparison.Ordinal);
		if (i == -1 || paramString1.Length == 1)
		{
		  return makeShortTitle(removeNewLines(paramString1));
		}
		string str;
		for (str = paramString1.Substring(i + 1, paramString1.Length - (i + 1)); str.StartsWith(" ", StringComparison.Ordinal) && str.Length > 0; str = StringHelper.SubstringSpecial(str, str.IndexOf(" ", StringComparison.Ordinal) + 1, str.Length))
		{
			;
		}
		return makeShortTitle(removeNewLines(str));
	  }

	  public static System.Collections.IList getMailsFromString(string paramString, bool paramBoolean)
	  {
		List<object> arrayList = new List<object>();
		foreach (string str in Arrays.asList(paramString.Split(";", true)))
		{
		  if (paramBoolean)
		  {
			str = "SMTP:" + str;
		  }
		  arrayList.Add(str);
		}
		return arrayList;
	  }

	  public static string escapeHQLParameterChars(string paramString)
	  {
		if (paramString.IndexOf("'", StringComparison.Ordinal) != -1)
		{
		  paramString = replaceAll(paramString, "'", "''");
		}
		return paramString;
	  }

	  public static string multiLineTableHeaderInHtml(Graphics paramGraphics, string paramString, int paramInt)
	  {
		StringBuilder stringBuffer = new StringBuilder();
		stringBuffer.Append("<html>");
		string[] arrayOfString = paramString.Split(" ", true);
		paramInt /= 7;
		stringBuffer.Append(arrayOfString[0]);
		int i = arrayOfString[0].Length + 1;
		for (sbyte b = 0; b < arrayOfString.Length - 1; b++)
		{
		  string str = arrayOfString[b + true];
		  int j = str.Length + 1;
		  i += j;
		  if (i >= paramInt)
		  {
			stringBuffer.Append("<br>");
			i = 0;
		  }
		  else
		  {
			stringBuffer.Append(" ");
		  }
		  stringBuffer.Append(str);
		}
		stringBuffer.Append("</html>");
		return stringBuffer.ToString();
	  }

	  public static double[] extractDoubles(string paramString)
	  {
		if (string.ReferenceEquals(paramString, null) || paramString.IndexOf(",", StringComparison.Ordinal) == -1)
		{
		  return new double[] {0.0D, 0.0D};
		}
		string[] arrayOfString = paramString.Split(",", true);
		double[] arrayOfDouble = new double[arrayOfString.Length];
		sbyte b = 0;
		foreach (string str in arrayOfString)
		{
		  arrayOfDouble[b++] = (Convert.ToDouble(str));
		}
		return arrayOfDouble;
	  }

	  public static bool isBlank(string paramString)
	  {
		  return (string.ReferenceEquals(paramString, null)) ? false : ((paramString.Trim().Length == 0));
	  }

	  public static bool isNull(string paramString)
	  {
		  return (string.ReferenceEquals(paramString, null));
	  }

	  public static bool isNullOrBlank(string paramString)
	  {
		  return (isNull(paramString) || paramString.Trim().Length == 0);
	  }

	  public static string getFirstLine(string paramString)
	  {
		if (isNull(paramString) || paramString.Trim().Length == 0)
		{
		  return null;
		}
		int i = paramString.IndexOf("\n", StringComparison.Ordinal);
		if (i != -1)
		{
		  paramString = paramString.Substring(0, i);
		}
		return paramString;
	  }

	  public static string getNameForSalutation(string paramString)
	  {
		if (isNullOrBlank(paramString))
		{
		  return "";
		}
		string[] arrayOfString = paramString.Split(" ", true);
		StringBuilder stringBuffer = new StringBuilder();
		foreach (string str in arrayOfString)
		{
		  if (stringBuffer.Length != 0)
		  {
			stringBuffer.Append(" ");
		  }
		  if (str.Length < 2)
		  {
			stringBuffer.Append(str);
		  }
		  else
		  {
			stringBuffer.Append(str[0] + str.Substring(1).ToLower());
		  }
		}
		return stringBuffer.ToString();
	  }

	  public static int occurencesOf(string paramString1, string paramString2)
	  {
		string str = paramString1;
		sbyte b;
		for (b = 0; str.IndexOf(paramString2, StringComparison.Ordinal) != -1; b++)
		{
		  str = StringHelper.SubstringSpecial(str, str.IndexOf(paramString2, StringComparison.Ordinal) + 1, str.Length);
		}
		return b;
	  }

	  public static bool isDecimal(string paramString)
	  {
		try
		{
		  double.Parse(paramString);
		}
		catch (Exception)
		{
		  return false;
		}
		return true;
	  }

	  public static bool isBoolean(string paramString)
	  {
		try
		{
		  bool.Parse(paramString);
		}
		catch (Exception)
		{
		  return false;
		}
		return true;
	  }

	  public static bool isInteger(string paramString)
	  {
		try
		{
		  long.Parse(paramString);
		}
		catch (Exception)
		{
		  return false;
		}
		return true;
	  }

	  public static string getFileNameFromUrl(string paramString)
	  {
		  return (paramString.IndexOf("\\", StringComparison.Ordinal) != -1) ? paramString.Substring(paramString.LastIndexOf("\\", StringComparison.Ordinal) + 1) : paramString.Substring(paramString.LastIndexOf("/", StringComparison.Ordinal) + 1);
	  }

	  public static Color getColorFromString(string paramString)
	  {
		string str1 = paramString.Substring(0, paramString.IndexOf(";", StringComparison.Ordinal));
		string str2 = StringHelper.SubstringSpecial(paramString, str1.Length + 1, paramString.IndexOf(";", str1.Length + 1, StringComparison.Ordinal));
		string str3 = StringHelper.SubstringSpecial(paramString, str1.Length + str2.Length + 2, paramString.LastIndexOf(";", StringComparison.Ordinal));
		int i = int.Parse(str1);
		int j = int.Parse(str2);
		int k = int.Parse(str3);
		return new Color(i, j, k);
	  }

	  public static string getStringFromColor(Color paramColor)
	  {
		  return paramColor.Red + ";" + paramColor.Green + ";" + paramColor.Blue + ";";
	  }

	  public static string[] mergeArrays(string[] paramArrayOfString1, string[] paramArrayOfString2)
	  {
		List<object> arrayList = new List<object>(Arrays.asList(paramArrayOfString1));
		arrayList.AddRange(Arrays.asList(paramArrayOfString2));
		return (string[])arrayList.ToArray(typeof(string));
	  }

	  public static string[] mergeArraysWithUniqueItems(string[] paramArrayOfString1, string[] paramArrayOfString2)
	  {
		List<object> arrayList = new List<object>(Arrays.asList(paramArrayOfString1));
		HashSet<object> hashSet = new HashSet<object>(arrayList.Count);
		foreach (string str in paramArrayOfString2)
		{
		  if (!string.ReferenceEquals(str, null) && !hashSet.Contains(str))
		  {
			arrayList.Add(str);
			hashSet.Add(str);
		  }
		}
		return (string[])arrayList.ToArray(typeof(string));
	  }

	  public static string rtfToHtml(string paramString)
	  {
		  return rtfToHtml(new StringReader(paramString));
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static String rtfToHtml(java.io.Reader paramReader) throws java.io.IOException
	  public static string rtfToHtml(Reader paramReader)
	  {
		JEditorPane jEditorPane = new JEditorPane();
		jEditorPane.ContentType = "text/rtf";
		EditorKit editorKit = jEditorPane.getEditorKitForContentType("text/rtf");
		try
		{
		  editorKit.read(paramReader, jEditorPane.Document, 0);
		  editorKit = null;
		  EditorKit editorKit1 = jEditorPane.getEditorKitForContentType("text/html");
		  StringWriter stringWriter = new StringWriter();
		  editorKit1.write(stringWriter, jEditorPane.Document, 0, jEditorPane.Document.Length);
		  return stringWriter.ToString();
		}
		catch (BadLocationException badLocationException)
		{
		  Console.WriteLine(badLocationException.ToString());
		  Console.Write(badLocationException.StackTrace);
		  return null;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static String inputStreamToString(java.io.InputStream paramInputStream) throws java.io.IOException
	  public static string inputStreamToString(Stream paramInputStream)
	  {
		StringBuilder stringBuffer = new StringBuilder();
		StreamReader bufferedReader = new StreamReader(paramInputStream);
		string str;
		while (!string.ReferenceEquals((str = bufferedReader.ReadLine()), null))
		{
		  stringBuffer.Append(str);
		}
		return stringBuffer.ToString();
	  }

	  public static bool startsWithNumber(string paramString)
	  {
		  return (paramString.Length == 0) ? false : isInteger("" + paramString[0]);
	  }

	  public static string toProperCase(string paramString)
	  {
		  return (string.ReferenceEquals(paramString, null) || paramString.Length <= 1) ? paramString : (paramString.Substring(0, 1).ToUpper() + paramString.Substring(1).ToLower());
	  }

	  public static string toFirstLetterLowerCase(string paramString)
	  {
		  return (string.ReferenceEquals(paramString, null) || paramString.Length <= 1) ? paramString : (paramString.Substring(0, 1).ToLower() + paramString.Substring(1));
	  }

	  public static string toFirstLetterUpperCase(string paramString)
	  {
		  return (string.ReferenceEquals(paramString, null) || paramString.Length <= 1) ? paramString : (paramString.Substring(0, 1).ToUpper() + paramString.Substring(1));
	  }

	  public static bool startsWithLowerCase(string paramString)
	  {
		  return (paramString.Length == 0) ? false : char.IsLower(paramString[0]);
	  }

	  public static bool showsOnlyZeros(string paramString)
	  {
		paramString = replaceAll(paramString, "0", "");
		paramString = replaceAll(paramString, ".", "");
		paramString = replaceAll(paramString, ",", "");
		paramString = replaceAll(paramString, " ", "");
		return (paramString.Length == 0);
	  }

	  public static int[] getIntArrayFromString(string paramString)
	  {
		List<object> vector = new List<object>();
		for (sbyte b1 = 0; b1 < paramString.Length; b1++)
		{
		  for (int i = b1 + true; i <= paramString.Length; i++)
		  {
			string str = paramString.Substring(b1, i - b1);
			if (str.EndsWith(";", StringComparison.Ordinal))
			{
			  vector.Add(paramString.Substring(b1, (i - 1) - b1));
			  b1 = i - 1;
			  i = paramString.Length;
			}
		  }
		}
		int[] arrayOfInt = new int[vector.Count];
		for (sbyte b2 = 0; b2 < vector.Count; b2++)
		{
		  try
		  {
			arrayOfInt[b2] = int.Parse((string)vector[b2]);
		  }
		  catch (System.FormatException numberFormatException)
		  {
			Console.WriteLine(numberFormatException.ToString());
			Console.Write(numberFormatException.StackTrace);
		  }
		}
		return arrayOfInt;
	  }

	  public static void setStringArrayProperty(Properties paramProperties, string paramString, string[] paramArrayOfString)
	  {
		string str = "";
		if (paramArrayOfString == null)
		{
		  paramArrayOfString = new string[0];
		}
		for (sbyte b = 0; b < paramArrayOfString.Length; b++)
		{
		  str = str + paramArrayOfString[b] + ";";
		}
		paramProperties.setProperty(paramString, str);
	  }

	  public static string[] getStringArrayProperty(Properties paramProperties, string paramString)
	  {
		string str = paramProperties.getProperty(paramString);
		if (string.ReferenceEquals(str, null))
		{
		  return new string[0];
		}
		List<object> vector = new List<object>();
		for (sbyte b = 0; b < str.Length; b++)
		{
		  for (int i = b + true; i <= str.Length; i++)
		  {
			string str1 = str.Substring(b, i - b);
			if (str1.EndsWith(";", StringComparison.Ordinal))
			{
			  vector.Add(str.Substring(b, (i - 1) - b));
			  b = i - 1;
			  i = str.Length;
			}
		  }
		}
		return (string[])vector.ToArray(typeof(string));
	  }

	  public static string[] getStringArray(string paramString)
	  {
		if (string.ReferenceEquals(paramString, null))
		{
		  return new string[0];
		}
		List<object> vector = new List<object>();
		for (sbyte b = 0; b < paramString.Length; b++)
		{
		  for (int i = b + true; i <= paramString.Length; i++)
		  {
			string str = paramString.Substring(b, i - b);
			if (str.EndsWith(";", StringComparison.Ordinal))
			{
			  vector.Add(paramString.Substring(b, (i - 1) - b));
			  b = i - 1;
			  i = paramString.Length;
			}
		  }
		}
		return (string[])vector.ToArray(typeof(string));
	  }

	  public static string getStringFromArray(string[] paramArrayOfString)
	  {
		if (paramArrayOfString == null)
		{
		  paramArrayOfString = new string[0];
		}
		string str = "";
		for (sbyte b = 0; b < paramArrayOfString.Length; b++)
		{
		  str = str + paramArrayOfString[b] + ";";
		}
		return str;
	  }

	  public static string getStringFromArray(int[] paramArrayOfInt)
	  {
		if (paramArrayOfInt == null)
		{
		  paramArrayOfInt = new int[0];
		}
		string str = "";
		for (sbyte b = 0; b < paramArrayOfInt.Length; b++)
		{
		  str = str + paramArrayOfInt[b] + ";";
		}
		return str;
	  }

	  public static bool checkEquality(string paramString1, string paramString2)
	  {
		  return (string.ReferenceEquals(paramString1, null) && string.ReferenceEquals(paramString2, null)) ? true : ((string.ReferenceEquals(paramString1, null) || string.ReferenceEquals(paramString2, null)) ? false : paramString1.Equals(paramString2));
	  }

	  public static bool checkEquality(object paramObject1, object paramObject2)
	  {
		  return (paramObject1 == null && paramObject2 == null) ? true : ((paramObject1 == null || paramObject2 == null) ? false : paramObject1.Equals(paramObject2));
	  }

	  public static bool checkEqualityBD(object paramObject1, object paramObject2)
	  {
		  return (paramObject1 == null && paramObject2 == null) ? true : ((paramObject1 == null || paramObject2 == null) ? false : ((paramObject1 is decimal && paramObject2 is decimal) ? ((BigDecimalMath.cmp((decimal)paramObject1, (decimal)paramObject2) == 0)) : paramObject1.Equals(paramObject2)));
	  }

	  public static string escapeParametricExpression(string paramString)
	  {
		if (occurencesOf(paramString, "\"") % 2 != 0)
		{
		  paramString = replaceAll(paramString, "\"", "'");
		}
		return replaceAll(paramString, "\n", "");
	  }

	  public static string unescapeString(string paramString)
	  {
		  return replaceAll(paramString, "\"\"", "\"");
	  }

	  public static char getNextCapitalAplhabetCharacter(char paramChar)
	  {
		paramChar = (char)(paramChar + '\x0001');
		return (paramChar < 'Z') ? paramChar : (char)65;
	  }

	  public static string numberToText(int paramInt)
	  {
		int i = ALPHABET.Length;
		string str = "";
		if (paramInt >= ALPHABET.Length)
		{
		  int j = paramInt / ALPHABET.Length;
		  if (j >= 1)
		  {
			str = ALPHABET[(j - 1) % ALPHABET.Length];
		  }
		}
		return str + ALPHABET[paramInt % ALPHABET.Length];
	  }

	  public static string getFirstLetterCapital(string paramString)
	  {
		  return isNullOrBlank(paramString) ? paramString : (paramString.Substring(0, 1).ToUpper() + paramString.Substring(1));
	  }

	  public static int numberOfOccurences(string paramString, char paramChar)
	  {
		sbyte b1 = 0;
		for (sbyte b2 = 0; b2 < paramString.Length; b2++)
		{
		  if (paramString[b2] == paramChar)
		  {
			b1++;
		  }
		}
		return b1;
	  }

	  public static string substringAtOccurence(string paramString, char paramChar, int paramInt)
	  {
		sbyte b1 = 0;
		for (sbyte b2 = 0; b2 < paramString.Length; b2++)
		{
		  if (paramString[b2] == paramChar)
		  {
			b1++;
		  }
		  if (b1 == paramInt)
		  {
			return paramString.Substring(0, b2);
		  }
		}
		return paramString;
	  }

	  public static string getStringFromObject(object paramObject)
	  {
		  return (paramObject == null) ? null : paramObject.ToString();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static String getValueFromAttribute(javax.naming.directory.Attribute paramAttribute) throws javax.naming.NamingException
	  public static string getValueFromAttribute(Attribute paramAttribute)
	  {
		  return (paramAttribute == null) ? null : ("" + paramAttribute.get());
	  }

	  public static string[] concat(params string[][] paramVarArgs)
	  {
		int i = 0;
		foreach (string[] arrayOfString1 in paramVarArgs)
		{
		  i += arrayOfString1.Length;
		}
		string[] arrayOfString = new string[i];
		int j = 0;
		foreach (string[] arrayOfString1 in paramVarArgs)
		{
		  Array.Copy(arrayOfString1, 0, arrayOfString, j, arrayOfString1.Length);
		  j += arrayOfString1.Length;
		}
		return arrayOfString;
	  }

	  public static bool containsIgnoreCase(string paramString1, string paramString2)
	  {
		if (string.ReferenceEquals(paramString1, null) || string.ReferenceEquals(paramString2, null))
		{
		  return false;
		}
		int i = paramString2.Length;
		int j = paramString1.Length - i;
		for (sbyte b = 0; b <= j; b++)
		{
		  if (paramString1.regionMatches(true, b, paramString2, 0, i))
		  {
			return true;
		  }
		}
		return false;
	  }

	  public static bool isEmpty(CharSequence paramCharSequence)
	  {
		  return (paramCharSequence == null || paramCharSequence.length() == 0);
	  }

	  public static bool isAllUpperCase(CharSequence paramCharSequence)
	  {
		if (paramCharSequence == null || isEmpty(paramCharSequence))
		{
		  return false;
		}
		int i = paramCharSequence.length();
		for (sbyte b = 0; b < i; b++)
		{
		  char c = paramCharSequence.charAt(b);
		  if (char.IsLetter(paramCharSequence.charAt(b)) && !char.IsUpper(paramCharSequence.charAt(b)))
		  {
			return false;
		  }
		}
		return true;
	  }

	  public static bool isRoman(string paramString)
	  {
		  return (!string.ReferenceEquals(paramString, null) && !"".Equals(paramString) && regex.matcher(paramString.ToUpper()).matches());
	  }

	  public static bool isAlphanumeric(string paramString)
	  {
		for (sbyte b = 0; b < paramString.Length; b++)
		{
		  char c = paramString[b];
		  if (c < '0' || (c >= ':' && c <= '@') || (c > 'Z' && c <= '`') || c > 'z')
		  {
			return false;
		  }
		}
		return true;
	  }

	  public static string getCodeStyleIdetifier(string paramString)
	  {
		string str = replaceAll(paramString, ".", "");
		return "" + isAllUpperCase(paramString) + paramString.IndexOf(".", StringComparison.Ordinal) + paramString.IndexOf("-", StringComparison.Ordinal) + isInteger(str) + isAlphanumeric(str) + ((!paramString.Equals("i", StringComparison.OrdinalIgnoreCase) && isRoman(str.ToUpper())) ? 1 : 0);
	  }

	  public static bool checkSameCodingStyle(string paramString1, string paramString2)
	  {
		  return getCodeStyleIdetifier(paramString1).Equals(getCodeStyleIdetifier(paramString2));
	  }

	  public static string createEmptySpaces(int paramInt)
	  {
		StringBuilder stringBuffer = new StringBuilder();
		for (sbyte b = 0; b < paramInt; b++)
		{
		  stringBuffer.Append(" ");
		}
		return stringBuffer.ToString();
	  }

	  public static string insertStringsIntoPositions(int[] paramArrayOfInt, params string[] paramVarArgs)
	  {
		if (paramVarArgs.Length != paramArrayOfInt.Length)
		{
		  throw new System.InvalidOperationException("String Utils exception: the number of arguments must be the same as the length of positions");
		}
		int i = 0;
		for (sbyte b1 = 0; b1 < paramVarArgs.Length; b1++)
		{
		  i = i + paramArrayOfInt[b1] + 1;
		}
		null = "";
		StringBuilder stringBuilder = new StringBuilder();
		char[] arrayOfChar = new char[i];
		Arrays.fill(arrayOfChar, ' ');
		stringBuilder.Append(arrayOfChar);
		for (sbyte b2 = 0; b2 < paramVarArgs.Length; b2++)
		{
		  stringBuilder.Insert(paramArrayOfInt[b2], paramVarArgs[b2]);
		}
		return removeSpacesFromEnd(stringBuilder.ToString());
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static String readFileIntoString(java.io.File paramFile) throws java.io.IOException
	  public static string readFileIntoString(File paramFile)
	  {
		StreamReader bufferedReader = new StreamReader(paramFile);
		string str1 = null;
		StringBuilder stringBuilder = new StringBuilder();
		string str2 = System.getProperty("line.separator");
		while (!string.ReferenceEquals((str1 = bufferedReader.ReadLine()), null))
		{
		  stringBuilder.Append(str1);
		  stringBuilder.Append(str2);
		}
		stringBuilder.Length = stringBuilder.Length - 2;
		bufferedReader.Close();
		return stringBuilder.ToString();
	  }

	  public static string keepOnlyAlphaNumerics(string paramString)
	  {
		  return paramString.replaceAll("[^A-Za-z0-9 ]", "");
	  }

	  public static bool isValidEmail(string paramString)
	  {
		bool @bool = true;
		string str1 = "[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,4}";
		string str2 = ".+@.+\\.[A-Za-z]{2}[A-Za-z]*";
		string str3 = @bool ? str1 : str2;
		Pattern pattern = Pattern.compile(str3);
		Matcher matcher = pattern.matcher(paramString);
		return matcher.matches();
	  }

	  public static bool checkHasScripts(string paramString)
	  {
		  return (paramString.ToLower().IndexOf("script", StringComparison.Ordinal) != -1);
	  }

	  public static string getOnlyASCIChars(string paramString)
	  {
		  return paramString.replaceAll("[^\\x00-\\x7F]", "");
	  }

	  public static int getDecimalPlaces(string paramString)
	  {
		int i = paramString.IndexOf(".", StringComparison.Ordinal);
		return (i != -1) ? paramString.Substring(i, (paramString.Length - 1) - i).Length : 0;
	  }

	  public static long? textToLong(string paramString)
	  {
		  return Convert.ToInt64(crc64(paramString.GetBytes()));
	  }

	  public static long crc64(sbyte[] paramArrayOfByte)
	  {
		long l = 0L;
		foreach (sbyte b in paramArrayOfByte)
		{
		  int i = ((int)l ^ b) & 0xFF;
		  l = (long)((ulong)l >> 8) ^ LOOKUPTABLE[i];
		}
		return l;
	  }

	  public static string clobToString(Clob paramClob)
	  {
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
		  Reader reader = paramClob.CharacterStream;
		  StreamReader bufferedReader = new StreamReader(reader);
		  string str;
		  for (sbyte b = 0; null != (str = bufferedReader.ReadLine()); b++)
		  {
			if (b)
			{
			  stringBuilder.Append("\n");
			}
			stringBuilder.Append(str);
		  }
		  bufferedReader.Close();
		}
		catch (SQLException)
		{

		}
		catch (IOException)
		{
		}
		return stringBuilder.ToString();
	  }

	  public static string getValidFileName(string paramString)
	  {
		  return paramString.replaceAll("[^a-zA-Z0-9.-\\]\\[]", "");
	  }

	  public static string toCommaSeperatedList(IList<string> paramList)
	  {
		StringBuilder stringBuffer = new StringBuilder();
		System.Collections.IEnumerator iterator = paramList.GetEnumerator();
		while (iterator.MoveNext())
		{
		  string str = (string)iterator.Current;
		  stringBuffer = stringBuffer.Append("'" + escapeHQLParameterChars(str) + "'");
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		  if (iterator.hasNext())
		  {
			stringBuffer = stringBuffer.Append(", ");
		  }
		}
		return stringBuffer.ToString();
	  }

	  public static int? indexOf(string[] paramArrayOfString, string paramString)
	  {
		  return Convert.ToInt32(indexOf(paramArrayOfString, paramString, 0));
	  }

	  public static int indexOf(object[] paramArrayOfObject, object paramObject, int paramInt)
	  {
		if (paramArrayOfObject == null)
		{
		  return -1;
		}
		if (paramInt < 0)
		{
		  paramInt = 0;
		}
		if (paramObject == null)
		{
		  for (int i = paramInt; i < paramArrayOfObject.Length; i++)
		  {
			if (paramArrayOfObject[i] == null)
			{
			  return i;
			}
		  }
		}
		else if (paramArrayOfObject.GetType().GetElementType().isInstance(paramObject))
		{
		  for (int i = paramInt; i < paramArrayOfObject.Length; i++)
		  {
			if (paramObject.Equals(paramArrayOfObject[i]))
			{
			  return i;
			}
		  }
		}
		return -1;
	  }

	  public static string questionMarks(int paramInt)
	  {
		StringBuilder stringBuffer = new StringBuilder();
		for (sbyte b = 0; b < paramInt; b++)
		{
		  if (b)
		  {
			stringBuffer.Append(",");
		  }
		  stringBuffer.Append("?");
		}
		return stringBuffer.ToString();
	  }

	  public static string abbreviate(string paramString, int paramInt)
	  {
		  return abbreviate(paramString, 0, paramInt);
	  }

	  public static string abbreviate(string paramString, int paramInt1, int paramInt2)
	  {
		if (string.ReferenceEquals(paramString, null))
		{
		  return null;
		}
		if (paramInt2 < 4)
		{
		  throw new System.ArgumentException("Minimum abbreviation width is 4");
		}
		if (paramString.Length <= paramInt2)
		{
		  return paramString;
		}
		if (paramInt1 > paramString.Length)
		{
		  paramInt1 = paramString.Length;
		}
		if (paramString.Length - paramInt1 < paramInt2 - 3)
		{
		  paramInt1 = paramString.Length - paramInt2 - 3;
		}
		if (paramInt1 <= 4)
		{
		  return paramString.Substring(0, paramInt2 - 3) + "...";
		}
		if (paramInt2 < 7)
		{
		  throw new System.ArgumentException("Minimum abbreviation width with offset is 7");
		}
		return (paramInt1 + paramInt2 - 3 < paramString.Length) ? ("..." + abbreviate(paramString.Substring(paramInt1), paramInt2 - 3)) : ("..." + paramString.Substring(paramString.Length - paramInt2 - 3));
	  }

	  public static bool checkUnitOfSameType(string paramString1, string paramString2)
	  {
		  return !checkEquality(paramString2, paramString1) ? (((paramString2.Equals("SF") && paramString1.Equals("SY")) || (paramString2.Equals("CF") && (paramString1.Equals("CY") || paramString1.Equals("Y3"))) || ((paramString2.Equals("LF") || paramString2.Equals("FT")) && (paramString1.Equals("IN") || paramString1.Equals("LI"))))) : true;
	  }

	  static StringUtils()
	  {
		for (sbyte b = 0; b < (sbyte)'Ā'; b++)
		{
		  long l = b;
		  for (sbyte b1 = 0; b1 < 8; b1++)
		  {
			if ((l & 0x1L) == 1L)
			{
			  l = (long)((ulong)l >> true) ^ 0xD800000000000000L;
			}
			else
			{
			  l = (long)((ulong)l >> true);
			}
		  }
		  LOOKUPTABLE[b] = l;
		}
		INVALID_CHARS = new string[] {";", "=", "+", "<", ">", "|", "\\", "/", "'", "?", "#", "@"};
		ALPHABET = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
		regex = Pattern.compile("M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})");
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\StringUtils.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}