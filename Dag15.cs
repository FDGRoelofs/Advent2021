using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Dag15 : Dag
    {
        public Dag15(string s) : base(s)
        {

        }

        public int[,] riskmap;
        //public int[,] risksum;
        public Dijkstranode[,] allnodes;
        public int dimension;

        public string[] debug = new string[10];

        public override void Puzzel1()
        {
            dimension = lines.Length;
            riskmap = new int[dimension,dimension];
            allnodes = new Dijkstranode[dimension, dimension];
            for (int y = 0; y < dimension; y++)
                for (int x = 0; x < dimension; x++)
                {
                    riskmap[y, x] = getRisk(x, y, 0);
                    allnodes[y, x] = new Dijkstranode(x, y, riskmap[y, x]);
                }
            Dijkstranode target = allnodes[dimension - 1, dimension - 1];
            Dijkstra(target);
            this.result1 = target.risksum.ToString();
            if(dimension < 25)
            {
                for (int y = 0; y < dimension; y++)
                {
                    for (int x = 0; x < dimension; x++)
                    {
                        debug[3] += allnodes[y, x].risksum.ToString();
                        debug[3] += ',';
                    }
                    debug[3] += 'w';
                    debug[3] += '\n';
                }
            }
            
        }

        public override void Puzzel2()
        {
            dimension = lines.Length * 5;
            riskmap = new int[dimension, dimension];
            allnodes = new Dijkstranode[dimension, dimension];
            for (int y = 0; y < dimension; y++)
                for (int x = 0; x < dimension; x++)
                {
                    int diagonal = x / 100 + y / 100;
                    riskmap[y, x] = getRisk(x%100,y%100,diagonal);
                    allnodes[y, x] = new Dijkstranode(x, y, riskmap[y, x]);
                }
            Dijkstranode target = allnodes[dimension - 1, dimension - 1];
            Dijkstra(target);
            this.result2 = target.risksum.ToString();

        }

        public int getRisk(int x, int y, int diagonal)
        {
            int val = 0;
            val = Int32.Parse("" + lines[y][x]);
            val += diagonal;
            if (val > 9)
                val -= 9;
            return val;
        }

        public void Dijkstra(Dijkstranode target)
        {
            List < Dijkstranode > tovisit = new List<Dijkstranode>();
            Dijkstranode origin = allnodes[0,0];
            origin.risksum = 0;
            addNeighbours(origin, tovisit);
            while(tovisit.Count > 0) //target.risksum == int.MaxValue
            {
                int visitcount = tovisit.Count;
                Dijkstranode nextvisit = origin; // zou nooit origin moeten blijven
                int lowest = int.MaxValue;
                int visitedIndex = -1;
                for(int i = 0; i < visitcount; i++)
                {
                    int nextriskvalue = tovisit[i].lowestneighbour(dimension, allnodes).risksum + tovisit[i].ownrisk;
                    if (nextriskvalue < lowest)
                    {
                        nextvisit = tovisit[i];
                        lowest = nextriskvalue;
                        visitedIndex = i;
                    }
                }
                Dijkstranode previous = nextvisit.lowestneighbour(dimension, allnodes);
                //nextvisit.prev = previous;
                nextvisit.setRisksum();
                tovisit.RemoveAt(visitedIndex);
                addNeighbours(nextvisit, tovisit);
            }
        }

        public void addNeighbours(Dijkstranode target, List<Dijkstranode> tovisit)
        {
            List<int[]> options = target.GetNeighbours(dimension);
            List<Dijkstranode> newvisits = new List<Dijkstranode>();
            foreach(int[] elem in options)
            {
                if(allnodes[elem[1],elem[0]].risksum == int.MaxValue && allnodes[elem[1], elem[0]].visitplanned == false)
                {
                    Dijkstranode next = allnodes[elem[1], elem[0]];
                    next.prev = target;
                    tovisit.Add(next);
                    next.visitplanned = true;
                }
            }
        }
    }

    class Dijkstranode
    {
        public int ownrisk
        { get; set; }
        public int risksum
        { get; set; }
        public (int x, int y) loc
        { get; set; }
        public Dijkstranode prev
        { get; set; }
        public bool visitplanned
        { get; set; }
        public Dijkstranode(int x, int y, int risk)
        {
            ownrisk = risk;
            loc = (x,y);
            risksum = int.MaxValue;
        }

        public List<int[]> GetNeighbours(int dimension)
        {
            List<int[]> result = new List<int[]>();
            if (loc.x > 0)
                result.Add(new int[2] { loc.x - 1, loc.y });
            if (loc.x < dimension -1)
                result.Add(new int[2] { loc.x + 1, loc.y });
            if (loc.y > 0)
                result.Add(new int[2] { loc.x, loc.y - 1 });
            if (loc.y < dimension -1)
                result.Add(new int[2] { loc.x, loc.y + 1 });
            return result;
        }

        public void setRisksum()
        {
            risksum = ownrisk + prev.risksum;
        }

        public Dijkstranode lowestneighbour(int dimension, Dijkstranode[,] allnodes)
        {
            int lowest = int.MaxValue;
            Dijkstranode nextvisit = null;
            if (loc.x > 0 && allnodes[loc.y, loc.x - 1].risksum < lowest)
            {
                nextvisit = allnodes[loc.y, loc.x - 1];
                lowest = allnodes[loc.y, loc.x - 1].risksum;
            }
            if (loc.x < dimension -1 && allnodes[loc.y, loc.x + 1].risksum < lowest)
            {
                nextvisit = allnodes[loc.y, loc.x + 1];
                lowest = allnodes[loc.y, loc.x + 1].risksum;
            }
            if (loc.y > 0 && allnodes[loc.y - 1, loc.x].risksum < lowest)
            {
                nextvisit = allnodes[loc.y - 1, loc.x];
                lowest = allnodes[loc.y - 1, loc.x].risksum;
            }
            if (loc.y < dimension -1 && allnodes[loc.y + 1, loc.x].risksum < lowest)
            {
                nextvisit = allnodes[loc.y + 1, loc.x];
                lowest = allnodes[loc.y + 1, loc.x].risksum;
            }
            return nextvisit;
        }
    }
}
