using BusinessRules.Entities;
using BusinessRules.Rules;
using BusinessRules.Rules.AccountRules;
using Moq;

namespace BusinessRules.Tests
{
  public class AccountEvaluatorTests
  {

    [Test]
    public void CanSaveAccount_AllRulesPassed_ShouldReturnTrue()
    {
      // ARRANGE
      var account = new Account("Test", "test@test.com", DateTime.Now.AddYears(-18));
      
      Mock<IAccountValidationRule> mockedEmailRule = new ();
      mockedEmailRule.Setup(x => x.IsAccountValidForSave(account)).Returns(true);

      Mock<IAccountValidationRule> mockedNameRule = new ();
      mockedNameRule.Setup(x => x.IsAccountValidForSave(account)).Returns(true);

      // ACT
      var evaluator = new AccountEvaluator();
      var result = evaluator.CanSaveAccount(account);

      // ASSERT
      Assert.That(result, Is.True);
    }

    [Test]
    public void CanSaveAccount_AtLeastOneRuleFailed_ShouldReturnFalse()
    {
      // ARRANGE
      var account = new Account("Test", "test@test", DateTime.Now.AddYears(-18));

      Mock<IAccountValidationRule> mockedEmailRule = new();
      mockedEmailRule.Setup(x => x.IsAccountValidForSave(account)).Returns(false);

      Mock<IAccountValidationRule> mockedNameRule = new();
      mockedNameRule.Setup(x => x.IsAccountValidForSave(account)).Returns(true);

      // ACT
      var evaluator = new AccountEvaluator();
      var result = evaluator.CanSaveAccount(account);

      // ASSERT
      Assert.That(result, Is.False);
    }
  }
}