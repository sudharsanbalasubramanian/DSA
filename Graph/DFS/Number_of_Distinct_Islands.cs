using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.Graph.DFS;

public class Number_of_Distinct_Islands
{
    private readonly int[] _rowDir = [-1, 0, 1, 0];
    private readonly int[] _colDir = [0, 1, 0, -1];
    public int NumDistinctIslands(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        bool[][] visited = new bool[m][];

        for (int i = 0; i < m; i++)
        {
            visited[i] = new bool[n];
        }

        HashSet<string> shapes = [];

        for (int row = 0; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (grid[row][col] == 1 && !visited[row][col])
                {
                    List<(int row, int col)> shape = [];

                    DFS(
                        grid,
                        row,
                        col,
                        row,
                        col,
                        visited,
                        shape
                    );

                    string signature = string.Join(
                        ",",
                        shape.Select(x => $"{x.row}:{x.col}")
                    );

                    shapes.Add(signature);
                }
            }
        }

        return shapes.Count;
    }

    private void DFS(
        int[][] grid,
        int row,
        int col,
        int baseRow,
        int baseCol,
        bool[][] visited,
        List<(int row, int col)> shape)
    {
        if (row < 0 || row >= grid.Length)
        {
            return;
        }

        if (col < 0 || col >= grid[row].Length)
        {
            return;
        }

        if (grid[row][col] == 0)
        {
            return;
        }

        if (visited[row][col])
        {
            return;
        }

        visited[row][col] = true;

        shape.Add((row - baseRow, col - baseCol));

        for (int i = 0; i < 4; i++)
        {
            int nr = row + _rowDir[i];
            int nc = col + _colDir[i];

            DFS(
                grid,
                nr,
                nc,
                baseRow,
                baseCol,
                visited,
                shape
            );
        }
    }
}
