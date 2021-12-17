using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Dag14 : Dag
    {
        public Dag14(string s) : base(s)
        {

        }

        public override void Puzzel1()
        {
            this.result1 = "in Haskell";
        }


        public override void Puzzel2()
        {
            polymertracker solver = new polymertracker(lines);
            solver.insertpolymers(40);
            this.result2 = solver.getAnswer().ToString();
            
        }
    }

    class polymertracker
    {
        Dictionary<string, long> polymercounter = new Dictionary<string, long>();
        Dictionary<string, char> inserterRules = new Dictionary<string, char>();
        Dictionary<string, long> currentcounter;
        Dictionary<char, long> charcounter = new Dictionary<char, long>();
        public polymertracker(string[] lines)
        {
            for (int i = 2; i < lines.Length; i++)
            {
                string[] rule = lines[i].Split(" -> ");
                inserterRules.Add(rule[0], rule[1][0]);
            }
            foreach (KeyValuePair<string, char> elem in inserterRules)
            {
                polymercounter.Add(elem.Key, 0);
            }
            currentcounter = new Dictionary<string, long>(polymercounter);
            for (int i = 65; i < 91; i++)
            {
                charcounter.Add((char)i, 0); //FCHBKPONSV
            }
            initialisecounter(lines[0]);
        }

        public void initialisecounter(string s)
        {
            for(int i = 0; i < s.Length - 1; i++)
            {
                string currentpolymer = "" + s[i] + s[i + 1];
                incrementcounter(currentpolymer, 1, currentcounter);
                charcounter[s[i]] += 1;
            }
            charcounter[s[s.Length - 1]]++;
        }

        public void incrementcounter(string polymer, long val, Dictionary<string,long> target)
        {
            target[polymer] += val;
        }

        public void insertpolymers(long repeat)
        {
            if (repeat == 0)
                return;
            Dictionary<string, long> nextcounter = new Dictionary<string, long>(polymercounter);
            foreach(KeyValuePair<string,long> elem in currentcounter)
            {
                char inserterchar = inserterRules[elem.Key];
                string left = "" + elem.Key[0] + inserterchar;
                string right = "" + inserterchar + elem.Key[1];
                nextcounter[left] += elem.Value;
                nextcounter[right] += elem.Value;
                charcounter[inserterchar] += elem.Value;
            }

            currentcounter = nextcounter;
            if (repeat > 0)
                insertpolymers(repeat - 1);
        }


        public long getAnswer()
        {
            long lowest = long.MaxValue;
            long highest = long.MinValue;
            foreach (KeyValuePair<char, long> elem in charcounter)
            {
                if (elem.Value > 0)
                    if (elem.Value < lowest)
                        lowest = elem.Value;
                if (elem.Value > highest)
                    highest = elem.Value;
            }
            return highest - lowest;
        }
        /*public long getAnswer()
        {
            long lowest = long.MaxValue;
            long highest = long.MinValue;
            foreach(KeyValuePair<string,long> elem in currentcounter)
            {
                if(elem.Value > 0)
                    if (elem.Value < lowest)
                        lowest = elem.Value;
                if (elem.Value > highest)
                    highest = elem.Value;
            }
            return highest - lowest;
        }*/
    }
}


