using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "first.txt";
            string outputFile = "second.txt";

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Файл не существует!");
                return;
            }

            string[] lines = File.ReadAllLines(inputFile);

            for (int i = 0; i < lines.Length; i++)
            {
                string s = lines[i];

                SearchMail(ref s);

                lines[i] = s;
            }

            File.WriteAllLines(outputFile, lines);

            Console.WriteLine("Готово! Адреса записаны в second.txt");
        }

        public static void SearchMail(ref string s)
        {
            int index = s.IndexOf('#');

            if (index != -1)
            {
                s = s.Substring(index + 1).Trim();
            }
        }
    }
}