namespace DSA.Graph.UnionFind;

internal class _547_Number_of_Provinces
{
    public int FindCircleNum(int[][] isConnected)
    {
        var unionFind = new UnionFind(isConnected.Length);
        for (int i = 0; i < isConnected.Length; i += 1)
        {
            for (int j = 0; j < isConnected[i].Length; j += 1)
            {
                if (isConnected[i][j] == 1)
                {
                    unionFind.Union(i, j);
                }
            }
        }

        return unionFind.Count;
    }
}
