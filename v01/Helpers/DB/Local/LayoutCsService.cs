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
	public class LayoutCsService
	{
		private LocalContext localContext;

		public LayoutCsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> LayoutCCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.LayoutC.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.LayoutC>> GetAllLayoutCs()
		{
			IList<Models.DB.Local.LayoutC> LayoutCs = new List<Models.DB.Local.LayoutC>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.LayoutC> layoutCs = await localContext.LayoutC.ToListAsync();
				return layoutCs;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateLayoutC(List<Models.DB.Local.LayoutC> LayoutCs)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.LayoutC layoutC in LayoutCs)
				{
					localContext.LayoutC.Add(layoutC);
					await localContext.SaveChangesAsync();
					returnid = layoutC.Layoutcid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateLayoutC(long id, Models.DB.Local.LayoutC layoutC)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.LayoutC.Update(layoutC);
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
		public async Task<bool> DeleteLayoutC(long layoutCId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.LayoutC layoutC = localContext.LayoutC.First(p => p.Layoutcid == layoutCId);
				localContext.LayoutC.Remove(layoutC);
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
