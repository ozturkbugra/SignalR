**# 🍔 Real-Time Order Management System (SignalR)

![Framework](https://img.shields.io/badge/ASP.NET%20Core%20API-MVC-purple)
![RealTime](https://img.shields.io/badge/Tech-SignalR-red)
![Architecture](https://img.shields.io/badge/Architecture-N--Layer-blue)
![Communication](https://img.shields.io/badge/Pattern-API%20Consume-orange)

## 📖 Overview
This project is a restaurant order management system developed to practice **Real-Time Web Applications** using **SignalR**.

The project is structured into two main parts:
1.  **Web API:** The backend that handles database operations and logic.
2.  **Web UI:** The frontend that **consumes the API** using `HttpClient` to display data.

It features an **N-Layer Architecture** to ensure separation of concerns between Data Access, Business, and Presentation layers.

## 🚀 Key Features

### 📡 Real-Time Communication (SignalR)
* **Live Table Status:** When an order is placed, the table color changes instantly on the dashboard without refreshing the page.
* **Instant Statistics:** Dashboard counters (Total Money, Active Orders, etc.) update in real-time as data changes in the database.

### 🔌 API Consumption
* The User Interface (MVC) does not connect to the database directly.
* All CRUD operations are performed by sending **HTTP Requests (GET, POST, PUT, DELETE)** to the Web API backend.

### 🏗️ Architecture
* **N-Layer Design:** Organized into Entity, DataAccess, Business, and API/UI layers.
* **DTOs:** Data Transfer Objects are used to carry data between processes.

## 🛠️ Tech Stack

| Component | Technology |
| :--- | :--- |
| **Backend** | .NET Core Web API |
| **Frontend** | ASP.NET Core MVC (Consuming API) |
| **Real-Time** | **Microsoft SignalR** |
| **Architecture** | N-Layered Architecture |
| **Data Access** | Entity Framework Core |
| **Database** | MSSQL |
| **Communication** | HttpClient / Newtonsoft.Json |

---
*Developed by [Bugra Ozturk](https://github.com/ozturkbugra)***
