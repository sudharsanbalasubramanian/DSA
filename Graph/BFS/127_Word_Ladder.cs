using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.Graph.BFS;

internal class _127_Word_Ladder
{
    public static int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        HashSet<string> set = [.. wordList];

        if (!set.Contains(endWord))
        {
            return 0;
        }

        Queue<string> queue = [];
        queue.Enqueue(beginWord);

        set.Remove(beginWord);

        int noOfTransformation = 1;

        while (queue.Count > 0)
        {
            int size = queue.Count;

            for (int i = 0; i < size; i += 1)
            {
                string word = queue.Dequeue();

                if (word == endWord)
                {
                    return noOfTransformation;
                }

                for (int j = 0; j < word.Length; j += 1)
                {
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        if (c == word[j])
                        {
                            continue;
                        }

                        char[] cArr = word.ToCharArray();
                        cArr[j] = c;

                        string newStr = new string(cArr);

                        if (!set.Contains(newStr))
                        {
                            continue;
                        }

                        queue.Enqueue(newStr);

                        // Mark visited immediately
                        set.Remove(newStr);
                    }
                }
            }

            noOfTransformation += 1;
        }

        return 0;
    }
}
