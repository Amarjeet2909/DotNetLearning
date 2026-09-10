// ============================================================
// MODULE 1: LANGUAGE BASICS
// ============================================================

#region 1.1 - What is C# / .NET / CLR?

/*
 * C# — statically-typed, OOP language by Microsoft (2000, Anders Hejlsberg)
 * .NET — platform = runtime + class library (BCL) + tooling
 *
 * History:
 *   .NET Framework (legacy, Windows-only)
 *     -> .NET Core (cross-platform)
 *       -> .NET 5+ (unified, yearly releases)
 *         -> Currently on .NET 10
 *
 * EXECUTION FLOW:
 *   C# Source (.cs)
 *     -> Roslyn Compiler
 *       -> IL Code (assembly .dll/.exe)
 *         -> CLR loads it
 *           -> JIT compiles IL to native code
 *             -> CPU executes
 *
 * KEY TERMS:
 *   CLR (Common Language Runtime) - virtual machine managing execution,
 *                                   memory (GC), type safety, exceptions
 *   IL  (Intermediate Language)   - CPU-independent bytecode, output of compiling C#
 *   JIT (Just-In-Time compiler)   - converts IL to native machine code at runtime
 *   Managed code                  - execution managed by CLR (vs "unmanaged" C/C++)
 *
 * GOTCHA / MISCONCEPTION:
 *   C# does NOT compile directly to machine code.
 *   It compiles to IL first; JIT converts IL to native code at runtime.
 *   This is what makes .NET cross-platform.
 *
 * TO REVISIT LATER:
 *   Native AOT compilation (skips JIT, compiles to native code at build time)
 *   - relevant for cloud/container deployments.
 */

#endregion

#region 1.2 - Variables, Data Types, Type Inference

/*
 * C# is statically typed: type is fixed at COMPILE TIME, cannot change.
 *
 * VALUE TYPES (store data directly):
 *   byte    - 8-bit   - 0 to 255
 *   short   - 16-bit  - -32,768 to 32,767
 *   int     - 32-bit  - ~-2.1B to 2.1B
 *   long    - 64-bit  - very large numbers          (suffix: L)
 *   float   - 32-bit  - ~7 digit precision          (suffix: f)
 *   double  - 64-bit  - ~15-16 digit precision
 *   decimal - 128-bit - exact, use for MONEY        (suffix: m)
 *   bool    - true/false
 *   char    - single UTF-16 character
 *
 * VAR / TYPE INFERENCE:
 *   'var' = compiler infers type at COMPILE TIME. NOT dynamic typing.
 *   Once inferred, type is locked (same as explicit typing).
 *   Use 'var' when type is obvious from right-hand side.
 *
 * DEFAULT VALUES:
 *   int -> 0, bool -> false, string -> null, double -> 0.0
 *   Use 'default' keyword: int x = default; // 0
 *
 * GOTCHA #1:
 *   'var' does NOT make C# dynamically typed.
 *   'dynamic' keyword exists separately for actual runtime typing (rare, advanced).
 *
 * GOTCHA #2 (IMPORTANT):
 *   double/float use binary floating point -> imprecise for decimals (0.1 + 0.2 != 0.3 exactly)
 *   decimal uses base-10 internally -> EXACT, always use for currency/financial data
 *
 *   Example:
 *     double d = 0.1 + 0.2;   // 0.30000000000000004
 *     decimal m = 0.1m + 0.2m; // 0.3 (exact)
 *
 * RULE OF THUMB: decimal = money, double = scientific/general math, int/long = whole numbers
 */

#endregion

#region 1.3 - Operators and Expressions

