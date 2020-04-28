using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Prjprop
	{
		private LocalContext localContext;

		public Prjprop(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long PrjpropCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Prjprop.Count();
		}

		public List<Models.DB.Local.Prjprop> GetAllPrjprop()
		{
			List<Models.DB.Local.Prjprop> Prjprop = new List<Models.DB.Local.Prjprop>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Prjprop = localContext.Prjprop.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Prjprop;
		}
		public long Createprjprop(List<Models.DB.Local.Prjprop> Prjprop)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Prjprop prjprop in Prjprop)
				{
					localContext.Prjprop.Add(prjprop);
					localContext.SaveChanges();
					returnid = prjprop.PrjpropId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateprjprop(long id, Models.DB.Local.Prjprop prjprop)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Prjprop.Update(prjprop);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteprjprop(long prjpropId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Prjprop prjprop = localContext.Prjprop.First(p => p.PrjpropId == prjpropId);
				localContext.Prjprop.Remove(prjprop);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
