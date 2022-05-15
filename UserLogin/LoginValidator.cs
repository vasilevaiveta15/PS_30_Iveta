using System;

namespace UserLogin
{
    public class LoginValidator
    {

        private readonly string? _userName;
        private readonly string? _password;
        private static string? ErrorMessage;
        public static User? User;
        private readonly ActionOnError _errorAction;

        public delegate void ActionOnError(string errorMsg);

        public LoginValidator(string? userName, string? password, ActionOnError errorAction)
        {
            _userName = userName;
            _password = password;
            _errorAction = errorAction;
        }

        public static UserRoles CurrentUserRole { get; set; }
        
        public bool ValidateUserInput(ref User user)
        {
            if (_userName == null || _userName.Equals(string.Empty) || _userName.Length < 5)
            {
                CurrentUserRole = UserRoles.Anonymous;
                ErrorMessage = "Invalid username.";
                _errorAction(ErrorMessage);
                return false;
            }

            if (_password == null || _password.Equals(string.Empty) || _password.Length < 5)
            {
                CurrentUserRole = UserRoles.Anonymous;
                ErrorMessage = "Invalid password.";
                _errorAction(ErrorMessage);
                return false;
            }
            User = user = UserData.IsUserPassCorrect(_userName, _password);
            if (user == null)
            {
                CurrentUserRole = UserRoles.Anonymous;
                ErrorMessage = "Invalid username/password.";
                _errorAction(ErrorMessage);
                return false;
            }
            CurrentUserRole = user.Role;
            Logger.LogActivity("Successful login");
            return true;
        }

    }
}