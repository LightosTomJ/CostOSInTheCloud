using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Userprop
	{
		private LocalContext localContext;

		public Userprop(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long UserpropCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Userprop.Count();
		}

		public List<Models.DB.Local.Userprop> GetAllUserprop()
		{
			List<Models.DB.Local.Userprop> Userprop = new List<Models.DB.Local.Userprop>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Userprop = localContext.Userprop.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Userprop;
		}
		public long Createuserprop(List<Models.DB.Local.Userprop> Userprop)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Userprop userprop in Userprop)
				{
					localContext.Userprop.Add(userprop);
					localContext.SaveChanges();
					returnid = userprop.UserpropId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateuserprop(long id, Models.DB.Local.Userprop userprop)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Userprop.Update(userprop);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteuserprop(long userpropId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Userprop userprop = localContext.Userprop.First(p => p.UserpropId == userpropId);
				localContext.Userprop.Remove(userprop);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
