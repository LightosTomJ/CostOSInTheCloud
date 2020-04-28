using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class FnctonArgument
	{
		private LocalContext localContext;

		public FnctonArgument(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long FnctonArgumentCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.FnctonArgument.Count();
		}

		public List<Models.DB.Local.FnctonArgument> GetAllFnctonArgument()
		{
			List<Models.DB.Local.FnctonArgument> FnctonArgument = new List<Models.DB.Local.FnctonArgument>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				FnctonArgument = localContext.FnctonArgument.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return FnctonArgument;
		}
		public long CreatefnctonArgument(List<Models.DB.Local.FnctonArgument> FnctonArgument)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.FnctonArgument fnctonArgument in FnctonArgument)
				{
					localContext.FnctonArgument.Add(fnctonArgument);
					localContext.SaveChanges();
					returnid = fnctonArgument.FnctonArgumentId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatefnctonArgument(long id, Models.DB.Local.FnctonArgument fnctonArgument)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.FnctonArgument.Update(fnctonArgument);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletefnctonArgument(long fnctonArgumentId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.FnctonArgument fnctonArgument = localContext.FnctonArgument.First(p => p.FnctonArgumentId == fnctonArgumentId);
				localContext.FnctonArgument.Remove(fnctonArgument);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
