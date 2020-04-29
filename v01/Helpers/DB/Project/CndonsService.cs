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
	public class CndonsService
	{
		private ProjectContext projectContext;

		public CndonsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> CndonCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Cndon.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Cndon>> GetAllCndons()
		{
			IList<Models.DB.Project.Cndon> Cndons = new List<Models.DB.Project.Cndon>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Cndon> cndons = await projectContext.Cndon.ToListAsync();
				return cndons;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateCndon(List<Models.DB.Project.Cndon> Cndons)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Cndon cndon in Cndons)
				{
					projectContext.Cndon.Add(cndon);
					await projectContext.SaveChangesAsync();
					returnid = cndon.Conditionid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateCndon(long id, Models.DB.Project.Cndon cndon)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Cndon.Update(cndon);
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
		public async Task<bool> DeleteCndon(long cndonId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Cndon cndon = projectContext.Cndon.First(p => p.Conditionid == cndonId);
				projectContext.Cndon.Remove(cndon);
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
