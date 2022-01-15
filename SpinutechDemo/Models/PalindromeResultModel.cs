using SpinutechDemo.Resources;

namespace SpinutechDemo.Models
{
	/// <summary>
	/// Represents the results of testing for a positive whole number which is also a palindrome.
	/// </summary>
	public class PalindromeResultModel
	{
		/// <summary>
		/// The last value used.
		/// </summary>
		public string? LastValue { get; private set; }

		/// <summary>
		/// A string representation of the check to see whether or not this is a positive integer which is also a palindrome.
		/// </summary>
		public string Result { get; private set; }

		/// <summary>
		/// Css class added to the results.
		/// </summary>
		public string CssClass { get; private set; }

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="valueToCheck">The value to be checked.</param>
		public PalindromeResultModel(string? valueToCheck)
		{
			LastValue = valueToCheck;

			PalindromeResult palindromeResult = GetPalindromeResult(valueToCheck);

			Result = GetResultString(palindromeResult);

			CssClass = (palindromeResult == PalindromeResult.Success) ? "success" : "error";
		}

		/// <summary>
		/// Represents the results of palindrome tests.
		/// </summary>
		private enum PalindromeResult
		{
			Success = 0,
			NotInteger,
			NotPositiveInteger,
			NotPalindrome
		}

		/// <summary>
		/// Checks to see if the value passed in is a valid positive integer which is also a palindrome.
		/// </summary>
		/// <param name="valueToCheck">The value to be checked.</param>
		/// <returns>The result of the check.</returns>
		private static PalindromeResult GetPalindromeResult(string? valueToCheck)
		{
			if (string.IsNullOrEmpty(valueToCheck))
			{
				return PalindromeResult.NotInteger;
			}

			string trimmedValueToCheck = valueToCheck.Trim();

			if (!int.TryParse(trimmedValueToCheck, out int parsedNumber))
			{
				return PalindromeResult.NotInteger;
			}

			if (parsedNumber <= 0)
			{
				return PalindromeResult.NotPositiveInteger;
			}

			string reversedValue = new(trimmedValueToCheck.ToCharArray().Reverse().ToArray());

			if (trimmedValueToCheck != reversedValue)
			{
				return PalindromeResult.NotPalindrome;
			}

			return PalindromeResult.Success;
		}

		/// <summary>
		/// Gets an internationalized string explaining the result of the check to see whether or not this is a positive integer which is also a palindrome.
		/// </summary>
		/// <param name="palindromeResult">The results of palindrome tests.</param>
		/// <returns>An internationalized string explaining the result of the check to see whether or not this is a positive integer which is also a palindrome.</returns>
		private static string GetResultString(PalindromeResult palindromeResult)
		{
			return palindromeResult switch
			{
				PalindromeResult.Success => Palindrome.SuccessText,
				PalindromeResult.NotInteger => string.Format(Palindrome.NotIntegerText, Palindrome.ErrorInstructionsText),
				PalindromeResult.NotPositiveInteger => string.Format(Palindrome.NotPositiveIntegerText, Palindrome.ErrorInstructionsText),
				PalindromeResult.NotPalindrome => string.Format(Palindrome.NotPalindromeText, Palindrome.ErrorInstructionsText),
				_ => string.Empty,
			};
		}
	}
}
