### Problem 3: Order Processor & Tight Coupling

* **Violation of the Dependency Inversion Principle (DIP):** The `OrderProcessor` class was tightly coupled to concrete implementations (`SqlOrderRepository` and `SmtpEmailSender`) using direct `new` keywords.
* **Lack of Testability & Flexibility:** Because dependencies were hardcoded inside the method, it was impossible to write isolated unit tests without touching a real database or SMTP service. Furthermore, switching to a different database or messaging channel (like WhatsApp or SMS) required modifying the `OrderProcessor` class directly.


### Solution 3: Dependency Inversion & Constructor Injection

* **Abstraction (`IOrderRepository` & `IMessageSender`):** Introduced clean interfaces to decouple the high-level business logic from low-level execution details.
* **Constructor Injection:** The dependencies are now injected via the `OrderProcessor` constructor, adhering to SOLID principles.
* **Flexibility & Extensibility:** The processor now works seamlessly with any repository or messaging channel (e.g., `WhatsAppSender`, `SmsSender`) without requiring code changes.