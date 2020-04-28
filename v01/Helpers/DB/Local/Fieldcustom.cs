using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Fieldcustom
	{
		private LocalContext localContext;

		public Fieldcustom(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long FieldcustomCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Fieldcustom.Count();
		}

		public List<Models.DB.Local.Fieldcustom> GetAllFieldcustom()
		{
			List<Models.DB.Local.Fieldcustom> Fieldcustom = new List<Models.DB.Local.Fieldcustom>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Fieldcustom = localContext.Fieldcustom.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Fieldcustom;
		}
		public long Createfieldcustom(List<Models.DB.Local.Fieldcustom> Fieldcustom)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Fieldcustom fieldcustom in Fieldcustom)
				{
					localContext.Fieldcustom.Add(fieldcustom);
					localContext.SaveChanges();
					returnid = fieldcustom.FieldcustomId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatefieldcustom(long id, Models.DB.Local.Fieldcustom fieldcustom)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Fieldcustom.Update(fieldcustom);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletefieldcustom(long fieldcustomId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Fieldcustom fieldcustom = localContext.Fieldcustom.First(p => p.FieldcustomId == fieldcustomId);
				localContext.Fieldcustom.Remove(fieldcustom);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}
