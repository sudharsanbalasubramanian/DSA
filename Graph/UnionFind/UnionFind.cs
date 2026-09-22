namespace DSA.Graph.UnionFind;

public class UnionFind
{
    private int[] parent;
    private int[] size;

    public int Count { get; private set; }

    public UnionFind(int n)
    {
        parent = new int[n];
        size = new int[n];

        Count = n;

        for (int i = 0; i < n; i += 1)
        {
            parent[i] = i;
            size[i] = 1;
        }
    }

    public int Find(int x)
    {
        if (parent[x] == x)
        {
            return x;
        }

        parent[x] = Find(parent[x]);

        return parent[x];
    }

    public bool Union(int a, int b)
    {
        int rootA = Find(a);
        int rootB = Find(b);

        if (rootA == rootB)
        {
            return false;
        }

        if (size[rootA] >= size[rootB])
        {
            parent[rootB] = rootA;
            size[rootA] += size[rootB];
        }
        else
        {
            parent[rootA] = rootB;
            size[rootB] += size[rootA];
        }

        Count--;

        return true;
    }
}
