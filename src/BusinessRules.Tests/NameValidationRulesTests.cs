using BusinessRules.Entities;
using BusinessRules.Rules.AccountRules;

namespace BusinessRules.Tests
{
  [TestFixture]
  public class NameValidationRulesTests
  {

    [Test]
    public void IsAccountValidForSave_NameIsEmpty_ShouldReturnFalse()
    {
      // ARRANGE
      var account = new Account("", "test@test.com", DateTime.Now.AddYears(-18));

      // ACT
      var rule = new NameValidationRule();
      var result = rule.IsAccountValidForSave(account);

      // ASSERT
      Assert.That(result, Is.False);
    }

    [Test]
    public void IsAccountValidForSave_NameIsTooShort_ShouldReturnFalse()
    {
      // ARRANGE
      var account = new Account("12", "test@test.com", DateTime.Now.AddYears(-18));

      // ACT
      var rule = new NameValidationRule();
      var result = rule.IsAccountValidForSave(account);

      // ASSERT
      Assert.That(result, Is.False);
    }

    [Test]
    public void IsAccountValidForSave_NameIsTooLong_ShouldReturnFalse()
    {
      // ARRANGE
      var account = new Account("12345678901", "test@test.com", DateTime.Now.AddYears(-18));

      // ACT
      var rule = new NameValidationRule();
      var result = rule.IsAccountValidForSave(account);

      // ASSERT
      Assert.That(result, Is.False);
    }

    [Test]
    public void IsAccountValidForSave_NameIsValid_ShouldReturnTrue()
    {
      // ARRANGE
      var account = new Account("Joe", "test@test.com", DateTime.Now.AddYears(-18));

      // ACT
      var rule = new NameValidationRule();
      var result = rule.IsAccountValidForSave(account);

      // ASSERT
      Assert.That(result, Is.True);
    }
  }
}
