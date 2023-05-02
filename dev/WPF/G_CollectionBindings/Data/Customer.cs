using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_CollectionBindings.Data
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid CustomerID { get; set; }
        public int Age { get; set; }
    }
    public class CustomerCollection : List<Customer>
    {
        public CustomerCollection()
        {
        }
    }
}
