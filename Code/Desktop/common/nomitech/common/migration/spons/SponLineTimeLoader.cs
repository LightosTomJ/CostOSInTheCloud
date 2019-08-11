using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common.migration.spon
{

    public class SponLineTimeLoader
    {
        private IList<SponLineItem> majorList = new List<SponLineItem>();

        private IList<SponLineItem> minorList = new List<SponLineItem>();

        private IDictionary<string, SponLineItem> majorMap = new Dictionary<string, SponLineItem>();

        private IDictionary<string, SponLineItem> minorMap = new Dictionary<string, SponLineItem>();

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private SponLineTimeLoader(String paramString1, String paramString2) throws Exception
        private SponLineTimeLoader(string paramString1, string paramString2)
        {
            File file1 = new File(paramString1);
            File file2 = new File(paramString1);
            Console.WriteLine("PROCESSING MAJOR: " + file1.AbsolutePath);
            StreamReader bufferedReader = new StreamReader(file1);
            while (true)
            {
                string str1 = bufferedReader.ReadLine();
                if (string.ReferenceEquals(str1, null))
                {
                    break;
                }
                string[] arrayOfString = str1.Split(",", 8);
                if (arrayOfString.Length < 8)
                {
                    Console.WriteLine("ERROR: Extracting line: " + str1 + " invalid length: " + arrayOfString.Length);
                }
                string str2 = arrayOfString[0];
                string str3 = arrayOfString[1];
                string str4 = arrayOfString[2];
                string str5 = arrayOfString[3];
                string str6 = arrayOfString[4];
                string str7 = arrayOfString[5];
                string str8 = arrayOfString[6];
                string str9 = null;
                if (str1.IndexOf("\"", StringComparison.Ordinal) != -1)
                {
                    str9 = StringHelper.SubstringSpecial(str1, str1.IndexOf("\"", StringComparison.Ordinal) + 1, str1.LastIndexOf("\"", StringComparison.Ordinal));
                }
                else
                {
                    str9 = StringHelper.SubstringSpecial(str1, str1.LastIndexOf(",", StringComparison.Ordinal) + 1, str1.Length);
                }
                if (str2.Equals("*"))
                {
                    SponLineItem sponLineItem1 = (SponLineItem)this.majorList[this.majorList.Count - 1];
                    if (sponLineItem1.Code.Equals(str3))
                    {
                        sponLineItem1.Description = sponLineItem1.Description + str9;
                        continue;
                    }
                    Console.WriteLine("ERROR for line " + str1 + " previous line does not have same code");
                    continue;
                }
                SponLineItem sponLineItem = new SponLineItem(str2, str3, str9, str6, str5, str7, str8, str4);
                this.majorList.Add(sponLineItem);
                this.majorMap[str3] = sponLineItem;
            }
            bufferedReader.Close();
            Console.WriteLine("PROCESSING MINOR: " + file2.AbsolutePath);
            bufferedReader = new StreamReader(file2);
            while (true)
            {
                string str1 = bufferedReader.ReadLine();
                if (string.ReferenceEquals(str1, null))
                {
                    break;
                }
                string[] arrayOfString = str1.Split(",", 8);
                if (arrayOfString.Length < 8)
                {
                    Console.WriteLine("ERROR: Extracting line: " + str1 + " invalid length: " + arrayOfString.Length);
                }
                string str2 = arrayOfString[0];
                string str3 = arrayOfString[1];
                string str4 = arrayOfString[2];
                string str5 = arrayOfString[3];
                string str6 = arrayOfString[4];
                string str7 = arrayOfString[5];
                string str8 = arrayOfString[6];
                string str9 = null;
                if (str1.IndexOf("\"", StringComparison.Ordinal) != -1)
                {
                    str9 = StringHelper.SubstringSpecial(str1, str1.IndexOf("\"", StringComparison.Ordinal) + 1, str1.LastIndexOf("\"", StringComparison.Ordinal));
                }
                else
                {
                    str9 = StringHelper.SubstringSpecial(str1, str1.LastIndexOf(",", StringComparison.Ordinal) + 1, str1.Length);
                }
                if (str2.Equals("*"))
                {
                    SponLineItem sponLineItem1 = (SponLineItem)this.minorList[this.minorList.Count - 1];
                    if (sponLineItem1.Code.Equals(str3))
                    {
                        sponLineItem1.Description = sponLineItem1.Description + str9;
                        continue;
                    }
                    Console.WriteLine("ERROR for line " + str1 + " previous line does not have same code");
                    continue;
                }
                SponLineItem sponLineItem = new SponLineItem(str2, str3, str9, str6, str5, str7, str8, str4);
                this.minorList.Add(sponLineItem);
                this.minorMap[str3] = sponLineItem;
            }
            bufferedReader.Close();
            Console.WriteLine("MERGING MAJOR WITH MINOR");
            foreach (SponLineItem sponLineItem1 in this.majorList)
            {
                SponLineItem sponLineItem2 = (SponLineItem)this.minorMap[sponLineItem1.Code];
                if (sponLineItem2 != null)
                {
                    sponLineItem1.SecondItem = sponLineItem2;
                }
            }
            Console.WriteLine("ADDING MINORS THAT DONT EXIST TO MAJOR");
            foreach (SponLineItem sponLineItem1 in this.minorList)
            {
                SponLineItem sponLineItem2 = (SponLineItem)this.majorMap[sponLineItem1.Code];
                if (sponLineItem2 == null)
                {
                    Console.WriteLine("CAUTION YOU NEED TO SORT: Adding " + sponLineItem1.Code + " " + sponLineItem1.Description);
                    this.majorList.Add(sponLineItem1);
                }
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static java.util.List<SponLineItem> loadLineItems(String paramString1, String paramString2) throws Exception
        public static IList<SponLineItem> loadLineItems(string paramString1, string paramString2)
        {
            SponLineTimeLoader sponLineTimeLoader = new SponLineTimeLoader(paramString1, paramString2);
            return sponLineTimeLoader.majorList;
        }
    }

    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\spon\SponLineTimeLoader.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}