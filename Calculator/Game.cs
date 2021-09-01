using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Game
    {
        bool applicationShouldExit = false;
        float lhs = float.NaN;
        float rhs = float.NaN;
        float result = float.NaN;
        string operation = "";
        int currentText = 1;
        string input = "";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        float GetResult()
        {
            if (operation == "+")
                return lhs + rhs;
            else if (operation == "-")
                return lhs - rhs;
            else if (operation == "*" || operation == "x")
                return lhs * rhs;
            else if (operation == "/")
                return lhs / rhs;

            return float.NaN;
        }

        void PrintExpression()
        {
            if (!float.IsNaN(lhs))
                Console.Write(lhs + " ");

            Console.Write(operation + " ");

            if (!float.IsNaN(rhs))
                Console.Write(rhs + " ");

            if (!float.IsNaN(result))
                Console.Write("= " + result + " ");

            Console.WriteLine();
        }

        float GetInputValue()
        {
            float value = float.NaN;

            while (float.IsNaN(value))
            {
                Console.WriteLine("Enter a value.");
                Console.Write("> ");
                input = Console.ReadLine();

                if (input == "q" || input == "quit")
                {
                    applicationShouldExit = true;
                    return value;
                }

                if (!float.TryParse(input, out value))
                {
                    value = float.NaN;
                    Console.WriteLine("Invalid Input");
                    Console.ReadKey();
                    Console.Clear();
                    PrintExpression();
                }
            }

            return value;
        }

        string GetInputOperation()
        {
            bool validInputReceived = false;

            while (!validInputReceived)
            {
                Console.WriteLine("Enter an operator.");
                Console.Write("> ");
                input = Console.ReadLine();

                if (input == "q" || input == "quit")
                {
                    applicationShouldExit = true;
                    return input;
                }

                if (input != "+" && input != "-" && input != "/" && input != "*" && input != "x")
                {
                    Console.WriteLine("Invalid Input");
                    Console.ReadKey();
                    Console.Clear();
                    PrintExpression();
                    validInputReceived = false;
                }
                else
                    validInputReceived = true;
            }

            return input;
        }

        void ResetValues()
        {
            lhs = float.NaN;
            rhs = float.NaN;
            operation = "";
            result = float.NaN;
        }

        public void Run()
        {

            while (!applicationShouldExit)
            {
                PrintExpression();

                if (currentText > 4)
                {
                    Console.ReadKey(true);
                    ResetValues();
                    currentText = 1;
                }

                DisplayCurrentText();

                currentText++;

                Console.Clear();
            }
        }

        private void DisplayCurrentText()
        {
            if (currentText == 1)
                lhs = GetInputValue();
            else if (currentText == 2)
                operation = GetInputOperation();
            else if (currentText == 3)
                rhs = GetInputValue();
            else if (currentText == 4)
                result = GetResult();
        }
    }
}
