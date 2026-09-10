// ============================================================
// MODULE 3: TYPE SYSTEM DEEP DIVE
// ============================================================

#region 3.1 - Value Types vs Reference Types (Stack vs Heap)

/*
 * VALUE TYPES:
 *   int, double, bool, char, struct, enum
 *   Assignment copies ACTUAL VALUE.
 *
 * REFERENCE TYPES:
 *   class, string, array, interface, delegate, record class
 *   Assignment copies REFERENCE (pointer), not object data.
 *
 * DEFAULT METHOD PARAMETER PASSING IN C#:
 *   Always pass-by-value (unless ref/out/in used).
 *   - For value types: copy of value
 *   - For reference types: copy of reference (same heap object)
 *
 * STRING SPECIAL CASE:
 *   string is a REFERENCE TYPE but IMMUTABLE.
 *   Any "modification" creates a new string object.
 *
 * INTERVIEW-SAFE STACK/HEAP EXPLANATION:
 *   Value types have value semantics.
 *   Reference types have reference semantics.
 *   Locals may be stack/register optimized, objects are heap-allocated by default.
 *   Avoid simplistic claim: "all value types always on stack."
 *
 * COMMON TRAP:
 *   "C# passes objects by reference by default" -> FALSE.
 *   C# passes by VALUE by default, including reference variables
 *   (copy of reference, not copy of object).
 */

#endregion

#region 3.2 - Boxing and Unboxing

/*
 * BOXING:
 *   Converting value type to object/interface.
 *   Example: int x = 10; object o = x;
 *   Runtime effect: heap allocation (boxed object created).
 *
 * UNBOXING:
 *   Converting object/interface back to value type.
 *   Requires explicit cast.
 *   Example: int y = (int)o;
 *
 * IMPORTANT RULE:
 *   Unboxing must be to the EXACT runtime boxed type.
 *   object o = 10; long l = (long)o; // InvalidCastException
 *   Correct: int i = (int)o; long l = i;
 *
 * PERFORMANCE IMPACT:
 *   Frequent boxing/unboxing increases allocations and GC pressure.
 *   Avoid old non-generic collections (ArrayList) for value types.
 *   Prefer generic collections: List<int>, Dictionary<int, int>, etc.
 *
 * INTERVIEW TRAP:
 *   "C# automatically converts boxed int to long on unboxing" -> FALSE.
 *   Unboxing is type-exact.
 */

#endregion

#region 3.3 - Nullable Types

/*
 * NULLABLE VALUE TYPES:
 *   int? x = null; // equivalent to Nullable<int>
 *   Members: HasValue, Value, GetValueOrDefault()
 *   Value throws InvalidOperationException if null.
 *
 * NULLABLE REFERENCE TYPES (NRT):
 *   string  -> intended non-null
 *   string? -> allowed null
 *   Compiler warns about possible null dereference.
 *
 * NULL-SAFE OPERATORS:
 *   ?.   null-conditional access
 *   ??   null-coalescing fallback
 *   ??=  assign only if null
 *
 * EXAMPLE:
 *   string? s = null;
 *   int len = s?.Length ?? 0;
 *
 * WARNING:
 *   null-forgiving operator '!' only suppresses warning.
 *   It does NOT prevent runtime null exceptions.
 */

#endregion