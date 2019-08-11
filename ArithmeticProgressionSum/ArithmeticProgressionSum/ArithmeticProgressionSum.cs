using System;

namespace ArithmeticProgressionSum
{
    class ArithmeticProgressionSum
    {
        public static void Main(string[] args)
        {
            int inputValue = ReadValidValue();
            Console.WriteLine(inputValue);
            int sum1 = ProgressionSum(inputValue, 3);
            int sum2 = ProgressionSum(inputValue, 5);
            int sum3 = ProgressionSum(inputValue, 15);

            int sum4 = sum1 + sum2 - sum3;
            Console.WriteLine("Sum of numbers less than {0}, divisible 3 or 5 = {1}", inputValue, sum4);
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

        public static int ProgressionSum(int value, int step)
        {
            int elementsCount = (value % step != 0 ? value / step : value / step - 1);
            int maxValue = elementsCount * step;
            return ((step + maxValue) * elementsCount) / 2;
        }
    }
}
