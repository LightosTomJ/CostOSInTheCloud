using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class PrjPropsService
	{
		private ProjectContext projectContext;

		public PrjPropsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> PrjPropCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.PrjProp.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.PrjProp>> GetAllPrjProps()
		{
			IList<Models.DB.Project.PrjProp> PrjProps = new List<Models.DB.Project.PrjProp>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.PrjProp> prjProps = await projectContext.PrjProp.ToListAsync();
				return prjProps;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreatePrjProp(List<Models.DB.Project.PrjProp> PrjProps)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.PrjProp prjProp in PrjProps)
				{
					projectContext.PrjProp.Add(prjProp);
					await projectContext.SaveChangesAsync();
					returnid = prjProp.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdatePrjProp(long id, Models.DB.Project.PrjProp prjProp)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.PrjProp.Update(prjProp);
				await projectContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
		public async Task<bool> DeletePrjProp(long prjPropId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.PrjProp prjProp = projectContext.PrjProp.First(p => p.Id == prjPropId);
				projectContext.PrjProp.Remove(prjProp);
				await projectContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
	}
}
