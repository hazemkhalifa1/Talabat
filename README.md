
## 🚀 Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or SQL Server LocalDB)
- [Git](https://git-scm.com/)
- An IDE (e.g., [Visual Studio 2022](https://visualstudio.microsoft.com/vs/), [VS Code](https://code.visualstudio.com/), or [Rider](https://www.jetbrains.com/rider/))

### Installation & Setup

1.  **Clone the repository**
    ```bash
    git clone https://github.com/hazemkhalifa1/Talabat.git
    cd Talabat
    ```

2.  **Restore the NuGet packages**
    ```bash
    dotnet restore
    ```

3.  **Configure the Database**
    - Open `appsettings.json` in the `Talabat.APIs` project.
    - Update the `DefaultConnection` string to point to your SQL Server instance.

4.  **Apply Database Migrations**
    From the `Talabat.Repository` project directory, run:
    ```bash
    dotnet ef database update
    ```

5.  **Run the Application**
    Navigate to the `Talabat.APIs` project and run:
    ```bash
    dotnet run
    ```
    The API will start, typically accessible at:
    - `https://localhost:5001`
    - `http://localhost:5000`

## 📡 API Endpoints

### Products
| Method | Endpoint | Description | Status |
|--------|----------|-------------|--------|
| `GET` | `/api/products` | Retrieves a paginated list of all products. | ✅ Implemented |
| `GET` | `/api/products/{id}` | Retrieves details of a specific product. | ✅ Implemented |
| `POST` | `/api/products` | Creates a new product. | 🔄 Planned |
| `PUT` | `/api/products/{id}` | Updates an existing product. | 🔄 Planned |
| `DELETE` | `/api/products/{id}` | Deletes a product. | 🔄 Planned |

### Orders
| Method | Endpoint | Description | Status |
|--------|----------|-------------|--------|
| `POST` | `/api/orders` | Creates a new food order. | ✅ Implemented |
| `GET` | `/api/orders` | Retrieves orders for a user. | 🔄 Planned |
| `GET` | `/api/orders/{id}` | Retrieves a specific order's details. | 🔄 Planned |

## 🛠️ Technology Stack

### Core Frameworks & Languages
| Technology | Purpose |
|------------|---------|
| ![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white) | Primary backend language |
| ![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?logo=dotnet&logoColor=white) | Web API framework |
| ![Entity Framework Core](https://img.shields.io/badge/EF%20Core-512BD4?logo=dotnet&logoColor=white) | Object-Relational Mapper (ORM) |
| ![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?logo=microsoft-sql-server&logoColor=white) | Relational database system |

### Key NuGet Packages
| Package | Purpose |
|---------|---------|
| **Microsoft.EntityFrameworkCore.SqlServer** | SQL Server provider for EF Core |
| **Microsoft.EntityFrameworkCore.Tools** | EF Core CLI tools (for migrations) |
| **Swashbuckle.AspNetCore** | For interactive API documentation (Swagger UI) |

## 🗺️ Development Roadmap

### Phase 1 (Current) ✅
- [x] Establish core multi-layered solution structure.
- [x] Implement Generic Repository and Unit of Work patterns.
- [x] Create foundational API endpoints for Products and Orders.

### Phase 2 (In Progress / Planned) 🔄
- [ ] Implement JWT-based Authentication & Authorization.
- [ ] Integrate **Swagger UI** for API documentation and testing.
- [ ] Implement the **Specification Design Pattern** for advanced querying[citation:7].
- [ ] Add shopping cart functionality.

### Phase 3 (Future) ⏳
- [ ] Integrate a payment gateway (e.g., Stripe).
- [ ] Add a caching layer using **Redis**[citation:4][citation:7].
- [ ] Implement real-time notifications.
- [ ] Containerize the application using Docker.

## 🤝 How to Contribute

Contributions are welcome! To contribute to Talabat:

1.  Fork the repository.
2.  Create a feature branch (`git checkout -b feature/AmazingFeature`).
3.  Commit your changes (`git commit -m 'Add some AmazingFeature'`).
4.  Push to the branch (`git push origin feature/AmazingFeature`).
5.  Open a Pull Request.

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## 📞 Contact

**Hazem Khalifa**
- GitHub: [@hazemkhalifa1](https://github.com/hazemkhalifa1)
- Project Link: [https://github.com/hazemkhalifa1/Talabat](https://github.com/hazemkhalifa1/Talabat)

---

⭐ **If you find this project interesting or useful, please give it a star on GitHub!** ⭐
