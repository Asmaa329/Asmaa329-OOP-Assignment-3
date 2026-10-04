# Refactoring Documentation: Notification System

## 1. Problem Summary

In the original implementation, the system heavily relied on deep **Inheritance Hierarchies** to support varying requirements for each notification (Channel Type + Urgency + Scheduling).

This approach led to an architectural issue known as **Combinatorial Class Explosion**, where the number of required classes multiplied with every newly added feature.

* **Class count in the old code:**
  * 2 Delivery Channels (Email, SMS) $\times$ 2 Urgency Levels (Normal, Urgent) $\times$ 2 Timing Options (Immediate, Scheduled) = **8 Classes**.
  * Adding a 3rd channel (e.g., Push Notifications) would immediately require creating **4 new classes** to cover all feature combinations.

---

## 2. Identified Code Smells

1. **Class Explosion:** Extreme code duplication across classes like `UrgentScheduledEmailNotification` and `UrgentScheduledSmsNotification`.
2. **Single Responsibility Principle (SRP) Violation:** A single class was simultaneously responsible for channel-specific delivery logic, formatting urgent tags (`[URGENT]`), and handling scheduling metadata (`[scheduled]`).
3. **Open/Closed Principle (OCP) Violation:** Modifying the formatting logic of urgent notifications required making changes across multiple classes in the inheritance tree.

---

## 3. The Solution: Decorator Pattern

The **Decorator Pattern** was implemented to shift the architecture from **Inheritance** to **Dynamic Composition**.

Instead of creating dedicated subclasses for every single feature combination, the system was decoupled into two independent parts:
1. **Core Channels:** Concrete implementations like `EmailNotification` and `SmsNotification` that focus purely on delivering the message through a specific transport.
2. **Decorators/Behaviors:** Classes like `UrgentNotification` and `UrgentScheduledNotification` that wrap any `INotification` instance to dynamically attach additional responsibilities without knowing the underlying channel details.

---

## 4. How Decorators Work

Behavioral decorators (`UrgentNotification` and `UrgentScheduledNotification`) do not care about the underlying delivery channel. Instead, they accept any
`INotification` instance via their constructor, modify the payload/behavior, and delegate execution:

## 4. Extensibility Proof
* **Adding a new Channel (`WhatsAppNotification`):** Created 1 single class implementing `INotification`.
* **Result:** `WhatsAppNotification` immediately supports Urgent, Scheduled, or Urgent+Scheduled variations **without writing any extra classes**.

