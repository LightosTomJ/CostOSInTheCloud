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
	public class TeamAliasService
	{
		private LocalContext localContext;

		public TeamAliasService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> TeamAliasCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.TeamAlias.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.TeamAlias>> GetAllTeamAlias()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.TeamAlias> teamAlias = await localContext.TeamAlias.ToListAsync();
				return teamAlias;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateTeamAlias(List<Models.DB.Local.TeamAlias> TeamAlias)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.TeamAlias teamAlias in TeamAlias)
				{
					localContext.TeamAlias.Add(teamAlias);
					await localContext.SaveChangesAsync();
					returnid = teamAlias.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateTeamAlias(Models.DB.Local.TeamAlias teamAlias)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.TeamAlias.Update(teamAlias);
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
		public async Task<bool> DeleteTeamAlias(long teamAliasId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.TeamAlias teamAlias = localContext.TeamAlias.First(p => p.Id == teamAliasId);
				localContext.TeamAlias.Remove(teamAlias);
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
