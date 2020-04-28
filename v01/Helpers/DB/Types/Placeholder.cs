using Models.DB.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Types
{
	public class Placeholder
	{
		private typesContext typesContext;

		public Placeholder(typesContext dbContext)
		{
			typesContext = dbContext;
		}

		public long PlaceholderCount()
		{
			if (typesContext == null) typesContext = new typesContext();
			return typesContext.Placeholder.Count();
		}

		public List<Models.DB.Types.Placeholder> GetAllPlaceholder()
		{
			List<Models.DB.Types.Placeholder> Placeholder = new List<Models.DB.Types.Placeholder>();
			try
			{
				if (typesContext == null) typesContext = new typesContext();
				Placeholder = typesContext.Placeholder.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Placeholder;
		}
		public long Createplaceholder(List<Models.DB.Types.Placeholder> Placeholder)
		{
			long returnid = 0;
			try
			{
				if (typesContext == null) typesContext = new typesContext();
				foreach (Models.DB.Types.Placeholder placeholder in Placeholder)
				{
					typesContext.Placeholder.Add(placeholder);
					typesContext.SaveChanges();
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

		public void Updateplaceholder(long id, Models.DB.Types.Placeholder placeholder)
		{
			try
			{
				if (typesContext == null) typesContext = new typesContext();
				typesContext.Placeholder.Update(placeholder);
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
				if (typesContext == null) typesContext = new typesContext();
				Models.DB.Types.Placeholder placeholder = typesContext.Placeholder.First(p => p.PlaceholderId == placeholderId);
				typesContext.Placeholder.Remove(placeholder);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
