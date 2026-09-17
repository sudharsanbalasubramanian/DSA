namespace DSA.Graph.UnionFind;

internal class _684_Redundant_Connection
{
    public int[] FindRedundantConnection(int[][] edges)
    {
        var unionFind = new UnionFind(edges.Length + 1);

        int[] ans = new int[2];
        for (int i = 0; i < edges.Length; i += 1)
        {
            if (!unionFind.Union(edges[i][0], edges[i][1]))
            {
                ans[0] = edges[i][0];
                ans[1] = edges[i][1];
            }
        }

        return ans;
    }
}
