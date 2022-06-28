using System;

namespace Candy
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
  }

  public class Solution
  {
    // Time = O(N)
    // Space = O(N)
    public int Candy(int[] r)
    {
      // Do it in two directions.
      // Step 1 - first loop makes sure children with a higher rating get more candy than its left neighbor.
      // Step 2 - second loop makes sure children with a higher rating get more candy than its right neighbor.
      // Step 3 - Finally another loop, now at each position will be taking Max(left[i], right[i])
      int n = r.Length;
      int[] left = new int[n];
      int[] right = new int[n];

      Array.Fill(left, 1);
      Array.Fill(right, 1);
      // Step 1
      for (int i = 1; i < n; i++)
      {
        if (r[i] > r[i - 1])
        {
          left[i] = left[i - 1] + 1;
        }
      }
      // Step 2
      for (int i = n - 2; i >= 0; i--)
      {
        if (r[i] > r[i + 1])
        {
          right[i] = right[i + 1] + 1;
        }
      }

      // Step 3
      int sum = 0;
      for (int i = 0; i < n; i++)
      {
        sum += Math.Max(left[i], right[i]);
      }

      return sum;
    }
  }
}
