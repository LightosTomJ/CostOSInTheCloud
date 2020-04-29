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
	public class Extracode1Service
	{
		private ProjectContext projectContext;

		public Extracode1Service(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> Extracode1Count()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Extracode1.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Extracode1>> GetAllExtracode1s()
		{
			IList<Models.DB.Project.Extracode1> Extracode1s = new List<Models.DB.Project.Extracode1>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Extracode1> extracode1s = await projectContext.Extracode1.ToListAsync();
				return extracode1s;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateExtracode1(List<Models.DB.Project.Extracode1> Extracode1s)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Extracode1 extracode1 in Extracode1s)
				{
					projectContext.Extracode1.Add(extracode1);
					await projectContext.SaveChangesAsync();
					returnid = extracode1.Groupcodeid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateExtracode1(long id, Models.DB.Project.Extracode1 extracode1)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Extracode1.Update(extracode1);
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
		public async Task<bool> DeleteExtracode1(long extracode1Id)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Extracode1 extracode1 = projectContext.Extracode1.First(p => p.Groupcodeid == extracode1Id);
				projectContext.Extracode1.Remove(extracode1);
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
