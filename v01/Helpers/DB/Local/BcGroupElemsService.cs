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
	public class BcGroupElemsService
	{
		private LocalContext localContext;

		public BcGroupElemsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcGroupElemCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcGroupElem.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcGroupElem>> GetAllBcGroupElems()
		{
			IList<Models.DB.Local.BcGroupElem> BcGroupElems = new List<Models.DB.Local.BcGroupElem>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcGroupElem> bcGroupElems = await localContext.BcGroupElem.ToListAsync();
				return bcGroupElems;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcGroupElem(List<Models.DB.Local.BcGroupElem> BcGroupElems)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcGroupElem bcGroupElem in BcGroupElems)
				{
					localContext.BcGroupElem.Add(bcGroupElem);
					await localContext.SaveChangesAsync();
					returnid = bcGroupElem.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcGroupElem(long id, Models.DB.Local.BcGroupElem bcGroupElem)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcGroupElem.Update(bcGroupElem);
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
		public async Task<bool> DeleteBcGroupElem(long bcGroupElemId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcGroupElem bcGroupElem = localContext.BcGroupElem.First(p => p.Id == bcGroupElemId);
				localContext.BcGroupElem.Remove(bcGroupElem);
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
