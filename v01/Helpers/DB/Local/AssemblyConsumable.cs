using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class AssemblyConsumable
	{
		private LocalContext localContext;

		public AssemblyConsumable(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long AssemblyConsumableCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.AssemblyConsumable.Count();
		}

		public List<Models.DB.Local.AssemblyConsumable> GetAllAssemblyConsumable()
		{
			List<Models.DB.Local.AssemblyConsumable> AssemblyConsumable = new List<Models.DB.Local.AssemblyConsumable>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				AssemblyConsumable = localContext.AssemblyConsumable.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AssemblyConsumable;
		}
		public long CreateassemblyConsumable(List<Models.DB.Local.AssemblyConsumable> AssemblyConsumable)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AssemblyConsumable assemblyConsumable in AssemblyConsumable)
				{
					localContext.AssemblyConsumable.Add(assemblyConsumable);
					localContext.SaveChanges();
					returnid = assemblyConsumable.AssemblyConsumableId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateassemblyConsumable(long id, Models.DB.Local.AssemblyConsumable assemblyConsumable)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AssemblyConsumable.Update(assemblyConsumable);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteassemblyConsumable(long assemblyConsumableId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AssemblyConsumable assemblyConsumable = localContext.AssemblyConsumable.First(p => p.AssemblyConsumableId == assemblyConsumableId);
				localContext.AssemblyConsumable.Remove(assemblyConsumable);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
