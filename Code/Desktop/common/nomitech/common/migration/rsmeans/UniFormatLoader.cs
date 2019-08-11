using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common.migration.rsmeans
{
	using GroupCode = nomitech.common.@base.GroupCode;
	using ExtraCode3Table = nomitech.common.db.local.ExtraCode3Table;
	using StringUtils = nomitech.common.util.StringUtils;
	using Session = org.hibernate.Session;
	using Transaction = org.hibernate.Transaction;

	public class UniFormatLoader
	{
	  private IDictionary<string, GroupCode> uniMap = new Hashtable();

	  private string costDataFolder = null;

	  private DateTime lastUpdate = DateTime.Now;

	  public const string AS14 = "ASMUNI14";

	  public const string AS17 = "ASMUNI17";

	  private string asm;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private UniFormatLoader(String paramString1, String paramString2) throws Exception
	  private UniFormatLoader(string paramString1, string paramString2)
	  {
		this.costDataFolder = paramString1;
		this.asm = paramString2;
		Session session = DatabaseDBUtil.currentSession();
		Transaction transaction = session.beginTransaction();
		try
		{
		  loadUniCodes("Assembly", "ASM", session);
		  loadUniCodes("Civil", "CVL", session);
		  loadUniCodes("Commercial", "COM", session);
		  loadUniCodes("Concrete", "CON", session);
		  loadUniCodes("Electrical", "ELE", session);
		  loadUniCodes("Facility", "FAC", session);
		  loadUniCodes("Green Building", "GRN", session);
		  loadUniCodes("Heavy", "HVY", session);
		  loadUniCodes("Interior", "INT", session);
		  loadUniCodes("Master", "ALL", session);
		  loadUniCodes("Mechanical", "MEC", session);
		  loadUniCodes("Plumbing", "PLU", session);
		  loadUniCodes("Site Work", "SIT", session);
		  loadUniCodes("Square Foot", "SF", session);
		  transaction.commit();
		}
		catch (Exception exception)
		{
		  transaction.rollback();
		  DatabaseDBUtil.closeSession();
		  throw exception;
		}
		DatabaseDBUtil.closeSession();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadUniCodes(String paramString1, String paramString2, org.hibernate.Session paramSession) throws Exception
	  private void loadUniCodes(string paramString1, string paramString2, Session paramSession)
	  {
		File file = new File(this.costDataFolder + File.separator + paramString1 + File.separator + this.asm + "." + paramString2);
		Console.WriteLine("PROCESSING: " + file.AbsolutePath);
		StreamReader bufferedReader = new StreamReader(file);
		while (true)
		{
		  string str1 = bufferedReader.ReadLine();
		  if (string.ReferenceEquals(str1, null))
		  {
			break;
		  }
		  string str2 = StringUtils.removeSpacesFromEnd(str1.Substring(0, 8));
		  string str3 = StringUtils.removeSpacesFromEnd(str1.Substring(8, str1.Length - 8));
		  if (!this.uniMap.ContainsKey(str2))
		  {
			ExtraCode3Table extraCode3Table = null;
			extraCode3Table = new ExtraCode3Table();
			((ExtraCode3Table)extraCode3Table).GroupCode = getInWbsFormat(str2);
			((ExtraCode3Table)extraCode3Table).Title = str3;
			((ExtraCode3Table)extraCode3Table).Notes = "";
			((ExtraCode3Table)extraCode3Table).EditorId = "rsmeans";
			((ExtraCode3Table)extraCode3Table).Description = "";
			((ExtraCode3Table)extraCode3Table).LastUpdate = this.lastUpdate;
			this.uniMap[str2] = (GroupCode)extraCode3Table.clone();
			Console.WriteLine(paramString1 + ": " + str2 + " - " + extraCode3Table);
			paramSession.save(extraCode3Table);
		  }
		}
		bufferedReader.Close();
	  }

	  private string getInWbsFormat(string paramString)
	  {
		  return (paramString.Length == 1) ? paramString : ((paramString.Length == 3) ? (paramString.Substring(0, 1) + "." + paramString.Substring(1, paramString.Length - 1)) : ((paramString.Length == 5) ? (paramString.Substring(0, 1) + "." + paramString.Substring(1, 2) + "." + paramString.Substring(3, paramString.Length - 3)) : (paramString.Substring(0, 1) + "." + paramString.Substring(1, 2) + "." + paramString.Substring(3, 2) + "." + paramString.Substring(5, paramString.Length - 5))));
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.Map<String, nomitech.common.base.GroupCode> loadUniFormat(String paramString1, String paramString2) throws Exception
	  public static IDictionary<string, GroupCode> loadUniFormat(string paramString1, string paramString2)
	  {
		UniFormatLoader uniFormatLoader = new UniFormatLoader(paramString1, paramString2);
		return uniFormatLoader.uniMap;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\rsmeans\UniFormatLoader.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}