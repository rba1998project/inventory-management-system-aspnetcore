# 📦 IMS - Inventory Management System

> **A layered inventory management application built with ASP.NET Core MVC and Three-Tier Architecture.**
>
> **Project Status:** Core Features Completed | Additional Enhancements Planned

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

IMS (Inventory Management System) is a web-based inventory management application built with **ASP.NET Core 8.0 using MVC and a Three-Tier Architecture.** The project demonstrates layered architecture, separation of concerns, and common enterprise application patterns such as Repository Pattern, Service Layer, Dependency Injection, Authentication & Authorization, and Inventory Operations.

**Key Highlights:**
- ✅ Role-Based Access Control (Admin & InventoryManager)
- ✅ Complete inventory operations (stock tracking, adjustments, transactions)
- ✅ Secure authentication using ASP.NET Identity
- ✅ Comprehensive CRUD operations for all core entities
- ✅ Modular service layer with dependency injection
- ✅ Repository pattern for data access
- ✅ SQL Server with Entity Framework Core 8

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

## 🎯 Skills Demonstrated

- ASP.NET Core MVC
- Razor Views
- ASP.NET Identity
- Entity Framework Core
- SQL Server
- Three-Tier Architecture
- Repository Pattern
- Service Layer Pattern
- Dependency Injection
- DTO Pattern
- Role-Based Authorization
- Logging
- Global Exception Handling Middleware
- Audit Trail Implementation
- Soft Delete Pattern
- Pagination & Searching
- Excel/PDF Export
- Git Version Control

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
- [x] View all users with pagination
- [x] Assign roles to users
- [x] Admin-only access controls

#### Category Management
- [x] Create, read, update, and delete (CRUD) categories
- [x] Soft delete support
- [x] Pagination and search functionality
- [x] Audit trail (CreatedBy, CreatedAt, LastModifiedBy, LastModifiedAt)

#### Supplier Management
- [x] Full CRUD operations for suppliers
- [x] Contact information (email, phone, address)
- [x] Supplier-Product relationships
- [x] Pagination and search
- [x] Soft delete and audit tracking

#### Product Management
- [x] Complete CRUD operations
- [x] Product categorization and supplier assignment
- [x] Price and quantity tracking
- [x] Image path support
- [x] Pagination and advanced search
- [x] Soft delete and audit trail
- [x] Low stock threshold configuration

#### Stock Management
- [x] Stock In operations
- [x] Stock Out operations
- [x] Stock Adjustment transactions
- [x] Transaction history and audit trail
- [x] Low stock alerts and notifications
- [x] Real-time stock level updates

#### Dashboard
- [x] Total product count
- [x] Total categories count
- [x] Total suppliers count
- [x] Inventory value calculation
- [x] Recent transactions display

#### Data Export & Reporting
- [x] Export to Excel
- [x] Export to PDF
- [x] Search and filter capabilities

#### Data Management
- [x] Soft delete across all entities
- [x] Audit fields on all entities (CreatedBy, CreatedAt, LastModifiedBy, LastModifiedAt)
- [x] Pagination with configurable page sizes
- [x] Global search functionality

---

## 🚀 Feature Roadmap

### Phase 1: Core Inventory ✅ Completed
- [x] Authentication & Authorization
- [x] Role-based access control
- [x] User management (Admin only)
- [x] Category CRUD
- [x] Supplier CRUD
- [x] Product CRUD
- [x] Soft delete functionality
- [x] Audit trail implementation

### Phase 2: Inventory Operations ✅ Completed
- [x] Stock level tracking
- [x] Stock In operations
- [x] Stock Out operations
- [x] Stock Adjustment transactions
- [x] Transaction history
- [x] Low stock alerts
- [x] Automatic stock quantity updates after inventory transactions

### Phase 3: Data Management & Reporting ✅ Completed
- [x] Dashboard with inventory overview
- [x] Export to Excel
- [x] Export to PDF
- [x] Advanced search and filtering
- [x] Pagination

### Phase 4: Additional Enhancements 🔄 Planned
- [ ] Product image upload
- [ ] Bulk operations for products/suppliers
- [ ] Activity/Audit logging
- [ ] Dashboard charts and graphs
- [ ] UI/UX improvements
- [ ] Unit testing (xUnit/NUnit)
- [ ] Integration testing
- [ ] Unit of Work pattern

