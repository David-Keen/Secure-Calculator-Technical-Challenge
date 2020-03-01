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
using Calculator_Application.Services;

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

        private Services.Calculator.ICalculator calculator = new Services.Calculator.BasicCalculator();
        private string userInput = "0";

        private double lhs = 0;
        private double rhs = 0;
        private Operation currentOpperation = Operation.None;

        private bool processingLhs = true;
        private bool shouldClearFullFormula = false;
        private bool decimalPlaceClicked = false;

        private bool shouldStartProcessingNewSum
        {
            get { return (!processingLhs || rhs != 0) && currentOpperation == Operation.None; }
        }

        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("Hello");
        }

        private void NumberClicked(object sender, RoutedEventArgs e)
        {
            shouldClearFullFormula = false;
            if (shouldStartProcessingNewSum) ClearFormula();
            processNumberClicked(((Button)sender).Content.ToString());
        }

        private void OperationClicked(object sender, RoutedEventArgs e)
        {
            if (!isStringADouble(userInput)) return;

            if (processingLhs)
            {
                lhs = Convert.ToDouble(userInput);
                processingLhs = false;
            }
            else
            {
                rhs = Convert.ToDouble(userInput);
                ProcessEquals();
            }

            Button operationalButton = (Button)sender;
            setOperationFromString(operationalButton.Content.ToString());
            userInput = "0";
        }

        private void setOperationFromString(string operation)
        {
            switch (operation)
            {
                case "+": setOperation(Operation.Addition); break;
                case "_": setOperation(Operation.Subtraction); break;
                case "X": setOperation(Operation.Multiplication); break;
                case "/": setOperation(Operation.Division); break;
            }
        }

        private void ClearClicked(object sender, RoutedEventArgs e)
        {
            if (shouldClearFullFormula)
            {
                ClearFormula();
                ClearButton.Content = "AC";
            }
            else
            {
                ClearDisplay();
                ClearButton.Content = "C";
            }
            shouldClearFullFormula = !shouldClearFullFormula;
        }

        void processNumberClicked(string givenInput)
        {
            if ((userInput == "0" && givenInput == "0") || decimalPlaceClicked) return;
            if (userInput == "0") userInput = "";
            userInput += givenInput;
            Display.Content = userInput;
        }

        void EqualsClicked(object sender, RoutedEventArgs e)
        {
            ProcessEquals();
            processingLhs = true;
        }

        void ProcessEquals()
        {
            if (!isStringADouble(userInput)) return;
            rhs = Convert.ToDouble(userInput);
            double sum = calculate(lhs, rhs, currentOpperation);
            Display.Content = sum.ToString();
            lhs = sum;
            processingLhs = false;
            currentOpperation = Operation.None;
            userInput = sum.ToString();
            shouldClearFullFormula = true;
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
            processingLhs = true;
            ClearDisplay();
            currentOpperation = Operation.None;
        }
    }
}
