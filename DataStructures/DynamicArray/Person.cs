namespace DynamicArray
{
    public class Person
    {
        public string Name { get; set; }
        
        public  int Age { get; set; }

        public override bool Equals(object obj)
        {
            Person person = obj as Person;
            return person.Age == this.Age && person.Name == this.Name;
        }
    }
}