using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Extracode6
	{
		private LocalContext localContext;

		public Extracode6(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long Extracode6Count()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Extracode6.Count();
		}

		public List<Models.DB.Local.Extracode6> GetAllExtracode6()
		{
			List<Models.DB.Local.Extracode6> Extracode6 = new List<Models.DB.Local.Extracode6>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Extracode6 = localContext.Extracode6.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Extracode6;
		}
		public long Createextracode6(List<Models.DB.Local.Extracode6> Extracode6)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Extracode6 extracode6 in Extracode6)
				{
					localContext.Extracode6.Add(extracode6);
					localContext.SaveChanges();
					returnid = extracode6.Extracode6Id;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateextracode6(long id, Models.DB.Local.Extracode6 extracode6)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Extracode6.Update(extracode6);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteextracode6(long extracode6Id)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Extracode6 extracode6 = localContext.Extracode6.First(p => p.Extracode6Id == extracode6Id);
				localContext.Extracode6.Remove(extracode6);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
