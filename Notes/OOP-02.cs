// ============================================================
// MODULE 2: OBJECT-ORIENTED PROGRAMMING
// ============================================================

#region 2.1 - Classes and Objects

/*
 * CLASS: a blueprint/template defining structure (fields/properties) and
 *        behavior (methods). Compile-time concept - no memory allocated
 *        just by declaring a class.
 *
 * OBJECT: a runtime INSTANCE of a class. Created with 'new', allocated on
 *         the HEAP. Each object has its own independent copy of instance fields.
 *
 * MEMORY MODEL:
 *   Car car1 = new Car("Tesla");
 *   -> 'car1' (stack, if local variable) holds a REFERENCE (pointer)
 *   -> the actual Car object { Model, Speed } lives on the HEAP
 *
 * ANATOMY OF A CLASS:
 *   - Fields: store the object's actual data (usually private)
 *   - Constructor: special method that runs when 'new' creates an object,
 *                   used to initialize fields
 *   - Properties: controlled access/gateway to fields (deep dive in 2.3 Encapsulation)
 *   - Methods: define behavior/actions the object can perform
 *
 * INSTANCE MEMBERS vs STATIC MEMBERS (static covered next in 2.2):
 *   Instance members belong to a SPECIFIC OBJECT - each object gets its own copy.
 *   Static members belong to the CLASS ITSELF - shared across ALL instances.
 *
 * GOTCHA / MISCONCEPTION #1:
 *   "A class and an object are the same thing" - FALSE.
 *   Class = blueprint (compile-time). Object = instance (runtime, allocated on heap).
 *
 * GOTCHA / MISCONCEPTION #2:
 *   "Objects from the same class share data" - FALSE (unless members are static).
 *   Example: Counter c1 = new(); Counter c2 = new();
 *            c1.Count = 100; -> c2.Count is still 0. Completely independent.
 */

#endregion

#region 2.2 - Constructors, this, and Static Members

/*
 * CONSTRUCTOR:
 *   - Special method, SAME NAME as class, NO return type.
 *   - Runs automatically when 'new ClassName(...)' is called.
 *   - If you write ZERO constructors, C# auto-generates a parameterless one.
 *   - The MOMENT you write ANY constructor yourself, the auto-generated
 *     parameterless one DISAPPEARS - must write it explicitly if still needed.
 *
 * CONSTRUCTOR OVERLOADING:
 *   Multiple constructors with different parameter lists, like regular methods.
 *
 * CONSTRUCTOR CHAINING (': this(...)'):
 *   One constructor calls another to avoid duplicating initialization logic.
 *   Example: public Student(string name) : this(name, 0) { }
 *
 * THIS KEYWORD - THREE USES:
 *   1. Disambiguate field vs parameter with SAME name:
 *        this.name = name;  // this.name = FIELD, name = PARAMETER
 *      WITHOUT 'this.': name = name; is a SILENT BUG (parameter assigned to
 *      itself, field stays null/default forever - NO compile error/warning!)
 *   2. Pass the current object to another method: someMethod(this);
 *   3. Constructor chaining: this(name, 0)
 *
 * BEST PRACTICE: prefix private fields with underscore (_name) to AVOID
 *                this whole class of bug entirely - no 'this' needed then.
 *
 * STATIC MEMBERS:
 *   - Belong to the CLASS ITSELF, not any instance. ONE shared copy for ALL objects.
 *   - Access via CLASS NAME: Student.GetTotalStudents() (NOT student1.GetTotalStudents())
 *   - Static methods CANNOT access instance members directly (no 'this' exists
 *     in static context - there's no specific object).
 *   - STATIC CLASS (whole class marked static): can ONLY have static members,
 *     CANNOT be instantiated with 'new'. Examples: Math, Console, Convert.
 *
 * GOTCHA / MISCONCEPTION #1:
 *   "Static fields reset for every new object" - FALSE. Initialized ONCE,
 *   persists/shared across entire app lifetime, regardless of object count.
 *
 * GOTCHA / MISCONCEPTION #2:
 *   "this is only for naming conflicts" - FALSE, also used for passing
 *   current object as argument, and constructor chaining.
 *
 * WHEN TO USE STATIC vs INSTANCE METHOD:
 *   STATIC: logic doesn't depend on any specific object's state (pure utility, e.g. Math.Sqrt)
 *   INSTANCE: operates on THIS specific object's data (e.g. student.AddMarks())
 */

#endregion

