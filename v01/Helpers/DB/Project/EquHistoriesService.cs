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
	public class EquHistoriesService
	{
		private ProjectContext projectContext;

		public EquHistoriesService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> EquHistoryCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.EquHistory.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.EquHistory>> GetAllEquHistories()
		{
			IList<Models.DB.Project.EquHistory> EquHistories = new List<Models.DB.Project.EquHistory>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.EquHistory> equHistories = await projectContext.EquHistory.ToListAsync();
				return equHistories;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateEquHistory(List<Models.DB.Project.EquHistory> EquHistories)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.EquHistory equHistory in EquHistories)
				{
					projectContext.EquHistory.Add(equHistory);
					await projectContext.SaveChangesAsync();
					returnid = equHistory.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateEquHistory(long id, Models.DB.Project.EquHistory equHistory)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.EquHistory.Update(equHistory);
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
		public async Task<bool> DeleteEquHistory(long equHistoryId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.EquHistory equHistory = projectContext.EquHistory.First(p => p.Id == equHistoryId);
				projectContext.EquHistory.Remove(equHistory);
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
