using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patika_csharp_kurs.AlanHesaplama
{
    public class Kup : Sekil
    {
        public int kenar { get; set; }

        public Kup(int k) {
            kenar = k;
        }

        public override double HesaplaAlan()
        {
            return 6 * (kenar * kenar);
        }

        public override double HesaplaCevre()
        {
            return kenar * 12;
        }

        public override double HesaplaHacim()
        {
            return kenar * kenar * kenar;
        }
    }
}
