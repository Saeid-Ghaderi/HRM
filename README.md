Human Resource Management
============

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)

This project implements a Human Resource Management (HRM) system designed with C#, ASP.NET Core, following SOLID principles and clean architecture, and utilizing Entity Framework for data persistence. This project offers both an API and an MVC version, providing flexibility for different integration needs.

Project Features

Employee Management: Create, read, update, and delete employee information (CRUD operations). Manage employee details like name, contact information, department, and designation.
Department Management: CRUD operations for departments within the organization. (Optional) Additional functionalities can include:
Leave management
Payroll processing
Performance management
Technologies Used

Programming Language: C#
Web Framework: ASP.NET Core (API and MVC versions)
Design Principles: SOLID principles (Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion)
Architecture: Clean Architecture
Data Persistence: Entity Framework
Project Structure

The project follows a clean architecture approach with separation of concerns:

Core: Contains business logic models, interfaces, and domain entities.
Persistence: Implements data access logic using Entity Framework.
API: Exposes web API endpoints for CRUD operations on resources.
Client: (Optional) Sample client application demonstrating API consumption.