/*
 * OPERATOR CATEGORIES:
 *   Arithmetic:    + - * / %
 *   Comparison:    == != > < >= <=
 *   Logical:       && || !
 *   Assignment:    = += -= *= /= %=
 *   Increment:     ++ --
 *   Null-handling: ?? ??= ?.
 *   Bitwise:       & | ^ ~ << >>
 *   Ternary:       ?:
 *
 * GOTCHA #1 - Integer division truncates, does not round:
 *   int result = 7 / 2;              // 3, NOT 3.5
 *   double result = (double)7 / 2;   // 3.5 (cast at least one operand)
 *
 * GOTCHA #2 - Pre vs Post increment:
 *   x++  -> POST: use current value, THEN increment
 *   ++x  -> PRE:  increment FIRST, then use new value
 *
 *   int a = 5;
 *   int r1 = a++; // r1 = 5, a becomes 6
 *   int b = 5;
 *   int r2 = ++b; // r2 = 6, b becomes 6
 *
 * IMPORTANT PATTERN - Short-circuit evaluation:
 *   && and || stop evaluating as soon as result is known.
 *   USED TO PREVENT NullReferenceException:
 *     if (name != null && name.Length > 0) { ... }
 *   If 'name != null' is false, 'name.Length' is NEVER evaluated -> no crash.
 *   ORDER MATTERS: reversing the condition would throw if name is null.
 *
 * NULL-HANDLING OPERATORS (heavily used in real code):
 *   ??   - null-coalescing: value ?? fallback
 *   ??=  - null-coalescing assignment: assign only if currently null
 *   ?.   - null-conditional: safely access member, returns null instead of throwing
 *
 *   Common chained pattern:
 *     int length = name?.Length ?? 0; // safe access + fallback default
 *
 * TERNARY OPERATOR:
 *   condition ? valueIfTrue : valueIfFalse
 *   Use for SIMPLE single-condition assignments only.
 *   Avoid nesting ternaries - hurts readability, prefer switch expression instead.
 *
 * BITWISE (rarely used daily, but common in DSA interviews):
 *   & AND | OR ^ XOR ~ NOT << left shift (x2) >> right shift (/2)
 */

#endregion

#region 1.4 - Type Conversion

/*
 * FOUR WAYS TO CONVERT TYPES:
 *   1. Implicit conversion - automatic, safe, no data loss (widening: int -> long -> double)
 *   2. Explicit conversion (casting) - manual, may lose data: (int)someDouble
 *   3. Convert class - safer utility, handles null, ROUNDS floating point
 *   4. Parse / TryParse - string to number conversions
 *
 * GOTCHA #1 - CAST TRUNCATES, Convert ROUNDS:
 *   int a = (int)9.99;              // 9  (truncates)
 *   int b = Convert.ToInt32(9.99);  // 10 (rounds)
 *   To round with a cast: (int)Math.Round(9.99); // 10
 *
 * GOTCHA #2 - Parse throws, TryParse doesn't:
 *   int.Parse("abc")     -> throws FormatException
 *   int.TryParse("abc", out int result) -> returns false, result = 0, NO exception
 *   BEST PRACTICE: always prefer TryParse for user input / untrusted strings.
 *
 * GOTCHA #3 - Integer overflow is SILENT by default:
 *   int overflow = int.MaxValue + 1; // wraps to negative number, NO exception by default
 *   Use 'checked(...)' to force an OverflowException to be thrown instead.
 *   Use 'unchecked(...)' to explicitly allow silent wraparound (rarely needed, it's default).
 *
 * RULE OF THUMB:
 *   - Use TryParse for any external/user input.
 *   - Use Convert when you want proper rounding behavior.
 *   - Use direct cast only when you fully understand truncation is acceptable.
 */

#endregion

#region 1.5 - Control Flow

