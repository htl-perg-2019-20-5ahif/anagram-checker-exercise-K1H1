using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace AnagramLibrary


{
	public class Checker : IChecker
	{
		
		public Checker()
		{

		}


		/// <summary>
		/// Checks wether it is possible that the two words are an anagram or not
		/// </summary>
		/// <returns>Returns if the words are anagrams or not</returns>
		public bool IsAnagram(string w1, string w2)
		{
			
			string ww1 = String.Concat(w1.OrderBy(c => c));
			string ww2 = String.Concat(w2.OrderBy(c => c));

			if (ww1 == ww2)
			{
				return true;
			}
			else
			{
				return false;
			}	
		}


		/// <summary>
		/// Checks if the given word is in the anagram dictionary
		/// </summary>
		/// <param name="dictname"></param>
		/// <param name="word"></param>
		public List<String> GetKnownAnagrams(string dicttext, string word)
		{
			List<string> knownWords = new List<string>();

			var dictWords = dicttext.Replace("\r", "").Split('\n');
			for (int i = 0; i < dictWords.Length; i++)
			{
				if (IsAnagram(dictWords[i], word) && dictWords[i] != word )
				{
					knownWords.Add(dictWords[i]);
				}
			}
			return knownWords;
		}
	}
}
