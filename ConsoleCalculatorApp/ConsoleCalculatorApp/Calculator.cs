using System;

namespace ConsoleCalculatorApp
{
    public class Calculator
    {
        private static void Main()
        {
            var isNewCalculation = true;

            while (isNewCalculation)
            {
                Console.WriteLine("Welcome to the calculator and number evaluator application, please select your mode (Type Calculator C/Evaluator E): ");
                var modeSelected = Console.ReadLine()?.ToUpper();
                if (modeSelected == "C")
                {
                    Console.WriteLine("Welcome to the calculator application, you must enter a number, an operator, and another  number.");
                    Console.WriteLine("Please, enter your first number: ");
                    var firstNumber = Console.ReadLine();
                    Console.WriteLine("Please enter an operator (+, -, *, or /): ");
                    var userOperator =  Console.ReadLine();
                    Console.WriteLine("Please enter your final number: ");
                    var secondNumber = Console.ReadLine();
                    Console.WriteLine("You have entered the following function: ");
                    Console.WriteLine($"{firstNumber} {userOperator} {secondNumber}");
                    Console.WriteLine($"Which means {Calculation(firstNumber, userOperator, secondNumber)}");
                    Console.WriteLine("Would you like to make a new calculation or evaluation (type Y/N)?");
                    var continueCalculation = Console.ReadLine()?.ToUpper();
                    if (continueCalculation == "Y")
                    {
                        isNewCalculation = true; 
                    }

                    if(continueCalculation == "N")
                    {
                        isNewCalculation = false;
                    }
                    
                }

                if (modeSelected == "E")
                {
                    Console.WriteLine("Welcome to the evaluator application, you must enter a number, an operator, and another  number.");
                    Console.WriteLine("Please, enter your first number: ");
                    var firstNumber = Console.ReadLine();
                    Console.WriteLine("Please enter an evaluation operator (>, <, =, >=, or <=): ");
                    var evaluationOperator =  Console.ReadLine();
                    Console.WriteLine("Please enter your final number: ");
                    var secondNumber = Console.ReadLine();
                    Console.WriteLine("You have entered the following function: ");
                    Console.WriteLine($"{firstNumber} {evaluationOperator} {secondNumber}");
                    Console.WriteLine($"Which means {Evaluation(firstNumber, evaluationOperator, secondNumber)}");
                    Console.WriteLine("Would you like to make a new calculation or evaluation (type Y/N)?");
                    var continueCalculation = Console.ReadLine()?.ToUpper();
                    if (continueCalculation == "Y")
                    {
                        isNewCalculation = true; 
                    }

                    if (continueCalculation == "N")
                    {
                        isNewCalculation = false;
                    }
                }
                else
                {
                    Console.WriteLine("You have typed an invalid response please start over.");
                    isNewCalculation = true;
                }
            }
        }

        public static string Calculation(string firstNumber, string userOperator, string secondNumber)
        {
            decimal totalCalculation = 0;


            switch (userOperator)
            {
                case "+":
                    totalCalculation = NumberTypeConverter(firstNumber) + NumberTypeConverter(secondNumber); return $"your calculation equals {totalCalculation}.";
                case "-":
                    totalCalculation = NumberTypeConverter(firstNumber) - NumberTypeConverter(secondNumber);
                    return $"your calculation equals {totalCalculation}.";
                case "*":
                    totalCalculation = NumberTypeConverter(firstNumber) * NumberTypeConverter(secondNumber);
                    return $"your calculation equals {totalCalculation}.";
                case "/":
                    totalCalculation = NumberTypeConverter(firstNumber) / NumberTypeConverter(secondNumber);
                    return $"your calculation equals {totalCalculation}.";
                default:
                    var errorMessage = $"the calculation you are trying to process is invalid please enter a new calculation.";
                    return errorMessage;
            }
        }

        public static dynamic NumberTypeConverter(string number)
        {
            if (number.Contains("."))
            {
                decimal result;
                var decimalTest = decimal.TryParse(number, out result);

                if (decimalTest)
                {
                    return Convert.ToDecimal(number);
                }

                else
                {
                    Console.WriteLine("This is an invalid response.");
                    return null;
                }
            }
            else
            {
                int result;
                var integerTest = int.TryParse(number, out result);
                
                if (integerTest)
                {
                    return Convert.ToInt32(number);
                }

                else
                {
                    Console.WriteLine("This is an invalid response.");
                    return null;
                }
            }
        }

        public static string Evaluation(string firstNumber, string evaluationOperator, string secondNumber)
        {
            var finalEvaluation = false;

            switch (evaluationOperator)
            {
                case ">":
                    finalEvaluation = NumberTypeConverter(firstNumber) > NumberTypeConverter(secondNumber); 
                    return $"your evaluation is {finalEvaluation.ToString().ToLower()}.";
                case "<":
                    finalEvaluation = NumberTypeConverter(firstNumber) < NumberTypeConverter(secondNumber);
                    return $"your evaluation is {finalEvaluation.ToString().ToLower()}.";
                case "=":
                    finalEvaluation = NumberTypeConverter(firstNumber) == NumberTypeConverter(secondNumber);
                    return $"your evaluation is {finalEvaluation.ToString().ToLower()}.";
                case ">=":
                    finalEvaluation = NumberTypeConverter(firstNumber) >= NumberTypeConverter(secondNumber);
                    return $"your evaluation is {finalEvaluation.ToString().ToLower()}.";
                case "<=":
                    finalEvaluation = NumberTypeConverter(firstNumber) <= NumberTypeConverter(secondNumber);
                    return $"your evaluation is {finalEvaluation.ToString().ToLower()}.";
                default:
                    var errorMessage = $"the evaluation you are trying to process is invalid please enter a new calculation.";
                    return errorMessage;
            }
        }
    }
}
