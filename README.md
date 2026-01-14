# 🛒 Talabat - Food Ordering System

The **Talabat** food ordering system is a comprehensive web application built using **ASP.NET Core** and **Entity Framework Core**. It features a clean, layered architecture with separate projects for each layer, ensuring maintainability and scalability.

## ✨ Key Features

*   **Multi-Layer Architecture**: Clean separation of concerns with distinct projects for Core business logic, Data Repository, API layer, and Services.
*   **Entity Framework Core**: Powerful ORM for database management and migrations.
*   **Generic Repository Pattern**: Reduces code duplication and standardizes data access.
*   **RESTful API**: Designed for consumption by web or mobile front-end applications.

## 🗂️ Project Structure (Solution)

```
Talabat.sln
├── 📂 Talabat.APIs/          # (Main entry point) Contains API Controllers, Middleware, and Configuration.
├── 📂 Talabat.Core/          # (Core Domain) Contains Entities, Interfaces, Enums, and Specifications.
├── 📂 Talabat.Repository/    # (Data Access Layer) Contains the Data Context, Migrations, and Repository implementations.
├── 📂 Talabat.Service/       # (Business Logic Layer) Contains services, DTOs, and application logic.
├── 📄 .gitignore
├── 📄 .gitattributes
└── 📄 README.md              # (This file)
```

## 🚀 Getting Started

### Prerequisites
*   [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
*   [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or use LocalDB which comes with Visual Studio)
*   A code editor like [Visual Studio 2022](https://visualstudio.microsoft.com/vs/), [VS Code](https://code.visualstudio.com/), or [Rider](https://www.jetbrains.com/rider/)

### Installation & Setup
1.  **Clone the repository**
    ```bash
    git clone https://github.com/hazemkhalifa1/Talabat.git
    cd Talabat
    ```

2.  **Restore dependencies**
    ```bash
    dotnet restore
    ```

3.  **Update the database connection string**
    *   Open `appsettings.json` in the `Talabat.APIs` project.
    *   Modify the `DefaultConnection` string to point to your local SQL Server instance.

4.  **Apply database migrations**
    Navigate to the `Talabat.Repository` project folder and run:
    ```bash
    dotnet ef database update
    ```

5.  **Run the application**
    ```bash
    dotnet run --project Talabat.APIs
    ```
    The API will start, typically at `https://localhost:5001` or `http://localhost:5000`.

## 🛠️ Built With

| Technology | Purpose |
|------------|---------|
| ![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white) | Primary backend language |
| ![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?logo=dotnet&logoColor=white) | Web API framework |
| ![Entity Framework Core](https://img.shields.io/badge/EF%20Core-512BD4?logo=dotnet&logoColor=white) | Object-Relational Mapper (ORM) |
| ![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?logo=microsoft-sql-server&logoColor=white) | Database management system |
| ![Git](https://img.shields.io/badge/Git-F05032?logo=git&logoColor=white) | Version control |

## 📖 API Usage Examples

Once the application is running, you can interact with the endpoints. Here are some examples:

*   **Get all products**: `GET https://localhost:5001/api/products`
*   **Get a specific product**: `GET https://localhost:5001/api/products/{id}`
*   *Replace `{id}` with an actual product ID.*

> **Tip**: Use tools like [Postman](https://www.postman.com/) or [Swagger UI](https://swagger.io/tools/swagger-ui/) (if configured) to test the API endpoints.

## 🔧 Development

### Running Tests
*(If you add a test project, describe how to run tests here)*
```bash
dotnet test
```

### Code Scaffolding
To add a new controller based on an existing entity:
```bash
dotnet aspnet-codegenerator controller -name YourController -api -async -m YourEntity -dc ApplicationDbContext -outDir Controllers
```

## 🤝 Contributing

Contributions are what make the open-source community an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

Distributed under the MIT License. See the `LICENSE` file for more information.

## 📞 Contact

Hazem Khalifa - [GitHub Profile](https://github.com/hazemkhalifa1)

Project Link: [https://github.com/hazemkhalifa1/Talabat](https://github.com/hazemkhalifa1/Talabat)

---

## 🌟 Acknowledgements

This project structure is inspired by clean architecture principles and common .NET development practices. Resources that were helpful include:
*   [Microsoft .NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
*   [Entity Framework Core Docs](https://docs.microsoft.com/en-us/ef/core/)
*   [ASP.NET Core Web API Tutorials](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger)
```
