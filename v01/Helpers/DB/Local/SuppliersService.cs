using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class SuppliersService
	{
		private LocalContext localContext;

		public SuppliersService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> SupplierCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Supplier.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Supplier>> GetAllSuppliers()
		{
			IList<Models.DB.Local.Supplier> Suppliers = new List<Models.DB.Local.Supplier>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Supplier> suppliers = await localContext.Supplier.ToListAsync();
				return suppliers;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateSupplier(List<Models.DB.Local.Supplier> Suppliers)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Supplier supplier in Suppliers)
				{
					localContext.Supplier.Add(supplier);
					await localContext.SaveChangesAsync();
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

		public async Task<bool> UpdateSupplier(long id, Models.DB.Local.Supplier supplier)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Supplier.Update(supplier);
				await localContext.SaveChangesAsync();
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
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Supplier supplier = localContext.Supplier.First(p => p.Supplierid == supplierId);
				localContext.Supplier.Remove(supplier);
				await localContext.SaveChangesAsync();
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
