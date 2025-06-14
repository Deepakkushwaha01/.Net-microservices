CREATE TABLE Users (
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    CountryCode NVARCHAR(5) NOT NULL CHECK (CountryCode LIKE '+%'),
    ContactNumber NVARCHAR(15) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL UNIQUE,
    Gender NVARCHAR(10) NOT NULL CHECK (
        Gender IN ('MALE', 'FEMALE', 'OTHER')
    ), -- Assuming Gender Enum
    Role NVARCHAR(20) NOT NULL CHECK (
        Role IN ('USER', 'ADMIN')
    ), -- Assuming userRole Enum
    AccountVerified BIT NOT NULL DEFAULT 0,
    ExpiresAt DATETIME2 NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE()
);

GO
-- Optional: Index on ExpiresAt for TTL-like functionality (manual deletion)
CREATE INDEX IX_Users_ExpiresAt ON Users (ExpiresAt);

-- Optional: Trigger or scheduled job can simulate TTL by deleting rows after ExpiresAt
-- Example:
-- DELETE FROM Users WHERE ExpiresAt IS NOT NULL AND ExpiresAt < GETDATE();