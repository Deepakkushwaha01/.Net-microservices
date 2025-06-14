INSERT INTO
    Users (
        FirstName,
        LastName,
        CountryCode,
        ContactNumber,
        Email,
        Password,
        Gender,
        Role,
        AccountVerified,
        ExpiresAt,
        CreatedAt,
        UpdatedAt
    )
VALUES
    -- Verified user (no expiresAt)
    (
        'Deepak',
        'Kushwaha',
        '+91',
        '9876543210',
        'deepak@example.com',
        'hashedPassword123',
        'MALE',
        'ADMIN',
        1,
        NULL,
        GETDATE(),
        GETDATE()
    ),

-- Unverified user (expiresAt in 5 mins from creation)
(
    'Swati',
    'Verma',
    '+91',
    '9988776655',
    'swati@example.com',
    'hashedPassword456',
    'FEMALE',
    'USER',
    0,
    DATEADD(MINUTE, 5, GETDATE()),
    GETDATE(),
    GETDATE()
),

-- Another unverified user
(
    'Ravi',
    'Sharma',
    '+1',
    '1234567890',
    'ravi@example.com',
    'hashedPassword789',
    'MALE',
    'USER',
    0,
    DATEADD(MINUTE, 5, GETDATE()),
    GETDATE(),
    GETDATE()
);