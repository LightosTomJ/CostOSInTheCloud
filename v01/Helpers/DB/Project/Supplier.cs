using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Supplier
	{
		private ProjectContext projectContext;

		public Supplier(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long SupplierCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Supplier.Count();
		}

		public List<Models.DB.Project.Supplier> GetAllSupplier()
		{
			List<Models.DB.Project.Supplier> Supplier = new List<Models.DB.Project.Supplier>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Supplier = projectContext.Supplier.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Supplier;
		}
		public long Createsupplier(List<Models.DB.Project.Supplier> Supplier)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Supplier supplier in Supplier)
				{
					projectContext.Supplier.Add(supplier);
					projectContext.SaveChanges();
					returnid = supplier.SupplierId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatesupplier(long id, Models.DB.Project.Supplier supplier)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Supplier.Update(supplier);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletesupplier(long supplierId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Supplier supplier = projectContext.Supplier.First(p => p.SupplierId == supplierId);
				projectContext.Supplier.Remove(supplier);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
