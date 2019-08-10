using System;

namespace LineCounter3
{
    class Program
    {
        static void Main(string[] args)
        {
            int trianglesCount = LineCounter2.DrawTriangle.ReadPositiveValue();
            Console.Clear();
            DrawTriangles(trianglesCount: trianglesCount);
            Console.ReadKey();
        }

        static void DrawTriangles(int trianglesCount)
        {
            int topShift = 0;
            int leftShift = trianglesCount - 1;
            for (int i = 1; i <= trianglesCount; i++)
            {
                Console.SetCursorPosition(leftShift, topShift);
                LineCounter2.DrawTriangle.Draw(i);
                topShift += i;
                leftShift -= 1;
            }
        }
    }
}
