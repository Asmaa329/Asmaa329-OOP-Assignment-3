* **What is the same:**
  Both `StudentStore` and `CourseStore` share identical structural logic and method signatures (`Add`, `GetById`, `GetAll`, `Remove`). They both manage an underlying collection and perform lookup/removal operations based on an `Id`.

* **What is different:**
  The underlying data types being stored and manipulated differ (`Student` vs `Course`).



## Step 3 — One class for both

* **Compiler Error:**
  `CS1061: 'T' does not contain a definition for 'Id' and no accessible extension method 'Id' accepting a first argument of type 'T' could be found`

* **Explanation in own words:**
  When writing `Store<T>` without constraints, C# treats `T` as a completely generic type (inheriting only from `System.Object`). 
  Because `System.Object` has no `Id` property, the compiler cannot guarantee that any type passed as `T` at runtime will have an `Id`. To prevent runtime errors, C# rejects the access to `item.Id` at compile time.

  ## Step 7 — Prove it in Main

***Why `new Store<string>()` does NOT compile:**
  `Store < T >` enforces a generic type constraint(`where T: IHasId`). The `System.String` type does not implement the `IHasId` interface. Therefore, attempting to instantiate `Store<string>` produces a compilation error(`CS0311`).

---

## Common Name Question

* **What is the common name for the kind of class built in Steps 4 and 5?**
  **Repository** (or** Generic Repository Pattern**).