using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Paraminput
	{
		private LocalContext localContext;

		public Paraminput(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long ParaminputCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Paraminput.Count();
		}

		public List<Models.DB.Local.Paraminput> GetAllParaminput()
		{
			List<Models.DB.Local.Paraminput> Paraminput = new List<Models.DB.Local.Paraminput>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Paraminput = localContext.Paraminput.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Paraminput;
		}
		public long Createparaminput(List<Models.DB.Local.Paraminput> Paraminput)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Paraminput paraminput in Paraminput)
				{
					localContext.Paraminput.Add(paraminput);
					localContext.SaveChanges();
					returnid = paraminput.ParaminputId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateparaminput(long id, Models.DB.Local.Paraminput paraminput)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Paraminput.Update(paraminput);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteparaminput(long paraminputId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Paraminput paraminput = localContext.Paraminput.First(p => p.ParaminputId == paraminputId);
				localContext.Paraminput.Remove(paraminput);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
