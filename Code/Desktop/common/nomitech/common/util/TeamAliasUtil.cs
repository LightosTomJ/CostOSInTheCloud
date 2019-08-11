namespace Desktop.common.nomitech.common.util
{
	using TeamAliasTable = nomitech.common.db.local.TeamAliasTable;
	using Query = org.hibernate.Query;
	using Session = org.hibernate.Session;

	public class TeamAliasUtil
	{
	  public static string getAliasForTeam(Session paramSession, string paramString)
	  {
		Query query = paramSession.createQuery("from TeamAliasTable c where c.team like :teamName");
		query.setString("teamName", paramString);
		System.Collections.IList list = query.list();
		return (list.Count > 0) ? ((TeamAliasTable)list[0]).Alias : null;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\TeamAliasUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}