### Phase 5: API & Advanced Features 🔄 Planned
- [ ] REST API layer
- [ ] Swagger/OpenAPI documentation
- [ ] SignalR real-time notifications
- [ ] Caching layer (Redis)
- [ ] CI/CD pipeline
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
│   │   ├── ProductController.cs
│   │   ├── StockController.cs
│   │   └── DashboardController.cs
│   ├── ViewModels/                    # View-specific models
│   ├── Views/                         # Razor templates
│   │   ├── Auth/
│   │   ├── Category/
│   │   ├── Supplier/
│   │   ├── Product/
│   │   ├── Stock/
│   │   ├── Dashboard/
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
│   │   ├── ProductService.cs
│   │   ├── StockService.cs
│   │   └── DashboardService.cs
│   ├── Interfaces/                    # Service contracts
│   │   ├── IAuthService.cs
│   │   ├── IUserManagementService.cs
│   │   ├── ICategoryService.cs
│   │   ├── ISupplierService.cs
│   │   ├── IProductService.cs
│   │   ├── IStockService.cs
│   │   └── IDashboardService.cs
│   └── DTOs/                          # Data transfer objects
│       ├── LoginDto.cs
│       ├── CategoryDto.cs
│       ├── ProductDto.cs
│       ├── SupplierDto.cs
│       ├── UserCreateDto.cs
│       ├── StockInDto.cs
│       ├── StockOutDto.cs
│       ├── StockAdjustmentDto.cs
│       ├── StockTransactionDto.cs
│       └── PagedResult.cs
│
├── IMS.DAL/                           # Data Access Layer
│   ├── Context/                       # Database context
│   │   └── AppDbContext.cs
│   ├── Repositories/                  # Data access implementations
│   │   ├── CategoryRepository.cs
│   │   ├── SupplierRepository.cs
│   │   ├── ProductRepository.cs
│   │   ├── StockRepository.cs
│   │   └── DashboardRepository.cs
│   ├── Interfaces/                    # Repository contracts
│   │   ├── ICategoryRepository.cs
│   │   ├── ISupplierRepository.cs
│   │   ├── IProductRepository.cs
│   │   ├── IStockRepository.cs
│   │   └── IDashboardRepository.cs
│   ├── Migrations/                    # EF Core migrations
│   │   └── [Migration files]
│   └── Seeders/                       # Database seeders
│       ├── IdentitySeeder.cs
│       └── DataSeeder.cs
│
├── IMS.Models/                        # Shared Entity Models
│   ├── ApplicationUser.cs             # Identity user
│   ├── Category.cs
│   ├── Supplier.cs
│   ├── Product.cs
│   └── StockTransaction.cs
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
├── LowStockThreshold
├── CreatedAt, CreatedBy
├── LastModifiedAt, LastModifiedBy
├── IsDeleted (soft delete flag)
└── Relationships: Category (Many:1), Supplier (Many:1)

StockTransaction
├── Id (PK)
├── ProductId (FK) → Product
├── TransactionType (In/Out/Adjustment)
├── Quantity
├── Notes
├── CreatedAt, CreatedBy
├── LastModifiedAt, LastModifiedBy
└── Relationship: Product (Many:1)
```

### Database Constraints
- **Cascade Protection:** Products cannot be deleted if related Category/Supplier exists (OnDelete: Restrict)
- **Soft Deletes:** All entities support logical deletion via `IsDeleted` flag
- **Audit Trail:** All entities track creation and modification metadata
- **Stock Transactions:** Immutable transaction history for audit compliance
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
2. **Repository Pattern:** Data access abstraction with interfaces for testability
3. **Service Layer Pattern:** Business logic encapsulation and reusability
4. **Dependency Injection:** Loose coupling via ASP.NET Core's built-in DI container
5. **DTO Pattern:** Type-safe data transfer between layers
6. **Fluent API Configuration:** EF Core entity relationships explicitly configured

### Code Organization

- **Separation of Concerns:** Each layer has distinct responsibilities
- **Interface-driven Design:** Services depend on abstractions, not implementations
- **Reusability:** Services can be tested and reused independently
- **Scalability:** New features can be added with minimal impact on existing code

### Data Management

- **Soft Deletes:** Logical deletion with audit trail preservation
- **Audit Fields:** CreatedAt, CreatedBy, LastModifiedAt, LastModifiedBy on all entities
- **Code-First Approach:** Database schema defined in C# models
- **Migrations:** Version-controlled database changes

### Error Handling & Monitoring

- Global Exception Handling Middleware
- Structured Logging using ASP.NET Core Logging
- Centralized Error Management
- Consistent Error Response Handling

### Data Access

- **Repository Pattern:** Abstract data operations from business logic
- **Foreign Key Constraints:** Enforce referential integrity
- **Pagination:** Efficient data retrieval for large datasets
- **Search & Filtering:** Advanced query capabilities

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

### Planned Enhancements

- Product Image Upload
- Bulk Operations
- Dashboard Charts & Graphs
- Activity Logging
- UI/UX Improvements
- Optimistic Concurrency Handling (RowVersion)
- Unit Testing (xUnit)

### Long-Term Improvements

- Unit of Work Pattern
- REST API Layer
- Swagger/OpenAPI Documentation
- SignalR Notifications
- Redis Caching
- CI/CD Pipeline
- Performance Optimization

---

## 📄 License

This project is licensed under the **MIT License** - see the LICENSE file for details.

---

## 👥 Authors

**Development By:** Rifat Bin Aziz

---

**Last Updated:** 2026-06-11  
**Project Status:** ✅ Core Features Completed | 🔄 Additional Enhancements Planned