using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Desktop.common.nomitech.bcis.api
{
    using TypeReference = Desktop.common.com.fasterxml.jackson.core.type.TypeReference;
    using ObjectMapper = Desktop.common.com.fasterxml.jackson.databind.ObjectMapper;
    using Assignments = Desktop.common.nomitech.bcis.dto.Assignments;
    using EditionDTO = Desktop.common.nomitech.bcis.dto.EditionDTO;
    using ItemDTO = Desktop.common.nomitech.bcis.dto.ItemDTO;
    using HTTPUtil = Desktop.common.nomitech.common.util.HTTPUtil;

    public class BCISApi
    {
        private ObjectMapper objectMapper = new ObjectMapper();

        private string username;

        private string password;

        private string apiBaseUrl;

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public BCISApi(String paramString1, String paramString2, String paramString3) throws Exception
        public BCISApi(string paramString1, string paramString2, string paramString3)
        {
            if (!string.ReferenceEquals(paramString2, null))
            {
                this.username = paramString2.ToLower();
            }
            this.password = paramString3;
            this.apiBaseUrl = paramString1;
            doLogin();
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void doLogin() throws Exception
        private void doLogin()
        {
            listLatestEditions();
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public java.util.List<nomitech.bcis.dto.EditionDTO> listLatestEditions() throws Exception
        public virtual IList<EditionDTO> listLatestEditions()
        {
            return (System.Collections.IList)this.objectMapper.readValue(getInputStream("listLatestEditions", null), new TypeReferenceAnonymousInnerClass(this));
        }

        private class TypeReferenceAnonymousInnerClass : TypeReference<IList<EditionDTO>>
        {
            private readonly BCISApi outerInstance;

            public TypeReferenceAnonymousInnerClass(BCISApi outerInstance)
            {
                this.outerInstance = outerInstance;
            }

        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public nomitech.bcis.dto.EditionDTO findEditionById(String paramString) throws Exception
        public virtual EditionDTO findEditionById(string paramString)
        {
            Hashtable hashMap = new Hashtable();
            hashMap["editionId"] = paramString;
            return (EditionDTO)this.objectMapper.readValue(getInputStream("findEditionById", hashMap), new TypeReferenceAnonymousInnerClass2(this));
        }

        private class TypeReferenceAnonymousInnerClass2 : TypeReference<EditionDTO>
        {
            private readonly BCISApi outerInstance;

            public TypeReferenceAnonymousInnerClass2(BCISApi outerInstance)
            {
                this.outerInstance = outerInstance;
            }

        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: @Deprecated public nomitech.bcis.dto.Assignments findItemAssignments(String paramString) throws Exception
        [Obsolete]
        public virtual Assignments findItemAssignments(string paramString)
        {
            Hashtable hashMap = new Hashtable();
            hashMap["itemId"] = paramString;
            return (Assignments)this.objectMapper.readValue(getInputStream("findItemAssignments", hashMap), new TypeReferenceAnonymousInnerClass3(this));
        }

        private class TypeReferenceAnonymousInnerClass3 : TypeReference<Assignments>
        {
            private readonly BCISApi outerInstance;

            public TypeReferenceAnonymousInnerClass3(BCISApi outerInstance)
            {
                this.outerInstance = outerInstance;
            }

        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public nomitech.bcis.dto.Assignments findSubItemAssignments(String paramString1, String paramString2) throws Exception
        public virtual Assignments findSubItemAssignments(string paramString1, string paramString2)
        {
            Hashtable hashMap = new Hashtable();
            hashMap["itemId"] = paramString1;
            hashMap["editionId"] = paramString2;
            return (Assignments)this.objectMapper.readValue(getInputStream("findSubItemAssignments", hashMap), new TypeReferenceAnonymousInnerClass4(this));
        }

        private class TypeReferenceAnonymousInnerClass4 : TypeReference<Assignments>
        {
            private readonly BCISApi outerInstance;

            public TypeReferenceAnonymousInnerClass4(BCISApi outerInstance)
            {
                this.outerInstance = outerInstance;
            }

        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public java.util.List<nomitech.bcis.dto.ItemDTO> findChapterHeadings(String paramString) throws Exception
        public virtual IList<ItemDTO> findChapterHeadings(string paramString)
        {
            Hashtable hashMap = new Hashtable();
            hashMap["editionId"] = paramString;
            return (System.Collections.IList)this.objectMapper.readValue(getInputStream("findChapterHeadings", hashMap), new TypeReferenceAnonymousInnerClass5(this));
        }

        private class TypeReferenceAnonymousInnerClass5 : TypeReference<IList<ItemDTO>>
        {
            private readonly BCISApi outerInstance;

            public TypeReferenceAnonymousInnerClass5(BCISApi outerInstance)
            {
                this.outerInstance = outerInstance;
            }

        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public java.util.List<nomitech.bcis.dto.ItemDTO> findChapterContents(String paramString) throws Exception
        public virtual IList<ItemDTO> findChapterContents(string paramString)
        {
            Hashtable hashMap = new Hashtable();
            hashMap["itemId"] = paramString;
            return (System.Collections.IList)this.objectMapper.readValue(getInputStream("findChapterContents", hashMap), new TypeReferenceAnonymousInnerClass6(this));
        }

        private class TypeReferenceAnonymousInnerClass6 : TypeReference<IList<ItemDTO>>
        {
            private readonly BCISApi outerInstance;

            public TypeReferenceAnonymousInnerClass6(BCISApi outerInstance)
            {
                this.outerInstance = outerInstance;
            }

        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public java.util.List<nomitech.bcis.dto.ItemDTO> findAncestorsOfItems(String paramString) throws Exception
        public virtual IList<ItemDTO> findAncestorsOfItems(string paramString)
        {
            Hashtable hashMap = new Hashtable();
            hashMap["itemId"] = paramString;
            return (System.Collections.IList)this.objectMapper.readValue(getInputStream("findAncestorsOfItems", hashMap), new TypeReferenceAnonymousInnerClass7(this));
        }

        private class TypeReferenceAnonymousInnerClass7 : TypeReference<IList<ItemDTO>>
        {
            private readonly BCISApi outerInstance;

            public TypeReferenceAnonymousInnerClass7(BCISApi outerInstance)
            {
                this.outerInstance = outerInstance;
            }

        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public java.util.List<nomitech.bcis.dto.ItemDTO> findSubtreeBelowItems(String paramString) throws Exception
        public virtual IList<ItemDTO> findSubtreeBelowItems(string paramString)
        {
            Hashtable hashMap = new Hashtable();
            hashMap["itemId"] = paramString;
            return (System.Collections.IList)this.objectMapper.readValue(getInputStream("findSubtreeBelowItems", hashMap), new TypeReferenceAnonymousInnerClass8(this));
        }

        private class TypeReferenceAnonymousInnerClass8 : TypeReference<IList<ItemDTO>>
        {
            private readonly BCISApi outerInstance;

            public TypeReferenceAnonymousInnerClass8(BCISApi outerInstance)
            {
                this.outerInstance = outerInstance;
            }

        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public java.util.List<nomitech.bcis.dto.ItemDTO> findItemChildren(String paramString) throws Exception
        public virtual IList<ItemDTO> findItemChildren(string paramString)
        {
            Hashtable hashMap = new Hashtable();
            hashMap["itemId"] = paramString;
            return (System.Collections.IList)this.objectMapper.readValue(getInputStream("findItemChildren", hashMap), new TypeReferenceAnonymousInnerClass9(this));
        }

        private class TypeReferenceAnonymousInnerClass9 : TypeReference<IList<ItemDTO>>
        {
            private readonly BCISApi outerInstance;

            public TypeReferenceAnonymousInnerClass9(BCISApi outerInstance)
            {
                this.outerInstance = outerInstance;
            }

        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public java.util.List<nomitech.bcis.dto.ItemDTO> searchForItems(String paramString1, String paramString2) throws Exception
        public virtual IList<ItemDTO> searchForItems(string paramString1, string paramString2)
        {
            Hashtable hashMap = new Hashtable();
            hashMap["editionId"] = paramString1;
            hashMap["searchQuery"] = paramString2;
            return (System.Collections.IList)this.objectMapper.readValue(getInputStream("searchForItems", hashMap), new TypeReferenceAnonymousInnerClass10(this));
        }

        private class TypeReferenceAnonymousInnerClass10 : TypeReference<IList<ItemDTO>>
        {
            private readonly BCISApi outerInstance;

            public TypeReferenceAnonymousInnerClass10(BCISApi outerInstance)
            {
                this.outerInstance = outerInstance;
            }

        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public java.util.List<nomitech.bcis.dto.ItemDTO> searchForItemsChapterHeadings(String paramString1, String paramString2) throws Exception
        public virtual IList<ItemDTO> searchForItemsChapterHeadings(string paramString1, string paramString2)
        {
            Hashtable hashMap = new Hashtable();
            hashMap["editionId"] = paramString1;
            hashMap["searchQuery"] = paramString2;
            return (System.Collections.IList)this.objectMapper.readValue(getInputStream("searchForItemsChapterHeadings", hashMap), new TypeReferenceAnonymousInnerClass11(this));
        }

        private class TypeReferenceAnonymousInnerClass11 : TypeReference<IList<ItemDTO>>
        {
            private readonly BCISApi outerInstance;

            public TypeReferenceAnonymousInnerClass11(BCISApi outerInstance)
            {
                this.outerInstance = outerInstance;
            }

        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public java.util.List<nomitech.bcis.dto.ItemDTO> searchForItemsChildren(String paramString1, String paramString2) throws Exception
        public virtual IList<ItemDTO> searchForItemsChildren(string paramString1, string paramString2)
        {
            Hashtable hashMap = new Hashtable();
            hashMap["itemId"] = paramString1;
            hashMap["searchQuery"] = paramString2;
            return (System.Collections.IList)this.objectMapper.readValue(getInputStream("searchForItemsChildren", hashMap), new TypeReferenceAnonymousInnerClass12(this));
        }

        private class TypeReferenceAnonymousInnerClass12 : TypeReference<IList<ItemDTO>>
        {
            private readonly BCISApi outerInstance;

            public TypeReferenceAnonymousInnerClass12(BCISApi outerInstance)
            {
                this.outerInstance = outerInstance;
            }

        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public java.util.List<nomitech.bcis.dto.ItemDTO> searchForItemsChapterContents(String paramString1, String paramString2) throws Exception
        public virtual IList<ItemDTO> searchForItemsChapterContents(string paramString1, string paramString2)
        {
            Hashtable hashMap = new Hashtable();
            hashMap["itemId"] = paramString1;
            hashMap["searchQuery"] = paramString2;
            return (System.Collections.IList)this.objectMapper.readValue(getInputStream("searchForItemsChapterContents", hashMap), new TypeReferenceAnonymousInnerClass13(this));
        }

        private class TypeReferenceAnonymousInnerClass13 : TypeReference<IList<ItemDTO>>
        {
            private readonly BCISApi outerInstance;

            public TypeReferenceAnonymousInnerClass13(BCISApi outerInstance)
            {
                this.outerInstance = outerInstance;
            }

        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public java.util.List<nomitech.bcis.dto.ItemDTO> searchForItemsAncestorsOfItem(String paramString1, String paramString2) throws Exception
        public virtual IList<ItemDTO> searchForItemsAncestorsOfItem(string paramString1, string paramString2)
        {
            Hashtable hashMap = new Hashtable();
            hashMap["itemId"] = paramString1;
            hashMap["searchQuery"] = paramString2;
            return (System.Collections.IList)this.objectMapper.readValue(getInputStream("searchForItemsAncestorsOfItem", hashMap), new TypeReferenceAnonymousInnerClass14(this));
        }

        private class TypeReferenceAnonymousInnerClass14 : TypeReference<IList<ItemDTO>>
        {
            private readonly BCISApi outerInstance;

            public TypeReferenceAnonymousInnerClass14(BCISApi outerInstance)
            {
                this.outerInstance = outerInstance;
            }

        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public java.util.List<nomitech.bcis.dto.ItemDTO> searchForItemsSubtreeBelowItem(String paramString1, String paramString2) throws Exception
        public virtual IList<ItemDTO> searchForItemsSubtreeBelowItem(string paramString1, string paramString2)
        {
            Hashtable hashMap = new Hashtable();
            hashMap["itemId"] = paramString1;
            hashMap["searchQuery"] = paramString2;
            return (System.Collections.IList)this.objectMapper.readValue(getInputStream("searchForItemsSubtreeBelowItem", hashMap), new TypeReferenceAnonymousInnerClass15(this));
        }

        private class TypeReferenceAnonymousInnerClass15 : TypeReference<IList<ItemDTO>>
        {
            private readonly BCISApi outerInstance;

            public TypeReferenceAnonymousInnerClass15(BCISApi outerInstance)
            {
                this.outerInstance = outerInstance;
            }

        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public java.util.List<nomitech.bcis.dto.ItemDTO> searchForItemsFullTree(String paramString1, String paramString2) throws Exception
        public virtual IList<ItemDTO> searchForItemsFullTree(string paramString1, string paramString2)
        {
            Hashtable hashMap = new Hashtable();
            hashMap["itemId"] = paramString1;
            hashMap["searchQuery"] = paramString2;
            return (System.Collections.IList)this.objectMapper.readValue(getInputStream("searchForItemsFullTree", hashMap), new TypeReferenceAnonymousInnerClass16(this));
        }

        private class TypeReferenceAnonymousInnerClass16 : TypeReference<IList<ItemDTO>>
        {
            private readonly BCISApi outerInstance;

            public TypeReferenceAnonymousInnerClass16(BCISApi outerInstance)
            {
                this.outerInstance = outerInstance;
            }

        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private java.io.InputStream getInputStream(String paramString, java.util.Map<String, String> paramMap) throws Exception
        private Stream getInputStream(string paramString, IDictionary<string, string> paramMap)
        {
            URL uRL = constructURL(paramString, paramMap);
            HttpURLConnection httpURLConnection = (HttpURLConnection)uRL.openConnection();
            httpURLConnection.ConnectTimeout = 4000;
            httpURLConnection.ReadTimeout = 30000;
            if (((!string.ReferenceEquals(this.username, null)) ? 1 : 0) & ((!string.ReferenceEquals(this.password, null)) ? 1 : 0))
            {
                httpURLConnection.setRequestProperty("Authorization", "Basic " + HTTPUtil.encode(this.username + ":" + this.password));
            }
            httpURLConnection.setRequestProperty("Content-Type", "application/json");
            return httpURLConnection.InputStream;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private java.net.URL constructURL(String paramString, java.util.Map<String, String> paramMap) throws Exception
        private URL constructURL(string paramString, IDictionary<string, string> paramMap)
        {
            if (paramMap == null || paramMap.Count == 0)
            {
                return new URL(this.apiBaseUrl + "/" + paramString);
            }
            StringBuilder stringBuffer = new StringBuilder();
            System.Collections.IEnumerator iterator = paramMap.Keys.GetEnumerator();
            while (iterator.MoveNext())
            {
                string str = (string)iterator.Current;
                stringBuffer.Append(str).Append("=").Append(URLEncoder.encode((string)paramMap[str], "UTF-8"));
                //JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
                if (iterator.hasNext())
                {
                    stringBuffer.Append("&");
                }
            }
            return new URL(this.apiBaseUrl + "/" + paramString + "?" + stringBuffer.ToString());
        }
    }


    //Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\bcis\api\BCISApi.class
    //Java compiler version: 8 (52.0)
    //JD-Core Version:       1.0.7
}