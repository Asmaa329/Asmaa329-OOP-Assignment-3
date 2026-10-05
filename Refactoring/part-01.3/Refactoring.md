
# Refactoring Documentation

## 1. Problem Summary

The original codebase suffered from two major architectural code smells that reduced maintainability and violated key Object-Oriented Design principles:

### Problem 1: Shipping Cost Calculator
* **Violation of the Open/Closed Principle (OCP):** The calculation logic relied on a central switch-case statement driven by hardcoded string identifiers for each carrier. Adding a new carrier or updating an existing rate required modifying the core calculator class directly.
* **Lack of Type Safety:** Using raw string parameters introduced a high risk of runtime bugs caused by typos or capitalization mismatches.

## 2. Solutions & Applied Design Patterns

* **Separation of Concerns:** Each carrier's shipping rate calculation rule was encapsulated into its own dedicated class implementing a unified carrier contract.
* **Loose Coupling:** The shipping cost calculator no longer performs conditional logic or knows specific formulas; it delegates the calculation step directly to whichever carrier strategy is provided.


## 3. Extensibility & Future Impact

1. **Adding a New Shipping Carrier:**
   * Requires creating only one new class that fulfills the carrier contract.
   * The core calculator class and existing carrier implementations remain untouched and do not require re-testing.

