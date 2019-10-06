using System;

namespace AnagramConsole
{
	class Checker
	{
		static void Main(string[] args)
		{
			if (args.Length == 3)
			{
				var checker = new  AnagramLibrary.Checker(args[1], args[2]);
				if (checker.IsAnagram())
				{
					Console.WriteLine(args[1] + " and " + args[2] + " are anagrams.");
				}
				else
				{
					Console.WriteLine(args[1] + " and " + args[2] + " are not anagrams.");
				}
			}
		}
	}
}
