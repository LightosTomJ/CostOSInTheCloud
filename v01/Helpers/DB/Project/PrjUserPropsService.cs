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
	public class PrjUserPropsService
	{
		private ProjectContext projectContext;

		public PrjUserPropsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> PrjUserPropCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.PrjUserProp.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.PrjUserProp>> GetAllPrjUserProps()
		{
			IList<Models.DB.Project.PrjUserProp> PrjUserProps = new List<Models.DB.Project.PrjUserProp>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.PrjUserProp> prjUserProps = await projectContext.PrjUserProp.ToListAsync();
				return prjUserProps;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreatePrjUserProp(List<Models.DB.Project.PrjUserProp> PrjUserProps)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.PrjUserProp prjUserProp in PrjUserProps)
				{
					projectContext.PrjUserProp.Add(prjUserProp);
					await projectContext.SaveChangesAsync();
					returnid = prjUserProp.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdatePrjUserProp(long id, Models.DB.Project.PrjUserProp prjUserProp)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.PrjUserProp.Update(prjUserProp);
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
		public async Task<bool> DeletePrjUserProp(long prjUserPropId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.PrjUserProp prjUserProp = projectContext.PrjUserProp.First(p => p.Id == prjUserPropId);
				projectContext.PrjUserProp.Remove(prjUserProp);
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
