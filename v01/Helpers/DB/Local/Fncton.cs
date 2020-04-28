using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Fncton
	{
		private LocalContext localContext;

		public Fncton(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long FnctonCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Fncton.Count();
		}

		public List<Models.DB.Local.Fncton> GetAllFncton()
		{
			List<Models.DB.Local.Fncton> Fncton = new List<Models.DB.Local.Fncton>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Fncton = localContext.Fncton.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Fncton;
		}
		public long Createfncton(List<Models.DB.Local.Fncton> Fncton)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Fncton fncton in Fncton)
				{
					localContext.Fncton.Add(fncton);
					localContext.SaveChanges();
					returnid = fncton.FnctonId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatefncton(long id, Models.DB.Local.Fncton fncton)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Fncton.Update(fncton);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletefncton(long fnctonId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Fncton fncton = localContext.Fncton.First(p => p.FnctonId == fnctonId);
				localContext.Fncton.Remove(fncton);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
