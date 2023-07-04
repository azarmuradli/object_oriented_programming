using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH
{
    public class Guide
    {
        private string name;
        private int talkative;

        public Guide(string n, int t)
        {
            name = n;
            talkative = t;
        }
        public int getTalkative() { return talkative; }
    }
}
