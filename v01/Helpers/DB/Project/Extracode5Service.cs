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
	public class Extracode5Service
	{
		private ProjectContext projectContext;

		public Extracode5Service(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> Extracode5Count()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Extracode5.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Extracode5>> GetAllExtracode5s()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Extracode5> extracode5s = await projectContext.Extracode5.ToListAsync();
				return extracode5s;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateExtracode5(List<Models.DB.Project.Extracode5> Extracode5s)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Extracode5 extracode5 in Extracode5s)
				{
					projectContext.Extracode5.Add(extracode5);
					await projectContext.SaveChangesAsync();
					returnid = extracode5.Groupcodeid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateExtracode5(Models.DB.Project.Extracode5 extracode5)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Extracode5.Update(extracode5);
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
		public async Task<bool> DeleteExtracode5(long extracode5Id)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Extracode5 extracode5 = projectContext.Extracode5.First(p => p.Groupcodeid == extracode5Id);
				projectContext.Extracode5.Remove(extracode5);
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
