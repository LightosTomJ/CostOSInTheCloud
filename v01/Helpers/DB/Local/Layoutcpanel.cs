using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Layoutcpanel
	{
		private LocalContext localContext;

		public Layoutcpanel(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long LayoutcpanelCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Layoutcpanel.Count();
		}

		public List<Models.DB.Local.Layoutcpanel> GetAllLayoutcpanel()
		{
			List<Models.DB.Local.Layoutcpanel> Layoutcpanel = new List<Models.DB.Local.Layoutcpanel>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Layoutcpanel = localContext.Layoutcpanel.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Layoutcpanel;
		}
		public long Createlayoutcpanel(List<Models.DB.Local.Layoutcpanel> Layoutcpanel)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Layoutcpanel layoutcpanel in Layoutcpanel)
				{
					localContext.Layoutcpanel.Add(layoutcpanel);
					localContext.SaveChanges();
					returnid = layoutcpanel.LayoutcpanelId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatelayoutcpanel(long id, Models.DB.Local.Layoutcpanel layoutcpanel)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Layoutcpanel.Update(layoutcpanel);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletelayoutcpanel(long layoutcpanelId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Layoutcpanel layoutcpanel = localContext.Layoutcpanel.First(p => p.LayoutcpanelId == layoutcpanelId);
				localContext.Layoutcpanel.Remove(layoutcpanel);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
