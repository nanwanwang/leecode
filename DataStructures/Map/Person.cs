using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public float Height { get; set; }

        public override int GetHashCode()
        {
            int hash = Age.GetHashCode();
            hash = ((hash << 5) - hash) + Height.GetHashCode();
            hash = ((hash << 5) - hash) + Name.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            var p = obj as Person;
           
            return p.Age == this.Age && p.Height == this.Height && p.Name == this.Name;

        }
    }
}
