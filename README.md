# APBD_1 - Container Ship Logistics Manager

## Overview

This project is part of the APBD course and focuses on designing an object-oriented application to simulate **loading and managing containers on cargo ships**. The system handles various container types, container ships, and all interactions between them based on business rules. This should be rather considered as a task that will help you to remind how to use OOP concepts.

## Objectives

* Practice strong OOP concepts such as inheritance, interfaces, exception handling, and encapsulation
* Implement a container logistics system including:

  * Container creation and management
  * Container ship constraints (capacity, weight, max containers)
  * Loading/unloading/replacing containers
  * Safety notifications for hazardous cargo
* Develop custom business logic such as:

  * Auto-generating serial numbers in format `KON-{Type}-{UniqueId}`
  * Max fill rules for hazardous/non-hazardous contents
  * Custom exceptions like `OverfillException`

## Key Features

* **Container Types:**

  * **Liquid Containers (L)**: Can store safe and hazardous liquids, with different max fill limits
  * **Gas Containers (G)**: Includes pressure tracking and safety unloading rules
  * **Refrigerated Containers (C)**: Tracks cargo temperature and only stores one type of product

* **Interfaces:**

  * `IHazardNotifier` – notifies about dangerous situations with container number

* **Ship Features:**

  * Max weight in tons
  * Max container count
  * Max speed
  * Tracks all containers loaded
  * Allows loading, unloading, replacing, and transferring containers

## Example Interactions

* Load banana into a refrigerated container
* Transfer helium (gas) into a gas container with pressure value
* Prevent overfill by throwing a custom exception
* Move a container from one ship to another
* Print information about specific containers or entire ships

## Running the Application

1. **Clone the repository**

```bash
git clone https://github.com/x0-lf/APBD_1.git
cd APBD_1
```

2. **Open the project**

   * Use an IDE like Visual Studio or JetBrains Rider
   * Target framework: .NET 8 or later

3. **Run the Program**

   * Use the `Program.cs` in the `Main()` method to simulate loading ships and containers
   * Sample operations will be logged to the console

## Requirements

* [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* Basic understanding of OOP and exception handling in C#

---

### Next Projects in the Series

**[APBD_2 - Simple 20 LINQ xUnit Tests](https://github.com/x0-lf/APBD_2)**
**[APBD_3 - REST API Travel Agency](https://github.com/x0-lf/APBD_3)**
**[APBD_4 - Warehouse Management](https://github.com/x0-lf/APBD_4)**
**[APBD_5 - EF (Code First) App that helps to manage prescriptions](https://github.com/x0-lf/APBD_5)**
**[APBD_6 – EF (Database First) Client and Trip Management API](https://github.com/x0-lf/APBD_6)**
