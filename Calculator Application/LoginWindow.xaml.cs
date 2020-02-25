using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Calculator_Application
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private Database.IDatabaseContext database = new Database.TestDatabase();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginClicked(object sender, RoutedEventArgs e)
        {
            var username = UsernameInput.Text;

            var firstName = username.Split(" ")[0];
            var lastName = username.Split(" ")[1];
            Database.IUser user = database.GetUser(firstName, lastName);

            if (user == null || user.GetFullName() != username)
            {
                MessageBox.Show("No such user");
                return;
            }

            string databasePassword = user.GetPasswordHash();
            var password = new Login_System.Security.MD5HashedPassword(PasswordInput.Password);

            if (password.MatchesHash(databasePassword))
            {
                var calculator = new MainWindow();
                calculator.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Password does not match");
            }
        }
    }
}
