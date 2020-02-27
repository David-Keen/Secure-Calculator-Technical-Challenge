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

        private SecureCalculator.ICalculator calculator = new SecureCalculator.BasicCalculator();
        private string userInput = "";
        private double lhs = 0;
        private double rhs = double.NaN;

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
            if (!double.IsNaN(this.rhs) && this.currentOpperation == Operation.None)
            {
                this.userInput = "";
            }
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

        void EqualsClicked(object sender, RoutedEventArgs e)
        {
            if (currentOpperation == Operation.None || !isStringADouble(userInput)) return;
            double rhs = Convert.ToDouble(userInput);
            var sum = calculate(lhs, rhs, currentOpperation);

            userInput = sum.ToString();

            if (double.IsNaN(sum) || double.IsInfinity(sum))
            {
                Display.Content = "Error";
                this.rhs = double.NaN;
            }
            else
            {
                this.rhs = rhs;
                Display.Content = userInput.ToString();
            }
            this.currentOpperation = Operation.None;
        }

        private double calculate(double lhs, double rhs, Operation operation)
        {
            switch (operation)
            {
                case Operation.Addition: return calculator.Add(lhs, rhs);
                case Operation.Subtraction: return calculator.Subtract(lhs, rhs);
                case Operation.Multiplication: return calculator.Multiply(lhs, rhs);
                case Operation.Division: return calculator.Divide(lhs, rhs);
                default: throw new Exception("Error");
            }
        }

        void setOperation(Operation operation)
        {
            if (!isStringADouble(userInput)) return;
            currentOpperation = operation;
            lhs = Convert.ToDouble(userInput);
            userInput = "";
            Display.Content = "0";
        }

        private bool isStringADouble(String str)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"/[^\d\.]/");
            var matches = regex.Match(userInput);
            return matches.Length == 0;
        }
    }
}
