using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(input.Length);
            int countOfNumFirsNumber = 0;
            int countOfNumSecNumber = 0;
            int result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char a = input[i];

                if (a == '+' || a == '-' || a == '*' || a == '/')
                {
                    break;
                }
                else
                {
                    countOfNumFirsNumber++;
                }
            }
            string parseFirstNumber = input.Substring(0, countOfNumFirsNumber);
            int firstNumber = int.Parse(parseFirstNumber);
            char operand = input[countOfNumFirsNumber];
            int nextNumber = countOfNumFirsNumber + 1;
            countOfNumSecNumber = input.Length - nextNumber;
            string parseSecondNumber = input.Substring(nextNumber, countOfNumSecNumber);
            int secondNumber = int.Parse(parseSecondNumber);
            if (operand == '+')
            {
                result = firstNumber + secondNumber;
            }
            else if (operand == '-')
            {
                result = firstNumber - secondNumber;
            }
            else if (operand == '*')
            {
                result = firstNumber * secondNumber;
            }
            else if (operand == '/')
            {
                result = firstNumber / secondNumber;
            }



            Console.WriteLine($"result: '{result}'");
            Console.ReadKey();

        }
    }
}
