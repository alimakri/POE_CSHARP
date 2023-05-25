using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_Ninject.Data
{
    public interface IRepository
    {
        string Get();
    }
    public class Repository : IRepository
    {
        public string Get()
        {
            return "Repository";
        }
    }
    public class Fake1Repository : IRepository
    {
        public string Get()
        {
            return "Fake1Repository";
        }
    }
    public class Fake2Repository : IRepository
    {
        public string Get()
        {
            return "Fake2Repository";
        }
    }
}
