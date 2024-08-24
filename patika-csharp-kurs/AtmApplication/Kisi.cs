using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patika_csharp_kurs.AtmApplication
{
    public class Kisi
    {

        public int id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string sifre { get; set; }
        public int bakiye { get; set; }



        public Kisi(int id, string ad, string soyad, string sifre, int bakiye)
        {
            this.ad = ad;
            this.id = id;
            this.soyad = soyad;
            this.sifre = sifre;
            this.bakiye = bakiye;

        }
    }
}
