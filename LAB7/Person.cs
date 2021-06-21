using System;
using System.Runtime.Serialization;

[Serializable]
public class Person
{
    public string Name { get; set; }
    public string Age { get; set; }

    public Person()
    {
        
    }

    public Person(string name, string age)
    {
        Name = name;
        Age = age;
    }

    [OnSerializing]
    internal void OnSerializing(StreamingContext context)
    {
        Name = Name.ToUpper();
        Age = Age.ToUpper();
    }

    [OnDeserialized]
    internal void OnDeserialized(StreamingContext context)
    {
        Name = Name.ToLower();
        Age = Age.ToLower();

    }
}
