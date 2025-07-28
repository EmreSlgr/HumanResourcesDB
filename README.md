-- Veritabanı oluşturma
IF DB_ID('HumanResourcesDB') IS NULL
BEGIN
    CREATE DATABASE HumanResourcesDB;
END;
GO

USE HumanResourcesDB;
GO

-- Departments
CREATE TABLE Departments (
    DepartmentID INT NOT NULL PRIMARY KEY,
    DepartmentName NVARCHAR(100) NOT NULL
);
GO

-- Roles
CREATE TABLE Roles (
    RoleID INT NOT NULL PRIMARY KEY,
    RoleName NVARCHAR(100) NOT NULL
);
GO

-- Positions
CREATE TABLE Positions (
    PositionID INT NOT NULL PRIMARY KEY,
    PositionName NVARCHAR(100) NOT NULL,
    DepartmentID INT NOT NULL,
    CONSTRAINT FK_Positions_Departments FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);
GO

-- Employees
CREATE TABLE Employees (
    EmployeeID INT NOT NULL PRIMARY KEY,
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
    CONSTRAINT FK_Employees_Departments FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
    CONSTRAINT FK_Employees_Positions FOREIGN KEY (PositionID) REFERENCES Positions(PositionID)
    -- UserID foreign key eklenecek, ancak Users tablosu henüz oluşturulmadı (aşağıda oluşturuluyor)
);
GO

-- Users
CREATE TABLE Users (
    UserID INT NOT NULL PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    PasswordHash NVARCHAR(256) NOT NULL,
    Email NVARCHAR(100) NULL,
    IsActive BIT NOT NULL,
    CreatedAt DATETIME NOT NULL,
    RoleID INT NULL,
    EmployeeID INT NULL,
    CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleID) REFERENCES Roles(RoleID),
    CONSTRAINT FK_Users_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);
GO

-- Şimdi Employees tablosundaki UserID için foreign key ekliyoruz:
ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Users FOREIGN KEY (UserID) REFERENCES Users(UserID);
GO

-- EmployeeAbsences
CREATE TABLE EmployeeAbsences (
    AbsenceID INT NOT NULL PRIMARY KEY,
    EmployeeID INT NOT NULL,
    AbsenceDate DATE NOT NULL,
    Reason NVARCHAR(250) NULL,
    Status NVARCHAR(20) NOT NULL,
    ReportedDate DATETIME NOT NULL,
    CONSTRAINT FK_EmployeeAbsences_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);
GO

-- EmployeeDocuments
CREATE TABLE EmployeeDocuments (
    DocumentID INT NOT NULL PRIMARY KEY,
    EmployeeID INT NOT NULL,
    DocumentName NVARCHAR(255) NOT NULL,
    DocumentType NVARCHAR(100) NOT NULL,
    DocumentData VARBINARY(MAX) NOT NULL,
    UploadDate DATETIME NOT NULL,
    CONSTRAINT FK_EmployeeDocuments_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);
GO

-- EmployeeLeaveRequests
CREATE TABLE EmployeeLeaveRequests (
    LeaveRequestID INT NOT NULL PRIMARY KEY,
    EmployeeID INT NOT NULL,
    LeaveTypeID INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalDays INT NOT NULL,
    Reason NVARCHAR(250) NULL,
    Status NVARCHAR(20) NOT NULL,
    RequestedDate DATETIME NOT NULL,
    ApprovedBy INT NULL,
    ApprovalDate DATETIME NULL,
    CONSTRAINT FK_EmployeeLeaveRequests_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
    CONSTRAINT FK_EmployeeLeaveRequests_LeaveTypes FOREIGN KEY (LeaveTypeID) REFERENCES LeaveTypes(LeaveTypeID),
    CONSTRAINT FK_EmployeeLeaveRequests_ApprovedBy FOREIGN KEY (ApprovedBy) REFERENCES Employees(EmployeeID)
);
GO

