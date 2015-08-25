using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Person {
    private static int Count = 0;

    public int Id { get; private set; }
    public String UserName { get; private set; }
    public String Email { get; private set; }
    public String Phone { get; private set; }
    public readonly List<Person> Same = new List<Person>();

    public Person(String userName, String email, String phone) {
        Id = Interlocked.Increment(ref Count);
        UserName = userName;
        Email = email;
        Phone = phone;
    }

    public override String ToString() {
        return String.Format("[id:{0}; Name:{1}; Email:{2}; Phone:{3}]", Id, UserName, Email, Phone);
    }
}

class Program {
    static void Main() {
        Dictionary<String, Person> userNames = new Dictionary<String, Person>();
        Dictionary<String, Person> emails = new Dictionary<String, Person>();
        Dictionary<String, Person> phones = new Dictionary<String, Person>();
        
        List<Person> persons = new List<Person>() {
            new Person("Gaurav", "gaurav@gmail.com", "gaurav@gfgQA.com"),
            new Person("Lucky", "lucky@gmail.com", "+1234567"),
            new Person("gaurav123", "+5412312", "gaurav123@skype.com"),
            new Person("gaurav1993", "+5412312", "gaurav@gfgQA.com")
        };

        foreach (Person p in persons) {
            AddNeighbor(userNames, p, p.UserName);
            AddNeighbor(emails, p, p.Email);
            AddNeighbor(phones, p, p.Phone);
        }

        HashSet<Person> visited = new HashSet<Person>();
        foreach(Person p in persons) {
            List<Person> group = new List<Person>();
            Find(visited, group, p);
            if (group.Any()) {
                Console.WriteLine("Group: {0}", String.Join(" ", group.Select(x => x.ToString())));
            }
        }
    }
    
    static void Find(HashSet<Person> visited, List<Person> group, Person current) {
        if (!visited.Contains(current)) {
            visited.Add(current);
            current.Same.ForEach(x => Find(visited, group, x));
            group.Add(current);
        }
    }

    static void AddNeighbor(Dictionary<String, Person> cache, Person current, String value) {
        if (cache.ContainsKey(value)) {
            cache[value].Same.Add(current);
            current.Same.Add(cache[value]);
        } else {
            cache[value] = current;
        }
    }
}
