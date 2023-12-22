# Phone Seller - ASP.NET Core 6 Web Application

## Project Introduction

This project is a modern phone sales platform developed using ASP.NET Core 6. It allows users to explore, evaluate, and purchase phones from various brands. It is supported by a robust back-end structure.

## Technology Stack

- **Framework**: ASP.NET Core 6
- **Database**: [Specify database technology, e.g., SQL Server, MySQL, etc.]
- **Other Used Tools**:
  - Microsoft.EntityFrameworkCore (v6.0.25)
  - Microsoft.EntityFrameworkCore.Design (v6.0.25)
  - AutoMapper.Extensions.Microsoft.DependencyInjection (v12.0.1)
  - AutoMapper (v12.0.1)
  - Microsoft.EntityFrameworkCore.SqlServer (v6.0.25)
  - Microsoft.VisualStudio.Web.CodeGeneration.Design (v6.0.16)
  - Microsoft.AspNetCore.Identity.EntityFrameworkCore (v6.0.25)
  - Microsoft.EntityFrameworkCore.Tools (v6.0.25)

## Setup and Configuration

Follow these steps to run the project in your local environment:

1. Clone the project from GitHub: `git clone [repository link]`.
2. Install the necessary NuGet packages: `dotnet restore`.
3. Configure the database and update the `appsettings.json` file as necessary.
4. Apply database migrations using Entity Framework: `dotnet ef database update`.
5. Run the application: `dotnet run`.

## Usage Examples

Some key usage examples in the project:

1. **User Registration and Login**: User registration and login are managed through the `AccountController`.
2. **Product Display and Orders**: Products are displayed to visitors through the `HomeController`, and orders are processed via the `OrderController`.
3. **User Management**: User information management is facilitated through the `UserController`.

## Contributing

Guide for developers who want to contribute to the project:

1. Fork the project and create your own branch.
2. Make your changes and commit them.
3. Submit a pull request.
