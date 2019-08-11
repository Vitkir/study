using System;

namespace ArithmeticProgressionSum
{
    class ArithmeticProgressionSum
    {
        public static void Main(string[] args)
        {
            int inputValue = ReadValidValue();
            Console.WriteLine(inputValue);
            int sum1 = ProgressionSumStep3(inputValue);
            int sum2 = ProgressionSumStep5(inputValue);
            int sum3 = sum1 + sum2;
            Console.WriteLine("Sum of numbers less than {0}, divisible 3 or 5 = {1}", inputValue, sum3);
            Console.ReadKey();
        }

        public static int ReadValidValue()
        {
            int validValue;
            bool isInputValid;
            do
            {
                Console.WriteLine("Enter positive value");
                isInputValid = !int.TryParse(Console.ReadLine(), out validValue);
                Console.Clear();
            }
            while (isInputValid && validValue <= 0);
            return validValue;
        }

        public static int ProgressionSumStep3(int value)
        {
            int elementsSum;
            int elementsCount = value / 3;
            int maxValue = elementsCount * 3;
            return elementsSum = ((0 + maxValue) * elementsCount) / 2;
        }

        public static int ProgressionSumStep5(int value)
        {
            int elementsSum;
            int elementsCount = value / 5;
            int maxValue = elementsCount * 5;
            return elementsSum = ((0 + maxValue) * elementsCount) / 2;
        }
    }
}
