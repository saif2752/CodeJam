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

            string s = circle;
            //int val= k % s.Length;   if k start from 0
            int val = (k-1) % s.Length;  //as k is starting from 1 ,so k-1
            int index_starting = val;
            char starting_char = s[index_starting];
            //List<char> listupper1 = new List<char>();    // list for upper case alphabet 
            //List<char> listlower = new List<char>();    //list for lowercase alphabet
            char[] listupper = new char [s.Length];
            char[] listlower = new char [s.Length];
            char[] arr = s.ToCharArray();
            int lowercount = 0, uppercount = 0;
            int end_condition;
            foreach (char char_val in arr)
            {
                if (char.IsLower(char_val))
                {
                    listlower[lowercount++] = char_val;
                }
                else
                {
                    listupper[uppercount++] = char_val;
                }
            }

            //sorting list
            //listlower.Sort();
            //listupper.Sort();
            Array.Sort(listlower);
            Array.Sort(listupper);

            if (lowercount >= uppercount)
            {
                end_condition = uppercount * 2;
            }
            else
            {
                end_condition = lowercount * 2;
            }
            if (end_condition == 0) //this is the case for all uppercase or all lowercase
            {
                return "";
            }

            char[] checking = new char [s.Length];
            int count = 0;
            while(true)
            {
                
                
                if (char.IsLower(starting_char))
                {
                    if (!check(checking, starting_char))            
                    {
                        checking[count++] = starting_char;
                        for (int i = 0; i < listupper.Length; i++)
                        {
                            if (!check(checking, listupper[i]))
                            {
                                checking[count++] = listupper[i];
                                break;
                            }
                        }
                    }
                }


                if (char.IsUpper(starting_char))
                {
                    if (!check(checking,starting_char))            
                    {
                        checking[count++] = starting_char;
                        for (int i = 0; i < listlower.Length; i++)
                        {
                            if (!check(checking, listlower[i]))
                            {
                                checking[count++] = listlower[i];
                                break;
                            }
                        }
                    }
                }


                if (count == end_condition)
                    break;
                else if (count != end_condition)
                {
                    index_starting = Next_Index(index_starting, arr, checking, k);
                    starting_char = arr[index_starting];
                }
            }


            for (int l = 0; l < count; l=l+2)
            {
                dates += checking[l];
                dates += checking[l + 1];
                dates += " ";
            }

            
            return dates.Trim(' ');
          
        }


        public int Next_Index(int index_starting, char[] arr, char[] checking, int k)
        {
            int next_index = index_starting;
            int count3 = 0;
            do
            {
                if (check(checking, arr[next_index]))
                    next_index = (next_index + 1) % arr.Length;
                else
                {
                    count3++;
                    break;
                }
            } while (true);


            for (int i = (next_index + 1) % arr.Length; true; i = (i + 1) % arr.Length)
            {
                if (k == 1)
                {
                    return next_index;
                }
                if (!check(checking, arr[i]))
                    count3++;
                if (count3 == k)
                {
                    next_index = i;
                    break;
                }
            }
            return next_index;
        }

        public Boolean check(char[] remove, char char_check)
        {

            foreach (char c in remove)
            {
                if (char_check == c)
                    return true;
            }
            return false;
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