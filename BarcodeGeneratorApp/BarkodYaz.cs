using System;
using System.Drawing;
using IronBarCode;



namespace BarcodeGeneratorApp
{
    public class BarkodYaz
    {
        public void barkodOlustur()
        {
            int sayi = 0;
            Console.Write("Barkod için bir metin girin: ");
            var input = Console.ReadLine();

            var barcode = BarcodeWriter.CreateBarcode(input, BarcodeEncoding.Code128);

            string directoryPath = @"C:\Users\ROG-GOKHAN.gokhan\source\repos\patika-csharp-course\BarcodeGeneratorApp\barkodlar\";
            string filePath = $"{directoryPath}barcode{sayi}.png";

            while (File.Exists(filePath))
            {
                sayi++;
                filePath = $"{directoryPath}barcode{sayi}.png";
            }

            barcode.SaveAsPng(filePath);
            Console.WriteLine($"Barkod oluşturuldu: barcode{sayi}.png");
        }

    }
}
