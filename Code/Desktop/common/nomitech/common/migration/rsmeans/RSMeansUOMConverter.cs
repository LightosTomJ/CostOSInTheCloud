using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.migration.rsmeans
{
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;

	public class RSMeansUOMConverter
	{
	  public static bool CONVERT_TO_METRIC = false;

	  private static RSMeansUOMConverter s_instance;

	  private IDictionary<string, string> o_imperialToMetricMap = new Hashtable();

	  private IDictionary<string, string> o_imperialToCostOSImperialMap = new Hashtable();

	  private IDictionary<string, decimal> o_imperialToMetricConverterMap = new Hashtable();

	  private IDictionary<string, string> map = new Hashtable();

	  private RSMeansUOMConverter()
	  {
		this.o_imperialToMetricMap["L.F."] = "LM";
		this.o_imperialToMetricMap["S.F."] = "M2";
		this.o_imperialToMetricMap["B.F."] = "M2";
		this.o_imperialToMetricMap["TON"] = "TN";
		this.o_imperialToMetricMap["C.F."] = "M3";
		this.o_imperialToMetricMap["C.Y."] = "M3";
		this.o_imperialToMetricMap["B.C.Y."] = "M3";
		this.o_imperialToMetricMap["DAY"] = "DAY";
		this.o_imperialToMetricMap["HOUR"] = "HOUR";
		this.o_imperialToMetricMap["WEEK"] = "WEEK";
		this.o_imperialToMetricMap["MONTH"] = "MONTH";
		this.o_imperialToMetricMap["GAL."] = "LT";
		this.o_imperialToMetricMap["HR."] = "HOUR";
		this.o_imperialToMetricMap["EA."] = "EACH";
		this.o_imperialToMetricMap["S.Y."] = "M2";
		this.o_imperialToMetricMap["SF FLR."] = "M2";
		this.o_imperialToMetricMap["SET"] = "SET";
		this.o_imperialToMetricMap["MILE"] = "KM";
		this.o_imperialToMetricMap["PROJECT"] = "PROJECT";
		this.o_imperialToMetricMap["INCH"] = "LCM";
		this.o_imperialToMetricMap["TOTAL"] = "TOTAL";
		this.o_imperialToMetricMap["CSF FLR"] = "HM2";
		this.o_imperialToMetricMap["PR."] = "PAIR";
		this.o_imperialToMetricMap["C.S.F."] = "HM2";
		this.o_imperialToMetricMap["C.C.F."] = "HM3";
		this.o_imperialToMetricMap["PAIR"] = "PAIR";
		this.o_imperialToMetricMap["MOVE"] = "MOVE";
		this.o_imperialToMetricMap["TREAD"] = "MOVE";
		this.o_imperialToMetricMap["C"] = "HUNDRED";
		this.o_imperialToMetricMap["M.S.F."] = "TM2";
		this.o_imperialToMetricMap["ACRE"] = "ACRE";
		this.o_imperialToMetricMap["V.L.F."] = "LM";
		this.o_imperialToMetricMap["SF FACE"] = "M2";
		this.o_imperialToMetricMap["C.L.F."] = "HLM";
		this.o_imperialToMetricMap["HEAD"] = "EACH";
		this.o_imperialToMetricMap["COURT"] = "COURT";
		this.o_imperialToMetricMap["SIGNAL"] = "SIGNAL";
		this.o_imperialToMetricMap["LB."] = "KG";
		this.o_imperialToMetricMap["BAG"] = "BAG";
		this.o_imperialToMetricMap["CWT."] = "HKG";
		this.o_imperialToMetricMap["SFCA"] = "M2";
		this.o_imperialToMetricMap["M.B.F."] = "M3";
		this.o_imperialToMetricMap["LF RSR"] = "LM";
		this.o_imperialToMetricMap["LF NOSE"] = "LM";
		this.o_imperialToMetricMap["RISER"] = "RISER";
		this.o_imperialToMetricMap["FLIGHT"] = "FLIGHT";
		this.o_imperialToMetricMap["JOB"] = "JOB";
		this.o_imperialToMetricMap["QT."] = "LT";
		this.o_imperialToMetricMap["OPNG."] = "EACH";
		this.o_imperialToMetricMap["M"] = "THOUSAND";
		this.o_imperialToMetricMap["DRUM"] = "DRUM";
		this.o_imperialToMetricMap["SQ."] = "SQUARE";
		this.o_imperialToMetricMap["KIP"] = "EACH";
		this.o_imperialToMetricMap["TRUSS"] = "EACH";
		this.o_imperialToMetricMap["C.PR."] = "HPR";
		this.o_imperialToMetricMap["M.L.F."] = "TLM";
		this.o_imperialToMetricMap["SF SURF"] = "M2";
		this.o_imperialToMetricMap["LEAF"] = "LEAF";
		this.o_imperialToMetricMap["SF HOR."] = "M2";
		this.o_imperialToMetricMap["DOOR"] = "EACH";
		this.o_imperialToMetricMap["FLOOR"] = "FLOOR";
		this.o_imperialToMetricMap["SF SHLF"] = "M2";
		this.o_imperialToMetricMap["CAR"] = "EACH";
		this.o_imperialToMetricMap["STATION"] = "STATION";
		this.o_imperialToMetricMap["SF STG."] = "M2";
		this.o_imperialToMetricMap["LANE"] = "EACH";
		this.o_imperialToMetricMap["SEAT"] = "SEAT";
		this.o_imperialToMetricMap["POINT"] = "POINT";
		this.o_imperialToMetricMap["SYSTEM"] = "SYSTEM";
		this.o_imperialToMetricMap["HOOD"] = "HOOD";
		this.o_imperialToMetricMap["TON/DAY"] = "TON/DAY";
		this.o_imperialToMetricMap["PERSON"] = "PERSON";
		this.o_imperialToMetricMap["SHADE"] = "SHADE";
		this.o_imperialToMetricMap["SECTION"] = "SECTION";
		this.o_imperialToMetricMap["ROOM"] = "ROOM";
		this.o_imperialToMetricMap["STUDENT"] = "STUDENT";
		this.o_imperialToMetricMap["SF POOL"] = "M2";
		this.o_imperialToMetricMap["SF WALL"] = "M2";
		this.o_imperialToMetricMap["M.C.F."] = "TM3";
		this.o_imperialToMetricMap["FIXTURE"] = "FIXTURE";
		this.o_imperialToMetricMap["PLANE"] = "PLANE";
		this.o_imperialToMetricMap["STOP"] = "STOP";
		this.o_imperialToMetricMap["MCFM"] = "TM3M";
		this.o_imperialToMetricMap["TONAC"] = "TONAC";
		this.o_imperialToMetricMap["KW"] = "KW";
		this.o_imperialToMetricMap["OUTLET"] = "OUTLET";
		this.o_imperialToMetricMap["SPEAKER"] = "SPEAKER";
		this.o_imperialToMetricMap["NAME"] = "NAME";
		this.o_imperialToMetricMap["E.C.Y."] = "M3";
		this.o_imperialToMetricMap["L.C.Y."] = "M3";
		this.o_imperialToMetricMap["LF HDR"] = "LM";
		this.o_imperialToMetricMap["ROLL"] = "ROLLERS";
		this.o_imperialToMetricMap["JACK"] = "JACK";
		this.o_imperialToMetricMap["LF RISER"] = "LM";
		this.o_imperialToMetricMap["STALL"] = "STALL";
		this.o_imperialToMetricMap["9 HOLES"] = "9 HOLES";
		this.o_imperialToMetricMap["C.Y"] = "M3";
		this.o_imperialToMetricMap["MVAR"] = "MVAR";
		this.o_imperialToMetricMap["W.MILE"] = "KM";
		this.o_imperialToMetricMap["K.A.H."] = "KAH";
		this.o_imperialToMetricMap["MVA"] = "MVA";
		this.o_imperialToMetricMap["SLIP"] = "SLIP";
		this.o_imperialToMetricMap["JOINT"] = "JOINT";
		this.o_imperialToMetricMap["UNIT"] = "UNIT";
		this.o_imperialToMetricMap["COIL"] = "COIL";
		this.o_imperialToMetricMap["OZ."] = "GRAMS";
		this.o_imperialToMetricMap["CARTON"] = "CARTON";
		this.o_imperialToCostOSImperialMap["L.F."] = "LF";
		this.o_imperialToCostOSImperialMap["S.F."] = "SF";
		this.o_imperialToCostOSImperialMap["B.F."] = "SF";
		this.o_imperialToCostOSImperialMap["TON"] = "TON";
		this.o_imperialToCostOSImperialMap["C.F."] = "CF";
		this.o_imperialToCostOSImperialMap["C.Y."] = "CY";
		this.o_imperialToCostOSImperialMap["B.C.Y."] = "CY";
		this.o_imperialToCostOSImperialMap["DAY"] = "DAY";
		this.o_imperialToCostOSImperialMap["HOUR"] = "HOUR";
		this.o_imperialToCostOSImperialMap["WEEK"] = "WEEK";
		this.o_imperialToCostOSImperialMap["MONTH"] = "MONTH";
		this.o_imperialToCostOSImperialMap["GAL."] = "GAL";
		this.o_imperialToCostOSImperialMap["HR."] = "HOUR";
		this.o_imperialToCostOSImperialMap["EA."] = "EACH";
		this.o_imperialToCostOSImperialMap["S.Y."] = "SY";
		this.o_imperialToCostOSImperialMap["SF FLR."] = "SF";
		this.o_imperialToCostOSImperialMap["SET"] = "SET";
		this.o_imperialToCostOSImperialMap["MILE"] = "MILE";
		this.o_imperialToCostOSImperialMap["PROJECT"] = "PROJECT";
		this.o_imperialToCostOSImperialMap["INCH"] = "IN";
		this.o_imperialToCostOSImperialMap["TOTAL"] = "TOTAL";
		this.o_imperialToCostOSImperialMap["CSF FLR"] = "SF";
		this.o_imperialToCostOSImperialMap["PR."] = "PAIR";
		this.o_imperialToCostOSImperialMap["C.S.F."] = "CSF";
		this.o_imperialToCostOSImperialMap["C.C.F."] = "CCF";
		this.o_imperialToCostOSImperialMap["PAIR"] = "PAIR";
		this.o_imperialToCostOSImperialMap["MOVE"] = "MOVE";
		this.o_imperialToCostOSImperialMap["TREAD"] = "MOVE";
		this.o_imperialToCostOSImperialMap["C"] = "HUNDRED";
		this.o_imperialToCostOSImperialMap["M.S.F."] = "MSF";
		this.o_imperialToCostOSImperialMap["ACRE"] = "ACRE";
		this.o_imperialToCostOSImperialMap["V.L.F."] = "LM";
		this.o_imperialToCostOSImperialMap["SF FACE"] = "SF";
		this.o_imperialToCostOSImperialMap["C.L.F."] = "HLF";
		this.o_imperialToCostOSImperialMap["HEAD"] = "EACH";
		this.o_imperialToCostOSImperialMap["COURT"] = "COURT";
		this.o_imperialToCostOSImperialMap["SIGNAL"] = "SIGNAL";
		this.o_imperialToCostOSImperialMap["LB."] = "LB";
		this.o_imperialToCostOSImperialMap["BAG"] = "BAG";
		this.o_imperialToCostOSImperialMap["CWT."] = "CLB";
		this.o_imperialToCostOSImperialMap["SFCA"] = "SF";
		this.o_imperialToCostOSImperialMap["M.B.F."] = "MBF";
		this.o_imperialToCostOSImperialMap["LF RSR"] = "LF";
		this.o_imperialToCostOSImperialMap["LF NOSE"] = "LF";
		this.o_imperialToCostOSImperialMap["RISER"] = "RISER";
		this.o_imperialToCostOSImperialMap["FLIGHT"] = "FLIGHT";
		this.o_imperialToCostOSImperialMap["JOB"] = "JOB";
		this.o_imperialToCostOSImperialMap["QT."] = "QUART";
		this.o_imperialToCostOSImperialMap["OPNG."] = "EACH";
		this.o_imperialToCostOSImperialMap["M"] = "THOUSAND";
		this.o_imperialToCostOSImperialMap["DRUM"] = "DRUM";
		this.o_imperialToCostOSImperialMap["SQ."] = "SQUARE";
		this.o_imperialToCostOSImperialMap["KIP"] = "EACH";
		this.o_imperialToCostOSImperialMap["TRUSS"] = "EACH";
		this.o_imperialToCostOSImperialMap["C.PR."] = "HPR";
		this.o_imperialToCostOSImperialMap["M.L.F."] = "MLF";
		this.o_imperialToCostOSImperialMap["SF SURF"] = "SF";
		this.o_imperialToCostOSImperialMap["LEAF"] = "LEAF";
		this.o_imperialToCostOSImperialMap["SF HOR."] = "SF";
		this.o_imperialToCostOSImperialMap["DOOR"] = "EACH";
		this.o_imperialToCostOSImperialMap["FLOOR"] = "FLOOR";
		this.o_imperialToCostOSImperialMap["SF SHLF"] = "SF";
		this.o_imperialToCostOSImperialMap["CAR"] = "EACH";
		this.o_imperialToCostOSImperialMap["STATION"] = "STATION";
		this.o_imperialToCostOSImperialMap["SF STG."] = "SF";
		this.o_imperialToCostOSImperialMap["LANE"] = "EACH";
		this.o_imperialToCostOSImperialMap["SEAT"] = "SEAT";
		this.o_imperialToCostOSImperialMap["POINT"] = "POINT";
		this.o_imperialToCostOSImperialMap["SYSTEM"] = "SYSTEM";
		this.o_imperialToCostOSImperialMap["HOOD"] = "HOOD";
		this.o_imperialToCostOSImperialMap["TON/DAY"] = "TON/DAY";
		this.o_imperialToCostOSImperialMap["PERSON"] = "PERSON";
		this.o_imperialToCostOSImperialMap["SHADE"] = "SHADE";
		this.o_imperialToCostOSImperialMap["SECTION"] = "SECTION";
		this.o_imperialToCostOSImperialMap["ROOM"] = "ROOM";
		this.o_imperialToCostOSImperialMap["STUDENT"] = "STUDENT";
		this.o_imperialToCostOSImperialMap["SF POOL"] = "SF";
		this.o_imperialToCostOSImperialMap["SF WALL"] = "SF";
		this.o_imperialToCostOSImperialMap["M.C.F."] = "MCF";
		this.o_imperialToCostOSImperialMap["FIXTURE"] = "FIXTURE";
		this.o_imperialToCostOSImperialMap["PLANE"] = "PLANE";
		this.o_imperialToCostOSImperialMap["STOP"] = "STOP";
		this.o_imperialToCostOSImperialMap["MCFM"] = "MCFM";
		this.o_imperialToCostOSImperialMap["TONAC"] = "TONAC";
		this.o_imperialToCostOSImperialMap["KW"] = "KW";
		this.o_imperialToCostOSImperialMap["OUTLET"] = "OUTLET";
		this.o_imperialToCostOSImperialMap["SPEAKER"] = "SPEAKER";
		this.o_imperialToCostOSImperialMap["NAME"] = "NAME";
		this.o_imperialToCostOSImperialMap["E.C.Y."] = "CY";
		this.o_imperialToCostOSImperialMap["L.C.Y."] = "CY";
		this.o_imperialToCostOSImperialMap["LF HDR"] = "LF";
		this.o_imperialToCostOSImperialMap["ROLL"] = "ROLLERS";
		this.o_imperialToCostOSImperialMap["JACK"] = "JACK";
		this.o_imperialToCostOSImperialMap["LF RISER"] = "LF";
		this.o_imperialToCostOSImperialMap["STALL"] = "STALL";
		this.o_imperialToCostOSImperialMap["9 HOLES"] = "9 HOLES";
		this.o_imperialToCostOSImperialMap["C.Y"] = "CY";
		this.o_imperialToCostOSImperialMap["MVAR"] = "MVAR";
		this.o_imperialToCostOSImperialMap["W.MILE"] = "MILE";
		this.o_imperialToCostOSImperialMap["K.A.H."] = "KAH";
		this.o_imperialToCostOSImperialMap["MVA"] = "MVA";
		this.o_imperialToCostOSImperialMap["SLIP"] = "SLIP";
		this.o_imperialToCostOSImperialMap["JOINT"] = "JOINT";
		this.o_imperialToCostOSImperialMap["UNIT"] = "UNIT";
		this.o_imperialToCostOSImperialMap["COIL"] = "COIL";
		this.o_imperialToCostOSImperialMap["OZ."] = "OUNCE";
		this.o_imperialToCostOSImperialMap["CARTON"] = "CARTON";
		this.o_imperialToCostOSImperialMap["M HDR"] = "LM";
		this.o_imperialToCostOSImperialMap["M NOSE"] = "LM";
		this.o_imperialToCostOSImperialMap["M RISER"] = "LM";
		this.o_imperialToCostOSImperialMap["M RSR"] = "LM";
		this.o_imperialToCostOSImperialMap["M HDR"] = "LM";
		this.o_imperialToCostOSImperialMap["M2CA"] = "M2";
		this.o_imperialToCostOSImperialMap["M2 FACE"] = "M2";
		this.o_imperialToCostOSImperialMap["M2 FLR"] = "M2";
		this.o_imperialToCostOSImperialMap["M2 FLR."] = "M2";
		this.o_imperialToCostOSImperialMap["M2 ROOF"] = "M2";
		this.o_imperialToCostOSImperialMap["M2 SHLF"] = "M2";
		this.o_imperialToCostOSImperialMap["M2 STG."] = "M2";
		this.o_imperialToCostOSImperialMap["M2 SURF"] = "M2";
		this.o_imperialToCostOSImperialMap["M3/S"] = "M3";
		this.o_imperialToCostOSImperialMap["MET. TON"] = "TN";
		this.o_imperialToCostOSImperialMap["H"] = "HUNDRED";
		this.o_imperialToCostOSImperialMap["K"] = "THOUSAND";
		this.o_imperialToCostOSImperialMap["LITER"] = "LT";
		this.o_imperialToCostOSImperialMap["HECTARE"] = "HA";
		this.o_imperialToCostOSImperialMap["KM"] = "KM";
		this.o_imperialToCostOSImperialMap["MM"] = "MM";
		this.o_imperialToCostOSImperialMap["M2"] = "M2";
		this.o_imperialToCostOSImperialMap["M3"] = "M3";
		this.o_imperialToCostOSImperialMap["KG"] = "KG";
		this.o_imperialToCostOSImperialMap["BM3"] = "M3";
		this.o_imperialToCostOSImperialMap["LM3"] = "M3";
		this.o_imperialToCostOSImperialMap["M2 HOR."] = "M2";
		this.o_imperialToCostOSImperialMap["M2 POOL"] = "M2";
		this.o_imperialToCostOSImperialMap["M2 WALL"] = "M2";
		this.o_imperialToCostOSImperialMap["EM3"] = "M3";
		this.o_imperialToCostOSImperialMap["H.PR."] = "HPR";
		this.o_imperialToMetricConverterMap["L.F."] = new BigDecimalFixed("3.280839");
		this.o_imperialToMetricConverterMap["S.F."] = new BigDecimalFixed("10.763910");
		this.o_imperialToMetricConverterMap["B.F."] = new BigDecimalFixed("10.763910");
		this.o_imperialToMetricConverterMap["TON"] = new BigDecimalFixed("0.9842065");
		this.o_imperialToMetricConverterMap["C.F."] = new BigDecimalFixed("35.31466671");
		this.o_imperialToMetricConverterMap["C.Y."] = new BigDecimalFixed("1.307950619");
		this.o_imperialToMetricConverterMap["B.C.Y."] = new BigDecimalFixed("1.307950619");
		this.o_imperialToMetricConverterMap["DAY"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["HOUR"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["WEEK"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["MONTH"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["GAL."] = new BigDecimalFixed("0.264172052");
		this.o_imperialToMetricConverterMap["HR."] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["EA."] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["S.Y."] = new BigDecimalFixed("1.195990046");
		this.o_imperialToMetricConverterMap["SF FLR."] = new BigDecimalFixed("10.763910");
		this.o_imperialToMetricConverterMap["SET"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["MILE"] = new BigDecimalFixed("0.621371192");
		this.o_imperialToMetricConverterMap["PROJECT"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["INCH"] = new BigDecimalFixed("0.3937008");
		this.o_imperialToMetricConverterMap["TOTAL"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["CSF FLR"] = new BigDecimalFixed("10.763910");
		this.o_imperialToMetricConverterMap["PR."] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["C.S.F."] = new BigDecimalFixed("10.763910");
		this.o_imperialToMetricConverterMap["C.C.F."] = new BigDecimalFixed("35.31466671");
		this.o_imperialToMetricConverterMap["PAIR"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["MOVE"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["TREAD"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["C"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["M.S.F."] = new BigDecimalFixed("10.763910");
		this.o_imperialToMetricConverterMap["ACRE"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["V.L.F."] = new BigDecimalFixed("3.280839");
		this.o_imperialToMetricConverterMap["SF FACE"] = new BigDecimalFixed("10.763910");
		this.o_imperialToMetricConverterMap["C.L.F."] = new BigDecimalFixed("3.280839");
		this.o_imperialToMetricConverterMap["HEAD"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["COURT"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["SIGNAL"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["LB."] = new BigDecimalFixed("2.204622622");
		this.o_imperialToMetricConverterMap["BAG"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["CWT."] = new BigDecimalFixed("2.204622622");
		this.o_imperialToMetricConverterMap["SFCA"] = new BigDecimalFixed("10.763910");
		this.o_imperialToMetricConverterMap["M.B.F."] = new BigDecimalFixed("0.423776001");
		this.o_imperialToMetricConverterMap["LF RSR"] = new BigDecimalFixed("3.280839");
		this.o_imperialToMetricConverterMap["LF NOSE"] = new BigDecimalFixed("3.280839");
		this.o_imperialToMetricConverterMap["RISER"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["FLIGHT"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["JOB"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["QT."] = new BigDecimalFixed("1.05668821");
		this.o_imperialToMetricConverterMap["OPNG."] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["M"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["DRUM"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["SQ."] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["KIP"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["TRUSS"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["C.PR."] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["M.L.F."] = new BigDecimalFixed("3.280839");
		this.o_imperialToMetricConverterMap["SF SURF"] = new BigDecimalFixed("10.763910");
		this.o_imperialToMetricConverterMap["LEAF"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["SF HOR."] = new BigDecimalFixed("10.763910");
		this.o_imperialToMetricConverterMap["DOOR"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["FLOOR"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["SF SHLF"] = new BigDecimalFixed("10.763910");
		this.o_imperialToMetricConverterMap["CAR"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["STATION"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["SF STG."] = new BigDecimalFixed("10.763910");
		this.o_imperialToMetricConverterMap["LANE"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["SEAT"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["POINT"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["SYSTEM"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["HOOD"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["TON/DAY"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["PERSON"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["SHADE"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["SECTION"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["ROOM"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["STUDENT"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["SF POOL"] = new BigDecimalFixed("10.763910");
		this.o_imperialToMetricConverterMap["SF WALL"] = new BigDecimalFixed("10.763910");
		this.o_imperialToMetricConverterMap["M.C.F."] = new BigDecimalFixed("35.31466671");
		this.o_imperialToMetricConverterMap["FIXTURE"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["PLANE"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["STOP"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["MCFM"] = new BigDecimalFixed("35.31466671");
		this.o_imperialToMetricConverterMap["TONAC"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["KW"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["OUTLET"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["SPEAKER"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["NAME"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["E.C.Y."] = new BigDecimalFixed("1.307950619");
		this.o_imperialToMetricConverterMap["L.C.Y."] = new BigDecimalFixed("1.307950619");
		this.o_imperialToMetricConverterMap["LF HDR"] = new BigDecimalFixed("3.280839");
		this.o_imperialToMetricConverterMap["ROLL"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["JACK"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["LF RISER"] = new BigDecimalFixed("3.280839");
		this.o_imperialToMetricConverterMap["STALL"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["9 HOLES"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["C.Y"] = new BigDecimalFixed("1.307950619");
		this.o_imperialToMetricConverterMap["MVAR"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["W.MILE"] = new BigDecimalFixed("0.621371192");
		this.o_imperialToMetricConverterMap["K.A.H."] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["MVA"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["SLIP"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["JOINT"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["UNIT"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["COIL"] = new BigDecimalFixed("1");
		this.o_imperialToMetricConverterMap["OZ."] = new BigDecimalFixed("0.035273");
		this.o_imperialToMetricConverterMap["CARTON"] = new BigDecimalFixed("1");
	  }

	  private string imperialToMetricUnit(string paramString)
	  {
		paramString = paramString.ToUpper();
		string str = (string)this.o_imperialToMetricMap[paramString];
		if (string.ReferenceEquals(str, null))
		{
		  if (string.ReferenceEquals(this.map[paramString], null))
		  {
			Console.WriteLine("o_imperialToMetricMap.put(\"" + paramString + "\",\"\");");
			this.map[paramString] = paramString;
		  }
		  str = paramString;
		}
		return str;
	  }

	  private string imperialToCostOSImperialUnit(string paramString)
	  {
		if (paramString.Equals("m"))
		{
		  return "LM";
		}
		paramString = paramString.ToUpper();
		string str = (string)this.o_imperialToCostOSImperialMap[paramString];
		if (string.ReferenceEquals(str, null))
		{
		  if (string.ReferenceEquals(this.map[paramString], null))
		  {
			Console.WriteLine("o_imperialToCostOSImperialMap.put(\"" + paramString + "\",\"\");");
			this.map[paramString] = paramString;
		  }
		  str = paramString;
		}
		return str;
	  }

	  private decimal imperialToMetricRate(string paramString, decimal paramBigDecimal)
	  {
		decimal bigDecimal1 = null;
		decimal bigDecimal2 = (decimal)this.o_imperialToMetricConverterMap[paramString];
		if (bigDecimal2 != null)
		{
		  bigDecimal1 = bigDecimal2 * paramBigDecimal.setScale(6, RoundingMode.DOWN);
		}
		else
		{
		  bigDecimal1 = paramBigDecimal;
		}
		return bigDecimal1;
	  }

	  private decimal imperialToMetricInverseRate(string paramString, decimal paramBigDecimal)
	  {
		decimal bigDecimal1 = null;
		decimal bigDecimal2 = (decimal)this.o_imperialToMetricConverterMap[paramString];
		if (bigDecimal2 != null)
		{
		  bigDecimal2 = (new BigDecimalFixed("1")).divide(bigDecimal2, BothDBPreferences.Instance.BigDecimalDividerScale, 1);
		  bigDecimal1 = bigDecimal2 * paramBigDecimal.setScale(6, RoundingMode.DOWN);
		}
		else
		{
		  Console.WriteLine("MULTIPLIER FOR " + paramString + " NOT FOUND SO ADD IT!");
		  bigDecimal1 = paramBigDecimal;
		}
		return bigDecimal1;
	  }

	  private static RSMeansUOMConverter Instance
	  {
		  get
		  {
			if (s_instance == null)
			{
			  s_instance = new RSMeansUOMConverter();
			}
			return s_instance;
		  }
	  }

	  public static string convertImperialToMetricUnit(string paramString)
	  {
		  return CONVERT_TO_METRIC ? Instance.imperialToMetricUnit(paramString.ToUpper()) : Instance.imperialToCostOSImperialUnit(paramString);
	  }

	  public static decimal convertImperialToMetricRate(string paramString, decimal paramBigDecimal)
	  {
		  return CONVERT_TO_METRIC ? Instance.imperialToMetricRate(paramString.ToUpper(), paramBigDecimal) : paramBigDecimal;
	  }

	  public static string convertImperialToCostOSImperialUnit(string paramString)
	  {
		  return Instance.imperialToCostOSImperialUnit(paramString);
	  }

	  public static decimal convertImperialToMetricInverseRate(string paramString, decimal paramBigDecimal)
	  {
		  return CONVERT_TO_METRIC ? Instance.imperialToMetricInverseRate(paramString.ToUpper(), paramBigDecimal) : paramBigDecimal;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\rsmeans\RSMeansUOMConverter.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}