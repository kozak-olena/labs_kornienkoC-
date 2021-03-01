using System;

namespace _2
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
            string expression = Console.ReadLine();
            while (expression != " ")
            {

            }
            int a = Console.Read();
            string operand = Console.ReadLine();
            int b = Console.Read();
            if (operand == "+")
            {
                Console.WriteLine(a + "+" + b + "=" + a + b);
            }
            switch (operand)
            {
                case "+":
                    Console.WriteLine(a + "+" + b + "=" + (a + b));
                    break;
                case "-":
                    Console.WriteLine(a + "-" + b + "=" + (a - b));
                    break;
                case "*":
                    Console.WriteLine(a + "*" + b + "=" + (a * b));
                    break;
                case "/":
                    Console.WriteLine(a + "/" + b + "=" + (a / b));
                    break;
            }
            Console.ReadKey();


        }
    }
}
