using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_Exo3_AbstractFactory
{
    public class Animal
    {
        public bool AvecAiles = false;
    }
    public class VitesseAnimal
    {
        public readonly IAnimalFactory Factory;
        public VitesseAnimal(IAnimalFactory factory)
        {
            Factory = factory;
        }
        public void SeDeplacer()
        {
            var course = Factory.Courir();
            var vol = Factory.Voler();

            Console.WriteLine("Course = " + course.VitesseCourse);
            Console.WriteLine("Vol = " + vol.VitesseVol);
        }
    }
    #region interfaces
    public interface IVol { decimal VitesseVol { get; } }
    public interface ICourse { int VitesseCourse { get; } }
    public interface IAnimalFactory
    {
        IVol Voler();
        ICourse Courir();
    }
    #endregion

    #region classes
    public class Aigle : IVol
    {
        public decimal VitesseVol => 1M;
    }
    public class Epervier : IVol
    {
        public decimal VitesseVol => 15M;
        //public decimal Pourcentage() { return 15M; }
    }
    public class Guepard : ICourse
    {
        public int VitesseCourse => 100;
    }
    public class Chien : ICourse
    {
        public int VitesseCourse => 50;
    }
    #endregion

    #region Factories
    public class AnimalAvecAilesFactory : IAnimalFactory
    {
        public ICourse Courir() => new Chien();

        public IVol Voler() => new Epervier();
    }
    public class AnimalSansAilesFactory : IAnimalFactory
    {
        public ICourse Courir() => new Guepard();

        public IVol Voler() => new Aigle();
    }
    #endregion
}
