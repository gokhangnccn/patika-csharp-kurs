using System;
using BarcodeGeneratorApp;
using IronBarCode;


class Program
{
    public static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("1. Barkod Oluştur");
            Console.WriteLine("2. Barkod Oku");
            Console.WriteLine("0. Çıkış Yap");
            Console.Write("Seçiminizi yapın: ");
            var choice = Console.ReadLine();
            BarkodYaz yaz = new BarkodYaz();
            BarkodOku oku = new BarkodOku();


            switch (choice)
            {
                case "1":
                    Console.Clear();
                    yaz.barkodOlustur();
                    break;
                case "2":
                    Console.Clear();
                    oku.barkodOku();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim!");
                    break;
            }

        }
    }

}
