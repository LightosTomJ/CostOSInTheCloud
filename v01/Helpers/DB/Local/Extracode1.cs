using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Extracode1
	{
		private LocalContext localContext;

		public Extracode1(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long Extracode1Count()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Extracode1.Count();
		}

		public List<Models.DB.Local.Extracode1> GetAllExtracode1()
		{
			List<Models.DB.Local.Extracode1> Extracode1 = new List<Models.DB.Local.Extracode1>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Extracode1 = localContext.Extracode1.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Extracode1;
		}
		public long Createextracode1(List<Models.DB.Local.Extracode1> Extracode1)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Extracode1 extracode1 in Extracode1)
				{
					localContext.Extracode1.Add(extracode1);
					localContext.SaveChanges();
					returnid = extracode1.Extracode1Id;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateextracode1(long id, Models.DB.Local.Extracode1 extracode1)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Extracode1.Update(extracode1);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteextracode1(long extracode1Id)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Extracode1 extracode1 = localContext.Extracode1.First(p => p.Extracode1Id == extracode1Id);
				localContext.Extracode1.Remove(extracode1);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
