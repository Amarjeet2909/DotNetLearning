# Copilot Instructions

## Project Guidelines
- User wants a full C# and Full Stack .NET tutorial taught E2E, module by module, with very large/detailed descriptions (like a full tutorial, not brief interview flashcards). For each concept, explicitly indicate: what to write in pen-and-paper notes (first-time learning), what to write in digital/IDE notes (Notes\ folder, .cs files with well-formatted XML doc comments/regions for review/searchability), and when to practice coding. Wants progress tracked across the conversation so nothing is repeated or lost. Prefers hybrid note-taking: pen & paper for first-time learning/diagrams/self-quizzing, digital .cs files in a Notes\ folder (e.g., Notes\01_LanguageBasics.cs) containing heavily commented explanations, organized with #region blocks or XML doc comments, so code examples inside get full IntelliSense/syntax highlighting, and an InterviewGotchas.md (also .cs format) for mistakes.
- Don't use graph LR for diagrams, use something which looks clean in chat for flowcharts and diagrams.
- Cover everything which can be asked in Interviews or generally asked.
- **Do NOT skip any topic even if user already knows it** — teach at full depth every time, since notes are being built for long-term/future interview prep, not just first-time learning. User explicitly wants no shortcuts and wants sufficiently deep teaching, and asks for clarification whenever a concept is unclear.
- Teaching format per topic (always 4 parts): Theory -> Explanation (with internals/misconceptions) -> Example (working C# code) -> Note-taking instructions (✍️ Pen & Paper / 💻 Digital Note in .cs format / 🧪 Practice exercise in Basics\ folder using existing IQuestion pattern).
- After user submits practice code, review it (point out mistakes, better patterns, add real mistakes to Notes\InterviewGotchas.cs) before moving to the next topic.
- User commitment: 3 hours/day, 5 days/week.
- Practice tasks must be extremely explicit and unambiguous, with step-by-step TODOs and exact expected outputs to avoid confusion.

## Time Commitment & Master Plan (12 Weeks Total)

**Part A — C# Language Mastery: Weeks 1–4**  
**Part B — Full Stack Development: Weeks 5–12 (incl. Capstone)**

### Part A Modules (Weeks 1-4)
- Module 1: Language Basics (1.1 What is C#/.NET/CLR, 1.2 Variables/Types/var, 1.3 Operators/Expressions, 1.4 Type Conversion, 1.5 Control Flow, 1.6 Methods & ref/out/in/params)
- Module 2: OOP (2.1 Classes/Objects, 2.2 Constructors/this/static, 2.3 Encapsulation, 2.4 Inheritance, 2.5 Polymorphism, 2.6 Abstraction, 2.7 record vs struct vs class)
- Module 3: Type System Deep Dive (3.1 Value vs Reference/stack vs heap, 3.2 Boxing/Unboxing, 3.3 Nullable types, 3.4 == vs Equals vs ReferenceEquals)
- Module 4: Collections & Generics (4.1 Arrays, 4.2 List/Dictionary/HashSet/Queue/Stack, 4.3 Generics & constraints, 4.4 IEnumerable/IEnumerator/yield)
- Module 5: Functional-Style C# (5.1 Delegates, 5.2 Func/Action/Predicate, 5.3 Events, 5.4 Lambdas, 5.5 LINQ, 5.6 Pattern matching)
- Module 6: Error Handling & Resources (6.1 Exceptions/try-catch-finally, 6.2 Custom exceptions, 6.3 IDisposable/using)
- Module 7: Async Programming (7.1 Threads vs Tasks, 7.2 async/await, 7.3 Task vs Task<T> vs ValueTask, 7.4 CancellationToken, 7.5 Parallel basics)
- Module 8: Advanced C# (8.1 SOLID, 8.2 Dependency Injection, 8.3 Reflection, 8.4 Attributes, 8.5 Memory management & GC)

### Part B Modules (Weeks 5-12)
- Module 9: SQL Server & Database Design
- Module 10: ASP.NET Core Web API
- Module 11: Entity Framework Core
- Module 12: Authentication & Security
- Module 13: Frontend (React or Angular)
- Module 14: Testing (xUnit, Moq, integration tests)
- Module 15: Git, Docker, CI/CD
- Module 16: System Design + Capstone Project (Order Management System: ASP.NET Core Web API + EF Core + SQL Server + JWT Auth + React/Angular frontend + tests + Docker + CI)

## 📍 PROGRESS TRACKER (update after every session)

**Last updated:** 2026-09-02

### Completed Topics
- [x] Module 1 — Language Basics (1.1–1.6) — FULLY COMPLETE
- [x] Module 2.1 — Classes and Objects
- [x] Module 2.2 — Constructors, `this`, and Static Members
- [x] Module 2.3 — Encapsulation
- [x] Module 2.4 — Inheritance
- [x] Module 2.5 — Polymorphism
- [x] Module 2.6 — Abstraction (taught, practice reviewed — all correct, minor style note: omit 'public' in interface members)
- [x] Module 3.1 — Value vs Reference Types (stack/heap semantics, copy behavior, method passing behavior, string immutability)

### Next Topic To Teach
- [ ] Module 3.2 — Boxing and Unboxing

### Files Created So Far
- `Notes\LanguageBasics-01.cs` (Module 1 complete)
- `Notes\OOP-02.cs` (contains 2.1–2.6 digital notes)
- `Notes\InterviewGotchas.cs` (mistakes: 1.2–1.6, 2.1–2.5 logged)
- `OOP\ClassesPracticeQuestion.cs` (completed & reviewed)
- `OOP\ConstructorsPracticeQuestion.cs` (completed & reviewed)
- `OOP\EncapsulationPracticeQuestion.cs` (completed & reviewed)
- `OOP\InheritancePracticeQuestion.cs` (completed & reviewed)
- `OOP\PolymorphismPracticeQuestion.cs` (completed & reviewed)
- `OOP\AbstractionPracticeQuestion.cs` (completed & reviewed)