
# 🧱 CleanArchitecture Angular + .NET Core Application

This project demonstrates a full-stack implementation using **Clean Architecture** principles with **Angular** for the frontend and **ASP.NET Core** for the backend. It includes a robust structure for managing **problems**, **problem categories**, and **problem catalogs**, organized in a hierarchical tree with state management via **NgRx** and API communication.

---

## 📁 Project Structure

```
CleanArchitecture-master/
├── AngularClient/         # Angular 15+ frontend application
├── WebApi/                # ASP.NET Core backend with CQRS and Clean Architecture
├── Kong/                  # API Gateway configuration
├── docker-compose.yml     # Docker orchestration
└── CleanArchitecture.sln  # Solution file
```

---

## 🖥️ Technologies Used

### Frontend (AngularClient)
- Angular 15+
- NgRx (Store, Actions, Reducers, Selectors)
- Angular Material UI
- RxJS
- i18n support
- ngx-datatable
- Custom directives for dialog control, scrolling, and validation

### Backend (WebApi)
- ASP.NET Core Web API
- CQRS with MediatR
- FluentValidation
- Entity Framework Core with SQL Server
- Docker support
- NSwag for API client generation
- Kong API Gateway configuration

---

## 🚀 Features

- CRUD operations for problems, categories, and catalogs
- Tree view management of entities
- Dialog-based UI forms with validation
- State management using NgRx
- Custom reusable UI components and directives
- API consumption with typed clients (NSwag generated)
- Internationalization support (i18n)
- Modular and scalable backend structure

---

## 🐳 Getting Started with Docker

### Prerequisites
- Docker & Docker Compose

### Run the entire stack:
```bash
docker-compose up --build
```

---

## 📦 Build & Run

### Frontend (Angular)
```bash
cd AngularClient
npm install
ng serve
```

### Backend (ASP.NET Core)
```bash
cd WebApi
dotnet restore
dotnet run
```

---

## 📂 API Documentation

The backend includes OpenAPI/Swagger documentation accessible at:

```
http://localhost/api/docs
```

NSwag-generated clients are included in `AngularClient/src/app/web-api-client`.

---

## 📝 License

This project is licensed under the MIT License.

---
