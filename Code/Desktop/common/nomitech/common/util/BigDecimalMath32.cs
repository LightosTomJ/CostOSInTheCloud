using System.Numerics;

namespace Desktop.common.nomitech.common.util
{
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;

	public class BigDecimalMath32
	{
	  public static int ROUND_DOWN = 1;

	  public static readonly decimal ZERO = BigDecimalMath.ZERO;

	  public static readonly decimal ONE = BigDecimalMath.ONE;

	  public static readonly decimal TWO = BigDecimalMath.TWO;

	  public static readonly decimal THREE = BigDecimalMath.THREE;

	  public static readonly decimal FOUR = BigDecimalMath.FOUR;

	  public static readonly decimal NINE = BigDecimalMath.NINE;

	  public static readonly decimal TEN = BigDecimalMath.TEN;

	  public static readonly decimal NEG_ONE = BigDecimalMath.NEG_ONE;

	  private static readonly decimal HALF = BigDecimalMath.HALF;

	  public const int DEC_PLACES = 32;

	  public const int MAX_PLACES = 37;

	  private static readonly decimal POINT99 = BigDecimalMath.POINT99;

	  private const int CMP_BIAS = 5;

	  private const int CMP_PLACES = 27;

	  public const int CALC_PLACES = 28;

	  public static readonly decimal CALC_PRECISION = ONE.movePointLeft(28);

	  public static int APPROX_EQ_PLACES = 28;

	  public const int APPROX_3_DIGITS = 3;

	  public static decimal E = taylor(ONE, ONE, ZERO, 1, false);

	  public static decimal PI = ComputePi();

	  private static readonly decimal ONE_HUND = new BigDecimalFixed("100");

	  private static readonly decimal ONE_TENTH = new BigDecimalFixed("0.1");

	  private static decimal LN_10 = ln(TEN);

	  public static decimal TWO_PI = mult(TWO, PI);

	  public static decimal PI_HALF = div(PI, TWO);

	  public static decimal PI_QTR = div(PI, FOUR);

	  public static decimal PI_3QTR = mult(PI_QTR, THREE);

	  private static readonly decimal X180 = new BigDecimalFixed("180");

	  public static decimal DEG_TO_RAD = div(PI, X180);

	  public static decimal RAD_TO_DEG = div(X180, PI);

	  public static void SetPrecision(int paramInt)
	  {
		if (paramInt < 1)
		{
		  paramInt = 1;
		}
		APPROX_EQ_PLACES = paramInt;
	  }

	  public static decimal recip(decimal paramBigDecimal)
	  {
		  return div(ONE, paramBigDecimal);
	  }

	  public static decimal mult(decimal paramBigDecimal1, decimal paramBigDecimal2)
	  {
		decimal bigDecimal = paramBigDecimal1 * paramBigDecimal2;
		return bigDecimal.setScale(37, ROUND_DOWN);
	  }

	  public static decimal div(decimal paramBigDecimal1, decimal paramBigDecimal2)
	  {
		if (paramBigDecimal2.CompareTo(ZERO) == 0)
		{
		  throw new ArithmeticException("divide by zero error: " + paramBigDecimal2);
		}
		decimal bigDecimal = paramBigDecimal1.setScale(37, ROUND_DOWN);
		return bigDecimal.divide(paramBigDecimal2, ROUND_DOWN);
	  }

	  public static decimal[] mod(decimal paramBigDecimal1, decimal paramBigDecimal2)
	  {
		decimal[] arrayOfBigDecimal = new decimal[2];
		if (paramBigDecimal2.CompareTo(ZERO) == 0)
		{
		  return null;
		}
		paramBigDecimal2 = paramBigDecimal2.abs();
		decimal bigDecimal1 = div(paramBigDecimal1, paramBigDecimal2);
		arrayOfBigDecimal[0] = new BigDecimalFixed(bigDecimal1.toBigInteger());
		decimal bigDecimal2 = mult(paramBigDecimal2, arrayOfBigDecimal[0]);
		arrayOfBigDecimal[1] = paramBigDecimal1 - bigDecimal2;
		return arrayOfBigDecimal;
	  }