#region 2.3 - Encapsulation

/*
 * ENCAPSULATION: bundling data (fields) with methods that operate on it,
 *                while RESTRICTING direct external access to protect
 *                the object from being put into an INVALID STATE.
 *
 * ACCESS MODIFIERS:
 *   private             - only within the same class
 *   protected           - same class + derived classes (subclasses)
 *   internal            - anywhere in the same assembly/project
 *   protected internal  - same assembly OR derived classes in other assemblies
 *   private protected   - same assembly AND derived classes only
 *   public              - anywhere, no restriction
 *   DEFAULT: class members default to private, top-level classes default to internal.
 *
 * WHY PUBLIC FIELDS ARE DANGEROUS:
 *   public decimal Balance; -> anyone can set account.Balance = -5000; with NO validation.
 *
 * PROPERTIES (get/set) - methods in disguise, can contain validation logic:
 *   public decimal Balance
 *   {
 *       get => _balance;
 *       set { if (value < 0) throw new ArgumentException(...); _balance = value; }
 *   }
 *   'value' is an IMPLICIT keyword available only inside 'set' - represents
 *   what the caller is trying to assign.
 *
 * TWO WAYS TO MAKE READ-ONLY FROM OUTSIDE:
 *   1. Expression-bodied: public string Name => _name;
 *      -> NO set accessor exists at all, even privately. Must assign backing
 *         field directly (usually only in constructor).
 *   2. Auto-property with private set: public string Name { get; private set; }
 *      -> readable externally, but class's OWN methods CAN change it later.
 *
 * AUTO-IMPLEMENTED PROPERTIES:
 *   public string Name { get; set; } - compiler auto-generates hidden backing field.
 *   Used when NO custom validation/logic is needed. Very common in real code.
 *   Only write manual backing field + custom get/set when validation IS needed.
 *
 * GOTCHA / MISCONCEPTION #1:
 *   "Properties and fields are the same" - FALSE. Properties compile to
 *   get_X()/set_X(value) METHODS under the hood - can contain any logic.
 *
 * GOTCHA / MISCONCEPTION #2:
 *   "Encapsulation = just making fields private" - INCOMPLETE. Must also
 *   expose CONTROLLED access (via properties/methods) that enforces rules -
 *   private fields with zero external interaction aren't useful either.
 *
 * GOTCHA / MISCONCEPTION #3:
 *   "=> and { get; private set; } are interchangeable" - FALSE.
 *   '=>' has NO set accessor at all (assign backing field directly, usually
 *   only in constructor). '{ get; private set; }' allows the class's OWN
 *   methods to update the value later (e.g., Deposit()/Withdraw() patterns).
 */

#endregion

#region 2.4 - Inheritance

/*
 * INHERITANCE: derived class (subclass/child) inherits fields, properties,
 *              methods from base class (parent/superclass). Creates "is-a"
 *              relationship: Dog is-a Animal.
 *
 * SYNTAX: public class Dog : Animal { ... }
 *         Dog inherits all public/protected members of Animal.
 *
 * CONSTRUCTOR CHAINING (: base(...)):
 *   When derived object is created, constructors run derived -> base.
 *   MUST explicitly chain with ': base(param1, param2)' passing what
 *   the base constructor needs.
 *   If base class has NO parameterless constructor AND you don't write
 *   ': base(...)', compile error - chaining is MANDATORY in that case.
 *   ALWAYS write ': base(...)' explicitly for clarity, even if parameterless
 *   constructor exists (implicit call is fragile).
 *
 * PROTECTED access modifier:
 *   Accessible from: same class + derived classes (but NOT outside callers).
 *   Used when base class wants derived classes to access/modify something,
 *   but external code shouldn't touch it.
 *
 * VIRTUAL methods and OVERRIDE (deep dive in 2.5, preview here):
 *   Base class marks method 'virtual' - derived classes can 'override' it.
 *   Enables polymorphism: same method name, different behavior per type.
 *
 * BASE keyword:
 *   Refers to the base class. Use base.MethodName() to call base version
 *   even if overridden. Common: base.Speak(); then add derived logic.
 *
 * GOTCHA / MISCONCEPTION #1:
 *   "Derived classes can access ALL base members" - FALSE. Can access
 *   public/protected, but NOT private (strictly internal to base).
 *
 * GOTCHA / MISCONCEPTION #2:
 *   "C# supports multiple inheritance" - FALSE. Single inheritance only
 *   (can inherit from ONE class). Can implement MULTIPLE interfaces (coming 2.6).
 *
 * GOTCHA / MISCONCEPTION #3:
 *   "Constructor chaining is automatic/optional" - INCOMPLETE. C# auto-calls
 *   parameterless base constructor if it exists and you don't write ': base(...)'.
 *   But if base has NO parameterless constructor, ': base(...)' is MANDATORY
 *   or compile error. Always write explicitly for clarity and safety.
 */

