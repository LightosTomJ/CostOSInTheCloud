using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.coins.api
{

    public class Coins
    {
        private IList<Header> header = new List<Header>();

        private IDictionary<string, object> additionalProperties = new Dictionary<string, object>();

        public virtual IList<Header> Header
        {
            get
            {
                return this.header;
            }
            set
            {
                this.header = value;
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

    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\coins\api\Coins.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}