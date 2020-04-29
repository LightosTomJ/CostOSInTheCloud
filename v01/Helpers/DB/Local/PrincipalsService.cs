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
	public class PrincipalsService
	{
		private LocalContext localContext;

		public PrincipalsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> PrincipalsCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Principals.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Principals>> GetAllPrincipals()
		{
			IList<Models.DB.Local.Principals> Principals = new List<Models.DB.Local.Principals>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Principals> principals = await localContext.Principals.ToListAsync();
				return principals;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<string> CreatePrincipals(List<Models.DB.Local.Principals> Principals)
		{
			string returnid = "";
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Principals principals in Principals)
				{
					localContext.Principals.Add(principals);
					await localContext.SaveChangesAsync();
					returnid = principals.Principalid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdatePrincipals(long id, Models.DB.Local.Principals principals)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Principals.Update(principals);
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
		public async Task<bool> DeletePrincipals(string principalsId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Principals principals = localContext.Principals.First(p => p.Principalid == principalsId);
				localContext.Principals.Remove(principals);
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
