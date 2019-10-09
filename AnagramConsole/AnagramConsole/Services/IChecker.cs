using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramConsole
{
	interface IChecker
	{
		void CheckAnagram(string w1, string w2);

		void GetKnownWord(IConfiguration config, string word);
	}
}
