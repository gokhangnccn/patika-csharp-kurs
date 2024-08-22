using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patika_csharp_kurs
{
    public class IndextekiniCikar
    {
        string str = "Algoritma";
        string bos = "";
        public string indextekiniCikar(int index)
        {
            for(int i=0; i<str.Length; i++)
            {
                if (i != index)
                {
                    bos += str[i];
                }
            }
            return bos;
        }
    }
}
