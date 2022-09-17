using BusinessRules.Entities;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BusinessRules.Rules.AccountRules
{
  public class EmailAddressValidationRule : IAccountValidationRule
  {
    public bool IsAccountValidForSave(Account account)
    {
      if (string.IsNullOrEmpty(account.Email) || string.IsNullOrWhiteSpace(account.Email))
        return false;

      return IsValidEmail(account.Email);
    }

    private static bool IsValidEmail(string email)
    {
      if (string.IsNullOrWhiteSpace(email))
        return false;

      try
      {
        // Normalize the domain
        email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                              RegexOptions.None, TimeSpan.FromMilliseconds(200));

        // Examines the domain part of the email and normalizes it.
        static string DomainMapper(Match match)
        {
          // Use IdnMapping class to convert Unicode domain names.
          var idn = new IdnMapping();

          // Pull out and process domain name (throws ArgumentException on invalid)
          string domainName = idn.GetAscii(match.Groups[2].Value);

          return match.Groups[1].Value + domainName;
        }
      }
      catch (RegexMatchTimeoutException)
      {
        return false;
      }
      catch (ArgumentException)
      {
        return false;
      }

      try
      {
        return Regex.IsMatch(email,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
      }
      catch (RegexMatchTimeoutException)
      {
        return false;
      }
    }
  }
}
