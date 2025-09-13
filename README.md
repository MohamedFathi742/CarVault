# 🚗 CarVault API

CarVault is an **ASP.NET Core Web API** project for managing cars, users, and orders.  
It follows the **Clean Architecture** principles and uses **Entity Framework Core, Identity, and JWT Authentication**.

---

## ✨ Features
- 👤 **Authentication & Authorization**
  - User registration & login with JWT Tokens.
  - Role-based access control (Admin, Seller, User).

- 🚗 **Cars Management**
  - Add, update, delete cars.
  - Upload car images.
  - Assign cars to categories.
  - Mark cars as Sold/Available.

- 📂 **Categories**
  - Manage car categories (SUV, Sedan, etc.).
  - Retrieve all cars belonging to a category.

- 🛒 **Orders**
  - Create purchase orders.
  - Fetch orders with related User and Car details.

---

## 🏗️ Tech Stack
- **.NET 8 Web API**
- **Entity Framework Core**
- **SQL Server**
- **ASP.NET Identity**
- **JWT Authentication**
- **Mapster** (DTO Mapping)
- **FluentValidation** (Request Validation)

---

## 🔐 Roles
| Role   | Permissions |
|--------|-------------|
| Admin  | Full management (Users, Cars, Orders, Categories). |
| Seller | Add/update cars. |
| User   | View and request cars only. |

---

## 📡 API Endpoints (Examples)

### Auth
```http
POST /api/auth/register
POST /api/auth/login
