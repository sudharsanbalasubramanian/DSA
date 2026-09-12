using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
//https://leetcode.com/problems/clone-graph/description/
namespace DSA.Graph.DFS;
internal class _133_Clone_Graph
{
    private readonly Dictionary<Node, Node> _map = [];
    public Node CloneGraph(Node node)
    {
        if (node is null)
        {
            return null;
        }

        return DFS(node);
    }

    private Node DFS(Node node)
    {
        if (_map.TryGetValue(node, out Node? value))
        {
            return value;
        }

        var clone = new Node(node.val);

        _map[node] = clone;

        foreach (var neighbors in node.neighbors)
        {
            clone.neighbors.Add(DFS(neighbors));
        }

        return clone;
    }


    internal class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = [];
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = [];
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}
