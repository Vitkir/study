﻿using System;

namespace LineCounter2
{
    public class DrawTriangle
    {
        static void Main(string[] args)
        {
            int rowCount = ReadPositiveValue();
            Draw(rowCount);
            Console.ReadKey();
        }

        public static int ReadPositiveValue()
        {
            int value;
            bool isInputValid;
            do
            {
                Console.WriteLine("Enter positive value");
                isInputValid = !int.TryParse(Console.ReadLine(), out value);
                Console.Clear();
            }
            while (isInputValid && (value <= 0));
            return value;
        }

        public static void Draw(int rowCount, int shiftTriangle = 0)
        {
            int asterixsCount = 1;
            char space = '\0';
            for (int i = 0; i < rowCount; i++)
            {
                int spaceCount = rowCount + shiftTriangle + i;
                Console.WriteLine(value: new string('*', asterixsCount).PadLeft(spaceCount, space));
                asterixsCount += 2;
            }
        }
    }
}
