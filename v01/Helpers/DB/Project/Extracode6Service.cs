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
	public class Extracode6Service
	{
		private ProjectContext projectContext;

		public Extracode6Service(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> Extracode6Count()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Extracode6.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Extracode6>> GetAllExtracode6s()
		{
			IList<Models.DB.Project.Extracode6> Extracode6s = new List<Models.DB.Project.Extracode6>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Extracode6> extracode6s = await projectContext.Extracode6.ToListAsync();
				return extracode6s;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateExtracode6(List<Models.DB.Project.Extracode6> Extracode6s)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Extracode6 extracode6 in Extracode6s)
				{
					projectContext.Extracode6.Add(extracode6);
					await projectContext.SaveChangesAsync();
					returnid = extracode6.Groupcodeid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateExtracode6(long id, Models.DB.Project.Extracode6 extracode6)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Extracode6.Update(extracode6);
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
		public async Task<bool> DeleteExtracode6(long extracode6Id)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Extracode6 extracode6 = projectContext.Extracode6.First(p => p.Groupcodeid == extracode6Id);
				projectContext.Extracode6.Remove(extracode6);
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
