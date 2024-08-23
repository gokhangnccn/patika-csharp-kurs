using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using patika_csharp_kurs;
using patika_csharp_kurs.AlanHesaplama;
using patika_csharp_kurs.VotingApplication;

namespace patika_csharp_kurs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string sekilTipi;
            int height = 0;
            Console.WriteLine("Kullanacağınız Uygulamanın Sayısını Giriniz:");
            Console.WriteLine("1. Fibonacci serisi hesaplama");
            Console.WriteLine("2. Konsola Üçgen Çizme:");
            Console.WriteLine("3. Yarıçapa göre konsola daire çizdir:");
            Console.WriteLine("4. Stringteki seçili indexteki harfi sil:");
            Console.WriteLine("5. Girilen cümledeki kelimeleri ters çevir:");
            Console.WriteLine("6. Geometrik şekil işlemleri:");
            Console.WriteLine("7. Girilen sayı dizisinde ikili sayılara işlem yap:");
            Console.WriteLine("8. Girilen sayı dizisinde 67 den büyük ve küçük sayılar için mutlak fark işlem yap:");
            Console.WriteLine("9. İlk ve son karakterleri değiştir:");
            Console.WriteLine("10. Cümledeki kelimelerden yan yana iki sessiz olanları bul:");

            Console.WriteLine("Diğer Büyük Uygulamalar");
            Console.WriteLine("50. Oylama uygulaması:");





            Console.WriteLine("0. Çık:");

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
                    UcgenCiz drawer = new UcgenCiz();
                    drawer.DrawTriangle(height);
                    break;
                case 3:
                    Console.WriteLine("Oluşurulacak daire çapını girin:");
                    DaireCiz dciz = new DaireCiz();
                    height = GetInputFromUser();
                    dciz.DrawCircle(height);
                    break;
                case 4:
                    Console.WriteLine("Silinecek indexi seçiniz:");
                    IndextekiniCikar cikar = new IndextekiniCikar();
                    Console.WriteLine(cikar.indextekiniCikar(GetNumberInputIndex()));
                    break;
                case 5:
                    KelimeyiTersCevir ktc = new KelimeyiTersCevir();
                    Console.WriteLine(ktc.kelimeyiTersCevir(GetStringInput()));
                    break;
                case 6:
                    Console.WriteLine("Lütfen şu şekillerden birini seçiniz: (Daire, Dortgen, Kup, Ucgen)");
                    sekilTipi = Console.ReadLine();
                    seciliSekil(sekilTipi);
                    break;
                case 7:
                    Console.WriteLine("Lütfen arasında boşluk bırakarak sayı dizisini giriniz (2 3 6 1 gibi):");
                    IkilileriAl dizi = new IkilileriAl(Console.ReadLine());
                    Console.WriteLine(dizi.Result());
                    break;
                case 8:
                    Console.WriteLine("Lütfen arasında boşluk bırakarak 67 den büyük veya küçük sayı dizisini giriniz (24 94 32 69 gibi):");
                    MutlakKare mutlakDizi = new MutlakKare(Console.ReadLine());
                    Console.WriteLine(mutlakDizi.Result());
                    break;
                case 9:
                    Console.WriteLine("Lütfen cümleyi giriniz:");
                    KarakterleriDegistir karakterleriDegistir = new KarakterleriDegistir();
                    karakterleriDegistir.ChangeFirstAndLastChars(Console.ReadLine());
                    break;
                case 10:
                    Console.WriteLine("Lütfen cümleyi giriniz:");
                    YanYanaKontrolEt yanYanaKontrolEt = new YanYanaKontrolEt();
                    yanYanaKontrolEt.Result(Console.ReadLine());
                    break;

                case 50:
                    Console.Clear();
                    VotingApp app = new VotingApp();
                    app.Run();
                    break;
                case 0:
                    Console.WriteLine("Çıkış yapılıyor...");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;

            }

        }
        private static int GetInputFromUser()
        {
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
        private static int GetNumberInputIndex()
        {
            if (int.TryParse(Console.ReadLine(), out int height) && height >= 0)
            {
                return height;
            }
            else
            {
                Console.WriteLine("Geçersiz bir giriş yapıldı. Lütfen pozitif bir tam sayı giriniz.");
                return GetNumberInputIndex();
            }
        }

        private static string GetStringInput()
        {
            Console.Write("Lütfen cümle giriniz: ");
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Geçersiz bir giriş yapıldı. Lütfen boş olmayan bir cümle giriniz.");
                return GetStringInput();
            }
        }



        public static void seciliSekil(string sekilTipi)
        {
            string islemTipi;
            Sekil sekil = null;

            switch (sekilTipi.ToLower())
            {
                case "daire":
                    Console.WriteLine("Yarıçap girin:");
                    double radius = GetInputFromUser();
                    sekil = new Daire(radius);
                    break;
                case "dortgen":
                    Console.WriteLine("1. Kenar uzunluğunu girin:");
                    int kenar1 = GetNumberInputIndex();
                    Console.WriteLine("2. Kenar uzunluğunu girin:");

                    int kenar2 = GetNumberInputIndex();
                    sekil = new Dortgen(kenar1, kenar2);
                    break;
                case "ucgen":
                    Console.WriteLine("1. Kenar uzunluğunu girin:");
                    int side1 = GetNumberInputIndex();
                    Console.WriteLine("2. Kenar uzunluğunu girin(taban):");
                    int side2 = GetNumberInputIndex();
                    Console.WriteLine("3. Kenar uzunluğunu girin:");
                    int side3 = GetNumberInputIndex();
                    sekil = new Ucgen(side1, side2, side3);
                    break;
                case "kup":
                    Console.WriteLine("Kenar uzunluğunu girin:");
                    int s1 = GetNumberInputIndex();
                    sekil = new Kup(s1);
                    break;
                default:
                    Console.WriteLine("Geçersiz şekil.");
                    return;
            }

            Console.WriteLine("İşlem tipini seçiniz (alan, çevre, hacim):");
            islemTipi = Console.ReadLine().ToLower();
            seciliSekilIslemi(sekil, islemTipi);
        }

        public static void seciliSekilIslemi(Sekil sekil, string islemTipi)
        {
            switch (islemTipi)
            {
                case "alan":
                    Console.WriteLine($"Alan: {sekil.HesaplaAlan()}");
                    break;
                case "cevre":
                    Console.WriteLine($"Çevre: {sekil.HesaplaCevre()}");
                    break;
                case "hacim":
                    try
                    {
                        Console.WriteLine($"Hacim: {sekil.HesaplaHacim()}");
                    }
                    catch (NotImplementedException)
                    {
                        Console.WriteLine("Bu şekil için hacim hesaplanamaz.");
                    }
                    break;
                default:
                    Console.WriteLine("Geçersiz işlem türü.");
                    break;
            }
        }
    }
}