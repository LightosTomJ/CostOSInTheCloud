using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Extdatasource
	{
		private LocalContext localContext;

		public Extdatasource(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long ExtdatasourceCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Extdatasource.Count();
		}

		public List<Models.DB.Local.Extdatasource> GetAllExtdatasource()
		{
			List<Models.DB.Local.Extdatasource> Extdatasource = new List<Models.DB.Local.Extdatasource>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Extdatasource = localContext.Extdatasource.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Extdatasource;
		}
		public long Createextdatasource(List<Models.DB.Local.Extdatasource> Extdatasource)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Extdatasource extdatasource in Extdatasource)
				{
					localContext.Extdatasource.Add(extdatasource);
					localContext.SaveChanges();
					returnid = extdatasource.ExtdatasourceId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateextdatasource(long id, Models.DB.Local.Extdatasource extdatasource)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Extdatasource.Update(extdatasource);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteextdatasource(long extdatasourceId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Extdatasource extdatasource = localContext.Extdatasource.First(p => p.ExtdatasourceId == extdatasourceId);
				localContext.Extdatasource.Remove(extdatasource);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
