using System;
using StringParser;
namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input string for convertion to int");
            string str = String.Empty;
            do
            {
                var input = Console.ReadLine();

                try
                {
                    Console.WriteLine(input.ToInt());
                }
                catch (Exception e) when (e is ArgumentException || e is OverflowException || e is ArgumentNullException)
                {
                    Console.WriteLine(e.Message);
                }

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}
