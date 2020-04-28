using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Paramreturn
	{
		private LocalContext localContext;

		public Paramreturn(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long ParamreturnCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Paramreturn.Count();
		}

		public List<Models.DB.Local.Paramreturn> GetAllParamreturn()
		{
			List<Models.DB.Local.Paramreturn> Paramreturn = new List<Models.DB.Local.Paramreturn>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Paramreturn = localContext.Paramreturn.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Paramreturn;
		}
		public long Createparamreturn(List<Models.DB.Local.Paramreturn> Paramreturn)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Paramreturn paramreturn in Paramreturn)
				{
					localContext.Paramreturn.Add(paramreturn);
					localContext.SaveChanges();
					returnid = paramreturn.ParamreturnId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateparamreturn(long id, Models.DB.Local.Paramreturn paramreturn)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Paramreturn.Update(paramreturn);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteparamreturn(long paramreturnId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Paramreturn paramreturn = localContext.Paramreturn.First(p => p.ParamreturnId == paramreturnId);
				localContext.Paramreturn.Remove(paramreturn);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
