namespace E_ClasseGenerique
{
    class Program
    {
        static void Main(string[] args)
        {
            var a1 = new ActiviteSportive<Foot, TerrainFoot>();
            var a2 = new ActiviteSportive<Rugby, TerrainRugby>();
            //var a3 = new ActiviteSportive<Natation>();
        }
    }
    class ActiviteSportive<T, U> 
        where T : SportAvecBalle, new()
        where U : Terrain, new()
    {
        public ActiviteSportive()
        {
            T f = new T();
            U terrain = new U();
        }
    }

    //class ActiviteSportiveFoot
    //{
    //    public ActiviteSportiveFoot()
    //    {
    //        Foot f = new Foot();
    //    }
    //}
    //class ActiviteSportiveRugby
    //{
    //    public ActiviteSportiveRugby()
    //    {
    //        Rugby f = new Rugby();
    //    }
    //}
    class Foot : SportAvecBalle { }
    class Rugby : SportAvecBalle { }
    class SportAvecBalle
    {

    }
    class Natation { }
    class TerrainFoot : Terrain { }
    class TerrainRugby : Terrain { }
    class Terrain { }
    class Piscine { }
}
