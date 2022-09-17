using BusinessRules.Entities;
using BusinessRules.Rules.AccountRules;

namespace BusinessRules.Rules
{
  public class AccountEvaluator : IAccountEvaluator
  {
    private readonly List<IAccountValidationRule> _rules = new ();

    public AccountEvaluator()
    {
      _rules.Add(new LegalAgeRule());
      _rules.Add(new NameValidationRule());
      _rules.Add(new EmailAddressValidationRule());
    }

    public bool CanSaveAccount(Account account)
    {
      var validationList = new List<bool>();

      _rules.ForEach(rule =>
      {
        validationList.Add(rule.IsAccountValidForSave(account));
      });

      return !validationList.Any(x => x == false);
    }
  }
}
