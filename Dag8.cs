using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Dag8 : Dag
    {
        public Dag8(string s) : base(s)
        {

        }
        public string[] debug = new string[10];

        public override void Puzzel1()
        {
            int puzzlelength = lines.Length;
            string[] keys = new string[puzzlelength];
            string[] outputvalues = new string[puzzlelength];
            for(int i = 0; i < puzzlelength; i++)
            {
                string[] s = lines[i].Split(" | ");
                keys[i] = s[0];
                outputvalues[i] = s[1];
            }
            DisplayKey[] displayKeys = new DisplayKey[puzzlelength];
            int count1478 = 0;
            for(int i = 0; i < puzzlelength; i++)
            {
                displayKeys[i] = new DisplayKey(keys[i]);
                string[] s = outputvalues[i].Split(' ');
                if(i < lines.Length -1)
                    s[3] = s[3].Remove(s[3].Length - 1);
                for (int n = 0; n < 4; n++)
                {
                    s[n] = DisplayKey.SortString(s[n]);
                    int displayvalue = -1;
                    displayvalue = displayKeys[i].KeyToInt(s[n]);
                    if (displayvalue == 1 | displayvalue == 4 | displayvalue == 7 | displayvalue == 8)
                        count1478++;
                }
            }
            this.result1 = count1478.ToString();

        }

        public override void Puzzel2()
        {
            int puzzlelength = lines.Length;
            string[] keys = new string[puzzlelength];
            string[] outputvalues = new string[puzzlelength];
            int finalsum = 0;
            for (int i = 0; i < puzzlelength; i++)
            {
                string[] s = lines[i].Split(" | ");
                keys[i] = s[0];
                outputvalues[i] = s[1];
            }
            DisplayKey[] displayKeys = new DisplayKey[puzzlelength];
            int mistakecount = 0;
            for (int i = 0; i < puzzlelength; i++)
            {
                displayKeys[i] = new DisplayKey(keys[i]);
                string[] s = outputvalues[i].Split(' ');
                if (i < lines.Length - 1)
                    s[3] = s[3].Remove(s[3].Length - 1);
                int linevalue = 0;
                int[] display = new int[4];
                for (int n = 0; n < 4; n++)
                {
                    s[n] = DisplayKey.SortString(s[n]);
                    int displayvalue = displayKeys[i].KeyToInt(s[n]);
                    display[n] = displayvalue;
                }
                linevalue += 1000 * display[0];
                linevalue += 100 * display[1];
                linevalue += 10 * display[2];
                linevalue += display[3];
                for(int x = 0; x < 4; x++)
                {
                    if (display[x] < 0)
                        mistakecount++;
                }    
                finalsum += linevalue;
            }
            this.debug[0] = mistakecount.ToString();
            this.result2 = finalsum.ToString();
        }
    }

    class DisplayKey
    {
        public string[] keys = new string[10];

        public DisplayKey(string s)
        {
            string[] unknownkeys = s.Split(' ');
            int possiblevalue = -1;
            List<int> remainingkeys = new List<int>();
            for (int i = 0; i < 10; i++)
                remainingkeys.Add(i);
            for (int i = 0; i < 10; i++)
            {
                unknownkeys[i] = SortString(unknownkeys[i]);
                possiblevalue = Detect1478(unknownkeys[i]);
                if(remainingkeys.Contains(possiblevalue))
                    keys[possiblevalue] = unknownkeys[i];
                possiblevalue = -1;
            }
            remainingkeys.Remove(1);
            remainingkeys.Remove(4);
            remainingkeys.Remove(7);
            remainingkeys.Remove(8);
            for (int i = 0; i < 10; i++)
            {
                possiblevalue = Detect6(unknownkeys[i]);
                if (remainingkeys.Contains(possiblevalue))
                    keys[possiblevalue] = unknownkeys[i];
            }
            remainingkeys.Remove(6);
            for (int i = 0; i < 10; i++)
            {
                possiblevalue = Detect253(unknownkeys[i]);
                if (remainingkeys.Contains(possiblevalue))
                    keys[possiblevalue] = unknownkeys[i];
            }
            remainingkeys.Remove(2);
            remainingkeys.Remove(5);
            remainingkeys.Remove(3);
            for (int i = 0; i < 10; i++)
            {
                possiblevalue = Detect90(unknownkeys[i]);
                if (remainingkeys.Contains(possiblevalue))
                    keys[possiblevalue] = unknownkeys[i];
            }
            int succescount = 0;
            for(int i = 0; i < 10; i++)
            {
                if (keys[i] != null)
                    succescount++;
            }
            if (succescount < 10)
                throw new Exception("no match found");

        }

        public int Detect1478(string s)
        {
            if (s.Length == 2)
                return 1;
            else if (s.Length == 3)
                return 7;
            else if (s.Length == 4)
                return 4;
            else if (s.Length == 7)
                return 8;
            else
                return -1;
        }

        public int Detect6(string s)
        {
            if (!(s.Length == 6))
                return -1;
            int compare7 = CountCharMatch(s, keys[7]);
            if(compare7 == 2)
                return 6;
            return -1;
        }

        public int Detect253(string s)
        {
            if (!(s.Length == 5))
                return -1;
            int compare4 = CountCharMatch(s, keys[4]);
            int compare7 = CountCharMatch(s, keys[7]);
            if (compare4 == 2)
                return 2;
            if (compare4 == 3)
            {
                if(compare7 == 2)
                    return 5;
                if (compare7 == 3)
                    return 3;
            }
            return -1;
        }

        public int Detect90(string s)
        {
            int compare5 = CountCharMatch(s, keys[5]);
            int compare7 = CountCharMatch(s, keys[7]);
            if (s.Length == 6)
            {
                if (compare5 == 5 && compare7 == 3)
                    return 9;
                if (compare5 == 4)
                    return 0;
            }
            return -1;

        }

        public int CountCharMatch(string a, string b)
        {
            string short1;
            string long1;
            int count = 0;
            if(a.Length >= b.Length)
            {
                long1 = a;
                short1 = b;
            }
            else
            {
                long1 = b;
                short1 = a;
            }
            for (int i = 0; i < short1.Length; i++)
                if (long1.Contains(short1[i]))
                    count++;
            return count;
        }

        public int KeyToInt(string s)
        {
            for(int i = 0; i < 10; i++)
            {
                if (s == keys[i])
                    return i;
            }
            return -1;
        }

        public static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
