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
	public class BOQItemMetadatasService
	{
		private LocalContext localContext;

		public BOQItemMetadatasService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BOQItemMetadataCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BOQItemMetadata.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BOQItemMetadata>> GetAllBOQItemMetadatas()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BOQItemMetadata> bOQItemMetadatas = await localContext.BOQItemMetadata.ToListAsync();
				return bOQItemMetadatas;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBOQItemMetadata(List<Models.DB.Local.BOQItemMetadata> BOQItemMetadatas)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BOQItemMetadata bOQItemMetadata in BOQItemMetadatas)
				{
					localContext.BOQItemMetadata.Add(bOQItemMetadata);
					await localContext.SaveChangesAsync();
					returnid = bOQItemMetadata.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBOQItemMetadata(Models.DB.Local.BOQItemMetadata bOQItemMetadata)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BOQItemMetadata.Update(bOQItemMetadata);
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
		public async Task<bool> DeleteBOQItemMetadata(long bOQItemMetadataId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BOQItemMetadata bOQItemMetadata = localContext.BOQItemMetadata.First(p => p.Id == bOQItemMetadataId);
				localContext.BOQItemMetadata.Remove(bOQItemMetadata);
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
