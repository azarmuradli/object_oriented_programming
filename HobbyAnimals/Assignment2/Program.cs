//Author:   Gregorics Tibor
//Date:     2021.11.13.
//Title:    competition of different creatures

using System;
using TextFile;
using System.Collections.Generic;
using Assignment2;

namespace Assignment2
{
    class Program
    {
        static void Main()
        {
            TextFileReader reader = new("inp.txt");

            // populating creatures
            reader.ReadLine(out string line); int n = int.Parse(line);
            List<Animal> animals = new();
            for (int i = 0; i < n; ++i)
            {
                char[] separators = new char[] { ' ', '\t' };
                Animal animal = null;

                if (reader.ReadLine(out line))
                {
                    string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    char ch = char.Parse(tokens[0]);
                    string name = tokens[1];
                    int p = int.Parse(tokens[2]);

                    switch (ch)
                    {
                        case 'T': animal = new Tarantula(name, p); break;
                        case 'H': animal = new Hamster(name, p); break;
                        case 'C': animal = new Cat(name, p); break;
                    }
                }
                animals.Add(animal);
            }


            // populating the moods
            List<IMood> moods = new();
            while (reader.ReadChar(out char c))
            {
                switch (c)
                {
                    case 'j':
                        moods.Add(Joyful.Instance()); break;
                    case 'u': moods.Add(Usual.Instance()); break;
                    case 'b': moods.Add(Blue.Instance()); break;
                }
            }


            // competition
            try
            {
                Steve steve = new Steve(animals);
                for (int i = 0; i < moods.Count; i++)
                {
                    steve.setMood(moods[i]);
                    steve.improveMood();
                    steve.updateAnimals();
                    Animal highestAnimal = steve.highestAnimal();

                    Console.WriteLine(highestAnimal.getName());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.ToString());
            }
        }
    }
}
