using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;


namespace AnagramConsole
{
	class Checker
	{
		static IConfiguration config = new ConfigurationBuilder().AddJsonFile("config.json").Build();      //binding in the "config.json" file

		static void Main(string[] args)
		{

			if (args.Length != 0)
			{
				switch (args[0])
				{
					case "check":

						if (string.IsNullOrEmpty(args[1]) || string.IsNullOrEmpty(args[2]))
						{
							Console.WriteLine("Please mind the Syntax: AnagramChecker.exe getKnown <word>");
							break;
						}
						else
						{
							CheckAnagram(args[1], args[2]);
						}
						break;


					case "getKnown":
						if (string.IsNullOrEmpty(args[1]))
						{
							Console.WriteLine("Please mind the Syntax: AnagramChecker.exe getKnown <word>");
							break;
						}
						else
						{
							GetKnownWord(args[1]);
						}
						break;

				}
			}

		}

		/// <summary>
		/// Checks if two words are an anagram
		/// </summary>
		/// <param name="w1"></param>
		/// <param name="w2"></param>
		public static void CheckAnagram(string w1, string w2)
		{
			var checker = new AnagramLibrary.Checker();

			if (checker.IsAnagram(w1, w2))
			{
				Console.WriteLine(w1 + " and " + w2 + " are anagrams.");
			}
			else
			{
				Console.WriteLine(w1 + " and " + w2 + " are not anagrams.");
			}

		}


		/// <summary>
		/// Gets the filename and the word to check, it calls a reader- function and checks if the word is known. 
		/// </summary>
		/// <param name="config"></param>
		/// <param name="word"></param>
		public static void GetKnownWord(string word)
		{
			var checker = new AnagramLibrary.Checker();
			var reader = new AnagramLibrary.Reader(config);

			var dictText = reader.ReadDictionary();
			List<string> knownWords = checker.GetKnownAnagrams(dictText, word);

			if (knownWords.Count != 0)
			{
				for (int i = 0; i < knownWords.Count; i++)
				{
					Console.WriteLine(knownWords[i]);

				}
			}
			else
			{
				Console.WriteLine("No known anagrams found.");
			}
		}
	}

}
