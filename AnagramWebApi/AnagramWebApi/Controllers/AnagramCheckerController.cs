using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;



namespace AnagramWebApi.Controllers
{
	[ApiController]
	[Route("api/checkAnagram")]
	public class AnagramCheckerController : ControllerBase
	{
	

		[HttpGet]
		public IActionResult CheckWords([FromBody]Words words)
		{

			// checker from classlibrary:

			var anagramChecker = new AnagramLibrary.Checker(words.w1, words.w2);
			if (anagramChecker.IsAnagram())
			{
				return Ok(words.w1 + " and " + words.w2 + " are anagrams.");
			}
			else
			{
				return BadRequest(words.w1 + " and " + words.w2 + " are not anagrams.");
			}
		}
	}
}
