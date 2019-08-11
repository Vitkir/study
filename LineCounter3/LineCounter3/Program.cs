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
            for (int i = 1; i <= trianglesCount; i++)
            {
                LineCounter2.DrawTriangle.Draw(i, trianglesCount - i);
            }
        }
    }
}
