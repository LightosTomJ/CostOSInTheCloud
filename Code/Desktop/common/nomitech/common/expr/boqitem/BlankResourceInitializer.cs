using System;
using System.Collections.Generic;
using System.Reflection;

namespace Desktop.common.nomitech.common.expr.boqitem
{
	using UserAndRolesData = nomitech.common.auth.UserAndRolesData;
	using BaseEntity = nomitech.common.@base.BaseEntity;
	using GroupCode = nomitech.common.@base.GroupCode;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using AssemblyTable = nomitech.common.db.local.AssemblyTable;
	using ConsumableTable = nomitech.common.db.local.ConsumableTable;
	using EquipmentTable = nomitech.common.db.local.EquipmentTable;
	using ExtraCode1Table = nomitech.common.db.local.ExtraCode1Table;
	using ExtraCode2Table = nomitech.common.db.local.ExtraCode2Table;
	using ExtraCode3Table = nomitech.common.db.local.ExtraCode3Table;
	using ExtraCode4Table = nomitech.common.db.local.ExtraCode4Table;
	using ExtraCode5Table = nomitech.common.db.local.ExtraCode5Table;
	using ExtraCode6Table = nomitech.common.db.local.ExtraCode6Table;
	using ExtraCode7Table = nomitech.common.db.local.ExtraCode7Table;
	using FieldCustomizationTable = nomitech.common.db.local.FieldCustomizationTable;
	using GekCodeTable = nomitech.common.db.local.GekCodeTable;
	using GroupCodeTable = nomitech.common.db.local.GroupCodeTable;
	using LaborTable = nomitech.common.db.local.LaborTable;
	using MaterialTable = nomitech.common.db.local.MaterialTable;
	using ParamItemQueryResourceTable = nomitech.common.db.local.ParamItemQueryResourceTable;
	using ParamItemTable = nomitech.common.db.local.ParamItemTable;
	using ProjectAccessRuleTable = nomitech.common.db.local.ProjectAccessRuleTable;
	using ProjectEPSTable = nomitech.common.db.local.ProjectEPSTable;
	using ProjectInfoTable = nomitech.common.db.local.ProjectInfoTable;
	using ProjectUserTable = nomitech.common.db.local.ProjectUserTable;
	using SubcontractorTable = nomitech.common.db.local.SubcontractorTable;
	using SupplierTable = nomitech.common.db.local.SupplierTable;
	using BoqItemTable = nomitech.common.db.project.BoqItemTable;
	using AssemblyPartialResult = nomitech.common.db.result.AssemblyPartialResult;
	using ParamItemPartialResult = nomitech.common.db.result.ParamItemPartialResult;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using FieldLookupUtil = nomitech.common.fields.FieldLookupUtil;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using StringUtils = nomitech.common.util.StringUtils;

