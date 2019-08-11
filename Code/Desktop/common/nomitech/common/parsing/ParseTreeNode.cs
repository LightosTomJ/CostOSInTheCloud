using System;

namespace Desktop.common.nomitech.common.parsing
{
	public class ParseTreeNode
	{
	  internal string value;

	  private int id;

	  private bool isTerminal;

	  private ParseTreeNode right;

	  private ParseTreeNode left;

	  public ParseTreeNode()
	  {
	  }

	  public virtual int Id
	  {
		  get
		  {
			  return this.id;
		  }
		  set
		  {
			  this.id = value;
		  }
	  }


	  public ParseTreeNode(string paramString, ParseTreeNode paramParseTreeNode1, ParseTreeNode paramParseTreeNode2)
	  {
		this.value = paramString;
		this.left = paramParseTreeNode1;
		this.right = paramParseTreeNode2;
	  }

	  public virtual bool Terminal
	  {
		  get
		  {
			  return this.isTerminal;
		  }
		  set
		  {
			  this.isTerminal = value;
		  }
	  }


	  public virtual string Value
	  {
		  get
		  {
			  return this.value;
		  }
		  set
		  {
			  this.value = value;
		  }
	  }


	  public virtual ParseTreeNode Right
	  {
		  get
		  {
			  return this.right;
		  }
		  set
		  {
			  this.right = value;
		  }
	  }


	  public virtual ParseTreeNode Left
	  {
		  get
		  {
			  return this.left;
		  }
		  set
		  {
			  this.left = value;
		  }
	  }


	  public static ParseTreeNode internalFindNode(ParseTreeNode paramParseTreeNode1, ParseTreeNode paramParseTreeNode2)
	  {
		if (paramParseTreeNode2 == null)
		{
		  return null;
		}
		if (paramParseTreeNode1.Id == paramParseTreeNode2.Id)
		{
		  return paramParseTreeNode1;
		}
		ParseTreeNode parseTreeNode = internalFindNode(paramParseTreeNode1, paramParseTreeNode2.Left);
		return (parseTreeNode != null) ? parseTreeNode : internalFindNode(paramParseTreeNode1, paramParseTreeNode2.Right);
	  }

	  public static ParseTreeNode internalFindNodeParent(ParseTreeNode paramParseTreeNode1, ParseTreeNode paramParseTreeNode2, ParseTreeNode paramParseTreeNode3)
	  {
		if (paramParseTreeNode3 == null)
		{
		  return null;
		}
		if (paramParseTreeNode1.Id == paramParseTreeNode3.Id)
		{
		  return paramParseTreeNode2;
		}
		ParseTreeNode parseTreeNode = (paramParseTreeNode2 = paramParseTreeNode3).internalFindNodeParent(paramParseTreeNode1, paramParseTreeNode2, paramParseTreeNode3.Left);
		return (parseTreeNode != null) ? parseTreeNode : internalFindNodeParent(paramParseTreeNode1, paramParseTreeNode2, paramParseTreeNode3.Right);
	  }

	  public static void printPreorder(ParseTreeNode paramParseTreeNode)
	  {
		if (paramParseTreeNode == null)
		{
		  return;
		}
		if (!string.ReferenceEquals(paramParseTreeNode.Value, null))
		{
		  Console.WriteLine(paramParseTreeNode.Value);
		}
		else
		{
		  Console.WriteLine("NULL");
		}
		printPreorder(paramParseTreeNode.Left);
		printPreorder(paramParseTreeNode.Right);
	  }

	  public static void printPostOrder(ParseTreeNode paramParseTreeNode)
	  {
		if (paramParseTreeNode == null)
		{
		  return;
		}
		printPostOrder(paramParseTreeNode.Left);
		if (!string.ReferenceEquals(paramParseTreeNode.Value, null))
		{
		  Console.WriteLine(paramParseTreeNode.Value);
		}
		else
		{
		  Console.WriteLine("NULL");
		}
		printPostOrder(paramParseTreeNode.Right);
	  }

	  public static void printInOrder(ParseTreeNode paramParseTreeNode)
	  {
		if (paramParseTreeNode == null)
		{
		  return;
		}
		printPreorder(paramParseTreeNode.Left);
		printPreorder(paramParseTreeNode.Right);
		if (!string.ReferenceEquals(paramParseTreeNode.Value, null))
		{
		  Console.WriteLine(paramParseTreeNode.Value);
		}
		else
		{
		  Console.WriteLine("NULL");
		}
	  }

	  public static ParseTreeNode createLeftChild(ParseTreeNode paramParseTreeNode, int paramInt)
	  {
		paramInt++;
		ParseTreeNode parseTreeNode = new ParseTreeNode();
		parseTreeNode.Id = paramInt;
		paramParseTreeNode.Left = parseTreeNode;
		return parseTreeNode;
	  }

	  public static ParseTreeNode createRightChild(ParseTreeNode paramParseTreeNode, int paramInt)
	  {
		paramInt++;
		ParseTreeNode parseTreeNode = new ParseTreeNode();
		parseTreeNode.Id = paramInt;
		paramParseTreeNode.Right = parseTreeNode;
		return parseTreeNode;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\parsing\ParseTreeNode.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}