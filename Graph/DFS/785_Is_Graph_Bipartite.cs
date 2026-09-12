namespace DSA.Graph.DFS;

internal class _785_Is_Graph_Bipartite
{
    public bool IsBipartite(int[][] graph)
    {
        int[] color = new int[graph.Length];
        Array.Fill(color, -1);

        for (int i = 0; i < graph.Length; i++)
        {
            if (color[i] != -1)
            {
                continue;
            }

            Queue<int> queue = [];
            queue.Enqueue(i);
            color[i] = 0;

            while (queue.Count > 0)
            {
                var size = queue.Count;

                for (int j = 0; j < size; j++)
                {
                    var node = queue.Dequeue();

                    foreach (var neighbor in graph[node])
                    {
                        if (color[neighbor] == -1)
                        {
                            color[neighbor] = 1 - color[node];
                            queue.Enqueue(neighbor);
                        }
                        else if (color[node] == color[neighbor])
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return true;
    }
}
