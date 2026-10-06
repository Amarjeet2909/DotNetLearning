// ============================================================
// MODULE 4: COLLECTIONS AND GENERICS
// ============================================================

#region 4.1 - Arrays

/*
 * ARRAY:
 *   Fixed-size, ordered collection of SAME-TYPE elements.
 *   Arrays are reference types, even when elements are value types (int[]).
 *
 * INDEXING:
 *   Zero-based: first = array[0], last = array[array.Length - 1].
 *   Invalid index throws IndexOutOfRangeException.
 *
 * FIXED SIZE:
 *   int[] values = new int[3]; // exactly 3 positions forever.
 *   Cannot add a 4th value without creating/copying to another array.
 *   Use List<T> when size must grow/shrink dynamically.
 *
 * DEFAULT VALUES:
 *   new int[3]     -> 0, 0, 0
 *   new bool[3]    -> false, false, false
 *   new string?[3] -> null, null, null
 *
 * ASSIGNMENT VS COPY:
 *   int[] second = first;       // copies REFERENCE -> same array object.
 *   int[] copy1 = (int[])first.Clone(); // copies array container.
 *   int[] copy2 = first[..];    // modern full-range copy.
 *
 * SHALLOW COPY GOTCHA:
 *   Copying Person[] copies Person REFERENCES, not new Person objects.
 *   Changing a referenced Person affects both arrays.
 *
 * ITERATION:
 *   for     -> use when index is needed.
 *   foreach -> use when only element values are needed.
 *
 * COMPLEXITY:
 *   Read/update by index = O(1)
 *   Unsorted search = O(n)
 *   Insert/remove in middle = O(n)
 *   Length = O(1)
 *
 * MULTI-DIMENSIONAL VS JAGGED:
 *   int[,]  rectangular/fixed grid: matrix[row, column]
 *   int[][] jagged array: each inner row may have different length: rows[row][column]
 *
 * COMMON ARRAY METHODS:
 *   Array.Sort(), Array.Reverse(), Array.Copy(), Array.IndexOf()
 *
 * INTERVIEW TRAP:
 *   Arrays have fixed SIZE, but individual elements can change.
 *   int[] b = a does NOT clone the array — it copies the reference.
 */

#endregion

#region 4.2 - List, Dictionary, HashSet, Queue, Stack

/*
 * LIST<T>:
 *   Dynamic, ordered collection. Duplicates allowed.
 *   Internally uses a resizable array.
 *   Index access = O(1); search/remove/insert middle = O(n);
 *   Add at end = amortized O(1).
 *   Use when: ordered data, dynamic size, duplicates allowed.
 *
 * DICTIONARY<TKey, TValue>:
 *   Maps unique keys to values. Hash-table based.
 *   Add/lookup/remove by key = O(1) average.
 *   Keys unique; values can duplicate.
 *   dictionary[key] throws KeyNotFoundException if key missing.
 *   Prefer TryGetValue() for safe external/optional lookup.
 *   Use when: key -> value mapping (id -> user, char -> frequency).
 *
 * HASHSET<T>:
 *   Unique values only. Hash-table based.
 *   Add/Contains/Remove = O(1) average.
 *   Add(item) returns false for duplicate.
 *   Use when: fast membership and uniqueness matter.
 *
 * QUEUE<T>:
 *   FIFO: First In, First Out.
 *   Enqueue = add newest at end.
 *   Dequeue = remove oldest from front.
 *   Peek = inspect oldest without removal.
 *   Use when: jobs/tickets/process oldest work first.
 *
 * STACK<T>:
 *   LIFO: Last In, First Out.
 *   Push = add newest to top.
 *   Pop = remove newest from top.
 *   Peek = inspect newest without removal.
 *   Use when: undo/browser history/DFS/balanced parentheses.
 *
 * COLLECTION SELECTION:
 *   Fixed size -> array
 *   Dynamic ordered values -> List<T>
 *   Key-to-value lookup -> Dictionary<TKey, TValue>
 *   Unique membership -> HashSet<T>
 *   Oldest first -> Queue<T>
 *   Newest first -> Stack<T>
 *
 * GOTCHA:
 *   Queue.Dequeue(), Stack.Pop(), Dictionary[key] can throw when empty/key absent.
 *   Use TryDequeue(), TryPop(), and TryGetValue() when absence is normal.
 */

#endregion