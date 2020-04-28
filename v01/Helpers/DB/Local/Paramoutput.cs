using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Paramoutput
	{
		private LocalContext localContext;

		public Paramoutput(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long ParamoutputCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Paramoutput.Count();
		}

		public List<Models.DB.Local.Paramoutput> GetAllParamoutput()
		{
			List<Models.DB.Local.Paramoutput> Paramoutput = new List<Models.DB.Local.Paramoutput>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Paramoutput = localContext.Paramoutput.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Paramoutput;
		}
		public long Createparamoutput(List<Models.DB.Local.Paramoutput> Paramoutput)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Paramoutput paramoutput in Paramoutput)
				{
					localContext.Paramoutput.Add(paramoutput);
					localContext.SaveChanges();
					returnid = paramoutput.ParamoutputId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateparamoutput(long id, Models.DB.Local.Paramoutput paramoutput)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Paramoutput.Update(paramoutput);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteparamoutput(long paramoutputId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Paramoutput paramoutput = localContext.Paramoutput.First(p => p.ParamoutputId == paramoutputId);
				localContext.Paramoutput.Remove(paramoutput);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
