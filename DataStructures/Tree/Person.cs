using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Person:IComparable<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

       
        public int CompareTo(Person other)
        {
            return this.Age - other.Age;
        }

        public override string ToString()
        {
            return "age=>"+this.Age;
        }
    }
}
