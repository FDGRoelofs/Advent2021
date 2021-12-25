using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

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
            if (testdata)
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
            while (doTurn(player))
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
            if (currentroll == 0)
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

        List<diracGameState> nextstates = new List<diracGameState>();
        Dictionary<int, int> stepgrowth;
        List<diracGameState> currentstates = new List<diracGameState>();
        List<diracGameState> completestates = new List<diracGameState>();
        public override void Puzzel2()
        {
            diracGameState initial = new diracGameState(0, 0, 4, 8, 1);
            currentstates.Add(initial);
            stepgrowth = populateGrowthDict();
            bool player1turn = true;
            while(currentstates.Count > 0)
            {
                foreach (diracGameState state in currentstates)
                {
                    diracTurn(player1turn, state);
                }
                currentstates = nextstates;
                nextstates = new List<diracGameState>();
                player1turn = !player1turn;
                checkwinners();
            }
            BigInteger p1winners = new BigInteger(0);
            BigInteger p2winners = new BigInteger(0);
            foreach (diracGameState state in completestates)
            {
                if(state.p1score > 20)
                    p1winners += state.universecount;
                if (state.p2score > 20)
                    p2winners += state.universecount;
                /*if (state.p1score > 20 && state.p2score > 20)
                    this.result1 = "error"; //deze check heeft een bug gefixed, maar is nu niet meer nodig */
            }
            if (p1winners > p2winners)
                this.result2 = p1winners.ToString();
            if(p2winners > p1winners)
                this.result2 = p2winners.ToString();
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
            for (int i = 3; i < 10; i++) //maak een diracgamestate aan met nieuwe positie en score, check of ie al in nextstates zit, voeg m toe of tel count er bij op (state.count * stepgrowth[i])
            {
                int nextpos = currentpos + i;
                nextpos = nextpos % 10;
                if (nextpos == 0)
                    nextpos = 10;
                newpoints = nextpos;
                if (player)
                {
                    bool found = false;
                    newpoints += state.p1score;
                    foreach (diracGameState elem in nextstates)
                    {
                        if (elem.p1pos == nextpos && elem.p2pos == state.p2pos && elem.p1score == newpoints && elem.p2score == state.p2score)
                        {
                            elem.universecount *= stepgrowth[i];
                            found = true;
                        }
                        if (found)
                            break;
                    }
                    if (!found)
                        nextstates.Add(new diracGameState(newpoints, state.p2score, nextpos, state.p2pos, state.universecount * stepgrowth[i]));

                }
                else
                {
                    bool found = false;
                    newpoints += state.p2score;
                    foreach (diracGameState elem in nextstates)
                    {
                        if (elem.p1pos == state.p1pos && elem.p2pos == nextpos && elem.p1score == state.p1score && elem.p2score == newpoints)
                        {
                            elem.universecount += stepgrowth[i] * state.universecount;
                            found = true;
                        }
                        if (found)
                            break;
                    }
                    if (!found)
                        nextstates.Add(new diracGameState(state.p1score, newpoints, state.p1pos, nextpos, state.universecount * stepgrowth[i]));
                }
            }
        }

        public void checkwinners()
        {
            foreach (diracGameState state in currentstates)
            {
                if (state.p1score >= 21 || state.p2score >= 21)
                    completestates.Add(state);
                else
                    nextstates.Add(state);
            }
            currentstates = nextstates;
            nextstates = new List<diracGameState>();
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