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
	public class BoqItemMetadatasService
	{
		private ProjectContext projectContext;

		public BoqItemMetadatasService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> BoqItemMetadataCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.BoqItemMetadata.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.BoqItemMetadata>> GetAllBoqItemMetadatas()
		{
			IList<Models.DB.Project.BoqItemMetadata> BoqItemMetadatas = new List<Models.DB.Project.BoqItemMetadata>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.BoqItemMetadata> boqItemMetadatas = await projectContext.BoqItemMetadata.ToListAsync();
				return boqItemMetadatas;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBoqItemMetadata(List<Models.DB.Project.BoqItemMetadata> BoqItemMetadatas)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.BoqItemMetadata boqItemMetadata in BoqItemMetadatas)
				{
					projectContext.BoqItemMetadata.Add(boqItemMetadata);
					await projectContext.SaveChangesAsync();
					returnid = boqItemMetadata.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBoqItemMetadata(long id, Models.DB.Project.BoqItemMetadata boqItemMetadata)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.BoqItemMetadata.Update(boqItemMetadata);
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
		public async Task<bool> DeleteBoqItemMetadata(long boqItemMetadataId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.BoqItemMetadata boqItemMetadata = projectContext.BoqItemMetadata.First(p => p.Id == boqItemMetadataId);
				projectContext.BoqItemMetadata.Remove(boqItemMetadata);
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