/*
 * SELECTION STATEMENTS:
 *   if/else if/else   - checks conditions top to bottom, runs FIRST true branch, skips rest
 *   switch statement   - classic, requires break/return/throw per case (NO implicit fall-through in C#)
 *   switch expression  - modern (C# 8+), returns a value directly, uses '_' as discard/default
 *
 * GOTCHA - if/else order matters:
 *   Broader conditions before narrower ones can make later conditions unreachable.
 *   Always order from MOST specific to LEAST specific (or vice versa consistently).
 *
 * GOTCHA - switch fall-through:
 *   C# does NOT allow implicit fall-through between non-empty cases (compile error).
 *   Empty case labels CAN be stacked together (case "A": case "B": ... break;) - that's grouping, not fall-through.
 *
 * ITERATION STATEMENTS:
 *   for        - known number of iterations: for(init; condition; iterator)
 *   while      - condition checked BEFORE each iteration, may run ZERO times
 *   do-while   - condition checked AFTER each iteration, GUARANTEES at least one execution
 *   foreach    - iterates over IEnumerable collections (arrays, List, Dictionary, etc.)
 *
 * GOTCHA - foreach + modifying collection:
 *   Cannot Add/Remove from a collection while iterating with foreach ->
 *   throws InvalidOperationException (enumerator's internal state becomes invalid).
 *
 * JUMP STATEMENTS:
 *   break    - exits the loop/switch ENTIRELY
 *   continue - skips ONLY current iteration, loop continues
 *
 * GOTCHA - nested loops:
 *   break/continue only affect the INNERMOST loop they are inside.
 *   To exit an outer loop from an inner one: use a flag variable, extract to a method
 *   with 'return', or (rarely) a labeled goto.
 *
 * RULE OF THUMB:
 *   - Use switch EXPRESSION when producing a single value.
 *   - Use switch STATEMENT when each branch needs multiple statements/side effects.
 *   - Use do-while specifically when you need "run at least once" behavior (e.g., menus).
 */

#endregion

#region 1.6 - Methods & Parameter Passing (ref, out, in, params)

/*
 * DEFAULT (pass-by-value):
 *   Value types: a COPY is passed. Changes inside method do NOT affect caller.
 *   Reference types: the REFERENCE is copied, but points to the SAME object.
 *     - Modifying the object's MEMBERS affects the caller (same object on heap).
 *     - REASSIGNING the parameter to a new object does NOT affect the caller
 *       (only the local copy of the reference is reassigned).
 *
 * ref:
 *   - Passes by reference. Method operates on the CALLER'S actual variable.
 *   - Variable MUST be initialized before the call.
 *   - 'ref' keyword required at BOTH method signature AND call site.
 *   - Use case: modify an existing variable directly (e.g., swap values).
 *
 * out:
 *   - Passes by reference. Variable does NOT need to be initialized before call.
 *   - Method MUST assign a value to it before returning.
 *   - Use case: return MULTIPLE values from one method (e.g., TryParse, TryGetValue pattern).
 *
 * in:
 *   - Passes by reference but READ-ONLY (cannot modify inside method - compile error if attempted).
 *   - Use case: avoid copying LARGE STRUCTS for performance, while guaranteeing no mutation.
 *   - Micro-optimization - not needed for small structs/classes.
 *
 * params:
 *   - Allows variable number of arguments of the same type (passed as an array internally).
 *   - Must be the LAST parameter in the method signature. Only ONE params allowed per method.
 *   - Can also directly pass an existing array instead of individual values.
 *
 * SUMMARY TABLE:
 *   (default) - must init: YES - modifies caller: NO  - use: normal passing
 *   ref       - must init: YES - modifies caller: YES - use: modify existing variable
 *   out       - must init: NO  - modifies caller: YES (must assign) - use: return multiple values
 *   in        - must init: YES - modifies caller: NO (read-only)    - use: avoid copying large structs
 *   params    - must init: N/A - modifies caller: N/A (local array) - use: variable argument count
 *
 * INTERVIEW TRAP (VERY COMMON):
 *   "Is C# pass-by-value or pass-by-reference?"
 *   ANSWER: C# is pass-by-value BY DEFAULT, even for reference types.
 *   What's copied is the REFERENCE itself (for objects) or the VALUE (for value types).
 *   This is why modifying an object's fields through a parameter affects the caller,
 *   but reassigning the parameter to a brand new object does not.
 */

#endregion