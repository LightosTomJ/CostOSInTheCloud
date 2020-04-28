using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Extracode2
	{
		private LocalContext localContext;

		public Extracode2(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long Extracode2Count()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Extracode2.Count();
		}

		public List<Models.DB.Local.Extracode2> GetAllExtracode2()
		{
			List<Models.DB.Local.Extracode2> Extracode2 = new List<Models.DB.Local.Extracode2>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Extracode2 = localContext.Extracode2.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Extracode2;
		}
		public long Createextracode2(List<Models.DB.Local.Extracode2> Extracode2)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Extracode2 extracode2 in Extracode2)
				{
					localContext.Extracode2.Add(extracode2);
					localContext.SaveChanges();
					returnid = extracode2.Extracode2Id;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateextracode2(long id, Models.DB.Local.Extracode2 extracode2)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Extracode2.Update(extracode2);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteextracode2(long extracode2Id)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Extracode2 extracode2 = localContext.Extracode2.First(p => p.Extracode2Id == extracode2Id);
				localContext.Extracode2.Remove(extracode2);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
