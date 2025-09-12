using System;

class Calculator
{
    static double memory = 0;
    static double current = 0;

    static void Main()
    {
        Console.WriteLine("Введите выражение (например 1 + 1) или exit для выхода.");
        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();
            if (input == null) continue;
            input = input.Trim();

            if (input.ToLower() == "exit") break;

            try
            {
                ProcessInput(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }

    static void ProcessInput(string input)
    {
        string[] parts = input.Split(' ');
        if (parts.Length == 3) // Бинарные операции
        {
            double num1 = ParseNumber(parts[0]);
            string op = parts[1];
            double num2 = ParseNumber(parts[2]);
            current = CalculateBinary(num1, op, num2);
            Console.WriteLine("Результат: " + current);
        }
        else if (parts.Length == 2) // Унарные операции
        {
            string op = parts[0];
            double num = ParseNumber(parts[1]);
            current = CalculateUnary(op, num);
            Console.WriteLine("Результат: " + current);
        }
        else if (parts.Length == 1) // Память
        {
            string op = parts[0];
            HandleMemory(op);
        }
        else
        {
            throw new Exception("Неверный формат ввода.");
        }
    }

    static double ParseNumber(string s)
    {
        if (double.TryParse(s, out double num)) return num;
        throw new Exception("Неверное число: " + s);
    }

    static double CalculateBinary(double a, string op, double b)
    {
        switch (op)
        {
            case "+": return a + b;
            case "-": return a - b;
            case "*": return a * b;
            case "/": if (b == 0) throw new Exception("Деление на ноль."); return a / b;
            case "%": return a % b;
            default: throw new Exception("Неизвестная операция: " + op);
        }
    }

    static double CalculateUnary(string op, double x)
    {
        switch (op)
        {
            case "1/x": if (x == 0) throw new Exception("Деление на ноль."); return 1 / x;
            case "x^2": return x * x;
            case "sqrt": if (x < 0) throw new Exception("Корень из отрицательного."); return Math.Sqrt(x);
            default: throw new Exception("Неизвестная операция: " + op);
        }
    }

    static void HandleMemory(string op)
    {
        switch (op)
        {
            case "M+": memory += current; Console.WriteLine("Добавлено в память: " + memory); break;
            case "M-": memory -= current; Console.WriteLine("Вычтено из памяти: " + memory); break;
            case "MR": Console.WriteLine("Память: " + memory); break;
            default: throw new Exception("Неизвестная операция памяти: " + op);
        }
    }
}