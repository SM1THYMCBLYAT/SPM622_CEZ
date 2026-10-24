CREATE DATABASE HostelManagementSystem;
GO
USE HostelManagementSystem;

--TABLE GUEST
CREATE TABLE Guests(
GuestID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
FirstName VARCHAR(100) NOT NULL,
LastName VARCHAR(100) NOT NULL,
PhoneNumber INT NOT NULL,
Email VARCHAR(150) NOT NULL,
Occupancy VARCHAR(20) NOT NULL,
CONSTRAINT chk_Occupancy CHECK(Occupancy IN('Checked In','Checked Out','Pending','Cancelled'))
);

--TABLE ROOMTYPE
CREATE TABLE RoomTypes(
Type VARCHAR(100) PRIMARY KEY NOT NULL,
Capacity INT NOT NULL,
);

--TABLE ROOM
CREATE TABLE Rooms(
RoomID INT PRIMARY KEY IDENTITY(1,1),
RoomNumber INT NOT NULL,
Type VARCHAR(100) NOT NULL,
Status VARCHAR(20) NOT NULL,
FOREIGN KEY (Type) REFERENCES RoomTypes(Type),
CONSTRAINT chk_RoomStatus CHECK(Status IN('Occupid','Vacant','Unavailable','Full'))
);

--TABEL BOOKING
CREATE TABLE Bookings(
BookingID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
GuestID INT NOT NULL,
RoomID INT NOT NULL,
BookingDateStart DATE NOT NULL,
BookingDateEnd DATE NOT NULL,
CheckInDate DATE,
CheckOutDate DATE,
PaymentStatus VARCHAR (20) NOT NULL,
TotalPrice DECIMAL(10,2) NOT NULL,
FOREIGN KEY (GuestID) REFERENCES Guests(GuestID),
FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID),
CONSTRAINT chk_PaymentStatus CHECK(PaymentStatus IN('Pending','Paid','Overdue'))
);

--TABLE USER
CREATE TABLE Users(
Username VARCHAR(100) PRIMARY KEY NOT NULL,
Password VARCHAR(100) NOT NULL,
Role VARCHAR(20) NOT NULL,
CONSTRAINT chk_Role CHECK(Role IN ('Admin','Staff'))
);

--TABLE Auditlog
CREATE TABLE AuditLog(
AuditID INT PRIMARY KEY IDENTITY(1,1),
Username VARCHAR(100) NOT NULL,
RecordType VARCHAR(20) NOT NULL,
GivenID INT NOT NULL,
QueryDate DATE NOT NULL,
Details VARCHAR(500) NOT NULL,
CONSTRAINT chk_RecordType CHECK(RecordType IN('Guests','Bookings','Rooms','Archive'))
);

CREATE TABLE Archive(
ArchiveID INT PRIMARY KEY IDENTITY(1,1),
BookingID INT NOT NULL,
RoomNumber INT NOT NULL,
GuestFullName VARCHAR(150) NOT NULL,
Email VARCHAR(100) NOT NULL,
Phone VARCHAR(20) NOT NULL,
Reason VARCHAR(20) NOT NULL,
ArchiveDate DATE NOT NULL,
BookingStartDate DATE NOT NULL,
BookingEndDate DATE NOT NULL,
CheckInDate DATE NOT NULL,
CheckOutDate DATE NOT NULL,
Price DECIMAL(10,2) NOT NULL,
);