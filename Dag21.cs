using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Dag21 : Dag
    {
        public Dag21(string s) : base(s)
        {

        }
        public int p1pos;
        public int p2pos;
        public int g1dielastroll = 0;
        public int p1score = 0;
        public int p2score = 0;

        public override void Puzzel1()
        {
            bool testdata = false;
            if(testdata)
            {
                p1pos = 4;
                p2pos = 8;
            }
            else
            {
                p1pos = 8;
                p2pos = 1;
            }
            bool player = true;
            while(doTurn(player))
            {
                player = !player;
            }
            int score;
            if (player)
                score = p2score * g1dielastroll;
            else
                score = p1score * g1dielastroll;
            this.result1 = score.ToString();

        }

        public int ThrowG1Die()
        {
            g1dielastroll++;
            int currentroll = g1dielastroll % 100;
            if(currentroll == 0)
                currentroll = 100;
            return currentroll;
        }

        public bool doTurn(bool player)
        {
            int steps = ThrowG1Die() + ThrowG1Die() + ThrowG1Die();
            if (player)
            {
                p1pos += steps;
                p1pos = p1pos % 10;
                if (p1pos == 0)
                    p1pos = 10;
                p1score += p1pos;
                if (p1score >= 1000)
                    return false;
            }
            else
            {
                p2pos += steps;
                p2pos = p2pos % 10;
                if (p2pos == 0)
                    p2pos = 10;
                p2score += p2pos;
                if (p2score >= 1000)
                    return false;
            }
            return true;
        }

        List<diracGameState> nextstates;
        Dictionary<int, int> stepgrowth
        public override void Puzzel2()
        {
            //throw new NotImplementedException();
            long[] p1scores = new long[30];
            long[] p2scores = new long[30];
            List<diracGameState> currentstates = new List<diracGameState>();
            diracGameState initial = new diracGameState(0, 0, 8, 1, 0);
            currentstates.Add(initial);
            nextstates = new List<diracGameState>();
            stepgrowth = populateGrowthDict();
            foreach(diracGameState state in currentstates)
            {
                //pak een staat. bereken de 7 volgende staten die kunnen ontstaan. voeg ze in de juiste aantallen toe aan de lijst nextstates, als er al identieke staten in staan tel het aantal er bij op
                //als een staat 21 punten bereikt, voeg de teller aan een relevante winnaar teller toe en gooi ze weg
            }


        }

        public Dictionary<int, int> populateGrowthDict()
        {
            Dictionary<int, int> stepgrowth = new Dictionary<int, int>();
            stepgrowth.Add(3, 1);
            stepgrowth.Add(4, 3);
            stepgrowth.Add(5, 6);
            stepgrowth.Add(6, 7);
            stepgrowth.Add(7, 6);
            stepgrowth.Add(8, 3);
            stepgrowth.Add(9, 1);
            return stepgrowth;
            /* 
             * 1/27 3 stappen verder
             * 3/27 4 stappen verder
             * 6/27 5 stappen verder
             * 7/27 6 stappen verder
             * 6/27 7 stappen verder
             * 3/27 8 stappen verder
             * 1/27 9 stappen verder
             */
        }

        public void diracTurn(bool player, diracGameState state)
        {
            int currentpos;
            int newpoints = 0;
            if (player)
                currentpos = state.p1pos;
            else
                currentpos = state.p2pos;
            for(int i = 3; i < 10; i++)
            {
                currentpos += i;
                currentpos = currentpos % 10;
                if (currentpos == 0)
                    currentpos = 10;
                newpoints = currentpos;
                if (player)
                    newpoints += state.p1score;
                else
                    newpoints += state.p2score;
                //maak een diracgamestate aan met nieuwe positie en score, check of ie al in nextstates zit, voeg m toe of tel count er bij op (state.count * stepgrowth[i])
            }
        }
    }

    public class diracGameState
    {
        public int p1score;
        public int p2score;
        public int p1pos;
        public int p2pos;
        public long universecount;
        public diracGameState(int score1, int score2, int pos1, int pos2, long count)
        {
            p1score = score1;
            p2score = score2;
            p1pos = pos1;
            p2pos = pos2;
            universecount = count;
        }
    }
}