	  public static int cmpCheckNulls(decimal paramBigDecimal1, decimal paramBigDecimal2)
	  {
		  return (paramBigDecimal1 == null && paramBigDecimal2 == null) ? 0 : ((paramBigDecimal1 != null && paramBigDecimal2 == null) ? 1 : ((paramBigDecimal1 == null && paramBigDecimal2 != null) ? -1 : approx(paramBigDecimal1, paramBigDecimal2, 27)));
	  }

	  public static int cmp(decimal paramBigDecimal1, decimal paramBigDecimal2)
	  {
		  return approx(paramBigDecimal1, paramBigDecimal2, 27);
	  }

	  public static int approx(decimal paramBigDecimal1, decimal paramBigDecimal2)
	  {
		  return approx(paramBigDecimal1, paramBigDecimal2, APPROX_EQ_PLACES);
	  }

	  public static int approx(decimal paramBigDecimal1, decimal paramBigDecimal2, int paramInt)
	  {
		decimal bigDecimal1 = ONE.movePointLeft(paramInt);
		decimal bigDecimal2 = paramBigDecimal1 - paramBigDecimal2;
		return (bigDecimal2.abs().compareTo(bigDecimal1) > 0) ? ((bigDecimal2.signum() > 0) ? 1 : -1) : 0;
	  }

	  public static bool isInt(decimal paramBigDecimal)
	  {
		  return isInt(paramBigDecimal, APPROX_EQ_PLACES);
	  }

	  public static bool isIntCmp(decimal paramBigDecimal)
	  {
		  return isInt(paramBigDecimal, 27);
	  }

	  public static bool isInt(decimal paramBigDecimal, int paramInt)
	  {
		BigDecimalFixed bigDecimalFixed = new BigDecimalFixed(paramBigDecimal.toBigInteger());
		decimal bigDecimal = paramBigDecimal - bigDecimalFixed.abs();
		return (approx(bigDecimal, ZERO, paramInt) == 0 || approx(bigDecimal, ONE, paramInt) == 0);
	  }

	  public static decimal RoundIntD(decimal paramBigDecimal)
	  {
		BigInteger bigInteger = RoundIntI(paramBigDecimal);
		return new BigDecimalFixed(bigInteger);
	  }

	  public static BigInteger RoundIntI(decimal paramBigDecimal)
	  {
		decimal bigDecimal = paramBigDecimal;
		bool @bool = false;
		if (cmp(paramBigDecimal, ZERO) < 0)
		{
		  bigDecimal = -paramBigDecimal;
		  @bool = true;
		}
		bigDecimal = bigDecimal + HALF;
		BigInteger bigInteger = bigDecimal.toBigInteger();
		if (@bool)
		{
		  bigInteger = -bigInteger;
		}
		return bigInteger;
	  }

	  public static decimal round(decimal paramBigDecimal, int paramInt)
	  {
		decimal bigDecimal1 = paramBigDecimal.movePointRight(paramInt);
		decimal bigDecimal2 = RoundIntD(bigDecimal1);
		return bigDecimal2.movePointLeft(paramInt);
	  }

	  public static decimal truncInt(decimal paramBigDecimal, int paramInt)
	  {
		BigInteger bigInteger = paramBigDecimal.movePointRight(paramInt).toBigInteger();
		return (new BigDecimalFixed(bigInteger)).movePointLeft(paramInt);
	  }

	  public static decimal SmartRound(decimal paramBigDecimal)
	  {
		  return SmartRound(paramBigDecimal, APPROX_EQ_PLACES);
	  }

	  public static decimal SmartRound(decimal paramBigDecimal, int paramInt)
	  {
		bool @bool = (cmp(paramBigDecimal, ZERO) < 0) ? 1 : 0;
		decimal bigDecimal = paramBigDecimal.abs();
		sbyte b1 = 0;
		sbyte b2 = 0;
		while (b2 < 32 - paramInt)
		{
		  BigDecimalFixed bigDecimalFixed = new BigDecimalFixed(bigDecimal.toBigInteger());
		  decimal bigDecimal1 = bigDecimal - bigDecimalFixed;
		  bool bool1 = (approx(bigDecimal1, ONE, paramInt) == 0) ? 1 : 0;
		  if (approx(bigDecimal1, ZERO, paramInt) == 0 || bool1)
		  {
			if (bool1)
			{
			  null = bigDecimalFixed.add(ONE);
			}
			null = null.setScale(37, ROUND_DOWN).movePointLeft(b1);
			if (@bool)
			{
			  null = null.negate();
			}
			return null.setScale(b1, ROUND_DOWN);
		  }
		  b2++;
		  bigDecimal = bigDecimal.movePointRight(1);
		  b1++;
		}
		return paramBigDecimal;
	  }

