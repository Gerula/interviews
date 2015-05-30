#  Describe abstraction, encapsulation, polymorphism. 
#  
#  To my eternal shame I will try to answer them directly and update them in another commit with the academic rigurous answers
#
#  Abstraction = The process in which an object hides implementation details about it's behavior.
#              = A technique for managing system complexity by establishing a level of detail on which an entity interacts with the system suppressing the more complex details below the current level. It can apply to control and data: Control abstraction - abstraction of actions and Data abstraction - abstraction of data structures.
#
#  Encapsulation = The packaging of data and behavior about a certain concept in a class
#                = Right-o.
#
#  Polymorphism = Object having different behaviors in different contexts (multiple forms)
#               = The process in which different underlying forms present the same interface.
#  
#  is-a and has-a? = inheritance vs composition. Is-a relationship is when the subsitution property holds: for any class B inheriting A, P(B) => P(A). Has-a relationship describes the practice of having another object as a property. Both are related to code-reuse.
#                  = Right-o
#
#  Abstract class vs interface? = Interface is a contract: does not contain any behaviors/code but only signatures, cannot be instatiated, you can inherit from multiple interfaces. Abstract class may contain code, must contain at least one virtual function, cannot be instantiated, in order to be used it needs to be inherited.
#                               = Righ-ish. An interface must be implemented fully. An abstract class may also contain data. An abstract class may not be implemented fully thus resulting in another abstract class. Abstract class has abstract functions, not virtual. Abstract class may have constructors and have access modifiers.
#
#  Class vs instance? = Class is a template for creating instances. Class is a type, instance is an object belonging to a type.
#                     = Class is a blueprint\prototype. Instance is a single unit of the class
#
