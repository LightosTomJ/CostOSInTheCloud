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
	public class LabHistoriesService
	{
		private ProjectContext projectContext;

		public LabHistoriesService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> LabHistoryCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.LabHistory.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.LabHistory>> GetAllLabHistories()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.LabHistory> labHistories = await projectContext.LabHistory.ToListAsync();
				return labHistories;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateLabHistory(List<Models.DB.Project.LabHistory> LabHistories)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.LabHistory labHistory in LabHistories)
				{
					projectContext.LabHistory.Add(labHistory);
					await projectContext.SaveChangesAsync();
					returnid = labHistory.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateLabHistory(Models.DB.Project.LabHistory labHistory)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.LabHistory.Update(labHistory);
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
		public async Task<bool> DeleteLabHistory(long labHistoryId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.LabHistory labHistory = projectContext.LabHistory.First(p => p.Id == labHistoryId);
				projectContext.LabHistory.Remove(labHistory);
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
