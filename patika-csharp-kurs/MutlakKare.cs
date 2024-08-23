using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patika_csharp_kurs
{
    public class MutlakKare
    {
        public string sayiDizisi { get; set; }
        public int[] sonucDizisi { get; set; }
        public int farkToplami { get; set; }
        public double mutlakKareleri { get; set; }
        string str;

        public MutlakKare(string dizi)
        {
            sayiDizisi = dizi;
        }

        public string Result()
        {
            sonucDizisi = sayiDizisi
                .Split(' ')          
                .Select(int.Parse)   
                .ToArray();

            for(int i = 0; i<sonucDizisi.Length; i++)
            {
                if (sonucDizisi[i] <= 67)
                {
                    farkToplami += Math.Abs(sonucDizisi[i] - 67);
                }else
                {
                    mutlakKareleri += Math.Pow(Math.Abs(sonucDizisi[i] - 67), 2);
                }
            }
            str = $"Sayıların fark toplamı {farkToplami} dır." +
                $"\nSayıların mutlak fark karelerinin toplamı {mutlakKareleri}";
            return str;
        }
    }
}
