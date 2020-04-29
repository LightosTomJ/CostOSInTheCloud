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
	public class ParamConditionsService
	{
		private ProjectContext projectContext;

		public ParamConditionsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> ParamConditionCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.ParamCondition.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.ParamCondition>> GetAllParamConditions()
		{
			IList<Models.DB.Project.ParamCondition> ParamConditions = new List<Models.DB.Project.ParamCondition>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.ParamCondition> paramConditions = await projectContext.ParamCondition.ToListAsync();
				return paramConditions;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<string> CreateParamCondition(List<Models.DB.Project.ParamCondition> ParamConditions)
		{
			string returnid;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.ParamCondition paramCondition in ParamConditions)
				{
					projectContext.ParamCondition.Add(paramCondition);
					await projectContext.SaveChangesAsync();
					returnid = paramCondition.Globalid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return "";
		}

		public async Task<bool> UpdateParamCondition(long id, Models.DB.Project.ParamCondition paramCondition)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.ParamCondition.Update(paramCondition);
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
		public async Task<bool> DeleteParamCondition(string paramConditionId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.ParamCondition paramCondition = projectContext.ParamCondition.First(p => p.Globalid == paramConditionId);
				projectContext.ParamCondition.Remove(paramCondition);
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
