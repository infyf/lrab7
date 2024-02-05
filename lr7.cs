using System;
using System.Collections.Generic;

namespace OOP
{
    class Ocean : IComparable<Ocean>
    {
        string name;
        int size;

        public Ocean(string name, int size)
        {
            this.name = name;
            this.size = size;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public int CompareTo(Ocean other)
        {
            return size.CompareTo(other.size);
        }

        public int CompareToByName(Ocean other)
        {
            return name.CompareTo(other.name);
        }

        public override string ToString()
        {
            return $"Ocean name:{name}, size:{size}";
        }
    }

    class Fish<T> where T : Ocean
    {
        List<T> listOcean;

        public Fish()
        {
            listOcean = new List<T>();
        }

        public void Add(T item)
        {
            listOcean.Add(item);
        }

        public void Remove(T item)
        {
            listOcean.Remove(item);
        }

        public List<T> ListOcean
        {
            get { return listOcean; }
        }

        public void DisplayFish()
        {
            foreach (var ocean in listOcean)
            {
                Console.WriteLine(ocean);
            }
        }

        public void SortByName()
        {
            listOcean.Sort(CompareByName);
        }

        private int CompareByName(T o1, T o2)
        {
            return o1.CompareToByName(o2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            int[] array = { 1, 2, 3, 4, 5 };


            List<int> list = new List<int>(array);


            Console.WriteLine("List elements:");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Ocean[] oceans = new Ocean[]
            {
                new Ocean("Shark", 500),
                new Ocean("Dolphin", 450),
                new Ocean("Needle-fish", 20)
            };

            List<Ocean> listOceans = new List<Ocean>(oceans);

            foreach (Ocean ocean in listOceans)
            {
                Console.WriteLine(ocean);
            }

            Console.WriteLine();

            Fish<Ocean> fishTs = new Fish<Ocean>();

            foreach (var item in oceans)
            {
                fishTs.Add(item);
            }

            fishTs.DisplayFish();
            Console.WriteLine();

            Console.WriteLine("BEFORE SORT");
            fishTs.ListOcean.Sort();
            fishTs.DisplayFish();
            Console.WriteLine("AFTER SORT");

           
            Console.WriteLine("SORT BY NAME");
            fishTs.SortByName();
            fishTs.DisplayFish();

            foreach (Ocean ocean in listOceans)
            {
                fishTs.Remove(ocean);
            }

            Console.WriteLine("REMOVE");
            fishTs.DisplayFish();

            Console.ReadLine();
        }
    }
}
