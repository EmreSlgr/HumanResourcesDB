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
-- 1. Veritabanı oluşturma (varsa)
IF DB_ID('HumanResourcesDB') IS NULL
BEGIN
    CREATE DATABASE HumanResourcesDB;
END
GO

USE HumanResourcesDB;
GO

-- 2. Tablolar

CREATE TABLE dbo.Departments (
    DepartmentID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    DepartmentName NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE dbo.Positions (
    PositionID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    PositionName NVARCHAR(100) NOT NULL,
    DepartmentID INT NOT NULL,
    CONSTRAINT FK_Positions_Departments FOREIGN KEY (DepartmentID) REFERENCES dbo.Departments(DepartmentID)
);
GO

CREATE TABLE dbo.Roles (
    RoleID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE dbo.Users (
    UserID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    PasswordHash NVARCHAR(256) NOT NULL,
    Email NVARCHAR(100) NULL,
    IsActive BIT NOT NULL DEFAULT ((1)),
    CreatedAt DATETIME NOT NULL DEFAULT (GETDATE()),
    RoleID INT NULL,
    EmployeeID INT NULL,
    CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleID) REFERENCES dbo.Roles(RoleID)
    -- EmployeeID ile Users-Employees ilişkisi CREATE sonra eklenecek (Employees tablosu sonra)
);
GO

CREATE TABLE dbo.Employees (
    EmployeeID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Surname NVARCHAR(100) NOT NULL,
    Gender NVARCHAR(10) NULL,
    BirthDate DATE NULL,
    DepartmentID INT NOT NULL,
    PositionID INT NOT NULL,
    HireDate DATE NULL,
    Phone NVARCHAR(20) NULL,
    RelativePhone NVARCHAR(20) NULL,
    Address NVARCHAR(255) NULL,
    CVFilePath NVARCHAR(255) NULL,
    ProfileImagePath NVARCHAR(255) NULL,
    Email NVARCHAR(100) NULL,
    StartDate DATE NULL,
    Photo VARBINARY(MAX) NULL,
    UserID INT NULL,
    CONSTRAINT FK_Employees_Departments FOREIGN KEY (DepartmentID) REFERENCES dbo.Departments(DepartmentID),
    CONSTRAINT FK_Employees_Positions FOREIGN KEY (PositionID) REFERENCES dbo.Positions(PositionID)
    -- UserID foreign key ilişki sonra eklenecek (Users tablosu zaten var)
);
GO

-- Şimdi UserID ile Employees tablosu arasındaki foreign key ilişkiyi ekleyelim:
ALTER TABLE dbo.Employees
ADD CONSTRAINT FK_Employees_Users FOREIGN KEY (UserID) REFERENCES dbo.Users(UserID);
GO

ALTER TABLE dbo.Users
ADD CONSTRAINT FK_Users_Employees FOREIGN KEY (EmployeeID) REFERENCES dbo.Employees(EmployeeID);
GO

CREATE TABLE dbo.LeaveTypes (
    LeaveTypeID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    LeaveTypeName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(250) NULL
);
GO

CREATE TABLE dbo.EmployeeLeaveRequests (
    LeaveRequestID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT NOT NULL,
    LeaveTypeID INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalDays INT NOT NULL,
    Reason NVARCHAR(250) NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT ('Beklemede'),
    RequestedDate DATETIME NOT NULL DEFAULT (GETDATE()),
    ApprovedBy INT NULL,
    ApprovalDate DATETIME NULL,
    CONSTRAINT FK_EmployeeLeaveRequests_Employees FOREIGN KEY (EmployeeID) REFERENCES dbo.Employees(EmployeeID),
    CONSTRAINT FK_EmployeeLeaveRequests_LeaveTypes FOREIGN KEY (LeaveTypeID) REFERENCES dbo.LeaveTypes(LeaveTypeID),
    CONSTRAINT FK_EmployeeLeaveRequests_Approver FOREIGN KEY (ApprovedBy) REFERENCES dbo.Users(UserID)
);
GO

CREATE TABLE dbo.LeaveRequests (
    LeaveRequestID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT NOT NULL,
    LeaveTypeID INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalDays INT NOT NULL,
    Reason NVARCHAR(500) NULL,
    Status NVARCHAR(50) NULL,
    RequestedDate DATETIME NOT NULL,
    ApprovedBy INT NULL,
    ApprovalDate DATETIME NULL,
    CONSTRAINT FK_LeaveRequests_Employees FOREIGN KEY (EmployeeID) REFERENCES dbo.Employees(EmployeeID),
    CONSTRAINT FK_LeaveRequests_LeaveTypes FOREIGN KEY (LeaveTypeID) REFERENCES dbo.LeaveTypes(LeaveTypeID),
    CONSTRAINT FK_LeaveRequests_Approver FOREIGN KEY (ApprovedBy) REFERENCES dbo.Users(UserID)
);
GO

CREATE TABLE dbo.Leaves (
    LeaveID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT NOT NULL,
    LeaveType NVARCHAR(50) NULL,
    StartDate DATE NULL,
    EndDate DATE NULL,
    Status NVARCHAR(20) NULL DEFAULT ('Beklemede'),
    ApprovedBy INT NULL,
    CONSTRAINT FK_Leaves_Employees FOREIGN KEY (EmployeeID) REFERENCES dbo.Employees(EmployeeID),
    CONSTRAINT FK_Leaves_Approver FOREIGN KEY (ApprovedBy) REFERENCES dbo.Users(UserID)
);
GO

CREATE TABLE dbo.EmployeeAbsences (
    AbsenceID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT NOT NULL,
    AbsenceDate DATE NOT NULL,
    Reason NVARCHAR(250) NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT ('Beklemede'),
    ReportedDate DATETIME NOT NULL DEFAULT (GETDATE()),
    CONSTRAINT FK_EmployeeAbsences_Employees FOREIGN KEY (EmployeeID) REFERENCES dbo.Employees(EmployeeID)
);
GO

CREATE TABLE dbo.EmployeeDocuments (
    DocumentID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT NOT NULL,
    DocumentName NVARCHAR(255) NOT NULL,
    DocumentType NVARCHAR(100) NOT NULL,
    DocumentData VARBINARY(MAX) NOT NULL,
    UploadDate DATETIME NOT NULL DEFAULT (GETDATE()),
    CONSTRAINT FK_EmployeeDocuments_Employees FOREIGN KEY (EmployeeID) REFERENCES dbo.Employees(EmployeeID)
);
GO

CREATE TABLE dbo.PerformanceDocuments (
    DocumentID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    EvaluationID INT NULL,
    DocumentName NVARCHAR(255) NULL,
    FileType NVARCHAR(50) NULL,
    FileData VARBINARY(MAX) NULL,
    UploadedDate DATETIME NULL DEFAULT (GETDATE()),
    CONSTRAINT FK_PerformanceDocuments_Evaluations FOREIGN KEY (EvaluationID) REFERENCES dbo.Evaluations(EvaluationID)
);
GO

CREATE TABLE dbo.Evaluations (
    EvaluationID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT NOT NULL,
    EvaluatorID INT NOT NULL,
    Score INT NULL,
    Comment NVARCHAR(MAX) NULL,
    EvaluationDate DATE NULL,
    CONSTRAINT FK_Evaluations_Employees FOREIGN KEY (EmployeeID) REFERENCES dbo.Employees(EmployeeID),
    CONSTRAINT FK_Evaluations_Evaluators FOREIGN KEY (EvaluatorID) REFERENCES dbo.Employees(EmployeeID)
);
GO

CREATE TABLE dbo.Trainings (
    TrainingID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT NOT NULL,
    TrainingName NVARCHAR(100) NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NULL,
    Status NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(500) NULL,
    CreatedDate DATETIME NOT NULL DEFAULT (GETDATE()),
    UpdatedDate DATETIME NULL,
    CONSTRAINT FK_Trainings_Employees FOREIGN KEY (EmployeeID) REFERENCES dbo.Employees(EmployeeID)
);
GO

CREATE TABLE dbo.Messages (
    MessageID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    SenderUserID INT NULL,
    ReceiverUserID INT NULL,
    Subject NVARCHAR(100) NULL,
    Body NVARCHAR(MAX) NULL,
    IsRead BIT NULL DEFAULT ((0)),
    SentDate DATETIME NULL DEFAULT (GETDATE()),
    CONSTRAINT FK_Messages_Sender FOREIGN KEY (SenderUserID) REFERENCES dbo.Users(UserID),
    CONSTRAINT FK_Messages_Receiver FOREIGN KEY (ReceiverUserID) REFERENCES dbo.Users(UserID)
);
GO

CREATE TABLE dbo.Notifications (
    NotificationID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    Title NVARCHAR(100) NULL,
    Content NVARCHAR(MAX) NULL,
    Date DATETIME NULL DEFAULT (GETDATE()),
    IsRead BIT NULL DEFAULT ((0)),
    CONSTRAINT FK_Notifications_Users FOREIGN KEY (UserID) REFERENCES dbo.Users(UserID)
);
GO

