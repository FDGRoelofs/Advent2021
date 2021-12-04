using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Dag4 : Dag
    {
        public Dag4(string s) : base(s)
        {

        }

        public override void Puzzel1()
        {
            int[] draws = getNumbers(lines[0]);
            List<BBord> boards = makeBoards();
            int currentdraw = 0;
            bool bingo = false;
            for(int i = 0; i < draws.Length; i++)
            {
                foreach (BBord element in boards)
                {
                    element.pop(draws[currentdraw]);
                    if (element.score > 0)
                    {
                        this.result1 = (element.score * draws[currentdraw]).ToString();
                        bingo = true;
                        break;
                    }
                        
                }
                if (bingo)
                    break;
                currentdraw++;
            }
        }

        public override void Puzzel2()
        {
            int[] draws = getNumbers(lines[0]);
            List<BBord> boards = makeBoards();
            int currentdraw = 0;
            int bingo = 0;
            //int lastbingo = -1;
            for (int i = 0; i < draws.Length; i++)
            {
                foreach (BBord element in boards)
                {
                    element.pop(draws[currentdraw]);
                    if (element.score > 0)
                    {
                        bingo++;
                    }

                }
                for(int n = 0; n < boards.Count; n++)
                {
                    if (boards[n].score > 0)
                        boards.RemoveAt(n);

                }
                currentdraw++;
                if (boards.Count == 1) // hier aanpassen voor test data
                {
                    for (int n = currentdraw; n < draws.Length; n++)
                    {
                        boards[0].pop(draws[n]);
                        if (boards[0].score > 0)
                        {
                            this.result2 = (boards[0].score * draws[n]).ToString();
                            break;
                        }

                    }
                }
            }
        }

        public int[] getNumbers(string inp)
        {
            string[] inpSplit = lines[0].Split(',');
            int[] draws = new int[inpSplit.Length];
            for (int i = 0; i < inpSplit.Length; i++)
                draws[i] = Int32.Parse(inpSplit[i]);
            return draws;
        }

        public List<BBord> makeBoards()
        {
            List<BBord> boards = new List<BBord>();
            int linetracker = 2;
            while(linetracker < 601) // hier aanpassen
            {
                int[,] currentBoard = new int[5, 5];
                for (int x = 0; x < 5; x++)
                {
                    //moet hier splitten op elk 3e char ipv op ' '
                    string[] currentline = cleanLine(lines[linetracker + x]);
                    for (int y = 0; y < 5; y++)
                    {
                        int currentvalue = Int32.Parse(currentline[y]);
                        currentBoard[x, y] = currentvalue;
                    }
                }
                linetracker += 6;
                boards.Add(new BBord(currentBoard));

            }
            

            return boards;
        }

        public string[] cleanLine(string line)
        {
            string[] cleanedline = new string[5];
            for(int i = 0; i < 5; i++)
            {
                if(!(line[0+ 3*i] == ' '))
                    cleanedline[i] += line[0 + 3 * i];
                cleanedline[i] += line[1 + 3 * i];

            }
            return cleanedline;
        }
    }

    class BBord
    {
        public int[,] bord = new int[5, 5];
        public bool[,] popped = new bool[5, 5];
        public int score
        {
            get;
            set;
        }
        public int lastPopped
        {
            get;
            set;
        }
        public int poppedCount
        {
            get;
            set;
        }

        public BBord(int[,] input)
        {
            bord = input;
            score = 0;
            poppedCount = 0;
        }

        public int pop(int value)
        {
            lastPopped = value;
            for(int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                    if (bord[x, y] == value)
                    {
                        popped[x, y] = true;
                        poppedCount++;
                    }
            }
            if(score == 0)
                if (poppedCount > 4)
                    if (checkBingo())
                        calcScore();
            return score;
        }

        public bool checkBingo()
        {
            int count = 0;
            //vertical
            for(int x = 0; x < 5; x++)
            {
                for(int y = 0; y < 5; y++)
                {
                    if (popped[x, y])
                        count++;
                }
                if (count == 5)
                    return true;
                else
                    count = 0;
            }

            //horizontal
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (popped[x, y])
                        count++;
                }
                if (count == 5)
                    return true;
                else
                    count = 0;
            }
            return false;
        }

        public void calcScore()
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (!popped[x, y])
                        score += bord[x, y];
                }
            }
        }
    }
}
