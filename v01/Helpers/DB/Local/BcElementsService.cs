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
	public class BcElementsService
	{
		private LocalContext localContext;

		public BcElementsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcElementCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcElement.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcElement>> GetAllBcElements()
		{
			IList<Models.DB.Local.BcElement> BcElements = new List<Models.DB.Local.BcElement>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcElement> bcElements = await localContext.BcElement.ToListAsync();
				return bcElements;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcElement(List<Models.DB.Local.BcElement> BcElements)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcElement bcElement in BcElements)
				{
					localContext.BcElement.Add(bcElement);
					await localContext.SaveChangesAsync();
					returnid = bcElement.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcElement(long id, Models.DB.Local.BcElement bcElement)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcElement.Update(bcElement);
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
		public async Task<bool> DeleteBcElement(long bcElementId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcElement bcElement = localContext.BcElement.First(p => p.Id == bcElementId);
				localContext.BcElement.Remove(bcElement);
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
