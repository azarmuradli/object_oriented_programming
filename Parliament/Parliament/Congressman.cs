using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH_Parlament
{
    public class Congressman
    {
        public Parliament parliament;
        public Party party;
        public string name;

        public Congressman(string n)
        {
            name = n;
        }
        public void Vote(bool vote,string id)
        {
            if(parliament==null)
            {
                throw new ArgumentNullException();
            }
            parliament.Vote(this, vote, id);
        }

        public void Enter(Party p)
        {
            if(party!=null || p==null)
            {
                throw new InvalidOperationException();
            }
            party = p;
            p.cmen.Add(this);
        }

        public void Leave()
        {
            if(party==null)
            {
                throw new InvalidOperationException();
            }
            party.cmen.Remove(this);
            party = null;
        }
    }
}
