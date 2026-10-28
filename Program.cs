// *****************************************************************
// Практическая работа №13                                         *
// Выполнил: Матченко М.С., группа 2-ИСП-оКФ                       *
// Вариант 3                                                       *
// Задание: Организация и использование функций                    *
// *****************************************************************
using System;
using System.Text;
namespace PR_13
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Практическая работа №13";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            string select;// переменная для контроля повторного запуска
            long m = 0;
            Console.WriteLine("Здравствуйте!");
            do // внешний цикл для повторного запуска 
            {
                Console.WriteLine("\n--- Новый расчет ---");
                while (true)// Цикл ввода строки 
                {
                    try
                    {
                        Console.Write("Введите число M: ");
                        string input = Console.ReadLine();
                        if (!long.TryParse(input, out m))// Попытка преобразования строки в число
                        {
                            throw new FormatException("Ошибка: введено некорректное значение. Используйте только цифры.");
                        }
                        if (m < 0)// Проверка на неотрицательность
                        {
                            throw new ArgumentException("Ошибка: число должно быть неотрицательным (>= 0).");
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        HandleError(ex);
                        Console.WriteLine("Пожалуйста, повторите ввод...\n");
                    }
                }
                int result = FindMaxDigit(m);// Вызов рекурсивной функции
                Console.WriteLine($"Наибольшая цифра в числе {m}: {result}\n");
                Console.Write("\nХотите выполнить программу еще раз? (да - 1 / нет - любая клавиша): ");
                select = Console.ReadLine();
            }
            while (select == "1");
            Console.WriteLine("\nПрограмма завершена. Нажмите Enter для выхода...");
            Console.ReadLine();
        }
        public static int FindMaxDigit(long n)
        {
            // Базовый случай рекурсии: если число меньше 10, это и есть цифра
            if (n < 10)
            {
                return (int)n;
            }
            // Рекурсивный шаг:
            // 1. Получаем последнюю цифру
            int lastDigit = (int)(n % 10);
            // 2. Рекурсивно находим наибольшую цифру в оставшейся части числа
            int maxInRest = FindMaxDigit(n / 10);
            // 3. Возвращаем максимум из двух значений
            return Math.Max(lastDigit, maxInRest);
        }
        static void HandleError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Произошла ошибка: {ex.Message}\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }
    }
}