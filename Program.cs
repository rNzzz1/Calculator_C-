using System;

namespace ClassicCalculator
{
    class Calculator
    {
        private double memory = 0;

        public double Add(double a, double b) => a + b;
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, double b) => a * b;

        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Деление на ноль невозможно.");
            return a / b;
        }

        public double Modulus(double a, double b) => a % b;
        public double Reciprocal(double a)
        {
            if (a == 0)
                throw new DivideByZeroException("Нельзя найти обратное для нуля.");
            return 1 / a;
        }

        public double Square(double a) => a * a;
        public double SquareRoot(double a)
        {
            if (a < 0)
                throw new ArgumentException("Корень квадратный из отрицательного числа невозможен.");
            return Math.Sqrt(a);
        }

        public void MemoryAdd(double a) => memory += a;
        public void MemorySubtract(double a) => memory -= a;
        public double MemoryRecall() => memory;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            string input;
            double num1, num2, result = 0;
            string operation;
            bool running = true;

            Console.WriteLine("Классический калькулятор на C#");
            Console.WriteLine("Операции: +, -, *, /, %, 1/x, x^2, sqrt, M+, M-, MR");
            Console.WriteLine("Для выхода введите exit");

            while (running)
            {
                try
                {
                    Console.Write("Введите первое число: ");
                    input = Console.ReadLine();
                    if (input.ToLower() == "exit") break;
                    num1 = Convert.ToDouble(input);

                    Console.Write("Введите операцию: ");
                    operation = Console.ReadLine();

                    if (operation.ToLower() == "exit") break;

                    if (operation == "M+" || operation == "M-" || operation == "MR")
                    {
                        switch (operation)
                        {
                            case "M+":
                                calc.MemoryAdd(num1);
                                Console.WriteLine("Добавлено в память.");
                                break;
                            case "M-":
                                calc.MemorySubtract(num1);
                                Console.WriteLine("Вычтено из памяти.");
                                break;
                            case "MR":
                                result = calc.MemoryRecall();
                                Console.WriteLine("Память: " + result);
                                break;
                        }
                    }
                    else if (operation == "1/x" || operation == "x^2" || operation.ToLower() == "sqrt")
                    {
                        switch (operation)
                        {
                            case "1/x":
                                result = calc.Reciprocal(num1);
                                Console.WriteLine("Результат: " + result);
                                break;
                            case "x^2":
                                result = calc.Square(num1);
                                Console.WriteLine("Результат: " + result);
                                break;
                            case "sqrt":
                                result = calc.SquareRoot(num1);
                                Console.WriteLine("Результат: " + result);
                                break;
                        }
                    }
                    else
                    {
                        Console.Write("Введите второе число: ");
                        input = Console.ReadLine();
                        if (input.ToLower() == "exit") break;
                        num2 = Convert.ToDouble(input);

                        switch (operation)
                        {
                            case "+":
                                result = calc.Add(num1, num2);
                                break;
                            case "-":
                                result = calc.Subtract(num1, num2);
                                break;
                            case "*":
                                result = calc.Multiply(num1, num2);
                                break;
                            case "/":
                                result = calc.Divide(num1, num2);
                                break;
                            case "%":
                                result = calc.Modulus(num1, num2);
                                break;
                            default:
                                Console.WriteLine("Неверная операция.");
                                continue;
                        }
                        Console.WriteLine("Результат: " + result);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка формата ввода. Введите число.");
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine("Ошибка: " + e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Ошибка: " + e.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Произошла неизвестная ошибка.");
                }
            }

            Console.WriteLine("Работа калькулятора завершена.");
        }
    }
}

