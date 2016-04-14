##  Basics

***OOP*** - a structured programming paradigm based on the concept of **objects** which may contain data in the form of fields
also known as attributes and code in the form of procedures known as methods.

***class*** - an extensible program code template for creating objects providing initial values for state
and implementations of behavior.

***object*** - instance of a class. A class itself can be an object, instace of a metaclass. Conceptually,
an object is a set of responsibilities. At the specification level it's a set of methods that can be invoked
on other object or itself. At the implementation level: data + code.

***interface*** - a protocol through which unrelated objects may be able to communicate. An interface provides
a definitions for methods which the objects agree upon.

***Abstract class vs interface*** = Interface is a contract: does not contain any behaviors/code but only signatures,
cannot be instatiated, you can inherit from multiple interfaces.
Abstract class may contain code, must contain at least one virtual function,
cannot be instantiated, in order to be used it needs to be inherited.

