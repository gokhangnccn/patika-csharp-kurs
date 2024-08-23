﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patika_csharp_kurs
{
    public class KarakterleriDegistir
    {

        public void ChangeFirstAndLastChars(string input)
        {

            string[] words = input.Split(' ');
            string[] newWords = new string[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                char firstChar = words[i][0];
                char lastChar = words[i][words[i].Length - 1];

                string newWord = lastChar + words[i].Substring(1, words[i].Length - 2) + firstChar;
                newWords[i] = newWord;

            }

            string output = string.Join(" ", newWords);
            Console.WriteLine($"Yeni metin: {output}");
        }
    }
}
