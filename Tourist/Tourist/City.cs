using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH
{
    public class City
    {
        class AlreadyContaining : Exception { }
        public List<District> ds;

        public City(List<District> ds)
        {
            this.ds = new List<District>();
            foreach(District d in ds)
            {
                if(this.ds.Contains(d))
                {
                    throw new AlreadyContaining();
                }
                this.ds.Add(d);
            }
        }

        public District WhichDistrict(Wonder w)
        {
            District district = null;
            foreach(District d in ds)
            {
                if(d.ws.Contains(w))
                {
                    district = d;
                }
            }
            return district;
        }

        public District MaxTotalTime()
        {
            int max = ds[0].TotalTime();
            District district = ds[0];

            foreach(District d in ds)
            {
                if (d.TotalTime() > max)
                {
                    max = d.TotalTime();
                    district= d;
                }
            }

            return district;
        }

        public bool CathedralEverywhere()
        {
            bool everywhere = true;

            foreach(District d in ds)
            {
                if(d.Cathedrals()<1)
                {
                    everywhere = false;
                }
            }
            return everywhere;
        }
    }
}