-- Evaluations
CREATE TABLE Evaluations (
    EvaluationID INT NOT NULL PRIMARY KEY,
    EmployeeID INT NOT NULL,
    EvaluatorID INT NOT NULL,
    Score INT NULL,
    Comment NVARCHAR(MAX) NULL,
    EvaluationDate DATE NULL,
    CONSTRAINT FK_Evaluations_Employee FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
    CONSTRAINT FK_Evaluations_Evaluator FOREIGN KEY (EvaluatorID) REFERENCES Employees(EmployeeID)
);
GO

-- LeaveRequests
CREATE TABLE LeaveRequests (
    LeaveRequestID INT NOT NULL PRIMARY KEY,
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
    CONSTRAINT FK_LeaveRequests_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
    CONSTRAINT FK_LeaveRequests_LeaveTypes FOREIGN KEY (LeaveTypeID) REFERENCES LeaveTypes(LeaveTypeID),
    CONSTRAINT FK_LeaveRequests_ApprovedBy FOREIGN KEY (ApprovedBy) REFERENCES Employees(EmployeeID)
);
GO

-- Leaves
CREATE TABLE Leaves (
    LeaveID INT NOT NULL PRIMARY KEY,
    EmployeeID INT NOT NULL,
    LeaveType NVARCHAR(50) NULL,
    StartDate DATE NULL,
    EndDate DATE NULL,
    Status NVARCHAR(20) NULL,
    ApprovedBy INT NULL,
    CONSTRAINT FK_Leaves_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
    CONSTRAINT FK_Leaves_ApprovedBy FOREIGN KEY (ApprovedBy) REFERENCES Employees(EmployeeID)
);
GO

-- LeaveTypes
CREATE TABLE LeaveTypes (
    LeaveTypeID INT NOT NULL PRIMARY KEY,
    LeaveTypeName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(250) NULL
);
GO

-- Messages
CREATE TABLE Messages (
    MessageID INT NOT NULL PRIMARY KEY,
    SenderUserID INT NULL,
    ReceiverUserID INT NULL,
    Subject NVARCHAR(100) NULL,
    Body NVARCHAR(MAX) NULL,
    IsRead BIT NULL,
    SentDate DATETIME NULL,
    CONSTRAINT FK_Messages_SenderUser FOREIGN KEY (SenderUserID) REFERENCES Users(UserID),
    CONSTRAINT FK_Messages_ReceiverUser FOREIGN KEY (ReceiverUserID) REFERENCES Users(UserID)
);
GO

-- Notifications
CREATE TABLE Notifications (
    NotificationID INT NOT NULL PRIMARY KEY,
    UserID INT NOT NULL,
    Title NVARCHAR(100) NULL,
    [Content] NVARCHAR(MAX) NULL,
    Date DATETIME NULL,
    IsRead BIT NULL,
    CONSTRAINT FK_Notifications_Users FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO

-- PerformanceDocuments
CREATE TABLE PerformanceDocuments (
    DocumentID INT NOT NULL PRIMARY KEY,
    EvaluationID INT NULL,
    DocumentName NVARCHAR(255) NULL,
    FileType NVARCHAR(50) NULL,
    FileData VARBINARY(MAX) NULL,
    UploadedDate DATETIME NULL,
    CONSTRAINT FK_PerformanceDocuments_Evaluations FOREIGN KEY (EvaluationID) REFERENCES Evaluations(EvaluationID)
);
GO

-- Trainings
CREATE TABLE Trainings (
    TrainingID INT NOT NULL PRIMARY KEY,
    EmployeeID INT NOT NULL,
    TrainingName NVARCHAR(100) NOT NULL,
    StartDate DATETIME NULL,
    EndDate DATETIME NULL,
    Status NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(500) NULL,
    CreatedDate DATETIME NOT NULL,
    UpdatedDate DATETIME NULL,
    CONSTRAINT FK_Trainings_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);
GO
