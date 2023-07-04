using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH_Parlament
{
    public class Party
    {
        public List<Congressman> cmen;
        public string name;

        public Party(string n, Parliament p)
        {
            name = n;
            cmen = new List<Congressman>();
            p.Establish(this);

        }
    }
}
