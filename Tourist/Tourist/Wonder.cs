using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH
{
    public abstract class Wonder
    {
        class EmptyWonders : Exception { }
        private Guide guide;
        public int x;
        public int y;
        public int interest;
        public int built;

        protected Wonder(int x, int y, int i, int b)
        {
            this.x = x;
            this.y = y;
            this.interest = i;
            this.built = b;
        }
        public abstract string GetType(); 
        
        public int ExpectedTime()
        {
            int g;
            if(guide==null)
            {
                g = 1;
            }
            else
            {
                g = 1 + guide.getTalkative();
            }
            return Factor() * interest * g;
        }

        protected abstract int Factor();
        private int Distance(Wonder w1, Wonder w2)
        {
            return Math.Abs(w1.x - w2.x) + Math.Abs(w1.y - w2.y);
        }
        public int Farthest(List<Wonder> ws)
        {
            if(ws.Count== 0)
            {
                throw new EmptyWonders();
            }
            int max = Distance(ws[0], this);

            foreach(Wonder w in ws)
            {
                if(Distance(w,this)>max)
                {
                    max = Distance(w,this);
                }
            }
            return max;
        }
        public void SetGuide(Guide g)
        {
            guide = g;
        }
    }

    public class Cathedral : Wonder
    {
        public Cathedral(int x, int y, int i, int b) : base(x, y, i, b) { }
        public override string GetType()
        {
            return "cath";
        }
        protected override int Factor()
        {
            return (2023 - built) + 5;
        }
    }

    public class Museum : Wonder
    {
        public Museum(int x, int y, int i, int b) : base(x, y, i, b) { }
        public override string GetType()
        {
            return "mus";
        }
        protected override int Factor()
        {
            return 10000 / (x * x + y * y + 1);
        }
    }

    public class Castle : Wonder
    {
        public Castle(int x, int y, int i, int b) : base(x, y, i, b) { }
        public override string GetType()
        {
            return "cast";
        }
        protected override int Factor()
        {
            return (2023 - built)*2;
        }
    }
}
