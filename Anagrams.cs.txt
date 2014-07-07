using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class Anagrams
    {

        public static bool IsAnagram(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
                return false;
            if (s1.Length != s2.Length)
                return false;

            foreach (char c in s2)
            {
                int iy = s1.IndexOf(c);
                if (iy >= 0)
                {
                    s1 = s1.Remove(iy, 1);
                }
            }

            return string.IsNullOrEmpty(s1);
        }
        
        
        
        int GetMaximumSubset(string[] words)
        {

            int i,j;
            int countAnagram=0;

            for (i = 0; i < words.Length - 1; i++)
            {
                for (j = i + 1; j < words.Length; j++)
                {
                    if (IsAnagram(words[i], words[j]))
                    {
                        countAnagram++;
                        break;
                    }
                }

            }

            return words.Length - countAnagram;
        }

        
        

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            Anagrams anagramSolver = new Anagrams();
            do
            {
                string[] words = input.Split(',');
                Console.WriteLine(anagramSolver.GetMaximumSubset(words));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}

