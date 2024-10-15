CREATE TABLE Room (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    RoomName NVARCHAR(100),
    Capacity INT
);

CREATE TABLE [User] (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(100)
);

CREATE TABLE Booking (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    RoomID INT FOREIGN KEY REFERENCES Room(RoomID),
    UserID INT FOREIGN KEY REFERENCES [User](UserID),
    BookingDate DATETIME,
    StartTime TIME,
    EndTime TIME
);

-- Add the integration tables to allow flexible support for external systems
CREATE TABLE IntegrationType (
    IntegrationTypeID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100)
);

CREATE TABLE RoomIntegration (
    RoomIntegrationID INT PRIMARY KEY IDENTITY(1,1),
    RoomID INT FOREIGN KEY REFERENCES Room(RoomID),
    IntegrationTypeID INT FOREIGN KEY REFERENCES IntegrationType(IntegrationTypeID),
    ExternalCalendarID NVARCHAR(100)
);

CREATE TABLE BookingIntegration (
    BookingIntegrationID INT PRIMARY KEY IDENTITY(1,1),
    BookingID INT FOREIGN KEY REFERENCES Booking(BookingID),
    IntegrationTypeID INT FOREIGN KEY REFERENCES IntegrationType(IntegrationTypeID),
    IsSynced BIT,
    LastSyncedDate DATETIME
);

-- Insert sample data for testing
INSERT INTO Room (RoomName, Capacity) VALUES ('Room A', 10), ('Room B', 20);
INSERT INTO [User] (UserName) VALUES ('John Doe'), ('Jane Smith');
INSERT INTO IntegrationType (Name) VALUES ('Exchange'), ('Google');