	  public static void CalcConstants()
	  {
		E = taylor(ONE, ONE, ZERO, 1, false);
		PI = ComputePi();
		LN_10 = ln(TEN);
		TWO_PI = mult(TWO, PI);
		PI_HALF = div(PI, TWO);
		PI_QTR = div(PI, FOUR);
		PI_3QTR = mult(PI_QTR, THREE);
		DEG_TO_RAD = div(PI, X180);
		RAD_TO_DEG = div(X180, PI);
	  }

	  private static decimal ComputePi()
	  {
		BigDecimalFixed bigDecimalFixed1 = new BigDecimalFixed("0.2");
		decimal bigDecimal1 = mult(atan(bigDecimalFixed1), FOUR);
		BigDecimalFixed bigDecimalFixed2 = new BigDecimalFixed("239");
		decimal bigDecimal2 = atan(recip(bigDecimalFixed2));
		bigDecimal1 = bigDecimal1 - bigDecimal2;
		bigDecimal1 = mult(bigDecimal1, FOUR);
		return bigDecimal1.setScale(37, ROUND_DOWN);
	  }

	  private static decimal taylor(decimal paramBigDecimal1, decimal paramBigDecimal2, decimal paramBigDecimal3, int paramInt, bool paramBoolean)
	  {
		decimal bigDecimal1 = paramBigDecimal2.setScale(37, ROUND_DOWN);
		null = bigDecimal1;
		decimal bigDecimal2 = paramBigDecimal3;
		sbyte b = 1;
		do
		{
		  for (int i = paramInt; i > 0; i--)
		  {
			bigDecimal2 = bigDecimal2 + ONE;
			bigDecimal1 = mult(bigDecimal1, paramBigDecimal1);
			if (bigDecimal2.CompareTo(ONE) > 0)
			{
			  bigDecimal1 = bigDecimal1.divide(bigDecimal2, ROUND_DOWN);
			}
		  }
		  if (paramBoolean)
		  {
			b = -b;
		  }
		  if (b > 0)
		  {
			null = null.add(bigDecimal1);
		  }
		  else
		  {
			null = null.subtract(bigDecimal1);
		  }
		} while (cmp(bigDecimal1.abs(), ZERO) != 0);
		return null.setScale(32, ROUND_DOWN);
	  }

	  public static decimal deg2rad(decimal paramBigDecimal)
	  {
		  return mult(paramBigDecimal, DEG_TO_RAD);
	  }

	  public static decimal rad2deg(decimal paramBigDecimal)
	  {
		  return mult(paramBigDecimal, RAD_TO_DEG);
	  }

	  public static decimal ln(decimal paramBigDecimal)
	  {
		if (approx(paramBigDecimal, ZERO) <= 0)
		{
		  return null;
		}
		if (approx(paramBigDecimal, ONE) == 0)
		{
		  return ZERO;
		}
		sbyte b;
		for (b = 0; cmp(paramBigDecimal, ONE_HUND) > 0; b++)
		{
		  paramBigDecimal = paramBigDecimal.movePointLeft(1);
		}
		while (cmp(paramBigDecimal, ONE_TENTH) < 0)
		{
		  paramBigDecimal = paramBigDecimal.movePointRight(1);
		  b--;
		}
		decimal bigDecimal1 = paramBigDecimal - ONE.setScale(37, ROUND_DOWN);
		decimal bigDecimal2 = paramBigDecimal + ONE;
		decimal bigDecimal3 = bigDecimal1.divide(bigDecimal2, ROUND_DOWN);
		decimal bigDecimal4 = logSeries(bigDecimal3);
		bigDecimal4 = mult(bigDecimal4, TWO);
		if (b != 0)
		{
		  decimal bigDecimal = mult(LN_10, new BigDecimalFixed(b));
		  bigDecimal4 = bigDecimal4 + bigDecimal;
		}
		return bigDecimal4.setScale(32, ROUND_DOWN);
	  }

