using System;
using System.Windows;
using StudentInfoSystem.Model;
using StudentInfoSystem.Utils;
using UserLogin;

namespace StudentInfoSystem.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginDialog : Window
    {
        private readonly LoginAction _loginAction;

        public delegate void LoginAction(Student student);
        public LoginDialog(LoginAction loginAction)
        {
            _loginAction = loginAction;
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            var login = new LoginValidator(Username.Text, Password.Password, msg => { ErrorMessage.Content = msg; });
            var user = new User();
            if (!login.ValidateUserInput(ref user)) return;

            try
            {
                _loginAction(new StudentValidation().GetStudentDataByUser(user));
                Close();
            }
            catch (Exception ex)
            {
                ErrorMessage.Content = ex.Message;
            }
        }
    }
}