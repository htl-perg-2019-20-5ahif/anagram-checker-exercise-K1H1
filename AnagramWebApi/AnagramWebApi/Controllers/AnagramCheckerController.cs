using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AnagramLibrary;




namespace AnagramWebApi.Controllers
{
	[ApiController]
	[Route("api")]
	public class AnagramCheckerController : ControllerBase
	{

		public ILogger<AnagramCheckerController> logger;

		public AnagramCheckerController(ILogger<AnagramCheckerController> logger)
		{
			this.logger = logger;
		}

		/// <summary>
		/// Checks if two words are an anagram
		/// </summary>
		/// <param name="words"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("checkAnagram")]
		public IActionResult CheckWords([FromBody]Words words)
		{
			var anagramChecker = new AnagramLibrary.Checker();
			if (anagramChecker.IsAnagram(words.w1, words.w2))
			{
				return Ok(words.w1 + " and " + words.w2 + " are anagrams.");
			}
			else
			{
				return BadRequest(words.w1 + " and " + words.w2 + " are not anagrams.");
			}
		}


		/// <summary>
		/// Checks if the word in the parameter is a known anagram
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("getKnownWords")]
		public IActionResult GetKnownWords([FromQuery] string w)
		{
			IConfiguration config = new ConfigurationBuilder().AddJsonFile("config.json").Build();
			var checker = new Checker();
			var reader = new Reader(config);


			string dictText = reader.ReadDictionary();

			IEnumerable<string> words = checker.GetKnownAnagrams(dictText, w);

			if (words.Count() == 0)
			{
				logger.LogError("No known anagrams found.");
				return NotFound("No known anagrams.");
			}

			logger.LogInformation("Some anagrams were found: ");
			return Ok(words);

		}
	}


}
