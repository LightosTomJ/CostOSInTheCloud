using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Extalias
	{
		private LocalContext localContext;

		public Extalias(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long ExtaliasCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Extalias.Count();
		}

		public List<Models.DB.Local.Extalias> GetAllExtalias()
		{
			List<Models.DB.Local.Extalias> Extalias = new List<Models.DB.Local.Extalias>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Extalias = localContext.Extalias.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Extalias;
		}
		public long Createextalias(List<Models.DB.Local.Extalias> Extalias)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Extalias extalias in Extalias)
				{
					localContext.Extalias.Add(extalias);
					localContext.SaveChanges();
					returnid = extalias.ExtaliasId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateextalias(long id, Models.DB.Local.Extalias extalias)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Extalias.Update(extalias);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteextalias(long extaliasId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Extalias extalias = localContext.Extalias.First(p => p.ExtaliasId == extaliasId);
				localContext.Extalias.Remove(extalias);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
