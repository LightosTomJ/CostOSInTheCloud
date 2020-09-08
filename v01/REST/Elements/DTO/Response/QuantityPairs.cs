using System.Collections.Generic;

namespace REST.Elements.DTO.Response.Elements
{
    public static class QuantityPairs
    {
        public static Dictionary<string, Quantity.Type> Types = new Dictionary<string, Quantity.Type>()
        {
            { "CalcBottomElevation", Quantity.Type.LENGTH },
            { "CalcFootprintPerimeter", Quantity.Type.LENGTH },
            { "CalcHeight", Quantity.Type.LENGTH },
            { "CalcLength", Quantity.Type.LENGTH },
            { "CalcOpeningsPerimeter", Quantity.Type.LENGTH },
            { "CalcTopElevation", Quantity.Type.LENGTH },
            { "CalcWidth", Quantity.Type.LENGTH },
            { "CalcAllSidesGrossArea", Quantity.Type.AREA },
            { "CalcAllSidesNetArea", Quantity.Type.AREA },
            { "CalcDoorsArea", Quantity.Type.AREA },
            { "CalcFootprintGrossArea", Quantity.Type.AREA },
            { "CalcFootprintNetArea", Quantity.Type.AREA },
            { "CalcOpeningsArea", Quantity.Type.AREA },
            { "CalcSideGrossArea", Quantity.Type.AREA },
            { "CalcSideNetArea", Quantity.Type.AREA },
            { "CalcVoidsArea", Quantity.Type.AREA },
            { "CalcWindowsArea", Quantity.Type.AREA },
            { "CalcGrossVolume", Quantity.Type.VOLUME },
            { "CalcNetVolume", Quantity.Type.VOLUME }
        };
    }
}
