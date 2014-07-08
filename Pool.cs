using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;

namespace CodeJam
{
    class Pool
    {
        int RackMoves(int[] triangle)
        {
            //Your code goes here
            //according to the rule given they can only be two possibilities
            //4th is not consider as it is fixed place for 8th ball(black)
            int Moves = 0;
            List<int> Striplist = new List<int>(triangle.Length);
            Striplist.Add(0);
            Striplist.Add(3);
            Striplist.Add(5);
            Striplist.Add(7);
            Striplist.Add(9);
            Striplist.Add(10);
            Striplist.Add(12);

            List<int> Solidlist = new List<int>(triangle.Length);
            Solidlist.Add(1);
            Solidlist.Add(2);
            Solidlist.Add(6);
            Solidlist.Add(8);
            Solidlist.Add(11);
            Solidlist.Add(13);
            Solidlist.Add(14);
            int SolidCount = 0, StripCount = 0;
            int EigthBallPlace = Array.IndexOf(triangle, 8);
           // Console.WriteLine(EigthBallPlace);
           // Console.ReadKey();
           
            //counting no of moves  if strip ball is not place in there correct position
          /*  foreach (int i in Striplist)
            {
                if (triangle[Striplist[i]] < 8)
                {
                    StripCount++;
                }
            } */

            for (int i = 0; i < Striplist.Count; i++)
            {
                if (triangle[Striplist[i]] < 8)
                {
                    StripCount++;
                }
            }

                //counting no of moves if solid ball is not palce in there correct position 
            for (int i = 0; i < Solidlist.Count;i++)
            {
                if (triangle[Solidlist[i]] > 8)
                {
                    SolidCount++;
                }
            }

            if (StripCount > 3)
            {
                StripCount = 7 - StripCount;
            }

            if (SolidCount > 3)
            {
                SolidCount = 7 - SolidCount;
            }

            //if 8th ball is in correct position then add one more move
            if (EigthBallPlace != 4)
            {
                Moves++;
            }

            Moves += (SolidCount + StripCount) / 2;
            return Moves;
          
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            Pool pool = new Pool();
            String input = Console.ReadLine();
            do
            {
                int[] triangle = Array.ConvertAll<string, int>(input.Split(','), delegate(string s) { return Int32.Parse(s); });
                Console.WriteLine(pool.RackMoves(triangle));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion

    }
}