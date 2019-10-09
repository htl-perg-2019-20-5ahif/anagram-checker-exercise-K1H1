using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramLibrary
{
	public class Reader:IReader1
	{
		readonly IConfiguration config;

		public Reader(IConfiguration config)
		{
			this.config = config;
		}

		/// <summary>
		/// Reads the dictionary-file
		/// </summary>
		/// <returns>Returns the words of the dictionary file.</returns>
		public string ReadDictionary()
		{
			var dictFile = config["DictionaryFileName"];
			var dictText = System.IO.File.ReadAllText(dictFile);
			return dictText;
		}
	}
}
