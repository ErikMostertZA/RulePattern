using BusinessRules.Entities;

namespace BusinessRules.Rules.AccountRules
{
  public class LegalAgeRule : IAccountValidationRule
  {
    public bool IsAccountValidForSave(Account account)
    {
      return account.Age >= 18;
    }
  }
}
