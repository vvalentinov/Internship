## Code Smells And Problems:

1. Long Method (Register)

- The Register method is too long and does too many things.
- It violates the Single Responsibility Principle (SRP) because it handles validation, business rules, fee calculation, and database operations in one method.

2. Deeply Nested Code

- Excessive nested if conditions make the method hard to read and maintain.
- Refactoring Technique: Extract methods to simplify and flatten logic.

3. Magic Numbers & Hardcoded Values

- "Microsoft", "Google", "Fog Creek Software", "37Signals" are hardcoded employer names.
- 500, 250, 100, 50, and 0 for registration fees.
- Refactoring Technique: Replace magic numbers with named constants or configuration settings.

4. Poor Naming Conventions

- good, appr, and ot are unclear variable names.
- good does not communicate what is being validated.

5. Commented-Out Code

- Old, commented-out validation logic should be removed.

6. Poor Separation of Concerns

- The method mixes business logic, validation, and data persistence.

## Refactoring Techniques

1. Create speaker service to handle speaker registration and validation.
2. In Speaker class - only speaker properties and speaker methods.
3. Create speaker repository for adding, deleting, retrieving and updating speaker in the "db".
4. Create separate models for the Session and WebBrowser.
5. Create separate Exception classes for no sessions approved or when speaker doesn't meet requirements.
6. Create a static constants class - to hold const values.