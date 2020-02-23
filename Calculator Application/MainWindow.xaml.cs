using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        enum Operation
        {
            None,
            Addition,
            Subtraction,
            Division,
            Multiplication
        }

        private string userInput = "";
        private double lhs = 0;

        private Operation currentOpperation = Operation.None;

        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("Hello");
        }

        private void NumberClicked(object sender, RoutedEventArgs e)
        {
            processNumberClicked(((Button)sender).Content.ToString());
        }

        private void OperationClicked(object sender, RoutedEventArgs e)
        {
            Button operationalButton = (Button)sender;
            switch (operationalButton.Content.ToString())
            {
                case "+": setOperation(Operation.Addition); break;
                case "_": setOperation(Operation.Subtraction); break;
                case "X": setOperation(Operation.Multiplication); break;
                case "/": setOperation(Operation.Division); break;
            }
        }

        void processNumberClicked(string givenInput)
        {
            if (givenInput == "." && userInput.Contains(".")) return;
            if (userInput != "0")
            {
                userInput += givenInput;
            }
            else if (userInput == "0" || userInput == "")
            {
                userInput += givenInput;
            }

            Display.Content = userInput;
        }

        void setOperation(Operation operation)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"/[^\d\.]/");
            var matches = regex.Match(userInput);
            if (matches.Length > 0) return;
            currentOpperation = operation;
            lhs = Convert.ToDouble(userInput);
            userInput = "";
            Display.Content = "0";
        }
    }
}
