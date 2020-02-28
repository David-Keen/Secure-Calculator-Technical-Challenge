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
        private string userInput = "0";

        private double lhs = 0;
        private double rhs = 0;

        private bool isCurrentlyLhs = true;

        private Operation currentOpperation = Operation.None;


        private bool clearFullFormula = false;

        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("Hello");
        }

        private void NumberClicked(object sender, RoutedEventArgs e)
        {
            clearFullFormula = false;
            if ((!isCurrentlyLhs || rhs != 0) && currentOpperation == Operation.None)
            {
                isCurrentlyLhs = true;
                userInput = "0";
                ClearButton.Content = "AC";
            }
            processNumberClicked(((Button)sender).Content.ToString());
            Display.Content = userInput;
        }

        private void OperationClicked(object sender, RoutedEventArgs e)
        {
            var previousOperation = currentOpperation;
            if (!isStringADouble(userInput)) return;
            Button operationalButton = (Button)sender;
            switch (operationalButton.Content.ToString())
            {
                case "+": setOperation(Operation.Addition); break;
                case "_": setOperation(Operation.Subtraction); break;
                case "X": setOperation(Operation.Multiplication); break;
                case "/": setOperation(Operation.Division); break;
            }

            if (isCurrentlyLhs)
            {
                lhs = Convert.ToDouble(userInput);
                isCurrentlyLhs = false;
            }
            else
            {
                var newOperation = currentOpperation;
                currentOpperation = previousOperation;
                rhs = Convert.ToDouble(userInput);
                ProcessEquals();
                currentOpperation = newOperation;
            }
            userInput = "0";
        }

        private void ClearClicked(object sender, RoutedEventArgs e)
        {
            if (clearFullFormula)
            {
                ClearFormula();
                ClearButton.Content = "AC";
            }
            else
            {
                ClearDisplay();
                ClearButton.Content = "C";
            }
            clearFullFormula = !clearFullFormula;
        }

        void processNumberClicked(string givenInput)
        {
            if (givenInput == "." && userInput.Contains(".")) return;
            if (userInput == "0" && givenInput == "0") return;
            if (userInput == "0")
            {
                userInput = "";
            }
            userInput += givenInput;
        }

        void EqualsClicked(object sender, RoutedEventArgs e)
        {
            ProcessEquals();
            isCurrentlyLhs = true;
        }

        void ProcessEquals()
        {
            if (!isStringADouble(userInput)) return;
            rhs = Convert.ToDouble(userInput);
            double sum = calculate(lhs, rhs, currentOpperation);
            Display.Content = sum.ToString();
            lhs = sum;
            isCurrentlyLhs = false;
            currentOpperation = Operation.None;
            userInput = sum.ToString();
            clearFullFormula = true;
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
            if (userInput == "" || !isStringADouble(userInput)) return;
            currentOpperation = operation;
        }

        private bool isStringADouble(String str)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"/[^\d\.]/");
            var matches = regex.Match(userInput);
            return matches.Length == 0;
        }

        private void ClearDisplay()
        {
            Display.Content = "0";
            userInput = "0";
        }

        private void ClearFormula()
        {
            isCurrentlyLhs = true;
            ClearDisplay();
            currentOpperation = Operation.None;
        }
    }
}
