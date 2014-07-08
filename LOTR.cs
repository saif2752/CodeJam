using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;
namespace CodeJam
{
    class LOTR
    {
        int GetMinimum(int[] replies)
        {
            //Your code goes here
            var Arr = replies;

            int [] DistinctResult = Arr.Distinct().ToArray();
            int Sum = 0;
            int Count = DistinctResult.Count();
            int Pair;
            // int[] array2 = new int[replies.Length];
            for (int i = 0; i < DistinctResult.Length; i++)
            {
                int temp = DistinctResult[i];
                int[] array2 = Array.FindAll(Arr,
                     element => element == temp);

                int value = array2.Length;
                temp = DistinctResult[i] ;

               /* if (value == 0)
                {
                    Sum = Sum + value;
                }

                else if (value == 1)
                {
                    if ((value % 2) != 0)
                    {
                        value = (value / 2) + 1;
                    }
                    else
                    {
                        value = value / 2;
                    }

                    Sum = Sum + (value * 2);
                } */

                
                 if (value == 1)
                {
                    Sum = Sum + (temp + 1);
                }
                

                else
                {

                    //  if (value <= temp + 1)
                    //    value = 1;
                    if ((value % (temp + 1)) != 0)
                    {

                         Pair = (int)((value) / (temp + 1)) +1;

                    }
                    else
                    {
                        Pair = (int)((value) / (temp + 1));
                       
                    }
                    Sum += Pair * (temp+1);

                    /* if ((value % 2) != 0)
                     {
                         value = (value / 2) + 1;
                     }
                     else
                     {
                         value = value / 2;
                     }

                    // Sum += (value * 2);

                     //int count = value / (temp + 1);

                     //Sum += count * (temp + 1) ;
                 }
              }

                 /*foreach (int d )
                {
                  Console.WriteLine(d);
                
                 }*/
                    // Sum++;
                 // Console.WriteLine(Sum);
                   //Console.ReadKey();
                   
                }
               
            }
            return Sum;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            LOTR lotr = new LOTR();
            String input = Console.ReadLine();
            do
            {
                int[] replies = Array.ConvertAll<string, int>(input.Split(','), delegate(string s) { return Int32.Parse(s); });
                Console.WriteLine(lotr.GetMinimum(replies));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion

    }
}