using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Desktop.common.nomitech.common.expr.boqitem
{
	using Edge = org.boris.expr.util.Edge;
	using GraphCycleException = org.boris.expr.util.GraphCycleException;
	using GraphTraversalListener = org.boris.expr.util.GraphTraversalListener;

	public class Graph : System.Collections.IEnumerable
	{
	  private bool wantsEdges = true;

	  private ISet<object> nodes = new HashSet<object>();

	  private ISet<object> edges = new HashSet<object>();

	  private System.Collections.IDictionary outbounds = new Hashtable();

	  private System.Collections.IDictionary inbounds = new Hashtable();

	  private System.Collections.IList ordered = null;

	  private ISet<object> traversed = null;

	  public virtual bool IncludeEdges
	  {
		  set
		  {
			  this.wantsEdges = value;
		  }
	  }

	  public virtual void add(object paramObject)
	  {
		  this.nodes.Add(paramObject);
	  }

	  public virtual ISet<object> getInbounds(object paramObject)
	  {
		  return (ISet<object>)this.inbounds[paramObject];
	  }

	  public virtual ISet<object> getOutbounds(object paramObject)
	  {
		  return (ISet<object>)this.outbounds[paramObject];
	  }

	  public virtual void clearOutbounds(object paramObject)
	  {
		ISet<object> set = (ISet<object>)this.outbounds[paramObject];
		if (set != null)
		{
		  System.Collections.IEnumerator iterator = set.GetEnumerator();
		  while (iterator.MoveNext())
		  {
			remove((Edge)iterator.Current);
		  }
		}
	  }

	  public virtual void clearInbounds(object paramObject)
	  {
		ISet<object> set = (ISet<object>)this.inbounds[paramObject];
		if (set != null)
		{
		  System.Collections.IEnumerator iterator = set.GetEnumerator();
		  while (iterator.MoveNext())
		  {
			remove((Edge)iterator.Current);
		  }
		}
	  }

	  public virtual void remove(object paramObject)
	  {
		this.nodes.remove(paramObject);
		clearInbounds(paramObject);
		clearOutbounds(paramObject);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void add(org.boris.expr.util.Edge paramEdge) throws org.boris.expr.util.GraphCycleException
	  public virtual void add(Edge paramEdge)
	  {
		checkCycle(paramEdge);
		this.nodes.Add(paramEdge.source);
		this.nodes.Add(paramEdge.target);
		this.edges.Add(paramEdge);
		ISet<object> set1 = (ISet<object>)this.inbounds[paramEdge.target];
		if (set1 == null)
		{
		  this.inbounds[paramEdge.target] = set1 = new HashSet<object>();
		}
		set1.Add(paramEdge);
		ISet<object> set2 = (ISet<object>)this.outbounds[paramEdge.source];
		if (set2 == null)
		{
		  this.outbounds[paramEdge.source] = set2 = new HashSet<object>();
		}
		set2.Add(paramEdge);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void checkCycle(org.boris.expr.util.Edge paramEdge) throws org.boris.expr.util.GraphCycleException
	  public virtual void checkCycle(Edge paramEdge)
	  {
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void remove(org.boris.expr.util.Edge paramEdge) throws org.boris.expr.util.GraphCycleException
	  public virtual void remove(Edge paramEdge)
	  {
		this.edges.remove(paramEdge);
		ISet<object> set1 = (ISet<object>)this.inbounds[paramEdge.target];
		if (set1 != null)
		{
		  set1.remove(paramEdge);
		}
		ISet<object> set2 = (ISet<object>)this.outbounds[paramEdge.source];
		if (set2 != null)
		{
		  set2.remove(paramEdge);
		}
	  }

	  public virtual void sort()
	  {
		this.ordered = new List<object>();
		this.traversed = new HashSet<object>();
		null = this.nodes.GetEnumerator();
		HashSet<object> hashSet = new HashSet<object>(this.nodes);
		while (null.hasNext())
		{
		  object @object = null.next();
		  ISet<object> set = (ISet<object>)this.inbounds[@object];
		  if (set == null || set.Count == 0)
		  {
			traverse(@object);
			hashSet.remove(@object);
		  }
		}
		foreach (object @object in hashSet)
		{
		  if (!this.traversed.Contains(@object))
		  {
			traverse(@object);
		  }
		}
	  }

	  private void traverse(object paramObject)
	  {
		ISet<object> set1 = (ISet<object>)this.inbounds[paramObject];
		if (set1 != null)
		{
		  foreach (Edge edge in set1)
		  {
			if (!this.traversed.Contains(edge.source))
			{
			  return;
			}
			if (this.wantsEdges)
			{
			  this.ordered.Add(edge);
			}
		  }
		}
		if (!this.traversed.Contains(paramObject))
		{
		  this.traversed.Add(paramObject);
		  this.ordered.Add(paramObject);
		}
		ISet<object> set2 = (ISet<object>)this.outbounds[paramObject];
		if (set2 == null || set2.Count == 0)
		{
		  return;
		}
		HashSet<object> hashSet = new HashSet<object>();
		foreach (Edge edge in set2)
		{
		  if (!this.traversed.Contains(edge) && this.traversed.Contains(edge.target))
		  {
			hashSet.Add(edge.target);
		  }
		}
		System.Collections.IEnumerator iterator = set2.GetEnumerator();
		while (iterator.MoveNext())
		{
		  object @object = ((Edge)iterator.Current).target;
		  if (!hashSet.Contains(@object))
		  {
			traverse(@object);
		  }
		}
	  }

	  public virtual void clear()
	  {
		this.edges.Clear();
		this.inbounds.Clear();
		this.outbounds.Clear();
		this.nodes.Clear();
		this.traversed = null;
		this.ordered.Clear();
	  }

	  public virtual System.Collections.IEnumerator GetEnumerator()
	  {
		if (this.ordered == null)
		{
		  sort();
		}
		return this.ordered.GetEnumerator();
	  }

	  public virtual void traverse(object paramObject, GraphTraversalListener paramGraphTraversalListener)
	  {
		HashSet<object> hashSet1 = new HashSet<object>();
		walk(paramObject, hashSet1);
		HashSet<object> hashSet2 = new HashSet<object>();
		hashSet2.Add(paramObject);
		traverse(paramObject, paramGraphTraversalListener, hashSet2, hashSet1);
	  }

	  private void walk(object paramObject, ISet<object> paramSet)
	  {
		paramSet.Add(paramObject);
		ISet<object> set = (ISet<object>)this.outbounds[paramObject];
		if (set != null)
		{
		  foreach (Edge edge in set)
		  {
			walk(edge.target, paramSet);
		  }
		}
	  }

	  private void traverse(object paramObject, GraphTraversalListener paramGraphTraversalListener, ISet<object> paramSet1, ISet<object> paramSet2)
	  {
		ISet<object> set = (ISet<object>)this.outbounds[paramObject];
		if (set != null)
		{
		  foreach (Edge edge in set)
		  {
			ISet<object> set1 = (ISet<object>)this.inbounds[edge.target];
			System.Collections.IEnumerator iterator = set1.GetEnumerator();
			bool @bool = true;
			while (iterator.MoveNext())
			{
			  Edge edge1 = (Edge)iterator.Current;
			  if (paramSet2.Contains(edge1.source) && !paramSet1.Contains(edge1.source) && !paramObject.Equals(edge1.source))
			  {
				@bool = false;
				break;
			  }
			}
			if (@bool)
			{
			  paramGraphTraversalListener.traverse(edge.target);
			  paramSet1.Add(edge.target);
			  traverse(edge.target, paramGraphTraversalListener, paramSet1, paramSet2);
			}
		  }
		}
	  }

	  public override string ToString()
	  {
		StringBuilder stringBuilder = new StringBuilder();
		System.Collections.IEnumerator iterator = this.edges.GetEnumerator();
		while (iterator.MoveNext())
		{
		  stringBuilder.Append(iterator.Current);
		  stringBuilder.Append("\n");
		}
		return stringBuilder.ToString();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\boqitem\Graph.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}