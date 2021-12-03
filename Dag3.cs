using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Dag3 : Dag
    {
        public int[,] diagnostic = new int[12, 1000];
        public string[] debug = new string[10];
        //public int[] common = new int[12];

        public Dag3(string s) : base(s)
        {

        }

        public override void Puzzel1()
        {
            int[] common = new int[12];
            linesReader();
            for(int n = 0; n < 12; n++)
            {
                int counter = 0;
                for(int i = 0; i < 1000; i++)
                {
                    if (diagnostic[n, i] == 1)
                        counter++;
                }
                if (counter > 499)
                    common[n] = 1;
            }
            int gamma = bitsToInt(common);
            int epsilon = bitsToInt(invertBits(common));
            this.result1 = (gamma * epsilon).ToString();
            debug[0] = gamma.ToString();
            debug[1] = epsilon.ToString();
        }

        public override void Puzzel2()
        {
            var diagnosticLines = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                diagnosticLines.Add(lines[i]);
            }
            var co2input = new List<string>(diagnosticLines);
            var oxygeninput = new List<string>(diagnosticLines);
            //co2input = diagnosticLines;
            //oxygeninput = diagnosticLines;
            int oxygenrating = getRating(oxygeninput, true);
            int co2rating = getRating(co2input, false);
            this.result2 = (oxygenrating * co2rating).ToString();
            
        }

        public void linesReader()
        {
            for(int i = 0; i < 1000; i++)
            {
                for(int n = 0; n < 12; n++)
                {
                    if (lines[i][n] == '1')
                        diagnostic[n, i] = 1;
                }
            }
        }

        public int bitsToInt(int[] inp)
        {
            int value = 0;
            int index = 11;
            for (int n = 1; n < 12; n++)
            {
                if(inp[index - n] == 1)
                    value += (int)Math.Pow(2, n);
            }
            value += inp[11];
            return value;
        }

        public int[] invertBits(int[] inp)
        {
            int[] output = new int[12];
            for (int n = 0; n < 12; n++)
            {
                if (inp[n] == 0)
                    output[n] = 1;
            }
            return output;
        }

        public int getRating(List<string> input, bool oxygen)
        {
            int index = 0;
            while (input.Count > 1)
            {
                char b = findCommon(input, index, oxygen);
                var toRemove = new List<int>();
                int length = input.Count;
                for(int i = 0; i < length; i++)
                {
                    char a = input[i][index];
                    

                    if (a != b)
                        toRemove.Add(i);
                }
                index += 1;
                for(int i = toRemove.Count - 1; i > -1; i--)
                {
                    input.RemoveAt(toRemove[i]);
                }

            }
            int[] output = new int[12];
            for(int i = 0; i < 12; i++)
            {
                if (input[0][i] == '1')
                    output[i] = 1;
            }
            return bitsToInt(output);
        }

        public char findCommon(List<string> input, int index, bool oxygen)
        {
            int count1 = 0;
            int count0 = 0;
            foreach(string element in input)
            {
                if (element[index] == '1')
                    count1++;
                else
                    count0++;
            }
            System.Diagnostics.Debug.WriteLine(count1);
            if(oxygen)
            {
                if ((count1 >= count0) )
                                return '1';
                            else
                                return '0';
            }
            else
            {
                if ((count1 < count0))
                    return '1';
                else
                    return '0';
            }
            
        }

    }
}
