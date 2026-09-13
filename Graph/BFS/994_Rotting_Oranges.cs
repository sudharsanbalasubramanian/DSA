namespace DSA.Graph.BFS;

internal class _994_Rotting_Oranges
{
    public static int OrangesRotting(int[][] grid)
    {
        Queue<(int, int)> queue = [];
        HashSet<(int, int)> visited = [];

        int m = grid.Length;
        int n = grid[0].Length;

        int freshOrange = 0;
        for (int i = 0; i < m; i += 1)
        {
            for (int j = 0; j < n; j += 1)
            {
                if (grid[i][j] == 1)
                {
                    freshOrange += 1;
                }
                else if (grid[i][j] == 2)
                {
                    queue.Enqueue((i, j));
                    visited.Add((i, j));
                }
            }
        }


        int[] rowDir = [-1, 0, 1, 0];
        int[] colDir = [0, 1, 0, -1];

        int time = 0;

        while (queue.Count > 0)
        {
            int size = queue.Count;

            bool isAnyOrangeRotted = false;

            for (int i = 0; i < size; i += 1)
            {
                var (row, col) = queue.Dequeue();

                for (int j = 0; j < 4; j += 1)
                {
                    int nr = row + rowDir[j];
                    int nc = col + colDir[j];

                    if (nr < 0 || nr > grid.Length - 1)
                    {
                        continue;
                    }

                    if (nc < 0 || nc > grid[nr].Length - 1)
                    {
                        continue;
                    }

                    if (grid[nr][nc] != 1)
                    {
                        continue;
                    }

                    if (!visited.Add((nr, nc)))
                    {
                        continue;
                    }

                    queue.Enqueue((nr, nc));
                    freshOrange -= 1;
                    isAnyOrangeRotted = true;
                }
            }

            if (isAnyOrangeRotted)
            {
                time += 1;
            }
        }

        return freshOrange == 0 ? time : -1;
    }
}