#endregion

#region 2.5 - Polymorphism

/*
 * POLYMORPHISM: ability of objects to take multiple forms through inheritance.
 *               Call a method on a base-typed variable, and the ACTUAL OBJECT's
 *               implementation runs (runtime type dispatch), not the variable's
 *               declared type.
 *
 * VIRTUAL + OVERRIDE (True Polymorphism):
 *   public class Animal { public virtual void Speak() { ... } }
 *   public class Dog : Animal { public override void Speak() { ... } }
 *   
 *   Animal dog = new Dog();
 *   dog.Speak(); // calls Dog's override (RUNTIME TYPE decides)
 *
 * METHOD HIDING WITH 'new' (NOT Polymorphism - Interview Trap!):
 *   public class Animal { public virtual void Speak() { ... } }
 *   public class Dog : Animal { public new void Speak() { ... } } // hides, doesn't override
 *   
 *   Animal dog = new Dog();
 *   dog.Speak(); // calls Animal's method (DECLARED TYPE decides)
 *   Dog direct = new Dog();
 *   direct.Speak(); // calls Dog's method
 *   SAME OBJECT, DIFFERENT OUTPUTS based on declared type!
 *
 * KEY DISTINCTION:
 *   override = polymorphic, runtime dispatch (what OOP is about)
 *   new = non-polymorphic, compile-time dispatch (hides method, bad practice usually)
 *
 * SEALED keyword:
 *   public sealed override void Speak() { ... }
 *   Prevents further overriding of this method in derived classes.
 *
 * BASE keyword in overrides:
 *   public override void Eat() {
 *       base.Eat();  // call base implementation first, then extend
 *       Console.WriteLine("Tail wagging!");
 *   }
 *   Optional - only use when you want to EXTEND base behavior.
 *
 * GOTCHA / MISCONCEPTION #1:
 *   "Overriding and hiding are the same" - FALSE. Override = polymorphic
 *   (runtime type), hiding = non-polymorphic (declared type).
 *
 * GOTCHA / MISCONCEPTION #2:
 *   "The method that runs is always what I see in the code" - FALSE.
 *   With virtual/override, the RUNTIME TYPE's method runs, not the
 *   declared type's. This is the whole point of polymorphism.
 *
 * GOTCHA / MISCONCEPTION #3:
 *   "You must call base.MethodName() when overriding" - FALSE. Calling
 *   base is optional - only if you want to EXTEND base behavior.
 *   If you want to completely REPLACE it, don't call base.
 *
 * GOTCHA / MISCONCEPTION #4 (Interview Classic):
 *   Watch questions that ask "What does this print?" with a combination
 *   of declared vs runtime types and virtual/hidden methods. The trap is
 *   confusing override (runtime dispatch) with new (compile-time dispatch).
 */

#endregion

#region 2.6 - Abstraction

