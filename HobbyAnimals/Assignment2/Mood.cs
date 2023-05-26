using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public interface IMood
    {
        void ChangeT(Tarantula p);
        void ChangeH(Hamster p);
        void ChangeC(Cat p);
        IMood MoodImprove();
    }

    public class Joyful : IMood
    {

        public void ChangeT(Tarantula p)
        {
            p.ModifyExhilaration(1);

        }
        public void ChangeH(Hamster p)
        {
            p.ModifyExhilaration(2);

        }
        public void ChangeC(Cat p)
        {
            p.ModifyExhilaration(3);

        }
        public IMood MoodImprove()
        {
            return this;
        }



        private Joyful() { }

        private static Joyful instance = null;
        public static Joyful Instance()
        {
            if (instance == null)
            {
                instance = new Joyful();
            }
            return instance;
        }


    }

    public class Usual : IMood
    {

        public void ChangeT(Tarantula p)
        {
            p.ModifyExhilaration(-2);

        }
        public void ChangeH(Hamster p)
        {
            p.ModifyExhilaration(-3);

        }
        public void ChangeC(Cat p)
        {
            p.ModifyExhilaration(3);
        }

        public IMood MoodImprove()
        {
            return Joyful.Instance();
        }

        private Usual() { }

        private static Usual instance = null;
        public static Usual Instance()
        {
            if (instance == null)
            {
                instance = new Usual();
            }
            return instance;
        }

    }

    public class Blue : IMood
    {

        public void ChangeT(Tarantula p)
        {
            p.ModifyExhilaration(-3);

        }
        public void ChangeH(Hamster p)
        {
            p.ModifyExhilaration(-5);

        }
        public void ChangeC(Cat p)
        {
            p.ModifyExhilaration(-7);

        }

        public IMood MoodImprove()
        {
            return Usual.Instance();
        }

        private Blue() { }

        private static Blue instance = null;
        public static Blue Instance()
        {
            if (instance == null)
            {
                instance = new Blue();
            }
            return instance;
        }




    }
}
