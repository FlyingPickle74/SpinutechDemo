using Microsoft.AspNetCore.Mvc;
using SpinutechDemo.Models;

namespace SpinutechDemo.Controllers
{
	public class DemosController : Controller
	{
		public const string ControllerName = "Demos";

		#region Palindrome

		/// <summary>
		/// Palindrome view page.
		/// </summary>
		/// <returns>View</returns>
		public IActionResult Palindrome()
		{
			return View();
		}

		/// <summary>
		/// Palindrome view page.
		/// </summary>
		/// <param name="palindromeModel"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Palindrome(PalindromeModel palindromeModel)
		{
			PalindromeResultModel palindromeResultModel = new(palindromeModel.ValueToCheck);

			return View(palindromeResultModel);
		}

		#endregion
	}
}