	  private static decimal logSeries(decimal paramBigDecimal)
	  {
		decimal bigDecimal1 = paramBigDecimal.setScale(37, ROUND_DOWN);
		decimal bigDecimal2 = bigDecimal1;
		decimal bigDecimal3 = mult(paramBigDecimal, paramBigDecimal);
		null = ZERO;
		decimal bigDecimal4 = ONE;
		do
		{
		  null = null.add(bigDecimal2);
		  bigDecimal1 = mult(bigDecimal1, bigDecimal3);
		  bigDecimal4 = bigDecimal4 + TWO;
		  bigDecimal2 = bigDecimal1.divide(bigDecimal4, ROUND_DOWN);
		} while (cmp(bigDecimal2.abs(), ZERO) != 0);
		return null.setScale(32, ROUND_DOWN);
	  }

	  public static decimal sqrt(decimal paramBigDecimal)
	  {
		  return root(2, paramBigDecimal);
	  }

	  public static decimal root(int paramInt, decimal paramBigDecimal)
	  {
		if (paramInt < 2)
		{
		  return null;
		}
		sbyte b = 1;
		if (cmp(paramBigDecimal, ZERO) < 0)
		{
		  if ((paramInt & true) == 0)
		  {
			return null;
		  }
		  paramBigDecimal = paramBigDecimal.abs();
		  b = -1;
		}
		else
		{
		  if (cmp(paramBigDecimal, ZERO) == 0)
		  {
			return ZERO;
		  }
		  if (cmp(paramBigDecimal, ONE) == 0)
		  {
			return ONE;
		  }
		}
		paramBigDecimal = paramBigDecimal.setScale(37, ROUND_DOWN);
		decimal bigDecimal = realRoot(paramInt, paramBigDecimal);
		if (b < 0)
		{
		  bigDecimal = -bigDecimal;
		}
		return bigDecimal.setScale(32, ROUND_DOWN);
	  }

	  private static decimal realRoot(int paramInt, decimal paramBigDecimal)
	  {
		decimal bigDecimal4;
		if (paramInt < 2)
		{
		  return null;
		}
		if (cmp(paramBigDecimal, ZERO) == 0)
		{
		  return ZERO;
		}
		if (cmp(paramBigDecimal, ONE) == 0)
		{
		  return ONE;
		}
		paramBigDecimal = paramBigDecimal.abs().setScale(37, ROUND_DOWN);
		BigDecimalFixed bigDecimalFixed = new BigDecimalFixed("" + paramInt);
		decimal bigDecimal1 = bigDecimalFixed.subtract(ONE);
		bigDecimal1 = bigDecimal1.setScale(37, ROUND_DOWN).divide(bigDecimalFixed, ROUND_DOWN);
		decimal bigDecimal2 = paramBigDecimal.divide(bigDecimalFixed, ROUND_DOWN);
		decimal bigDecimal3 = ONE;
		if (cmp(paramBigDecimal, ONE) > 0)
		{
		  int i = paramBigDecimal.toBigInteger().ToString().Length;
		  i = (i + paramInt - 1) / paramInt;
		  if (i > 0)
		  {
			bigDecimal3 = (new BigDecimalFixed("5")).movePointRight(i - 1);
		  }
		}
		sbyte b = 0;
		do
		{
		  decimal bigDecimal5 = bigDecimal3;
		  decimal bigDecimal6 = bigDecimal2;
		  for (sbyte b1 = 1; b1 < paramInt; b1++)
		  {
			bigDecimal6 = bigDecimal6.divide(bigDecimal3, ROUND_DOWN);
		  }
		  bigDecimal3 = mult(bigDecimal3, bigDecimal1) + bigDecimal6;
		  bigDecimal4 = bigDecimal5 - bigDecimal3;
		} while (bigDecimal4.abs().compareTo(CALC_PRECISION) > 0 && ++b < (sbyte)'✐');
		return bigDecimal3.setScale(32, ROUND_DOWN);
	  }

	  public static decimal sin(decimal paramBigDecimal)
	  {
		decimal[] arrayOfBigDecimal = mod(paramBigDecimal, TWO_PI);
		return taylor(arrayOfBigDecimal[1], arrayOfBigDecimal[1], ONE, 2, true);
	  }

	  public static decimal cos(decimal paramBigDecimal)
	  {
		decimal[] arrayOfBigDecimal = mod(paramBigDecimal, TWO_PI);
		return taylor(arrayOfBigDecimal[1], ONE, ZERO, 2, true);
	  }

