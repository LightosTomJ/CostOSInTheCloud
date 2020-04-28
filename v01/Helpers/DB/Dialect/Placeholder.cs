using Models.DB.Dialect;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Dialect
{
	public class Placeholders
	{
		private DialectContext dialectContext;

		public Placeholders(DialectContext dbContext)
		{
			dialectContext = dbContext;
		}

		public long PlaceholderCount()
		{
			if (dialectContext == null) dialectContext = new DialectContext();
			return dialectContext.Placeholder.Count();
		}

		public List<Models.DB.Dialect.Placeholder> GetAllPlaceholders()
		{
			List<Models.DB.Dialect.Placeholder> Placeholders = new List<Models.DB.Dialect.Placeholder>();
			try
			{
				if (dialectContext == null) dialectContext = new DialectContext();
				Placeholders = dialectContext.Placeholder.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Placeholders;
		}
		public long Createplaceholder(List<Models.DB.Dialect.Placeholder> Placeholders)
		{
			long returnid = 0;
			try
			{
				if (dialectContext == null) dialectContext = new DialectContext();
				foreach (Models.DB.Dialect.Placeholder placeholder in Placeholders)
				{
					dialectContext.Placeholder.Add(placeholder);
					dialectContext.SaveChanges();
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

		public void Updateplaceholder(long id, Models.DB.Dialect.Placeholder placeholder)
		{
			try
			{
				if (dialectContext == null) dialectContext = new DialectContext();
				dialectContext.Placeholder.Update(placeholder);
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
				if (dialectContext == null) dialectContext = new DialectContext();
				Models.DB.Dialect.Placeholder placeholder = dialectContext.Placeholder.First(p => p.PlaceholderId == placeholderId);
				dialectContext.Placeholder.Remove(placeholder);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
