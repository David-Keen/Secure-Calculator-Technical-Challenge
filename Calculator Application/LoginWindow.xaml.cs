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

            try
            {
                Database.IUser user = database.GetUser(int.Parse(username));

                if (user == null)
                {
                    throw new Exception("User does not exist");
                }

                string databasePassword = user.GetPasswordHash();
                var password = new Login_System.Security.MD5HashedPassword(PasswordInput.Password);

                if (password.MatchesHash(databasePassword))
                {
                    var calculator = new MainWindow();
                    calculator.Show();
                    this.Close();
                    return;
                }
                throw new Exception("Passwords do not match");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter your user id");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
