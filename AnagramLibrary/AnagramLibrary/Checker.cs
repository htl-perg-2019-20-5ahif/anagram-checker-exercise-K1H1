using System;

namespace AnagramLibrary
{
	public class Checker : IChecker
	{
		String w1;
		String w2;
		char[] c1;
		char[] c2;

		public Checker(String w1, String w2)
		{
			this.w1 = w1;
			this.w2 = w2;
		}

		public bool IsAnagram()
		{
			this.sortLetters(w1, w2);
			
			// check if  letters are the same and if an anagram is possible
			for (int i = 0; i < c1.Length; i++)
			{
				if (this.c1[i] != this.c2[i])
				{
					return false;			
				}
				return true;
			}
			
			return true;
		}

		public void sortLetters(String w1, String w2)
		{
			c1 = this.w1.ToCharArray();
			c2 = this.w2.ToCharArray();

			Array.Sort(c1);
			Array.Sort(c2);
		}

	}
}
