namespace Desktop.common.nomitech.common
{
    using EquipmentTable = Desktop.common.nomitech.common.db.local.EquipmentTable;
    using BigDecimalFixed = Desktop.common.nomitech.common.db.types.BigDecimalFixed;

    public class BothDBPreferences : Properties
    {
        private const long serialVersionUID = 1L;

        private static BothDBPreferences s_instance = null;

        private static readonly string LOCAL_BIG_DECIMAL_SCALE = LocalDBProperties.FIELDS[6];

        private static readonly string LOCAL_BIG_DECIMAL_DIVIDER_SCALE = LocalDBProperties.FIELDS[7];

        private static readonly string LOCAL_BIG_DECIMAL_ROUND_MODE = LocalDBProperties.FIELDS[8];

        private const string PROJECT_BIG_DECIMAL_SCALE = "project.decimal.scale";

        private const string PROJECT_BIG_DECIMAL_ROUND_MODE = "project.rounding.mode";

        private const string PROJECT_BIG_DECIMAL_DIVIDER_SCALE = "project.divider.scale";

        private string DIESEL_PRICE_KEY = "DIESEL";

        private string PETROL_PRICE_KEY = "PETROL";

        private string ELECTRIC_PRICE_KEY = "ELECTRIC";

        private string OTHER_PRICE_KEY = "OTHER";

        private string DEFAULT_CURRENCY_SYMBOL = " €";

        public virtual void setFuelPriceKeys(string paramString1, string paramString2, string paramString3, string paramString4)
        {
            this.DIESEL_PRICE_KEY = paramString1;
            this.PETROL_PRICE_KEY = paramString2;
            this.ELECTRIC_PRICE_KEY = paramString3;
            this.OTHER_PRICE_KEY = paramString4;
        }

        public virtual string DefaultCurrencySymbol
        {
            set
            {
                this.DEFAULT_CURRENCY_SYMBOL = value;
            }
        }

        public virtual int BigDecimalRoundingMode
        {
            get
            {
                return (ProjectDBUtil.currentProjectDBUtil() != null && ProjectDBUtil.currentProjectDBUtil().Properties != null) ? ProjectDBUtil.currentProjectDBUtil().Properties.getIntProperty("project.rounding.mode") : ((DatabaseDBUtil.CurrentDBUtil == null) ? 4 : DatabaseDBUtil.Properties.getIntProperty(LOCAL_BIG_DECIMAL_ROUND_MODE));
            }
        }

        public virtual int BigDecimalScale
        {
            get
            {
                return (ProjectDBUtil.currentProjectDBUtil() != null && ProjectDBUtil.currentProjectDBUtil().Properties != null) ? ProjectDBUtil.currentProjectDBUtil().Properties.getIntProperty("project.decimal.scale") : ((DatabaseDBUtil.CurrentDBUtil == null) ? 2 : DatabaseDBUtil.Properties.getIntProperty(LOCAL_BIG_DECIMAL_SCALE));
            }
        }

        public virtual int BigDecimalDividerScale
        {
            get
            {
                return (ProjectDBUtil.currentProjectDBUtil() != null && ProjectDBUtil.currentProjectDBUtil().Properties != null) ? ProjectDBUtil.currentProjectDBUtil().Properties.getIntProperty("project.divider.scale") : DatabaseDBUtil.Properties.getIntProperty(LOCAL_BIG_DECIMAL_DIVIDER_SCALE);
            }
        }

        public virtual bool hasCustomFuelPrices()
        {
            return (ProjectDBUtil.currentProjectDBUtil() != null) ? ProjectDBUtil.currentProjectDBUtil().Properties.getBooleanProperty("project.energy.prices.use") : 0;
        }

        public virtual decimal getCustomFuelPrice(EquipmentTable paramEquipmentTable)
        {
            if (paramEquipmentTable.FuelType.Equals(this.DIESEL_PRICE_KEY))
            {
                string str = ProjectDBUtil.currentProjectDBUtil().Properties.getProperty("project.diesel.price");
                return new BigDecimalFixed(str);
            }
            if (paramEquipmentTable.FuelType.Equals(this.OTHER_PRICE_KEY))
            {
                string str = ProjectDBUtil.currentProjectDBUtil().Properties.getProperty("project.other.energy.price");
                return new BigDecimalFixed(str);
            }
            if (paramEquipmentTable.FuelType.Equals(this.ELECTRIC_PRICE_KEY))
            {
                string str = ProjectDBUtil.currentProjectDBUtil().Properties.getProperty("project.electricity.price");
                return new BigDecimalFixed(str);
            }
            if (paramEquipmentTable.FuelType.Equals(this.PETROL_PRICE_KEY))
            {
                string str = ProjectDBUtil.currentProjectDBUtil().Properties.getProperty("project.petrol.price");
                return new BigDecimalFixed(str);
            }
            return null;
        }

        public virtual string CurrencySymbol
        {
            get
            {
                return (ProjectDBUtil.currentProjectDBUtil() != null) ? ProjectDBUtil.currentProjectDBUtil().Properties.getProperty("project.currency.symbol") : this.DEFAULT_CURRENCY_SYMBOL;
            }
        }

        public static BothDBPreferences Instance
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = new BothDBPreferences();
                }
                return s_instance;
            }
        }
    }

    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\BothDBPreferences.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}