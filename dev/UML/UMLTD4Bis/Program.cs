using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLTD4Bis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vegetalList = new Vegetaux();
            vegetalList.Add(new Vegetal { Nom = "Cactus", EstComestible = false });
            vegetalList.Add(new Vegetal { Nom = "Ficus", EstComestible = false });
            vegetalList.Add(new Vegetal { Nom = "Citronier", EstComestible = true });

            var v1 = vegetalList[0];

            foreach(var vegetal in vegetalList)
            {
                Console.WriteLine(vegetal.Nom);
            }
            Console.Read();
        }
    }
    public class Vegetal
    {
        public string Nom;
        public bool EstComestible;
    }
    public class Vegetaux : IEnumerable<Vegetal>
    {
        private List<Vegetal> vegetalList = new List<Vegetal>();
        internal void Add(Vegetal vegetal)
        {
            vegetalList.Add(vegetal);
        }

        public IEnumerator<Vegetal> GetEnumerator()
        {
            return new VegetalEnumerator(vegetalList);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return new VegetalEnumerator(vegetalList);
        }
        public Vegetal this[int index]
        {
            get
            {
                return vegetalList[index];
            }
        }
    }

    internal class VegetalEnumerator : IEnumerator<Vegetal>
    {
        private int Index = -1;
        private List<Vegetal> VegetalList;

        public VegetalEnumerator(List<Vegetal> vegetalList)
        {
            VegetalList = vegetalList;
        }

        public Vegetal Current => VegetalList[Index];

        object IEnumerator.Current => VegetalList[Index];

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            Index++;
            return Index < VegetalList.Count;
        }

        public void Reset()
        {
            Index = -1;
        }
    }
}