	  public static decimal tan(decimal paramBigDecimal)
	  {
		decimal bigDecimal = cos(paramBigDecimal);
		return (approx(bigDecimal, ZERO) == 0) ? null : sin(paramBigDecimal).divide(bigDecimal, ROUND_DOWN);
	  }

	  public static decimal cot(decimal paramBigDecimal)
	  {
		decimal bigDecimal = sin(paramBigDecimal);
		return (approx(bigDecimal, ZERO) == 0) ? null : cos(paramBigDecimal).divide(bigDecimal, ROUND_DOWN);
	  }

	  public static decimal sec(decimal paramBigDecimal)
	  {
		decimal bigDecimal = cos(paramBigDecimal);
		return (approx(bigDecimal, ZERO) == 0) ? null : recip(bigDecimal);
	  }

	  public static decimal csc(decimal paramBigDecimal)
	  {
		decimal bigDecimal = sin(paramBigDecimal);
		return (approx(bigDecimal, ZERO) == 0) ? null : recip(bigDecimal);
	  }

	  public static decimal asin(decimal paramBigDecimal)
	  {
		if (cmp(paramBigDecimal.abs(), ONE) > 0)
		{
		  return null;
		}
		if (approx(paramBigDecimal, ONE) == 0)
		{
		  return PI_HALF;
		}
		if (approx(paramBigDecimal, NEG_ONE) == 0)
		{
		  return -PI_HALF;
		}
		if (cmp(paramBigDecimal.abs(), POINT99) > 0)
		{
		  decimal bigDecimal7 = mult(paramBigDecimal, paramBigDecimal);
		  decimal bigDecimal8 = ONE - bigDecimal7;
		  decimal bigDecimal9 = root(2, bigDecimal8);
		  decimal bigDecimal10 = div(paramBigDecimal, bigDecimal9);
		  return atan(bigDecimal10);
		}
		decimal bigDecimal1 = paramBigDecimal.setScale(37, ROUND_DOWN);
		decimal bigDecimal2 = bigDecimal1;
		decimal bigDecimal3 = mult(paramBigDecimal, paramBigDecimal);
		decimal bigDecimal4 = ZERO;
		decimal bigDecimal5 = ONE;
		decimal bigDecimal6 = ONE;
		do
		{
		  bigDecimal4 = bigDecimal4 + bigDecimal2;
		  bigDecimal1 = mult(bigDecimal1, bigDecimal3);
		  decimal bigDecimal = bigDecimal6 + ONE;
		  bigDecimal5 = mult(bigDecimal5, bigDecimal6).divide(bigDecimal, ROUND_DOWN);
		  bigDecimal6 = bigDecimal6 + TWO;
		  bigDecimal2 = mult(bigDecimal1, bigDecimal5).divide(bigDecimal6, ROUND_DOWN);
		} while (cmp(bigDecimal2.abs(), ZERO) != 0);
		return bigDecimal4.setScale(32, ROUND_DOWN);
	  }

	  public static decimal atan2(decimal paramBigDecimal1, decimal paramBigDecimal2)
	  {
		if (approx(paramBigDecimal1, ZERO) == 0)
		{
		  return (cmp(paramBigDecimal2, ZERO) >= 0) ? ZERO : PI;
		}
		if (approx(paramBigDecimal2, ZERO) == 0)
		{
		  return (cmp(paramBigDecimal1, ZERO) > 0) ? PI_HALF : -PI_HALF;
		}
		decimal bigDecimal1 = paramBigDecimal1.setScale(37, ROUND_DOWN).divide(paramBigDecimal2, ROUND_DOWN);
		decimal bigDecimal2 = atan(bigDecimal1.abs());
		return (cmp(paramBigDecimal2, ZERO) >= 0) ? ((cmp(paramBigDecimal1, ZERO) >= 0) ? bigDecimal2 : -bigDecimal2) : ((cmp(paramBigDecimal1, ZERO) >= 0) ? PI - bigDecimal2 : -PI.add(bigDecimal2));
	  }

