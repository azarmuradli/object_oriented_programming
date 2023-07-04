using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH
{
    public  class District
    {
        class EmptyWonders : Exception { }
        class AlreadyContaining : Exception { }

        public string name;
        public List<Wonder> ws;


        public District(string n, List<Wonder> ws)
        {
            name = n;
            this.ws = new List<Wonder>();
            foreach(Wonder w in ws) {
                if (this.ws.Contains(w))
                {
                    throw new AlreadyContaining();
                }
                this.ws.Add(w);
            }
        }
        public int MaxDistance()
        {
            if(ws.Count == 0)
            {
                throw new EmptyWonders();
            }
            int max = ws[0].Farthest(ws);

            foreach(Wonder w in ws)
            {
                if(w.Farthest(ws)>max)
                {
                    max = w.Farthest(ws);
                }
            }

            return max;
        }

        public int Cathedrals()
        {
            int c = 0;
            
            foreach(Wonder w in ws)
            {
                if(w.GetType()=="cath")
                {
                    c++;
                }
            }

            return c;
        }

        public int TotalTime()
        {
            int total = 0;

            foreach(Wonder w in ws)
            {
                total += w.ExpectedTime();
            }

            return total;
        }

        
    }
}
