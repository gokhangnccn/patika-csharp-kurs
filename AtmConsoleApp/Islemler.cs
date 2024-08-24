using System;
using System.Collections.Generic;

namespace AtmConsoleApp;

public class Islemler
{
    private Log log = new Log();
    private Kisi aktifKullanici = null; // Giriş yapan kullanıcıyı tutacak değişken

    private List<Kisi> kisiler = new List<Kisi>
    {
        new Kisi(1, "Ahmet", "Yılmaz", "hello", 5000),
        new Kisi(2, "Mehmet", "Kaya", "world", 3000)
    };

    public void Calistir()
    {
        log.CheckAndCreate(kisiler); // Log dosyalarını kontrol et ve oluştur
        bool uygulamaDevam = true;

        while (uygulamaDevam)
        {
            if (aktifKullanici == null) // Giriş yapılmamışsa kayıt ol veya giriş işlemi zorunlu
            {
                Console.WriteLine("Lütfen bir seçenek belirleyin:");
                Console.WriteLine("1- Giriş Yap");
                Console.WriteLine("2- Kayıt Ol");
                Console.WriteLine("0- Uygulamayı Kapat");

                int secim;
                if (int.TryParse(Console.ReadLine(), out secim))
                {
                    switch (secim)
                    {
                        case 1:
                            GirisYap();
                            break;
                        case 2:
                            KayıtOl();
                            break;
                        case 0:
                            uygulamaDevam = false;
                            Console.WriteLine("ATM'den çıkış yapılıyor.");
                            break;
                        default:
                            Console.WriteLine("Geçersiz seçenek, lütfen tekrar deneyin.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Lütfen geçerli bir seçenek girin.");
                }
            }
            else
            {
                Console.WriteLine("Lütfen bir işlem seçin:");
                Console.WriteLine("1- Para Çekme");
                Console.WriteLine("2- Para Yatırma");
                Console.WriteLine("3- Para Gönderme");
                Console.WriteLine("4- Bakiye Görüntüle");
                Console.WriteLine("9- Çıkış");
                Console.WriteLine("0- Uygulamayı Kapat");

                int secim;
                if (int.TryParse(Console.ReadLine(), out secim))
                {
                    switch (secim)
                    {
                        case 1:
                            Console.Write("Çekmek istediğiniz miktar: ");
                            int cekilecekMiktar = int.Parse(Console.ReadLine());
                            ParaCekme(cekilecekMiktar);
                            break;
                        case 2:
                            Console.Write("Yatırmak istediğiniz miktar: ");
                            int yatirilacakMiktar = int.Parse(Console.ReadLine());
                            ParaYatirma(yatirilacakMiktar);
                            break;
                        case 3:
                            Console.Write("Alıcı ID: ");
                            int aliciId = int.Parse(Console.ReadLine());
                            Console.Write("Gönderilecek miktar: ");
                            int gonderilecekMiktar = int.Parse(Console.ReadLine());
                            ParaGonderme(aliciId, gonderilecekMiktar);
                            break;
                        case 4:
                            BakiyeGoruntule();
                            break;
                        case 9:
                            Console.Clear();
                            Console.WriteLine("Hesaptan çıkış yapıldı.");
                            aktifKullanici = null;
                            break;
                        case 0:
                            uygulamaDevam = false;
                            Console.WriteLine("ATM'den çıkış yapılıyor.");
                            break;
                        default:
                            Console.WriteLine("Geçersiz seçenek, lütfen tekrar deneyin.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Lütfen geçerli bir seçenek girin.");
                }
            }
        }
    }

    public void KayıtOl()
    {
        int id;
        bool idMevcut = false;

        do
        {
            Console.Write("ID: ");
            id = int.Parse(Console.ReadLine());

            if (kisiler.Exists(p => p.id == id))
            {
                Console.WriteLine("Bu ID zaten kullanılıyor. Lütfen farklı bir ID girin.");
                idMevcut = true;
            }
            else
            {
                idMevcut = false;
            }
        } while (idMevcut);

        Console.Write("Ad: ");
        string ad = Console.ReadLine();

        Console.Write("Soyad: ");
        string soyad = Console.ReadLine();

        Console.Write("Şifre: ");
        string sifre = Console.ReadLine();

        Console.Write("Başlangıç bakiyesi: ");
        int bakiye = int.Parse(Console.ReadLine());

        var yeniKisi = new Kisi(id, ad, soyad, sifre, bakiye);
        kisiler.Add(yeniKisi);

        log.CheckAndCreate(kisiler);

        log.BasariliKayit(ad, soyad, id);
        Console.WriteLine("Kayıt başarıyla tamamlandı. Lütfen giriş yapın.");
    }


    public void ParaCekme(int miktar)
    {
        if (aktifKullanici.bakiye >= miktar)
        {
            aktifKullanici.bakiye -= miktar;
            log.BasariliParaCekme(aktifKullanici.ad, aktifKullanici.soyad, aktifKullanici.id, miktar);
            Console.WriteLine($"{miktar} TL başarıyla çekildi.");
        }
        else
        {
            log.BasarisizParaCekme(aktifKullanici.ad, aktifKullanici.soyad, aktifKullanici.id, miktar);
            Console.WriteLine("Yetersiz bakiye.");
        }
    }

    public void ParaYatirma(int miktar)
    {
        aktifKullanici.bakiye += miktar;
        log.BasariliParaYatirma(aktifKullanici.ad, aktifKullanici.soyad, aktifKullanici.id, miktar);
        Console.WriteLine($"{miktar} TL başarıyla yatırıldı.");
    }

    public void ParaGonderme(int aliciid, int miktar)
    {
        var alici = kisiler.Find(p => p.id == aliciid);

        if (alici == null)
        {
            log.BasarisizParaGonderme(aktifKullanici.ad, aktifKullanici.soyad, aktifKullanici.id, "Bilinmiyor", "Bilinmiyor", aliciid, miktar);
            Console.WriteLine("Alıcı bulunamadı.");
            return;
        }

        if (aktifKullanici.bakiye >= miktar)
        {
            aktifKullanici.bakiye -= miktar;
            alici.bakiye += miktar;
            log.BasariliParaGonderme(aktifKullanici.ad, aktifKullanici.soyad, aktifKullanici.id, alici.ad, alici.soyad, aliciid, miktar);
            Console.WriteLine($"{miktar} TL başarıyla gönderildi.");
        }
        else
        {
            log.BasarisizParaGonderme(aktifKullanici.ad, aktifKullanici.soyad, aktifKullanici.id, alici.ad, alici.soyad, aliciid, miktar);
            Console.WriteLine("Yetersiz bakiye.");
        }
    }

    public void BakiyeGoruntule()
    {
        log.bakiyeGoruntule(aktifKullanici.ad, aktifKullanici.soyad, aktifKullanici.id, aktifKullanici.bakiye);
        Console.WriteLine($"Mevcut bakiyeniz: {aktifKullanici.bakiye} TL.");
    }

    public void GirisYap()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        var kisi = kisiler.Find(p => p.id == id);
        if (kisi == null)
        {
            Console.Clear();
            log.BasarisizGiris("Bilinmiyor", "Bilinmiyor", id);
            Console.WriteLine("Kişi bulunamadı, tekrar deneyin.");
            return;
        }

        Console.Write("Şifre: ");
        string sifre = Console.ReadLine();

        if (kisi.sifre == sifre)
        {
            Console.Clear();
            log.BasariliGiris(kisi.ad, kisi.soyad, id);
            aktifKullanici = kisi;
            Console.WriteLine($"Hoşgeldiniz {kisi.ad} {kisi.soyad}.");
        }
        else
        {
            Console.Clear();
            log.BasarisizGiris(kisi.ad, kisi.soyad, id);
            Console.WriteLine("Hatalı şifre, tekrar deneyin.");
        }
    }
}
