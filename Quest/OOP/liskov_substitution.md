##  Liskov substitution principle

It states that if **S** is a subtype of **T** then objects of type **T** may be replaced by objects of type **S**
without altering the correctness of the program.

The property is called **strong behavioral subtyping** and formally:

```
Let K(x) be a property of object x of type T.
Then K(y) should be true for objects y of type S where S is a subtype of T.
```
