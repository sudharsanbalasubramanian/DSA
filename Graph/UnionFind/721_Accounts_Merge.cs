using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.Graph.UnionFind;

internal class _721_Accounts_Merge
{
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
    {
        int n = accounts.Count;

        var uf = new UnionFind(n);
        var emailToAccount = new Dictionary<string, int>();

        // 1. Connect accounts sharing the same email
        for (int account = 0; account < n; account++)
        {
            for (int j = 1; j < accounts[account].Count; j++)
            {
                string email = accounts[account][j];

                if (!emailToAccount.TryAdd(email, account))
                {
                    uf.Union(account, emailToAccount[email]);
                }
            }
        }

        // 2. Group emails by their root account
        var rootToEmails = new Dictionary<int, List<string>>();

        foreach (var (email, account) in emailToAccount)
        {
            int root = uf.Find(account);

            if (!rootToEmails.TryGetValue(root, out var emails))
            {
                emails = [];
                rootToEmails[root] = emails;
            }

            emails.Add(email);
        }

        // 3. Build merged accounts
        var result = new List<IList<string>>();

        foreach (var (root, emails) in rootToEmails)
        {
            emails.Sort(StringComparer.Ordinal);

            var mergedAccount = new List<string>(emails.Count + 1)
            {
                accounts[root][0]
            };

            mergedAccount.AddRange(emails);
            result.Add(mergedAccount);
        }

        return result;
    }
}
