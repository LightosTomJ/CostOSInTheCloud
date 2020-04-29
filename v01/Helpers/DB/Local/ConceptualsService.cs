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
	public class ConceptualsService
	{
		private LocalContext localContext;

		public ConceptualsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ConceptualsCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Conceptuals.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Conceptuals>> GetAllConceptuals()
		{
			IList<Models.DB.Local.Conceptuals> Conceptuals = new List<Models.DB.Local.Conceptuals>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Conceptuals> conceptuals = await localContext.Conceptuals.ToListAsync();
				return conceptuals;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateConceptuals(List<Models.DB.Local.Conceptuals> Conceptuals)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Conceptuals conceptuals in Conceptuals)
				{
					localContext.Conceptuals.Add(conceptuals);
					await localContext.SaveChangesAsync();
					returnid = conceptuals.Conceptualid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateConceptuals(long id, Models.DB.Local.Conceptuals conceptuals)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Conceptuals.Update(conceptuals);
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
		public async Task<bool> DeleteConceptuals(long conceptualsId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Conceptuals conceptuals = localContext.Conceptuals.First(p => p.Conceptualid == conceptualsId);
				localContext.Conceptuals.Remove(conceptuals);
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
