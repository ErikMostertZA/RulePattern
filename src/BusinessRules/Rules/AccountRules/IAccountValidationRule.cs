using BusinessRules.Entities;

namespace BusinessRules.Rules.AccountRules
{
  public interface IAccountValidationRule
  {
    bool IsAccountValidForSave(Account account);
  }
}
