using System;
using System.Drawing;
using BarcodeStandard;
using IronBarCode;


namespace BarcodeGeneratorApp
{
    public class BarkodOku
    {
        public void barkodOku()
        {
            Console.Write("Barkodun adını giriniz: ");
            var filePath = "C:\\Users\\ROG-GOKHAN.gokhan\\source\\repos\\patika-csharp-course\\BarcodeGeneratorApp\\barkodlar\\" + Console.ReadLine() + ".png";

            BarcodeResult[] results = BarcodeReader.Read(filePath).ToArray();


            if (results != null)
            {
               
                Console.WriteLine($"Barkod metni: {results[0].Text}");
            }
            else
            {
                Console.WriteLine("Barkod okunamadı.");
            }
        }
    }
}
