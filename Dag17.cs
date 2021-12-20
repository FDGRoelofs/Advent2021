using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Dag17 : Dag
    {
        int targetXmin;
        int targetXmax;
        int targetYmin;
        int targetYmax;
        
        public Dag17(string s, bool b) : base(s,b)
        {
            bool testdata = true;
            if (testdata)
            {
                targetXmin = 20;
                targetXmax = 30;
                targetYmin = -10;
                targetYmax = -5;
            }
            else
            {
                targetXmin = 153;
                targetXmax = 199;
                targetYmin = -114;
                targetYmax = -75;

            }
            Puzzel1();
            Puzzel2();
        }

        public override void Puzzel1()
        {
            //init target
            
            //start puzzel 1
            int answer = 0;
            string s = "poep";
            for(int velx = 0; velx < targetXmax; velx++)
                for(int vely = targetYmin; vely < 45; vely++)
                {
                    if (velx == 9 && vely == 0)
                        s = "test";
                    TrickShot Nextshot = new TrickShot((velx, vely), targetXmin, targetXmax, targetYmin, targetYmax);
                    int thisheight = Nextshot.Go();
                    if (thisheight > answer)
                        answer = thisheight;
                }
            this.result1 = answer.ToString();
            this.result2 = s;
        }

        public override void Puzzel2()
        {
            //throw new NotImplementedException();
        }

        
    }

    public class TrickShot
    {
        int maxheight
        { get; set; }
        (int x, int y) pos;
        (int x, int y) velocity;
        int targetXmin;
        int targetXmax;
        int targetYmin;
        int targetYmax;
        public TrickShot((int x, int y) initvel, int tXmin, int tXmax, int tYmin, int tYmax)
        {
            pos = (0, 0);
            velocity = initvel;
            targetXmin = tXmin;
            targetXmax = tXmax;
            targetYmin = tYmin;
            targetYmax = tYmax;
            maxheight = -999;
        }

        public int Go()
        {
            
            bool live = true;
            bool hit = false;
            while(live)
            {
                live = Step();
                if (pos.y > maxheight)
                    maxheight = pos.y;
                if (pos.y > maxheight)
                    maxheight = pos.y;
                if (GoalCheck())
                {
                    hit = true;
                    break;
                }
                    
            }
            if (hit)
                return maxheight;
            else
                return -999;
        }

        public bool Step()
        {
            bool live = true;
            pos.x += velocity.x;
            pos.y += velocity.y;
            if (pos.x > targetXmax)
                return false;
            if (pos.y < targetYmin)
                return false;
            velocity.y--;
            velocity.x = drag(velocity.x);
            return live;
            
        }
        private int drag(int vel)
        {
            int value = vel;
            if (value > 0)
                return value-1;
            else if (value < 0)
                return value + 1;
            else
                return value;
        }

        private bool GoalCheck()
        {
            bool xbounds = false;
            bool ybounds = false;
            if (pos.x > targetXmin && pos.x < targetXmax)
                xbounds = true;
            if (pos.y > targetYmin && pos.y < targetYmax)
                ybounds = true;
            return xbounds & ybounds;
        }
    }
}
