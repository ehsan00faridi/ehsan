Clean Architecture E-Commerce / Account Management API

A modular backend project built with ASP.NET Core and Clean Architecture principles.

The project demonstrates separation of concerns, CQRS pattern using MediatR, validation pipeline, centralized exception handling, logging behavior, user registration with OTP verification, and product management features.


Project Overview
This project is a backend application designed to demonstrate a clean, scalable, and production-ready architecture for real-world business applications.

The main focus of this project is not only implementing CRUD operations, but also applying enterprise-level patterns and best practices such as:

- Clean Architecture (Separation of Concerns)
- CQRS
- MediatR
- Pipeline Behaviors
- FluentValidation
- Repository / Unit of Work pattern
- Domain-driven separation
- Authentication and account management
- Product management


Architecture
The solution follows Clean Architecture, separating the application into distinct layers 
(Domain, Application, Infrastructure, Presentation) to ensure loose coupling, maintainability, and testability.


Architectural Principles
Architecture: Clean Architecture (strict Separation of Concerns)

Patterns: CQRS using MediatR to decouple request/response handling

Data Access Layer: Hybrid approach
- Entity Framework Core for write-side operations (Commands)
- Dapper for optimized read-side queries (Queries)


Cross-Cutting Concerns
FluentValidation:
Integrated into the MediatR pipeline as a behavior for automatic request validation.

Logging & Exception Handling:
Centralized middleware and pipeline behaviors for clean, traceable, and maintainable error handling.

Security:
Robust implementation of Identity-based Authentication and Authorization policies.

