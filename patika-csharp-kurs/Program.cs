using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatikaExamples.FibonacciTriangle;
using static patikaDevOdevleri.UcgenCiz;

namespace patikaDevOdevleri
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int height = 0;
            Console.WriteLine("Kullanacağınız Uygulamanın Sayısını Giriniz:");
            Console.WriteLine("1. Fibonacci serisi hesaplama");
            Console.WriteLine("2. Konsola Üçgen Çizme:");
            Console.WriteLine("3. Yarıçapa göre konsola daire çizdir:");
            Console.WriteLine("Kullanacağınız Uygulamayı Giriniz:");
            int secenek = int.Parse(Console.ReadLine());

            switch (secenek)
            {
                case 1:
                    Console.WriteLine("Fibonacci dizisi yüksekliğini girin:");
                    height = GetInputFromUser();
                    FibonacciOrtalamaVeUcgen fortalama = new FibonacciOrtalamaVeUcgen();
                    fortalama.PrintFibonacciTriangle(height);
                    break;
                case 2:
                    Console.WriteLine("Oluşturulacak üçgenin yüksekliğini girin:");
                    height = GetInputFromUser();
                    TriangleDrawer drawer = new TriangleDrawer();
                    drawer.DrawTriangle(height);
                    break;
                case 3:
                    Console.WriteLine("Oluşurulacak daire çapını girin:");
                    DaireCiz dciz = new DaireCiz();
                    height = GetInputFromUser();
                    dciz.DrawCircle(height);
                    break;
                case 4:
                    break;
            }


            

            
        }

        private static int GetInputFromUser()
        {
            Console.Write("Lütfen değer giriniz: ");
            if (int.TryParse(Console.ReadLine(), out int height) && height > 0)
            {
                return height;
            }
            else
            {
                Console.WriteLine("Geçersiz bir giriş yapıldı. Lütfen pozitif bir tam sayı giriniz.");
                return GetInputFromUser(); 
            }
        }
    }
}
