using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.Graph.DFS;

public class _200_Number_of_Islands
{
    private int[] _rowDir = [-1, 0, 1, 0];
    private int[] _colDir = [0, 1, 0, -1];
    public int NumIslands(char[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[][] visited = new int[m][];
        for (int i = 0; i < m; i += 1)
        {
            visited[i] = new int[n];
        }

        int numOfIsland = 0;
        for (int i = 0; i < m; i += 1)
        {
            for (int j = 0; j < n; j += 1)
            {
                if (grid[i][j] == '1' && visited[i][j] == 0)
                {
                    DFS(grid, i, j, visited);
                    numOfIsland += 1;
                }
            }
        }

        return numOfIsland;
    }
    private void DFS(char[][] grid, int row, int col, int[][] visited)
    {
        if (row < 0 || row > grid.Length - 1)
        {
            return;
        }

        if (col < 0 || col > grid[row].Length - 1)
        {
            return;
        }

        if (grid[row][col] != '1')
        {
            return;
        }

        if (visited[row][col] == 1)
        {
            return;
        }

        visited[row][col] = 1;

        for (int i = 0; i < 4; i += 1)
        {
            int nr = row + _rowDir[i];
            int nc = col + _colDir[i];

            DFS(grid, nr, nc, visited);
        }
    }
}
