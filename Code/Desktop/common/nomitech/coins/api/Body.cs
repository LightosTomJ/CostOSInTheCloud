using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.coins.api
{
    public class Body
    {
        private string dummy;

        private IDictionary<string, object> additionalProperties = new Dictionary<string, object>();

        public virtual string Dummy
        {
            get
            {
                return this.dummy;
            }
            set
            {
                this.dummy = value;
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


    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\coins\api\Body.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}