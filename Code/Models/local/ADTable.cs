using System;

using CryptUtil = Desktop.common.nomitech.common.util.CryptUtil;
using StringUtils = Desktop.common.nomitech.common.util.StringUtils;

namespace Models.local
{
    //#RXP_START
    /// <summary>
    /// @hibernate.class table="AD"
    /// @hibernate.cache usage="nonstrict-read-write"
    /// </summary>
    //#RXP_END
    [Serializable]
    public class ADTable
    {

        public static readonly string[] FIELDS = new string[] { "id", "profile", "type", "hostname", "baseDn", "rolesDn", "port", "isSSL", "bindDn", "password", "enable", "syncTime" };

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @DocumentId private System.Nullable<long> id;
        private long? id;
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String type;
        private string type;
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String statusMsg;
        private string statusMsg;
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String profile;
        private string profile;
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String hostname;
        private string hostname;
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private System.Nullable<int> port;
        private int? port;
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private System.Nullable<bool> isSSL;
        private bool? isSSL;
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String bindDn;
        private string bindDn;
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String searchFilter;
        private string searchFilter;
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String password;
        private string password;
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String baseDN;
        private string baseDN;
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private System.Nullable<bool> enable;
        private bool? enable;
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal syncTime;
        private decimal syncTime;

        public ADTable()
        {

        }

        /// 
        /// <summary>
        /// @hibernate.id generator-class="native" 
        ///               unsaved-value="null"
        ///               column="ID" </summary>
        /// <returns> Long </returns>
        public virtual long? Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
            }
        }


        /// <summary>
        /// @hibernate.property column="TYPE" type="java.lang.String" </summary>
        /// <returns> description </returns>

        public virtual string Type
        {
            get
            {
                return type;
            }
            set
            {
                this.type = value;
            }
        }


        /// <summary>
        /// @hibernate.property column="STATUSMSG" type="java.lang.String" </summary>
        /// <returns> description </returns>
        public virtual string StatusMsg
        {
            get
            {
                return statusMsg;
            }
            set
            {
                this.statusMsg = value;
            }
        }


        /// <summary>
        /// @hibernate.property column="PORT" type="int" </summary>
        /// <returns> description </returns>
        public virtual int? Port
        {
            get
            {
                return port;
            }
            set
            {
                this.port = value;
            }
        }


        /// <summary>
        /// @hibernate.property column="ISSSL" type="boolean" </summary>
        /// <returns> description </returns>
        public virtual bool? IsSSL
        {
            get
            {
                return isSSL;
            }
            set
            {
                this.isSSL = value;
            }
        }


        /// <summary>
        /// @hibernate.property column="BINDDN" type="java.lang.String" </summary>
        /// <returns> description </returns>
        public virtual string BindDn
        {
            get
            {
                return bindDn;
            }
            set
            {
                this.bindDn = value;
            }
        }

        /// <summary>
        /// @hibernate.property column="SEARCHFILTER" type="java.lang.String" </summary>
        /// <returns> description </returns>
        public virtual string SearchFilter
        {
            get
            {
                return searchFilter;
            }
            set
            {
                this.searchFilter = value;
            }
        }

        /// <summary>
        /// @hibernate.property column="PASSWORD" type="java.lang.String" </summary>
        /// <returns> description </returns>
        public virtual string Password
        {
            get
            {

                return password;
            }
            set
            {
                this.password = value;
            }
        }

        public virtual string DecryptedPassword
        {
            get
            {
                if (!string.ReferenceEquals(Password, null))
                {
                    return CryptUtil.Instance.decryptHexString(Password);
                }
                return null;
            }
        }

        public virtual string EncryptPassword
        {
            set
            {
                string encryptPassword = null;
                if (!StringUtils.isNullOrBlank(value))
                {
                    encryptPassword = CryptUtil.Instance.encryptHexString(value);
                }
                Password = encryptPassword;
            }
        }


        /// <summary>
        /// @hibernate.property column="BASEDN" type="java.lang.String" </summary>
        /// <returns> description </returns>
        public virtual string BaseDN
        {
            get
            {
                return baseDN;
            }
            set
            {
                this.baseDN = value;
            }
        }


        /// <summary>
        /// @hibernate.property column="ENABLE" type="boolean" </summary>
        /// <returns> description </returns>
        public virtual bool? Enable
        {
            get
            {
                return enable;
            }
            set
            {
                this.enable = value;
            }
        }


        /// <summary>
        /// @hibernate.property column="SYNCTIME" type="big_decimal" precision="30" scale="10" </summary>
        /// <returns> description </returns>
        public virtual decimal SyncTime
        {
            get
            {
                return syncTime;
            }
            set
            {
                this.syncTime = value;
            }
        }


        /// <summary>
        /// @hibernate.property column="HOSTNAME" type="java.lang.String" </summary>
        /// <returns> description </returns>
        public virtual string Hostname
        {
            get
            {
                return hostname;
            }
            set
            {
                this.hostname = value;
            }
        }


        /// <summary>
        /// @hibernate.property column="PROFILE" type="java.lang.String" </summary>
        /// <returns> description </returns>
        public virtual string Profile
        {
            get
            {
                return profile;
            }
            set
            {
                this.profile = value;
            }
        }
    }
}