# Part 03 — answers

---

## BlockedUsers

- **Time complexity before:** O(N * M)
- **Time (ms) before:** 146 ms 
- **What did you change?** 
  Changed the lookup mechanism inside `CountBlocked` by creating or taking a `HashSet<int>` instead of iterating linearly over a list. Searching inside a `HashSet` takes $O(1)$ constant time on average instead of $O(N)$ linear time.
- **Time complexity after:** O(N + M)
- **Time (ms) after:** 15 ms

---

## Students

- **What was the problem?**
  The `GetAllStudents` method was eagerly instantiating and adding 1,000,000 `Student` objects into a list in memory all at once, even though `Program.cs` only requested and printed the first 3 students.

- **What did you change?**
  Refactored `GetAllStudents` to return `IEnumerable<Student>` and used `yield return` for deferred/lazy execution. Instead of creating all objects upfront, items are generated on-demand as requested by `.Take(3)`, preventing the instantiation of the remaining 999,997 students.