using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Steve
    {

        private IMood mood;
        private List<Animal> animals;

        public List<Animal> getAnimals() { return animals; }
        public IMood getMood() { return mood; }


        public Steve(List<Animal> animals)
        {
            this.mood = null;
            this.animals = animals;
        }

        public void setMood(IMood mood) {
            this.mood = mood;
        }


        public void updateAnimals()
        {
            foreach(Animal animal in animals)
            {
                animal.Accept(mood);
            }
        }
        public void improveMood()
        {
            if (animals.All(a => a.getExhilaration() >= 5))
            {
                mood = mood.MoodImprove();
            }
        }

        public Animal highestAnimal()
        {
            int highest = animals[0].getExhilaration();
            Animal animal = animals[0];
            for (int i = 1; i < animals.Count; i++)
            {
                if (animals[i].getExhilaration() > highest)
                {
                    highest = animals[i].getExhilaration();
                    animal = animals[i];
                }
            }
            return animal;
        }
    }
}
