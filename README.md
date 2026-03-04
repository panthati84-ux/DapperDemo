# DapperDemo

A sample **ASP.NET Core MVC (.NET 8)** project demonstrating how to use **Dapper and Entity Framework Core together** for database operations.

This project shows how developers can combine the power of **Dapper (micro ORM)** with **Entity Framework Core (full ORM)** in a single application.

---

# 🚀 Technologies Used

- .NET 8
- ASP.NET Core MVC
- Dapper
- Entity Framework Core
- SQL Server
- Razor Views
- Bootstrap
- jQuery
- Visual Studio 2022

---

# 📂 Project Structure

```
DapperDemo
│
├── Controllers
│   ├── CompaniesController.cs
│   └── HomeController.cs
│
├── Models
│   ├── Company.cs
│   └── ErrorViewModel.cs
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Repositories
│   ├── CompanyRepository.cs
│   ├── EfCompanyRepository.cs
│   ├── ICompanyRepository.cs
│   └── IEfCompanyRepository.cs
│
├── Migrations
│
├── Views
│
├── wwwroot
│
├── appsettings.json
└── Program.cs
```

---

# 📊 Features

- Create Company
- View Company List
- Edit Company
- Delete Company
- View Company Details
- Demonstrates both **Dapper and Entity Framework**

---

# 🧩 Company Model

```csharp
public class Company
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string PostalCode { get; set; }

    public string Phone { get; set; }
}
```

---

# 🗄 Database Configuration

Database connection is configured in:

```
appsettings.json
```

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=DapperDemoDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

# ⚙️ Entity Framework Migration

Create migration

```
Add-Migration InitialCreate
```

Update database

```
Update-Database
```

This will automatically create the database and tables.

---

# ⚡ Dapper Implementation

Dapper is used for **high performance SQL queries**.

Example:

```csharp
var companies = connection.Query<Company>("SELECT * FROM Companies");
```

Advantages of Dapper:

- Lightweight
- Faster execution
- Direct SQL control
- Ideal for complex queries

---

# 🧠 Entity Framework Implementation

Entity Framework is used for:

- Database migrations
- Data seeding
- LINQ queries
- Change tracking

Example query:

```csharp
_context.Companies.ToList();
```

---

# 🔧 How to Run the Project

## 1 Clone the Repository

```
git clone https://github.com/yourusername/DapperDemo.git
```

---

## 2 Open the Project

Open the solution file in Visual Studio:

```
DapperDemo.sln
```

---

## 3 Configure Database

Update connection string in:

```
appsettings.json
```

---

## 4 Run Migration

Open **Package Manager Console**

```
Update-Database
```

---

## 5 Run the Application

Press:

```
F5
```

or run:

```
dotnet run
```

---

# 📌 Why Use Dapper and EF Together

| Feature | Entity Framework | Dapper |
|-------|-----------------|--------|
| ORM Type | Full ORM | Micro ORM |
| Query Style | LINQ | SQL |
| Performance | Moderate | Very Fast |
| Migrations | Supported | Not Supported |
| Change Tracking | Yes | No |

Using both allows developers to balance **productivity and performance**.

---

# 📷 Application UI

This project provides a simple UI to manage companies including:

- Company List
- Create Company
- Edit Company
- Delete Company
- View Details

---

# 📚 Learning Purpose

This project is useful for developers who want to understand:

- Difference between **Dapper vs Entity Framework**
- How to use **multiple ORMs in one project**
- Repository pattern implementation
- ASP.NET Core MVC CRUD operations

---

# 👨‍💻 Author

**Praveen Anthati**  
.NET Full Stack Developer
