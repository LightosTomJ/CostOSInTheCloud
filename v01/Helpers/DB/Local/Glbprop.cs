using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Glbprop
	{
		private LocalContext localContext;

		public Glbprop(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long GlbpropCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Glbprop.Count();
		}

		public List<Models.DB.Local.Glbprop> GetAllGlbprop()
		{
			List<Models.DB.Local.Glbprop> Glbprop = new List<Models.DB.Local.Glbprop>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Glbprop = localContext.Glbprop.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Glbprop;
		}
		public long Createglbprop(List<Models.DB.Local.Glbprop> Glbprop)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Glbprop glbprop in Glbprop)
				{
					localContext.Glbprop.Add(glbprop);
					localContext.SaveChanges();
					returnid = glbprop.GlbpropId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateglbprop(long id, Models.DB.Local.Glbprop glbprop)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Glbprop.Update(glbprop);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteglbprop(long glbpropId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Glbprop glbprop = localContext.Glbprop.First(p => p.GlbpropId == glbpropId);
				localContext.Glbprop.Remove(glbprop);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
