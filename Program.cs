using System;
using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя файла:");
            string fileName = Console.ReadLine();

            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не существует!");
                return;
            }

            string text = File.ReadAllText(fileName);

            string upperText = text.ToUpper();

            File.WriteAllText("output.txt", upperText);

            Console.WriteLine("Готово! Результат записан в output.txt");
        }
    }
