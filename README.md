````md
# StarterApi

A reusable ASP.NET Core Web API starter template built with Onion Architecture, designed for rapid backend experimentation, feature prototyping, and architecture exploration.

The purpose of this project is to eliminate repetitive backend setup work and provide a clean, extensible foundation for learning, testing new technologies, and evolving backend engineering skills.

Instead of rebuilding authentication, validation, middleware, and infrastructure for every new idea, this repository acts as a stable backend engineering laboratory where new features and architectural patterns can be explored safely and efficiently.

---

# Goals

- Build a reusable backend foundation
- Avoid repetitive CRUD and infrastructure setup
- Accelerate feature experimentation
- Practice scalable architecture patterns
- Explore modern backend technologies incrementally
- Maintain a clean and extensible project structure
- Create a long-term engineering lab for .NET backend development

---

# Architecture

This project follows Onion Architecture principles.

```text
API
 ↓
Application
 ↓
Domain

Infrastructure depends on:
- Application
- Domain
````

The architecture emphasizes:

* Separation of concerns
* Dependency inversion
* Maintainability
* Testability
* Extensibility

---

# Solution Structure

```text
StarterApi/
│
├── src/
│   ├── StarterApi.API
│   ├── StarterApi.Application
│   ├── StarterApi.Domain
│   └── StarterApi.Infrastructure
│
├── tests/
│
├── docker-compose.yml
│
├── StarterApi.sln
│
└── README.md
```

---

# Project Layers

## StarterApi.API

Handles:

* Controllers
* Middleware
* Authentication configuration
* Swagger/OpenAPI
* API endpoints
* HTTP concerns

### Folders

```text
Controllers/
Middlewares/
Extensions/
Configurations/
Filters/
```

---

## StarterApi.Application

Contains:

* DTOs
* Interfaces
* Validators
* Business rules
* Application services
* Feature implementations

### Folders

```text
DTOs/
Interfaces/
Features/
Validators/
Services/
Behaviors/
```

---

## StarterApi.Domain

Contains the core business models and abstractions.

### Folders

```text
Entities/
Enums/
Common/
```

---

## StarterApi.Infrastructure

Handles external concerns and infrastructure implementations.

### Folders

```text
Persistence/
Repositories/
Identity/
Services/
Configurations/
```

---

# Current Features

* Onion Architecture
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT Authentication
* Role-based Authorization
* Global Exception Handling Middleware
* Validation Support
* Swagger/OpenAPI
* Clean Separation of Layers
* Reusable Project Structure

---

# Planned Features

* Serilog Logging
* Redis Caching
* CQRS + MediatR
* Background Jobs
* Health Checks
* Dockerized Development Environment
* Audit Logging
* Rate Limiting
* Integration Testing
* Refresh Tokens
* API Versioning
* Modular Architecture Experiments
* Performance Profiling
* Caching Strategies

---

# Why This Project Exists

Many backend learning projects spend excessive time rebuilding infrastructure instead of focusing on actual engineering concepts.

Common repetitive setup includes:

* Authentication
* Validation
* DTO Mapping
* DbContext setup
* Middleware
* CRUD operations
* Logging
* Authorization

This repository separates:

```text
Infrastructure setup
vs
Feature experimentation
```

allowing new ideas and technologies to be tested quickly without rebuilding an entire application from scratch.

---

# Experimentation Philosophy

This repository is designed as:

```text
an engineering laboratory
not just a CRUD project
```

The `main` branch represents the stable reusable foundation.

Feature experiments are explored using dedicated Git branches.

Examples:

```text
main                -> stable reusable template
redis-lab           -> distributed caching experiments
mediatr-lab         -> CQRS and MediatR experiments
signalr-lab         -> realtime communication experiments
performance-lab     -> optimization and profiling
security-lab        -> authentication and security testing
```

This workflow allows the architecture to evolve gradually while keeping the core foundation stable and reusable.

---

# Example Domain

The project intentionally uses a lightweight and generic domain model to avoid becoming tied to a specific business system.

Current example entities may include:

```text
User
Role
Project
TaskItem
```

The focus of the repository is backend engineering infrastructure and experimentation rather than domain complexity.

---

# Tech Stack

* ASP.NET Core
* Entity Framework Core
* SQL Server
* JWT Bearer Authentication
* FluentValidation
* Swagger/OpenAPI
* Docker
* Git & GitHub

Planned additions:

* Serilog
* Redis
* MediatR
* SignalR
* Testcontainers

---

# Development Workflow

## Stable Foundation

The `main` branch contains:

* stable architecture
* reusable infrastructure
* production-style organization
* foundational backend systems

## Feature Labs

New technologies and ideas are explored in isolated branches.

Example workflow:

```bash
git checkout -b redis-lab
```

Experiment safely without affecting the stable architecture.

Useful improvements can later be merged back into `main`.

---

# Getting Started

## Clone Repository

```bash
git clone <your-repository-url>
```

---

## Configure Database

Update your connection string inside:

```text
appsettings.json
```

---

## Apply Migrations

```bash
update-database
```

---

## Run Application

```bash
dotnet run
```

---

# Long-Term Vision

The long-term goal of this repository is to evolve into a reusable backend engineering platform capable of supporting:

* rapid prototyping
* architecture experimentation
* backend feature research
* infrastructure testing
* performance exploration
* scalable backend practices

while remaining understandable, maintainable, and extensible.

---

# License

This project is intended for learning, experimentation, and backend engineering practice.

```
```
