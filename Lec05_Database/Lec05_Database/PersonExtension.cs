using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec05_Database
{
    partial class Person
    {
        public override string ToString()
        {
            return $"{this.Name} ({this.Age})";
        }
    }
}
