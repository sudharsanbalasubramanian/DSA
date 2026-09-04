using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.BucketSort
{
    internal class _451_Sort_Characters_By_Frequency
    {
        
        public string FrequencySort(string s)
        {
            Dictionary<char, int> frequency = [];

            foreach (char ch in s)
            {
                frequency[ch] = frequency.GetValueOrDefault(ch, 0) + 1;
            }

            // bucket[count] contains characters appearing "count" times
            List<char>[] buckets = new List<char>[s.Length + 1];

            foreach (var (ch, count) in frequency)
            {
                buckets[count] ??= [];
                buckets[count].Add(ch);
            }

            StringBuilder result = new(s.Length);

            // Process frequencies from highest to lowest
            for (int count = s.Length; count >= 1; count--)
            {
                if (buckets[count] == null)
                {
                    continue;
                }

                foreach (char ch in buckets[count])
                {
                    result.Append(ch, count);
                }
            }

            return result.ToString();
        }
    }
}
