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
	public class CnmHistoriesService
	{
		private ProjectContext projectContext;

		public CnmHistoriesService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> CnmHistoryCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.CnmHistory.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.CnmHistory>> GetAllCnmHistories()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.CnmHistory> cnmHistories = await projectContext.CnmHistory.ToListAsync();
				return cnmHistories;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateCnmHistory(List<Models.DB.Project.CnmHistory> CnmHistories)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.CnmHistory cnmHistory in CnmHistories)
				{
					projectContext.CnmHistory.Add(cnmHistory);
					await projectContext.SaveChangesAsync();
					returnid = cnmHistory.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateCnmHistory(Models.DB.Project.CnmHistory cnmHistory)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.CnmHistory.Update(cnmHistory);
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
		public async Task<bool> DeleteCnmHistory(long cnmHistoryId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.CnmHistory cnmHistory = projectContext.CnmHistory.First(p => p.Id == cnmHistoryId);
				projectContext.CnmHistory.Remove(cnmHistory);
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
