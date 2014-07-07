using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class Dating
    {
        String Dates(String circle, int k)
        {
            string dates = string.Empty;
            //Your code goes here
            List<char> list = new List<char>();
        
            string newfinal = null;
            string newfinal1=null;
            string s1 = circle;
            string sample = null;
            string sample1 = null;
            string sample3 = null;
            string sample4 = null;
            char[] arr = s1.ToCharArray();
            char ch;
            List<char> listupper = new List<char>();
            List<char> listlower = new List<char>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (char.IsUpper(arr[i]))
                {
                    listupper[i] = arr[i];
                }
                else
                {
                    listlower[i] = arr[i];
                }

            }

            if (listlower.Capacity==0 || listupper.Capacity == 0)
            {
                return dates;
            }

                //string s2 = circle;
                if (s1.Length > k)
                {

                    ch = arr[k - 1];
                    // Console.WriteLine(ch);
                    //int index = s1.IndexOf(ch);
                    if (char.IsLower(ch))
                    {
                        for (int i = 0; i < arr.Length; i++)
                        {
                            char check = arr[i];
                            if (char.IsUpper(check))
                            {
                                //int j = 0;
                                // b = b + arr[i];
                                list.Add(arr[i]);
                            }
                        }

                        list.Sort();
                        char pair = list[0];
                        sample = "" + ch + pair;
                        dates = dates + sample;
                        //  Console.WriteLine(dates);
                        newfinal = arr.ToString();
                        int ix = newfinal.IndexOf(ch);
                        //Console.WriteLine(ch);
                        ix = ix + 2;
                        newfinal = newfinal.Remove(ix, 1);
                        int iy = newfinal.IndexOf(pair);
                        newfinal = newfinal.Remove(iy, 1);
                    }

                    char s = ch;
                    if (char.IsLower(s))
                    {
                        char[] arr1 = newfinal.ToCharArray();
                        char f = ch;
                        if (char.IsUpper(f))
                        {
                            for (int i = 0; i < arr1.Length; i++)
                            {
                                char check = arr1[i];
                                if (char.IsLower(check))
                                {
                                    //int j = 0;
                                    // b = b + arr[i];
                                    list.Add(arr1[i]);
                                }
                            }

                            list.Sort();
                            char pair = list[0];
                            sample1 = "" + f + pair;
                            dates = dates + sample + sample1;
                            //Console.WriteLine(dates);
                            newfinal1 = arr1.ToString();
                            int ix = newfinal1.IndexOf(ch);
                            newfinal1 = newfinal1.Remove(ix, 1);
                            int iy = newfinal1.IndexOf(pair);
                            newfinal1 = newfinal1.Remove(iy, 1);
                        }

                    }


                    if (char.IsUpper(ch))
                    {
                        for (int i = 0; i < arr.Length; i++)
                        {
                            char check = arr[i];
                            if (char.IsLower(check))
                            {
                                //int j = 0;
                                // b = b + arr[i];
                                list.Add(arr[i]);
                            }
                        }

                        list.Sort();
                        char pair = list[0];
                        sample3 = "" + ch + pair;
                        dates = dates + sample3;
                        Console.WriteLine(dates);
                        newfinal = arr.ToString();
                        int ix = newfinal.IndexOf(ch);
                        newfinal = newfinal.Remove(ix, 1);
                        int iy = newfinal.IndexOf(pair);
                        newfinal = newfinal.Remove(iy, 1);
                    }


                    s = ch;
                    if (char.IsUpper(s))
                    {
                        char[] arr2 = newfinal.ToCharArray();

                        if (char.IsLower(ch))
                        {
                            for (int i = 0; i < arr2.Length; i++)
                            {
                                char check = arr2[i];
                                if (char.IsUpper(check))
                                {
                                    //int j = 0;
                                    // b = b + arr[i];
                                    list.Add(arr2[i]);
                                }
                            }

                            list.Sort();
                            char pair = list[0];
                            sample4 = "" + ch + pair;
                            dates = dates + sample3 + sample4;
                            Console.WriteLine(dates);
                            newfinal = arr2.ToString();
                            int ix = newfinal.IndexOf(ch);
                            newfinal = newfinal.Remove(ix, 1);
                            int iy = newfinal.IndexOf(pair);
                            newfinal = newfinal.Remove(iy, 1);
                        }

                    }





                }
                return dates;
            }
        

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            Dating dating = new Dating();

            do
            {
                string[] values = input.Split(',');
                Console.WriteLine(dating.Dates(values[0], Int32.Parse(values[1])));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}