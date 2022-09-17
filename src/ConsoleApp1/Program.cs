using BusinessRules.Entities;
using BusinessRules.Rules;

var accountEvaluator = new AccountEvaluator();

var accounts = new List<Account>
{
  new Account("", "abc@abc.com", DateTime.Now.AddYears(-18)),
  new Account("12", "abc@abc.com", DateTime.Now.AddYears(-18)),
  new Account("12345678901", "abc@abc.com", DateTime.Now.AddYears(-18)),
  new Account("12345", "", DateTime.Now.AddYears(-18)),
  new Account("12345", "abc@aabc", DateTime.Now.AddYears(-18)),
  new Account("12345", "@abc.com", DateTime.Now.AddYears(-18)),
  new Account("12345", "abc@abc.com", DateTime.Now.AddYears(-1)),
  new Account("12345", "abc@abc.com", DateTime.Now.AddYears(-17)),
  // The only account that can be saved
  new Account("12345", "abc@abc.com", DateTime.Now.AddYears(-18))
};

accounts.ForEach(account =>
{
  if (accountEvaluator.CanSaveAccount(account))
    WriteSuccess("Account can be saved");
  else
    WriteError("Account is invalid");
});

static void WriteSuccess(string message)
{
  Console.ForegroundColor = ConsoleColor.Green;
  WriteMessage(message);
}

static void WriteError(string message)
{
  Console.ForegroundColor = ConsoleColor.Red;
  WriteMessage(message);
}

static void WriteMessage(string message)
{
  Console.WriteLine(message);
  Console.ResetColor();
}