using Models.DB.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Utils
{
	public class Placeholder
	{
		private utilsContext utilsContext;

		public Placeholder(utilsContext dbContext)
		{
			utilsContext = dbContext;
		}

		public long PlaceholderCount()
		{
			if (utilsContext == null) utilsContext = new utilsContext();
			return utilsContext.Placeholder.Count();
		}

		public List<Models.DB.Utils.Placeholder> GetAllPlaceholder()
		{
			List<Models.DB.Utils.Placeholder> Placeholder = new List<Models.DB.Utils.Placeholder>();
			try
			{
				if (utilsContext == null) utilsContext = new utilsContext();
				Placeholder = utilsContext.Placeholder.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Placeholder;
		}
		public long Createplaceholder(List<Models.DB.Utils.Placeholder> Placeholder)
		{
			long returnid = 0;
			try
			{
				if (utilsContext == null) utilsContext = new utilsContext();
				foreach (Models.DB.Utils.Placeholder placeholder in Placeholder)
				{
					utilsContext.Placeholder.Add(placeholder);
					utilsContext.SaveChanges();
					returnid = placeholder.PlaceholderId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateplaceholder(long id, Models.DB.Utils.Placeholder placeholder)
		{
			try
			{
				if (utilsContext == null) utilsContext = new utilsContext();
				utilsContext.Placeholder.Update(placeholder);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteplaceholder(long placeholderId)
		{
			try
			{
				if (utilsContext == null) utilsContext = new utilsContext();
				Models.DB.Utils.Placeholder placeholder = utilsContext.Placeholder.First(p => p.PlaceholderId == placeholderId);
				utilsContext.Placeholder.Remove(placeholder);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
