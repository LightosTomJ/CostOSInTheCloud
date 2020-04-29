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
	public class GroupcodesService
	{
		private ProjectContext projectContext;

		public GroupcodesService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> GroupcodeCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Groupcode.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Groupcode>> GetAllGroupcodes()
		{
			IList<Models.DB.Project.Groupcode> Groupcodes = new List<Models.DB.Project.Groupcode>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Groupcode> groupcodes = await projectContext.Groupcode.ToListAsync();
				return groupcodes;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateGroupcode(List<Models.DB.Project.Groupcode> Groupcodes)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Groupcode groupcode in Groupcodes)
				{
					projectContext.Groupcode.Add(groupcode);
					await projectContext.SaveChangesAsync();
					returnid = groupcode.Groupcodeid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateGroupcode(long id, Models.DB.Project.Groupcode groupcode)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Groupcode.Update(groupcode);
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
		public async Task<bool> DeleteGroupcode(long groupcodeId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Groupcode groupcode = projectContext.Groupcode.First(p => p.Groupcodeid == groupcodeId);
				projectContext.Groupcode.Remove(groupcode);
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
