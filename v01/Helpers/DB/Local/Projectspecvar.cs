using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Projectspecvar
	{
		private LocalContext localContext;

		public Projectspecvar(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long ProjectspecvarCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Projectspecvar.Count();
		}

		public List<Models.DB.Local.Projectspecvar> GetAllProjectspecvar()
		{
			List<Models.DB.Local.Projectspecvar> Projectspecvar = new List<Models.DB.Local.Projectspecvar>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Projectspecvar = localContext.Projectspecvar.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Projectspecvar;
		}
		public long Createprojectspecvar(List<Models.DB.Local.Projectspecvar> Projectspecvar)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Projectspecvar projectspecvar in Projectspecvar)
				{
					localContext.Projectspecvar.Add(projectspecvar);
					localContext.SaveChanges();
					returnid = projectspecvar.ProjectspecvarId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateprojectspecvar(long id, Models.DB.Local.Projectspecvar projectspecvar)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Projectspecvar.Update(projectspecvar);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteprojectspecvar(long projectspecvarId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Projectspecvar projectspecvar = localContext.Projectspecvar.First(p => p.ProjectspecvarId == projectspecvarId);
				localContext.Projectspecvar.Remove(projectspecvar);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