	  public static decimal atan(decimal paramBigDecimal)
	  {
		decimal bigDecimal2;
		if (paramBigDecimal == null)
		{
		  return PI_HALF;
		}
		if (approx(paramBigDecimal, ONE) == 0)
		{
		  return PI_QTR;
		}
		if (approx(paramBigDecimal, NEG_ONE) == 0)
		{
		  return -PI_QTR;
		}
		decimal bigDecimal1 = paramBigDecimal.abs();
		if (cmp(bigDecimal1, ONE) < 0)
		{
		  bigDecimal2 = atanSeries(bigDecimal1);
		}
		else
		{
		  decimal bigDecimal = recip(bigDecimal1);
		  bigDecimal2 = atanSeries(bigDecimal);
		  bigDecimal2 = PI_HALF - bigDecimal2;
		}
		if (cmp(paramBigDecimal, ZERO) < 0)
		{
		  bigDecimal2 = -bigDecimal2;
		}
		return bigDecimal2;
	  }

	  private static decimal atanSeries(decimal paramBigDecimal)
	  {
		paramBigDecimal = paramBigDecimal.setScale(37, ROUND_DOWN);
		decimal bigDecimal1 = mult(paramBigDecimal, paramBigDecimal);
		decimal bigDecimal2 = bigDecimal1 + ONE;
		decimal bigDecimal3 = paramBigDecimal.divide(bigDecimal2, ROUND_DOWN);
		decimal bigDecimal4 = bigDecimal1.divide(bigDecimal2, ROUND_DOWN);
		null = ZERO;
		decimal bigDecimal5 = ZERO;
		bigDecimal2 = ONE;
		do
		{
		  null = null.add(bigDecimal3);
		  bigDecimal5 = bigDecimal5 + ONE;
		  decimal bigDecimal = mult(mult(bigDecimal5, bigDecimal5), FOUR);
		  bigDecimal3 = mult(bigDecimal3, bigDecimal);
		  bigDecimal3 = mult(bigDecimal3, bigDecimal4);
		  bigDecimal2 = bigDecimal2 + ONE;
		  bigDecimal3 = bigDecimal3.divide(bigDecimal2, ROUND_DOWN);
		  bigDecimal2 = bigDecimal2 + ONE;
		  bigDecimal3 = bigDecimal3.divide(bigDecimal2, ROUND_DOWN);
		} while (cmp(bigDecimal3.abs(), ZERO) != 0);
		return null.setScale(32, ROUND_DOWN);
	  }

	  public static decimal acot(decimal paramBigDecimal)
	  {
		decimal bigDecimal2;
		if (paramBigDecimal == null)
		{
		  return ZERO;
		}
		if (approx(paramBigDecimal, ONE) == 0)
		{
		  return PI_QTR;
		}
		if (approx(paramBigDecimal, NEG_ONE) == 0)
		{
		  return PI_3QTR;
		}
		decimal bigDecimal1 = paramBigDecimal.abs();
		if (cmp(bigDecimal1, ONE) < 0)
		{
		  bigDecimal2 = atanSeries(bigDecimal1);
		  bigDecimal2 = PI_HALF - bigDecimal2;
		}
		else
		{
		  decimal bigDecimal = recip(bigDecimal1);
		  bigDecimal2 = atanSeries(bigDecimal);
		}
		if (cmp(paramBigDecimal, ZERO) < 0)
		{
		  bigDecimal2 = PI - bigDecimal2;
		}
		return bigDecimal2;
	  }

	  public static decimal abs(decimal paramBigDecimal)
	  {
		  return (paramBigDecimal.CompareTo(decimal.Zero) < 0) ? paramBigDecimal * (new BigDecimalFixed("-1")) : paramBigDecimal;
	  }

	  public static decimal pow(decimal paramBigDecimal, int paramInt)
	  {
		decimal bigDecimal = BigDecimalMath.ZERO;
		for (sbyte b = 0; b < paramInt; b++)
		{
		  if (bigDecimal.Equals(BigDecimalMath.ZERO))
		  {
			bigDecimal = paramBigDecimal;
		  }
		  else
		  {
			bigDecimal = bigDecimal * paramBigDecimal;
		  }
		}
		return bigDecimal;
	  }

	  public static int comp(decimal paramBigDecimal1, decimal paramBigDecimal2, int paramInt)
	  {
		paramBigDecimal1 = paramBigDecimal1.setScale(paramInt, ROUND_DOWN);
		paramBigDecimal2 = paramBigDecimal2.setScale(paramInt, ROUND_DOWN);
		return paramBigDecimal1.CompareTo(paramBigDecimal2);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\BigDecimalMath32.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}