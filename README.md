# 🛒 Talabat - Food Ordering System with ASP.NET Core

[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-blueviolet)](https://dotnet.microsoft.com/)
[![Entity Framework Core](https://img.shields.io/badge/EF%20Core-8.0-blue)](https://docs.microsoft.com/ef/core/)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![Architecture: Clean Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture-orange)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

**Talabat** is a comprehensive web application for managing food orders, built using **ASP.NET Core** and **Entity Framework Core**. It features a clean, multi-layered architecture (Clean Architecture) to ensure maintainability and scalability.

## ✨ Key Features

✅ **Multi-Layered Architecture** - Clear separation between business logic, API layer, data layer, and services layer  
✅ **Entity Framework Core** - Using a powerful ORM for database management and migrations  
✅ **Generic Repository** - Design pattern that reduces duplication and standardizes data access  
✅ **Unit of Work** - Transaction management and data integrity assurance  
✅ **RESTful API** - Designed for consumption by web or mobile applications  
✅ **Data Transfer Objects (DTOs)** - Separates presentation models from domain models  
✅ **Dependency Injection** - Effective dependency management and improved testability  

## 🏗️ Architectural Structure (Clean Architecture)

```
Talabat.sln
├── 📂 Talabat.APIs/          # (Presentation Layer) - API Interfaces
│   ├── Controllers/          # API Controllers
│   ├── DTOs/                 # Data Transfer Objects
│   ├── Middleware/           # Application Middleware
│   ├── Extensions/           # Application Extensions
│   └── appsettings.json      # Application Settings
│
├── 📂 Talabat.Core/          # (System Core) - Core Business Logic
│   ├── Entities/             # Domain Entities
│   ├── Interfaces/           # Repository and Service Interfaces
│   ├── Specifications/       # Specification Pattern for Queries
│   └── Constants/            # System Constants
│
├── 📂 Talabat.Repository/    # (Infrastructure Layer) - Data Access
│   ├── Data/                 # Database Context (DbContext)
│   ├── Migrations/           # Database Migrations
│   ├── GenericRepository/    # Generic Repository
│   └── UnitOfWork/           # Unit of Work Pattern
│
├── 📂 Talabat.Service/       # (Application Layer) - Application Logic
│   ├── Services/             # Application Services
│   ├── Mappings/             * Mapping Files (AutoMapper)
│   └── Validators/           * Data Validators
│
└── 📂 Talabat.Tests/         # (Testing Project) - Unit Tests
    ├── UnitTests/            # Unit Tests
    └── IntegrationTests/     # Integration Tests
```

*Note: Folders marked with * are optional and can be added in the future*

## 🚀 Quick Start

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or LocalDB that comes with Visual Studio)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [VS Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/)

### Installation Steps

1. **Clone the Repository**
   ```bash
   git clone https://github.com/hazemkhalifa1/Talabat.git
   cd Talabat
   ```

2. **Install Required Packages**
   ```bash
   dotnet restore
   ```

3. **Configure Database**
   - Open the `appsettings.json` file in the `Talabat.APIs` project
   - Modify the `DefaultConnection` string to point to your SQL Server:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TalabatDB;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

4. **Apply Database Migrations**
   ```bash
   cd Talabat.Repository
   dotnet ef database update
   ```

5. **Run the Application**
   ```bash
   cd ../Talabat.APIs
   dotnet run
   ```
   
   The application will run on:
   - `https://localhost:5001` (for secure connections)
   - `http://localhost:5000` (for regular connections)

## 📡 API Endpoints

### Store Products
| Method | Path | Description | Status |
|---------|--------|--------|------|
| `GET` | `/api/products` | Retrieve list of all products (with pagination) | ✅ Implemented |
| `GET` | `/api/products/{id}` | Retrieve specific product by ID | ✅ Implemented |
| `POST` | `/api/products` | Add new product | ⏳ Planned |
| `PUT` | `/api/products/{id}` | Update existing product | ⏳ Planned |
| `DELETE` | `/api/products/{id}` | Delete product | ⏳ Planned |

### Orders
| Method | Path | Description | Status |
|---------|--------|--------|------|
| `GET` | `/api/orders` | Retrieve user orders | ⏳ Planned |
| `GET` | `/api/orders/{id}` | Retrieve specific order | ⏳ Planned |
| `POST` | `/api/orders` | Create new order | ✅ Implemented |
| `PUT` | `/api/orders/{id}/status` | Update order status | ⏳ Planned |

### Customers
| Method | Path | Description | Status |
|---------|--------|--------|------|
| `GET` | `/api/customers` | Retrieve customer list | ⏳ Planned |
| `POST` | `/api/customers/register` | Register new customer | ⏳ Planned |
| `POST` | `/api/customers/login` | Customer login | ⏳ Planned |

## 🛠️ Technologies Used

### Core
| Technology | Purpose | Version |
|---------|--------|---------|
| ![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white) | Main programming language | 12.0 |
| ![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?logo=dotnet&logoColor=white) | API framework | 8.0 |
| ![Entity Framework Core](https://img.shields.io/badge/EF%20Core-512BD4?logo=dotnet&logoColor=white) | Object-Relational Mapper (ORM) | 8.0 |
| ![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?logo=microsoft-sql-server&logoColor=white) | Database management system | 2022 |

### Key NuGet Packages
| Package | Purpose | 
|---------|--------|
| **Microsoft.EntityFrameworkCore.SqlServer** | SQL Server provider for EF Core |
| **Microsoft.EntityFrameworkCore.Tools** | EF Core command line tools |
| **Swashbuckle.AspNetCore** | Automatic API documentation (Swagger) |
| **AutoMapper** | Automatic object mapping (planned) |
| **FluentValidation** | Model validation (planned) |

### Development Tools
| Tool | Usage |
|--------|-----------|
| ![Git](https://img.shields.io/badge/Git-F05032?logo=git&logoColor=white) | Version control |
| ![Postman](https://img.shields.io/badge/Postman-FF6C37?logo=postman&logoColor=white) | API testing |
| ![Swagger](https://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=black) | API documentation and testing |

## 🔧 How to Use

### 1. Browse API (Swagger UI)
After running the application, go to:
```
https://localhost:5001/swagger
```
To view all available endpoints and try them directly.

### 2. Testing with Postman
Import the available Postman collection or use the following examples:

**Retrieve all products:**
```http
GET https://localhost:5001/api/products
```

**Create a new order:**
```http
POST https://localhost:5001/api/orders
Content-Type: application/json

{
  "customerId": 1,
  "items": [
    {
      "productId": 5,
      "quantity": 2
    }
  ],
  "deliveryAddress": "123 Tahrir Street, Cairo"
}
```

## 🧪 Testing

### Running Tests
```bash
# Run all tests
dotnet test

# Run specific project tests
dotnet test Talabat.Tests
```

### Test Structure
- **Unit Tests**: Testing services and repositories in isolation
- **Integration Tests**: Testing API integration with database
- **Controller Tests**: Testing API endpoints

## 🗺️ Future Roadmap

### Phase 1 (Current) ✅
- [x] Create basic multi-layered structure
- [x] Implement Generic Repository
- [x] Unit of Work pattern
- [x] Basic endpoints for products and orders

### Phase 2 (In Development) 🔄
- [ ] Implement authentication and authorization using JWT
- [ ] Add Swagger UI for API documentation
- [ ] Implement Specification Pattern for complex queries
- [ ] Add pricing and discounts

### Phase 3 (Planned) ⏳
- [ ] Add electronic payment system
- [ ] Implement real-time notifications
- [ ] Add admin dashboard
- [ ] Integrate with Google Maps for delivery tracking

### Phase 4 (Advanced) 🚀
- [ ] Containerize application using Docker
- [ ] Deploy to AWS/Azure
- [ ] Add caching system (Redis)
- [ ] Build mobile application (React Native/Xamarin)

## 🤝 How to Contribute

Contributions are welcome! To help us improve Talabat:

1. Fork the project
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Make changes and commit them (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Contribution Guidelines
- Follow the existing coding style
- Add clear comments for complex code
- Update documentation when changing APIs
- Write tests for new functionality

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📞 Contact

- **Developer**: Hazem Khalifa
- **Email**: [hazem.khalifa@example.com](mailto:hazem.khalifa@example.com)
- **LinkedIn**: [Hazem Khalifa](https://linkedin.com/in/hazemkhalifa)
- **GitHub**: [@hazemkhalifa1](https://github.com/hazemkhalifa1)

Project Link: [https://github.com/hazemkhalifa1/Talabat](https://github.com/hazemkhalifa1/Talabat)

## 🙏 Acknowledgments

This project is inspired by:
- [Clean Architecture by Uncle Bob](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Microsoft .NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [Entity Framework Core Tutorials](https://docs.microsoft.com/en-us/ef/core/)
- Common architectural patterns in .NET Enterprise application development

---

⭐ **If you like this project, don't forget to add a star to the repository!** ⭐
