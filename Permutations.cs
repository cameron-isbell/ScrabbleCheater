/*
    Code Sourced from https://www.geeksforgeeks.org/write-a-c-program-to-print-all-permutations-of-a-given-string/
*/
using System;
using System.Collections;

namespace Scrabble
{
    class Permutations {

        private static ArrayList permList;

        public static ArrayList Start(string str) {
            permList = new ArrayList();
            permute(str, 0, str.Length-1);
            return permList;
        }

        private static void permute(String str, int l, int r)
        {
            if (l == r)
                permList.Add(str.ToUpper());
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = swap(str, l, i);
                    permute(str, l + 1, r);
                    str = swap(str, l, i);
                }
            }
        }
 
        /**
        * Swap Characters at position
        * @param a string value
        * @param i position 1
        * @param j position 2
        * @return swapped string
        */
        private static String swap(String a, int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i] ;
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }
    }
}