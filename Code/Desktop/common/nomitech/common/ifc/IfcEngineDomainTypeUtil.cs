using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.ifc
{

	public class IfcEngineDomainTypeUtil
	{
		private bool InstanceFieldsInitialized = false;

		private void InitializeInstanceFields()
		{
			AIR_CONDITIONING_TYPES = mergeTypes(this.GENERAL_BS_TYPES, new string[] {"IfcPipeSegmentType", "IfcDuctSegmentType", "IfcSensorType", "IfcUnitaryEquipmentType", "IfcAirTerminalType", "IfcAirTerminalBoxType", "IfcAirToAirHeatRecoveryType", "IfcSpaceHeaterType", "IfcChillerType", "IfcCoilType", "IfcCompressorType", "IfcFilterType", "IfcValveType", "IfcCondenserType", "IfcCooledBeamType", "IfcCoolingTowerType", "IfcDamperType", "IfcDistributionChamberElementType", "IfcDistributionControlElementType", "IfcDistributionElementType", "IfcDistributionFlowElementType", "IfcDuctFittingType", "IfcDuctSilencerType", "IfcFlowMeterType", "IfcFanType", "IfcEvaporativeCoolerType", "IfcEvaporatorType", "IfcHeatExchangerType", "IfcHumidifierType", "IfcTubeBundleType"});
			ELECTRICAL_TYPES = mergeTypes(this.GENERAL_BS_TYPES, new string[] {"IfcCableSegmentType", "IfcCableCarrierSegmentType", "IfcFireSuppressionTerminalType", "IfcAlarmType", "IfcOutletType", "IfcElectricFlowStorageDeviceType", "IfcCableCarrierFittingType", "IfcProtectiveDeviceType", "IfcElectricApplianceType", "IfcElectricGeneratorType", "IfcElectricHeaterType", "IfcElectricMotorType", "IfcElectricTimeControlType", "IfcJunctionBoxType", "IfcLampType", "IfcLightFixtureType", "IfcMotorConnectionType", "IfcSwitchingDeviceType", "IfcTransformerType"});
			HEAT_TYPES = mergeTypes(this.GENERAL_BS_TYPES, new string[] {"IfcPipeSegmentType", "IfcDuctSegmentType", "IfcUnitaryEquipmentType", "IfcAirToAirHeatRecoveryType", "IfcSpaceHeaterType", "IfcBoilerType", "IfcValveType", "IfcDistributionChamberElementType", "IfcDistributionControlElementType", "IfcDistributionElementType", "IfcDistributionFlowElementType", "IfcPumpType", "IfcFlowMeterType", "IfcGasTerminalType", "IfcHeatExchangerType", "IfcTankType", "IfcPipeFittingType", "IfcTubeBundleType"});
			VENTILATION_TYPES = mergeTypes(this.GENERAL_BS_TYPES, new string[] {"IfcPipeSegmentType", "IfcDuctSegmentType", "IfcStackTerminalType", "IfcAirTerminalType", "IfcAirTerminalBoxType", "IfcAirToAirHeatRecoveryType", "IfcCompressorType", "IfcFilterType", "IfcValveType", "IfcCondenserType", "IfcDamperType", "IfcDistributionChamberElementType", "IfcDistributionControlElementType", "IfcDistributionElementType", "IfcDistributionFlowElementType", "IfcDuctFittingType", "IfcDuctSilencerType", "IfcFlowMeterType", "IfcFanType", "IfcHeatExchangerType", "IfcHumidifierType"});
			PLUMBING_TYPES = mergeTypes(this.GENERAL_BS_TYPES, new string[] {"IfcPipeSegmentType", "IfcWasteTerminalType", "IfcDuctSegmentType", "IfcFireSuppressionTerminalType", "IfcOutletType", "IfcBoilerType", "IfcFilterType", "IfcValveType", "IfcDistributionChamberElementType", "IfcDistributionControlElementType", "IfcDistributionElementType", "IfcDistributionFlowElementType", "IfcPumpType", "IfcFlowMeterType", "IfcGasTerminalType", "IfcTankType", "IfcPipeFittingType"});
			SPRINKLER_TYPES = mergeTypes(this.GENERAL_BS_TYPES, new string[] {"IfcOutletType", "IfcBoilerType", "IfcProtectiveDeviceType", "IfcFilterType", "IfcValveType", "IfcDistributionChamberElementType", "IfcDistributionControlElementType", "IfcDistributionElementType", "IfcDistributionFlowElementType", "IfcPumpType", "IfcFlowMeterType", "IfcTankType", "IfcPipeFittingType"});
		}

	  private Color AIRCONDITION_COLOR = new Color(200, 100, 100);

	  private Color ELECTRICAL_COLOR = new Color(100, 200, 100);

	  private Color PLUMBING_COLOR = new Color(100, 100, 200);

	  private Color HEATING_COLOR = new Color(200, 200, 100);

	  private Color OTHER_COLOR = Color.GRAY;

	  private readonly string[] ARCHITECTURE_TYPES = new string[] {"IfcBuildingElementProxyType", "IfcSpaceType", "IfcDoorStyle", "IfcRailingType", "IfcCoveringType", "IfcSlabType", "IfcBeamType", "IfcWallType", "IfcColumnType", "IfcCurtainWallType", "IfcFurnitureType", "IfcWindowStyle", "IfcLightFixtureType"};

	  private readonly string[] GENERAL_BS_TYPES = new string[] {"IfcSystemFurnitureElementType", "IfcFurnishingElementType", "IfcTransportElementType", "IfcControllerType", "IfcSanitaryTerminalType", "IfcDiscreteAccessoryType", "IfcFlowInstrumentType", "IfcActuatorType", "IfcUnitaryEquipmentType", "IfcFlowControllerType", "IfcFlowFittingType", "IfcFlowMovingDeviceType", "IfcFlowSegmentType", "IfcFlowStorageDeviceType", "IfcFlowTerminalType", "IfcFlowTreatmentDeviceType"};

	  private string[] AIR_CONDITIONING_TYPES;

	  private string[] ELECTRICAL_TYPES;

	  private string[] HEAT_TYPES;

	  private readonly string[] STRUCTURAL_TYPES = new string[] {"IfcFastenerType", "IfcMechanicalFastenerType", "IfcSlabType", "IfcBeamType", "IfcMemberType", "IfcWallType", "IfcColumnType", "IfcPlateType"};

	  private string[] VENTILATION_TYPES;

	  private string[] PLUMBING_TYPES;

	  private string[] SPRINKLER_TYPES;

	  private readonly string[] LANDSCAPE_TYPES = new string[] {"IfcRailingType", "IfcSlabType", "IfcBeamType", "IfcWallType", "IfcColumnType", "IfcCurtainWallType", "IfcLightFixtureType"};

	  private IDictionary<string, HashSet<string>> typeClassificationMap = new Hashtable();

	  private IDictionary<string, BuildingElementInfo> typeNameMap = new Hashtable();

	  public virtual bool isArchitecture(string paramString)
	  {
		  return ((HashSet<object>)this.typeClassificationMap["ARCHITECTURE_TYPES"]).Contains(paramString);
	  }

	  public virtual bool isStructural(string paramString)
	  {
		  return ((HashSet<object>)this.typeClassificationMap["STRUCTURAL_TYPES"]).Contains(paramString);
	  }

	  public virtual bool isGeneral(string paramString)
	  {
		  return ((HashSet<object>)this.typeClassificationMap["GENERAL_BS_TYPES"]).Contains(paramString);
	  }

	  public virtual bool isAirconditioning(string paramString)
	  {
		  return ((HashSet<object>)this.typeClassificationMap["AIR_CONDITIONING_TYPES"]).Contains(paramString);
	  }

	  public virtual bool isElectrical(string paramString)
	  {
		  return ((HashSet<object>)this.typeClassificationMap["ELECTRICAL_TYPES"]).Contains(paramString);
	  }

	  public virtual bool isHeat(string paramString)
	  {
		  return ((HashSet<object>)this.typeClassificationMap["HEAT_TYPES"]).Contains(paramString);
	  }

	  public virtual bool isVentilation(string paramString)
	  {
		  return ((HashSet<object>)this.typeClassificationMap["VENTILATION_TYPES"]).Contains(paramString);
	  }

	  public virtual bool isPlumbing(string paramString)
	  {
		  return ((HashSet<object>)this.typeClassificationMap["PLUMBING_TYPES"]).Contains(paramString);
	  }

	  public virtual bool isSprinkler(string paramString)
	  {
		  return ((HashSet<object>)this.typeClassificationMap["SPRINKLER_TYPES"]).Contains(paramString);
	  }

	  public virtual bool isLandscape(string paramString)
	  {
		  return ((HashSet<object>)this.typeClassificationMap["LANDSCAPE_TYPES"]).Contains(paramString);
	  }

	  private string[] mergeTypes(string[] paramArrayOfString1, string[] paramArrayOfString2)
	  {
		HashSet<object> hashSet = new HashSet<object>(2 * (paramArrayOfString1.Length + paramArrayOfString2.Length));
		hashSet.addAll(Arrays.asList(paramArrayOfString1));
		hashSet.addAll(Arrays.asList(paramArrayOfString2));
		return (string[])hashSet.toArray(new string[hashSet.Count]);
	  }

	  public IfcEngineDomainTypeUtil(string paramString)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		this.typeClassificationMap["ARCHITECTURE_TYPES"] = new HashSet<object>(Arrays.asList(this.ARCHITECTURE_TYPES));
		this.typeClassificationMap["GENERAL_BS_TYPES"] = new HashSet<object>(Arrays.asList(this.GENERAL_BS_TYPES));
		this.typeClassificationMap["AIR_CONDITIONING_TYPES"] = new HashSet<object>(Arrays.asList(this.AIR_CONDITIONING_TYPES));
		this.typeClassificationMap["ELECTRICAL_TYPES"] = new HashSet<object>(Arrays.asList(this.ELECTRICAL_TYPES));
		this.typeClassificationMap["HEAT_TYPES"] = new HashSet<object>(Arrays.asList(this.HEAT_TYPES));
		this.typeClassificationMap["STRUCTURAL_TYPES"] = new HashSet<object>(Arrays.asList(this.STRUCTURAL_TYPES));
		this.typeClassificationMap["VENTILATION_TYPES"] = new HashSet<object>(Arrays.asList(this.VENTILATION_TYPES));
		this.typeClassificationMap["PLUMBING_TYPES"] = new HashSet<object>(Arrays.asList(this.PLUMBING_TYPES));
		this.typeClassificationMap["SPRINKLER_TYPES"] = new HashSet<object>(Arrays.asList(this.SPRINKLER_TYPES));
		this.typeClassificationMap["LANDSCAPE_TYPES"] = new HashSet<object>(Arrays.asList(this.LANDSCAPE_TYPES));
		putClassAndType("Building Element Proxy", "IfcBuildingElementProxy", "IfcBuildingElementProxyType", true, this.OTHER_COLOR);
		putClassAndType("Actuator", "IfcDistributionControlElement", "IfcActuatorType", true, this.OTHER_COLOR);
		putClassAndType("Unitary Equipment", "IfcEnergyConversionDevice", "IfcUnitaryEquipmentType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Air Terminal", "IfcFlowTerminal", "IfcAirTerminalType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Air Terminal Box", "IfcDistributionFlowElement", "IfcAirTerminalBoxType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Air To Air Heat Recovery", "IfcEnergyConversionDevice", "IfcAirToAirHeatRecoveryType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Alarm", "IfcDistributionControlElement", "IfcAlarmType", true, this.OTHER_COLOR);
		putClassAndType("Flow Instrument", "IfcDistributionControlElement", "IfcFlowInstrumentType", true, this.OTHER_COLOR);
		putClassAndType("Discrete Accessory", "IfcDiscreteAccessory", "IfcDiscreteAccessoryType", true, this.OTHER_COLOR);
		putClassAndType("Space", "IfcSpace", "IfcSpaceType", true, this.OTHER_COLOR);
		putClassAndType("Outlet", "IfcFlowTerminal", "IfcOutletType", true, this.ELECTRICAL_COLOR);
		putClassAndType("Door", "IfcDoor", "IfcDoorStyle", true, this.OTHER_COLOR);
		putClassAndType("Railing", "IfcRailing", "IfcRailingType", false, this.OTHER_COLOR);
		putClassAndType("Covering", "IfcCovering", "IfcCoveringType", false, this.OTHER_COLOR);
		putClassAndType("Space Heater", "IfcEnergyConversionDevice", "IfcSpaceHeaterType", true, this.HEATING_COLOR);
		putClassAndType("Slab", "IfcSlab", "IfcSlabType", false, this.OTHER_COLOR);
		putClassAndType("Sanitary Terminal", "IfcFlowTerminal", "IfcSanitaryTerminalType", true, this.OTHER_COLOR);
		putClassAndType("Electric Flow Storage Device", "IfcEnergyConversionDevice", "IfcElectricFlowStorageDeviceType", true, this.ELECTRICAL_COLOR);
		putClassAndType("Beam", "IfcBeam", "IfcBeamType", false, this.OTHER_COLOR);
		putClassAndType("Controller", "IfcDistributionControlElement", "IfcControllerType", true, this.OTHER_COLOR);
		putClassAndType("Boiler", "IfcEnergyConversionDevice", "IfcBoilerType", true, this.HEATING_COLOR);
		putClassAndType("Mechanical Fastener", "IfcMechanicalFastener", "IfcMechanicalFastenerType", false, this.OTHER_COLOR);
		putClassAndType("Member", "IfcMember", "IfcMemberType", false, this.OTHER_COLOR);
		putClassAndType("Fire Suppression Terminal", "IfcFlowTerminal", "IfcFireSuppressionTerminalType", true, this.OTHER_COLOR);
		putClassAndType("Wall", "IfcWall", "IfcWallType", false, this.OTHER_COLOR);
		putClassAndType("Cable Carrier Fitting", "IfcFlowFitting", "IfcCableCarrierFittingType", false, this.ELECTRICAL_COLOR);
		putClassAndType("Cable Carrier Segment", "IfcFlowSegment", "IfcCableCarrierSegmentType", false, this.OTHER_COLOR);
		putClassAndType("Cable Segment", "IfcFlowSegment", "IfcCableSegmentType", false, this.OTHER_COLOR);
		putClassAndType("Chiller", "IfcEnergyConversionDevice", "IfcChillerType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Protective Device", "IfcFlowController", "IfcProtectiveDeviceType", true, this.ELECTRICAL_COLOR);
		putClassAndType("Sensor", "IfcDistributionControlElement", "IfcSensorType", true, this.OTHER_COLOR);
		putClassAndType("Coil", "IfcEnergyConversionDevice", "IfcCoilType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Column", "IfcColumn", "IfcColumnType", false, this.OTHER_COLOR);
		putClassAndType("Compressor", "IfcFlowMovingDevice", "IfcCompressorType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Filter", "IfcFlowTreatmentDevice", "IfcFilterType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Valve", "IfcFlowController", "IfcValveType", true, this.PLUMBING_COLOR);
		putClassAndType("Electric Appliance", "IfcFlowTerminal", "IfcElectricApplianceType", true, this.ELECTRICAL_COLOR);
		putClassAndType("Condenser", "IfcEnergyConversionDevice", "IfcCondenserType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Cooled Beam", "IfcEnergyConversionDevice", "IfcCooledBeamType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Cooling Tower", "IfcEnergyConversionDevice", "IfcCoolingTowerType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Stack Terminal", "IfcFlowTerminal", "IfcStackTerminalType", true, this.OTHER_COLOR);
		putClassAndType("Curtain Wall", "IfcCurtainWall", "IfcCurtainWallType", false, this.OTHER_COLOR);
		putClassAndType("Plate", "IfcPlate", "IfcPlateType", false, this.OTHER_COLOR);
		putClassAndType("Damper", "IfcFlowController", "IfcDamperType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Distribution Chamber Element", "IfcDistributionChamberElement", "IfcDistributionChamberElementType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Distribution Control Element", "IfcDistributionControlElement", "IfcDistributionControlElementType", true, this.OTHER_COLOR);
		putClassAndType("Distribution Element", "IfcDistributionElement", "IfcDistributionElementType", true, this.OTHER_COLOR);
		putClassAndType("Distribution Flow Element", "IfcDistributionElement", "IfcDistributionFlowElementType", true, this.OTHER_COLOR);
		putClassAndType("Pump", "IfcFlowMovingDevice", "IfcPumpType", true, this.PLUMBING_COLOR);
		putClassAndType("Duct Segment", "IfcFlowSegment", "IfcDuctSegmentType", false, this.OTHER_COLOR);
		putClassAndType("Duct Fitting", "IfcFlowFitting", "IfcDuctFittingType", false, this.AIRCONDITION_COLOR);
		putClassAndType("Duct Silencer", "IfcFlowTreatmentDevice", "IfcDuctSilencerType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Electric Generator", "IfcEnergyConversionDevice", "IfcElectricGeneratorType", true, this.ELECTRICAL_COLOR);
		putClassAndType("Electric Heater", "IfcFlowTerminal", "IfcElectricHeaterType", true, this.ELECTRICAL_COLOR);
		putClassAndType("Flow Meter", "IfcDistributionFlowElement", "IfcFlowMeterType", true, this.OTHER_COLOR);
		putClassAndType("Electric Motor", "IfcEnergyConversionDevice", "IfcElectricMotorType", true, this.ELECTRICAL_COLOR);
		putClassAndType("Electric Time Control", "IfcDistributionControlElement", "IfcElectricTimeControlType", true, this.ELECTRICAL_COLOR);
		putClassAndType("Transport Element", "IfcTransportElement", "IfcTransportElementType", true, this.OTHER_COLOR);
		putClassAndType("Fan", "IfcFlowMovingDevice", "IfcFanType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Evaporative Cooler", "IfcEnergyConversionDevice", "IfcEvaporativeCoolerType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Evaporator", "IfcEnergyConversionDevice", "IfcEvaporatorType", true, this.OTHER_COLOR);
		putClassAndType("Fastener", "IfcFastener", "IfcFastenerType", false, this.OTHER_COLOR);
		putClassAndType("Flow Controller", "IfcFlowController", "IfcFlowControllerType", true, this.OTHER_COLOR);
		putClassAndType("Flow Fitting", "IfcFlowFitting", "IfcFlowFittingType", false, this.OTHER_COLOR);
		putClassAndType("Flow Moving Device", "IfcFlowMovingDevice", "IfcFlowMovingDeviceType", true, this.OTHER_COLOR);
		putClassAndType("Flow Segment", "IfcFlowSegment", "IfcFlowSegmentType", false, this.OTHER_COLOR);
		putClassAndType("Flow Storage Device", "IfcFlowStorageDevice", "IfcFlowStorageDeviceType", true, this.OTHER_COLOR);
		putClassAndType("Flow Terminal", "IfcFlowTerminal", "IfcFlowTerminalType", true, this.OTHER_COLOR);
		putClassAndType("Waste Terminal", "IfcFlowTerminal", "IfcWasteTerminalType", true, this.OTHER_COLOR);
		putClassAndType("Flow Treatment Device", "IfcFlowTreatmentDevice", "IfcFlowTreatmentDeviceType", true, this.OTHER_COLOR);
		putClassAndType("Furniture", "IfcFurnishingElement", "IfcFurnitureType", true, this.OTHER_COLOR);
		putClassAndType("Furnishing Element", "IfcFurnishingElement", "IfcFurnishingElementType", true, this.OTHER_COLOR);
		putClassAndType("System Furniture Element", "IfcFurnishingElement", "IfcSystemFurnitureElementType", true, this.OTHER_COLOR);
		putClassAndType("Gas Terminal", "IfcFlowTerminal", "IfcGasTerminalType", true, this.OTHER_COLOR);
		putClassAndType("Window", "IfcWindow", "IfcWindowStyle", true, this.OTHER_COLOR);
		putClassAndType("Pipe Segment", "IfcFlowSegment", "IfcPipeSegmentType", false, this.OTHER_COLOR);
		putClassAndType("Heat Exchanger", "IfcEnergyConversionDevice", "IfcHeatExchangerType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Humidifier", "IfcEnergyConversionDevice", "IfcHumidifierType", true, this.AIRCONDITION_COLOR);
		putClassAndType("Junction Box", "IfcFlowFitting", "IfcJunctionBoxType", false, this.ELECTRICAL_COLOR);
		putClassAndType("Lamp", "IfcFlowTerminal", "IfcLampType", true, this.ELECTRICAL_COLOR);
		putClassAndType("Light Fixture", "IfcFlowTerminal", "IfcLightFixtureType", true, this.OTHER_COLOR);
		putClassAndType("Motor Connection", "IfcEnergyConversionDevice", "IfcMotorConnectionType", true, this.ELECTRICAL_COLOR);
		putClassAndType("Switching Device", "IfcFlowController", "IfcSwitchingDeviceType", true, this.ELECTRICAL_COLOR);
		putClassAndType("Tank", "IfcFlowStorageDevice", "IfcTankType", true, this.HEATING_COLOR);
		putClassAndType("Pipe Fitting", "IfcFlowFitting", "IfcPipeFittingType", false, this.PLUMBING_COLOR);
		putClassAndType("Ramp Flight", "IfcRampFlight", "IfcRampFlightType", false, this.OTHER_COLOR);
		putClassAndType("Stair Flight", "IfcStairFlight", "IfcStairFlightType", false, this.OTHER_COLOR);
		putClassAndType("Transformer", "IfcEnergyConversionDevice", "IfcTransformerType", true, this.ELECTRICAL_COLOR);
		putClassAndType("Tube Bundle", "IfcEnergyConversionDevice", "IfcTubeBundleType", true, this.HEATING_COLOR);
		putClassAndType("Vibration Isolator", "IfcDiscreteAccessory", "IfcVibrationIsolatorType", false, this.OTHER_COLOR);
	  }

	  private void putClassAndType(string paramString1, string paramString2, string paramString3, bool paramBoolean, Color paramColor)
	  {
		BuildingElementInfo buildingElementInfo = new BuildingElementInfo(paramString1, paramString2, paramString3, paramBoolean, paramColor);
		buildingElementInfo.Architecture = isAirconditioning(paramString3);
		buildingElementInfo.Structural = isStructural(paramString3);
		buildingElementInfo.Electrical = isElectrical(paramString3);
		buildingElementInfo.Heating = isHeat(paramString3);
		buildingElementInfo.Plumbing = isPlumbing(paramString3);
		buildingElementInfo.Sprinkler = isSprinkler(paramString3);
		buildingElementInfo.Landscaping = isLandscape(paramString3);
		buildingElementInfo.Ventilation = isVentilation(paramString3);
		this.typeNameMap[paramString3.ToUpper()] = buildingElementInfo;
	  }

	  public virtual BuildingElementInfo getDistributionElementInfo(string paramString)
	  {
		BuildingElementInfo buildingElementInfo = (BuildingElementInfo)this.typeNameMap[paramString];
		if (buildingElementInfo == null)
		{
		  buildingElementInfo = (BuildingElementInfo)this.typeNameMap["IfcDistributionElementType".ToUpper()];
		}
		return buildingElementInfo;
	  }

	  public virtual BuildingElementInfo getBuildingElementInfo(string paramString)
	  {
		BuildingElementInfo buildingElementInfo = (BuildingElementInfo)this.typeNameMap[paramString];
		if (buildingElementInfo == null)
		{
		  buildingElementInfo = (BuildingElementInfo)this.typeNameMap["IfcBuildingElementProxyType".ToUpper()];
		}
		return buildingElementInfo;
	  }

	  public class BuildingElementInfo
	  {
		internal string description;

		internal string classification;

		internal string typeClass;

		internal bool coBiee;

		internal Color color;

		internal bool plumbing = false;

		internal bool architecture = false;

		internal bool landscaping = false;

		internal bool airconditioning = false;

		internal bool heating = false;

		internal bool electrical = false;

		internal bool sprinkler = false;

		internal bool structural = false;

		internal bool ventilation = false;

		public BuildingElementInfo(string param1String1, string param1String2, string param1String3, bool param1Boolean, Color param1Color)
		{
		  this.description = param1String1;
		  this.classification = param1String2;
		  this.typeClass = param1String3;
		  this.coBiee = param1Boolean;
		  this.color = param1Color;
		}

		public virtual string Description
		{
			get
			{
				return this.description;
			}
			set
			{
				this.description = value;
			}
		}


		public virtual string Classification
		{
			get
			{
				return this.classification;
			}
			set
			{
				this.classification = value;
			}
		}


		public virtual string TypeClass
		{
			get
			{
				return this.typeClass;
			}
			set
			{
				this.typeClass = value;
			}
		}


		public virtual bool CoBiee
		{
			get
			{
				return this.coBiee;
			}
			set
			{
				this.coBiee = value;
			}
		}


		public virtual Color Color
		{
			get
			{
				return this.color;
			}
			set
			{
				this.color = value;
			}
		}


		public virtual bool Plumbing
		{
			get
			{
				return this.plumbing;
			}
			set
			{
				this.plumbing = value;
			}
		}


		public virtual bool Architecture
		{
			get
			{
				return this.architecture;
			}
			set
			{
				this.architecture = value;
			}
		}


		public virtual bool Landscaping
		{
			get
			{
				return this.landscaping;
			}
			set
			{
				this.landscaping = value;
			}
		}


		public virtual bool Airconditioning
		{
			get
			{
				return this.airconditioning;
			}
			set
			{
				this.airconditioning = value;
			}
		}


		public virtual bool Heating
		{
			get
			{
				return this.heating;
			}
			set
			{
				this.heating = value;
			}
		}


		public virtual bool Electrical
		{
			get
			{
				return this.electrical;
			}
			set
			{
				this.electrical = value;
			}
		}


		public virtual bool Sprinkler
		{
			get
			{
				return this.sprinkler;
			}
			set
			{
				this.sprinkler = value;
			}
		}


		public virtual bool Structural
		{
			get
			{
				return this.structural;
			}
			set
			{
				this.structural = value;
			}
		}


		public virtual bool Ventilation
		{
			get
			{
				return this.ventilation;
			}
			set
			{
				this.ventilation = value;
			}
		}

	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ifc\IfcEngineDomainTypeUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}