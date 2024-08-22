using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace patika_csharp_kurs
{

    class UcgenCiz
    {

        public void DrawTriangle(int height)
        {
            for (int i = 1; i <= height; i++)
            {
                PrintSpaces(height - i);
                PrintStars(i);
                Console.WriteLine();
            }
        }

        private void PrintSpaces(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(" ");
            }
        }

        private void PrintStars(int count)
        {
            for (int i = 0; i < count * 2 - 1; i++)
            {
                Console.Write("*");
            }
            
        }

    }
}
