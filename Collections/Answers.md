# Part 02: Research & Collection Selection

## Research: IReadOnlyDictionary & SortedDictionary

### 1. IReadOnlyDictionary<TKey, TValue>
* **What it is:** `IReadOnlyDictionary<TKey, TValue>` is an interface in .NET that represents a read-only collection of key-value pairs. It provides lookup methods and properties (such as `ContainsKey`, `TryGetValue`, and indexer reading), but intentionally omits mutation operations like `Add`, `Remove`, or `Clear`.
* **Difference from Dictionary:** `Dictionary<TKey, TValue>` is a mutable concrete class implementing `IDictionary<TKey, TValue>`, allowing callers to add, modify, or remove items at any time. `IReadOnlyDictionary` is an abstraction interface that completely prevents modifications.
* **Why return it from a public method:** Returning `IReadOnlyDictionary` enforces encapsulation and protects state integrity. It signals to callers that they can query data safely without altering or corrupting the internal collection of the underlying class.

---

### 2. SortedDictionary<TKey, TValue>
* **What it is:** `SortedDictionary<TKey, TValue>` is a collection that stores key-value pairs sorted automatically by key, implemented using a balanced binary search tree (Red-Black tree).
* **Difference from Dictionary (Ordering & Lookup Speed):**
  * **Ordering:** `Dictionary` maintains elements based on a hash table with no guaranteed sorting order. `SortedDictionary` automatically keeps its keys sorted continuously based on `IComparable` or a custom `IComparer`.
  * **Lookup Speed:** `Dictionary` provides $O(1)$ constant time average lookup, whereas `SortedDictionary` provides $O(\log n)$ logarithmic time lookup due to tree traversal.
* **When to choose it:** Use `SortedDictionary` when you need key-value storage that dynamically stays sorted as items are inserted or removed, especially when you frequently need to iterate through keys in sorted order.

---

## Task 2.2 — Pick the Collection

### S1: Find a student by national ID — thousands of times a day.
* **Collection:** `Dictionary`
* **Explanation:** Provides average $O(1)$ lookup speed, making it the fastest option for retrieving student records by unique national ID.

### S2: Keep the tags of a course. The same tag must never be stored twice.
* **Collection:** `HashSet`
* **Explanation:** Automatically prevents duplicate elements and offers $O(1)$ constant time operations for set membership checks.

### S3: Keep a student's grades in the order they were entered. The same grade can appear more than once.
* **Collection:** `List`
* **Explanation:** Maintains strict insertion ordering and allows duplicate elements to be stored without restriction.

### S4: A public method returns the course price list. Callers can read prices but must not add or change any.
* **Collection:** `IReadOnlyDictionary`
* **Explanation:** Exposes key-value price pairs for reading while explicitly preventing callers from modifying, adding, or deleting items.

### S5: A timetable keyed by session start time. Sessions are added at any moment, and it must always print in time order.
* **Collection:** `SortedDictionary`
* **Explanation:** Automatically keeps keys sorted upon every insertion, ensuring sessions remain ordered by their start time without manual sorting.

### S6: A method returns results that the caller only loops over once — and may stop early.
* **Collection:** `IEnumerable`
* **Explanation:** Supports deferred, streaming iteration, allowing the caller to process elements one by one and exit early without loading all results into memory.