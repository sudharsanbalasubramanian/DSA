using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.Graph.DFS;
//https://leetcode.com/problems/word-search/description/
internal class _79_Word_Search
{
    private int[] _rowDir = [-1, 0, 1, 0];
    private int[] _colDir = [0, 1, 0, -1];
    public bool Exist(char[][] board, string word)
    {
        int n = board.Length;
        int m = board[0].Length;

        int[,] visited = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (board[i][j] == word[0])
                {
                    if (DFS(board, i, j, 0, word, visited))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private bool DFS(
        char[][] board,
        int row,
        int col,
        int index,
        string word,
        int[,] visited)
    {
        // Boundary
        if (row < 0 || row >= board.Length ||
            col < 0 || col >= board[row].Length)
        {
            return false;
        }

        // Already used
        if (visited[row, col] == 1)
        {
            return false;
        }

        // Character doesn't match
        if (board[row][col] != word[index])
        {
            return false;
        }

        // Last character successfully matched
        if (index == word.Length - 1)
        {
            return true;
        }

        visited[row, col] = 1;

        for (int i = 0; i < 4; i++)
        {
            int nr = row + _rowDir[i];
            int nc = col + _colDir[i];

            if (DFS(board, nr, nc, index + 1, word, visited))
            {
                return true;
            }
        }

        // Backtrack
        visited[row, col] = 0;

        return false;
    }
}

