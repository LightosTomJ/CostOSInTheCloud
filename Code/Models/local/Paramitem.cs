
namespace Models.local
{
	public class Paramitem : BaseClass.Paramitem//, Interfaces.IParamitem
	{
		public Paramitem Clone()
		{
			Paramitem c = new Paramitem();
			c.Paramitemid = Paramitemid;
			c.Samplerate = Samplerate;
			c.Icon = Icon;
			c.Cmodel = Cmodel;
			c.Groupname = Groupname;
			c.Totalcost = Totalcost;
			c.Qty = Qty;
			c.Multunitqty = Multunitqty;
			c.Variable = Variable;
			c.Description = Description;
			c.Accrights = Accrights;
			c.Keyw = Keyw;
			c.Rescode = Rescode;
			c.Titleequ = Titleequ;
			c.Groupidentity = Groupidentity;
			c.Title = Title;
			c.Unit = Unit;
			c.Groupcode = Groupcode;
			c.Gekcode = Gekcode;
			c.Editorid = Editorid;
			c.Notes = Notes;
			c.Lastupdate = Lastupdate;
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
			c.Wbs = Wbs;
			c.Wbs2 = Wbs2;
			c.Loc = Loc;
			c.Pswd = Pswd;
			c.Snum = Snum;
			c.Prttype = Prttype;
			c.Createuserid = Createuserid;
			c.Createdate = Createdate;
			c.Paraminput = Paraminput;
			c.Paramoutput = Paramoutput;
			c.Paramreturn = Paramreturn;

			return c;
		}
	}
}
