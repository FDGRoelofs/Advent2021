using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Dag12 : Dag
    {
        public Dag12(string s) : base(s)
        {

        }
        public Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        public string[] debug = new string[10];

        public override void Puzzel1()
        {
            for (int i = 0; i < lines.Length; i++)
                AddToGraph(lines[i]);
            this.result1 = FindAllRoutes(1).Count.ToString();
        }

        public override void Puzzel2()
        {
            List<List<string>> allroutes = FindAllRoutes(2);
            this.result2 = allroutes.Count.ToString();
            List<string> routestring = new List<string>();
            foreach(List<string> route in allroutes) // maakt strings van de routes om te debuggen
            {
                string routeline = "";
                foreach(string node in route)
                {
                    routeline += node;
                    routeline += ',';
                }
                routestring.Add(routeline);
                routeline += '\r';
                debug[3] += routeline;
            }
            routestring = routestring.Distinct().ToList();
            debug[0] = routestring.Count().ToString();
        }

        public void AddToGraph(string s)
        {
            string[] nodes = s.Split('-');
            //add first direction
            if(graph.ContainsKey(nodes[0]))
            {
                graph[nodes[0]].Add(nodes[1]);
            }
            else
            {
                List<string> newnodevertices = new List<string>();
                newnodevertices.Add(nodes[1]);
                graph.Add(nodes[0], newnodevertices);
            }
            //add other direction
            if (graph.ContainsKey(nodes[1]))
            {
                graph[nodes[1]].Add(nodes[0]);
            }
            else
            {
                List<string> newnodevertices = new List<string>();
                newnodevertices.Add(nodes[0]);
                graph.Add(nodes[1], newnodevertices);
            }
        }

        public List<List<string>> FindAllRoutes(int smallcave)
        {
            List<List<string>> completeroutes = new List<List<string>>();
            List<List<string>> inprogress = new List<List<string>>();
            List<string> firststep = new List<string>();
            firststep.Add("start");
            inprogress.Add(firststep);
            while (inprogress.Count > 0)
                inprogress = TakeNextStep(inprogress, completeroutes, smallcave);
            return completeroutes;
        }

        public List<List<string>> TakeNextStep(List<List<string>> inprogress, List<List<string>> completeroutes, int smallcave)
        {
            List<List<string>> keeplooking = new List<List<string>>();
            /*foreach (List<string> elem in inprogress)
            {
                //pak laatste element
                string lastnode = elem[elem.Count - 1];
                // pak elke volgende optie hiervan uit de dictionary
                List<string> possiblenodes = new List<string>(graph[lastnode]);
                foreach (string nextnode in possiblenodes)
                {
                    if(nodeAccesible(elem, nextnode, smallcave))
                    {
                        //maak voor elke toegankelijke node een nieuwe identieke lijst met nieuwe element aan het eind
                        List<string> progressed = new List<string>(elem);
                        progressed.Add(nextnode);
                        if (nextnode == "end")//als laatste element end is, voeg het toe aan completeroutes
                            completeroutes.Add(progressed); // 0,2,4,8,14,20,28,37,45,54
                        else //else voeg toe aan keeplooking
                            keeplooking.Add(progressed);
                    }
                }
            }*/
            Parallel.ForEach(inprogress, elem =>
            {
                //pak laatste element
                string lastnode = elem[elem.Count - 1];
                // pak elke volgende optie hiervan uit de dictionary
                List<string> possiblenodes = new List<string>(graph[lastnode]);
                foreach (string nextnode in possiblenodes)
                {
                    if (nodeAccesible(elem, nextnode, smallcave))
                    {
                        //maak voor elke toegankelijke node een nieuwe identieke lijst met nieuwe element aan het eind
                        List<string> progressed = new List<string>(elem);
                        progressed.Add(nextnode);
                        if (nextnode == "end")//als laatste element end is, voeg het toe aan completeroutes
                        {
                            lock(completeroutes)
                                completeroutes.Add(progressed);
                        }
                            
                        else //else voeg toe aan keeplooking
                            lock(keeplooking)
                            {
                                keeplooking.Add(progressed);
                            }
                    }
                }
            });
            return keeplooking;
        }

        public bool nodeAccesible(List<string> visited, string checknode, int smallcave)
        {
            if (checknode == "start")
                return false;
            if (Char.IsUpper(checknode[0]))
                return true;
            int visitcount = nodecount(visited, checknode);
            if (visitcount == 0)
                return true;
            else if (visitcount < smallcave && nodecanbevisitedtwice(visited, checknode))
                return true;
            else
                return false;
            
            
            /*else if (visited[0] == "start")//&& nodecount(visited, checknode) >= smallcave
            {
                return true;
            }
            else if (nodecanbevisitedtwice(visited[0], checknode) && visitcount < smallcave)
            {
                if (visitcount == 1)
                    visited[0] += checknode;
                return true;
            }
            else if (visitcount >= 1)
                return false;
            return false;*/
        }

        private static int nodecount(List<string> target, string element)
        {
            int count = 0;
            foreach (string a in target)
                if (a == element)
                    count++;
            return count;
        }

        private static bool nodecanbevisitedtwice(List<string> visited, string target)
        {
            Dictionary<string, int> timesvisited = new Dictionary<string, int>();
            foreach(string elem in visited)
            {
                if (!Char.IsUpper(elem[0]))
                {
                    if (timesvisited.ContainsKey(elem))
                        timesvisited[elem]++;
                    else
                        timesvisited.Add(elem, 1);
                }
            }
            foreach(KeyValuePair<string,int> elem in timesvisited)
            {
                if (elem.Value > 1)
                    return false;
            }
            return true;
        }
    }
}
