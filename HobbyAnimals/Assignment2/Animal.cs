using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public abstract class Animal
    {
        public string name;
        protected int exhilaration;

        public void ModifyExhilaration(int e) 
        {
            if (exhilaration + e >= 70) {
                exhilaration = 70;
            }
            else if (exhilaration + e < 0) {
                exhilaration = 0;
            }
            else
            {
                exhilaration += e;
            }
        }

        protected Animal(string str, int e = 0) 
        { 
            name = str; 
            if(e<0)
            {
                throw new ArgumentException("Exhilaration of animal " + str + " can not be minus");
            }
            exhilaration = e;
        }

        public int getExhilaration() { return exhilaration; }

        public string getName() { return name; }


        public abstract void Accept(IMood mood);
    }


    public class Tarantula : Animal
    {
        public Tarantula(string str, int e = 0) : base(str, e) { }
        public override void Accept(IMood mood)
        {
            mood.ChangeT(this);
        }
    }

    // class of squelchies
    public class Hamster : Animal
    {
        public Hamster(string str, int e = 0) : base(str, e) { }
        public override void Accept(IMood mood)
        {
            mood.ChangeH(this);
        }
    }

    // class of green finches
    public class Cat : Animal
    {
        public Cat(string str, int e = 0) : base(str, e) { }
        public override void Accept(IMood mood)
        {
            mood.ChangeC(this);
        }
    }
}




