using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patikaDevOdevleri
{
    public class DaireCiz
    {
        public void DrawCircle(int radius)
        {
            int cap = radius * 2;
            for (int y = 0; y <= cap; y++)
            {
                for (int x = 0; x <= cap; x++)
                {
                    if (IsPointInCircle(x, y, radius))
                    {
                        Console.Write(" * ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine();
            }
        }

        private bool IsPointInCircle(int x, int y, int radius)
        {
            int dx = radius - x;
            int dy = radius - y;
            return (dx * dx + dy * dy) <= (radius * radius);
        }
    }
}
