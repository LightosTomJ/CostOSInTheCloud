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
	public class Extracode7Service
	{
		private ProjectContext projectContext;

		public Extracode7Service(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> Extracode7Count()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Extracode7.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Extracode7>> GetAllExtracode7s()
		{
			IList<Models.DB.Project.Extracode7> Extracode7s = new List<Models.DB.Project.Extracode7>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Extracode7> extracode7s = await projectContext.Extracode7.ToListAsync();
				return extracode7s;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateExtracode7(List<Models.DB.Project.Extracode7> Extracode7s)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Extracode7 extracode7 in Extracode7s)
				{
					projectContext.Extracode7.Add(extracode7);
					await projectContext.SaveChangesAsync();
					returnid = extracode7.Groupcodeid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateExtracode7(long id, Models.DB.Project.Extracode7 extracode7)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Extracode7.Update(extracode7);
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
		public async Task<bool> DeleteExtracode7(long extracode7Id)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Extracode7 extracode7 = projectContext.Extracode7.First(p => p.Groupcodeid == extracode7Id);
				projectContext.Extracode7.Remove(extracode7);
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
