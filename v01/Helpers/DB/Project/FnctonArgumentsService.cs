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
	public class FnctonArgumentsService
	{
		private ProjectContext projectContext;

		public FnctonArgumentsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> FnctonArgumentCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.FnctonArgument.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.FnctonArgument>> GetAllFnctonArguments()
		{
			IList<Models.DB.Project.FnctonArgument> FnctonArguments = new List<Models.DB.Project.FnctonArgument>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.FnctonArgument> fnctonArguments = await projectContext.FnctonArgument.ToListAsync();
				return fnctonArguments;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateFnctonArgument(List<Models.DB.Project.FnctonArgument> FnctonArguments)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.FnctonArgument fnctonArgument in FnctonArguments)
				{
					projectContext.FnctonArgument.Add(fnctonArgument);
					await projectContext.SaveChangesAsync();
					returnid = fnctonArgument.Fargid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateFnctonArgument(long id, Models.DB.Project.FnctonArgument fnctonArgument)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.FnctonArgument.Update(fnctonArgument);
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
		public async Task<bool> DeleteFnctonArgument(long fnctonArgumentId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.FnctonArgument fnctonArgument = projectContext.FnctonArgument.First(p => p.Fargid == fnctonArgumentId);
				projectContext.FnctonArgument.Remove(fnctonArgument);
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
