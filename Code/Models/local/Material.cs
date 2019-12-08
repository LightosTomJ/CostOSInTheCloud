
namespace Models.local
{
	public class Material : BaseClass.Material//, Interfaces.IMaterial
	{
		public Material Clone()
		{
			Material c = new Material();
			c.Materialid = Materialid;
			c.Accuracy = Accuracy;
			c.Description = Description;
			c.Virtual = Virtual;
			c.Predicted = Predicted;
			c.Tchtype = Tchtype;
			c.Tval = Tval;
			c.Tunit = Tunit;
			c.Tcolor = Tcolor;
			c.Tregtype = Tregtype;
			c.Trids = Trids;
			c.Trdate = Trdate;
			c.Conceptual = Conceptual;
			c.Bimmaterial = Bimmaterial;
			c.Bimtype = Bimtype;
			c.Country = Country;
			c.Rawmat = Rawmat;
			c.Reliance = Reliance;
			c.Rawmat2 = Rawmat2;
			c.Reliance2 = Reliance2;
			c.Rawmat3 = Rawmat3;
			c.Reliance3 = Reliance3;
			c.Rawmat4 = Rawmat4;
			c.Reliance4 = Reliance4;
			c.Rawmat5 = Rawmat5;
			c.Reliance5 = Reliance5;
			c.Unit = Unit;
			c.Rate = Rate;
			c.Shiprate = Shiprate;
			c.Fabrate = Fabrate;
			c.Totalrate = Totalrate;
			c.Inclusion = Inclusion;
			c.Distance = Distance;
			c.Distunit = Distunit;
			c.Groupcode = Groupcode;
			c.Gekcode = Gekcode;
			c.Project = Project;
			c.Notes = Notes;
			c.Editorid = Editorid;
			c.Stateprovince = Stateprovince;
			c.Createuser = Createuser;
			c.Createdate = Createdate;
			c.Lastupdate = Lastupdate;
			c.Accrights = Accrights;
			c.Keyw = Keyw;
			c.Rescode = Rescode;
			c.Title = Title;
			c.Suppliername = Suppliername;
			c.Currency = Currency;
			c.Weight = Weight;
			c.Weightunit = Weightunit;
			c.Volflow = Volflow;
			c.Msflow = Msflow;
			c.Duty = Duty;
			c.Opres = Opres;
			c.Optmp = Optmp;
			c.Vlflowut = Vlflowut;
			c.Msflowut = Msflowut;
			c.Dutyut = Dutyut;
			c.Optemput = Optemput;
			c.Opresut = Opresut;
			c.Qty = Qty;
			c.Supplierid = Supplierid;
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
			c.Supplier = Supplier;
			c.AssemblyMaterial = AssemblyMaterial;

			return c;
		}
	}
}
