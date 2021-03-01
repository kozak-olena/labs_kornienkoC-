using System;

namespace ConsoleApp1
{
    class Program
    {
        static int ReadInt(string question)
        {
            Console.Write(question);
            string answer = Console.ReadLine();
            int result = int.Parse(answer);
            return result;
        }
        static void Main(string[] args)
        {
            int number = ReadInt("number is ");
            while (number != 0)
            {
                if (number % 2 == 0)
                {
                    Console.WriteLine(number);
                    number = number - 2;
                }
                else
                {
                    number = number - 1;

                }



            }
            Console.ReadKey();
        }
    }
}
