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
	public class IfcelementsService
	{
		private ProjectContext projectContext;

		public IfcelementsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> IfcelementCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Ifcelement.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Ifcelement>> GetAllIfcelements()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Ifcelement> ifcelements = await projectContext.Ifcelement.ToListAsync();
				return ifcelements;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateIfcelement(List<Models.DB.Project.Ifcelement> Ifcelements)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Ifcelement ifcelement in Ifcelements)
				{
					projectContext.Ifcelement.Add(ifcelement);
					await projectContext.SaveChangesAsync();
					returnid = ifcelement.Elemid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateIfcelement(Models.DB.Project.Ifcelement ifcelement)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Ifcelement.Update(ifcelement);
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
		public async Task<bool> DeleteIfcelement(long ifcelementId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Ifcelement ifcelement = projectContext.Ifcelement.First(p => p.Elemid == ifcelementId);
				projectContext.Ifcelement.Remove(ifcelement);
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
