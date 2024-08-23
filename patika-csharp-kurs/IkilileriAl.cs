using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patika_csharp_kurs
{
    public class IkilileriAl
    {
        public string sayilar { get; set; }
        public int[] sonuclar { get; set; }
        public string sonSonuclar { get; set; }
        public IkilileriAl(string sayilar)
        {
            this.sayilar = sayilar;
        }

        public string Result()
        {
            // Sayilar string'ini boşluklara göre böl ve int dizisine dönüştür
            sonuclar = sayilar
                .Split(' ')          // Boşluklara göre böl
                .Select(int.Parse)   // Her bir parçayı int'e dönüştür
                .ToArray();          // Int dizisine çevir

            // İkili toplama veya karesini alma işlemi
            for (int i = 0; i < sonuclar.Length; i += 2)
            {
                if (i + 1 < sonuclar.Length) // Sonraki elemanın var olup olmadığını kontrol et
                {
                    if (sonuclar[i] != sonuclar[i + 1])
                        sonSonuclar += (sonuclar[i] + sonuclar[i + 1]) + " ";
                    else
                        sonSonuclar += Math.Pow(sonuclar[i] + sonuclar[i+1], 2) + " "; // Sayının karesini al
                }
                else
                {
                    sonSonuclar += sonuclar[i] + " "; // Tek sayı kalmışsa onu ekle
                }
            }

            return sonSonuclar.Trim(); // Fazladan boşluğu kaldır
        }
    }
}
