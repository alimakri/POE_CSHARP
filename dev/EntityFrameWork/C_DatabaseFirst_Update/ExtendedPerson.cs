using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_DatabaseFirst_Update
{
    public partial class Person
    {
        public string FullName { get { return LastName + " " + FirstName; } }
    }
}
