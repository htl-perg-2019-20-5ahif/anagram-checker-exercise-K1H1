using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnagramLibrary
{
	interface IChecker
	{

		bool IsAnagram(string w1, string w2);

		List<String> GetKnownAnagrams(string dicttext, string word);

	}
}
