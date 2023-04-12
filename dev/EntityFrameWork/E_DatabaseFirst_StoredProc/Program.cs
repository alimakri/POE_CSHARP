using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_DatabaseFirst_StoredProc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AdvContext();
            var employees = context.uspGetEmployeeManagers(10);
            foreach(var employee in employees)
            {
                Console.WriteLine("{0} {1} : {2}", employee.FirstName, employee.LastName, employee.OrganizationNode);
            }
            Console.ReadLine();
        }
    }
}
