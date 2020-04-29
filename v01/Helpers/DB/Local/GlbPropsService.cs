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
	public class GlbPropsService
	{
		private LocalContext localContext;

		public GlbPropsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> GlbPropCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.GlbProp.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.GlbProp>> GetAllGlbProps()
		{
			IList<Models.DB.Local.GlbProp> GlbProps = new List<Models.DB.Local.GlbProp>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.GlbProp> glbProps = await localContext.GlbProp.ToListAsync();
				return glbProps;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateGlbProp(List<Models.DB.Local.GlbProp> GlbProps)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.GlbProp glbProp in GlbProps)
				{
					localContext.GlbProp.Add(glbProp);
					await localContext.SaveChangesAsync();
					returnid = glbProp.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateGlbProp(long id, Models.DB.Local.GlbProp glbProp)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.GlbProp.Update(glbProp);
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
		public async Task<bool> DeleteGlbProp(long glbPropId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.GlbProp glbProp = localContext.GlbProp.First(p => p.Id == glbPropId);
				localContext.GlbProp.Remove(glbProp);
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
