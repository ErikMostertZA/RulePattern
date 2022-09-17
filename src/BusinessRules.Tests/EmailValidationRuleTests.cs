using BusinessRules.Entities;
using BusinessRules.Rules.AccountRules;

namespace BusinessRules.Tests
{
  [TestFixture]
  public class EmailValidationRuleTests
  {

    [Test]
    public void IsAccountValidForSave_EmailIsNull_ShouldReturnFalse()
    {
      // ARRANGE
      var account = new Account("name", null, DateTime.Now.AddYears(-18));

      // ACT
      var rule = new EmailAddressValidationRule();
      var result = rule.IsAccountValidForSave(account);

      // ASSERT
      Assert.That(result, Is.False);
    }

    [Test]
    public void IsAccountValidForSave_EmailIsEmptyString_ShouldReturnFalse()
    {
      // ARRANGE
      var account = new Account("name", string.Empty, DateTime.Now.AddYears(-18));

      // ACT
      var rule = new EmailAddressValidationRule();
      var result = rule.IsAccountValidForSave(account);

      // ASSERT
      Assert.That(result, Is.False);
    }

    [Test]
    public void IsAccountValidForSave_EmailHasNoRecipient_ShouldReturnFalse()
    {
      // ARRANGE
      var account = new Account("name", "@somedomain.com", DateTime.Now.AddYears(-18));

      // ACT
      var rule = new EmailAddressValidationRule();
      var result = rule.IsAccountValidForSave(account);

      // ASSERT
      Assert.That(result, Is.False);
    }

    [Test]
    public void IsAccountValidForSave_EmailHasNoDomain_ShouldReturnFalse()
    {
      // ARRANGE
      var account = new Account("name", "user@.com", DateTime.Now.AddYears(-18));

      // ACT
      var rule = new EmailAddressValidationRule();
      var result = rule.IsAccountValidForSave(account);

      // ASSERT
      Assert.That(result, Is.False);
    }
    

    [Test]
    public void IsAccountValidForSave_EmailHasNoTopLevelDomain_ShouldReturnFalse()
    {
      // ARRANGE
      var account = new Account("name", "user@domain", DateTime.Now.AddYears(-18));

      // ACT
      var rule = new EmailAddressValidationRule();
      var result = rule.IsAccountValidForSave(account);

      // ASSERT
      Assert.That(result, Is.False);
    }

    [Test]
    public void IsAccountValidForSave_EmailIsValid_ShouldReturnTrue()
    {
      // ARRANGE
      var account = new Account("name", "user@domain.com", DateTime.Now.AddYears(-18));

      // ACT
      var rule = new EmailAddressValidationRule();
      var result = rule.IsAccountValidForSave(account);

      // ASSERT
      Assert.That(result, Is.True);
    }
  }
}
