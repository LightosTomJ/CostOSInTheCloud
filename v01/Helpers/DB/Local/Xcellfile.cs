using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Xcellfile
	{
		private LocalContext localContext;

		public Xcellfile(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long XcellfileCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Xcellfile.Count();
		}

		public List<Models.DB.Local.Xcellfile> GetAllXcellfile()
		{
			List<Models.DB.Local.Xcellfile> Xcellfile = new List<Models.DB.Local.Xcellfile>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Xcellfile = localContext.Xcellfile.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Xcellfile;
		}
		public long Createxcellfile(List<Models.DB.Local.Xcellfile> Xcellfile)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Xcellfile xcellfile in Xcellfile)
				{
					localContext.Xcellfile.Add(xcellfile);
					localContext.SaveChanges();
					returnid = xcellfile.XcellfileId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatexcellfile(long id, Models.DB.Local.Xcellfile xcellfile)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Xcellfile.Update(xcellfile);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletexcellfile(long xcellfileId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Xcellfile xcellfile = localContext.Xcellfile.First(p => p.XcellfileId == xcellfileId);
				localContext.Xcellfile.Remove(xcellfile);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