/*
 * ABSTRACTION: hiding complexity, exposing only what's necessary.
 *              Defines a CONTRACT - what derived/implementing classes must do.
 *
 * ABSTRACT CLASSES:
 *   - CANNOT be instantiated (new AbstractClass() -> compile error)
 *   - Can have STATE (fields, properties, constructor)
 *   - Can have CONCRETE methods (with implementation)
 *   - Can have ABSTRACT methods (no implementation, derived classes MUST implement)
 *   - Single inheritance only (one base class)
 *   - Used for "is-a" relationships with SHARED STATE/BEHAVIOR
 *
 *   Rule: Derived class MUST implement ALL abstract methods, or it too becomes abstract.
 *
 * INTERFACES:
 *   - CANNOT be instantiated (new IInterface() -> compile error)
 *   - NO state (only properties, no backing fields)
 *   - Can have DEFAULT implementations (C# 8+, but usually just contract)
 *   - ALL members are public by default
 *   - MULTIPLE inheritance allowed (one class implements many interfaces)
 *   - Used for CAPABILITY/CONTRACT, independent of class hierarchy
 *
 * ABSTRACT CLASS vs INTERFACE:
 *   Abstract class = shared state + behavior (Vehicle -> Car, Truck)
 *   Interface = capability contract (IFlyer, IPrintable)
 *
 * DEFAULT INTERFACE IMPLEMENTATIONS (C# 8+):
 *   public interface ILogger {
 *       void Log(string message);
 *       void LogError(string msg) { Console.WriteLine("[ERROR] " + msg); }
 *   }
 *   Implementing class can use LogError's default, or override it.
 *
 * SEALED keyword:
 *   public sealed class Final : Base { }
 *   Prevents further inheritance. Used when a class is "final" and shouldn't be subclassed.
 *
 * GOTCHA / MISCONCEPTION #1:
 *   "Interfaces are just abstract classes with all abstract members" - INCOMPLETE.
 *   Philosophical difference: abstract class = is-a relationship (shared state),
 *   interface = capability/contract independent of inheritance.
 *
 * GOTCHA / MISCONCEPTION #2:
 *   "Always use interfaces instead of abstract classes" - FALSE. Use abstract class
 *   when derived classes genuinely share STATE and COMMON BEHAVIOR.
 *   Use interface when defining a CAPABILITY multiple unrelated classes might have.
 *
 * GOTCHA / MISCONCEPTION #3:
 *   "A class can only implement one interface" - FALSE. Multiple interfaces:
 *   public class Dog : IAnimal, IFlyer, ISwimmer { }
 *
 * INTERVIEW QUESTION (very common):
 *   "When would you use abstract class vs interface?"
 *   Answer with EXAMPLES:
 *   - Abstract: Vehicle (shared Speed, Start() behavior) -> Car, Truck
 *   - Interface: IDisposable (cleanup contract) -> multiple unrelated classes
 */

#endregion

#region 2.7 - record vs struct vs class

/*
 * CLASS (reference type):
 *   - Stored on HEAP. Variable holds a REFERENCE.
 *   - Mutable by default (fields/properties can change).
 *   - Reference equality: == compares references, not values (unless overridden).
 *   - Identity matters: p1 and p2 with same values are DIFFERENT objects.
 *   - Use for: mutable business entities (User, Product, Order).
 *
 * STRUCT (value type):
 *   - Stored on STACK (when local) or INLINE (in arrays).
 *   - Variable holds the ACTUAL DATA (not a reference).
 *   - Mutable by default, but mutable structs are BAD PRACTICE.
 *   - Value equality: == compares field values by default.
 *   - COPY SEMANTICS: assignment copies entire struct (expensive for large structs!).
 *   - Use for: small, immutable data (Point, Color, Vector3).
 *   - SIZE RULE: keep structs <~16 bytes. Larger = use class.
 *
 * RECORD (reference type by default, value semantics):
 *   - record class = reference type (default)
 *   - record struct = value type (rare)
 *   - Value-based equality: == compares field values (like struct behavior!)
 *   - init-only properties by default: immutable after creation.
 *   - WITH expression: non-destructive mutation (creates a copy with one field changed).
 *   - Auto-generates ToString, Equals, GetHashCode.
 *   - Use for: DTOs, data models, API responses (value semantics, immutable, concise).
 *
 * INIT accessor (C# 9+):
 *   public string Name { get; init; } - settable only during initialization, never after.
 *   Enables immutability in any class/record.
 *
 * GOTCHA / MISCONCEPTION #1:
 *   "Structs are always faster" - FALSE. Only if small+immutable. Large mutable structs
 *   are SLOWER than class references due to copying overhead.
 *
 * GOTCHA / MISCONCEPTION #2:
 *   "Records are always immutable" - INCOMPLETE. Records are init-only by DEFAULT,
 *   but can have mutable properties if you explicitly make them { get; set; }.
 *
 * GOTCHA / MISCONCEPTION #3:
 *   "Record equality = class equality" - FALSE. Records have VALUE-BASED equality
 *   like structs (compare field values). Classes have REFERENCE equality.
 *
 * GOTCHA / MISCONCEPTION #4:
 *   "Mutable struct in a collection" - TRAP! Modifying struct in collection
 *   modifies a COPY that gets discarded. Changes are LOST. This is why mutable
 *   structs are strongly discouraged.
 *
 * RULE OF THUMB:
 *   class = entity with identity + mutable state
 *   struct = small, immutable data (Point, Color, Date)
 *   record = DTO/data model with value semantics + immutability
 */

#endregion