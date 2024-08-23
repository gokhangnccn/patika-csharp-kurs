using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patika_csharp_kurs
{
    public class YanYanaKontrolEt
    {
        public void Result(string input)
        {
            string sessizHarfler = "zyvtşsrpnrmlkhjğgdçcb";
            string[] words = input.Split(' ');


            bool[] result = new bool[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length - 1; j++)
                {
                    if (sessizHarfler.Contains(words[i][j]) && sessizHarfler.Contains(words[i][j + 1]))
                    {
                        result[i] = true;
                        break;
                    }
                    result[i] = false;
                }

            }
            string output = string.Join(" ", result);
            Console.WriteLine("Output : " + output);
        }
    }
}
