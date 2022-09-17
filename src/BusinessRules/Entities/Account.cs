namespace BusinessRules.Entities
{
  public class Account : IAggregateRoot
  {
    public Account(string name, string email, DateTime birthday, DateTime? registrationDate = null)
    {
      Name = name;
      Email = email;
      Birthday = birthday;
      RegistrationDate = registrationDate ?? DateTime.Now;

    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public DateTime RegistrationDate { get; private set; }
    public string Email { get; private set; }
    public DateTime Birthday { get; private set; }
    public int Age { get => DateTime.Now.Year - Birthday.Year; }

    public void SetName(string name)
    {
      Name = name;
    }

    public void SetRegistrationDate(DateTime regDate)
    {
      RegistrationDate = regDate;
    }

    public void SetEmail(string email)
    {
      Email = email;
    }

    public void SetBirthDay(DateTime birthDay)
    {
      Birthday = birthDay;
    }
  }
}
