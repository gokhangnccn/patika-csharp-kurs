using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patika_csharp_kurs.AlanHesaplama
{
    public class Daire : Sekil
    {
        public double Cap { get; set; }

        public Daire(double cap)
        {
            Cap = cap;
        }

        public override double HesaplaAlan()
        {
            return Math.PI * Cap * Cap;
        }

        public override double HesaplaCevre()
        {
            return 2 * Math.PI * Cap;
        }

        public override double HesaplaHacim()
        {
            throw new NotImplementedException("Dairenin hacmi yoktur. Alan mı demek istediniz?");

        }
    }
}
