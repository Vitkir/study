using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStyles
{
    class Program
    {

        static void Main(string[] args)
        {
            var defaultFont = Font.None;
            Console.WriteLine("Text options: " + defaultFont);
            Console.WriteLine("Assign font: ");
            FontListShow();
            AssignFontText(ref defaultFont);
        }

        [Flags]
        enum Font
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }

        public static ConsoleKeyInfo EnterText()
        {
            var input = Console.ReadKey();

            return input;
        }

        static void FontListShow()
        {
            int fontIndex = 1;
            foreach (string name in Enum.GetNames(typeof(Font)).Skip(1))
            {
                Console.WriteLine($"{fontIndex} :{name}");
                fontIndex++;
            }
        }

        private static ConsoleKeyInfo AssignFontText(ref Font font)
        {
            ConsoleKeyInfo input;
            do
            {
                input = EnterText();
                Console.WriteLine();
                switch (input.KeyChar)
                {
                    case '1':
                        font ^= Font.Bold;
                        break;
                    case '2':
                        font ^= Font.Italic;
                        break;
                    case '3':
                        font ^= Font.Underline;
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Text options: " + font);
            }
            while (input.Key != ConsoleKey.Escape);
            return input;
        }
    }
}
