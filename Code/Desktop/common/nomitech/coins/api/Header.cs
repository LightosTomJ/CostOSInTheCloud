using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.coins.api
{

    public class Header
    {
        private string id;

        private string msgID;

        private string action;

        private string entity;

        private bool? testMsg;

        private string userID;

        private string from;

        private string hostname;

        private string environment;

        private string created;

        private string version;

        private string user;

        private string password;

        private IList<Body> body = new List<Body>();

        private IDictionary<string, object> additionalProperties = new Dictionary<string, object>();

        public virtual string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }


        public virtual string MsgID
        {
            get
            {
                return this.msgID;
            }
            set
            {
                this.msgID = value;
            }
        }


        public virtual string Action
        {
            get
            {
                return this.action;
            }
            set
            {
                this.action = value;
            }
        }


        public virtual string Entity
        {
            get
            {
                return this.entity;
            }
            set
            {
                this.entity = value;
            }
        }


        public virtual bool? TestMsg
        {
            get
            {
                return this.testMsg;
            }
            set
            {
                this.testMsg = value;
            }
        }


        public virtual string UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                this.userID = value;
            }
        }


        public virtual string From
        {
            get
            {
                return this.from;
            }
            set
            {
                this.from = value;
            }
        }


        public virtual string Hostname
        {
            get
            {
                return this.hostname;
            }
            set
            {
                this.hostname = value;
            }
        }


        public virtual string Environment
        {
            get
            {
                return this.environment;
            }
            set
            {
                this.environment = value;
            }
        }


        public virtual string Created
        {
            get
            {
                return this.created;
            }
            set
            {
                this.created = value;
            }
        }


        public virtual string Version
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
            }
        }


        public virtual string User
        {
            get
            {
                return this.user;
            }
            set
            {
                this.user = value;
            }
        }


        public virtual string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }


        public virtual IList<Body> Body
        {
            get
            {
                return this.body;
            }
            set
            {
                this.body = value;
            }
        }


        public virtual IDictionary<string, object> AdditionalProperties
        {
            get
            {
                return this.additionalProperties;
            }
        }

        public virtual void setAdditionalProperty(string paramString, object paramObject)
        {
            this.additionalProperties[paramString] = paramObject;
        }
    }

    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\coins\api\Header.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}