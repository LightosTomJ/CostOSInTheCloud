using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class AssemblyChild
	{
		private LocalContext localContext;

		public AssemblyChild(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long AssemblyChildCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.AssemblyChild.Count();
		}

		public List<Models.DB.Local.AssemblyChild> GetAllAssemblyChild()
		{
			List<Models.DB.Local.AssemblyChild> AssemblyChild = new List<Models.DB.Local.AssemblyChild>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				AssemblyChild = localContext.AssemblyChild.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AssemblyChild;
		}
		public long CreateassemblyChild(List<Models.DB.Local.AssemblyChild> AssemblyChild)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AssemblyChild assemblyChild in AssemblyChild)
				{
					localContext.AssemblyChild.Add(assemblyChild);
					localContext.SaveChanges();
					returnid = assemblyChild.AssemblyChildId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdateassemblyChild(long id, Models.DB.Local.AssemblyChild assemblyChild)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AssemblyChild.Update(assemblyChild);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeleteassemblyChild(long assemblyChildId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AssemblyChild assemblyChild = localContext.AssemblyChild.First(p => p.AssemblyChildId == assemblyChildId);
				localContext.AssemblyChild.Remove(assemblyChild);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
