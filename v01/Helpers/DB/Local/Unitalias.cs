using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Unitalias
	{
		private LocalContext localContext;

		public Unitalias(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long UnitaliasCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Unitalias.Count();
		}

		public List<Models.DB.Local.Unitalias> GetAllUnitalias()
		{
			List<Models.DB.Local.Unitalias> Unitalias = new List<Models.DB.Local.Unitalias>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Unitalias = localContext.Unitalias.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Unitalias;
		}
		public long Createunitalias(List<Models.DB.Local.Unitalias> Unitalias)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Unitalias unitalias in Unitalias)
				{
					localContext.Unitalias.Add(unitalias);
					localContext.SaveChanges();
					returnid = unitalias.UnitaliasId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateunitalias(long id, Models.DB.Local.Unitalias unitalias)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Unitalias.Update(unitalias);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteunitalias(long unitaliasId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Unitalias unitalias = localContext.Unitalias.First(p => p.UnitaliasId == unitaliasId);
				localContext.Unitalias.Remove(unitalias);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
