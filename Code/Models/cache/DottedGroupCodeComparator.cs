using System.Collections.Generic;

namespace Models.cache
{

	//using BaseCache = nomitech.common.@base.BaseCache;
	//using GroupCode = nomitech.common.@base.GroupCode;

	// AVOIDS THE SORTING 1.1 10.1 2.1 PROBLEM!!

	public class DottedGroupCodeComparator : IComparer<GroupCode>
	{

		private const int TOKEN_LENGTH = 7;
		private const string ZERO = "0";
		private static readonly string DOT = BaseCache.DOT;
		private const string regex = "\\.";

		public virtual int Compare(GroupCode o1, GroupCode o2)
		{

			string code1 = o1.GroupCode;
			string code2 = o2.GroupCode;

			code1 = addEqualZerosToEveryToken(code1);
			code2 = addEqualZerosToEveryToken(code2);

			return code1.CompareTo(code2);
		}

		private string addEqualZerosToEveryToken(string code)
		{

			string[] gcs = code.Split(regex,9);

			if (gcs.Length == 1)
			{
				return addZeros(gcs[0]);
			}
			else if (gcs.Length == 2)
			{
				return addZeros(gcs[0]) + DOT + addZeros(gcs[1]);
			}
			else if (gcs.Length == 3)
			{
				return addZeros(gcs[0]) + DOT + addZeros(gcs[1]) + DOT + addZeros(gcs[2]);
			}
			else if (gcs.Length == 4)
			{
				return addZeros(gcs[0]) + DOT + addZeros(gcs[1]) + DOT + addZeros(gcs[2]) + DOT + addZeros(gcs[3]);
			}
			else if (gcs.Length == 5)
			{
				return addZeros(gcs[0]) + DOT + addZeros(gcs[1]) + DOT + addZeros(gcs[2]) + DOT + addZeros(gcs[3]) + DOT + addZeros(gcs[4]);
			}
			else if (gcs.Length == 6)
			{
				return addZeros(gcs[0]) + DOT + addZeros(gcs[1]) + DOT + addZeros(gcs[2]) + DOT + addZeros(gcs[3]) + DOT + addZeros(gcs[4]) + DOT + addZeros(gcs[5]);
			}
			else if (gcs.Length == 7)
			{
				return addZeros(gcs[0]) + DOT + addZeros(gcs[1]) + DOT + addZeros(gcs[2]) + DOT + addZeros(gcs[3]) + DOT + addZeros(gcs[4]) + DOT + addZeros(gcs[5]) + DOT + addZeros(gcs[6]);
			}
			else if (gcs.Length == 8)
			{
				return addZeros(gcs[0]) + DOT + addZeros(gcs[1]) + DOT + addZeros(gcs[2]) + DOT + addZeros(gcs[3]) + DOT + addZeros(gcs[4]) + DOT + addZeros(gcs[5]) + DOT + addZeros(gcs[6]) + DOT + addZeros(gcs[7]);
			}
			else if (gcs.Length >= 9)
			{
				return addZeros(gcs[0]) + DOT + addZeros(gcs[1]) + DOT + addZeros(gcs[2]) + DOT + addZeros(gcs[3]) + DOT + addZeros(gcs[4]) + DOT + addZeros(gcs[5]) + DOT + addZeros(gcs[6]) + DOT + addZeros(gcs[7]) + DOT + addZeros(gcs[8]);
			}

			return code;
		}

		private string addZeros(string code)
		{

			int zerosToAdd = TOKEN_LENGTH - code.Length;

			if (zerosToAdd <= 0)
			{
				return code;
			}

			for (int i = 0; i < zerosToAdd; i++)
			{
				code = ZERO + code;
			}

			return code;
		}

	}

}