using System;
using Microsoft.AspNetCore.Identity;
namespace console_auth
{
  class Program
  {
    static void Main(string[] args)
    {
      PasswordHasher<UserModel> hasher = new PasswordHasher<UserModel>();
      var user = new UserModel
      {
        FirstName = "Chase",
        LastName = "Lirette",
        UserName = "chaselirette"
      };

      Console.WriteLine("Set your password");
      user.PlainTextPassword = Console.ReadLine();
      user.HashedPassword = hasher.HashPassword(user, user.PlainTextPassword);

      Console.WriteLine($"Password is {user.PlainTextPassword} and hash {user.HashedPassword}");

      Console.WriteLine("What is your password?");
      var password1 = Console.ReadLine();

      var isMatch = hasher.VerifyHashedPassword(user, user.HashedPassword, password1);
      var result = isMatch.ToString() == "Success" ? "Access granted" : "Access denied";
      Console.WriteLine(result);
    }
  }

  class UserModel
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string PlainTextPassword { get; set; }
    public string HashedPassword { get; set; }
  }
}
