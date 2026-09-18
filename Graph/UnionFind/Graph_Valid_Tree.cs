using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.Graph.UnionFind;

internal class Graph_Valid_Tree
{
    public bool ValidTree(int n, int[][] edges)
    {
        if (edges.Length != n - 1)
        {
            return false;
        }

        var unionFind = new UnionFind(n);

        for (int i = 0; i < edges.Length; i += 1)
        {
            var node1 = edges[i][0];
            var node2 = edges[i][1];

            if (!unionFind.Union(node1, node2))
            {
                return false;
            }
        }

        return true;
    }
}
