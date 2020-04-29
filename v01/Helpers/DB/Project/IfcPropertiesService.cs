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
	public class IfcPropertiesService
	{
		private ProjectContext projectContext;

		public IfcPropertiesService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> IfcPropertyCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.IfcProperty.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.IfcProperty>> GetAllIfcProperties()
		{
			IList<Models.DB.Project.IfcProperty> IfcProperties = new List<Models.DB.Project.IfcProperty>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.IfcProperty> ifcProperties = await projectContext.IfcProperty.ToListAsync();
				return ifcProperties;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateIfcProperty(List<Models.DB.Project.IfcProperty> IfcProperties)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.IfcProperty ifcProperty in IfcProperties)
				{
					projectContext.IfcProperty.Add(ifcProperty);
					await projectContext.SaveChangesAsync();
					returnid = ifcProperty.Propid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateIfcProperty(long id, Models.DB.Project.IfcProperty ifcProperty)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.IfcProperty.Update(ifcProperty);
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
		public async Task<bool> DeleteIfcProperty(long ifcPropertyId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.IfcProperty ifcProperty = projectContext.IfcProperty.First(p => p.Propid == ifcPropertyId);
				projectContext.IfcProperty.Remove(ifcProperty);
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
