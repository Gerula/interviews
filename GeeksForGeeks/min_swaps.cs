// http://qa.geeksforgeeks.org/1666/google-interview-question-minimum-no-of-swaps
//
using System;
using System.Collections.Generic;

static class Program {
	static int MinSwaps(this int[] array, Dictionary<int, int> mapping)
	{
		var positions = new Dictionary<int, int>();
		for (int i = 0; i < array.Length; i++)
		{
			positions[array[i]] = i;
			if (mapping.ContainsKey(array[i]))
			{
				mapping[mapping[array[i]]] = array[i];
			}
		}

		return MinSwapsRecursive(0, array, mapping, positions);
	}

	static int MinSwapsRecursive(int current,
							 	 int[] array, 
								 Dictionary<int, int> mapping, 
								 Dictionary<int, int> positions)
	{
		if (current == array.Length) 
		{
			return 0;
		}
		
		if (mapping[array[current]] == array[current + 1]) 
		{
			return MinSwapsRecursive(current + 2, array, mapping, positions);
		}
		
		int first = array.Length;
		if (positions[mapping[array[current + 1]]] > current) 
		{
			Swap(ref array[current], ref array[positions[mapping[array[current + 1]]]], positions);
			first = 1 + MinSwapsRecursive(current + 2, array, mapping, positions);
			Swap(ref array[current], ref array[positions[mapping[array[current + 1]]]], positions);
		}

		int second = array.Length;
		if (positions[mapping[array[current]]] > current) 
		{
			Swap(ref array[current + 1], ref array[positions[mapping[array[current]]]], positions);
			second = 1 + MinSwapsRecursive(current + 2, array, mapping, positions);
			Swap(ref array[current + 1], ref array[positions[mapping[array[current]]]], positions);
		}

		return Math.Min(first, second);
	}

	static void Swap(ref int a, ref int b, Dictionary<int, int> positions) 
	{
		int c = a;
		a = b;
		b = c;
		c = positions[a];
		positions[a] = positions[b];
		positions[b] = c;
	}

	static void Main()
	{
		Console.WriteLine(new int[] {3, 5, 6, 4, 1, 2}.
									MinSwaps(new Dictionary<int, int>() {{1, 3},
																		 {2, 6},
																		 {4, 5}}));
	}
}
