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
	public class AssHistoriesService
	{
		private ProjectContext projectContext;

		public AssHistoriesService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> AssHistoryCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.AssHistory.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.AssHistory>> GetAllAssHistories()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.AssHistory> assHistories = await projectContext.AssHistory.ToListAsync();
				return assHistories;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAssHistory(List<Models.DB.Project.AssHistory> AssHistories)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.AssHistory assHistory in AssHistories)
				{
					projectContext.AssHistory.Add(assHistory);
					await projectContext.SaveChangesAsync();
					returnid = assHistory.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAssHistory(Models.DB.Project.AssHistory assHistory)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.AssHistory.Update(assHistory);
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
		public async Task<bool> DeleteAssHistory(long assHistoryId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.AssHistory assHistory = projectContext.AssHistory.First(p => p.Id == assHistoryId);
				projectContext.AssHistory.Remove(assHistory);
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
