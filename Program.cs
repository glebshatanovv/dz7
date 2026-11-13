using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "glebas";

            string result = ReverseWord(word);

            Console.WriteLine("Исходное слово: " + word);
            Console.WriteLine("Перевернутое слово: " + result);
        }

        public static string ReverseWord(string word)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char letter in word)
            {
                stack.Push(letter);
            }

            string result = "";

            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }
    }
}