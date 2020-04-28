using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Extracode3
	{
		private LocalContext localContext;

		public Extracode3(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long Extracode3Count()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Extracode3.Count();
		}

		public List<Models.DB.Local.Extracode3> GetAllExtracode3()
		{
			List<Models.DB.Local.Extracode3> Extracode3 = new List<Models.DB.Local.Extracode3>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Extracode3 = localContext.Extracode3.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Extracode3;
		}
		public long Createextracode3(List<Models.DB.Local.Extracode3> Extracode3)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Extracode3 extracode3 in Extracode3)
				{
					localContext.Extracode3.Add(extracode3);
					localContext.SaveChanges();
					returnid = extracode3.Extracode3Id;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateextracode3(long id, Models.DB.Local.Extracode3 extracode3)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Extracode3.Update(extracode3);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteextracode3(long extracode3Id)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Extracode3 extracode3 = localContext.Extracode3.First(p => p.Extracode3Id == extracode3Id);
				localContext.Extracode3.Remove(extracode3);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
