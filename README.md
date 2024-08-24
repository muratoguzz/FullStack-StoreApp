# Full-Stack MVC Project

This project is a full-stack MVC application developed with .NET 6, demonstrating a complete implementation of the Model-View-Controller (MVC) architecture.

## Setup Instructions

**Database Initialization**

   - Delete the `Migrations` folder if it exists.
   - Run the following commands in the terminal to drop the existing database and create a new migration:
     ```bash
     dotnet ef database drop
     dotnet ef migrations add init
     ```

**Admin Login**

   - Default credentials for accessing the application:
     - **Name**: Admin
     - **Password**: Admin+123456

**Run the Application**

   - Restore dependencies:
     ```bash
     dotnet restore
     ```
   - Update `appsettings.json` with your configuration:
     - Connection strings
     - JWT or session settings
   - Run the application:
     ```bash
     dotnet run
     ```
     
## API Endpoints

- **Get All Products**: `{{baseurl}}/api/products`
- **Get Product by ID**: `{{baseurl}}/api/products/{id}`

## NuGet Packages

This project uses the following NuGet packages:

- **AutoMapper.Extensions.Microsoft.DependencyInjection**: Simplifies object-object mapping.
- **Iyzipay**: Payment processing integration.
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore**: ASP.NET Core Identity for authentication.
- **Microsoft.AspNetCore.Mvc.Core**: Core functionalities for ASP.NET Core MVC.
- **Microsoft.EntityFrameworkCore**: Core package for Entity Framework Core.
- **Microsoft.EntityFrameworkCore.Design**: Includes tools required for design-time development.
- **Microsoft.EntityFrameworkCore.SqlServer**: Enables SQL Server as the database provider.



