using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Supplier
	{
		private LocalContext localContext;

		public Supplier(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long SupplierCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Supplier.Count();
		}

		public List<Models.DB.Local.Supplier> GetAllSupplier()
		{
			List<Models.DB.Local.Supplier> Supplier = new List<Models.DB.Local.Supplier>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Supplier = localContext.Supplier.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Supplier;
		}
		public long Createsupplier(List<Models.DB.Local.Supplier> Supplier)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Supplier supplier in Supplier)
				{
					localContext.Supplier.Add(supplier);
					localContext.SaveChanges();
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

		public void Updatesupplier(long id, Models.DB.Local.Supplier supplier)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Supplier.Update(supplier);
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
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Supplier supplier = localContext.Supplier.First(p => p.SupplierId == supplierId);
				localContext.Supplier.Remove(supplier);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
