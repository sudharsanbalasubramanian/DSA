namespace DSA.Graph.TopologicalSort;

internal class _210_Course_Schedule_II
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        Dictionary<int, List<int>> graph = [];
        for (int i = 0; i < numCourses; i += 1)
        {
            graph[i] = [];
        }

        int[] inDegree = new int[numCourses];
        for (int i = 0; i < prerequisites.Length; i += 1)
        {
            int prerequisite = prerequisites[i][1];
            int course = prerequisites[i][0];

            graph[prerequisite].Add(course);

            inDegree[course] += 1;
        }

        Queue<int> queue = [];

        for (int i = 0; i < inDegree.Length; i += 1)
        {
            if (inDegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        List<int> order = [];
        while (queue.Count > 0)
        {
            var course = queue.Dequeue();

            order.Add(course);

            foreach (var nextCourse in graph[course])
            {
                inDegree[nextCourse] -= 1;
                if (inDegree[nextCourse] == 0)
                {
                    queue.Enqueue(nextCourse);
                }
            }
        }

        return order.Count == numCourses ? [.. order] : [];
    }
}
