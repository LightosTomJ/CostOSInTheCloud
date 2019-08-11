using System.Collections.Generic;

namespace Desktop.common.nomitech.costos.plugin.api
{
	using Expandable = com.jidesoft.grid.Expandable;
	using Node = com.jidesoft.grid.Node;

	public interface ItemRow
	{
	  int? indexOfField(string paramString);

	  object getValueAt(int paramInt);

	  object getValueForField(string paramString);

	  System.Collections.IEnumerator breadthFirstEnumeration();

	  System.Collections.IEnumerator depthFirstEnumeration();

//JAVA TO C# CONVERTER WARNING: Java wildcard generics have no direct equivalent in .NET:
//ORIGINAL LINE: java.util.List<?> getChildren();
	  IList<object> Children {get;}

	  System.Collections.IEnumerator postorderEnumeration();

	  System.Collections.IEnumerator preorderEnumeration();

	  int getAllChildrenCount(bool paramBoolean);

	  int AllVisibleChildrenCount {get;}

	  object getChildAt(int paramInt);

	  int getChildIndex(object paramObject);

	  int ChildrenCount {get;}

	  int NumberOfVisibleChildren {get;}

	  int NumberOfVisibleExpandable {get;}

	  bool hasChildren();

	  bool hasVisibleChildren();

	  bool Expandable {get;}

	  bool Expanded {get;}

	  int Level {get;}

	  Node NextSibling {get;}

	  Expandable Parent {get;}

	  Node PreviousSibling {get;}

	  object Object {get;}
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\ItemRow.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}