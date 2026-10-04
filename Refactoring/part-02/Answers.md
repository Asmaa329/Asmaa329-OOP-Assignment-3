## Part 2: Reports (Template Method Pattern)

### Why an Abstract Class is a Better Fit Than an Interface

In this refactoring task, using an **abstract class** (`ReportExporter`) is significantly better suited for implementing the **Template Method pattern** than an **interface** for the following key reasons:

1. **Centralized Workflow Control (Template Method Core):**
   - An abstract class allows us to define the invariant execution sequence inside `Export(string path)` in **one central place**. 
   - While modern C# interfaces support Default Interface Methods (DIM), interfaces cannot prevent implementing classes from overriding or bypassing the overall template workflow. An abstract class enforces the template structure and lifecycle directly.

2. **Code Sharing and Avoiding Duplication (DRY Principle):**
   - The default operations (`Load()`, `Validate()`, and `Save()`) are completely identical across all exporter types. 
   - An abstract class provides inherited state and concrete default implementations that subclasses receive automatically without duplicating code or re-declaring execution logic.

3. **Controlled Extension Points via Access Modifiers:**
   - Abstract classes allow fine-grained access control using `protected virtual` and `protected abstract` modifiers for internal algorithm steps (`Load`, `Validate`, `Format`, `Save`).
   - This ensures internal helper operations remain encapsulated within the exporter hierarchy rather than exposed publicly to external consumers.

4. **Adherence to Design Principles:**
   - **Single Responsibility Principle (SRP):** Core data workflow execution is separated from output formatting.
   - **Open/Closed Principle (OCP):** Adding a new report format (e.g., XML) requires creating a single lightweight class overriding only `Format()`, without touching the overall export process.


   ## Enrollment Refactoring (Facade Pattern)

### What problem does the Facade solve here?
In the original code, the client (`Program.cs`) had to directly instantiate and orchestrate four distinct subsystem services (`PaymentGateway`, `SeatInventory`, `InvoiceGenerator`, and `EmailService`) in a strict sequential order to process a single student enrollment. This led to high coupling, code duplication, and exposed the internal workflow implementation details to the caller. 

The `EnrollmentFacade` solves this by encapsulating the interaction logic behind a unified, high-level interface (`EnrollStudent`), simplifying execution and decoupling the caller from subsystem details.

### What does the caller no longer need to know?
1. **Subsystem Dependencies:** The caller no longer needs to know about or instantiate `PaymentGateway`, `SeatInventory`, `InvoiceGenerator`, or `EmailService`.
2. **Execution Order & Workflow:** The caller does not need to know the correct sequence of steps required for enrollment (e.g., charging payment before creating an invoice, or passing the generated `invoiceId` to the email service).
3. **Internal Data Passing:** The caller no longer handles intermediate values, such as capturing the `invoiceId` from `InvoiceGenerator.Create()` to pass it into `EmailService.Send()`.