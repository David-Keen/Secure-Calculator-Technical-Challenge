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
        private Database.IDatabaseContext database = new Database.ReleaseDatabase();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Login(int.Parse(UsernameInput.Text), PasswordInput.Password);
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

        private void Login(int id, string password)
        {
            var user = this.GetUser(id);
            if (this.IsAuthenticated(user, password))
            {
                this.ShowCalculatorAndCloseCurrentWindow();
                return;
            }
            throw new Exception("Passwords do not match");
        }

        private Database.IUser GetUser(int id)
        {
            Database.IUser user = database.GetUser(id);
            if (user == null) throw new Exception("User does not exist");
            return user;
        }

        private bool IsAuthenticated(Database.IUser user, string password)
        {
            string databasePassword = user.GetPasswordHash();
            var pass = new Security.MD5HashedPassword(password);
            return pass.MatchesHash(databasePassword);
        }

        private void ShowCalculatorAndCloseCurrentWindow()
        {
            var calculatorView = new MainWindow();
            calculatorView.Show();
            this.Close();
        }
    }
}
