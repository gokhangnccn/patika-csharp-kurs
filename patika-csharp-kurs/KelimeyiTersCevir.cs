using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patika_csharp_kurs
{
    public class KelimeyiTersCevir
    {

        public string kelimeyiTersCevir(string cumle)
        {
            string[] dizi = cumle.Split(' ');
            string str = "";
            for (int i = 0; i < dizi.Length; i++)
            {
                for (int j = dizi[i].Length - 1; j >= 0; j--)
                {
                    str += dizi[i][j];
                }
                str += " ";
            }
            return str;
        }

    }
}
