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
	public class SuppliersService
	{
		private ProjectContext projectContext;

		public SuppliersService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> SupplierCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Supplier.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Supplier>> GetAllSuppliers()
		{
			IList<Models.DB.Project.Supplier> Suppliers = new List<Models.DB.Project.Supplier>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Supplier> suppliers = await projectContext.Supplier.ToListAsync();
				return suppliers;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateSupplier(List<Models.DB.Project.Supplier> Suppliers)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Supplier supplier in Suppliers)
				{
					projectContext.Supplier.Add(supplier);
					await projectContext.SaveChangesAsync();
					returnid = supplier.Supplierid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateSupplier(long id, Models.DB.Project.Supplier supplier)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Supplier.Update(supplier);
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
		public async Task<bool> DeleteSupplier(long supplierId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Supplier supplier = projectContext.Supplier.First(p => p.Supplierid == supplierId);
				projectContext.Supplier.Remove(supplier);
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
