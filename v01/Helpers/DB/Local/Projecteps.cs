using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Projecteps
	{
		private LocalContext localContext;

		public Projecteps(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long ProjectepsCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Projecteps.Count();
		}

		public List<Models.DB.Local.Projecteps> GetAllProjecteps()
		{
			List<Models.DB.Local.Projecteps> Projecteps = new List<Models.DB.Local.Projecteps>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Projecteps = localContext.Projecteps.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Projecteps;
		}
		public long Createprojecteps(List<Models.DB.Local.Projecteps> Projecteps)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Projecteps projecteps in Projecteps)
				{
					localContext.Projecteps.Add(projecteps);
					localContext.SaveChanges();
					returnid = projecteps.ProjectepsId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateprojecteps(long id, Models.DB.Local.Projecteps projecteps)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Projecteps.Update(projecteps);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteprojecteps(long projectepsId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Projecteps projecteps = localContext.Projecteps.First(p => p.ProjectepsId == projectepsId);
				localContext.Projecteps.Remove(projecteps);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
