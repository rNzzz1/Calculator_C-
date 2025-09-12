using System;
using System.Data;

namespace ClassicCalculator
{
    class Calculator
    {
        double memory = 0, last = 0;

        public void Process(string input)
        {
            input = input.Replace(" ", "");
            try
            {
                if (input.ToLower() == "mr")
                {
                    Console.WriteLine("Память: " + memory);
                }
                else if (input.ToLower() == "m+")
                {
                    memory += last;
                    Console.WriteLine("Добавлено в память.");
                }
                else if (input.ToLower() == "m-")
                {
                    memory -= last;
                    Console.WriteLine("Вычтено из памяти.");
                }
                else if (input.StartsWith("1/"))
                {
                    double x = Eval(input.Substring(2));
                    last = 1 / x;
                    Console.WriteLine("Результат: " + last);
                }
                else if (input.StartsWith("sqrt"))
                {
                    double x = Eval(input.Substring(4));
                    if (x < 0) throw new Exception("Отрицательное число.");
                    last = Math.Sqrt(x);
                    Console.WriteLine("Результат: " + last);
                }
                else if (input.EndsWith("^2"))
                {
                    double x = Eval(input.Substring(0, input.Length - 2));
                    last = x * x;
                    Console.WriteLine("Результат: " + last);
                }
                else
                {
                    last = Eval(input);
                    Console.WriteLine("Результат: " + last);
                }
            }
            catch
            {
                Console.WriteLine("Ошибка: неправильный ввод или операция.");
            }
        }

        double Eval(string expr)
        {
            return Convert.ToDouble(new DataTable().Compute(expr, ""));
        }
    }

    class Program
    {
        static void Main()
        {
            var calc = new Calculator();
            Console.WriteLine("Введите выражение:");
            while (true)
            {
                Console.Write("");
                var input = Console.ReadLine();
                if (input == null || input.ToLower() == "exit") break;
                calc.Process(input);
            }
        }
    }
}