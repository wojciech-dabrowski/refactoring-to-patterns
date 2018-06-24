# Refactoring to patterns
Repository contains examples of refactoring existing code to design patterns. Every example is provided with tests and full list of steps for complete transition to the design pattern.

## Refactoring to strategy pattern
Steps:
1. Create _Strategy_ class. This class will contain behavior of considered method in original class. Name of strategy should correspond to the original class method behavior. Created class name can contain word `Strategy` if you think that will increase readability of code, but it is not necessary.
2. Move considered method from original class to the new _Strategy_ class. During this step you should leave original method, but it will delegate behavior to the new class. To do this, define new member in original class. In this step, you should somehow pass needed data from original class to the _Strategy_ class. You can do it in two ways:
   * Pass needed data as parameters.
   * Pass original class (context) to the _Strategy_ method.

   Depending on chosen method, you could be forced to change access modifiers to some original class members.

3. Introduce parameter to the constructor of _Strategy_ type or create _Strategy_ instance inside constructor.

   **Compile code and run tests.**
4. Create _Strategy_ subclass for every algorithm variant. Choose method of determine which algorithm should be used. You can do it in several ways:
    * Inject appropriate _Strategy_ class in original class constructor.
    * Create appropriate _Strategy_ class in original class factory method.
    * Create appropriate _Strategy_ class in base _Strategy_ class factory method.

    Base strategy class should be converted to interface or abstract class.

   **Compile code and run tests.**

## Refactoring to template method pattern
Steps:
1. Find _the similar_ method in multiple subclasses (method which executes similar steps). Extract _identical_ and _unique_ methods from _the similar_ method in subclasses. 

   **Compile code and run tests.**

2. If _unique_ methods in subclasses have other signatures, unify them.

   **Compile code and run tests.**

3. If _similar_ methods in subclasses have other signatures, unify them.

   **Compile code and run tests.**

4. Pull up _identical_ methods to the base class.

   **Compile code and run tests.**

5. Pull up _similar_ method to the base class. Define _unique_ methods as abstract in the base class. _Similar_ method has become _template method_.

   **Compile code and run tests.**

## Refactoring to state pattern
Steps:
1. _Context_ class is the class where you can find complex conditional state changes. Change field in _context_ class that describe her state (used for checking conditions and changed during changing state) into seperate class. This class will be _base state class_. Move defined constants (if they exist) to the _base state class_.

   **Compile code.**

2. Create _n_ state subclasses, where _n_ describes number of allowed states.  

   **Compile code.**

3. TODO

   **Compile code and run tests.**

4. TODO

   **Compile code and run tests.**

5. TODO

   **Compile code and run tests.**

## Contribution
Feel free to add new examples of existing patterns or propose refactors to other design pattern. Remember that you should provide tests, steps description in this file and full steps shown in code.