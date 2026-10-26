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
CONSTRAINT chk_RoomStatus CHECK(Status IN('Occupied','Vacant','Unavailable','Full'))
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
Price DECIMAL (10,2) NOT NULL,
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

--added table data (10 Guests, 30 rooms, 3 roomtypes and 4 users (2 admin, 2 staff))
-- ROOM TYPES
INSERT INTO RoomTypes (Type, Capacity)
VALUES
('Single', 1),
('Double', 2),
('Triple', 3);


-- ROOMS
INSERT INTO Rooms (RoomNumber, Type, Status)
VALUES
(101, 'Single', 'Vacant'),
(102, 'Single', 'Vacant'),
(103, 'Single', 'Occupied'),
(104, 'Single', 'Vacant'),
(105, 'Single', 'Unavailable'),
(106, 'Single', 'Vacant'),
(107, 'Single', 'Occupied'),
(108, 'Single', 'Vacant'),
(109, 'Single', 'Vacant'),
(110, 'Single', 'Occupied'),

(201, 'Double', 'Vacant'),
(202, 'Double', 'Vacant'),
(203, 'Double', 'Occupied'),
(204, 'Double', 'Vacant'),
(205, 'Double', 'Full'),
(206, 'Double', 'Vacant'),
(207, 'Double', 'Occupied'),
(208, 'Double', 'Vacant'),
(209, 'Double', 'Vacant'),
(210, 'Double', 'Unavailable'),

(301, 'Triple', 'Vacant'),
(302, 'Triple', 'Vacant'),
(303, 'Triple', 'Occupied'),
(304, 'Triple', 'Vacant'),
(305, 'Triple', 'Vacant'),
(306, 'Triple', 'Occupied'),
(307, 'Triple', 'Vacant'),
(308, 'Triple', 'Vacant'),
(309, 'Triple', 'Unavailable'),
(310, 'Triple', 'Vacant');


-- GUESTS
INSERT INTO Guests
(FirstName, LastName, PhoneNumber, Email, Occupancy)
VALUES
('John', 'Smith', 721111111, 'john.smith@email.com', 'Checked In'),
('Sarah', 'Jones', 722222222, 'sarah.jones@email.com', 'Checked In'),
('Michael', 'Brown', 723333333, 'michael.brown@email.com', 'Pending'),
('Emma', 'Wilson', 724444444, 'emma.wilson@email.com', 'Checked Out'),
('David', 'Taylor', 725555555, 'david.taylor@email.com', 'Checked In'),
('Lisa', 'Johnson', 726666666, 'lisa.johnson@email.com', 'Pending'),
('Peter', 'Williams', 727777777, 'peter.williams@email.com', 'Checked In'),
('Amy', 'Davis', 728888888, 'amy.davis@email.com', 'Cancelled'),
('Brian', 'Miller', 729999999, 'brian.miller@email.com', 'Checked Out'),
('Sophie', 'Anderson', 721234567, 'sophie.anderson@email.com', 'Checked In');

-- USERS
-- 2 Admins, 2 Staff
INSERT INTO Users
(Username, Password, Role)
VALUES
('admin01', '3b612c75a7b5048a435fb6ec81e52ff92d6d795a8b5a9c17070f6a63c97a53b2', 'Admin'),
('admin02', '3b0b01e1e1f2fee1bd464ded0ecb23d0b11f4e85c8942a08cec242f182f46bdb', 'Admin'),
('staff01', '2f005e42a17da46ec51ba6f11d725e60788931a1dadd33d9cb85084fb32bb166', 'Staff'),
('staff02', 'cdc4d189f8469bf67d5c5d2137221b8712e04c29415bb67df0b7e8d347694ef2', 'Staff');


-- BOOKINGS (price R150)
INSERT INTO Bookings
(GuestID, RoomID, BookingDateStart, BookingDateEnd,
 CheckInDate, CheckOutDate, PaymentStatus, TotalPrice,Price)
VALUES
(1, 3, '2026-11-01', '2026-12-05', '2026-11-01', NULL, 'Paid', 0.00,0.00),
(2, 13, '2026-11-03', '2026-11-08', '2026-11-03', NULL, 'Paid', 0.00,0.00),
(3, 21, '2026-11-10', '2026-11-25', NULL, NULL, 'Pending', 0.00,0.00),
(4, 7, '2026-10-01', '2026-10-05', '2026-10-01', '2026-10-05', 'Paid', 0.00,0.00),
(5, 15, '2026-11-12', '2026-11-20', '2026-11-12', NULL, 'Pending', 0.00,0.00),
(6, 24, '2026-11-15', '2026-11-18', NULL, NULL, 'Pending', 0.00,0.00),
(7, 23, '2026-11-02', '2026-11-10', '2026-11-02', NULL, 'Paid', 0.00,0.00),
(8, 30, '2026-12-01', '2027-02-12', NULL, NULL, 'Pending', 0.00,0.00),
(9, 17, '2026-10-10', '2026-10-14', '2026-10-10', '2026-10-14', 'Paid', 0.00,0.00),
(10, 5, '2026-11-20', '2026-12-30', '2026-11-20', NULL, 'Pending', 0.00,0.00);
