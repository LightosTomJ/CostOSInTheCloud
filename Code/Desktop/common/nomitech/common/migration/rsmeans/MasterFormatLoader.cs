using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common.migration.rsmeans
{
	using GroupCode = nomitech.common.@base.GroupCode;
	using ExtraCode1Table = nomitech.common.db.local.ExtraCode1Table;
	using StringUtils = nomitech.common.util.StringUtils;
	using Session = org.hibernate.Session;
	using Transaction = org.hibernate.Transaction;

	public class MasterFormatLoader
	{
	  public const string MF95 = "MF95.CSI";

	  public const string MF04 = "MF04.CSI";

	  public const string MF12 = "MF12.CSI";

	  public const string MF14 = "MF14.CSI";

	  private IDictionary<string, GroupCode> csiMap = new Hashtable();

	  private string csiType = "MF04.CSI";

	  private string costDataFolder = null;

	  private DateTime lastUpdate = DateTime.Now;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private MasterFormatLoader(String paramString1, String paramString2, String paramString3) throws Exception
	  private MasterFormatLoader(string paramString1, string paramString2, string paramString3)
	  {
		this.costDataFolder = paramString1;
		this.csiType = paramString3;
		Session session = DatabaseDBUtil.currentSession();
		Transaction transaction = session.beginTransaction();
		try
		{
		  if (!string.ReferenceEquals(paramString1, null))
		  {
			loadCSICodes("BCCD", "BCCD", session);
			loadCSICodes("Civil", "CIVL", session);
			loadCSICodes("Commercial", "COMM", session);
			loadCSICodes("Concrete", "CONC", session);
			loadCSICodes("Commercial Renovation (R&R)", "R&R", session);
			loadCSICodes("Electrical", "ELEC", session);
			loadCSICodes("Facility", "FACL", session);
			loadCSICodes("Green Building", "GRN", session);
			loadCSICodes("Heavy", "HVY", session);
			loadCSICodes("Interior", "INTR", session);
			loadCSICodes("Light Commercial", "LITE", session);
			loadCSICodes("Master", "MSTR", session);
			loadCSICodes("Mechanical", "MECH", session);
			loadCSICodes("Open Shop", "Open", session);
			loadCSICodes("Plumbing", "PLUM", session);
			loadCSICodes("Residential", "RESI", session);
			loadCSICodes("Site Work", "SITE", session);
		  }
		  if (!string.ReferenceEquals(paramString2, null))
		  {
			this.costDataFolder = paramString2;
			if (paramString3.Equals("MF14.CSI"))
			{
			  this.csiType = "CSI14";
			}
			else if (paramString3.Equals("MF12.CSI"))
			{
			  this.csiType = "CSI12";
			}
			else if (paramString3.Equals("MF04.CSI"))
			{
			  this.csiType = "CSI04";
			}
			else
			{
			  this.csiType = "CSI95";
			}
			loadCSICodesAss("Assembly", "ASM", session);
			loadCSICodesAss("Civil", "CVL", session);
			loadCSICodesAss("Commercial", "COM", session);
			loadCSICodesAss("Concrete", "CON", session);
			loadCSICodesAss("Electrical", "ELE", session);
			loadCSICodesAss("Facility", "FAC", session);
			loadCSICodesAss("Green Building", "GRN", session);
			loadCSICodesAss("Heavy", "HVY", session);
			loadCSICodesAss("Interior", "INT", session);
			loadCSICodesAss("Master", "ALL", session);
			loadCSICodesAss("Mechanical", "MEC", session);
			loadCSICodesAss("Plumbing", "PLU", session);
			loadCSICodesAss("Site Work", "SIT", session);
			loadCSICodesAss("Square Foot", "SF", session);
		  }
		  Console.WriteLine("BEFORE COMMIT " + paramString3);
		  transaction.commit();
		  Console.WriteLine("AFTER COMMIT " + paramString3);
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
//ORIGINAL LINE: private void loadCSICodes(String paramString1, String paramString2, org.hibernate.Session paramSession) throws Exception
	  private void loadCSICodes(string paramString1, string paramString2, Session paramSession)
	  {
		File file = new File(this.costDataFolder + File.separator + paramString1 + File.separator + paramString2 + this.csiType);
		Console.WriteLine("PROCESSING: " + file.AbsolutePath);
		StreamReader bufferedReader = new StreamReader(file);
		while (true)
		{
		  string str1 = bufferedReader.ReadLine();
		  if (string.ReferenceEquals(str1, null))
		  {
			break;
		  }
		  string str2 = str1.Substring(0, 8);
		  string str3 = str1.Substring(8, 1);
		  string str4 = StringUtils.removeSpacesFromEnd(str1.Substring(9, 60));
		  if (!this.csiMap.ContainsKey(str2))
		  {
			ExtraCode1Table extraCode1Table = null;
			if (this.csiType.Equals("MF95.CSI"))
			{
			  extraCode1Table = new ExtraCode1Table();
			  ((ExtraCode1Table)extraCode1Table).GroupCode = StringUtils.convert8digitCodetoDotit(str2);
			  ((ExtraCode1Table)extraCode1Table).Title = str4;
			  ((ExtraCode1Table)extraCode1Table).Notes = "";
			  ((ExtraCode1Table)extraCode1Table).EditorId = "csi";
			  ((ExtraCode1Table)extraCode1Table).Description = "";
			  ((ExtraCode1Table)extraCode1Table).LastUpdate = this.lastUpdate;
			}
			else
			{
			  extraCode1Table = new ExtraCode1Table();
			  ((ExtraCode1Table)extraCode1Table).GroupCode = StringUtils.convert8digitCodetoDotit(str2);
			  ((ExtraCode1Table)extraCode1Table).Title = str4;
			  ((ExtraCode1Table)extraCode1Table).Notes = "";
			  ((ExtraCode1Table)extraCode1Table).EditorId = "csi";
			  ((ExtraCode1Table)extraCode1Table).Description = "";
			  ((ExtraCode1Table)extraCode1Table).LastUpdate = this.lastUpdate;
			}
			this.csiMap[str2] = (GroupCode)extraCode1Table.clone();
			if (str3.Equals("1"))
			{
			  Console.WriteLine(paramString1 + ": " + str2 + " - " + extraCode1Table);
			}
			paramSession.save(extraCode1Table);
		  }
		}
		bufferedReader.Close();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadCSICodesAss(String paramString1, String paramString2, org.hibernate.Session paramSession) throws Exception
	  private void loadCSICodesAss(string paramString1, string paramString2, Session paramSession)
	  {
		File file = new File(this.costDataFolder + File.separator + paramString1 + File.separator + "ASM" + this.csiType + "." + paramString2);
		Console.WriteLine("PROCESSING: " + file.AbsolutePath);
		StreamReader bufferedReader = new StreamReader(file);
		while (true)
		{
		  string str1 = bufferedReader.ReadLine();
		  if (string.ReferenceEquals(str1, null))
		  {
			break;
		  }
		  string str2 = str1.Substring(0, 8);
		  string str3 = str1.Substring(8, 1);
		  string str4 = StringUtils.removeSpacesFromEnd(str1.Substring(9, 60));
		  if (!this.csiMap.ContainsKey(str2))
		  {
			ExtraCode1Table extraCode1Table = null;
			if (this.csiType.Equals("MF95.CSI"))
			{
			  extraCode1Table = new ExtraCode1Table();
			  ((ExtraCode1Table)extraCode1Table).GroupCode = StringUtils.convert8digitCodetoDotit(str2);
			  ((ExtraCode1Table)extraCode1Table).Title = str4;
			  ((ExtraCode1Table)extraCode1Table).Notes = "";
			  ((ExtraCode1Table)extraCode1Table).EditorId = "csi";
			  ((ExtraCode1Table)extraCode1Table).Description = "";
			  ((ExtraCode1Table)extraCode1Table).LastUpdate = this.lastUpdate;
			}
			else
			{
			  extraCode1Table = new ExtraCode1Table();
			  ((ExtraCode1Table)extraCode1Table).GroupCode = StringUtils.convert8digitCodetoDotit(str2);
			  ((ExtraCode1Table)extraCode1Table).Title = str4;
			  ((ExtraCode1Table)extraCode1Table).Notes = "";
			  ((ExtraCode1Table)extraCode1Table).EditorId = "csi";
			  ((ExtraCode1Table)extraCode1Table).Description = "";
			  ((ExtraCode1Table)extraCode1Table).LastUpdate = this.lastUpdate;
			}
			this.csiMap[str2] = (GroupCode)extraCode1Table.clone();
			if (str3.Equals("1"))
			{
			  Console.WriteLine(paramString1 + ": " + str2 + " - " + extraCode1Table);
			}
			paramSession.save(extraCode1Table);
		  }
		}
		bufferedReader.Close();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.Map<String, nomitech.common.base.GroupCode> loadCSI(String paramString1, String paramString2, String paramString3) throws Exception
	  public static IDictionary<string, GroupCode> loadCSI(string paramString1, string paramString2, string paramString3)
	  {
		MasterFormatLoader masterFormatLoader = new MasterFormatLoader(paramString1, paramString2, paramString3);
		return masterFormatLoader.csiMap;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\rsmeans\MasterFormatLoader.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}