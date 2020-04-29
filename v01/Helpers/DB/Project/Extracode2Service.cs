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
	public class Extracode2Service
	{
		private ProjectContext projectContext;

		public Extracode2Service(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> Extracode2Count()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Extracode2.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Extracode2>> GetAllExtracode2s()
		{
			IList<Models.DB.Project.Extracode2> Extracode2s = new List<Models.DB.Project.Extracode2>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Extracode2> extracode2s = await projectContext.Extracode2.ToListAsync();
				return extracode2s;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateExtracode2(List<Models.DB.Project.Extracode2> Extracode2s)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Extracode2 extracode2 in Extracode2s)
				{
					projectContext.Extracode2.Add(extracode2);
					await projectContext.SaveChangesAsync();
					returnid = extracode2.Groupcodeid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateExtracode2(long id, Models.DB.Project.Extracode2 extracode2)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Extracode2.Update(extracode2);
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
		public async Task<bool> DeleteExtracode2(long extracode2Id)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Extracode2 extracode2 = projectContext.Extracode2.First(p => p.Groupcodeid == extracode2Id);
				projectContext.Extracode2.Remove(extracode2);
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
