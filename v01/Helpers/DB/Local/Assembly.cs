using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Assemblies
	{
		private LocalContext localContext;

		public Assemblies(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long AssemblyCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Assembly.Count();
		}

		public List<Models.DB.Local.Assembly> GetAllAssemblies()
		{
			List<Models.DB.Local.Assembly> Assemblies = new List<Models.DB.Local.Assembly>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Assemblies = localContext.Assembly.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Assemblies;
		}
		public long Createassembly(List<Models.DB.Local.Assembly> Assemblies)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Assembly assembly in Assemblies)
				{
					localContext.Assembly.Add(assembly);
					localContext.SaveChanges();
					returnid = assembly.AssemblyId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateassembly(long id, Models.DB.Local.Assembly assembly)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Assembly.Update(assembly);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteassembly(long assemblyId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Assembly assembly = localContext.Assembly.First(p => p.AssemblyId == assemblyId);
				localContext.Assembly.Remove(assembly);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
