##  Interface segregation principle

No client should be forced to depend on an interface it does not use \ need.
So it should not implement interfaces it does not use. Such an interface is called
polluted \ fat and needs to be split in smaller interfaces named *role interfaces*.

Example:

```
interface IWorker {
    public void TakeLunchBreak();
    public void Work();
}

class Employee : IWorker {
}

class Robot : IWorker {
    //  Robot needs to implement TakeLunchBreak()
}
```

Further reading: http://www.oodesign.com/interface-segregation-principle.html
