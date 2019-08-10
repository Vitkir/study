using System;

namespace LineCounter2
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowCount = ReadPositiveValue();
            Draw(rowCount);
            Console.ReadKey();
        }

        private static void Draw(int rowCount)
        {
            int asterixsCount = 1;
            for (int i = 1; i <= rowCount; i++)
            {
                Console.SetCursorPosition(rowCount - i, i);
                Console.WriteLine(value: new string('*', asterixsCount));
                asterixsCount = asterixsCount + 2;
            }
        }

        private static int ReadPositiveValue()
        {
            int value;
            bool isInputValid;
            do
            {
                Console.WriteLine("Enter positive value");
                isInputValid = !int.TryParse(Console.ReadLine(), out value);
            }
            while (isInputValid && value <= 0);
            return value;
        }
    }

}
