using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramLibrary
{
	interface IChecker
	{

		void sortLetters(String w1, String w2);
		bool IsAnagram();

	}
}
