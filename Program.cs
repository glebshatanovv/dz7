using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckFormat(100);
            CheckFormat("Hello");
            CheckFormat(12.2);
        }

        public static void CheckFormat(object value)
        {
            if (value is IFormattable)
            {
                Console.WriteLine("Объект реализует IFormattable");

                IFormattable formatted = value as IFormattable;

                Console.WriteLine("Форматированное значение: " +
                                  formatted.ToString("F2", null));
            }
            else
            {
                Console.WriteLine("Объект НЕ реализует IFormattable");
            }
        }
    }
}