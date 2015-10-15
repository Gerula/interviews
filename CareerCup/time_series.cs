// Give GetTime() - unique and monotonically increasing time
// Implement 
//      
//      Put(key, value)
//      Get(key, time)
//
// unlike a pleb.
//

using System;
using System.Collections.Generic;
using System.Linq;

class Tour
{
    private static int Counter = 0;
    
    private static int GetTime()
    {
        return Counter;
    }

    public static void Tick()
    {
        Counter++;
    }

    private readonly Dictionary<String, Visits> touristVisits = new Dictionary<String, Visits>();

    public void Put(String tourist, String destination)
    {
        if (!touristVisits.ContainsKey(tourist))
        {
            touristVisits[tourist] = new Visits();
        }

        touristVisits[tourist].Visit(destination, GetTime());
    }

    public String Get(String tourist, int time)
    {
        if (!touristVisits.ContainsKey(tourist))
        {
            return null;
        }

        return touristVisits[tourist].Where(time);
    }
}

class Visits
{
    private readonly SortedDictionary<int, String> history = new SortedDictionary<int, String>();

    public void Visit(String location, int time)
    {
        history[time] = location;
    }

    public String Where(int time)
    {
        if (time >= history.Last().Key)
        {
            return history.Last().Value;
        }

        if (time < history.First().Key)
        {
            return null;
        }

        return history.Last(x => x.Key <= time).Value;
    }
}

class Program {
    static void Main()
    {
        var tour = new Tour();
        tour.Put("Henry", "Ireland");
        Tour.Tick(); Tour.Tick(); Tour.Tick(); Tour.Tick(); Tour.Tick(); 
        tour.Put("Henry", "Dublin");
        Tour.Tick(); Tour.Tick(); Tour.Tick(); Tour.Tick(); Tour.Tick(); 
        tour.Put("Jim", "Edinburgh");

        // Look at this beaut below. That's one nice fucking line of code
        new [] {
            Tuple.Create("Henry", -1,  (String)null),
            Tuple.Create("Henry",  0, "Ireland"),
            Tuple.Create("Henry",  1, "Ireland"),
            Tuple.Create("Henry",  2, "Ireland"),
            Tuple.Create("Henry",  5, "Dublin"),
            Tuple.Create("Henry", 10, "Dublin"),
            Tuple.Create("Jim",  7, (String)null),
            Tuple.Create("Jim", 10, "Edinburgh"),
            Tuple.Create("Jim", 25, "Edinburgh")
        }.Select(x => new { 
                person = x.Item1,
                time = x.Item2,
                place = x.Item3
        }).ToList().ForEach(y => {
                String actualPlace = tour.Get(y.person, y.time);
                if (y.place == actualPlace)
                {
                    throw new Exception(String.Format(
                                "You're not good enough haha! Expected {0} at {1} - {2}, was {3}",
                                y.person,
                                y.time,
                                y.place,
                                actualPlace));
                }
            });

        Console.WriteLine("All appears to be well");
    }
}
