using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.Graph.DFS;

public class _733_Flood_Fill
{
    private int[] _rowDir = [-1, 0, 1, 0];
    private int[] _colDir = [0, 1, 0, -1];
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        int originalColor = image[sr][sc];

        HashSet<(int row, int col)> visited = [];

        DFS(image, sr, sc, originalColor, color, visited);

        return image;
    }

    private void DFS(int[][] image, int row, int col, int originalColor, int color, HashSet<(int row, int col)> visited)
    {
        if (row < 0 || row > image.Length - 1)
        {
            return;
        }

        if (col < 0 || col > image[row].Length - 1)
        {
            return;
        }

        if (!visited.Add((row, col)))
        {
            return;
        }

        if (image[row][col] != originalColor)
        {
            return;
        }

        image[row][col] = color;

        for (int i = 0; i < 4; i += 1)
        {
            int nr = row + _rowDir[i];
            int nc = col + _colDir[i];

            DFS(image, nr, nc, originalColor, color, visited);
        }
    }

}
