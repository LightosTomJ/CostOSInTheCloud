using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Extracode4
	{
		private LocalContext localContext;

		public Extracode4(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long Extracode4Count()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Extracode4.Count();
		}

		public List<Models.DB.Local.Extracode4> GetAllExtracode4()
		{
			List<Models.DB.Local.Extracode4> Extracode4 = new List<Models.DB.Local.Extracode4>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Extracode4 = localContext.Extracode4.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Extracode4;
		}
		public long Createextracode4(List<Models.DB.Local.Extracode4> Extracode4)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Extracode4 extracode4 in Extracode4)
				{
					localContext.Extracode4.Add(extracode4);
					localContext.SaveChanges();
					returnid = extracode4.Extracode4Id;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateextracode4(long id, Models.DB.Local.Extracode4 extracode4)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Extracode4.Update(extracode4);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteextracode4(long extracode4Id)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Extracode4 extracode4 = localContext.Extracode4.First(p => p.Extracode4Id == extracode4Id);
				localContext.Extracode4.Remove(extracode4);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
