# CleanArchitecture DotNet8

## 🚀 **Overview**
Welcome to the **CleanArchitecture** project! This repository demonstrates a robust API built with **.NET 8**, leveraging the **Clean Architecture** design principles. It integrates modern tools and frameworks like **CQRS**, **MediatR**, **FluentValidation**, **Entity Framework Core**, and **AutoRegisterDI** for scalable, maintainable, and high-performance applications. 

The project uses **PostgreSQL** for the database and is containerized using **Docker Compose** for simplified deployment and development.

#### 📝 **git clone**
        git clone https://github.com/username/CleanArchitecture.git


#### 📝 **docker build & run**
        docker build -t cleanarchitecture-app:latest .
        docker run -p 8080:8080 -e ASPNETCORE_ENVIRONMENT=Development --name cleanarchitecture-container cleanarchitecture-app:latest

## 🏗️ **Key Features**
- **Clean Architecture**: Ensures separation of concerns and scalability.
- **CQRS**: Implements Command and Query Responsibility Segregation for better maintainability.
- **MediatR**: Simplifies communication between layers by decoupling request and response logic.
- **FluentValidation**: Provides fluent, expressive validation for objects and requests.
- **PostgreSQL**: A reliable and robust relational database.
- **Entity Framework Core**: Handles database interactions with a code-first approach.
- **AutoRegisterDI**: Automates the registration of dependencies in the DI container.
- **Docker Compose**: Simplifies environment setup for local and production use.


## 📦 **Project Structure**
The project is organized to reflect the **Clean Architecture** principles:

```plaintext
📦 ProjectRoot
├── 📁 Core
│   ├── 📁 Application      # Business Logic (CQRS Handlers, MediatR)
│   ├── 📁 Domain           # Core Entities & Interfaces
│   └── 📁 Infrastructure   # Data Access (EF Core, PostgreSQL)
└── 📁 Web.Api
    └── 📁 Presentation     # CleanArchitecture (API Layer)
