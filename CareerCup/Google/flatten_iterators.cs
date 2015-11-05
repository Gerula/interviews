// Flatten an iterator of iterators
//
// [[1, 2], [3, [4, 5]], 6]
//
// [1, 2, 3, 4, 5, 6]
//
// Implement Next and HasNext
//

using System;
using System.Collections.Generic;
using System.Linq;

class Iterator
{
    public List<Iterator> Children;
    public int Val;
    
    public override String ToString() 
    {
        if (Children == null)
        {
            return Val.ToString();
        }

        return String.Format("[{0}]", String.Join(", ", Children.Select(x => x.ToString())));
    }

    public IEnumerable<int> List()
    {
        if (Children == null)
        {
            yield return Val;
        }
        else
        {
            foreach (var val in  Children.SelectMany(x => x.List()))
            {
                yield return val;
            }
        }
    }
}

static class Program 
{
    static void Main()
    {
        var it = new Iterator {
            Children = new List<Iterator> {
                new Iterator {
                    Children = new List<Iterator> {
                        new Iterator {
                            Val = 1
                        },
                        new Iterator {
                            Val = 2
                        }
                    }
                },
                new Iterator {
                    Children = new List<Iterator> {
                        new Iterator {
                            Val = 3
                        },
                        new Iterator {
                            Children = new List<Iterator> {
                                new Iterator {
                                    Val = 4
                                },
                                new Iterator {
                                    Val = 5
                                }
                            }
                        }
                    }
                },
                new Iterator {
                    Val = 6
                }
            }
        };

        Console.WriteLine(it);
        Console.WriteLine(String.Join(", ", it.List()));
    }
}
