using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Layoutc
	{
		private LocalContext localContext;

		public Layoutc(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long LayoutcCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Layoutc.Count();
		}

		public List<Models.DB.Local.Layoutc> GetAllLayoutc()
		{
			List<Models.DB.Local.Layoutc> Layoutc = new List<Models.DB.Local.Layoutc>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Layoutc = localContext.Layoutc.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Layoutc;
		}
		public long Createlayoutc(List<Models.DB.Local.Layoutc> Layoutc)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Layoutc layoutc in Layoutc)
				{
					localContext.Layoutc.Add(layoutc);
					localContext.SaveChanges();
					returnid = layoutc.LayoutcId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatelayoutc(long id, Models.DB.Local.Layoutc layoutc)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Layoutc.Update(layoutc);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletelayoutc(long layoutcId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Layoutc layoutc = localContext.Layoutc.First(p => p.LayoutcId == layoutcId);
				localContext.Layoutc.Remove(layoutc);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
