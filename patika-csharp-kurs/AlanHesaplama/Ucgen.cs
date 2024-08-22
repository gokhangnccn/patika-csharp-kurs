using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patika_csharp_kurs.AlanHesaplama
{
    public class Ucgen : Sekil
    {
        public int kenar1 { get; set; }
        public int kenar2 { get; set; }
        public int kenar3 { get; set; }
        public Ucgen(int k1, int k2, int k3)
        {
            kenar1 = k1;
            kenar2 = k2;
            kenar3 = k3;
        }

        public override double HesaplaAlan()
        {
            double s = (kenar1 + kenar2 + kenar3) / 2;
            return Math.Sqrt(s * (s - kenar1) * (s - kenar2) * (s - kenar3));
        }

        public override double HesaplaCevre()
        {
            return kenar1 + kenar2 + kenar3;
        }

        public override double HesaplaHacim()
        {
            throw new NotImplementedException("Üçgenin hacmi yoktur. Alan mı demek istediniz?");
        }
    }
}
