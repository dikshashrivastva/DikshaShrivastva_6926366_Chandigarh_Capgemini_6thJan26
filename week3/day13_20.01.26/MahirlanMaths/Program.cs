namespace MahirlanMaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
			int N = int.Parse(Console.ReadLine());
			Console.WriteLine(MinOperations(N));
		}

		static int MinOperations(int N)
		{
			if (N == 10)
				return 0;

			Queue<(int value, int steps)> q = new Queue<(int, int)>();
			HashSet<int> visited = new HashSet<int>();

			q.Enqueue((10, 0));
			visited.Add(10);

			int limit = Math.Max(N * 3, 50);  // safe upper bound

			while (q.Count > 0)
			{
				var (current, steps) = q.Dequeue();

				int[] nextStates = { current + 2, current - 1, current * 3 };

				foreach (int next in nextStates)
				{
					if (next == N)
						return steps + 1;

					if (next >= 0 && next <= limit && !visited.Contains(next))
					{
						visited.Add(next);
						q.Enqueue((next, steps + 1));
					}
				}
			}

			return -1; // theoretically unreachable
		}
    }
}
