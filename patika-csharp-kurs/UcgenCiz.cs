using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace patikaDevOdevleri
{

    class UcgenCiz
    {
        // Üçgen çiziminden sorumlu sınıf
        public class TriangleDrawer
        {
            // Verilen yükseklik değerine göre üçgen çizen metot
            public void DrawTriangle(int height)
            {
                for (int i = 1; i <= height; i++)
                {
                    PrintSpaces(height - i);
                    PrintStars(i);
                    Console.WriteLine();
                }
            }

            // Satır başındaki boşlukları basan metot
            private void PrintSpaces(int count)
            {
                for (int i = 0; i < count; i++)
                {
                    Console.Write(" ");
                }
            }

            // Satırdaki yıldızları basan metot
            private void PrintStars(int count)
            {
                for (int i = 0; i < count * 2 - 1; i++)
                {
                    Console.Write("*");
                }
            }
        }

    }
}
