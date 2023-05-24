using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace assignment1
{

    public class Item
    {
        public int element;
        public int frequency;

        public Item() { }
        public Item(int element, int frequency)
        {
            this.element = element;
            this.frequency = frequency;
        }
        public override string ToString()
        {
            return $"Element : {element} , Frequency: {frequency}";
        }

    }
    public class Bag
    {
        #region Exceptions
        public class BagDoesntContainThisElement : Exception { }
        #endregion

        #region Attributes
        private readonly List<Item> items;
        private int numOfOneOccur;
        #endregion

        public List<Item> getItems()
        {
            return this.items;
        }


        public Bag() {
            items = new List<Item>();
            numOfOneOccur = 0;
        }
        public bool Exist(int element)
        {
            for(int i=0;i<items.Count;i++)
            {
                if (items[i].element==element)
                {
                    return true;
                }
            }
            return false;
        }
        public Item Find(int element)
        {
            for(int i=0;i<items.Count;i++)
            {
                if (items[i].element==element)
                {
                    return items[i];
                }
            }
            return default(Item);
        }
     
        public void Insert(int element)
        {
            
            if (Exist(element))
            {
                Item item = Find(element);
                item.frequency++;
                if (item.frequency == 2)
                {
                    numOfOneOccur--;
                }

            }
            else
            {
                Item itemNew = new Item();
                itemNew.element = element;
                itemNew.frequency = 1;
                items.Add(itemNew);
                numOfOneOccur++;

            }
        }

        public int Remove(int element)
        {
            
            if (Exist(element)) {

                Item item = Find(element);

                if (item.frequency == 1)
                {
                    items.Remove(item);
                    numOfOneOccur--;
                }
                else
                {
                    item.frequency--;
                    if (item.frequency == 1)
                    {
                        numOfOneOccur++;
                    }
                }
                return element; 
            }
            else
            {
                throw new BagDoesntContainThisElement();

            }
        }

        public int Frequency(int element)
        {
            
            if (Exist(element))
            {
                Item item = Find(element);
                return item.frequency;          
            }
            else
            {
                return 0;
            }
        
        }

        public int getNumOfOneOccur()
        {
            return numOfOneOccur; 
        }
        public void Print()
        {
            foreach(Item item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}
