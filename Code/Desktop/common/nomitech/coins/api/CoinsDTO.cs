using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.coins.api
{
    using JsonSerialize = Desktop.common.com.fasterxml.jackson.databind.annotation.JsonSerialize;

    //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
    //ORIGINAL LINE: @JsonSerialize(include = JsonSerialize.Inclusion.NON_NULL) public class CoinsDTO
    public class CoinsDTO
    {
        private Coins coins;

        private IDictionary<string, object> additionalProperties = new Dictionary<string, object>();

        public virtual Coins Coins
        {
            get
            {
                return this.coins;
            }
            set
            {
                this.coins = value;
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

    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\coins\api\CoinsDTO.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}