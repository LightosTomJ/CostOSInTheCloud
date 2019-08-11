namespace Desktop.common.nomitech.common.ifc
{
	public class IfcEngineUnit
	{
	  public const int ABSORBEDDOSEUNIT = 101;

	  public const int AREAUNIT = 102;

	  public const int DOSEEQUIVALENTUNIT = 103;

	  public const int ELECTRICCAPACITANCEUNIT = 104;

	  public const int ELECTRICCHARGEUNIT = 105;

	  public const int ELECTRICCONDUCTANCEUNIT = 106;

	  public const int ELECTRICCURRENTUNIT = 107;

	  public const int ELECTRICRESISTANCEUNIT = 108;

	  public const int ELECTRICVOLTAGEUNIT = 109;

	  public const int ENERGYUNIT = 110;

	  public const int FORCEUNIT = 111;

	  public const int FREQUENCYUNIT = 112;

	  public const int ILLUMINANCEUNIT = 113;

	  public const int INDUCTANCEUNIT = 114;

	  public const int LENGTHUNIT = 115;

	  public const int LUMINOUSFLUXUNIT = 116;

	  public const int LUMINOUSINTENSITYUNIT = 117;

	  public const int MAGNETICFLUXDENSITYUNIT = 118;

	  public const int MAGNETICFLUXUNIT = 119;

	  public const int MASSUNIT = 120;

	  public const int PLANEANGLEUNIT = 121;

	  public const int POWERUNIT = 122;

	  public const int PRESSUREUNIT = 123;

	  public const int RADIOACTIVITYUNIT = 124;

	  public const int SOLIDANGLEUNIT = 125;

	  public const int THERMODYNAMICTEMPERATUREUNIT = 126;

	  public const int TIMEUNIT = 127;

	  public const int VOLUMEUNIT = 128;

	  public const int USERDEFINED = 129;

	  private int type;

	  private string prefix;

	  private string name;

	  private string unitType;

	  private double conversionFactor;

	  public IfcEngineUnit()
	  {
	  }

	  public IfcEngineUnit(int paramInt, string paramString1, double paramDouble, string paramString2)
	  {
		this.type = paramInt;
		this.prefix = paramString1;
		this.conversionFactor = paramDouble;
		this.name = paramString2;
	  }

	  public virtual double ConversionFactor
	  {
		  get
		  {
			  return this.conversionFactor;
		  }
		  set
		  {
			  this.conversionFactor = value;
		  }
	  }


	  public virtual int Type
	  {
		  get
		  {
			  return this.type;
		  }
		  set
		  {
			  this.type = value;
		  }
	  }


	  public virtual string UnitType
	  {
		  get
		  {
			  return this.unitType;
		  }
		  set
		  {
			  this.unitType = value;
		  }
	  }


	  public virtual string Prefix
	  {
		  get
		  {
			  return this.prefix;
		  }
	  }

	  public virtual void setPrefix(string paramString, double paramDouble)
	  {
		this.prefix = paramString;
		this.conversionFactor = paramDouble;
	  }

	  public virtual string Name
	  {
		  get
		  {
			  return this.name;
		  }
		  set
		  {
			  this.name = value;
		  }
	  }


	  public override string ToString()
	  {
		  return "Type: " + this.type + ", Prefix: " + this.prefix + " (" + this.conversionFactor + "), Name: " + this.name;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ifc\IfcEngineUnit.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}