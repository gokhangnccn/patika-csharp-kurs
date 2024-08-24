using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patika_csharp_kurs.AtmApplication
{
    public class Log
    {
        private string directoryPath = @"C:\Users\ROG-GOKHAN.gokhan\source\repos\patika-csharp-course\patika-csharp-kurs\AtmApplication\kullanici-kayitlari";

        public void LogYaz(int id, string logMessage)
        {
            string logFilePath = Path.Combine(directoryPath, id + ".txt");

            if (!File.Exists(logFilePath))
            {
                Console.WriteLine($"Kişi ({id}) bulunamadı.");
                return;
            }

            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }



        private void LogIslem(string islemDurumu, string islemTipi, string ad, string soyad, int id, int miktar = 0, int? aliciid = null, string aliciad = null, string alicisoyad = null)
        {
            string logMessage = $"Log: {islemDurumu}! : {islemTipi}\n" +
                                $"Kimlik: {id}\n" +
                                $"Kişi: {ad} {soyad}\n";

            if (miktar > 0)
                logMessage += $"Miktar: {miktar}\n";

            if (aliciid != null)
            {
                logMessage += $"Alıcı Kimlik: {aliciid}\n" +
                              $"Alıcı ad: {aliciad} {alicisoyad}\n";
            }

            logMessage += $"Tarih: {DateTime.Now}\n";
            LogYaz(id, logMessage);
        }

        public void BasariliKayit(string ad, string soyad, int id)
        {
            LogIslem("BAŞARILI", "Kayıt", ad,soyad,id);
        }

        public void BasariliGiris(string ad, string soyad, int id) =>
            LogIslem("BAŞARILI", "Giriş", ad, soyad, id);

        public void BasarisizGiris(string ad, string soyad, int id) =>
            LogIslem("BAŞARISIZ", "Giriş", ad, soyad, id);

        public void BasariliParaCekme(string ad, string soyad, int id, int miktar) =>
            LogIslem("BAŞARILI", "Para Çekme", ad, soyad, id, miktar);

        public void BasarisizParaCekme(string ad, string soyad, int id, int miktar) =>
            LogIslem("BAŞARISIZ", "Para Çekme", ad, soyad, id, miktar);

        public void BasariliParaYatirma(string ad, string soyad, int id, int miktar) =>
            LogIslem("BAŞARILI", "Para Yatırma", ad, soyad, id, miktar);

        public void BasarisizParaYatirma(string ad, string soyad, int id, int miktar) =>
            LogIslem("BAŞARISIZ", "Para Yatırma", ad, soyad, id, miktar);

        public void BasariliParaGonderme(string gad, string gsoyad, int gid, string aad, string asoyad, int aid, int miktar)
        {
            LogIslem("BAŞARILI", "Para Gönderme", gad, gsoyad, gid, miktar, aid, aad, asoyad);
            LogIslem("BAŞARILI", "Para Alma", aad, asoyad, aid, miktar, gid, gad, gsoyad);
        }

        public void BasarisizParaGonderme(string gad, string gsoyad, int gid, string aad, string asoyad, int aid, int miktar) =>
            LogIslem("BAŞARISIZ", "Para Gönderme", gad, gsoyad, gid, miktar, aid, aad, asoyad);

        public void bakiyeGoruntule(string ad, string soyad, int id, int miktar) =>
            LogIslem("BAKİYE", "Bakiye Görüntüleme", ad, soyad, id, miktar);


        public void CheckAndCreate(List<Kisi> persons)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            foreach (var person in persons)
            {
                string logFilePath = Path.Combine(directoryPath, person.id + ".txt");
                if (!File.Exists(logFilePath))
                {
                    File.Create(logFilePath).Dispose();
                }
            }
        }
    }

}


