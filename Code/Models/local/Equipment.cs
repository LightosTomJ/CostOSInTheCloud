
namespace Models.local
{
	public class Equipment : BaseClass.Equipment//, Interfaces.IEquipment
	{
		public Equipment Clone()
		{
			Equipment c = new Equipment();
			c.Equipmentid = Equipmentid;
			c.Description = Description;
			c.Make = Make;
			c.Model = Model;
			c.Unit = Unit;
			c.Groupcode = Groupcode;
			c.Gekcode = Gekcode;
			c.Fueltype = Fueltype;
			c.Reservationrate = Reservationrate;
			c.Sparepartsrate = Sparepartsrate;
			c.Tiresrate = Tiresrate;
			c.Fuelrate = Fuelrate;
			c.Lubricatesrate = Lubricatesrate;
			c.Depreciationrate = Depreciationrate;
			c.Fuelconsumption = Fuelconsumption;
			c.Currency = Currency;
			c.Country = Country;
			c.State = State;
			c.Totalrate = Totalrate;
			c.Notes = Notes;
			c.Editorid = Editorid;
			c.Createuser = Createuser;
			c.Createdate = Createdate;
			c.Rescode = Rescode;
			c.Lastupdate = Lastupdate;
			c.Accrights = Accrights;
			c.Keyw = Keyw;
			c.Title = Title;
			c.DeprecationCalcMethod = DeprecationCalcMethod;
			c.InitAquasitionPrice = InitAquasitionPrice;
			c.SalvageValue = SalvageValue;
			c.InterestRate = InterestRate;
			c.DepreciationYears = DepreciationYears;
			c.OccupationHoursPerMonth = OccupationHoursPerMonth;
			c.OccupationalFactor = OccupationalFactor;
			c.Virtual = Virtual;
			c.Predicted = Predicted;
			c.Conceptual = Conceptual;
			c.Tchtype = Tchtype;
			c.Tval = Tval;
			c.Tunit = Tunit;
			c.Tcolor = Tcolor;
			c.Tregtype = Tregtype;
			c.Trids = Trids;
			c.Trdate = Trdate;
			c.Extracode1 = Extracode1;
			c.Extracode2 = Extracode2;
			c.Extracode3 = Extracode3;
			c.Extracode4 = Extracode4;
			c.Extracode5 = Extracode5;
			c.Extracode6 = Extracode6;
			c.Extracode7 = Extracode7;
			c.Extracode8 = Extracode8;
			c.Extracode9 = Extracode9;
			c.Extracode10 = Extracode10;
			c.Overtype = Overtype;
			c.AssemblyEquipment = AssemblyEquipment;

			return c;
		}
	}
}
