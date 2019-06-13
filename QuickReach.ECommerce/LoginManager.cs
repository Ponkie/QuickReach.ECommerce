using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Mail;
namespace QuickReach.ECommerce
{
    public class LoginManager : ILoginManager
    {
        public bool Validate(string username, string password)
        {
            bool validPassword = passwordValidation(password);
            bool validUsername = userNameValidation(username);

            if (!validPassword || !validUsername)
            {
                return false;
            }

            return true;

        }

        private bool userNameValidation(string username)
        {
            if (username.Length < 6)
            {
                return false;
            }
            if (username.Substring(username.Length - 4, 1) != ".")
            {
                return false;
            }
            try
            {
                MailAddress m = new MailAddress(username);
            }
            catch (FormatException)
            {
                return false;
            }

            return true;
        }

        private bool passwordValidation(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            if (password.Length < 8)
            {
                return false;
            }

            var hasSymbol = password.ToCharArray().Any(c => char.IsSymbol(c));

            if (!hasSymbol)
            {
                return false;
            }

            var hasUpper = password.ToCharArray().Any(c => char.IsUpper(c));

            if (!hasUpper)
            {
                return false;
            }

            var hasDigit = password.ToCharArray().Any(c => char.IsDigit(c));

            if (!hasDigit)
            {
                return false;
            }

            return true;
        }
    }

}
