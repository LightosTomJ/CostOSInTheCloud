using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Extracode7
	{
		private LocalContext localContext;

		public Extracode7(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long Extracode7Count()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Extracode7.Count();
		}

		public List<Models.DB.Local.Extracode7> GetAllExtracode7()
		{
			List<Models.DB.Local.Extracode7> Extracode7 = new List<Models.DB.Local.Extracode7>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Extracode7 = localContext.Extracode7.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Extracode7;
		}
		public long Createextracode7(List<Models.DB.Local.Extracode7> Extracode7)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Extracode7 extracode7 in Extracode7)
				{
					localContext.Extracode7.Add(extracode7);
					localContext.SaveChanges();
					returnid = extracode7.Extracode7Id;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateextracode7(long id, Models.DB.Local.Extracode7 extracode7)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Extracode7.Update(extracode7);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteextracode7(long extracode7Id)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Extracode7 extracode7 = localContext.Extracode7.First(p => p.Extracode7Id == extracode7Id);
				localContext.Extracode7.Remove(extracode7);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
