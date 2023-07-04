using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH_Parlament
{
    public abstract class DraftLaw
    {
        public Parliament parliament;
        public List<Congressman> cmen;
        public string date;
        public string ID;
        public List<bool> votes;

        protected DraftLaw(string d, string id)
        {
            date  = d;
            ID = id;
            votes= new List<bool>();
            cmen = new List<Congressman>();
        }
        protected int YesCount()
        {
            int count = 0;
            foreach(bool vote in votes)
            {
                if(vote) count++;
            }
            return count;
            
        }

        public abstract bool isValid();

        public bool Abstain(Party p)
        {
            foreach(Congressman c in cmen)
            {
                if(c.party==p) return false;
            }
            return true;
        }
    }

    public class Normal : DraftLaw
    {
        public Normal(string d, string id): base(d, id) { }
        public override bool isValid()
        {
            return (YesCount() * 2) > votes.Count;
        }
    }
    public class Cardinal : DraftLaw
    {
        public Cardinal(string d, string id) : base(d, id) { }
        public override bool isValid()
        {
            if(parliament == null)
            {
                return false;
            }
            return (YesCount() * 2) > parliament.cmen.Count;
        }
    }
    public class Constitutional : DraftLaw
    {
        public Constitutional(string d, string id) : base(d, id) { }
        public override bool isValid()
        {
            if (parliament == null || parliament.cmen.Count()==0)
            {
                return false;
            }
            return (YesCount() * 3) > (parliament.cmen.Count*2);
        }
    }
}
