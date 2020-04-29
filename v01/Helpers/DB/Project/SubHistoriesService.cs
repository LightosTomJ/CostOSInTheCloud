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
	public class SubHistoriesService
	{
		private ProjectContext projectContext;

		public SubHistoriesService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> SubHistoryCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.SubHistory.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.SubHistory>> GetAllSubHistories()
		{
			IList<Models.DB.Project.SubHistory> SubHistories = new List<Models.DB.Project.SubHistory>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.SubHistory> subHistories = await projectContext.SubHistory.ToListAsync();
				return subHistories;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateSubHistory(List<Models.DB.Project.SubHistory> SubHistories)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.SubHistory subHistory in SubHistories)
				{
					projectContext.SubHistory.Add(subHistory);
					await projectContext.SaveChangesAsync();
					returnid = subHistory.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateSubHistory(long id, Models.DB.Project.SubHistory subHistory)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.SubHistory.Update(subHistory);
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
		public async Task<bool> DeleteSubHistory(long subHistoryId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.SubHistory subHistory = projectContext.SubHistory.First(p => p.Id == subHistoryId);
				projectContext.SubHistory.Remove(subHistory);
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
