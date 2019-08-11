using System;

namespace Models.local
{

	using BaseTable = Desktop.common.nomitech.common.@base.BaseTable;
	using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="CONCEPTUALS"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class ParamItemConceptualResourceTable : BaseTable, ProjectIdEntity
	{

		private long? conceptualId;
		private string title;
		private string currency;
		private string unit;
		private string materialUnitRate;
		private string materialFabricationRate;
		private string materialShipmentRate;
		private string subcontractorRate;
		private string subcontractorIKA;
		private string crewIds;
		private string crewFactors;
		private string titleConcatenation;
		private string notesConcatenation;
		private string descriptionConcatenation;

		private string weightUnit;
		private string weight;
		/*OIL & GAS*/
		private string volFlow;
		private string volFlowUnit;
		private string massFlow;
		private string massFlowUnit;
		private string duty;
		private string dutyUnit;
		private string operPress;
		private string operPressUnit;
		private string operTemp;
		private string operTempUnit;
		/* oil & gas end */	
		private string groupCode;
		private string gekCode;
		private string extraCode1;
		private string extraCode2;
		private string extraCode3;
		private string extraCode4;
		private string extraCode5;
		private string extraCode6;
		private string extraCode7;

		private string rawMaterial1;
		private string rawMaterial2;
		private string rawMaterial3;
		private string rawMaterial4;
		private string rawMaterial5;
		private decimal reliance1;
		private decimal reliance2;
		private decimal reliance3;
		private decimal reliance4;
		private decimal reliance5;
		private DateTime refDate;

		private ParamItemOutputTable paramItemOutputTable;

		private string laborRate;
		private string laborIKA;
		private string consumableRate;
		private string equipmentReservationRate;
		private string equipmentLubricatesRate;
		private string equipmentTiresRate;
		private string equipmentSparePartsRate;
		private string equipmentDepreciationRate;
		private string equipmentFuelRate;
		private string equipmentFuelConsumption;
		private string equipmentFuelType;

		// Custom Text
		private string customText1Equation;
		private string customText2Equation;
		private string customText3Equation;
		private string customText4Equation;
		private string customText5Equation;
		private string customText6Equation;
		private string customText7Equation;
		private string customText8Equation;
		private string customText9Equation;
		private string customText10Equation;
		private string customText11Equation;
		private string customText12Equation;
		private string customText13Equation;
		private string customText14Equation;
		private string customText15Equation;
		private string customText16Equation;
		private string customText17Equation;
		private string customText18Equation;
		private string customText19Equation;
		private string customText20Equation;
		private string customText21Equation;
		private string customText22Equation;
		private string customText23Equation;
		private string customText24Equation;
		private string customText25Equation;


		// Custom Decimal
		private string customRate1Equation;
		private string customRate2Equation;
		private string customRate3Equation;
		private string customRate4Equation;
		private string customRate5Equation;
		private string customRate6Equation;
		private string customRate7Equation;
		private string customRate8Equation;
		private string customRate9Equation;
		private string customRate10Equation;
		private string customRate11Equation;
		private string customRate12Equation;
		private string customRate13Equation;
		private string customRate14Equation;
		private string customRate15Equation;
		private string customRate16Equation;
		private string customRate17Equation;
		private string customRate18Equation;
		private string customRate19Equation;
		private string customRate20Equation;

		// Custom Cumulative Rate
		private string customCumRate1Equation;
		private string customCumRate2Equation;
		private string customCumRate3Equation;
		private string customCumRate4Equation;
		private string customCumRate5Equation;
		private string customCumRate6Equation;
		private string customCumRate7Equation;
		private string customCumRate8Equation;
		private string customCumRate9Equation;
		private string customCumRate10Equation;
		private string customCumRate11Equation;
		private string customCumRate12Equation;
		private string customCumRate13Equation;
		private string customCumRate14Equation;
		private string customCumRate15Equation;
		private string customCumRate16Equation;
		private string customCumRate17Equation;
		private string customCumRate18Equation;
		private string customCumRate19Equation;
		private string customCumRate20Equation;

		private int? executionType;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="CONCEPTUALID" </summary>
		/// <returns> Long </returns>
		public virtual long? ConceptualId
		{
			get
			{
				return conceptualId;
			}
			set
			{
				this.conceptualId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EXECTYPE" type="int" </summary>
		/// <returns> executionType </returns>
		public virtual int? ExecutionType
		{
			get
			{
				return executionType;
			}
			set
			{
				this.executionType = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="TITLE" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string Title
		{
			get
			{
				return title;
			}
			set
			{
				this.title = value;
			}
		}
		/// <summary>
		/// @hibernate.property column="CURRENCY" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string Currency
		{
			get
			{
				return currency;
			}
			set
			{
				this.currency = value;
			}
		}
		/// <summary>
		/// @hibernate.property column="CREWFACS" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string CrewFactors
		{
			get
			{
				return crewFactors;
			}
			set
			{
				this.crewFactors = value;
			}
		}
		/// <summary>
		/// @hibernate.property column="UNIT" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string Unit
		{
			get
			{
				return unit;
			}
			set
			{
				this.unit = value;
			}
		}
		/// <summary>
		/// @hibernate.property column="TITLECONCAT" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string TitleConcatenation
		{
			get
			{
				return titleConcatenation;
			}
			set
			{
				this.titleConcatenation = value;
			}
		}
		/// <summary>
		/// @hibernate.property column="NOTESCONCAT" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string NotesConcatenation
		{
			get
			{
				return notesConcatenation;
			}
			set
			{
				this.notesConcatenation = value;
			}
		}
		/// <summary>
		/// @hibernate.property column="DESCCONCAT" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string DescriptionConcatenation
		{
			get
			{
				return descriptionConcatenation;
			}
			set
			{
				this.descriptionConcatenation = value;
			}
		}
		/// <summary>
		/// @hibernate.property column="MATRATE" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string MaterialUnitRate
		{
			get
			{
				return materialUnitRate;
			}
			set
			{
				this.materialUnitRate = value;
			}
		}
		/// <summary>
		/// @hibernate.property column="MATFAB" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string MaterialFabricationRate
		{
			get
			{
				return materialFabricationRate;
			}
			set
			{
				this.materialFabricationRate = value;
			}
		}
		/// <summary>
		/// @hibernate.property column="MATSHIP" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string MaterialShipmentRate
		{
			get
			{
				return materialShipmentRate;
			}
			set
			{
				this.materialShipmentRate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CREWS" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string CrewIds
		{
			get
			{
				return crewIds;
			}
			set
			{
				this.crewIds = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="SUBRATE" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string SubcontractorRate
		{
			get
			{
				return subcontractorRate;
			}
			set
			{
				this.subcontractorRate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="SUBIKA" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string SubcontractorIKA
		{
			get
			{
				return subcontractorIKA;
			}
			set
			{
				this.subcontractorIKA = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="WEIGHTUNIT" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string WeightUnit
		{
			get
			{
				return weightUnit;
			}
			set
			{
				this.weightUnit = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="VOLFLOW" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string VolFlow
		{
			get
			{
				return volFlow;
			}
			set
			{
				this.volFlow = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="VFUNIT" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string VolFlowUnit
		{
			get
			{
				return volFlowUnit;
			}
			set
			{
				this.volFlowUnit = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="MASSFLOW" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string MassFlow
		{
			get
			{
				return massFlow;
			}
			set
			{
				this.massFlow = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="MFUNIT" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string MassFlowUnit
		{
			get
			{
				return massFlowUnit;
			}
			set
			{
				this.massFlowUnit = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="DUTY" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string Duty
		{
			get
			{
				return duty;
			}
			set
			{
				this.duty = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="DTUNIT" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string DutyUnit
		{
			get
			{
				return dutyUnit;
			}
			set
			{
				this.dutyUnit = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="OPERPRESS" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string OperPress
		{
			get
			{
				return operPress;
			}
			set
			{
				this.operPress = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="OPUNIT" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string OperPressUnit
		{
			get
			{
				return operPressUnit;
			}
			set
			{
				this.operPressUnit = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="OPERTEMP" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string OperTemp
		{
			get
			{
				return operTemp;
			}
			set
			{
				this.operTemp = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="OTUNIT" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string OperTempUnit
		{
			get
			{
				return operTempUnit;
			}
			set
			{
				this.operTempUnit = value;
			}
		}

		/// <summary>
		/// group code
		/// 
		/// @hibernate.property column="GROUPCODE" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string GroupCode
		{
			get
			{
				return groupCode;
			}
			set
			{
				this.groupCode = value;
			}
		}

		/// <summary>
		/// group code
		/// 
		/// @hibernate.property column="GEKCODE" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string GekCode
		{
			get
			{
				return gekCode;
			}
			set
			{
				this.gekCode = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="LABRATE" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string LaborRate
		{
			get
			{
				return laborRate;
			}
			set
			{
				this.laborRate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="LABIKA" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string LaborIKA
		{
			get
			{
				return laborIKA;
			}
			set
			{
				this.laborIKA = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CONRATE" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string ConsumableRate
		{
			get
			{
				return consumableRate;
			}
			set
			{
				this.consumableRate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EQURESRATE" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string EquipmentReservationRate
		{
			get
			{
				return equipmentReservationRate;
			}
			set
			{
				this.equipmentReservationRate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EQULUBRATE" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string EquipmentLubricatesRate
		{
			get
			{
				return equipmentLubricatesRate;
			}
			set
			{
				this.equipmentLubricatesRate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EQUTRSRATE" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string EquipmentTiresRate
		{
			get
			{
				return equipmentTiresRate;
			}
			set
			{
				this.equipmentTiresRate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EQUSPRRATE" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string EquipmentSparePartsRate
		{
			get
			{
				return equipmentSparePartsRate;
			}
			set
			{
				this.equipmentSparePartsRate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EQUDEPRATE" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string EquipmentDepreciationRate
		{
			get
			{
				return equipmentDepreciationRate;
			}
			set
			{
				this.equipmentDepreciationRate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EQUFULRATE" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string EquipmentFuelRate
		{
			get
			{
				return equipmentFuelRate;
			}
			set
			{
				this.equipmentFuelRate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EQUFUCRATE" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string EquipmentFuelConsumption
		{
			get
			{
				return equipmentFuelConsumption;
			}
			set
			{
				this.equipmentFuelConsumption = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EQUFUTRATE" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string EquipmentFuelType
		{
			get
			{
				return equipmentFuelType;
			}
			set
			{
				this.equipmentFuelType = value;
			}
		}

		/// <summary>
		/// group code
		/// 
		/// @hibernate.property column="EXTRACODE1" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string ExtraCode1
		{
			get
			{
				return extraCode1;
			}
			set
			{
				this.extraCode1 = value;
			}
		}

		/// <summary>
		/// group code
		/// 
		/// @hibernate.property column="EXTRACODE2" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string ExtraCode2
		{
			get
			{
				return extraCode2;
			}
			set
			{
				this.extraCode2 = value;
			}
		}

		/// <summary>
		/// group code
		/// 
		/// @hibernate.property column="EXTRACODE3" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string ExtraCode3
		{
			get
			{
				return extraCode3;
			}
			set
			{
				this.extraCode3 = value;
			}
		}

		/// <summary>
		/// group code
		/// 
		/// @hibernate.property column="EXTRACODE4" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string ExtraCode4
		{
			get
			{
				return extraCode4;
			}
			set
			{
				this.extraCode4 = value;
			}
		}

		/// <summary>
		/// group code
		/// 
		/// @hibernate.property column="EXTRACODE5" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string ExtraCode5
		{
			get
			{
				return extraCode5;
			}
			set
			{
				this.extraCode5 = value;
			}
		}

		/// <summary>
		/// group code
		/// 
		/// @hibernate.property column="EXTRACODE6" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string ExtraCode6
		{
			get
			{
				return extraCode6;
			}
			set
			{
				this.extraCode6 = value;
			}
		}

		/// <summary>
		/// group code
		/// 
		/// @hibernate.property column="EXTRACODE7" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string ExtraCode7
		{
			get
			{
				return extraCode7;
			}
			set
			{
				this.extraCode7 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RAWMAT1" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string RawMaterial1
		{
			get
			{
				return rawMaterial1;
			}
			set
			{
				this.rawMaterial1 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RAWMAT2" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string RawMaterial2
		{
			get
			{
				return rawMaterial2;
			}
			set
			{
				this.rawMaterial2 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RAWMAT3" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string RawMaterial3
		{
			get
			{
				return rawMaterial3;
			}
			set
			{
				this.rawMaterial3 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RAWMAT4" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string RawMaterial4
		{
			get
			{
				return rawMaterial4;
			}
			set
			{
				this.rawMaterial4 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RAWMAT5" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string RawMaterial5
		{
			get
			{
				return rawMaterial5;
			}
			set
			{
				this.rawMaterial5 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="WEIGHTRATE" type="costos_text" </summary>
		/// <returns> rate </returns>
		public virtual string Weight
		{
			get
			{
				return weight;
			}
			set
			{
				this.weight = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="REL1" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Reliance1
		{
			get
			{
				return reliance1;
			}
			set
			{
				this.reliance1 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="REL2" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Reliance2
		{
			get
			{
				return reliance2;
			}
			set
			{
				this.reliance2 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="REL3" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Reliance3
		{
			get
			{
				return reliance3;
			}
			set
			{
				this.reliance3 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="REL4" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Reliance4
		{
			get
			{
				return reliance4;
			}
			set
			{
				this.reliance4 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="REL5" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Reliance5
		{
			get
			{
				return reliance5;
			}
			set
			{
				this.reliance5 = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="REFDATE" type="timestamp" </summary>
		/// <returns> lastUpdate </returns>
		public virtual DateTime RefDate
		{
			get
			{
				return refDate;
			}
			set
			{
				this.refDate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CT01EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText1Equation
		{
			get
			{
				return customText1Equation;
			}
			set
			{
				this.customText1Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT02EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText2Equation
		{
			get
			{
				return customText2Equation;
			}
			set
			{
				this.customText2Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT03EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText3Equation
		{
			get
			{
				return customText3Equation;
			}
			set
			{
				this.customText3Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT04EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText4Equation
		{
			get
			{
				return customText4Equation;
			}
			set
			{
				this.customText4Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT05EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText5Equation
		{
			get
			{
				return customText5Equation;
			}
			set
			{
				this.customText5Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT06EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText6Equation
		{
			get
			{
				return customText6Equation;
			}
			set
			{
				this.customText6Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT07EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText7Equation
		{
			get
			{
				return customText7Equation;
			}
			set
			{
				this.customText7Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT08EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText8Equation
		{
			get
			{
				return customText8Equation;
			}
			set
			{
				this.customText8Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT09EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText9Equation
		{
			get
			{
				return customText9Equation;
			}
			set
			{
				this.customText9Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT10EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText10Equation
		{
			get
			{
				return customText10Equation;
			}
			set
			{
				this.customText10Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT11EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText11Equation
		{
			get
			{
				return customText11Equation;
			}
			set
			{
				this.customText11Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CT12EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText12Equation
		{
			get
			{
				return customText12Equation;
			}
			set
			{
				this.customText12Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CT13EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText13Equation
		{
			get
			{
				return customText13Equation;
			}
			set
			{
				this.customText13Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CT14EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText14Equation
		{
			get
			{
				return customText14Equation;
			}
			set
			{
				this.customText14Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CT15EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText15Equation
		{
			get
			{
				return customText15Equation;
			}
			set
			{
				this.customText15Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CT16EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText16Equation
		{
			get
			{
				return customText16Equation;
			}
			set
			{
				this.customText16Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CT17EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText17Equation
		{
			get
			{
				return customText17Equation;
			}
			set
			{
				this.customText17Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CT18EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText18Equation
		{
			get
			{
				return customText18Equation;
			}
			set
			{
				this.customText18Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CT19EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText19Equation
		{
			get
			{
				return customText19Equation;
			}
			set
			{
				this.customText19Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CT20EQ" type="costos_text"
		/// </summary>
		public virtual string CustomText20Equation
		{
			get
			{
				return customText20Equation;
			}
			set
			{
				this.customText20Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CT21EQ" type="costos_text"
		/// </summary>
		public virtual string CustomText21Equation
		{
			get
			{
				return customText21Equation;
			}
			set
			{
				this.customText21Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CT22EQ" type="costos_text"
		/// </summary>
		public virtual string CustomText22Equation
		{
			get
			{
				return customText22Equation;
			}
			set
			{
				this.customText22Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CT23EQ" type="costos_text"
		/// </summary>
		public virtual string CustomText23Equation
		{
			get
			{
				return customText23Equation;
			}
			set
			{
				this.customText23Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CT24EQ" type="costos_text"
		/// </summary>
		public virtual string CustomText24Equation
		{
			get
			{
				return customText24Equation;
			}
			set
			{
				this.customText24Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CT25EQ" type="costos_text"
		/// </summary>
		public virtual string CustomText25Equation
		{
			get
			{
				return customText25Equation;
			}
			set
			{
				this.customText25Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CR01EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate1Equation
		{
			get
			{
				return customRate1Equation;
			}
			set
			{
				this.customRate1Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR02EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate2Equation
		{
			get
			{
				return customRate2Equation;
			}
			set
			{
				this.customRate2Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR03EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate3Equation
		{
			get
			{
				return customRate3Equation;
			}
			set
			{
				this.customRate3Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR04EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate4Equation
		{
			get
			{
				return customRate4Equation;
			}
			set
			{
				this.customRate4Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR05EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate5Equation
		{
			get
			{
				return customRate5Equation;
			}
			set
			{
				this.customRate5Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR06EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate6Equation
		{
			get
			{
				return customRate6Equation;
			}
			set
			{
				this.customRate6Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR07EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate7Equation
		{
			get
			{
				return customRate7Equation;
			}
			set
			{
				this.customRate7Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR08EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate8Equation
		{
			get
			{
				return customRate8Equation;
			}
			set
			{
				this.customRate8Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR09EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate9Equation
		{
			get
			{
				return customRate9Equation;
			}
			set
			{
				this.customRate9Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR10EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate10Equation
		{
			get
			{
				return customRate10Equation;
			}
			set
			{
				this.customRate10Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR11EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate11Equation
		{
			get
			{
				return customRate11Equation;
			}
			set
			{
				this.customRate11Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CR12EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate12Equation
		{
			get
			{
				return customRate12Equation;
			}
			set
			{
				this.customRate12Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CR13EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate13Equation
		{
			get
			{
				return customRate13Equation;
			}
			set
			{
				this.customRate13Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CR14EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate14Equation
		{
			get
			{
				return customRate14Equation;
			}
			set
			{
				this.customRate14Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CR15EQ" type="costos_text"
		/// </summary>
		public virtual string CustomRate15Equation
		{
			get
			{
				return customRate15Equation;
			}
			set
			{
				this.customRate15Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CR16EQ" type="costos_text"
		/// </summary>
		public virtual string CustomRate16Equation
		{
			get
			{
				return customRate16Equation;
			}
			set
			{
				this.customRate16Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CR17EQ" type="costos_text"
		/// </summary>
		public virtual string CustomRate17Equation
		{
			get
			{
				return customRate17Equation;
			}
			set
			{
				this.customRate17Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CR18EQ" type="costos_text"
		/// </summary>
		public virtual string CustomRate18Equation
		{
			get
			{
				return customRate18Equation;
			}
			set
			{
				this.customRate18Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CR19EQ" type="costos_text"
		/// </summary>
		public virtual string CustomRate19Equation
		{
			get
			{
				return customRate19Equation;
			}
			set
			{
				this.customRate19Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CR20EQ" type="costos_text"
		/// </summary>
		public virtual string CustomRate20Equation
		{
			get
			{
				return customRate20Equation;
			}
			set
			{
				this.customRate20Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CC01EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate1Equation
		{
			get
			{
				return customCumRate1Equation;
			}
			set
			{
				this.customCumRate1Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC02EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate2Equation
		{
			get
			{
				return customCumRate2Equation;
			}
			set
			{
				this.customCumRate2Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC03EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate3Equation
		{
			get
			{
				return customCumRate3Equation;
			}
			set
			{
				this.customCumRate3Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC04EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate4Equation
		{
			get
			{
				return customCumRate4Equation;
			}
			set
			{
				this.customCumRate4Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC05EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate5Equation
		{
			get
			{
				return customCumRate5Equation;
			}
			set
			{
				this.customCumRate5Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC06EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate6Equation
		{
			get
			{
				return customCumRate6Equation;
			}
			set
			{
				this.customCumRate6Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CC07EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate7Equation
		{
			get
			{
				return customCumRate7Equation;
			}
			set
			{
				this.customCumRate7Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CC08EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate8Equation
		{
			get
			{
				return customCumRate8Equation;
			}
			set
			{
				this.customCumRate8Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CC09EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate9Equation
		{
			get
			{
				return customCumRate9Equation;
			}
			set
			{
				this.customCumRate9Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CC10EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate10Equation
		{
			get
			{
				return customCumRate10Equation;
			}
			set
			{
				this.customCumRate10Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CC11EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate11Equation
		{
			get
			{
				return customCumRate11Equation;
			}
			set
			{
				this.customCumRate11Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CC12EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate12Equation
		{
			get
			{
				return customCumRate12Equation;
			}
			set
			{
				this.customCumRate12Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CC13EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate13Equation
		{
			get
			{
				return customCumRate13Equation;
			}
			set
			{
				this.customCumRate13Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CC14EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate14Equation
		{
			get
			{
				return customCumRate14Equation;
			}
			set
			{
				this.customCumRate14Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CC15EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate15Equation
		{
			get
			{
				return customCumRate15Equation;
			}
			set
			{
				this.customCumRate15Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CC16EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate16Equation
		{
			get
			{
				return customCumRate16Equation;
			}
			set
			{
				this.customCumRate16Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CC17EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate17Equation
		{
			get
			{
				return customCumRate17Equation;
			}
			set
			{
				this.customCumRate17Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CC18EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate18Equation
		{
			get
			{
				return customCumRate18Equation;
			}
			set
			{
				this.customCumRate18Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CC19EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate19Equation
		{
			get
			{
				return customCumRate19Equation;
			}
			set
			{
				this.customCumRate19Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CC20EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate20Equation
		{
			get
			{
				return customCumRate20Equation;
			}
			set
			{
				this.customCumRate20Equation = value;
			}
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="PARAMOUTPUTID" </summary>
		/// <returns> ParamItemTable </returns>
		public virtual ParamItemOutputTable ParamItemOutputTable
		{
			get
			{
				return paramItemOutputTable;
			}
			set
			{
				this.paramItemOutputTable = value;
			}
		}

		public override long? Id
		{
			get
			{
				return ConceptualId;
			}
		}

		public override decimal TableRate
		{
			get
			{
				return null;
			}
		}
		public override DateTime LastUpdate
		{
			get
			{
				return RefDate;
			}
		}

		public virtual object Clone()
		{
			ParamItemConceptualResourceTable conTable = new ParamItemConceptualResourceTable();

			conTable.ConceptualId = ConceptualId;
			conTable.ExecutionType = ExecutionType;
			conTable.Title = Title;
			conTable.TitleConcatenation = TitleConcatenation;
			conTable.NotesConcatenation = NotesConcatenation;
			conTable.DescriptionConcatenation = DescriptionConcatenation;

			conTable.Unit = Unit;
			conTable.Currency = Currency;
			conTable.CrewIds = CrewIds;
			conTable.CrewFactors = CrewFactors;
			conTable.MaterialFabricationRate = MaterialFabricationRate;
			conTable.MaterialUnitRate = MaterialUnitRate;
			conTable.MaterialShipmentRate = MaterialShipmentRate;
			conTable.SubcontractorRate = SubcontractorRate;
			conTable.SubcontractorIKA = SubcontractorIKA;
			conTable.RawMaterial1 = RawMaterial1;
			conTable.RawMaterial2 = RawMaterial2;
			conTable.RawMaterial3 = RawMaterial3;
			conTable.RawMaterial4 = RawMaterial4;
			conTable.RawMaterial5 = RawMaterial5;
			conTable.Reliance1 = Reliance1;
			conTable.Reliance2 = Reliance2;
			conTable.Reliance3 = Reliance3;
			conTable.Reliance4 = Reliance4;
			conTable.Reliance5 = Reliance5;
			conTable.Weight = Weight;
			conTable.WeightUnit = WeightUnit;
			conTable.RefDate = RefDate;

			conTable.VolFlow = VolFlow;
			conTable.VolFlowUnit = VolFlowUnit;
			conTable.MassFlow = MassFlow;
			conTable.MassFlowUnit = MassFlowUnit;
			conTable.Duty = Duty;
			conTable.DutyUnit = DutyUnit;
			conTable.OperPress = OperPress;
			conTable.OperPressUnit = OperPressUnit;
			conTable.OperTemp = OperTemp;
			conTable.OperTempUnit = OperTempUnit;

			conTable.LaborRate = LaborRate;
			conTable.LaborIKA = LaborIKA;
			conTable.ConsumableRate = ConsumableRate;
			conTable.EquipmentReservationRate = EquipmentReservationRate;
			conTable.EquipmentDepreciationRate = EquipmentDepreciationRate;
			conTable.EquipmentFuelConsumption = EquipmentFuelConsumption;
			conTable.EquipmentFuelRate = EquipmentFuelRate;
			conTable.EquipmentFuelType = EquipmentFuelType;
			conTable.EquipmentLubricatesRate = EquipmentLubricatesRate;
			conTable.EquipmentSparePartsRate = EquipmentSparePartsRate;
			conTable.EquipmentTiresRate = EquipmentTiresRate;

			conTable.GroupCode = GroupCode;
			conTable.GekCode = GekCode;
			conTable.ExtraCode1 = ExtraCode1;
			conTable.ExtraCode2 = ExtraCode2;
			conTable.ExtraCode1 = ExtraCode1;
			conTable.ExtraCode2 = ExtraCode2;
			conTable.ExtraCode3 = ExtraCode3;
			conTable.ExtraCode4 = ExtraCode4;
			conTable.ExtraCode5 = ExtraCode5;
			conTable.ExtraCode6 = ExtraCode6;
			conTable.ExtraCode7 = ExtraCode7;

			conTable.CustomRate1Equation = CustomRate1Equation;
			conTable.CustomRate2Equation = CustomRate2Equation;
			conTable.CustomRate3Equation = CustomRate3Equation;
			conTable.CustomRate4Equation = CustomRate4Equation;
			conTable.CustomRate5Equation = CustomRate5Equation;
			conTable.CustomRate6Equation = CustomRate6Equation;
			conTable.CustomRate7Equation = CustomRate7Equation;
			conTable.CustomRate8Equation = CustomRate8Equation;
			conTable.CustomRate9Equation = CustomRate9Equation;
			conTable.CustomRate10Equation = CustomRate10Equation;
			conTable.CustomRate11Equation = CustomRate11Equation;
			conTable.CustomRate12Equation = CustomRate12Equation;
			conTable.CustomRate13Equation = CustomRate13Equation;
			conTable.CustomRate14Equation = CustomRate14Equation;
			conTable.CustomRate15Equation = CustomRate15Equation;
			conTable.CustomRate16Equation = CustomRate16Equation;
			conTable.CustomRate17Equation = CustomRate17Equation;
			conTable.CustomRate18Equation = CustomRate18Equation;
			conTable.CustomRate19Equation = CustomRate19Equation;
			conTable.CustomRate20Equation = CustomRate20Equation;

			conTable.CustomCumRate1Equation = CustomCumRate1Equation;
			conTable.CustomCumRate2Equation = CustomCumRate2Equation;
			conTable.CustomCumRate3Equation = CustomCumRate3Equation;
			conTable.CustomCumRate4Equation = CustomCumRate4Equation;
			conTable.CustomCumRate5Equation = CustomCumRate5Equation;
			conTable.CustomCumRate6Equation = CustomCumRate6Equation;
			conTable.CustomCumRate7Equation = CustomCumRate7Equation;
			conTable.CustomCumRate8Equation = CustomCumRate8Equation;
			conTable.CustomCumRate9Equation = CustomCumRate9Equation;
			conTable.CustomCumRate10Equation = CustomCumRate10Equation;
			conTable.CustomCumRate11Equation = CustomCumRate11Equation;
			conTable.CustomCumRate12Equation = CustomCumRate12Equation;
			conTable.CustomCumRate13Equation = CustomCumRate13Equation;
			conTable.CustomCumRate14Equation = CustomCumRate14Equation;
			conTable.CustomCumRate15Equation = CustomCumRate15Equation;
			conTable.CustomCumRate16Equation = CustomCumRate16Equation;
			conTable.CustomCumRate17Equation = CustomCumRate17Equation;
			conTable.CustomCumRate18Equation = CustomCumRate18Equation;
			conTable.CustomCumRate19Equation = CustomCumRate19Equation;
			conTable.CustomCumRate20Equation = CustomCumRate20Equation;

			conTable.CustomText1Equation = CustomText1Equation;
			conTable.CustomText2Equation = CustomText2Equation;
			conTable.CustomText3Equation = CustomText3Equation;
			conTable.CustomText4Equation = CustomText4Equation;
			conTable.CustomText5Equation = CustomText5Equation;
			conTable.CustomText6Equation = CustomText6Equation;
			conTable.CustomText7Equation = CustomText7Equation;
			conTable.CustomText8Equation = CustomText8Equation;
			conTable.CustomText9Equation = CustomText9Equation;
			conTable.CustomText10Equation = CustomText10Equation;

			conTable.CustomText11Equation = CustomText11Equation;
			conTable.CustomText12Equation = CustomText12Equation;
			conTable.CustomText13Equation = CustomText13Equation;
			conTable.CustomText14Equation = CustomText14Equation;
			conTable.CustomText15Equation = CustomText15Equation;
			conTable.CustomText16Equation = CustomText16Equation;
			conTable.CustomText17Equation = CustomText17Equation;
			conTable.CustomText18Equation = CustomText18Equation;
			conTable.CustomText19Equation = CustomText19Equation;
			conTable.CustomText20Equation = CustomText20Equation;
			conTable.CustomText21Equation = CustomText21Equation;
			conTable.CustomText22Equation = CustomText22Equation;
			conTable.CustomText23Equation = CustomText23Equation;
			conTable.CustomText24Equation = CustomText24Equation;
			conTable.CustomText25Equation = CustomText25Equation;

			conTable.ProjectId = ProjectId;

			return conTable;
		}
		public virtual ParamItemConceptualResourceTable Data
		{
			set
			{
				ConceptualId = value.ConceptualId;
				ExecutionType = value.ExecutionType;
				Title = value.Title;
				TitleConcatenation = value.TitleConcatenation;
				NotesConcatenation = value.NotesConcatenation;
				DescriptionConcatenation = value.DescriptionConcatenation;
    
				Unit = value.Unit;
				Currency = value.Currency;
				CrewIds = value.CrewIds;
				CrewFactors = value.CrewFactors;
				MaterialFabricationRate = value.MaterialFabricationRate;
				MaterialUnitRate = value.MaterialUnitRate;
				MaterialShipmentRate = value.MaterialShipmentRate;
				SubcontractorRate = value.SubcontractorRate;
				SubcontractorIKA = value.SubcontractorIKA;
				RawMaterial1 = value.RawMaterial1;
				RawMaterial2 = value.RawMaterial2;
				RawMaterial3 = value.RawMaterial3;
				RawMaterial4 = value.RawMaterial4;
				RawMaterial5 = value.RawMaterial5;
				Reliance1 = value.Reliance1;
				Reliance2 = value.Reliance2;
				Reliance3 = value.Reliance3;
				Reliance4 = value.Reliance4;
				Reliance5 = value.Reliance5;
				Weight = value.Weight;
				WeightUnit = value.WeightUnit;
				RefDate = value.RefDate;
    
				VolFlow = value.VolFlow;
				VolFlowUnit = value.VolFlowUnit;
				MassFlow = value.MassFlow;
				MassFlowUnit = value.MassFlowUnit;
				Duty = value.Duty;
				DutyUnit = value.DutyUnit;
				OperPress = value.OperPress;
				OperPressUnit = value.OperPressUnit;
				OperTemp = value.OperTemp;
				OperTempUnit = value.OperTempUnit;
    
				LaborRate = value.LaborRate;
				LaborIKA = value.LaborIKA;
				EquipmentReservationRate = value.EquipmentReservationRate;
				EquipmentDepreciationRate = value.EquipmentDepreciationRate;
				EquipmentFuelConsumption = value.EquipmentFuelConsumption;
				EquipmentFuelRate = value.EquipmentFuelRate;
				EquipmentFuelType = value.EquipmentFuelType;
				EquipmentLubricatesRate = value.EquipmentLubricatesRate;
				EquipmentSparePartsRate = value.EquipmentSparePartsRate;
				EquipmentTiresRate = value.EquipmentTiresRate;
				ConsumableRate = value.ConsumableRate;
    
				GroupCode = value.GroupCode;
				GekCode = value.GekCode;
				ExtraCode1 = value.ExtraCode1;
				ExtraCode2 = value.ExtraCode2;
				ExtraCode3 = value.ExtraCode3;
				ExtraCode4 = value.ExtraCode4;
				ExtraCode5 = value.ExtraCode5;
				ExtraCode6 = value.ExtraCode6;
				ExtraCode7 = value.ExtraCode7;
    
				CustomRate1Equation = value.CustomRate1Equation;
				CustomRate2Equation = value.CustomRate2Equation;
				CustomRate3Equation = value.CustomRate3Equation;
				CustomRate4Equation = value.CustomRate4Equation;
				CustomRate5Equation = value.CustomRate5Equation;
				CustomRate6Equation = value.CustomRate6Equation;
				CustomRate7Equation = value.CustomRate7Equation;
				CustomRate8Equation = value.CustomRate8Equation;
				CustomRate9Equation = value.CustomRate9Equation;
				CustomRate10Equation = value.CustomRate10Equation;
				CustomRate11Equation = value.CustomRate11Equation;
				CustomRate12Equation = value.CustomRate12Equation;
				CustomRate13Equation = value.CustomRate13Equation;
				CustomRate14Equation = value.CustomRate14Equation;
				CustomRate15Equation = value.CustomRate15Equation;
				CustomRate16Equation = value.CustomRate16Equation;
				CustomRate17Equation = value.CustomRate17Equation;
				CustomRate18Equation = value.CustomRate18Equation;
				CustomRate19Equation = value.CustomRate19Equation;
				CustomRate20Equation = value.CustomRate20Equation;
    
				CustomCumRate1Equation = value.CustomCumRate1Equation;
				CustomCumRate2Equation = value.CustomCumRate2Equation;
				CustomCumRate3Equation = value.CustomCumRate3Equation;
				CustomCumRate4Equation = value.CustomCumRate4Equation;
				CustomCumRate5Equation = value.CustomCumRate5Equation;
				CustomCumRate6Equation = value.CustomCumRate6Equation;
				CustomCumRate7Equation = value.CustomCumRate7Equation;
				CustomCumRate8Equation = value.CustomCumRate8Equation;
				CustomCumRate9Equation = value.CustomCumRate9Equation;
				CustomCumRate10Equation = value.CustomCumRate10Equation;
				CustomCumRate11Equation = value.CustomCumRate11Equation;
				CustomCumRate12Equation = value.CustomCumRate12Equation;
				CustomCumRate13Equation = value.CustomCumRate13Equation;
				CustomCumRate14Equation = value.CustomCumRate14Equation;
				CustomCumRate15Equation = value.CustomCumRate15Equation;
				CustomCumRate16Equation = value.CustomCumRate16Equation;
				CustomCumRate17Equation = value.CustomCumRate17Equation;
				CustomCumRate18Equation = value.CustomCumRate18Equation;
				CustomCumRate19Equation = value.CustomCumRate19Equation;
				CustomCumRate20Equation = value.CustomCumRate20Equation;
    
				CustomText1Equation = value.CustomText1Equation;
				CustomText2Equation = value.CustomText2Equation;
				CustomText3Equation = value.CustomText3Equation;
				CustomText4Equation = value.CustomText4Equation;
				CustomText5Equation = value.CustomText5Equation;
				CustomText6Equation = value.CustomText6Equation;
				CustomText7Equation = value.CustomText7Equation;
				CustomText8Equation = value.CustomText8Equation;
				CustomText9Equation = value.CustomText9Equation;
				CustomText10Equation = value.CustomText10Equation;
				CustomText11Equation = value.CustomText11Equation;
				CustomText12Equation = value.CustomText12Equation;
				CustomText13Equation = value.CustomText13Equation;
				CustomText14Equation = value.CustomText14Equation;
				CustomText15Equation = value.CustomText15Equation;
				CustomText16Equation = value.CustomText16Equation;
				CustomText17Equation = value.CustomText17Equation;
				CustomText18Equation = value.CustomText18Equation;
				CustomText19Equation = value.CustomText19Equation;
				CustomText20Equation = value.CustomText20Equation;
				CustomText21Equation = value.CustomText21Equation;
				CustomText22Equation = value.CustomText22Equation;
				CustomText23Equation = value.CustomText23Equation;
				CustomText24Equation = value.CustomText24Equation;
				CustomText25Equation = value.CustomText25Equation;
			}
		}

		private long? projectId;
		//#RXL_START
		/// <summary>
		/// @hibernate.property column="PRJID" type="long" index="IDX_PRJID" </summary>
		/// <returns> BigDecimal </returns>
		//#RXL_END
		public override long? ProjectId
		{
			get
			{
				return projectId;
			}
			set
			{
				this.projectId = value;
			}
		}

	}

}