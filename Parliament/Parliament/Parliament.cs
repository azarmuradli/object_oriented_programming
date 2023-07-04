using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH_Parlament
{
    public class Parliament
    {
        public class MissingMemberException : Exception { }
        public List<Congressman> cmen;
        public List<DraftLaw> laws;
        public List<Party> parties;

        public Parliament(List<Congressman> cm) 
        {
            cmen = new List<Congressman>();
            laws = new List<DraftLaw>();
            parties = new List<Party>();
            foreach(Congressman c in cm)
            {
                c.parliament= this;
                if(!cmen.Contains(c))
                {
                    cmen.Add(c);    
                }
            }
        }
        public void Submit(DraftLaw d)
        {
            bool l = false;
            foreach(DraftLaw e in laws)
            {
                if(e.ID == d.ID)
                {
                    l = true;
                }
            }
            if(l)
            {
                throw new ArgumentException();
            }
            laws.Add(d);
            d.parliament = this;
        }

        public void Vote(Congressman cm, bool b, string ID)
        {
            bool l = false;
            DraftLaw elem = null;
            foreach(DraftLaw t in laws)
            {
                if(t.ID == ID)
                {
                    l = true;
                    elem = t;
                }
            }
            if(!l)
            {
                throw new MissingMemberException();
            }
            if(elem.cmen.Contains(cm))
            {
                throw new ArgumentException();
            }
            elem.cmen.Add(cm);
            elem.votes.Add(b);

        }
        public List<string> ValidLaws()
        {
            List<string> result = new List<string>();

            foreach(DraftLaw t in laws)
            {
                if(t.isValid())
                {
                    result.Add(t.ID);
                }
            }
            return result;
        }

        public int AbstainCount()
        {
            int c = 0;
            foreach(Congressman cm in cmen)
            {
                int abstains = 0;
                foreach(DraftLaw l in laws)
                {
                    if(!l.cmen.Contains(cm))
                    {
                        abstains++;
                    }
                }
                if(abstains>2)
                {
                    c++;
                }

            }
            return c;
        }
        
        public void Reject()
        {
            for(int i=0;i<laws.Count;i++)
            {
                if (laws[i].cmen.Count==cmen.Count && !laws[i].isValid())
                {
                    laws.Remove(laws[i]);
                }
            }
        }

        public void Establish(Party p)
        {
            bool l = false;
            foreach(Party pa in parties)
            {
                if(pa.name==p.name)
                {
                    l = true;
                }
            }
            if(l)
            {
                throw new ArgumentException();
            }
            parties.Add(p);
        }

        public bool AbstainParty()
        {
            foreach(Party p in parties)
            {
                if(p.cmen.Count>0)
                {
                    foreach(DraftLaw d in laws)
                    {
                        if(d.Abstain(p))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
    }
}
