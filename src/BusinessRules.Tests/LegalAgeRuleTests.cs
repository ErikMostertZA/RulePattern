using BusinessRules.Entities;
using BusinessRules.Rules.AccountRules;

namespace BusinessRules.Tests
{
  [TestFixture]
  public class LegalAgeRuleTests
  {
    [Test]
    public void IsAccountValidForSave_AgeIsLessThan18_ShouldReturnFalse()
    {
      // ARRANGE
      var account = new Account("name", "email@test.com", DateTime.Now.AddYears(-17));

      // ACT
      var rule = new LegalAgeRule();
      var result = rule.IsAccountValidForSave(account);

      // ASSERT
      Assert.That(result, Is.False);
    }

    [Test]
    public void IsAccountValidForSave_AgeIsEqualTo18_ShouldReturnTrue()
    {

      // ARRANGE
      var account = new Account("name", "email@test.com", DateTime.Now.AddYears(-18));

      // ACT
      var rule = new LegalAgeRule();
      var result = rule.IsAccountValidForSave(account);

      // ASSERT
      Assert.That(result, Is.True);
    }

    [Test]
    public void IsAccountValidForSave_AgeIsMoreThan18_ShouldReturnTrue()
    {

      // ARRANGE
      var account = new Account("name", "email@test.com", DateTime.Now.AddYears(-20));

      // ACT
      var rule = new LegalAgeRule();
      var result = rule.IsAccountValidForSave(account);

      // ASSERT
      Assert.That(result, Is.True);
    }
  }
}
