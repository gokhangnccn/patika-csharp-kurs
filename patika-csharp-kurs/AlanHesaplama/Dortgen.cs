using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patika_csharp_kurs.AlanHesaplama
{
    public class Dortgen : Sekil
    {
        public double kenar1 { get; set; }
        public double kenar2 { get; set; }


        public Dortgen(int k1, int k2)
        {
            kenar1 = k1;
            kenar2 = k2;
        }
        public override double HesaplaAlan()
        {
            return kenar1 * kenar2;
        }

        public override double HesaplaCevre()
        {
            return (kenar1 + kenar2) * 2;
        }

        public override double HesaplaHacim()
        {
            throw new NotImplementedException("Dörtgenin hacmi yoktur. Alan mı demek istediniz?");
        }
    }
}
