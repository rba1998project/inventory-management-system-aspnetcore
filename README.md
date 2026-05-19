# 📦 IMS - Inventory Management System

> **A layered inventory management application built with ASP.NET Core MVC and Three-Tier Architecture.**
>
> ⚠️ **Project Status:** Currently under active development

## 📋 Table of Contents

- [Overview](#-overview)
- [Architecture](#-architecture)
- [Tech Stack](#-tech-stack)
- [Features](#-features)
- [Feature Roadmap](#-feature-roadmap)
- [Project Structure](#-project-structure)
- [Database Design](#-database-design)
- [Authentication & Authorization](#-authentication--authorization)
- [Engineering Practices](#-engineering-practices)
- [Getting Started](#-getting-started)
- [Demo Credentials](#-demo-credentials)
- [Future Improvements](#-future-improvements)
- [Contribution](#-contribution)
- [License](#-license)

---

## 🎯 Overview

IMS (Inventory Management System) is a web-based inventory management application built with **ASP.NET Core 8.0 using MVC, Razor Pages, and a Three-Tier Architecture.** The project is focused on implementing clean architecture principles, role-based authentication, and scalable module design for inventory operations.

**Key Highlights:**
- ✅ Role-Based Access Control (Admin & InventoryManager)
- ✅ Enterprise-grade architecture with Dependency Injection
- ✅ Secure authentication using ASP.NET Identity
- ✅ Comprehensive CRUD operations for core entities
- ✅ Modular, scalable service layer
- ✅ Repository pattern for data access abstraction
- ✅ SQL Server with Entity Framework Core

---

## 🏗️ Architecture

The system follows a **Three-Tier Layered Architecture** pattern, ensuring separation of concerns, testability, and maintainability:

```
┌─────────────────────────────────────────────┐
│         PRESENTATION LAYER (IMS.WEB)        │
│  ASP.NET Core MVC • Razor Pages • Views     │
│  Controllers • ViewModels • Validation      │
└──────────────────┬──────────────────────────┘
                   │
                   ▼
┌─────────────────────────────────────────────┐
│      BUSINESS LOGIC LAYER (IMS.BLL)         │
│  Services • Interfaces • DTOs • Mapping      │
│  Business Rules • Data Processing           │
└──────────────────┬──────────────────────────┘
                   │
                   ▼
┌─────────────────────────────────────────────┐
│       DATA ACCESS LAYER (IMS.DAL)           │
│  Repositories • DbContext • Migrations      │
│  Entity Framework Core • SQL Server         │
└─────────────────────────────────────────────┘
```

### Layer Responsibilities

| Layer | Responsibility | Technologies |
|-------|---------------|--------------|
| **Presentation** | UI rendering, user input handling, request routing | ASP.NET Core MVC, Razor Pages, Controllers, ViewModels |
| **Business Logic** | Core application logic, services, DTOs, business rules | C# Services, Interfaces, DTOs, Data mapping |
| **Data Access** | Database operations, repositories, ORM abstraction | Entity Framework Core, SQL Server, Migrations |

---

## 🛠️ Tech Stack

### Backend
- **Framework:** ASP.NET Core 8.0
- **Pattern:** MVC & Razor Pages
- **Runtime:** .NET 8.0
- **Language:** C# 12.0

### Database
- **Database Engine:** SQL Server
- **ORM:** Entity Framework Core 8.0.26
- **Approach:** Code-First with Migrations

### Authentication & Security
- **Authentication:** ASP.NET Core Identity
- **Authorization:** Role-Based Access Control (RBAC)
- **Password Security:** Identity security hashing
- **Session Management:** Cookie-based authentication

### Architecture & Design Patterns
- **Dependency Injection:** ASP.NET Core's built-in DI container
- **Repository Pattern:** Data access abstraction
- **Service Layer:** Business logic encapsulation
- **Three-Tier Architecture:** Clean separation of concerns
- **DTO Pattern:** Data transfer between layers

### Development Tools
- **IDE:** Visual Studio 2022 (v17.14+)
- **Version Control:** Git
- **Package Manager:** NuGet

---

## ✨ Features

### ✅ Implemented Features

#### Authentication & Authorization
- [x] User login with ASP.NET Identity
- [x] Secure password authentication
- [x] Role-based authorization (Admin, InventoryManager)
- [x] Session-based access control
- [x] Remember-me functionality
- [x] Logout mechanism

#### User Management
- [x] Create users with role assignment
- [x] View all users
- [x] Assign roles to users
- [x] Admin-only access controls

#### Category Management
- [x] Create categories
- [x] Read/View categories with pagination
- [x] Update category details
- [x] Soft delete categories
- [x] Search functionality
- [x] Audit trail (Created by, Last modified by)

#### Supplier Management
- [x] Full supplier CRUD operations
- [x] Contact information (email, phone, address)
- [x] Supplier-Product relationships
- [x] Pagination and search
- [x] Audit tracking

#### Product Management
- [x] Complete product CRUD
- [x] Product categorization
- [x] Supplier assignment
- [x] Price and quantity tracking
- [x] Image path support
- [x] Product pagination
- [x] Advanced search

---

## 🚀 Feature Roadmap

### Phase 1: Core Inventory (In Progress)
- [x] Authentication & Authorization
- [x] Role-based access control
- [x] User management (Admin only)
- [x] Category CRUD
- [x] Supplier CRUD
- [x] Product CRUD

### Phase 2: Inventory Operations (Planned)
- [ ] Stock level tracking
- [ ] Inventory transactions (In/Out)
- [ ] Low stock alerts
- [ ] Stock adjustment forms
- [ ] Batch operations

### Phase 3: Administration (Planned)
- [ ] Advanced role permissions
- [ ] Activity/Audit logging
- [ ] User activity tracking
- [ ] System settings management

### Phase 4: Analytics & Reporting (Planned)
- [ ] Dashboard with KPIs
- [ ] Sales/Inventory reports
- [ ] Export to Excel/PDF
- [ ] Real-time analytics
- [ ] Graphical dashboards

### Phase 5: Engineering Excellence (Planned)
- [ ] Unit tests (xUnit/NUnit)
- [ ] Integration tests
- [ ] CI/CD pipeline (GitHub Actions/Azure Pipelines)
- [ ] Swagger/OpenAPI documentation
- [ ] RESTful API layer
- [ ] Caching layer (Redis)
- [ ] Performance optimization

---

## 📁 Project Structure

```
IMS.ThreeTier/
├── IMS.WEB/                           # Presentation Layer
│   ├── Controllers/                   # Route handlers
│   │   ├── AuthController.cs
│   │   ├── UserManagementController.cs
│   │   ├── CategoryController.cs
│   │   ├── SupplierController.cs
│   │   └── ProductController.cs
│   ├── ViewModels/                    # View-specific models
│   ├── Views/                         # Razor templates
│   │   ├── Auth/
│   │   ├── Category/
│   │   ├── Supplier/
│   │   ├── Product/
│   │   ├── UserManagement/
│   │   └── Shared/
│   ├── Program.cs                     # Dependency injection & middleware
│   └── appsettings.json
│
├── IMS.BLL/                           # Business Logic Layer
│   ├── Services/                      # Business logic implementation
│   │   ├── AuthService.cs
│   │   ├── UserManagementService.cs
│   │   ├── CategoryService.cs
│   │   ├── SupplierService.cs
│   │   └── ProductService.cs
│   ├── Interfaces/                    # Service contracts
│   │   ├── IAuthService.cs
│   │   ├── IUserManagementService.cs
│   │   ├── ICategoryService.cs
│   │   ├── ISupplierService.cs
│   │   └── IProductService.cs
│   └── DTOs/                          # Data transfer objects
│       ├── LoginDto.cs
│       ├── CategoryDto.cs
│       ├── ProductDto.cs
│       ├── SupplierDto.cs
│       ├── CreateUserDto.cs
│       └── PagedResult.cs
│
├── IMS.DAL/                           # Data Access Layer
│   ├── Context/                       # Database context
│   │   └── AppDbContext.cs
│   ├── Repositories/                  # Data access implementations
│   │   ├── CategoryRepository.cs
│   │   ├── SupplierRepository.cs
│   │   └── ProductRepository.cs
│   ├── Interfaces/                    # Repository contracts
│   ├── Migrations/                    # EF Core migrations
│   └── Seeders/                       # Database seeders
│       ├── IdentitySeeder.cs
│       └── DataSeeder.cs
│
├── IMS.Models/                        # Shared Entity Models
│   ├── ApplicationUser.cs             # Identity user
│   ├── Category.cs
│   ├── Supplier.cs
│   └── Product.cs
│
└── IMS.ThreeTier.sln                  # Solution file
```

---

## 🗄️ Database Design

### Entity Relationships

```
User (ASP.NET Identity)
├── Roles: [Admin, InventoryManager]
└── Authentication & Authorization

Category
├── Id (PK)
├── Name, Description
├── CreatedAt, CreatedBy
├── LastModifiedAt, LastModifiedBy
├── IsDeleted (soft delete flag)
└── Products (1:Many relationship)

Supplier
├── Id (PK)
├── Name, ContactPerson
├── Email, Phone, Address
├── CreatedAt, CreatedBy
├── LastModifiedAt, LastModifiedBy
├── IsDeleted (soft delete flag)
└── Products (1:Many relationship)

Product
├── Id (PK)
├── Name, Price, Quantity
├── CategoryId (FK) → Category
├── SupplierId (FK) → Supplier
├── ImagePath
├── CreatedAt, CreatedBy
├── LastModifiedAt, LastModifiedBy
├── IsDeleted (soft delete flag)
└── Relationships: Category (Many:1), Supplier (Many:1)
```

### Database Constraints
- **Cascade Protection:** Products cannot be deleted if related Category/Supplier exists (OnDelete: Restrict)
- **Soft Deletes:** All entities support logical deletion via `IsDeleted` flag
- **Audit Trail:** All entities track creation and modification metadata
- **Data Integrity:** Foreign keys enforce referential integrity

---

## 🔐 Authentication & Authorization

### Authentication Mechanism

The system uses **ASP.NET Core Identity** with **Cookie-based Authentication**:

1. **User Registration:** Admin creates users with role assignment
2. **Login Process:** Email + password credentials validated against Identity
3. **Session Storage:** Secure cookies maintain user session
4. **Logout:** Session invalidated on logout

### Password Policy

```csharp
- Minimum Length: 6 characters
- Require Digits: Yes (at least 1 number)
- Require Uppercase: Yes (at least 1 uppercase letter)
- Require Lowercase: Yes (at least 1 lowercase letter)
- Require Non-Alphanumeric: No
```

### Role-Based Authorization

**Two Roles Implemented:**

| Role | Permissions |
|------|-------------|
| **Admin** | ✓ User management (create, view, assign roles) ✓ Category CRUD ✓ Supplier CRUD ✓ Product CRUD |
| **InventoryManager** | ✓ Category view ✓ Supplier view ✓ Product view/CRUD |

### Authorization Attributes

```csharp
[Authorize]                              // Requires authentication
[Authorize(Roles = "Admin")]             // Admin-only access
[Authorize(Roles = "Admin,InventoryManager")]  // Multiple roles
[AllowAnonymous]                         // Public access
```

---

## 💡 Engineering Practices

### Design Patterns Implemented

1. **Three-Tier Architecture:** Clear separation into presentation, business, and data layers
2. **Repository Pattern:** Data access abstraction with interfaces
3. **Service Layer Pattern:** Business logic encapsulation
4. **Dependency Injection:** Loose coupling via ASP.NET Core's built-in DI container
5. **DTO Pattern:** Safe data transfer between layers
6. **Fluent API Configuration:** EF Core entity relationships explicitly configured

### Code Organization

- **Separation of Concerns:** Each layer has distinct responsibilities
- **Interface-driven Design:** Services depend on abstractions, not implementations
- **Reusability:** Services can be tested and reused independently
- **Scalability:** New features can be added with minimal impact on existing code

### Database Best Practices

- **Code-First Approach:** Database schema defined in C# models
- **Migrations:** Version-controlled database changes
- **Soft Deletes:** Logical deletion with audit trail preservation
- **Audit Fields:** CreatedAt, CreatedBy, LastModifiedAt, LastModifiedBy
- **Constraints:** Foreign keys with appropriate delete behaviors

---

## 🚀 Getting Started

### Prerequisites

- **.NET 8.0 SDK** or later ([Download](https://dotnet.microsoft.com/download))
- **SQL Server** (2019 or later) or **SQL Server Express**
- **Visual Studio 2022** (recommended) or VS Code
- **Git**

### Step 1: Clone the Repository

```bash
git clone https://github.com/yourusername/IMS.ThreeTier.git
cd IMS.ThreeTier
```

### Step 2: Configure Database Connection

Edit `IMS.ThreeTier/appsettings.json` and set your SQL Server connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IMS_DB;Integrated Security=True;Encrypt=false;"
  }
}
```

**Alternative:** Set via Environment Variable
```bash
set ConnectionStrings__DefaultConnection="Your connection string here"
```

### Step 3: Apply Database Migrations

Navigate to the project root and run:

```bash
cd IMS.ThreeTier
dotnet ef database update --project ../IMS.DAL/IMS.DAL.csproj
```

This will:
- Create the database if it doesn't exist
- Apply all pending migrations
- Seed default roles (Admin, InventoryManager)
- Create demo data and admin user

### Step 4: Build the Solution

```bash
dotnet build
```

### Step 5: Run the Application

```bash
dotnet run --project IMS.ThreeTier/IMS.WEB.csproj
```

The application will launch at: **https://localhost:5001** (or as specified in `launchSettings.json`)

### Step 6: Login

Use the default admin credentials:

```
Email: admin@demo.com
Password: Admin123!
```

---

## 👤 Demo Credentials

### Default Admin User

```
Email:    admin@demo.com
Password: Admin123!
Role:     Admin
```

**Note:** Change this password in production and remove demo data before deployment.

---

## 🔮 Future Improvements

### Short Term (Next Quarter)
- [ ] Real-time stock notifications
- [ ] Inventory adjustment workflows
- [ ] Email notifications for low stock
- [ ] Advanced filtering and sorting
- [ ] Bulk operations for products/suppliers
- [ ] UI/UX Improvement

### Medium Term (Next 2-3 Quarters)
- [ ] Mobile-friendly responsive design enhancement
- [ ] REST API layer for external integrations
- [ ] Comprehensive audit logging system
- [ ] Import/export functionality (Excel, CSV)
- [ ] Dashboard with analytics
- [ ] User activity tracking

### Long Term (Beyond 3 Quarters)
- [ ] Real-time notifications (SignalR)
- [ ] Advanced reporting engine
- [ ] Multi-tenant support
- [ ] Distributed caching (Redis)

---

## 📝 Contribution

Contributions are welcome! Please follow these guidelines:

1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature/amazing-feature`)
3. **Commit** your changes (`git commit -m 'Add amazing feature'`)
4. **Push** to the branch (`git push origin feature/amazing-feature`)
5. **Open** a Pull Request

### Development Guidelines

- Follow C# naming conventions (PascalCase for public members)
- Write meaningful commit messages
- Add comments for complex logic
- Test your changes before submitting PR
- Update documentation as needed

---

## 📄 License

This project is licensed under the **MIT License** - see the LICENSE file for details.

---

## 👥 Authors

**Development By:** Rifat Bin Aziz

---

## 🎓 Learning Resources

- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core Guide](https://learn.microsoft.com/en-us/ef/core/)
- [ASP.NET Identity Documentation](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity)
- [Repository Pattern](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design)
- [Three-Tier Architecture](https://en.wikipedia.org/wiki/Multitier_architecture)

---

**Last Updated:** 2025-05-19  
**Project Status:** 🟡 Active Development