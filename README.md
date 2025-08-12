# HumanResourcesDB

HumanResourcesDB, insan kaynakları yönetimi için geliştirilmiş kapsamlı bir veritabanı projesidir.  
Çalışanlar, departmanlar, pozisyonlar, izinler, performans değerlendirmeleri, eğitimler, mesajlaşma ve bildirimler gibi insan kaynakları süreçlerini destekleyen tablolar ve ilişkiler içerir.

---

🛠️ Teknolojiler  
- SQL Server  
- T-SQL  
- İnsan Kaynakları Yönetimi  

📬 İletişim  
Emre Salgır  
E-posta: emre.salgir@gmail.com  
GitHub: https://github.com/EmreSlgr  

## 🚀 Başlangıç

Aşağıdaki adımlarla projeyi veritabanınızda kurup kullanmaya başlayabilirsiniz.

### Veritabanı Kurulumu

1. SQL Server Management Studio veya benzeri bir araçla veritabanı sunucunuza bağlanın.

2. Aşağıdaki SQL kod bloğunu çalıştırarak `HumanResourcesDB` veritabanını ve tablolarını oluşturun:

```sql
-- Veritabanı oluşturma
IF DB_ID('HumanResourcesDB') IS NULL
BEGIN
    CREATE DATABASE HumanResourcesDB;
END
GO

USE HumanResourcesDB;
GO

CREATE TABLE Departments (
    DepartmentID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    DepartmentName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(250) NULL
);
GO

CREATE TABLE Positions (
    PositionID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    PositionName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(250) NULL
);
GO

CREATE TABLE Users (
    UserID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL,
    Password NVARCHAR(200) NOT NULL,
    FullName NVARCHAR(200) NOT NULL,
    Email NVARCHAR(200) NULL,
    Phone NVARCHAR(40) NULL,
    IsActive BIT NULL,
    LastLogin DATETIME NULL,
    CreatedDate DATETIME NULL
);
GO

CREATE TABLE Employees (
    EmployeeID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    DepartmentID INT NULL,
    PositionID INT NULL,
    UserID INT NULL,
    CONSTRAINT FK_Employees_Departments FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
    CONSTRAINT FK_Employees_Positions FOREIGN KEY (PositionID) REFERENCES Positions(PositionID)
);
GO

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Users FOREIGN KEY (UserID) REFERENCES Users(UserID);
GO

CREATE TABLE Leaves (
    LeaveID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT NOT NULL,
    LeaveTypeID INT NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    Reason NVARCHAR(500) NULL,
    Status NVARCHAR(50) NULL,
    CONSTRAINT FK_Leaves_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);
GO

CREATE TABLE LeaveTypes (
    LeaveTypeID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    LeaveTypeName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(250) NULL
);
GO

CREATE TABLE EmployeeDocuments (
    DocumentID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT NOT NULL,
    DocumentName NVARCHAR(200) NOT NULL,
    DocumentPath NVARCHAR(500) NOT NULL,
    UploadDate DATETIME NULL,
    CONSTRAINT FK_EmployeeDocuments_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);
GO

CREATE TABLE Trainings (
    TrainingID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT NOT NULL,
    TrainingName NVARCHAR(200) NOT NULL,
    Description NVARCHAR(500) NULL,
    StartDate DATETIME NULL,
    EndDate DATETIME NULL,
    Status NVARCHAR(50) NULL,
    CONSTRAINT FK_Trainings_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);
GO

CREATE TABLE Messages (
    MessageID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    SenderID INT NOT NULL,
    ReceiverID INT NOT NULL,
    MessageText NVARCHAR(MAX) NOT NULL,
    SentDate DATETIME NULL,
    IsRead BIT NULL,
    CONSTRAINT FK_Messages_Sender FOREIGN KEY (SenderID) REFERENCES Employees(EmployeeID),
    CONSTRAINT FK_Messages_Receiver FOREIGN KEY (ReceiverID) REFERENCES Employees(EmployeeID)
);
GO

CREATE TABLE Notifications (
    NotificationID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT NOT NULL,
    NotificationText NVARCHAR(MAX) NOT NULL,
    NotificationDate DATETIME NULL,
    IsRead BIT NULL,
    CONSTRAINT FK_Notifications_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);
GO
