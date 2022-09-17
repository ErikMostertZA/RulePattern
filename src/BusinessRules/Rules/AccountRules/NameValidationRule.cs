using BusinessRules.Entities;

namespace BusinessRules.Rules.AccountRules
{
  public class NameValidationRule : IAccountValidationRule
  {
    public bool IsAccountValidForSave(Account account)
    {
      if (string.IsNullOrEmpty(account.Name) || string.IsNullOrWhiteSpace(account.Name))
        return false;

      if (account.Name.Length < 3 || account.Name.Length > 10)
        return false;

      return true;
    }
  }
}
