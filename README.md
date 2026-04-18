# AstroNova - Space Exploration Management System

![.NET Version](https://img.shields.io/badge/.NET-10.0-blue)
![License](https://img.shields.io/badge/License-MIT-green)
![Status](https://img.shields.io/badge/Status-Active-brightgreen)

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [System Requirements](#system-requirements)
- [Installation & Setup](#installation--setup)
- [Configuration](#configuration)
- [Running the Application](#running-the-application)
- [Project Structure](#project-structure)
- [Database Schema](#database-schema)
- [Usage Examples](#usage-examples)
- [Technologies](#technologies)
- [Troubleshooting](#troubleshooting)

---

## 🚀 Overview

**AstroNova** is a comprehensive console-based Space Exploration Management System built with C# and .NET 10. It manages critical space operations including astronauts, engineers, spacecraft, missions, and exploration logs for the fictional AstroNova Mission Control organization.

The application implements a complete CRUD (Create, Read, Update, Delete) system for all entities with real-time database synchronization using Entity Framework Core and MySQL.

---

## ✨ Features

### Entity Management
- ✅ **Astronaut Management** - Track astronauts with rank levels (Rookie, Pilot, Commander) and experience hours
- ✅ **Engineer Management** - Manage engineers by specialty (Propulsion, Systems, AI) and years of experience
- ✅ **Spacecraft Management** - Monitor fleet with status tracking (Operational, Under Maintenance, Retired)
- ✅ **Mission Management** - Plan and track missions with status lifecycle (Planned, In Progress, Completed, Failed)
- ✅ **Exploration Logs** - Document exploration activities with risk assessment (Low, Medium, High)

### Core Functionality
- Complete CRUD operations for all entities
- Relational data management with Foreign Keys
- Input validation and error handling
- Interactive console menu system
- Persistent database storage

### Data Relationships
- **Astronauts → Missions** (1:N) - One astronaut can participate in multiple missions
- **Spacecraft → Missions** (1:N) - One spacecraft can be used in multiple missions
- **Missions → Exploration Logs** (1:N) - One mission can have multiple exploration records

---

## 💻 System Requirements

- **Operating System**: Windows, macOS, or Linux
- **.NET Runtime**: .NET 10.0 or higher
- **Database**: MySQL 8.0 or higher
- **RAM**: Minimum 2GB
- **Storage**: 100MB for application + database space
- **IDE** (Optional): Visual Studio, Visual Studio Code, or JetBrains Rider

---

## 📦 Installation & Setup

### Step 1: Clone/Download the Project

```bash
# Clone the repository
git clone <repository-url>
cd AstroNova
```

### Step 2: Install .NET 10 SDK

Download from [Microsoft .NET Official Website](https://dotnet.microsoft.com/download/dotnet/10.0)

Verify installation:
```bash
dotnet --version
```

### Step 3: Install MySQL Server

**Windows:**
```bash
# Using Chocolatey
choco install mysql
```

**macOS:**
```bash
# Using Homebrew
brew install mysql
```

**Linux (Ubuntu/Debian):**
```bash
sudo apt-get update
sudo apt-get install mysql-server
```

Start MySQL service:
```bash
# Windows
net start MySQL80

# macOS
brew services start mysql

# Linux
sudo systemctl start mysql
```

### Step 4: Install Dependencies

```bash
dotnet restore
```

---

## ⚙️ Configuration

### Setting Environment Variables

The application requires database connection parameters via environment variables.

#### Option 1: Permanent Environment Variables (Recommended)

**Windows (PowerShell):**
```powershell
$env:DB_HOST = "localhost"
$env:DB_PORT = "3306"
$env:DB_NAME = "astronova_db"
$env:DB_USER = "root"
$env:DB_PASSWORD = "your_password"

# Make permanent (optional)
[Environment]::SetEnvironmentVariable("DB_HOST", "localhost", "User")
[Environment]::SetEnvironmentVariable("DB_PORT", "3306", "User")
[Environment]::SetEnvironmentVariable("DB_NAME", "astronova_db", "User")
[Environment]::SetEnvironmentVariable("DB_USER", "root", "User")
[Environment]::SetEnvironmentVariable("DB_PASSWORD", "your_password", "User")
```

**Windows (Command Prompt):**
```cmd
setx DB_HOST localhost
setx DB_PORT 3306
setx DB_NAME astronova_db
setx DB_USER root
setx DB_PASSWORD your_password
```

**Linux/macOS (Bash):**
```bash
export DB_HOST=localhost
export DB_PORT=3306
export DB_NAME=astronova_db
export DB_USER=root
export DB_PASSWORD=your_password

# Make permanent by adding to ~/.bashrc or ~/.zshrc
echo 'export DB_HOST=localhost' >> ~/.bashrc
echo 'export DB_PORT=3306' >> ~/.bashrc
echo 'export DB_NAME=astronova_db' >> ~/.bashrc
echo 'export DB_USER=root' >> ~/.bashrc
echo 'export DB_PASSWORD=your_password' >> ~/.bashrc

source ~/.bashrc
```

#### Option 2: Temporary Environment Variables (Session Only)

```bash
# Windows PowerShell
$env:DB_HOST = "localhost"
$env:DB_PORT = "3306"
$env:DB_NAME = "astronova_db"
$env:DB_USER = "root"
$env:DB_PASSWORD = "your_password"

# Linux/macOS Bash
export DB_HOST=localhost
export DB_PORT=3306
export DB_NAME=astronova_db
export DB_USER=root
export DB_PASSWORD=your_password
```

⚠️ **Note**: Temporary variables are lost when you close the terminal.

### Create Database

**Option 1: Using MySQL CLI**
```bash
mysql -u root -p
```

Then execute:
```sql
CREATE DATABASE astronova_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
```

**Option 2: Using MySQL Workbench**
1. Connect to your MySQL server
2. Right-click on Databases → Create New Database
3. Name: `astronova_db`
4. Charset: `utf8mb4`
5. Collation: `utf8mb4_unicode_ci`
6. Click Apply

### Run Entity Framework Migrations

After setting environment variables and creating the database:

```bash
# Add initial migration
dotnet ef migrations add InitialCreate

# Apply migrations to database
dotnet ef database update
```

---

## 🏃 Running the Application

### Build the Project

```bash
dotnet build
```

### Run the Application

```bash
dotnet run
```

### Expected Output

```
╔═══════════════════════════════════════════════════════════╗
║     SISTEMA DE GESTIÓN DE EXPLORACIÓN ESPACIAL - AstroNova  ║
╚═══════════════════════════════════════════════════════════╝

¿Qué deseas gestionar?

1. Astronautas
2. Ingenieros
3. Naves
4. Misiones
5. Registros de Exploración
0. Salir

Selecciona una opción:
```

Navigate through the menu using numeric inputs (0-5).

---

## 📁 Project Structure

```
AstroNova/
├── Program.cs                      # Main entry point with interactive menu
├── astronova.csproj               # Project configuration
├── README.md                       # This file
├── REQUESTS.md                     # Requirements specification
│
├── Data/
│   └── AstronovaDbContext.cs       # Entity Framework DbContext
│
├── Entities/                       # Domain models
│   ├── Astronauts.cs
│   ├── Engineers.cs
│   ├── Ships.cs
│   ├── Missions.cs
│   ├── ExplorationLogs.cs
│   │
│   └── Enums/                      # Enumeration types
│       ├── AstronautRank.cs        # Rookie, Pilot, Commander
│       ├── EngineerSpeciality.cs   # Propulsion, Systems, AI
│       ├── MissionStatus.cs        # Planned, InProgress, Completed, Failed
│       ├── RiskLevel.cs            # Low, Medium, High
│       └── ShipStatus.cs           # Operational, UnderMaintenance, Retired
│
├── Repository/                     # Data access layer
│   ├── AstronautsRepository.cs
│   ├── EngineersRepository.cs
│   ├── ShipsRepository.cs
│   ├── MissionsRepository.cs
│   └── ExplorationLogsRepository.cs
│
├── Migrations/                     # Entity Framework migrations
│   ├── 20260414015610_InitialCreate.cs
│   ├── 20260414020034_InitialCreate2.cs
│   ├── 20260415003903_AstronautUpdated.cs
│   └── AstronovaDbContextModelSnapshot.cs
│
└── bin/Debug/                      # Compiled output
```

---

## 📊 Database Schema

### Astronauts Table
```sql
CREATE TABLE Astronauts (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    Range ENUM('Rookie', 'Pilot', 'Commander') NOT NULL,
    HoursExperience INT CHECK (HoursExperience > 0)
);
```

### Engineers Table
```sql
CREATE TABLE Engineers (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    Specialty ENUM('Propulsion', 'Systems', 'AI') NOT NULL,
    YearExperience INT NOT NULL
);
```

### Ships Table
```sql
CREATE TABLE Ships (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL,
    Model VARCHAR(100) NOT NULL,
    CrewCapacity INT CHECK (CrewCapacity > 0),
    Status ENUM('Operational', 'UnderMaintenance', 'Retired') NOT NULL
);
```

### Missions Table
```sql
CREATE TABLE Missions (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(200) NOT NULL,
    LaunchDate DATETIME NOT NULL,
    Status ENUM('Planned', 'InProgress', 'Completed', 'Failed') NOT NULL,
    AstronautId INT NOT NULL,
    ShipId INT NOT NULL,
    FOREIGN KEY (AstronautId) REFERENCES Astronauts(Id),
    FOREIGN KEY (ShipId) REFERENCES Ships(Id)
);
```

### ExplorationLogs Table
```sql
CREATE TABLE ExplorationLogs (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    DestinyPlanet VARCHAR(100) NOT NULL,
    Description TEXT,
    RiskLevel ENUM('Low', 'Medium', 'High') NOT NULL,
    MissionId INT NOT NULL,
    FOREIGN KEY (MissionId) REFERENCES Missions(Id)
);
```

---

## 💡 Usage Examples

### Creating an Astronaut

1. Run: `dotnet run`
2. Select option: `1` (Astronauts)
3. Select option: `1` (Create Astronaut)
4. Enter details:
   - Name: `John`
   - Last Name: `Armstrong`
   - Experience Hours: `5000`
   - Rank: `2` (Commander)
5. Confirmation: `✅ Astronauta creado exitosamente`

### Creating a Mission

1. Select option: `4` (Missions)
2. Select option: `1` (Create Mission)
3. Enter details:
   - Mission Name: `Apollo 11`
   - Launch Date: `2026-04-20`
   - Status: `1` (InProgress)
   - Astronaut ID: `1`
   - Ship ID: `1`
4. Confirmation: `✅ Misión creada exitosamente`

### Viewing All Astronauts

1. Select option: `1` (Astronauts)
2. Select option: `2` (List Astronauts)
3. Display all registered astronauts with details

### Updating an Entity

1. Select option: `[1-5]` (Any entity)
2. Select option: `4` (Update)
3. Enter entity ID
4. Provide new values (leave blank to skip fields)

### Deleting an Entity

1. Select option: `[1-5]` (Any entity)
2. Select option: `5` (Delete)
3. Enter entity ID for confirmation

---

## 🛠️ Technologies Used

| Technology | Version | Purpose |
|-----------|---------|---------|
| .NET | 10.0 | Runtime Framework |
| C# | Latest | Programming Language |
| Entity Framework Core | Latest | ORM |
| MySQL | 8.0+ | Database |
| Pomelo.EntityFrameworkCore.MySql | Latest | MySQL Driver for EF Core |

---

## 🔍 Validation Rules

The application enforces the following business rules:

| Entity | Field | Validation |
|--------|-------|-----------|
| Astronauts | HoursExperience | Must be > 0 |
| Engineers | YearExperience | Must be > 0 |
| Ships | CrewCapacity | Must be > 0 |
| Missions | Status | Must be valid enum value |
| Missions | AstronautId | Must reference existing astronaut |
| Missions | ShipId | Must reference existing ship |
| ExplorationLogs | RiskLevel | Must be Low, Medium, or High |
| ExplorationLogs | MissionId | Must reference existing mission |

---

## ⚠️ Troubleshooting

### Problem: "Database connection failed"
**Solution:**
1. Verify MySQL service is running
2. Check environment variables are set correctly
3. Confirm database `astronova_db` exists
4. Test connection: `mysql -u root -p -h localhost`

### Problem: "Migrations pending"
**Solution:**
```bash
dotnet ef database update
```

### Problem: "Package restore fails"
**Solution:**
```bash
dotnet nuget locals all --clear
dotnet restore
```

### Problem: ".NET SDK not found"
**Solution:**
1. Download .NET 10.0 SDK from [Microsoft](https://dotnet.microsoft.com/download/dotnet/10.0)
2. Verify installation: `dotnet --version`
3. Restart terminal/IDE

### Problem: "Invalid connection string"
**Solution:**
1. Verify all environment variables are set:
   ```bash
   # Windows PowerShell
   Get-ChildItem env: | Where-Object {$_.Name -like "DB_*"}
   
   # Linux/macOS
   env | grep DB_
   ```
2. Check MySQL default port (usually 3306)
3. Verify MySQL username and password

### Problem: "Port 3306 already in use"
**Solution:**
```bash
# Find process using port 3306
# Windows
netstat -ano | findstr :3306

# Linux/macOS
lsof -i :3306

# Kill process or configure different MySQL port
```

---

## 📝 Notes

- All data is persisted to the MySQL database
- The menu system is interactive and user-friendly
- The application validates all inputs before database operations
- All CRUD operations include error handling with user-friendly messages
- Entity relationships are enforced at the database level

---

## 📄 License

This project is licensed under the MIT License.

---

## 📧 Support

For issues, questions, or contributions, please contact AstroNova Mission Control Support.

---

**Last Updated**: April 18, 2026  
**Status**: ✅ Production Ready

