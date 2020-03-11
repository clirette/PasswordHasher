using System;
using Microsoft.AspNetCore.Identity;
namespace console_auth
{
  class Program
  {
    static void Main(string[] args)
    {
      PasswordHasher<string> hasher = new PasswordHasher<string>();
      Console.WriteLine("Set your password");
      var password = Console.ReadLine();
      var hashedPassword = hasher.HashPassword("User", password);
      Console.WriteLine($"Password is {password} and hash {hashedPassword}");
      Console.WriteLine("What is your password?");
      var password1 = Console.ReadLine();
      var isMatch = hasher.VerifyHashedPassword("User", hashedPassword, password1);
      var result = isMatch.ToString() == "Success" ? "Access granted" : "Access denied";
      Console.WriteLine(result);
    }
  }
}
