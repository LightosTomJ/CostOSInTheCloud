using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.license
{
	using XStream = com.thoughtworks.xstream.XStream;
	using ConcLicenseTable = nomitech.common.db.local.ConcLicenseTable;
	using EncryptedStringUserType = nomitech.common.db.types.EncryptedStringUserType;
	using PongEvent = nomitech.common.@event.PongEvent;
	using CryptUtil = nomitech.common.util.CryptUtil;
	using Session = org.hibernate.Session;

	public class LicenseManager
	{
	  public static void validateTableAndFixTable(Session paramSession)
	  {
		EncryptedStringUserType.Key = CryptUtil.Instance.encryptHexString("oasj419][f'ar;;34").ToCharArray();
		System.Collections.IList list = paramSession.createQuery("from ConcLicenseTable").list();
		XStream xStream = new XStream();
		HashSet<object> hashSet1 = new HashSet<object>();
		bool? @bool = true;
		Hashtable hashMap = new Hashtable();
		HashSet<object> hashSet2 = new HashSet<object>();
		foreach (ConcLicenseTable concLicenseTable in list)
		{
		  LicenseRowItem licenseRowItem = (LicenseRowItem)xStream.fromXML(concLicenseTable.HashKey);
		  if (hashMap.ContainsKey(licenseRowItem.Serial))
		  {
			@bool = false;
			hashSet2.Add(concLicenseTable.Id);
			hashSet2.Add(((ConcLicenseTable)hashMap[licenseRowItem.Serial]).Id);
			continue;
		  }
		  hashMap[licenseRowItem.Serial] = concLicenseTable;
		}
		if (!@bool.Value)
		{
		  int? integer = Convert.ToInt32(hashSet2.Count);
		  foreach (long? long in hashSet2)
		  {
			ConcLicenseTable concLicenseTable = (ConcLicenseTable)paramSession.load(typeof(ConcLicenseTable), long);
			LicenseRowItem licenseRowItem = (LicenseRowItem)xStream.fromXML(concLicenseTable.HashKey);
			if (integer.Value > 1)
			{
			  paramSession.delete(concLicenseTable);
			  paramSession.flush();
			}
		  }
		}
	  }

	  public static License loadFromTable(Session paramSession)
	  {
		validateTableAndFixTable(paramSession);
		EncryptedStringUserType.Key = CryptUtil.Instance.encryptHexString("oasj419][f'ar;;34").ToCharArray();
		System.Collections.IList list = paramSession.createQuery("from ConcLicenseTable").list();
		XStream xStream = new XStream();
		License license = new License();
		bool @bool = false;
		foreach (ConcLicenseTable concLicenseTable in list)
		{
		  LicenseRowItem licenseRowItem = (LicenseRowItem)xStream.fromXML(concLicenseTable.HashKey);
		  license.addRowItemToSet(licenseRowItem);
		}
		return license;
	  }

	  public static void storeToTable(Session paramSession, License paramLicense)
	  {
		validateTableAndFixTable(paramSession);
		EncryptedStringUserType.Key = CryptUtil.Instance.encryptHexString("oasj419][f'ar;;34").ToCharArray();
		XStream xStream = new XStream();
		foreach (LicenseRowItem licenseRowItem in paramLicense.RowItems)
		{
		  ConcLicenseTable concLicenseTable = new ConcLicenseTable();
		  string str = xStream.toXML(licenseRowItem);
		  concLicenseTable.HashKey = str;
		  paramSession.save(concLicenseTable);
		}
	  }

	  public static bool? registerUserBySerial(Session paramSession, string paramString1, string paramString2, string paramString3)
	  {
		EncryptedStringUserType.Key = CryptUtil.Instance.encryptHexString("oasj419][f'ar;;34").ToCharArray();
		bool? @bool = Convert.ToBoolean(false);
		System.Collections.IList list = paramSession.createQuery("from ConcLicenseTable").list();
		XStream xStream = new XStream();
		License license = new License();
		foreach (ConcLicenseTable concLicenseTable in list)
		{
		  LicenseRowItem licenseRowItem = (LicenseRowItem)xStream.fromXML(concLicenseTable.HashKey);
		  if (licenseRowItem.hasSameSerial(paramString3).Value && !licenseRowItem.CheckedIn)
		  {
			try
			{
			  bool? bool1 = Convert.ToBoolean(false);
			  System.Collections.IEnumerator enumeration = NetworkInterface.NetworkInterfaces;
			  List<object> arrayList = new List<object>();
			  foreach (NetworkInterface networkInterface in Collections.list(enumeration))
			  {
				foreach (InetAddress inetAddress in Collections.list(networkInterface.InetAddresses))
				{
				  arrayList.Add(inetAddress);
				  if (inetAddress.HostAddress.equalsIgnoreCase(licenseRowItem.ServerIP))
				  {
					bool1 = Convert.ToBoolean(true);
					InetAddress inetAddress1 = inetAddress;
				  }
				}
			  }
			  if (!bool1.Value)
			  {
				@bool = Convert.ToBoolean(false);
				break;
			  }
			}
			catch (SocketException socketException)
			{
			  Console.WriteLine(socketException.ToString());
			  Console.Write(socketException.StackTrace);
			}
			DateTime date = DateTime.Now;
			SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyyyMMddHHmmssZ");
			string str1 = simpleDateFormat.format(date);
			LicenseRowItem licenseRowItem1 = createRow(paramString1, paramString2, paramString3, licenseRowItem, Convert.ToBoolean(true), str1);
			string str2 = xStream.toXML(licenseRowItem1);
			concLicenseTable.HashKey = str2;
			paramSession.update(concLicenseTable);
			@bool = Convert.ToBoolean(true);
		  }
		}
		paramSession.flush();
		return @bool;
	  }

	  public static LicenseRowItem createRow(string paramString1, string paramString2, string paramString3, LicenseRowItem paramLicenseRowItem, bool? paramBoolean, string paramString4)
	  {
		LicenseRowItem licenseRowItem = new LicenseRowItem();
		licenseRowItem.CheckedIn = paramBoolean.Value;
		licenseRowItem.CID = paramString1;
		licenseRowItem.PlugIns = paramLicenseRowItem.PlugIns;
		licenseRowItem.CheckedInDate = paramString4;
		licenseRowItem.ExpDate = paramLicenseRowItem.ExpDate;
		licenseRowItem.SupportExpirationDate = paramLicenseRowItem.SupportExpirationDate;
		licenseRowItem.Serial = paramString3;
		licenseRowItem.Userid = paramString2;
		licenseRowItem.CompanyName = paramLicenseRowItem.CompanyName;
		licenseRowItem.ServerIP = paramLicenseRowItem.ServerIP;
		if (paramLicenseRowItem.IsTrial)
		{
		  licenseRowItem.TrialDays = paramLicenseRowItem.TrialDays;
		  licenseRowItem.IsTrial = paramLicenseRowItem.IsTrial;
		}
		else
		{
		  licenseRowItem.TrialDays = -1;
		  licenseRowItem.IsTrial = false;
		}
		return licenseRowItem;
	  }

	  public static bool? unRegisterUserBySerial(Session paramSession, string paramString1, string paramString2, string paramString3)
	  {
		EncryptedStringUserType.Key = CryptUtil.Instance.encryptHexString("oasj419][f'ar;;34").ToCharArray();
		bool? @bool = Convert.ToBoolean(false);
		System.Collections.IList list = paramSession.createQuery("from ConcLicenseTable").list();
		XStream xStream = new XStream();
		License license = new License();
		foreach (ConcLicenseTable concLicenseTable in list)
		{
		  LicenseRowItem licenseRowItem = (LicenseRowItem)xStream.fromXML(concLicenseTable.HashKey);
		  if (licenseRowItem.hasSameSerial(paramString3).Value && licenseRowItem.CheckedIn)
		  {
			LicenseRowItem licenseRowItem1 = createRow("NULL", "NULL", paramString3, licenseRowItem, Convert.ToBoolean(false), "NULL");
			string str = xStream.toXML(licenseRowItem1);
			concLicenseTable.HashKey = str;
			paramSession.update(concLicenseTable);
			paramSession.flush();
			@bool = Convert.ToBoolean(true);
		  }
		}
		if (paramSession.Open)
		{
		  paramSession.flush();
		}
		return @bool;
	  }

	  public static void decrementTrialDays(Session paramSession)
	  {
		EncryptedStringUserType.Key = CryptUtil.Instance.encryptHexString("oasj419][f'ar;;34").ToCharArray();
		System.Collections.IList list = paramSession.createQuery("from ConcLicenseTable").list();
		XStream xStream = new XStream();
		foreach (ConcLicenseTable concLicenseTable in list)
		{
		  LicenseRowItem licenseRowItem = (LicenseRowItem)xStream.fromXML(concLicenseTable.HashKey);
		  if (licenseRowItem.Version == 2 && licenseRowItem.IsTrial)
		  {
			if (licenseRowItem.TrialDays < -1)
			{
			  licenseRowItem.TrialDays = -1;
			}
			if (licenseRowItem.TrialDays != -1 && licenseRowItem.TrialDays != 0)
			{
			  licenseRowItem.TrialDays = licenseRowItem.TrialDays - 10;
			  string str = xStream.toXML(licenseRowItem);
			  concLicenseTable.HashKey = str;
			  paramSession.update(concLicenseTable);
			}
		  }
		}
		if (paramSession.Open)
		{
		  paramSession.flush();
		  paramSession.close();
		}
	  }

	  public static string timeConvert(int paramInt)
	  {
		  return (paramInt / 24 / 60) + ":" + (paramInt / 60 % 24) + ':' + (paramInt % 60);
	  }

	  public static int serialVersion(Session paramSession)
	  {
		EncryptedStringUserType.Key = CryptUtil.Instance.encryptHexString("oasj419][f'ar;;34").ToCharArray();
		System.Collections.IList list = paramSession.createQuery("from ConcLicenseTable").list();
		XStream xStream = new XStream();
		foreach (ConcLicenseTable concLicenseTable in list)
		{
		  LicenseRowItem licenseRowItem = (LicenseRowItem)xStream.fromXML(concLicenseTable.HashKey);
		  if (licenseRowItem.Version == 2)
		  {
			if (paramSession.Open)
			{
			  paramSession.flush();
			  paramSession.close();
			}
			return 2;
		  }
		}
		if (paramSession.Open)
		{
		  paramSession.flush();
		  paramSession.close();
		}
		return 1;
	  }

	  public static bool updateDate(PongEvent paramPongEvent, Session paramSession)
	  {
		EncryptedStringUserType.Key = CryptUtil.Instance.encryptHexString("oasj419][f'ar;;34").ToCharArray();
		System.Collections.IList list = paramSession.createQuery("from ConcLicenseTable").list();
		XStream xStream = new XStream();
		SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyyyMMddHHmmssZ");
		bool @bool = false;
		foreach (ConcLicenseTable concLicenseTable in list)
		{
		  LicenseRowItem licenseRowItem = (LicenseRowItem)xStream.fromXML(concLicenseTable.HashKey);
		  if (licenseRowItem.CheckedIn && licenseRowItem.Serial.Equals(paramPongEvent.Serial) && licenseRowItem.Userid.Equals(paramPongEvent.UserId, StringComparison.OrdinalIgnoreCase))
		  {
			@bool = true;
			string str1 = simpleDateFormat.format(DateTime.Now);
			licenseRowItem.CheckedInDate = str1;
			string str2 = xStream.toXML(licenseRowItem);
			concLicenseTable.HashKey = str2;
			paramSession.update(concLicenseTable);
		  }
		}
		return @bool;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\license\LicenseManager.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}