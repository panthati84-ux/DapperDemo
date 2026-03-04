DapperDemo

A sample ASP.NET Core Razor Pages application demonstrating Dapper and Entity Framework Core working together in the same project for database operations.

Project Overview

This project demonstrates how to build a .NET 8 Razor Pages application that performs CRUD operations on a Company table using two data access approaches:

- Dapper – lightweight micro ORM for fast SQL queries
- Entity Framework Core – full ORM used for migrations and database management

The application allows users to create, read, update, delete, and view company information via Razor Pages.

Technologies Used

- .NET 8
- ASP.NET Core Razor Pages
- Dapper
- Entity Framework Core
- SQL Server
- Razor Pages (UI)
- Bootstrap
- jQuery

Project Structure
DapperDemo
│
├── Views
│   ├── Companies
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   └── Details.cshtml
│   └── Shared
│       └── _Layout.cshtml
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
├── wwwroot
│
├── appsettings.json
└── Program.cs

Company Model
public class Company
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string PostalCode { get; set; }
}

Database Configuration

Connection string is defined in `appsettings.json`.

Example:
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=DapperDemoDB;Trusted_Connection=True;TrustServerCertificate=True"
}

Entity Framework Migration

From the Package Manager Console run:
- __Add-Migration__ InitialCreate
- __Update-Database__

Or using the CLI:
- `dotnet ef migrations add InitialCreate`
- `dotnet ef database update`

Running the Application

1. Clone the repository
   git clone https://github.com/panthati84-ux/DapperDemo

2. Open the solution in Visual Studio

3. Configure the database connection in `appsettings.json`

4. Run migrations (see commands above) or use the Package Manager Console

5. Run the project
   - Press __F5__ in Visual Studio, or run:
     dotnet run

Features

- CRUD operations for Companies via Razor Pages
- Dapper implementation for SQL queries
- Entity Framework for migrations and database creation
- Razor Pages UI interface
- Repository pattern implementation

Why Use Dapper and EF Together

Entity Framework — Full ORM, Handles migrations, LINQ queries, Change tracking  
Dapper — Micro ORM, Direct SQL queries, High performance, Lightweight

Using both provides flexibility and performance in enterprise applications.

Author

Praveen Anthati
.NET Full Stack Developer