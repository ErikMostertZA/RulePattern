using BusinessRules.Entities;

namespace BusinessRules
{
  public interface IAccountEvaluator
  {
    bool CanSaveAccount(Account account);
  }
}
