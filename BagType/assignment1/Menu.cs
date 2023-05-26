using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace assignment1
{
    public class Menu
    {
        private Bag bag = new Bag();
        public Menu() { }

        #region Run
        public void Run() {
            int n;
            do
            {
                PrintMenu();
                try
                {
                    n = int.Parse(Console.ReadLine()!);
                }
                catch (System.FormatException) {
                    n = -1;
                    Console.WriteLine("You can only insert integers");
                }
                switch (n)
                {
                    case 1:
                        InsertElement();
                        break;
                    case 2: 
                        RemoveElement(); 
                        break;
                    case 3:
                        getFrequency();
                        break;
                    case 4:
                        getNumOfOneOccur();
                        break;
                    case 5:
                        getBagContent();
                        break;

                }

            } while (n != 0);


        }

        #endregion



        #region Menu operations
        static private void PrintMenu()
        {
            Console.WriteLine("\n\n 0. - Quit");
            Console.WriteLine(" 1. - Insert an element");
            Console.WriteLine(" 2. - Remove an element");
            Console.WriteLine(" 3. - Return frequency of an element");
            Console.WriteLine(" 4. - Return the number of elements which occur only once ");
            Console.WriteLine(" 5. - Return content of Bag");
            Console.Write(" Choose: ");
        }

        private void InsertElement() {
            int element = 0;
            bool ok = false;
            do
            {
                Console.WriteLine("Enter the element you want to insert: ");
                try
                {
                    element = int.Parse(Console.ReadLine()!);
                    ok = true;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Inserted element should be integer!");
                }
            } while (!ok);
            bag.Insert(element);

        }
        private void RemoveElement()
        {
            if (bag.getItems().Count > 0)
            {


                int element = 0;
                bool ok = false;
                do
                {
                    Console.WriteLine("Enter the element you want to remove from bag: ");
                    try
                    {
                        element = int.Parse((Console.ReadLine()!));
                        ok = true;
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("All elements in the bag should be integer!");
                    }

                } while (!ok);
                try
                {
                    bag.Remove(element);
                }
                catch (Bag.BagDoesntContainThisElement)
                {
                    Console.WriteLine("Bag doesn't contain this element");
                }
            }
            else
            {
                Console.WriteLine("The bag is empty!");
                return;
            }
            

        }

        private void getFrequency()
        {
            if (bag.getItems().Count > 0)
            {


                int element = 0;
                bool ok = false;
                do
                {
                    Console.WriteLine("Enter the element you want to get the frequency of: ");
                    try
                    {
                        element = int.Parse((Console.ReadLine()!));
                        ok = true;
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Element should be integer!");
                    }

                } while (!ok);


                Console.WriteLine($"Frequency of {element} is " + bag.Frequency(element));
            }
            else
            {
                Console.WriteLine("The bag is empty!");
                return;
            }
            


        }

        private void getNumOfOneOccur()
        {
            if (bag.getItems().Count > 0)
            {
                Console.WriteLine("Number  of elements with one occurance is " + bag.getNumOfOneOccur());
            }
            else
            {
                Console.WriteLine("The bag is empty!");
            }
        }

        private void getBagContent()
        {
           if(bag.getItems().Count>0)
            {
                bag.Print();
            }
           else
            {
                Console.WriteLine("The bag is empty!");
                return;
            }
        }
        #endregion
    }
}
