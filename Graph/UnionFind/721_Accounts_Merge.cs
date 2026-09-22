using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.Graph.UnionFind;

internal class _721_Accounts_Merge
{
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
    {
        int n = accounts.Count;

        UnionFind unionFind = new UnionFind(n);

        // email -> account index
        Dictionary<string, int> map = new();

        // Step 1: Union accounts having common emails
        for (int i = 0; i < n; i++)
        {
            for (int j = 1; j < accounts[i].Count; j++)
            {
                string email = accounts[i][j];

                if (map.TryGetValue(email, out int previousIndex))
                {
                    unionFind.Union(previousIndex, i);
                }
                else
                {
                    map[email] = i;
                }
            }
        }

        // root account -> emails
        Dictionary<int, List<string>> groups = new();

        // Step 2: Put every email under its final root
        foreach (var entry in map)
        {
            string email = entry.Key;
            int accountIndex = entry.Value;

            int root = unionFind.Find(accountIndex);

            if (!groups.ContainsKey(root))
            {
                groups[root] = [];
            }

            groups[root].Add(email);
        }

        // Step 3: Sort emails and build answer
        List<IList<string>> result = [];

        foreach (var entry in groups)
        {
            int root = entry.Key;
            List<string> emails = entry.Value;

            emails.Sort(StringComparer.Ordinal);

            List<string> mergedAccount = new();

            // Name
            mergedAccount.Add(accounts[root][0]);

            // Emails
            mergedAccount.AddRange(emails);

            result.Add(mergedAccount);
        }

        return result;
    }
}
