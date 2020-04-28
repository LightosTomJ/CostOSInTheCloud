using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Extracode5
	{
		private LocalContext localContext;

		public Extracode5(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long Extracode5Count()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Extracode5.Count();
		}

		public List<Models.DB.Local.Extracode5> GetAllExtracode5()
		{
			List<Models.DB.Local.Extracode5> Extracode5 = new List<Models.DB.Local.Extracode5>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Extracode5 = localContext.Extracode5.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Extracode5;
		}
		public long Createextracode5(List<Models.DB.Local.Extracode5> Extracode5)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Extracode5 extracode5 in Extracode5)
				{
					localContext.Extracode5.Add(extracode5);
					localContext.SaveChanges();
					returnid = extracode5.Extracode5Id;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateextracode5(long id, Models.DB.Local.Extracode5 extracode5)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Extracode5.Update(extracode5);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteextracode5(long extracode5Id)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Extracode5 extracode5 = localContext.Extracode5.First(p => p.Extracode5Id == extracode5Id);
				localContext.Extracode5.Remove(extracode5);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
