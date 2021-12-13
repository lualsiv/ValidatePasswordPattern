using System;
namespace ValidatePasswordPattern.Api.Models
{
    public class UserModel
    {
        public string User { get; set; }

        [Password(SpecialCharactereRequired = true, StrongPasswordRequired = true, PasswordMinLength = 9)]
        public string Password { get; set; }
    }
}

