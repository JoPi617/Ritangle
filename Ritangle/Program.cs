using static System.Console;
using System;
using static System.Convert;

namespace Ritangle
{
    public class Ritnagle
    {
        private static List<string> Primes(int max)
        {
            bool[] primes = new bool[max];
            Array.Fill(primes, true);

             for (int i = 2; i * i < max; i++)
            {
                if (primes[i])
                {
                    for (int j = i * i; j < max; j += i)
                        primes[j] = false;
                }
            }


            var output = new List<string>();
            for (uint i = 0; i < max; i++)
            {
                if (primes[i])
                {
                    output.Add(i.ToString());
                    //WriteLine(i);
                }
            }

            return output;
        }

        static int ToValue(char cha)
        {
            switch (cha)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '0':
                    return Convert.ToInt32($"{cha}"); //return int value (not asc value)
                default:
                    return cha - 87; //if not num, return asc value -87: a=10, etc.
            }
        }

        static char ToSymbol(int num)
        {
            switch (num)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 0:
                    return num.ToString()[0]; //return number as char
                default:
                    return (char)(num + 87); //return corresponding letter: 10=a, etc.
            }
        }

        static int ToDec(string input, int _base)
        {
            int total = 0;
            int exp = input.Length - 1;
            for (int i = 0; i < input.Length; i++)
            {//for each char, add value x place value
                int value = Convert.ToInt32(ToValue(input[i]) * Math.Pow(_base, exp));
                total += value;
                exp--;
            }
            return total;
        }

        static string toBase(int input, int _base)
        {
            int running = input;
            string mid = "";

            for (int i = 1; running != 0; i++)
            {//add mod of number by base, then change to int division
                mid += ToSymbol(Convert.ToInt32(running % _base));
                running = Convert.ToInt32(running / _base);
            }

            string output = "";
            for (int i = mid.Length - 1; i > -1; i--) //reverse for desired output
            {
                output += mid[i];
            }
            return output;
        }

        private static bool isOnes(string input)
        {
            return input.All(cha => cha == '1');
        }


        private static void Main()
        {
            for (int num = 8191; num < 10000; num++)
            {
                var count = 0;
                for (int _base = 2; _base < num; _base++)
                {
                    var inBase = toBase(num, _base);
                    if (isOnes(inBase))
                    {
                        count++;
                        if (num==8191) WriteLine(_base);
                    }
                }

                if (count == 3 && num!=31)
                {
                    WriteLine(num);
                    break;
                }
            }
        }
    }
}


