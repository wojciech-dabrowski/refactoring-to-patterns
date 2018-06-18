# Refactoring to patterns
Repository contains examples of refactoring existing code to design patterns. Every example is provided with tests and full list of steps for complete transition to the design pattern.

### Refactoring to strategy pattern
Steps:
1. Create _Strategy_ class. This class will contain behavior of considered method in original class. Name of strategy should correspond to the original class method behavior. Created class name can contain word `Strategy` if you think that will increase readability of code, but it is not necessary.
2. Move considered method from original class to the new _Strategy_ class. During this step you should leave original method, but it will delegate behavior to the new class. To do this, define new member in original class. In this step, you should somehow pass needed data from original class to the _Strategy_ class. You can do it in two ways:
   1. Pass needed data as parameters.
   2. Pass original class (context) to the _Strategy_ method.

   **Compile code and run tests.**

3. Introduce parameter to the constructor of _Strategy_ type or create _Strategy_ instance inside constructor.

   **Compile code and run tests.**
4. STEP FOUR TODO

   **Compile code and run tests.**

### Refactoring to state pattern
Steps:
1. 
2. 
3. 
4. 

### Refactoring to template method pattern
Steps:
1. 
2. 
3. 
4. 

#### Contribution
Feel free to add new examples of existing patterns or propose refactors to other design pattern. Remember that you should provide tests, steps description in this file and full steps shown in code.