	public class BlankResourceInitializer
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static Object getFieldValueEx(nomitech.common.base.BaseEntity paramBaseEntity, String paramString) throws Exception
	  public static object getFieldValueEx(BaseEntity paramBaseEntity, string paramString)
	  {
		if (paramBaseEntity == null || string.ReferenceEquals(paramString, null))
		{
		  throw new System.ArgumentException();
		}
		string str1 = "" + paramString[0];
		string str2 = "get" + str1.ToUpper() + paramString.Substring(1);
		System.Reflection.MethodInfo method = paramBaseEntity.GetType().GetMethod(str2, new Type[0]);
		return method.invoke(paramBaseEntity, new object[0]);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static Object getFieldValue(nomitech.common.base.BaseEntity paramBaseEntity, String paramString) throws Exception
	  public static object getFieldValue(BaseEntity paramBaseEntity, string paramString)
	  {
		if (paramBaseEntity == null || string.ReferenceEquals(paramString, null))
		{
		  return null;
		}
		try
		{
		  string str1 = "" + paramString[0];
		  string str2 = "get" + str1.ToUpper() + paramString.Substring(1);
		  System.Reflection.MethodInfo method = paramBaseEntity.GetType().GetMethod(str2, new Type[0]);
		  return method.invoke(paramBaseEntity, new object[0]);
		}
		catch (Exception)
		{
		  return null;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static boolean setFieldValue(nomitech.common.base.BaseEntity paramBaseEntity, String paramString, Object paramObject) throws Exception
	  public static bool setFieldValue(BaseEntity paramBaseEntity, string paramString, object paramObject)
	  {
		bool @bool = true;
		if (paramObject is Timestamp)
		{
		  paramObject = new DateTime(((Timestamp)paramObject).Time);
		}
		string str1 = "" + paramString[0];
		string str2 = "set" + str1.ToUpper() + paramString.Substring(1);
		Type clazz = typeof(string);
		if (paramObject != null)
		{
		  clazz = paramObject.GetType();
		  if (clazz.Equals(typeof(BigDecimalFixed)))
		  {
			clazz = typeof(decimal);
		  }
		}
		else
		{
		  @bool = true;
		}
		Type[] arrayOfClass = null;
		if (@bool)
		{
		  System.Reflection.MethodInfo[] arrayOfMethod = paramBaseEntity.GetType().GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
		  foreach (System.Reflection.MethodInfo method1 in arrayOfMethod)
		  {
			if (method1.Name.Equals(str2))
			{
			  arrayOfClass = method1.ParameterTypes;
			}
		  }
		  System.Reflection.MethodInfo method = paramBaseEntity.GetType().GetMethod(str2, arrayOfClass);
		  method.invoke(paramBaseEntity, new object[] {paramObject});
		}
		else
		{
		  System.Reflection.MethodInfo method = paramBaseEntity.GetType().GetMethod(str2, new Type[] {clazz});
		  method.invoke(paramBaseEntity, new object[] {paramObject});
		}
		return true;
	  }

	  private static void setCustomFieldValue(ResourceTable paramResourceTable, string paramString, bool paramBoolean)
	  {
		  setCustomFieldValue(paramResourceTable, paramString, paramBoolean, true);
	  }

	  private static void setCustomFieldValue(ResourceTable paramResourceTable, string paramString, bool paramBoolean1, bool paramBoolean2)
	  {
		FieldCustomizationTable fieldCustomizationTable = FieldLookupUtil.Instance.customizationForField(paramString, "boqitem");
		try
		{
		  if (string.ReferenceEquals(fieldCustomizationTable.Formula, null) && fieldCustomizationTable.SelectionList.Value)
		  {
			object @object = getFieldValue(paramResourceTable, paramString);
			if (paramBoolean1)
			{
			  if (@object == null || StringUtils.isNullOrBlank(@object.ToString()))
			  {
				if (!StringUtils.isNullOrBlank(fieldCustomizationTable.DefSelection) && StringUtils.isDecimal(fieldCustomizationTable.DefSelection))
				{
				  setFieldValue(paramResourceTable, paramString, new BigDecimalFixed(fieldCustomizationTable.DefSelection));
				}
				else
				{
				  setFieldValue(paramResourceTable, paramString, BigDecimalMath.ZERO);
				}
			  }
			}
			else if (@object == null || StringUtils.isNullOrBlank(@object.ToString()))
			{
			  if (!StringUtils.isNullOrBlank(fieldCustomizationTable.DefSelection))
			  {
				setFieldValue(paramResourceTable, paramString, fieldCustomizationTable.DefSelection);
			  }
			  else
			  {
				setFieldValue(paramResourceTable, paramString, "");
			  }
			}
			if (paramBoolean2)
			{
			  setFieldValue(paramResourceTable, paramString + "Formula", null);
			}
		  }
		  else if (paramBoolean2)
		  {
			setFieldValue(paramResourceTable, paramString + "Formula", fieldCustomizationTable.Formula);
		  }
		}
		catch (Exception)
		{
		  Console.WriteLine("I COULD NOT SET A VALUE FOR: " + paramString);
		}
	  }

	  public static BoqItemTable createBlankBoqItem(BaseEntity paramBaseEntity, long? paramLong, DateTime paramDate, bool paramBoolean)
	  { // Byte code:
		//   0: new nomitech/common/db/project/BoqItemTable
		//   3: dup
		//   4: invokespecial <init> : ()V
		//   7: astore #4
		//   9: iconst_0
		//   10: istore #5
		//   12: iload #5
		//   14: getstatic nomitech/common/db/project/BoqItemTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   17: arraylength
		//   18: if_icmpge -> 668
		//   21: getstatic nomitech/common/db/project/BoqItemTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   24: iload #5
		//   26: aaload
		//   27: astore #6
		//   29: getstatic nomitech/common/db/project/BoqItemTable.CLASSES : [Ljava/lang/Class;
		//   32: iload #5
		//   34: aaload
		//   35: astore #7
		//   37: aload_0
		//   38: aload #6
		//   40: invokestatic getFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;)Ljava/lang/Object;
		//   43: astore #8
		//   45: aload #8
		//   47: ifnull -> 68
		//   50: aload #4
		//   52: aload #6
		//   54: aload #8
		//   56: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   59: pop
		//   60: goto -> 662
		//   63: astore #9
		//   65: aconst_null
		//   66: astore #8
		//   68: aload #6
		//   70: ldc 'calculationType'
		//   72: invokevirtual equals : (Ljava/lang/Object;)Z
		//   75: ifeq -> 104
		//   78: iload_3
		//   79: ifeq -> 93
		//   82: aload #4
		//   84: getstatic nomitech/common/db/project/BoqItemTable.s_PRODUCTIVITY_METHOD : Ljava/lang/String;
		//   87: invokevirtual setCalculationType : (Ljava/lang/String;)V
		//   90: goto -> 662
		//   93: aload #4
		//   95: getstatic nomitech/common/db/project/BoqItemTable.s_TOTAL_UNITS_METHOD : Ljava/lang/String;
		//   98: invokevirtual setCalculationType : (Ljava/lang/String;)V
		//   101: goto -> 662
		//   104: aload #6
		//   106: ldc 'status'
		//   108: invokevirtual equals : (Ljava/lang/Object;)Z
		//   111: ifeq -> 124
		//   114: aload #4
		//   116: ldc 'enum.boqstatus.pending'
		//   118: invokevirtual setStatus : (Ljava/lang/String;)V
		//   121: goto -> 662
		//   124: aload #6
		//   126: ldc 'surfaceType'
		//   128: invokevirtual equals : (Ljava/lang/Object;)Z
		//   131: ifeq -> 144
		//   134: aload #4
		//   136: ldc 'enum.boqsurfacetype.superstructure'
		//   138: invokevirtual setSurfaceType : (Ljava/lang/String;)V
		//   141: goto -> 662
		//   144: aload #6
		//   146: ldc 'accuracy'
		//   148: invokevirtual equals : (Ljava/lang/Object;)Z
		//   151: ifeq -> 164
		//   154: aload #4
		//   156: ldc 'enum.quotation.accuracy.estimated'
		//   158: invokevirtual setAccuracy : (Ljava/lang/String;)V
		//   161: goto -> 662
		//   164: aload #6
		//   166: ldc 'planningType'
		//   168: invokevirtual equals : (Ljava/lang/Object;)Z
		//   171: ifeq -> 185
		//   174: aload #4
		//   176: getstatic nomitech/common/db/project/BoqItemTable.s_SCHEDULED : Ljava/lang/String;
		//   179: invokevirtual setPlanningType : (Ljava/lang/String;)V
		//   182: goto -> 662
		//   185: aload #6
		//   187: ldc 'activityBased'
		//   189: invokevirtual equals : (Ljava/lang/Object;)Z
		//   192: ifeq -> 206
		//   195: aload #4
		//   197: getstatic java/lang/Boolean.TRUE : Ljava/lang/Boolean;
		//   200: invokevirtual setActivityBased : (Ljava/lang/Boolean;)V
		//   203: goto -> 662
		//   206: aload #7
		//   208: ldc java/lang/String
		//   210: invokevirtual equals : (Ljava/lang/Object;)Z
		//   213: ifeq -> 260
		//   216: aload #4
		//   218: aload #6
		//   220: ldc ''
		//   222: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   225: pop
		//   226: goto -> 662
		//   229: astore #9
		//   231: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   234: new java/lang/StringBuilder
		//   237: dup
		//   238: invokespecial <init> : ()V
		//   241: ldc 'I COULD NOT SET A STRING FOR: '
		//   243: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   246: aload #6
		//   248: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   251: invokevirtual toString : ()Ljava/lang/String;
		//   254: invokevirtual println : (Ljava/lang/String;)V
		//   257: goto -> 662
		//   260: aload #7
		//   262: ldc java/math/BigDecimal
		//   264: invokevirtual equals : (Ljava/lang/Object;)Z
		//   267: ifeq -> 315
		//   270: aload #4
		//   272: aload #6
		//   274: getstatic nomitech/common/util/BigDecimalMath.ZERO : Ljava/math/BigDecimal;
		//   277: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   280: pop
		//   281: goto -> 662
		//   284: astore #9
		//   286: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   289: new java/lang/StringBuilder
		//   292: dup
		//   293: invokespecial <init> : ()V
		//   296: ldc 'I COULD NOT SET A DECIMAL FOR: '
		//   298: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   301: aload #6
		//   303: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   306: invokevirtual toString : ()Ljava/lang/String;
		//   309: invokevirtual println : (Ljava/lang/String;)V
		//   312: goto -> 662
		//   315: aload #7
		//   317: ldc java/lang/Long
		//   319: invokevirtual equals : (Ljava/lang/Object;)Z
		//   322: ifeq -> 371
		//   325: aload #4
		//   327: aload #6
		//   329: lconst_0
		//   330: invokestatic valueOf : (J)Ljava/lang/Long;
		//   333: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   336: pop
		//   337: goto -> 662
		//   340: astore #9
		//   342: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   345: new java/lang/StringBuilder
		//   348: dup
		//   349: invokespecial <init> : ()V
		//   352: ldc 'I COULD NOT SET A LONG FOR: '
		//   354: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   357: aload #6
		//   359: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   362: invokevirtual toString : ()Ljava/lang/String;
		//   365: invokevirtual println : (Ljava/lang/String;)V
		//   368: goto -> 662
		//   371: aload #7
		//   373: ldc java/lang/Integer
		//   375: invokevirtual equals : (Ljava/lang/Object;)Z
		//   378: ifeq -> 431
		//   381: aload #4
		//   383: aload #6
		//   385: new java/lang/Integer
		//   388: dup
		//   389: iconst_0
		//   390: invokespecial <init> : (I)V
		//   393: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   396: pop
		//   397: goto -> 662
		//   400: astore #9
		//   402: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   405: new java/lang/StringBuilder
		//   408: dup
		//   409: invokespecial <init> : ()V
		//   412: ldc 'I COULD NOT SET AN INTEGER FOR: '
		//   414: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   417: aload #6
		//   419: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   422: invokevirtual toString : ()Ljava/lang/String;
		//   425: invokevirtual println : (Ljava/lang/String;)V
		//   428: goto -> 662
		//   431: aload #7
		//   433: ldc java/lang/Boolean
		//   435: invokevirtual equals : (Ljava/lang/Object;)Z
		//   438: ifeq -> 486
		//   441: aload #4
		//   443: aload #6
		//   445: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   448: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   451: pop
		//   452: goto -> 662
		//   455: astore #9
		//   457: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   460: new java/lang/StringBuilder
		//   463: dup
		//   464: invokespecial <init> : ()V
		//   467: ldc 'I COULD NOT SET A BOOLEAN FOR: '
		//   469: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   472: aload #6
		//   474: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   477: invokevirtual toString : ()Ljava/lang/String;
		//   480: invokevirtual println : (Ljava/lang/String;)V
		//   483: goto -> 662
		//   486: aload #7
		//   488: ldc java/util/Date
		//   490: invokevirtual equals : (Ljava/lang/Object;)Z
		//   493: ifeq -> 662
		//   496: aload #6
		//   498: ldc 'custom'
		//   500: invokevirtual startsWith : (Ljava/lang/String;)Z
		//   503: ifeq -> 616
		//   506: aload #6
		//   508: invokevirtual toLowerCase : ()Ljava/lang/String;
		//   511: ldc 'customdate1'
		//   513: invokevirtual equals : (Ljava/lang/Object;)Z
		//   516: ifeq -> 528
		//   519: aload #4
		//   521: aconst_null
		//   522: invokevirtual setCustomDate1 : (Ljava/util/Date;)V
		//   525: goto -> 631
		//   528: aload #6
		//   530: invokevirtual toLowerCase : ()Ljava/lang/String;
		//   533: ldc 'customdate2'
		//   535: invokevirtual equals : (Ljava/lang/Object;)Z
		//   538: ifeq -> 550
		//   541: aload #4
		//   543: aconst_null
		//   544: invokevirtual setCustomDate2 : (Ljava/util/Date;)V
		//   547: goto -> 631
		//   550: aload #6
		//   552: invokevirtual toLowerCase : ()Ljava/lang/String;
		//   555: ldc 'customdate3'
		//   557: invokevirtual equals : (Ljava/lang/Object;)Z
		//   560: ifeq -> 572
		//   563: aload #4
		//   565: aconst_null
		//   566: invokevirtual setCustomDate3 : (Ljava/util/Date;)V
		//   569: goto -> 631
		//   572: aload #6
		//   574: invokevirtual toLowerCase : ()Ljava/lang/String;
		//   577: ldc 'customdate4'
		//   579: invokevirtual equals : (Ljava/lang/Object;)Z
		//   582: ifeq -> 594
		//   585: aload #4
		//   587: aconst_null
		//   588: invokevirtual setCustomDate4 : (Ljava/util/Date;)V
		//   591: goto -> 631
		//   594: aload #6
		//   596: invokevirtual toLowerCase : ()Ljava/lang/String;
		//   599: ldc 'customdate5'
		//   601: invokevirtual equals : (Ljava/lang/Object;)Z
		//   604: ifeq -> 631
		//   607: aload #4
		//   609: aconst_null
		//   610: invokevirtual setCustomDate5 : (Ljava/util/Date;)V
		//   613: goto -> 631
		//   616: aload #4
		//   618: aload #6
		//   620: new java/util/Date
		//   623: dup
		//   624: invokespecial <init> : ()V
		//   627: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   630: pop
		//   631: goto -> 662
		//   634: astore #9
		//   636: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   639: new java/lang/StringBuilder
		//   642: dup
		//   643: invokespecial <init> : ()V
		//   646: ldc 'I COULD NOT SET A DATE FOR: '
		//   648: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   651: aload #6
		//   653: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   656: invokevirtual toString : ()Ljava/lang/String;
		//   659: invokevirtual println : (Ljava/lang/String;)V
		//   662: iinc #5, 1
		//   665: goto -> 12
		//   668: aload_1
		//   669: ifnull -> 678
		//   672: aload #4
		//   674: aload_1
		//   675: invokevirtual setCode : (Ljava/lang/Long;)V
		//   678: aload_0
		//   679: ifnull -> 716
		//   682: aload_0
		//   683: instanceof nomitech/common/base/ResourceTable
		//   686: ifeq -> 716
		//   689: aload_0
		//   690: checkcast nomitech/common/base/ResourceTable
		//   693: astore #5
		//   695: aload #5
		//   697: invokevirtual getItemCode : ()Ljava/lang/String;
		//   700: invokestatic isNullOrBlank : (Ljava/lang/String;)Z
		//   703: ifne -> 716
		//   706: aload #4
		//   708: aload #5
		//   710: invokevirtual getItemCode : ()Ljava/lang/String;
		//   713: invokevirtual setItemCode : (Ljava/lang/String;)V
		//   716: aload_2
		//   717: ifnull -> 726
		//   720: aload #4
		//   722: aload_2
		//   723: invokevirtual setPaymentDate : (Ljava/util/Date;)V
		//   726: aload #4
		//   728: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   731: ldc 'totalCost'
		//   733: ldc 'boqitem'
		//   735: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   738: invokevirtual getFormula : ()Ljava/lang/String;
		//   741: invokevirtual setTotalCostFormula : (Ljava/lang/String;)V
		//   744: aload #4
		//   746: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   749: ldc 'offeredPrice'
		//   751: ldc 'boqitem'
		//   753: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   756: invokevirtual getFormula : ()Ljava/lang/String;
		//   759: invokevirtual setOfferedPriceFormula : (Ljava/lang/String;)V
		//   762: aload #4
		//   764: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   767: ldc 'markup'
		//   769: ldc 'boqitem'
		//   771: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   774: invokevirtual getFormula : ()Ljava/lang/String;
		//   777: invokevirtual setMarkupFormula : (Ljava/lang/String;)V
		//   780: aload #4
		//   782: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   785: ldc 'productivity'
		//   787: ldc 'boqitem'
		//   789: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   792: invokevirtual getFormula : ()Ljava/lang/String;
		//   795: invokevirtual setProductivityFormula : (Ljava/lang/String;)V
		//   798: aload #4
		//   800: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   803: ldc 'adjustedProd'
		//   805: ldc 'boqitem'
		//   807: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   810: invokevirtual getFormula : ()Ljava/lang/String;
		//   813: invokevirtual setAdjustedProdFormula : (Ljava/lang/String;)V
		//   816: aload #4
		//   818: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   821: ldc 'prodFactor'
		//   823: ldc 'boqitem'
		//   825: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   828: invokevirtual getFormula : ()Ljava/lang/String;
		//   831: invokevirtual setProdFactorFormula : (Ljava/lang/String;)V
		//   834: aload #4
		//   836: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   839: ldc 'mhoursFactor'
		//   841: ldc 'boqitem'
		//   843: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   846: invokevirtual getFormula : ()Ljava/lang/String;
		//   849: invokevirtual setMhoursFactorFormula : (Ljava/lang/String;)V
		//   852: aload #4
		//   854: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   857: ldc 'duration'
		//   859: ldc 'boqitem'
		//   861: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   864: invokevirtual getFormula : ()Ljava/lang/String;
		//   867: invokevirtual setDurationFormula : (Ljava/lang/String;)V
		//   870: aload #4
		//   872: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   875: ldc 'unitManhours'
		//   877: ldc 'boqitem'
		//   879: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   882: invokevirtual getFormula : ()Ljava/lang/String;
		//   885: invokevirtual setUnitManhoursFormula : (Ljava/lang/String;)V
		//   888: aload #4
		//   890: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   893: ldc 'adjustedUnitManhours'
		//   895: ldc 'boqitem'
		//   897: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   900: invokevirtual getFormula : ()Ljava/lang/String;
		//   903: invokevirtual setAdjustedUnitManhoursFormula : (Ljava/lang/String;)V
		//   906: aload #4
		//   908: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   911: ldc 'quantity'
		//   913: ldc 'boqitem'
		//   915: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   918: invokevirtual getFormula : ()Ljava/lang/String;
		//   921: invokevirtual setQuantityFormula : (Ljava/lang/String;)V
		//   924: aload #4
		//   926: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   929: ldc 'measuredQuantity'
		//   931: ldc 'boqitem'
		//   933: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   936: invokevirtual getFormula : ()Ljava/lang/String;
		//   939: invokevirtual setMeasuredQuantityFormula : (Ljava/lang/String;)V
		//   942: aload #4
		//   944: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   947: ldc 'estimatedQuantity'
		//   949: ldc 'boqitem'
		//   951: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   954: invokevirtual getFormula : ()Ljava/lang/String;
		//   957: invokevirtual setEstimatedQuantityFormula : (Ljava/lang/String;)V
		//   960: aload #4
		//   962: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   965: ldc 'quantityLoss'
		//   967: ldc 'boqitem'
		//   969: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   972: invokevirtual getFormula : ()Ljava/lang/String;
		//   975: invokevirtual setQuantityLossFormula : (Ljava/lang/String;)V
		//   978: aload #4
		//   980: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   983: ldc 'rate'
		//   985: ldc 'boqitem'
		//   987: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   990: invokevirtual getFormula : ()Ljava/lang/String;
		//   993: invokevirtual setRateFormula : (Ljava/lang/String;)V
		//   996: aload #4
		//   998: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   1001: ldc 'offeredRate'
		//   1003: ldc 'boqitem'
		//   1005: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   1008: invokevirtual getFormula : ()Ljava/lang/String;
		//   1011: invokevirtual setOfferedRateFormula : (Ljava/lang/String;)V
		//   1014: aload #4
		//   1016: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   1019: ldc 'offeredSecondRate'
		//   1021: ldc 'boqitem'
		//   1023: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   1026: invokevirtual getFormula : ()Ljava/lang/String;
		//   1029: invokevirtual setOfferedSecondRateFormula : (Ljava/lang/String;)V
		//   1032: aload #4
		//   1034: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   1037: ldc 'secondRate'
		//   1039: ldc 'boqitem'
		//   1041: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   1044: invokevirtual getFormula : ()Ljava/lang/String;
		//   1047: invokevirtual setSecondRateFormula : (Ljava/lang/String;)V
		//   1050: aload #4
		//   1052: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   1055: ldc 'secondQuantity'
		//   1057: ldc 'boqitem'
		//   1059: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   1062: invokevirtual getFormula : ()Ljava/lang/String;
		//   1065: invokevirtual setSecondQuantityFormula : (Ljava/lang/String;)V
		//   1068: aload #4
		//   1070: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   1073: ldc 'secondUnit'
		//   1075: ldc 'boqitem'
		//   1077: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   1080: invokevirtual getFormula : ()Ljava/lang/String;
		//   1083: invokevirtual setSecondUnitFormula : (Ljava/lang/String;)V
		//   1086: aload #4
		//   1088: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   1091: ldc 'unitsDiv'
		//   1093: ldc 'boqitem'
		//   1095: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   1098: invokevirtual getFormula : ()Ljava/lang/String;
		//   1101: invokevirtual setUnitsDivFormula : (Ljava/lang/String;)V
		//   1104: aload #4
		//   1106: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   1109: ldc 'assemblyTotalCost'
		//   1111: ldc 'boqitem'
		//   1113: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   1116: invokevirtual getFormula : ()Ljava/lang/String;
		//   1119: invokevirtual setAssemblyTotalCostFormula : (Ljava/lang/String;)V
		//   1122: aload #4
		//   1124: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   1127: ldc 'equipmentTotalCost'
		//   1129: ldc 'boqitem'
		//   1131: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   1134: invokevirtual getFormula : ()Ljava/lang/String;
		//   1137: invokevirtual setEquipmentTotalCostFormula : (Ljava/lang/String;)V
		//   1140: aload #4
		//   1142: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   1145: ldc 'materialTotalCost'
		//   1147: ldc 'boqitem'
		//   1149: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   1152: invokevirtual getFormula : ()Ljava/lang/String;
		//   1155: invokevirtual setMaterialTotalCostFormula : (Ljava/lang/String;)V
		//   1158: aload #4
		//   1160: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   1163: ldc 'subcontractorTotalCost'
		//   1165: ldc 'boqitem'
		//   1167: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   1170: invokevirtual getFormula : ()Ljava/lang/String;
		//   1173: invokevirtual setSubcontractorTotalCostFormula : (Ljava/lang/String;)V
		//   1176: aload #4
		//   1178: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   1181: ldc 'laborTotalCost'
		//   1183: ldc 'boqitem'
		//   1185: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   1188: invokevirtual getFormula : ()Ljava/lang/String;
		//   1191: invokevirtual setLaborTotalCostFormula : (Ljava/lang/String;)V
		//   1194: aload #4
		//   1196: invokestatic getInstance : ()Lnomitech/common/fields/FieldLookupUtil;
		//   1199: ldc 'consumableTotalCost'
		//   1201: ldc 'boqitem'
		//   1203: invokevirtual customizationForField : (Ljava/lang/String;Ljava/lang/String;)Lnomitech/common/db/local/FieldCustomizationTable;
		//   1206: invokevirtual getFormula : ()Ljava/lang/String;
		//   1209: invokevirtual setConsumableTotalCostFormula : (Ljava/lang/String;)V
		//   1212: aload #4
		//   1214: ldc 'customRate1'
		//   1216: iconst_1
		//   1217: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1220: aload #4
		//   1222: ldc 'customRate2'
		//   1224: iconst_1
		//   1225: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1228: aload #4
		//   1230: ldc 'customRate3'
		//   1232: iconst_1
		//   1233: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1236: aload #4
		//   1238: ldc 'customRate4'
		//   1240: iconst_1
		//   1241: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1244: aload #4
		//   1246: ldc 'customRate5'
		//   1248: iconst_1
		//   1249: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1252: aload #4
		//   1254: ldc 'customRate6'
		//   1256: iconst_1
		//   1257: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1260: aload #4
		//   1262: ldc 'customRate7'
		//   1264: iconst_1
		//   1265: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1268: aload #4
		//   1270: ldc 'customRate8'
		//   1272: iconst_1
		//   1273: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1276: aload #4
		//   1278: ldc 'customRate9'
		//   1280: iconst_1
		//   1281: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1284: aload #4
		//   1286: ldc 'customRate10'
		//   1288: iconst_1
		//   1289: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1292: aload #4
		//   1294: ldc 'customRate11'
		//   1296: iconst_1
		//   1297: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1300: aload #4
		//   1302: ldc 'customRate12'
		//   1304: iconst_1
		//   1305: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1308: aload #4
		//   1310: ldc 'customRate13'
		//   1312: iconst_1
		//   1313: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1316: aload #4
		//   1318: ldc 'customRate14'
		//   1320: iconst_1
		//   1321: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1324: aload #4
		//   1326: ldc 'customRate15'
		//   1328: iconst_1
		//   1329: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1332: aload #4
		//   1334: ldc 'customRate16'
		//   1336: iconst_1
		//   1337: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1340: aload #4
		//   1342: ldc 'customRate17'
		//   1344: iconst_1
		//   1345: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1348: aload #4
		//   1350: ldc 'customRate18'
		//   1352: iconst_1
		//   1353: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1356: aload #4
		//   1358: ldc 'customRate19'
		//   1360: iconst_1
		//   1361: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1364: aload #4
		//   1366: ldc 'customRate20'
		//   1368: iconst_1
		//   1369: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1372: aload #4
		//   1374: ldc 'customCumRate1'
		//   1376: iconst_1
		//   1377: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1380: aload #4
		//   1382: ldc 'customCumRate2'
		//   1384: iconst_1
		//   1385: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1388: aload #4
		//   1390: ldc 'customCumRate3'
		//   1392: iconst_1
		//   1393: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1396: aload #4
		//   1398: ldc 'customCumRate4'
		//   1400: iconst_1
		//   1401: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1404: aload #4
		//   1406: ldc 'customCumRate5'
		//   1408: iconst_1
		//   1409: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1412: aload #4
		//   1414: ldc 'customCumRate6'
		//   1416: iconst_1
		//   1417: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1420: aload #4
		//   1422: ldc 'customCumRate7'
		//   1424: iconst_1
		//   1425: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1428: aload #4
		//   1430: ldc 'customCumRate8'
		//   1432: iconst_1
		//   1433: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1436: aload #4
		//   1438: ldc 'customCumRate9'
		//   1440: iconst_1
		//   1441: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1444: aload #4
		//   1446: ldc 'customCumRate10'
		//   1448: iconst_1
		//   1449: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1452: aload #4
		//   1454: ldc 'customCumRate11'
		//   1456: iconst_1
		//   1457: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1460: aload #4
		//   1462: ldc 'customCumRate12'
		//   1464: iconst_1
		//   1465: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1468: aload #4
		//   1470: ldc 'customCumRate13'
		//   1472: iconst_1
		//   1473: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1476: aload #4
		//   1478: ldc 'customCumRate14'
		//   1480: iconst_1
		//   1481: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1484: aload #4
		//   1486: ldc 'customCumRate15'
		//   1488: iconst_1
		//   1489: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1492: aload #4
		//   1494: ldc 'customCumRate16'
		//   1496: iconst_1
		//   1497: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1500: aload #4
		//   1502: ldc 'customCumRate17'
		//   1504: iconst_1
		//   1505: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1508: aload #4
		//   1510: ldc 'customCumRate18'
		//   1512: iconst_1
		//   1513: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1516: aload #4
		//   1518: ldc 'customCumRate19'
		//   1520: iconst_1
		//   1521: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1524: aload #4
		//   1526: ldc 'customCumRate20'
		//   1528: iconst_1
		//   1529: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1532: aload #4
		//   1534: ldc 'customPercentRate1'
		//   1536: iconst_1
		//   1537: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1540: aload #4
		//   1542: ldc 'customPercentRate2'
		//   1544: iconst_1
		//   1545: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1548: aload #4
		//   1550: ldc 'customPercentRate3'
		//   1552: iconst_1
		//   1553: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1556: aload #4
		//   1558: ldc 'customPercentRate4'
		//   1560: iconst_1
		//   1561: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1564: aload #4
		//   1566: ldc 'customPercentRate5'
		//   1568: iconst_1
		//   1569: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1572: aload #4
		//   1574: ldc 'customPercentRate6'
		//   1576: iconst_1
		//   1577: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1580: aload #4
		//   1582: ldc 'customPercentRate7'
		//   1584: iconst_1
		//   1585: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1588: aload #4
		//   1590: ldc 'customPercentRate8'
		//   1592: iconst_1
		//   1593: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1596: aload #4
		//   1598: ldc 'customPercentRate9'
		//   1600: iconst_1
		//   1601: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1604: aload #4
		//   1606: ldc 'customPercentRate10'
		//   1608: iconst_1
		//   1609: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1612: aload #4
		//   1614: ldc 'customPercentRate11'
		//   1616: iconst_1
		//   1617: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1620: aload #4
		//   1622: ldc 'customPercentRate12'
		//   1624: iconst_1
		//   1625: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1628: aload #4
		//   1630: ldc 'customPercentRate13'
		//   1632: iconst_1
		//   1633: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1636: aload #4
		//   1638: ldc 'customPercentRate14'
		//   1640: iconst_1
		//   1641: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1644: aload #4
		//   1646: ldc 'customPercentRate15'
		//   1648: iconst_1
		//   1649: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1652: aload #4
		//   1654: ldc 'customPercentRate16'
		//   1656: iconst_1
		//   1657: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1660: aload #4
		//   1662: ldc 'customPercentRate17'
		//   1664: iconst_1
		//   1665: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1668: aload #4
		//   1670: ldc 'customPercentRate18'
		//   1672: iconst_1
		//   1673: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1676: aload #4
		//   1678: ldc 'customPercentRate19'
		//   1680: iconst_1
		//   1681: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1684: aload #4
		//   1686: ldc 'customPercentRate20'
		//   1688: iconst_1
		//   1689: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1692: aload #4
		//   1694: ldc 'customText1'
		//   1696: iconst_0
		//   1697: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1700: aload #4
		//   1702: ldc 'customText2'
		//   1704: iconst_0
		//   1705: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1708: aload #4
		//   1710: ldc 'customText3'
		//   1712: iconst_0
		//   1713: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1716: aload #4
		//   1718: ldc 'customText4'
		//   1720: iconst_0
		//   1721: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1724: aload #4
		//   1726: ldc 'customText5'
		//   1728: iconst_0
		//   1729: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1732: aload #4
		//   1734: ldc 'customText6'
		//   1736: iconst_0
		//   1737: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1740: aload #4
		//   1742: ldc 'customText7'
		//   1744: iconst_0
		//   1745: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1748: aload #4
		//   1750: ldc 'customText8'
		//   1752: iconst_0
		//   1753: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1756: aload #4
		//   1758: ldc 'customText9'
		//   1760: iconst_0
		//   1761: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1764: aload #4
		//   1766: ldc 'customText10'
		//   1768: iconst_0
		//   1769: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1772: aload #4
		//   1774: ldc 'customText11'
		//   1776: iconst_0
		//   1777: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1780: aload #4
		//   1782: ldc 'customText12'
		//   1784: iconst_0
		//   1785: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1788: aload #4
		//   1790: ldc 'customText13'
		//   1792: iconst_0
		//   1793: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1796: aload #4
		//   1798: ldc 'customText14'
		//   1800: iconst_0
		//   1801: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1804: aload #4
		//   1806: ldc 'customText15'
		//   1808: iconst_0
		//   1809: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1812: aload #4
		//   1814: ldc 'customText16'
		//   1816: iconst_0
		//   1817: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1820: aload #4
		//   1822: ldc 'customText17'
		//   1824: iconst_0
		//   1825: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1828: aload #4
		//   1830: ldc 'customText18'
		//   1832: iconst_0
		//   1833: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1836: aload #4
		//   1838: ldc 'customText19'
		//   1840: iconst_0
		//   1841: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1844: aload #4
		//   1846: ldc 'customText20'
		//   1848: iconst_0
		//   1849: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1852: aload #4
		//   1854: ldc 'customText21'
		//   1856: iconst_0
		//   1857: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1860: aload #4
		//   1862: ldc 'customText22'
		//   1864: iconst_0
		//   1865: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1868: aload #4
		//   1870: ldc 'customText23'
		//   1872: iconst_0
		//   1873: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1876: aload #4
		//   1878: ldc 'customText24'
		//   1880: iconst_0
		//   1881: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1884: aload #4
		//   1886: ldc 'customText25'
		//   1888: iconst_0
		//   1889: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;Z)V
		//   1892: aload #4
		//   1894: invokevirtual getHasProductivity : ()Ljava/lang/Boolean;
		//   1897: invokevirtual booleanValue : ()Z
		//   1900: ifeq -> 1912
		//   1903: aload #4
		//   1905: aconst_null
		//   1906: invokevirtual setProductivityFormula : (Ljava/lang/String;)V
		//   1909: goto -> 1918
		//   1912: aload #4
		//   1914: aconst_null
		//   1915: invokevirtual setDurationFormula : (Ljava/lang/String;)V
		//   1918: aload #4
		//   1920: invokevirtual getMhoursFactorFormula : ()Ljava/lang/String;
		//   1923: invokestatic isNullOrBlank : (Ljava/lang/String;)Z
		//   1926: ifne -> 1935
		//   1929: aload #4
		//   1931: aconst_null
		//   1932: invokevirtual setProdFactorFormula : (Ljava/lang/String;)V
		//   1935: aload #4
		//   1937: new java/util/HashSet
		//   1940: dup
		//   1941: iconst_0
		//   1942: invokespecial <init> : (I)V
		//   1945: invokevirtual setQuoteItemSet : (Ljava/util/Set;)V
		//   1948: aload #4
		//   1950: new java/util/HashSet
		//   1953: dup
		//   1954: iconst_0
		//   1955: invokespecial <init> : (I)V
		//   1958: invokevirtual setBoqItemLaborSet : (Ljava/util/Set;)V
		//   1961: aload #4
		//   1963: new java/util/HashSet
		//   1966: dup
		//   1967: iconst_0
		//   1968: invokespecial <init> : (I)V
		//   1971: invokevirtual setResourceHistorySet : (Ljava/util/Set;)V
		//   1974: aload #4
		//   1976: new java/util/HashSet
		//   1979: dup
		//   1980: iconst_0
		//   1981: invokespecial <init> : (I)V
		//   1984: invokevirtual setBoqItemMaterialSet : (Ljava/util/Set;)V
		//   1987: aload #4
		//   1989: new java/util/HashSet
		//   1992: dup
		//   1993: iconst_0
		//   1994: invokespecial <init> : (I)V
		//   1997: invokevirtual setBoqItemAssemblySet : (Ljava/util/Set;)V
		//   2000: aload #4
		//   2002: new java/util/HashSet
		//   2005: dup
		//   2006: iconst_0
		//   2007: invokespecial <init> : (I)V
		//   2010: invokevirtual setBoqItemConditionSet : (Ljava/util/Set;)V
		//   2013: aload #4
		//   2015: new java/util/HashSet
		//   2018: dup
		//   2019: iconst_0
		//   2020: invokespecial <init> : (I)V
		//   2023: invokevirtual setBoqItemEquipmentSet : (Ljava/util/Set;)V
		//   2026: aload #4
		//   2028: new java/util/HashSet
		//   2031: dup
		//   2032: iconst_0
		//   2033: invokespecial <init> : (I)V
		//   2036: invokevirtual setBoqItemConsumableSet : (Ljava/util/Set;)V
		//   2039: aload #4
		//   2041: new java/util/HashSet
		//   2044: dup
		//   2045: iconst_0
		//   2046: invokespecial <init> : (I)V
		//   2049: invokevirtual setBoqItemSubcontractorSet : (Ljava/util/Set;)V
		//   2052: aload #4
		//   2054: bipush #6
		//   2056: invokestatic valueOf : (B)Ljava/lang/Byte;
		//   2059: invokevirtual setLaborRateType : (Ljava/lang/Byte;)V
		//   2062: aload #4
		//   2064: bipush #6
		//   2066: invokestatic valueOf : (B)Ljava/lang/Byte;
		//   2069: invokevirtual setAssemblyRateType : (Ljava/lang/Byte;)V
		//   2072: aload #4
		//   2074: bipush #6
		//   2076: invokestatic valueOf : (B)Ljava/lang/Byte;
		//   2079: invokevirtual setMaterialRateType : (Ljava/lang/Byte;)V
		//   2082: aload #4
		//   2084: bipush #6
		//   2086: invokestatic valueOf : (B)Ljava/lang/Byte;
		//   2089: invokevirtual setEquipmentRateType : (Ljava/lang/Byte;)V
		//   2092: aload #4
		//   2094: bipush #6
		//   2096: invokestatic valueOf : (B)Ljava/lang/Byte;
		//   2099: invokevirtual setSubcontractorRateType : (Ljava/lang/Byte;)V
		//   2102: aload #4
		//   2104: bipush #6
		//   2106: invokestatic valueOf : (B)Ljava/lang/Byte;
		//   2109: invokevirtual setConsumableRateType : (Ljava/lang/Byte;)V
		//   2112: aload #4
		//   2114: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   2117: invokevirtual setVirtual : (Ljava/lang/Boolean;)V
		//   2120: aload #4
		//   2122: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   2125: invokevirtual setPredicted : (Ljava/lang/Boolean;)V
		//   2128: aload #4
		//   2130: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   2133: invokevirtual setQuoted : (Ljava/lang/Boolean;)V
		//   2136: aload #4
		//   2138: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   2141: invokevirtual setConceptual : (Ljava/lang/Boolean;)V
		//   2144: aload #4
		//   2146: iconst_0
		//   2147: invokestatic valueOf : (I)Ljava/lang/Integer;
		//   2150: invokevirtual setOverrideType : (Ljava/lang/Integer;)V
		//   2153: aload_0
		//   2154: ifnull -> 2164
		//   2157: aload_0
		//   2158: instanceof nomitech/common/db/project/BoqItemTable
		//   2161: ifne -> 2170
		//   2164: aload #4
		//   2166: aconst_null
		//   2167: invokevirtual setBoqitemId : (Ljava/lang/Long;)V
		//   2170: aload #4
		//   2172: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   2175: invokevirtual setHasAssignmentFormula : (Ljava/lang/Boolean;)V
		//   2178: aload #4
		//   2180: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   2183: invokevirtual setHasPVFormula : (Ljava/lang/Boolean;)V
		//   2186: aload #4
		//   2188: ldc ''
		//   2190: invokevirtual setPvVars : (Ljava/lang/String;)V
		//   2193: aload #4
		//   2195: ldc ''
		//   2197: invokevirtual setVars : (Ljava/lang/String;)V
		//   2200: aload #4
		//   2202: areturn
		// Exception table:
		//   from	to	target	type
		//   50	60	63	java/lang/Exception
		//   216	226	229	java/lang/Exception
		//   270	281	284	java/lang/Exception
		//   325	337	340	java/lang/Exception
		//   381	397	400	java/lang/Exception
		//   441	452	455	java/lang/Exception
		//   496	631	634	java/lang/Exception }

	  public static AssemblyTable createBlankAssembly(BaseEntity paramBaseEntity)
	  { // Byte code:
		//   0: new nomitech/common/db/local/AssemblyTable
		//   3: dup
		//   4: invokespecial <init> : ()V
		//   7: astore_1
		//   8: iconst_0
		//   9: istore_2
		//   10: iload_2
		//   11: getstatic nomitech/common/db/local/AssemblyTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   14: arraylength
		//   15: if_icmpge -> 405
		//   18: getstatic nomitech/common/db/local/AssemblyTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   21: iload_2
		//   22: aaload
		//   23: astore_3
		//   24: getstatic nomitech/common/db/local/AssemblyTable.CLASSES : [Ljava/lang/Class;
		//   27: iload_2
		//   28: aaload
		//   29: astore #4
		//   31: aload_0
		//   32: aload_3
		//   33: invokestatic getFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;)Ljava/lang/Object;
		//   36: astore #5
		//   38: aload #5
		//   40: ifnull -> 59
		//   43: aload_1
		//   44: aload_3
		//   45: aload #5
		//   47: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   50: pop
		//   51: goto -> 399
		//   54: astore #6
		//   56: aconst_null
		//   57: astore #5
		//   59: aload_3
		//   60: ldc 'accuracy'
		//   62: invokevirtual equals : (Ljava/lang/Object;)Z
		//   65: ifeq -> 77
		//   68: aload_1
		//   69: ldc 'enum.quotation.accuracy.estimated'
		//   71: invokevirtual setAccuracy : (Ljava/lang/String;)V
		//   74: goto -> 399
		//   77: aload #4
		//   79: ldc java/lang/String
		//   81: invokevirtual equals : (Ljava/lang/Object;)Z
		//   84: ifeq -> 128
		//   87: aload_1
		//   88: aload_3
		//   89: ldc ''
		//   91: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   94: pop
		//   95: goto -> 399
		//   98: astore #6
		//   100: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   103: new java/lang/StringBuilder
		//   106: dup
		//   107: invokespecial <init> : ()V
		//   110: ldc 'I COULD NOT SET A STRING FOR: '
		//   112: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   115: aload_3
		//   116: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   119: invokevirtual toString : ()Ljava/lang/String;
		//   122: invokevirtual println : (Ljava/lang/String;)V
		//   125: goto -> 399
		//   128: aload #4
		//   130: ldc java/math/BigDecimal
		//   132: invokevirtual equals : (Ljava/lang/Object;)Z
		//   135: ifeq -> 180
		//   138: aload_1
		//   139: aload_3
		//   140: getstatic nomitech/common/util/BigDecimalMath.ZERO : Ljava/math/BigDecimal;
		//   143: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   146: pop
		//   147: goto -> 399
		//   150: astore #6
		//   152: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   155: new java/lang/StringBuilder
		//   158: dup
		//   159: invokespecial <init> : ()V
		//   162: ldc 'I COULD NOT SET A DECIMAL FOR: '
		//   164: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   167: aload_3
		//   168: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   171: invokevirtual toString : ()Ljava/lang/String;
		//   174: invokevirtual println : (Ljava/lang/String;)V
		//   177: goto -> 399
		//   180: aload #4
		//   182: ldc java/lang/Long
		//   184: invokevirtual equals : (Ljava/lang/Object;)Z
		//   187: ifeq -> 237
		//   190: aload_1
		//   191: aload_3
		//   192: new java/lang/Long
		//   195: dup
		//   196: lconst_0
		//   197: invokespecial <init> : (J)V
		//   200: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   203: pop
		//   204: goto -> 399
		//   207: astore #6
		//   209: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   212: new java/lang/StringBuilder
		//   215: dup
		//   216: invokespecial <init> : ()V
		//   219: ldc 'I COULD NOT SET A LONG FOR: '
		//   221: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   224: aload_3
		//   225: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   228: invokevirtual toString : ()Ljava/lang/String;
		//   231: invokevirtual println : (Ljava/lang/String;)V
		//   234: goto -> 399
		//   237: aload #4
		//   239: ldc java/lang/Integer
		//   241: invokevirtual equals : (Ljava/lang/Object;)Z
		//   244: ifeq -> 294
		//   247: aload_1
		//   248: aload_3
		//   249: new java/lang/Integer
		//   252: dup
		//   253: iconst_0
		//   254: invokespecial <init> : (I)V
		//   257: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   260: pop
		//   261: goto -> 399
		//   264: astore #6
		//   266: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   269: new java/lang/StringBuilder
		//   272: dup
		//   273: invokespecial <init> : ()V
		//   276: ldc 'I COULD NOT SET AN INTEGER FOR: '
		//   278: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   281: aload_3
		//   282: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   285: invokevirtual toString : ()Ljava/lang/String;
		//   288: invokevirtual println : (Ljava/lang/String;)V
		//   291: goto -> 399
		//   294: aload #4
		//   296: ldc java/lang/Boolean
		//   298: invokevirtual equals : (Ljava/lang/Object;)Z
		//   301: ifeq -> 346
		//   304: aload_1
		//   305: aload_3
		//   306: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   309: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   312: pop
		//   313: goto -> 399
		//   316: astore #6
		//   318: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   321: new java/lang/StringBuilder
		//   324: dup
		//   325: invokespecial <init> : ()V
		//   328: ldc 'I COULD NOT SET A BOOLEAN FOR: '
		//   330: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   333: aload_3
		//   334: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   337: invokevirtual toString : ()Ljava/lang/String;
		//   340: invokevirtual println : (Ljava/lang/String;)V
		//   343: goto -> 399
		//   346: aload #4
		//   348: ldc java/util/Date
		//   350: invokevirtual equals : (Ljava/lang/Object;)Z
		//   353: ifeq -> 399
		//   356: aload_1
		//   357: aload_3
		//   358: new java/util/Date
		//   361: dup
		//   362: invokespecial <init> : ()V
		//   365: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   368: pop
		//   369: goto -> 399
		//   372: astore #6
		//   374: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   377: new java/lang/StringBuilder
		//   380: dup
		//   381: invokespecial <init> : ()V
		//   384: ldc 'I COULD NOT SET A DATE FOR: '
		//   386: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   389: aload_3
		//   390: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   393: invokevirtual toString : ()Ljava/lang/String;
		//   396: invokevirtual println : (Ljava/lang/String;)V
		//   399: iinc #2, 1
		//   402: goto -> 10
		//   405: aload_1
		//   406: ldc 'customText1'
		//   408: iconst_0
		//   409: iconst_0
		//   410: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   413: aload_1
		//   414: ldc 'customText2'
		//   416: iconst_0
		//   417: iconst_0
		//   418: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   421: aload_1
		//   422: ldc 'customText3'
		//   424: iconst_0
		//   425: iconst_0
		//   426: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   429: aload_1
		//   430: ldc 'customText4'
		//   432: iconst_0
		//   433: iconst_0
		//   434: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   437: aload_1
		//   438: ldc 'customText5'
		//   440: iconst_0
		//   441: iconst_0
		//   442: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   445: aload_1
		//   446: ldc 'customText6'
		//   448: iconst_0
		//   449: iconst_0
		//   450: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   453: aload_1
		//   454: ldc 'customText7'
		//   456: iconst_0
		//   457: iconst_0
		//   458: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   461: aload_1
		//   462: ldc 'customText8'
		//   464: iconst_0
		//   465: iconst_0
		//   466: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   469: aload_1
		//   470: ldc 'customText9'
		//   472: iconst_0
		//   473: iconst_0
		//   474: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   477: aload_1
		//   478: ldc 'customText10'
		//   480: iconst_0
		//   481: iconst_0
		//   482: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   485: aload_1
		//   486: ldc 'customText11'
		//   488: iconst_0
		//   489: iconst_0
		//   490: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   493: aload_1
		//   494: ldc 'customText12'
		//   496: iconst_0
		//   497: iconst_0
		//   498: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   501: aload_1
		//   502: ldc 'customText13'
		//   504: iconst_0
		//   505: iconst_0
		//   506: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   509: aload_1
		//   510: ldc 'customText14'
		//   512: iconst_0
		//   513: iconst_0
		//   514: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   517: aload_1
		//   518: ldc 'customText15'
		//   520: iconst_0
		//   521: iconst_0
		//   522: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   525: aload_1
		//   526: ldc 'customText16'
		//   528: iconst_0
		//   529: iconst_0
		//   530: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   533: aload_1
		//   534: ldc 'customText17'
		//   536: iconst_0
		//   537: iconst_0
		//   538: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   541: aload_1
		//   542: ldc 'customText18'
		//   544: iconst_0
		//   545: iconst_0
		//   546: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   549: aload_1
		//   550: ldc 'customText19'
		//   552: iconst_0
		//   553: iconst_0
		//   554: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   557: aload_1
		//   558: ldc 'customText20'
		//   560: iconst_0
		//   561: iconst_0
		//   562: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   565: aload_1
		//   566: ldc 'customText21'
		//   568: iconst_0
		//   569: iconst_0
		//   570: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   573: aload_1
		//   574: ldc 'customText22'
		//   576: iconst_0
		//   577: iconst_0
		//   578: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   581: aload_1
		//   582: ldc 'customText23'
		//   584: iconst_0
		//   585: iconst_0
		//   586: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   589: aload_1
		//   590: ldc 'customText24'
		//   592: iconst_0
		//   593: iconst_0
		//   594: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   597: aload_1
		//   598: ldc 'customText25'
		//   600: iconst_0
		//   601: iconst_0
		//   602: invokestatic setCustomFieldValue : (Lnomitech/common/base/ResourceTable;Ljava/lang/String;ZZ)V
		//   605: aload_1
		//   606: getstatic java/lang/Boolean.TRUE : Ljava/lang/Boolean;
		//   609: invokevirtual setActivityBased : (Ljava/lang/Boolean;)V
		//   612: aload_1
		//   613: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   616: invokevirtual setVirtual : (Ljava/lang/Boolean;)V
		//   619: aload_1
		//   620: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   623: invokevirtual setPredicted : (Ljava/lang/Boolean;)V
		//   626: aload_1
		//   627: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   630: invokevirtual setQuoted : (Ljava/lang/Boolean;)V
		//   633: aload_1
		//   634: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   637: invokevirtual setConceptual : (Ljava/lang/Boolean;)V
		//   640: aload_1
		//   641: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   644: invokevirtual setVirtualEquipment : (Ljava/lang/Boolean;)V
		//   647: aload_1
		//   648: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   651: invokevirtual setVirtualSubcontractor : (Ljava/lang/Boolean;)V
		//   654: aload_1
		//   655: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   658: invokevirtual setVirtualLabor : (Ljava/lang/Boolean;)V
		//   661: aload_1
		//   662: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   665: invokevirtual setVirtualMaterial : (Ljava/lang/Boolean;)V
		//   668: aload_1
		//   669: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   672: invokevirtual setVirtualConsumable : (Ljava/lang/Boolean;)V
		//   675: aload_1
		//   676: iconst_0
		//   677: invokestatic valueOf : (I)Ljava/lang/Integer;
		//   680: invokevirtual setOverrideType : (Ljava/lang/Integer;)V
		//   683: aload_0
		//   684: ifnull -> 694
		//   687: aload_0
		//   688: instanceof nomitech/common/db/local/AssemblyTable
		//   691: ifne -> 699
		//   694: aload_1
		//   695: aconst_null
		//   696: invokevirtual setAssemblyId : (Ljava/lang/Long;)V
		//   699: aload_1
		//   700: ldc ''
		//   702: invokevirtual setVars : (Ljava/lang/String;)V
		//   705: aload_1
		//   706: areturn
		// Exception table:
		//   from	to	target	type
		//   43	51	54	java/lang/Exception
		//   87	95	98	java/lang/Exception
		//   138	147	150	java/lang/Exception
		//   190	204	207	java/lang/Exception
		//   247	261	264	java/lang/Exception
		//   304	313	316	java/lang/Exception
		//   356	369	372	java/lang/Exception }

	  public static MaterialTable createBlankMaterial(BaseEntity paramBaseEntity)
	  { // Byte code:
		//   0: new nomitech/common/db/local/MaterialTable
		//   3: dup
		//   4: invokespecial <init> : ()V
		//   7: astore_1
		//   8: aload_0
		//   9: ifnull -> 23
		//   12: aload_0
		//   13: instanceof nomitech/common/db/local/AssemblyTable
		//   16: ifeq -> 23
		//   19: iconst_1
		//   20: goto -> 24
		//   23: iconst_0
		//   24: istore_2
		//   25: iconst_0
		//   26: istore_3
		//   27: iload_3
		//   28: getstatic nomitech/common/db/local/MaterialTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   31: arraylength
		//   32: if_icmpge -> 563
		//   35: getstatic nomitech/common/db/local/MaterialTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   38: iload_3
		//   39: aaload
		//   40: astore #4
		//   42: getstatic nomitech/common/db/local/MaterialTable.CLASSES : [Ljava/lang/Class;
		//   45: iload_3
		//   46: aaload
		//   47: astore #5
		//   49: aload_0
		//   50: aload #4
		//   52: invokestatic getFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;)Ljava/lang/Object;
		//   55: astore #6
		//   57: aload #6
		//   59: ifnull -> 99
		//   62: aload_1
		//   63: aload #4
		//   65: aload #6
		//   67: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   70: pop
		//   71: iload_2
		//   72: ifeq -> 88
		//   75: aload #4
		//   77: ldc 'accuracy'
		//   79: invokevirtual equals : (Ljava/lang/Object;)Z
		//   82: ifeq -> 88
		//   85: goto -> 91
		//   88: goto -> 557
		//   91: goto -> 99
		//   94: astore #7
		//   96: aconst_null
		//   97: astore #6
		//   99: aload #4
		//   101: ldc 'accuracy'
		//   103: invokevirtual equals : (Ljava/lang/Object;)Z
		//   106: ifeq -> 118
		//   109: aload_1
		//   110: ldc 'enum.quotation.accuracy.estimated'
		//   112: invokevirtual setAccuracy : (Ljava/lang/String;)V
		//   115: goto -> 557
		//   118: aload #4
		//   120: ldc_w 'rawMaterial'
		//   123: invokevirtual equals : (Ljava/lang/Object;)Z
		//   126: ifeq -> 139
		//   129: aload_1
		//   130: ldc_w 'enum.rm.unspecified'
		//   133: invokevirtual setRawMaterial : (Ljava/lang/String;)V
		//   136: goto -> 557
		//   139: aload #4
		//   141: ldc_w 'rawMaterial2'
		//   144: invokevirtual equals : (Ljava/lang/Object;)Z
		//   147: ifeq -> 160
		//   150: aload_1
		//   151: ldc_w 'enum.rm.unspecified'
		//   154: invokevirtual setRawMaterial2 : (Ljava/lang/String;)V
		//   157: goto -> 557
		//   160: aload #4
		//   162: ldc_w 'rawMaterial3'
		//   165: invokevirtual equals : (Ljava/lang/Object;)Z
		//   168: ifeq -> 181
		//   171: aload_1
		//   172: ldc_w 'enum.rm.unspecified'
		//   175: invokevirtual setRawMaterial3 : (Ljava/lang/String;)V
		//   178: goto -> 557
		//   181: aload #4
		//   183: ldc_w 'rawMaterial4'
		//   186: invokevirtual equals : (Ljava/lang/Object;)Z
		//   189: ifeq -> 202
		//   192: aload_1
		//   193: ldc_w 'enum.rm.unspecified'
		//   196: invokevirtual setRawMaterial4 : (Ljava/lang/String;)V
		//   199: goto -> 557
		//   202: aload #4
		//   204: ldc_w 'rawMaterial5'
		//   207: invokevirtual equals : (Ljava/lang/Object;)Z
		//   210: ifeq -> 223
		//   213: aload_1
		//   214: ldc_w 'enum.rm.unspecified'
		//   217: invokevirtual setRawMaterial5 : (Ljava/lang/String;)V
		//   220: goto -> 557
		//   223: aload #5
		//   225: ldc java/lang/String
		//   227: invokevirtual equals : (Ljava/lang/Object;)Z
		//   230: ifeq -> 276
		//   233: aload_1
		//   234: aload #4
		//   236: ldc ''
		//   238: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   241: pop
		//   242: goto -> 557
		//   245: astore #7
		//   247: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   250: new java/lang/StringBuilder
		//   253: dup
		//   254: invokespecial <init> : ()V
		//   257: ldc 'I COULD NOT SET A STRING FOR: '
		//   259: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   262: aload #4
		//   264: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   267: invokevirtual toString : ()Ljava/lang/String;
		//   270: invokevirtual println : (Ljava/lang/String;)V
		//   273: goto -> 557
		//   276: aload #5
		//   278: ldc java/math/BigDecimal
		//   280: invokevirtual equals : (Ljava/lang/Object;)Z
		//   283: ifeq -> 330
		//   286: aload_1
		//   287: aload #4
		//   289: getstatic nomitech/common/util/BigDecimalMath.ZERO : Ljava/math/BigDecimal;
		//   292: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   295: pop
		//   296: goto -> 557
		//   299: astore #7
		//   301: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   304: new java/lang/StringBuilder
		//   307: dup
		//   308: invokespecial <init> : ()V
		//   311: ldc 'I COULD NOT SET A DECIMAL FOR: '
		//   313: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   316: aload #4
		//   318: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   321: invokevirtual toString : ()Ljava/lang/String;
		//   324: invokevirtual println : (Ljava/lang/String;)V
		//   327: goto -> 557
		//   330: aload #5
		//   332: ldc java/lang/Long
		//   334: invokevirtual equals : (Ljava/lang/Object;)Z
		//   337: ifeq -> 389
		//   340: aload_1
		//   341: aload #4
		//   343: new java/lang/Long
		//   346: dup
		//   347: lconst_0
		//   348: invokespecial <init> : (J)V
		//   351: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   354: pop
		//   355: goto -> 557
		//   358: astore #7
		//   360: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   363: new java/lang/StringBuilder
		//   366: dup
		//   367: invokespecial <init> : ()V
		//   370: ldc 'I COULD NOT SET A LONG FOR: '
		//   372: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   375: aload #4
		//   377: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   380: invokevirtual toString : ()Ljava/lang/String;
		//   383: invokevirtual println : (Ljava/lang/String;)V
		//   386: goto -> 557
		//   389: aload #5
		//   391: ldc java/lang/Integer
		//   393: invokevirtual equals : (Ljava/lang/Object;)Z
		//   396: ifeq -> 448
		//   399: aload_1
		//   400: aload #4
		//   402: new java/lang/Integer
		//   405: dup
		//   406: iconst_0
		//   407: invokespecial <init> : (I)V
		//   410: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   413: pop
		//   414: goto -> 557
		//   417: astore #7
		//   419: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   422: new java/lang/StringBuilder
		//   425: dup
		//   426: invokespecial <init> : ()V
		//   429: ldc 'I COULD NOT SET AN INTEGER FOR: '
		//   431: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   434: aload #4
		//   436: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   439: invokevirtual toString : ()Ljava/lang/String;
		//   442: invokevirtual println : (Ljava/lang/String;)V
		//   445: goto -> 557
		//   448: aload #5
		//   450: ldc java/lang/Boolean
		//   452: invokevirtual equals : (Ljava/lang/Object;)Z
		//   455: ifeq -> 502
		//   458: aload_1
		//   459: aload #4
		//   461: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   464: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   467: pop
		//   468: goto -> 557
		//   471: astore #7
		//   473: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   476: new java/lang/StringBuilder
		//   479: dup
		//   480: invokespecial <init> : ()V
		//   483: ldc 'I COULD NOT SET A BOOLEAN FOR: '
		//   485: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   488: aload #4
		//   490: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   493: invokevirtual toString : ()Ljava/lang/String;
		//   496: invokevirtual println : (Ljava/lang/String;)V
		//   499: goto -> 557
		//   502: aload #5
		//   504: ldc java/util/Date
		//   506: invokevirtual equals : (Ljava/lang/Object;)Z
		//   509: ifeq -> 557
		//   512: aload_1
		//   513: aload #4
		//   515: new java/util/Date
		//   518: dup
		//   519: invokespecial <init> : ()V
		//   522: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   525: pop
		//   526: goto -> 557
		//   529: astore #7
		//   531: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   534: new java/lang/StringBuilder
		//   537: dup
		//   538: invokespecial <init> : ()V
		//   541: ldc 'I COULD NOT SET A DATE FOR: '
		//   543: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   546: aload #4
		//   548: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   551: invokevirtual toString : ()Ljava/lang/String;
		//   554: invokevirtual println : (Ljava/lang/String;)V
		//   557: iinc #3, 1
		//   560: goto -> 27
		//   563: aload_1
		//   564: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   567: invokevirtual setVirtual : (Ljava/lang/Boolean;)V
		//   570: aload_1
		//   571: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   574: invokevirtual setPredicted : (Ljava/lang/Boolean;)V
		//   577: aload_1
		//   578: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   581: invokevirtual setQuoted : (Ljava/lang/Boolean;)V
		//   584: aload_1
		//   585: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   588: invokevirtual setConceptual : (Ljava/lang/Boolean;)V
		//   591: aload_1
		//   592: iconst_0
		//   593: invokestatic valueOf : (I)Ljava/lang/Integer;
		//   596: invokevirtual setOverrideType : (Ljava/lang/Integer;)V
		//   599: aload_0
		//   600: ifnull -> 610
		//   603: aload_0
		//   604: instanceof nomitech/common/db/local/MaterialTable
		//   607: ifne -> 615
		//   610: aload_1
		//   611: aconst_null
		//   612: invokevirtual setMaterialId : (Ljava/lang/Long;)V
		//   615: aload_1
		//   616: areturn
		// Exception table:
		//   from	to	target	type
		//   62	88	94	java/lang/Exception
		//   233	242	245	java/lang/Exception
		//   286	296	299	java/lang/Exception
		//   340	355	358	java/lang/Exception
		//   399	414	417	java/lang/Exception
		//   458	468	471	java/lang/Exception
		//   512	526	529	java/lang/Exception }

	  public static SubcontractorTable createBlankSubcontractor(BaseEntity paramBaseEntity)
	  { // Byte code:
		//   0: new nomitech/common/db/local/SubcontractorTable
		//   3: dup
		//   4: invokespecial <init> : ()V
		//   7: astore_1
		//   8: aload_0
		//   9: ifnull -> 23
		//   12: aload_0
		//   13: instanceof nomitech/common/db/local/AssemblyTable
		//   16: ifeq -> 23
		//   19: iconst_1
		//   20: goto -> 24
		//   23: iconst_0
		//   24: istore_2
		//   25: iconst_0
		//   26: istore_3
		//   27: iload_3
		//   28: getstatic nomitech/common/db/local/SubcontractorTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   31: arraylength
		//   32: if_icmpge -> 458
		//   35: getstatic nomitech/common/db/local/SubcontractorTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   38: iload_3
		//   39: aaload
		//   40: astore #4
		//   42: getstatic nomitech/common/db/local/SubcontractorTable.CLASSES : [Ljava/lang/Class;
		//   45: iload_3
		//   46: aaload
		//   47: astore #5
		//   49: aload_0
		//   50: aload #4
		//   52: invokestatic getFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;)Ljava/lang/Object;
		//   55: astore #6
		//   57: aload #6
		//   59: ifnull -> 99
		//   62: aload_1
		//   63: aload #4
		//   65: aload #6
		//   67: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   70: pop
		//   71: iload_2
		//   72: ifeq -> 88
		//   75: aload #4
		//   77: ldc 'accuracy'
		//   79: invokevirtual equals : (Ljava/lang/Object;)Z
		//   82: ifeq -> 88
		//   85: goto -> 91
		//   88: goto -> 452
		//   91: goto -> 99
		//   94: astore #7
		//   96: aconst_null
		//   97: astore #6
		//   99: aload #4
		//   101: ldc 'accuracy'
		//   103: invokevirtual equals : (Ljava/lang/Object;)Z
		//   106: ifeq -> 118
		//   109: aload_1
		//   110: ldc 'enum.quotation.accuracy.estimated'
		//   112: invokevirtual setAccuracy : (Ljava/lang/String;)V
		//   115: goto -> 452
		//   118: aload #5
		//   120: ldc java/lang/String
		//   122: invokevirtual equals : (Ljava/lang/Object;)Z
		//   125: ifeq -> 171
		//   128: aload_1
		//   129: aload #4
		//   131: ldc ''
		//   133: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   136: pop
		//   137: goto -> 452
		//   140: astore #7
		//   142: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   145: new java/lang/StringBuilder
		//   148: dup
		//   149: invokespecial <init> : ()V
		//   152: ldc 'I COULD NOT SET A STRING FOR: '
		//   154: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   157: aload #4
		//   159: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   162: invokevirtual toString : ()Ljava/lang/String;
		//   165: invokevirtual println : (Ljava/lang/String;)V
		//   168: goto -> 452
		//   171: aload #5
		//   173: ldc java/math/BigDecimal
		//   175: invokevirtual equals : (Ljava/lang/Object;)Z
		//   178: ifeq -> 225
		//   181: aload_1
		//   182: aload #4
		//   184: getstatic nomitech/common/util/BigDecimalMath.ZERO : Ljava/math/BigDecimal;
		//   187: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   190: pop
		//   191: goto -> 452
		//   194: astore #7
		//   196: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   199: new java/lang/StringBuilder
		//   202: dup
		//   203: invokespecial <init> : ()V
		//   206: ldc 'I COULD NOT SET A DECIMAL FOR: '
		//   208: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   211: aload #4
		//   213: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   216: invokevirtual toString : ()Ljava/lang/String;
		//   219: invokevirtual println : (Ljava/lang/String;)V
		//   222: goto -> 452
		//   225: aload #5
		//   227: ldc java/lang/Long
		//   229: invokevirtual equals : (Ljava/lang/Object;)Z
		//   232: ifeq -> 284
		//   235: aload_1
		//   236: aload #4
		//   238: new java/lang/Long
		//   241: dup
		//   242: lconst_0
		//   243: invokespecial <init> : (J)V
		//   246: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   249: pop
		//   250: goto -> 452
		//   253: astore #7
		//   255: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   258: new java/lang/StringBuilder
		//   261: dup
		//   262: invokespecial <init> : ()V
		//   265: ldc 'I COULD NOT SET A LONG FOR: '
		//   267: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   270: aload #4
		//   272: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   275: invokevirtual toString : ()Ljava/lang/String;
		//   278: invokevirtual println : (Ljava/lang/String;)V
		//   281: goto -> 452
		//   284: aload #5
		//   286: ldc java/lang/Integer
		//   288: invokevirtual equals : (Ljava/lang/Object;)Z
		//   291: ifeq -> 343
		//   294: aload_1
		//   295: aload #4
		//   297: new java/lang/Integer
		//   300: dup
		//   301: iconst_0
		//   302: invokespecial <init> : (I)V
		//   305: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   308: pop
		//   309: goto -> 452
		//   312: astore #7
		//   314: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   317: new java/lang/StringBuilder
		//   320: dup
		//   321: invokespecial <init> : ()V
		//   324: ldc 'I COULD NOT SET AN INTEGER FOR: '
		//   326: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   329: aload #4
		//   331: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   334: invokevirtual toString : ()Ljava/lang/String;
		//   337: invokevirtual println : (Ljava/lang/String;)V
		//   340: goto -> 452
		//   343: aload #5
		//   345: ldc java/lang/Boolean
		//   347: invokevirtual equals : (Ljava/lang/Object;)Z
		//   350: ifeq -> 397
		//   353: aload_1
		//   354: aload #4
		//   356: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   359: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   362: pop
		//   363: goto -> 452
		//   366: astore #7
		//   368: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   371: new java/lang/StringBuilder
		//   374: dup
		//   375: invokespecial <init> : ()V
		//   378: ldc 'I COULD NOT SET A BOOLEAN FOR: '
		//   380: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   383: aload #4
		//   385: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   388: invokevirtual toString : ()Ljava/lang/String;
		//   391: invokevirtual println : (Ljava/lang/String;)V
		//   394: goto -> 452
		//   397: aload #5
		//   399: ldc java/util/Date
		//   401: invokevirtual equals : (Ljava/lang/Object;)Z
		//   404: ifeq -> 452
		//   407: aload_1
		//   408: aload #4
		//   410: new java/util/Date
		//   413: dup
		//   414: invokespecial <init> : ()V
		//   417: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   420: pop
		//   421: goto -> 452
		//   424: astore #7
		//   426: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   429: new java/lang/StringBuilder
		//   432: dup
		//   433: invokespecial <init> : ()V
		//   436: ldc 'I COULD NOT SET A DATE FOR: '
		//   438: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   441: aload #4
		//   443: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   446: invokevirtual toString : ()Ljava/lang/String;
		//   449: invokevirtual println : (Ljava/lang/String;)V
		//   452: iinc #3, 1
		//   455: goto -> 27
		//   458: aload_1
		//   459: invokevirtual getPerformance : ()Ljava/lang/String;
		//   462: invokestatic isNullOrBlank : (Ljava/lang/String;)Z
		//   465: ifeq -> 475
		//   468: aload_1
		//   469: ldc_w '8'
		//   472: invokevirtual setPerformance : (Ljava/lang/String;)V
		//   475: aload_1
		//   476: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   479: invokevirtual setVirtual : (Ljava/lang/Boolean;)V
		//   482: aload_1
		//   483: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   486: invokevirtual setPredicted : (Ljava/lang/Boolean;)V
		//   489: aload_1
		//   490: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   493: invokevirtual setQuoted : (Ljava/lang/Boolean;)V
		//   496: aload_1
		//   497: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   500: invokevirtual setConceptual : (Ljava/lang/Boolean;)V
		//   503: aload_1
		//   504: iconst_0
		//   505: invokestatic valueOf : (I)Ljava/lang/Integer;
		//   508: invokevirtual setOverrideType : (Ljava/lang/Integer;)V
		//   511: aload_0
		//   512: ifnull -> 522
		//   515: aload_0
		//   516: instanceof nomitech/common/db/local/SubcontractorTable
		//   519: ifne -> 527
		//   522: aload_1
		//   523: aconst_null
		//   524: invokevirtual setSubcontractorId : (Ljava/lang/Long;)V
		//   527: aload_1
		//   528: areturn
		// Exception table:
		//   from	to	target	type
		//   62	88	94	java/lang/Exception
		//   128	137	140	java/lang/Exception
		//   181	191	194	java/lang/Exception
		//   235	250	253	java/lang/Exception
		//   294	309	312	java/lang/Exception
		//   353	363	366	java/lang/Exception
		//   407	421	424	java/lang/Exception }

	  public static LaborTable createBlankLabor(BaseEntity paramBaseEntity)
	  { // Byte code:
		//   0: new nomitech/common/db/local/LaborTable
		//   3: dup
		//   4: invokespecial <init> : ()V
		//   7: astore_1
		//   8: iconst_0
		//   9: istore_2
		//   10: iload_2
		//   11: getstatic nomitech/common/db/local/LaborTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   14: arraylength
		//   15: if_icmpge -> 387
		//   18: getstatic nomitech/common/db/local/LaborTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   21: iload_2
		//   22: aaload
		//   23: astore_3
		//   24: getstatic nomitech/common/db/local/LaborTable.CLASSES : [Ljava/lang/Class;
		//   27: iload_2
		//   28: aaload
		//   29: astore #4
		//   31: aload_0
		//   32: aload_3
		//   33: invokestatic getFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;)Ljava/lang/Object;
		//   36: astore #5
		//   38: aload #5
		//   40: ifnull -> 59
		//   43: aload_1
		//   44: aload_3
		//   45: aload #5
		//   47: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   50: pop
		//   51: goto -> 381
		//   54: astore #6
		//   56: aconst_null
		//   57: astore #5
		//   59: aload #4
		//   61: ldc java/lang/String
		//   63: invokevirtual equals : (Ljava/lang/Object;)Z
		//   66: ifeq -> 110
		//   69: aload_1
		//   70: aload_3
		//   71: ldc ''
		//   73: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   76: pop
		//   77: goto -> 381
		//   80: astore #6
		//   82: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   85: new java/lang/StringBuilder
		//   88: dup
		//   89: invokespecial <init> : ()V
		//   92: ldc 'I COULD NOT SET A STRING FOR: '
		//   94: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   97: aload_3
		//   98: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   101: invokevirtual toString : ()Ljava/lang/String;
		//   104: invokevirtual println : (Ljava/lang/String;)V
		//   107: goto -> 381
		//   110: aload #4
		//   112: ldc java/math/BigDecimal
		//   114: invokevirtual equals : (Ljava/lang/Object;)Z
		//   117: ifeq -> 162
		//   120: aload_1
		//   121: aload_3
		//   122: getstatic nomitech/common/util/BigDecimalMath.ZERO : Ljava/math/BigDecimal;
		//   125: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   128: pop
		//   129: goto -> 381
		//   132: astore #6
		//   134: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   137: new java/lang/StringBuilder
		//   140: dup
		//   141: invokespecial <init> : ()V
		//   144: ldc 'I COULD NOT SET A DECIMAL FOR: '
		//   146: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   149: aload_3
		//   150: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   153: invokevirtual toString : ()Ljava/lang/String;
		//   156: invokevirtual println : (Ljava/lang/String;)V
		//   159: goto -> 381
		//   162: aload #4
		//   164: ldc java/lang/Long
		//   166: invokevirtual equals : (Ljava/lang/Object;)Z
		//   169: ifeq -> 219
		//   172: aload_1
		//   173: aload_3
		//   174: new java/lang/Long
		//   177: dup
		//   178: lconst_0
		//   179: invokespecial <init> : (J)V
		//   182: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   185: pop
		//   186: goto -> 381
		//   189: astore #6
		//   191: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   194: new java/lang/StringBuilder
		//   197: dup
		//   198: invokespecial <init> : ()V
		//   201: ldc 'I COULD NOT SET A LONG FOR: '
		//   203: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   206: aload_3
		//   207: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   210: invokevirtual toString : ()Ljava/lang/String;
		//   213: invokevirtual println : (Ljava/lang/String;)V
		//   216: goto -> 381
		//   219: aload #4
		//   221: ldc java/lang/Integer
		//   223: invokevirtual equals : (Ljava/lang/Object;)Z
		//   226: ifeq -> 276
		//   229: aload_1
		//   230: aload_3
		//   231: new java/lang/Integer
		//   234: dup
		//   235: iconst_0
		//   236: invokespecial <init> : (I)V
		//   239: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   242: pop
		//   243: goto -> 381
		//   246: astore #6
		//   248: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   251: new java/lang/StringBuilder
		//   254: dup
		//   255: invokespecial <init> : ()V
		//   258: ldc 'I COULD NOT SET AN INTEGER FOR: '
		//   260: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   263: aload_3
		//   264: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   267: invokevirtual toString : ()Ljava/lang/String;
		//   270: invokevirtual println : (Ljava/lang/String;)V
		//   273: goto -> 381
		//   276: aload #4
		//   278: ldc java/lang/Boolean
		//   280: invokevirtual equals : (Ljava/lang/Object;)Z
		//   283: ifeq -> 328
		//   286: aload_1
		//   287: aload_3
		//   288: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   291: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   294: pop
		//   295: goto -> 381
		//   298: astore #6
		//   300: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   303: new java/lang/StringBuilder
		//   306: dup
		//   307: invokespecial <init> : ()V
		//   310: ldc 'I COULD NOT SET A BOOLEAN FOR: '
		//   312: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   315: aload_3
		//   316: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   319: invokevirtual toString : ()Ljava/lang/String;
		//   322: invokevirtual println : (Ljava/lang/String;)V
		//   325: goto -> 381
		//   328: aload #4
		//   330: ldc java/util/Date
		//   332: invokevirtual equals : (Ljava/lang/Object;)Z
		//   335: ifeq -> 381
		//   338: aload_1
		//   339: aload_3
		//   340: new java/util/Date
		//   343: dup
		//   344: invokespecial <init> : ()V
		//   347: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   350: pop
		//   351: goto -> 381
		//   354: astore #6
		//   356: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   359: new java/lang/StringBuilder
		//   362: dup
		//   363: invokespecial <init> : ()V
		//   366: ldc 'I COULD NOT SET A BOOLEAN FOR: '
		//   368: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   371: aload_3
		//   372: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   375: invokevirtual toString : ()Ljava/lang/String;
		//   378: invokevirtual println : (Ljava/lang/String;)V
		//   381: iinc #2, 1
		//   384: goto -> 10
		//   387: aload_1
		//   388: ldc_w 'HOUR'
		//   391: invokevirtual setUnit : (Ljava/lang/String;)V
		//   394: aload_1
		//   395: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   398: invokevirtual setVirtual : (Ljava/lang/Boolean;)V
		//   401: aload_1
		//   402: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   405: invokevirtual setPredicted : (Ljava/lang/Boolean;)V
		//   408: aload_1
		//   409: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   412: invokevirtual setQuoted : (Ljava/lang/Boolean;)V
		//   415: aload_1
		//   416: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   419: invokevirtual setConceptual : (Ljava/lang/Boolean;)V
		//   422: aload_1
		//   423: iconst_0
		//   424: invokestatic valueOf : (I)Ljava/lang/Integer;
		//   427: invokevirtual setOverrideType : (Ljava/lang/Integer;)V
		//   430: aload_0
		//   431: ifnull -> 441
		//   434: aload_0
		//   435: instanceof nomitech/common/db/local/LaborTable
		//   438: ifne -> 446
		//   441: aload_1
		//   442: aconst_null
		//   443: invokevirtual setLaborId : (Ljava/lang/Long;)V
		//   446: aload_1
		//   447: areturn
		// Exception table:
		//   from	to	target	type
		//   43	51	54	java/lang/Exception
		//   69	77	80	java/lang/Exception
		//   120	129	132	java/lang/Exception
		//   172	186	189	java/lang/Exception
		//   229	243	246	java/lang/Exception
		//   286	295	298	java/lang/Exception
		//   338	351	354	java/lang/Exception }

	  public static EquipmentTable createBlankEquipment(BaseEntity paramBaseEntity)
	  { // Byte code:
		//   0: new nomitech/common/db/local/EquipmentTable
		//   3: dup
		//   4: invokespecial <init> : ()V
		//   7: astore_1
		//   8: iconst_0
		//   9: istore_2
		//   10: iload_2
		//   11: getstatic nomitech/common/db/local/EquipmentTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   14: arraylength
		//   15: if_icmpge -> 387
		//   18: getstatic nomitech/common/db/local/EquipmentTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   21: iload_2
		//   22: aaload
		//   23: astore_3
		//   24: getstatic nomitech/common/db/local/EquipmentTable.CLASSES : [Ljava/lang/Class;
		//   27: iload_2
		//   28: aaload
		//   29: astore #4
		//   31: aload_0
		//   32: aload_3
		//   33: invokestatic getFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;)Ljava/lang/Object;
		//   36: astore #5
		//   38: aload #5
		//   40: ifnull -> 59
		//   43: aload_1
		//   44: aload_3
		//   45: aload #5
		//   47: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   50: pop
		//   51: goto -> 381
		//   54: astore #6
		//   56: aconst_null
		//   57: astore #5
		//   59: aload #4
		//   61: ldc java/lang/String
		//   63: invokevirtual equals : (Ljava/lang/Object;)Z
		//   66: ifeq -> 110
		//   69: aload_1
		//   70: aload_3
		//   71: ldc ''
		//   73: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   76: pop
		//   77: goto -> 381
		//   80: astore #6
		//   82: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   85: new java/lang/StringBuilder
		//   88: dup
		//   89: invokespecial <init> : ()V
		//   92: ldc 'I COULD NOT SET A STRING FOR: '
		//   94: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   97: aload_3
		//   98: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   101: invokevirtual toString : ()Ljava/lang/String;
		//   104: invokevirtual println : (Ljava/lang/String;)V
		//   107: goto -> 381
		//   110: aload #4
		//   112: ldc java/math/BigDecimal
		//   114: invokevirtual equals : (Ljava/lang/Object;)Z
		//   117: ifeq -> 162
		//   120: aload_1
		//   121: aload_3
		//   122: getstatic nomitech/common/util/BigDecimalMath.ZERO : Ljava/math/BigDecimal;
		//   125: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   128: pop
		//   129: goto -> 381
		//   132: astore #6
		//   134: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   137: new java/lang/StringBuilder
		//   140: dup
		//   141: invokespecial <init> : ()V
		//   144: ldc 'I COULD NOT SET A DECIMAL FOR: '
		//   146: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   149: aload_3
		//   150: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   153: invokevirtual toString : ()Ljava/lang/String;
		//   156: invokevirtual println : (Ljava/lang/String;)V
		//   159: goto -> 381
		//   162: aload #4
		//   164: ldc java/lang/Long
		//   166: invokevirtual equals : (Ljava/lang/Object;)Z
		//   169: ifeq -> 219
		//   172: aload_1
		//   173: aload_3
		//   174: new java/lang/Long
		//   177: dup
		//   178: lconst_0
		//   179: invokespecial <init> : (J)V
		//   182: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   185: pop
		//   186: goto -> 381
		//   189: astore #6
		//   191: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   194: new java/lang/StringBuilder
		//   197: dup
		//   198: invokespecial <init> : ()V
		//   201: ldc 'I COULD NOT SET A LONG FOR: '
		//   203: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   206: aload_3
		//   207: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   210: invokevirtual toString : ()Ljava/lang/String;
		//   213: invokevirtual println : (Ljava/lang/String;)V
		//   216: goto -> 381
		//   219: aload #4
		//   221: ldc java/lang/Integer
		//   223: invokevirtual equals : (Ljava/lang/Object;)Z
		//   226: ifeq -> 276
		//   229: aload_1
		//   230: aload_3
		//   231: new java/lang/Integer
		//   234: dup
		//   235: iconst_0
		//   236: invokespecial <init> : (I)V
		//   239: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   242: pop
		//   243: goto -> 381
		//   246: astore #6
		//   248: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   251: new java/lang/StringBuilder
		//   254: dup
		//   255: invokespecial <init> : ()V
		//   258: ldc 'I COULD NOT SET AN INTEGER FOR: '
		//   260: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   263: aload_3
		//   264: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   267: invokevirtual toString : ()Ljava/lang/String;
		//   270: invokevirtual println : (Ljava/lang/String;)V
		//   273: goto -> 381
		//   276: aload #4
		//   278: ldc java/lang/Boolean
		//   280: invokevirtual equals : (Ljava/lang/Object;)Z
		//   283: ifeq -> 328
		//   286: aload_1
		//   287: aload_3
		//   288: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   291: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   294: pop
		//   295: goto -> 381
		//   298: astore #6
		//   300: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   303: new java/lang/StringBuilder
		//   306: dup
		//   307: invokespecial <init> : ()V
		//   310: ldc 'I COULD NOT SET A BOOLEAN FOR: '
		//   312: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   315: aload_3
		//   316: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   319: invokevirtual toString : ()Ljava/lang/String;
		//   322: invokevirtual println : (Ljava/lang/String;)V
		//   325: goto -> 381
		//   328: aload #4
		//   330: ldc java/util/Date
		//   332: invokevirtual equals : (Ljava/lang/Object;)Z
		//   335: ifeq -> 381
		//   338: aload_1
		//   339: aload_3
		//   340: new java/util/Date
		//   343: dup
		//   344: invokespecial <init> : ()V
		//   347: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   350: pop
		//   351: goto -> 381
		//   354: astore #6
		//   356: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   359: new java/lang/StringBuilder
		//   362: dup
		//   363: invokespecial <init> : ()V
		//   366: ldc 'I COULD NOT SET A DATE FOR: '
		//   368: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   371: aload_3
		//   372: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   375: invokevirtual toString : ()Ljava/lang/String;
		//   378: invokevirtual println : (Ljava/lang/String;)V
		//   381: iinc #2, 1
		//   384: goto -> 10
		//   387: aload_1
		//   388: getstatic nomitech/common/db/local/EquipmentTable.USER_DEFINED_METHOD : Ljava/lang/Integer;
		//   391: invokevirtual setDepreciationCalculationMethod : (Ljava/lang/Integer;)V
		//   394: aload_1
		//   395: new java/math/BigInteger
		//   398: dup
		//   399: ldc_w '6'
		//   402: invokespecial <init> : (Ljava/lang/String;)V
		//   405: invokevirtual setDepreciationYears : (Ljava/math/BigInteger;)V
		//   408: aload_1
		//   409: new nomitech/common/db/types/BigDecimalFixed
		//   412: dup
		//   413: ldc_w '0.73'
		//   416: invokespecial <init> : (Ljava/lang/String;)V
		//   419: invokevirtual setOccupationalFactor : (Ljava/math/BigDecimal;)V
		//   422: aload_1
		//   423: new nomitech/common/db/types/BigDecimalFixed
		//   426: dup
		//   427: ldc_w '175.0'
		//   430: invokespecial <init> : (Ljava/lang/String;)V
		//   433: invokevirtual setOccupationHoursPerMonth : (Ljava/math/BigDecimal;)V
		//   436: aload_1
		//   437: new nomitech/common/db/types/BigDecimalFixed
		//   440: dup
		//   441: ldc_w '0.0'
		//   444: invokespecial <init> : (Ljava/lang/String;)V
		//   447: invokevirtual setInitAquasitionPrice : (Ljava/math/BigDecimal;)V
		//   450: aload_1
		//   451: new nomitech/common/db/types/BigDecimalFixed
		//   454: dup
		//   455: ldc_w '0.065'
		//   458: invokespecial <init> : (Ljava/lang/String;)V
		//   461: invokevirtual setInterestRate : (Ljava/math/BigDecimal;)V
		//   464: aload_1
		//   465: ldc_w 'HOUR'
		//   468: invokevirtual setUnit : (Ljava/lang/String;)V
		//   471: aload_1
		//   472: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   475: invokevirtual setVirtual : (Ljava/lang/Boolean;)V
		//   478: aload_1
		//   479: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   482: invokevirtual setPredicted : (Ljava/lang/Boolean;)V
		//   485: aload_1
		//   486: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   489: invokevirtual setQuoted : (Ljava/lang/Boolean;)V
		//   492: aload_1
		//   493: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   496: invokevirtual setConceptual : (Ljava/lang/Boolean;)V
		//   499: aload_1
		//   500: iconst_0
		//   501: invokestatic valueOf : (I)Ljava/lang/Integer;
		//   504: invokevirtual setOverrideType : (Ljava/lang/Integer;)V
		//   507: aload_0
		//   508: ifnull -> 518
		//   511: aload_0
		//   512: instanceof nomitech/common/db/local/EquipmentTable
		//   515: ifne -> 523
		//   518: aload_1
		//   519: aconst_null
		//   520: invokevirtual setEquipmentId : (Ljava/lang/Long;)V
		//   523: aload_1
		//   524: areturn
		// Exception table:
		//   from	to	target	type
		//   43	51	54	java/lang/Exception
		//   69	77	80	java/lang/Exception
		//   120	129	132	java/lang/Exception
		//   172	186	189	java/lang/Exception
		//   229	243	246	java/lang/Exception
		//   286	295	298	java/lang/Exception
		//   338	351	354	java/lang/Exception }

	  public static ConsumableTable createBlankConsumable(BaseEntity paramBaseEntity)
	  { // Byte code:
		//   0: new nomitech/common/db/local/ConsumableTable
		//   3: dup
		//   4: invokespecial <init> : ()V
		//   7: astore_1
		//   8: iconst_0
		//   9: istore_2
		//   10: iload_2
		//   11: getstatic nomitech/common/db/local/ConsumableTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   14: arraylength
		//   15: if_icmpge -> 387
		//   18: getstatic nomitech/common/db/local/ConsumableTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   21: iload_2
		//   22: aaload
		//   23: astore_3
		//   24: getstatic nomitech/common/db/local/ConsumableTable.CLASSES : [Ljava/lang/Class;
		//   27: iload_2
		//   28: aaload
		//   29: astore #4
		//   31: aload_0
		//   32: aload_3
		//   33: invokestatic getFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;)Ljava/lang/Object;
		//   36: astore #5
		//   38: aload #5
		//   40: ifnull -> 59
		//   43: aload_1
		//   44: aload_3
		//   45: aload #5
		//   47: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   50: pop
		//   51: goto -> 381
		//   54: astore #6
		//   56: aconst_null
		//   57: astore #5
		//   59: aload #4
		//   61: ldc java/lang/String
		//   63: invokevirtual equals : (Ljava/lang/Object;)Z
		//   66: ifeq -> 110
		//   69: aload_1
		//   70: aload_3
		//   71: ldc ''
		//   73: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   76: pop
		//   77: goto -> 381
		//   80: astore #6
		//   82: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   85: new java/lang/StringBuilder
		//   88: dup
		//   89: invokespecial <init> : ()V
		//   92: ldc 'I COULD NOT SET A STRING FOR: '
		//   94: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   97: aload_3
		//   98: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   101: invokevirtual toString : ()Ljava/lang/String;
		//   104: invokevirtual println : (Ljava/lang/String;)V
		//   107: goto -> 381
		//   110: aload #4
		//   112: ldc java/math/BigDecimal
		//   114: invokevirtual equals : (Ljava/lang/Object;)Z
		//   117: ifeq -> 162
		//   120: aload_1
		//   121: aload_3
		//   122: getstatic nomitech/common/util/BigDecimalMath.ZERO : Ljava/math/BigDecimal;
		//   125: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   128: pop
		//   129: goto -> 381
		//   132: astore #6
		//   134: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   137: new java/lang/StringBuilder
		//   140: dup
		//   141: invokespecial <init> : ()V
		//   144: ldc 'I COULD NOT SET A DECIMAL FOR: '
		//   146: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   149: aload_3
		//   150: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   153: invokevirtual toString : ()Ljava/lang/String;
		//   156: invokevirtual println : (Ljava/lang/String;)V
		//   159: goto -> 381
		//   162: aload #4
		//   164: ldc java/lang/Long
		//   166: invokevirtual equals : (Ljava/lang/Object;)Z
		//   169: ifeq -> 219
		//   172: aload_1
		//   173: aload_3
		//   174: new java/lang/Long
		//   177: dup
		//   178: lconst_0
		//   179: invokespecial <init> : (J)V
		//   182: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   185: pop
		//   186: goto -> 381
		//   189: astore #6
		//   191: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   194: new java/lang/StringBuilder
		//   197: dup
		//   198: invokespecial <init> : ()V
		//   201: ldc 'I COULD NOT SET A LONG FOR: '
		//   203: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   206: aload_3
		//   207: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   210: invokevirtual toString : ()Ljava/lang/String;
		//   213: invokevirtual println : (Ljava/lang/String;)V
		//   216: goto -> 381
		//   219: aload #4
		//   221: ldc java/lang/Integer
		//   223: invokevirtual equals : (Ljava/lang/Object;)Z
		//   226: ifeq -> 276
		//   229: aload_1
		//   230: aload_3
		//   231: new java/lang/Integer
		//   234: dup
		//   235: iconst_0
		//   236: invokespecial <init> : (I)V
		//   239: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   242: pop
		//   243: goto -> 381
		//   246: astore #6
		//   248: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   251: new java/lang/StringBuilder
		//   254: dup
		//   255: invokespecial <init> : ()V
		//   258: ldc 'I COULD NOT SET AN INTEGER FOR: '
		//   260: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   263: aload_3
		//   264: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   267: invokevirtual toString : ()Ljava/lang/String;
		//   270: invokevirtual println : (Ljava/lang/String;)V
		//   273: goto -> 381
		//   276: aload #4
		//   278: ldc java/lang/Boolean
		//   280: invokevirtual equals : (Ljava/lang/Object;)Z
		//   283: ifeq -> 328
		//   286: aload_1
		//   287: aload_3
		//   288: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   291: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   294: pop
		//   295: goto -> 381
		//   298: astore #6
		//   300: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   303: new java/lang/StringBuilder
		//   306: dup
		//   307: invokespecial <init> : ()V
		//   310: ldc 'I COULD NOT SET A BOOLEAN FOR: '
		//   312: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   315: aload_3
		//   316: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   319: invokevirtual toString : ()Ljava/lang/String;
		//   322: invokevirtual println : (Ljava/lang/String;)V
		//   325: goto -> 381
		//   328: aload #4
		//   330: ldc java/util/Date
		//   332: invokevirtual equals : (Ljava/lang/Object;)Z
		//   335: ifeq -> 381
		//   338: aload_1
		//   339: aload_3
		//   340: new java/util/Date
		//   343: dup
		//   344: invokespecial <init> : ()V
		//   347: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   350: pop
		//   351: goto -> 381
		//   354: astore #6
		//   356: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   359: new java/lang/StringBuilder
		//   362: dup
		//   363: invokespecial <init> : ()V
		//   366: ldc 'I COULD NOT SET A DATE FOR: '
		//   368: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   371: aload_3
		//   372: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   375: invokevirtual toString : ()Ljava/lang/String;
		//   378: invokevirtual println : (Ljava/lang/String;)V
		//   381: iinc #2, 1
		//   384: goto -> 10
		//   387: aload_1
		//   388: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   391: invokevirtual setVirtual : (Ljava/lang/Boolean;)V
		//   394: aload_1
		//   395: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   398: invokevirtual setPredicted : (Ljava/lang/Boolean;)V
		//   401: aload_1
		//   402: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   405: invokevirtual setQuoted : (Ljava/lang/Boolean;)V
		//   408: aload_1
		//   409: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   412: invokevirtual setConceptual : (Ljava/lang/Boolean;)V
		//   415: aload_1
		//   416: iconst_0
		//   417: invokestatic valueOf : (I)Ljava/lang/Integer;
		//   420: invokevirtual setOverrideType : (Ljava/lang/Integer;)V
		//   423: aload_0
		//   424: ifnull -> 434
		//   427: aload_0
		//   428: instanceof nomitech/common/db/local/ConsumableTable
		//   431: ifne -> 439
		//   434: aload_1
		//   435: aconst_null
		//   436: invokevirtual setConsumableId : (Ljava/lang/Long;)V
		//   439: aload_1
		//   440: areturn
		// Exception table:
		//   from	to	target	type
		//   43	51	54	java/lang/Exception
		//   69	77	80	java/lang/Exception
		//   120	129	132	java/lang/Exception
		//   172	186	189	java/lang/Exception
		//   229	243	246	java/lang/Exception
		//   286	295	298	java/lang/Exception
		//   338	351	354	java/lang/Exception }

	  public static ParamItemTable createBlankParamItem(BaseEntity paramBaseEntity)
	  { // Byte code:
		//   0: new nomitech/common/db/local/ParamItemTable
		//   3: dup
		//   4: invokespecial <init> : ()V
		//   7: astore_1
		//   8: iconst_0
		//   9: istore_2
		//   10: iload_2
		//   11: getstatic nomitech/common/db/local/ParamItemTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   14: arraylength
		//   15: if_icmpge -> 387
		//   18: getstatic nomitech/common/db/local/ParamItemTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   21: iload_2
		//   22: aaload
		//   23: astore_3
		//   24: getstatic nomitech/common/db/local/ParamItemTable.CLASSES : [Ljava/lang/Class;
		//   27: iload_2
		//   28: aaload
		//   29: astore #4
		//   31: aload_0
		//   32: aload_3
		//   33: invokestatic getFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;)Ljava/lang/Object;
		//   36: astore #5
		//   38: aload #5
		//   40: ifnull -> 59
		//   43: aload_1
		//   44: aload_3
		//   45: aload #5
		//   47: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   50: pop
		//   51: goto -> 381
		//   54: astore #6
		//   56: aconst_null
		//   57: astore #5
		//   59: aload #4
		//   61: ldc java/lang/String
		//   63: invokevirtual equals : (Ljava/lang/Object;)Z
		//   66: ifeq -> 110
		//   69: aload_1
		//   70: aload_3
		//   71: ldc ''
		//   73: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   76: pop
		//   77: goto -> 381
		//   80: astore #6
		//   82: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   85: new java/lang/StringBuilder
		//   88: dup
		//   89: invokespecial <init> : ()V
		//   92: ldc 'I COULD NOT SET A STRING FOR: '
		//   94: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   97: aload_3
		//   98: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   101: invokevirtual toString : ()Ljava/lang/String;
		//   104: invokevirtual println : (Ljava/lang/String;)V
		//   107: goto -> 381
		//   110: aload #4
		//   112: ldc java/math/BigDecimal
		//   114: invokevirtual equals : (Ljava/lang/Object;)Z
		//   117: ifeq -> 162
		//   120: aload_1
		//   121: aload_3
		//   122: getstatic nomitech/common/util/BigDecimalMath.ZERO : Ljava/math/BigDecimal;
		//   125: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   128: pop
		//   129: goto -> 381
		//   132: astore #6
		//   134: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   137: new java/lang/StringBuilder
		//   140: dup
		//   141: invokespecial <init> : ()V
		//   144: ldc 'I COULD NOT SET A DECIMAL FOR: '
		//   146: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   149: aload_3
		//   150: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   153: invokevirtual toString : ()Ljava/lang/String;
		//   156: invokevirtual println : (Ljava/lang/String;)V
		//   159: goto -> 381
		//   162: aload #4
		//   164: ldc java/lang/Long
		//   166: invokevirtual equals : (Ljava/lang/Object;)Z
		//   169: ifeq -> 219
		//   172: aload_1
		//   173: aload_3
		//   174: new java/lang/Long
		//   177: dup
		//   178: lconst_0
		//   179: invokespecial <init> : (J)V
		//   182: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   185: pop
		//   186: goto -> 381
		//   189: astore #6
		//   191: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   194: new java/lang/StringBuilder
		//   197: dup
		//   198: invokespecial <init> : ()V
		//   201: ldc 'I COULD NOT SET A LONG FOR: '
		//   203: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   206: aload_3
		//   207: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   210: invokevirtual toString : ()Ljava/lang/String;
		//   213: invokevirtual println : (Ljava/lang/String;)V
		//   216: goto -> 381
		//   219: aload #4
		//   221: ldc java/lang/Integer
		//   223: invokevirtual equals : (Ljava/lang/Object;)Z
		//   226: ifeq -> 276
		//   229: aload_1
		//   230: aload_3
		//   231: new java/lang/Integer
		//   234: dup
		//   235: iconst_0
		//   236: invokespecial <init> : (I)V
		//   239: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   242: pop
		//   243: goto -> 381
		//   246: astore #6
		//   248: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   251: new java/lang/StringBuilder
		//   254: dup
		//   255: invokespecial <init> : ()V
		//   258: ldc 'I COULD NOT SET AN INTEGER FOR: '
		//   260: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   263: aload_3
		//   264: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   267: invokevirtual toString : ()Ljava/lang/String;
		//   270: invokevirtual println : (Ljava/lang/String;)V
		//   273: goto -> 381
		//   276: aload #4
		//   278: ldc java/lang/Boolean
		//   280: invokevirtual equals : (Ljava/lang/Object;)Z
		//   283: ifeq -> 328
		//   286: aload_1
		//   287: aload_3
		//   288: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   291: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   294: pop
		//   295: goto -> 381
		//   298: astore #6
		//   300: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   303: new java/lang/StringBuilder
		//   306: dup
		//   307: invokespecial <init> : ()V
		//   310: ldc 'I COULD NOT SET A BOOLEAN FOR: '
		//   312: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   315: aload_3
		//   316: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   319: invokevirtual toString : ()Ljava/lang/String;
		//   322: invokevirtual println : (Ljava/lang/String;)V
		//   325: goto -> 381
		//   328: aload #4
		//   330: ldc java/util/Date
		//   332: invokevirtual equals : (Ljava/lang/Object;)Z
		//   335: ifeq -> 381
		//   338: aload_1
		//   339: aload_3
		//   340: new java/util/Date
		//   343: dup
		//   344: invokespecial <init> : ()V
		//   347: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   350: pop
		//   351: goto -> 381
		//   354: astore #6
		//   356: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   359: new java/lang/StringBuilder
		//   362: dup
		//   363: invokespecial <init> : ()V
		//   366: ldc 'I COULD NOT SET A DATE FOR: '
		//   368: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   371: aload_3
		//   372: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   375: invokevirtual toString : ()Ljava/lang/String;
		//   378: invokevirtual println : (Ljava/lang/String;)V
		//   381: iinc #2, 1
		//   384: goto -> 10
		//   387: aload_1
		//   388: getstatic java/lang/Boolean.TRUE : Ljava/lang/Boolean;
		//   391: invokevirtual setMultUnitQty : (Ljava/lang/Boolean;)V
		//   394: aload_1
		//   395: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   398: invokevirtual setVirtual : (Ljava/lang/Boolean;)V
		//   401: aload_1
		//   402: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   405: invokevirtual setPredicted : (Ljava/lang/Boolean;)V
		//   408: aload_1
		//   409: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   412: invokevirtual setQuoted : (Ljava/lang/Boolean;)V
		//   415: aload_1
		//   416: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   419: invokevirtual setConceptual : (Ljava/lang/Boolean;)V
		//   422: aload_1
		//   423: iconst_0
		//   424: invokestatic valueOf : (I)Ljava/lang/Integer;
		//   427: invokevirtual setOverrideType : (Ljava/lang/Integer;)V
		//   430: aload_1
		//   431: ldc ''
		//   433: invokevirtual setPassword : (Ljava/lang/String;)V
		//   436: aload_1
		//   437: ldc ''
		//   439: invokevirtual setSerialNumber : (Ljava/lang/String;)V
		//   442: aload_1
		//   443: ldc_w 'NONE'
		//   446: invokevirtual setProtectionType : (Ljava/lang/String;)V
		//   449: aload_0
		//   450: ifnull -> 460
		//   453: aload_0
		//   454: instanceof nomitech/common/db/local/ParamItemTable
		//   457: ifne -> 465
		//   460: aload_1
		//   461: aconst_null
		//   462: invokevirtual setParamitemId : (Ljava/lang/Long;)V
		//   465: aload_1
		//   466: areturn
		// Exception table:
		//   from	to	target	type
		//   43	51	54	java/lang/Exception
		//   69	77	80	java/lang/Exception
		//   120	129	132	java/lang/Exception
		//   172	186	189	java/lang/Exception
		//   229	243	246	java/lang/Exception
		//   286	295	298	java/lang/Exception
		//   338	351	354	java/lang/Exception }

	  public static ParamItemQueryResourceTable constructQueryResource(ParamItemQueryResourceTable paramParamItemQueryResourceTable) throws Exception
	  {
		ParamItemQueryResourceTable paramItemQueryResourceTable = new ParamItemQueryResourceTable();
		if (paramParamItemQueryResourceTable != null)
		{
		  paramItemQueryResourceTable.Data = paramParamItemQueryResourceTable;
		}
		for (sbyte b = 0; b < ParamItemQueryResourceTable.ITEM_FIELDS.Length; b++)
		{
		  string str1 = ParamItemQueryResourceTable.ITEM_VARIABLES[b];
		  string str2 = ParamItemQueryResourceTable.ITEM_FIELDS[b] + "Equation";
		  setFieldValue(paramItemQueryResourceTable, str2, str1);
		}
		return paramItemQueryResourceTable;
	  }

	  public static SupplierTable createBlankSupplier(BaseEntity paramBaseEntity)
	  { // Byte code:
		//   0: new nomitech/common/db/local/SupplierTable
		//   3: dup
		//   4: invokespecial <init> : ()V
		//   7: astore_1
		//   8: iconst_0
		//   9: istore_2
		//   10: iload_2
		//   11: getstatic nomitech/common/db/local/SupplierTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   14: arraylength
		//   15: if_icmpge -> 387
		//   18: getstatic nomitech/common/db/local/SupplierTable.VIEWABLE_FIELDS : [Ljava/lang/String;
		//   21: iload_2
		//   22: aaload
		//   23: astore_3
		//   24: getstatic nomitech/common/db/local/SupplierTable.CLASSES : [Ljava/lang/Class;
		//   27: iload_2
		//   28: aaload
		//   29: astore #4
		//   31: aload_0
		//   32: aload_3
		//   33: invokestatic getFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;)Ljava/lang/Object;
		//   36: astore #5
		//   38: aload #5
		//   40: ifnull -> 59
		//   43: aload_1
		//   44: aload_3
		//   45: aload #5
		//   47: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   50: pop
		//   51: goto -> 381
		//   54: astore #6
		//   56: aconst_null
		//   57: astore #5
		//   59: aload #4
		//   61: ldc java/lang/String
		//   63: invokevirtual equals : (Ljava/lang/Object;)Z
		//   66: ifeq -> 110
		//   69: aload_1
		//   70: aload_3
		//   71: ldc ''
		//   73: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   76: pop
		//   77: goto -> 381
		//   80: astore #6
		//   82: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   85: new java/lang/StringBuilder
		//   88: dup
		//   89: invokespecial <init> : ()V
		//   92: ldc 'I COULD NOT SET A STRING FOR: '
		//   94: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   97: aload_3
		//   98: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   101: invokevirtual toString : ()Ljava/lang/String;
		//   104: invokevirtual println : (Ljava/lang/String;)V
		//   107: goto -> 381
		//   110: aload #4
		//   112: ldc java/math/BigDecimal
		//   114: invokevirtual equals : (Ljava/lang/Object;)Z
		//   117: ifeq -> 162
		//   120: aload_1
		//   121: aload_3
		//   122: getstatic nomitech/common/util/BigDecimalMath.ZERO : Ljava/math/BigDecimal;
		//   125: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   128: pop
		//   129: goto -> 381
		//   132: astore #6
		//   134: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   137: new java/lang/StringBuilder
		//   140: dup
		//   141: invokespecial <init> : ()V
		//   144: ldc 'I COULD NOT SET A DECIMAL FOR: '
		//   146: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   149: aload_3
		//   150: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   153: invokevirtual toString : ()Ljava/lang/String;
		//   156: invokevirtual println : (Ljava/lang/String;)V
		//   159: goto -> 381
		//   162: aload #4
		//   164: ldc java/lang/Long
		//   166: invokevirtual equals : (Ljava/lang/Object;)Z
		//   169: ifeq -> 219
		//   172: aload_1
		//   173: aload_3
		//   174: new java/lang/Long
		//   177: dup
		//   178: lconst_0
		//   179: invokespecial <init> : (J)V
		//   182: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   185: pop
		//   186: goto -> 381
		//   189: astore #6
		//   191: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   194: new java/lang/StringBuilder
		//   197: dup
		//   198: invokespecial <init> : ()V
		//   201: ldc 'I COULD NOT SET A LONG FOR: '
		//   203: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   206: aload_3
		//   207: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   210: invokevirtual toString : ()Ljava/lang/String;
		//   213: invokevirtual println : (Ljava/lang/String;)V
		//   216: goto -> 381
		//   219: aload #4
		//   221: ldc java/lang/Integer
		//   223: invokevirtual equals : (Ljava/lang/Object;)Z
		//   226: ifeq -> 276
		//   229: aload_1
		//   230: aload_3
		//   231: new java/lang/Integer
		//   234: dup
		//   235: iconst_0
		//   236: invokespecial <init> : (I)V
		//   239: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   242: pop
		//   243: goto -> 381
		//   246: astore #6
		//   248: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   251: new java/lang/StringBuilder
		//   254: dup
		//   255: invokespecial <init> : ()V
		//   258: ldc 'I COULD NOT SET AN INTEGER FOR: '
		//   260: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   263: aload_3
		//   264: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   267: invokevirtual toString : ()Ljava/lang/String;
		//   270: invokevirtual println : (Ljava/lang/String;)V
		//   273: goto -> 381
		//   276: aload #4
		//   278: ldc java/lang/Boolean
		//   280: invokevirtual equals : (Ljava/lang/Object;)Z
		//   283: ifeq -> 328
		//   286: aload_1
		//   287: aload_3
		//   288: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   291: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   294: pop
		//   295: goto -> 381
		//   298: astore #6
		//   300: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   303: new java/lang/StringBuilder
		//   306: dup
		//   307: invokespecial <init> : ()V
		//   310: ldc 'I COULD NOT SET A BOOLEAN FOR: '
		//   312: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   315: aload_3
		//   316: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   319: invokevirtual toString : ()Ljava/lang/String;
		//   322: invokevirtual println : (Ljava/lang/String;)V
		//   325: goto -> 381
		//   328: aload #4
		//   330: ldc java/util/Date
		//   332: invokevirtual equals : (Ljava/lang/Object;)Z
		//   335: ifeq -> 381
		//   338: aload_1
		//   339: aload_3
		//   340: new java/util/Date
		//   343: dup
		//   344: invokespecial <init> : ()V
		//   347: invokestatic setFieldValue : (Lnomitech/common/base/BaseEntity;Ljava/lang/String;Ljava/lang/Object;)Z
		//   350: pop
		//   351: goto -> 381
		//   354: astore #6
		//   356: getstatic java/lang/System.out : Ljava/io/PrintStream;
		//   359: new java/lang/StringBuilder
		//   362: dup
		//   363: invokespecial <init> : ()V
		//   366: ldc 'I COULD NOT SET A DATE FOR: '
		//   368: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   371: aload_3
		//   372: invokevirtual append : (Ljava/lang/String;)Ljava/lang/StringBuilder;
		//   375: invokevirtual toString : ()Ljava/lang/String;
		//   378: invokevirtual println : (Ljava/lang/String;)V
		//   381: iinc #2, 1
		//   384: goto -> 10
		//   387: aload_1
		//   388: invokevirtual getPerformance : ()Ljava/lang/String;
		//   391: invokestatic isNullOrBlank : (Ljava/lang/String;)Z
		//   394: ifeq -> 404
		//   397: aload_1
		//   398: ldc_w '8'
		//   401: invokevirtual setPerformance : (Ljava/lang/String;)V
		//   404: aload_1
		//   405: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   408: invokevirtual setVirtual : (Ljava/lang/Boolean;)V
		//   411: aload_1
		//   412: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   415: invokevirtual setPredicted : (Ljava/lang/Boolean;)V
		//   418: aload_1
		//   419: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   422: invokevirtual setQuoted : (Ljava/lang/Boolean;)V
		//   425: aload_1
		//   426: getstatic java/lang/Boolean.FALSE : Ljava/lang/Boolean;
		//   429: invokevirtual setConceptual : (Ljava/lang/Boolean;)V
		//   432: aload_1
		//   433: iconst_0
		//   434: invokestatic valueOf : (I)Ljava/lang/Integer;
		//   437: invokevirtual setOverrideType : (Ljava/lang/Integer;)V
		//   440: aload_0
		//   441: ifnonnull -> 449
		//   444: aload_1
		//   445: aconst_null
		//   446: invokevirtual setSupplierId : (Ljava/lang/Long;)V
		//   449: aload_1
		//   450: areturn
		// Exception table:
		//   from	to	target	type
		//   43	51	54	java/lang/Exception
		//   69	77	80	java/lang/Exception
		//   120	129	132	java/lang/Exception
		//   172	186	189	java/lang/Exception
		//   229	243	246	java/lang/Exception
		//   286	295	298	java/lang/Exception
		//   338	351	354	java/lang/Exception }

	  public static GroupCode createBlankGroupCode(int paramInt, string paramString1, string paramString2, string paramString3, string paramString4, string paramString5, string paramString6, DateTime paramDate)
	  {
		ExtraCode7Table extraCode7Table = null;
		if (paramInt == 1)
		{
		  extraCode7Table = new GroupCodeTable();
		}
		else if (paramInt == 2)
		{
		  GekCodeTable gekCodeTable = new GekCodeTable();
		}
		else if (paramInt == 3)
		{
		  ExtraCode1Table extraCode1Table = new ExtraCode1Table();
		}
		else if (paramInt == 4)
		{
		  ExtraCode2Table extraCode2Table = new ExtraCode2Table();
		}
		else if (paramInt == 5)
		{
		  ExtraCode3Table extraCode3Table = new ExtraCode3Table();
		}
		else if (paramInt == 6)
		{
		  ExtraCode4Table extraCode4Table = new ExtraCode4Table();
		}
		else if (paramInt == 7)
		{
		  ExtraCode5Table extraCode5Table = new ExtraCode5Table();
		}
		else if (paramInt == 8)
		{
		  ExtraCode6Table extraCode6Table = new ExtraCode6Table();
		}
		else if (paramInt == 9)
		{
		  extraCode7Table = new ExtraCode7Table();
		}
		else
		{
		  throw new System.ArgumentException("Can not create a group code with code: " + paramInt);
		}
		extraCode7Table.GroupCode = paramString1;
		extraCode7Table.Title = paramString2;
		extraCode7Table.Notes = paramString3;
		extraCode7Table.EditorId = paramString6;
		extraCode7Table.LastUpdate = paramDate;
		extraCode7Table.CreateDate = paramDate;
		extraCode7Table.CreateUserId = paramString6;
		extraCode7Table.UnitFactor = BigDecimalMath.ONE;
		extraCode7Table.Unit = paramString5;
		extraCode7Table.Description = paramString4;
		return extraCode7Table;
	  }

	  public static System.Collections.IList fillNullCustomsInLineItems(IList<AssemblyTable> paramList)
	  {
		if (paramList == null || paramList.size() == 0 || ((AssemblyTable)paramList.get(false)).CustomRate15 != null)
		{
		  return paramList;
		}
		foreach (AssemblyTable assemblyTable in paramList)
		{
		  assemblyTable.CustomRate11 = BigDecimalMath.ZERO;
		  assemblyTable.CustomRate12 = BigDecimalMath.ZERO;
		  assemblyTable.CustomRate13 = BigDecimalMath.ZERO;
		  assemblyTable.CustomRate14 = BigDecimalMath.ZERO;
		  assemblyTable.CustomRate15 = BigDecimalMath.ZERO;
		}
		return paramList;
	  }

	  public static AssemblyPartialResult fillNullCustomsInLineItems(AssemblyPartialResult paramAssemblyPartialResult)
	  {
		if (paramAssemblyPartialResult.PartialResult != null)
		{
		  fillNullCustomsInLineItems(paramAssemblyPartialResult.PartialResult);
		}
		if (paramAssemblyPartialResult.Result != null)
		{
		  fillNullCustomsInLineItems(paramAssemblyPartialResult.Result);
		}
		return paramAssemblyPartialResult;
	  }

	  public static System.Collections.IList fillNullsInParamItems(IList<ParamItemTable> paramList)
	  {
		if (paramList == null || paramList.size() == 0 || ((ParamItemTable)paramList.get(false)).MultUnitQty != null)
		{
		  return paramList;
		}
		foreach (ParamItemTable paramItemTable in paramList)
		{
		  paramItemTable.MultUnitQty = true;
		}
		return paramList;
	  }

	  public static ParamItemPartialResult fillNullsInParamItems(ParamItemPartialResult paramParamItemPartialResult)
	  {
		if (paramParamItemPartialResult.PartialResult != null)
		{
		  fillNullsInParamItems(paramParamItemPartialResult.PartialResult);
		}
		if (paramParamItemPartialResult.Result != null)
		{
		  fillNullsInParamItems(paramParamItemPartialResult.Result);
		}
		return paramParamItemPartialResult;
	  }

	  public static ResourceTable createBlankResource(ResourceTable paramResourceTable, string paramString)
	  {
		  return paramString.Equals("assembly") ? createBlankAssembly(paramResourceTable) : (paramString.Equals("material") ? createBlankMaterial(paramResourceTable) : (paramString.Equals("labor") ? createBlankLabor(paramResourceTable) : (paramString.Equals("equipment") ? createBlankEquipment(paramResourceTable) : (paramString.Equals("subcontractor") ? createBlankSubcontractor(paramResourceTable) : (paramString.Equals("consumable") ? createBlankConsumable(paramResourceTable) : (paramString.Equals("supplier") ? createBlankSupplier(paramResourceTable) : (paramString.Equals("paramitem") ? createBlankParamItem(paramResourceTable) : (paramString.Equals("boqitem") ? createBlankBoqItem(paramResourceTable, null, null, true) : null))))))));
	  }

	  public static ProjectInfoTable createBlankProjectInfo(ProjectEPSTable paramProjectEPSTable, string paramString1, string paramString2, string paramString3, string paramString4, string paramString5, string paramString6)
	  {
		DateTime date = DateTime.Now;
		ProjectInfoTable projectInfoTable = new ProjectInfoTable();
		projectInfoTable.LastUpdate = date;
		projectInfoTable.EpsCode = paramProjectEPSTable.Code + " - " + paramProjectEPSTable.Title;
		projectInfoTable.Description = "";
		projectInfoTable.Currency = paramString1;
		projectInfoTable.PrimaveraConnected = Convert.ToBoolean(false);
		projectInfoTable.LocationFactors = Convert.ToBoolean(false);
		projectInfoTable.LocationProfile = "";
		projectInfoTable.SelectedFactor = "";
		projectInfoTable.HasBimTakeoff = Convert.ToBoolean(false);
		projectInfoTable.HasOnScreenTakeoff = Convert.ToBoolean(false);
		projectInfoTable.StorageType = "Server";
		projectInfoTable.CodeStyle = "dotted";
		projectInfoTable.Code = paramString4;
		projectInfoTable.Title = paramString5;
		projectInfoTable.Unit = paramString3;
		projectInfoTable.EditorId = paramString6;
		projectInfoTable.TotalCost = decimal.Zero;
		projectInfoTable.OfferedPrice = decimal.Zero;
		projectInfoTable.Status = "enum.boqstatus.underreview";
		projectInfoTable.Location = "";
		projectInfoTable.Currency = paramString1;
		projectInfoTable.Country = paramString2;
		projectInfoTable.Client = "";
		projectInfoTable.BasementSize = decimal.Zero;
		projectInfoTable.SuperstructureSize = decimal.Zero;
		projectInfoTable.UnitCost = decimal.Zero;
		projectInfoTable.StateProvince = "";
		projectInfoTable.ProjectType = "dialog.newproject.projecttype.construction";
		projectInfoTable.SubCategory = "dialog.newproject.projectsubtype.construction.residency";
		projectInfoTable.Contractor = "";
		projectInfoTable.GeoLocation = "0.0,0.0";
		projectInfoTable.Floors = Convert.ToInt32(0);
		projectInfoTable.PaymentDuration = Convert.ToInt32(0);
		projectInfoTable.ClientBudget = decimal.Zero;
		projectInfoTable.SubmissionDate = date;
		projectInfoTable.ProjectEPSTable = paramProjectEPSTable;
		projectInfoTable.CreateUserId = paramString6;
		projectInfoTable.CreateDate = date;
		projectInfoTable.CustomCumRate1 = decimal.Zero;
		projectInfoTable.CustomCumRate2 = decimal.Zero;
		projectInfoTable.CustomCumRate3 = decimal.Zero;
		projectInfoTable.CustomCumRate4 = decimal.Zero;
		projectInfoTable.CustomCumRate5 = decimal.Zero;
		projectInfoTable.CustomCumRate6 = decimal.Zero;
		projectInfoTable.CustomCumRate7 = decimal.Zero;
		projectInfoTable.CustomCumRate8 = decimal.Zero;
		projectInfoTable.CustomCumRate9 = decimal.Zero;
		projectInfoTable.CustomCumRate10 = decimal.Zero;
		projectInfoTable.SubcontractorTotalCost = decimal.Zero;
		projectInfoTable.LaborTotalCost = decimal.Zero;
		projectInfoTable.MaterialTotalCost = decimal.Zero;
		projectInfoTable.ConsumableTotalCost = decimal.Zero;
		projectInfoTable.LaborManhours = decimal.Zero;
		projectInfoTable.EquipmentHours = decimal.Zero;
		projectInfoTable.CustomEpsRate1 = decimal.Zero;
		projectInfoTable.CustomEpsRate2 = decimal.Zero;
		projectInfoTable.CustomEpsRate3 = decimal.Zero;
		projectInfoTable.CustomEpsRate4 = decimal.Zero;
		projectInfoTable.CustomEpsRate5 = decimal.Zero;
		projectInfoTable.CustomEpsRate6 = decimal.Zero;
		projectInfoTable.CustomEpsRate7 = decimal.Zero;
		projectInfoTable.CustomEpsRate8 = decimal.Zero;
		projectInfoTable.CustomEpsRate9 = decimal.Zero;
		projectInfoTable.CustomEpsRate10 = decimal.Zero;
		projectInfoTable.CustomEpsText1 = "";
		projectInfoTable.CustomEpsText2 = "";
		projectInfoTable.CustomEpsText3 = "";
		projectInfoTable.CustomEpsText4 = "";
		projectInfoTable.CustomEpsText5 = "";
		projectInfoTable.CustomEpsText6 = "";
		projectInfoTable.CustomEpsText7 = "";
		projectInfoTable.CustomEpsText8 = "";
		projectInfoTable.CustomEpsText9 = "";
		projectInfoTable.CustomEpsText10 = "";
		projectInfoTable.CustomEpsText11 = "";
		projectInfoTable.CustomEpsText12 = "";
		projectInfoTable.CustomEpsText13 = "";
		projectInfoTable.CustomEpsText14 = "";
		projectInfoTable.CustomEpsText15 = "";
		projectInfoTable.CustomEpsText16 = "";
		projectInfoTable.CustomEpsText17 = "";
		projectInfoTable.CustomEpsText18 = "";
		projectInfoTable.CustomEpsText19 = "";
		projectInfoTable.CustomEpsText20 = "";
		return projectInfoTable;
	  }

	  public static ProjectUserTable createBlankProjectUser(UserAndRolesData paramUserAndRolesData, bool? paramBoolean)
	  {
		ProjectUserTable projectUserTable = new ProjectUserTable();
		projectUserTable.UserId = paramUserAndRolesData.PrincipalsData.PrincipalId;
		projectUserTable.Name = paramUserAndRolesData.PrincipalsData.Name;
		projectUserTable.Email = paramUserAndRolesData.PrincipalsData.EMail;
		projectUserTable.EditExchange = paramBoolean;
		projectUserTable.EditEscalate = paramBoolean;
		projectUserTable.EditProps = paramBoolean;
		projectUserTable.EditTakeoff = paramBoolean;
		projectUserTable.EditResource = paramBoolean;
		projectUserTable.Estimator = paramBoolean;
		projectUserTable.Administrator = paramBoolean;
		projectUserTable.SubmitQuotes = paramBoolean;
		projectUserTable.SendQuotes = paramBoolean;
		projectUserTable.AwardQuotes = paramBoolean;
		projectUserTable.Wbs = paramBoolean;
		projectUserTable.AddItems = paramBoolean;
		projectUserTable.RemoveItems = paramBoolean;
		projectUserTable.EditItems = paramBoolean;
		projectUserTable.ViewAllItems = paramBoolean;
		projectUserTable.VariablesAdmin = paramBoolean;
		projectUserTable.VariablesUser = paramBoolean;
		projectUserTable.VariablesViewer = paramBoolean;
		projectUserTable.AccessRules = new HashSet<object>();
		ProjectAccessRuleTable projectAccessRuleTable = new ProjectAccessRuleTable();
		projectAccessRuleTable.Title = "Access Rule";
		projectAccessRuleTable.AccessCondition = "TRUE()";
		projectAccessRuleTable.AllowAdd = paramBoolean;
		projectAccessRuleTable.AllowUpdate = paramBoolean;
		projectAccessRuleTable.AllowRemove = paramBoolean;
		projectUserTable.AccessRules.Add(projectAccessRuleTable);
		return projectUserTable;
	  }
	  }


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\boqitem\BlankResourceInitializer.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
	  }