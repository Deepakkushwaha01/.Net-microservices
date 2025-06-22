CREATE TABLE [Integration].[CustomerReview]
(
    [Id] INT IDENTITY(1, 1) PRIMARY KEY,
    [Uid] UNIQUEIDENTIFIER NOT NULL,
    [CustomerName] NVARCHAR(100) NOT NULL,
    [ReviewText] NVARCHAR(100) NULL DEFAULT NULL,
    [Rating] INT NULL DEFAULT NULL,
    [CreatedOn] DATETIME NOT NULL,
    [DeletedOn] DATETIME NULL DEFAULT NULL,
    [CreatedBy] UNIQUEIDENTIFIER NULL,
    [UpdatedBy] UNIQUEIDENTIFIER NULL
)

GO
CREATE INDEX [IX_CustomerReview_Uid]
ON [Integration].[CustomerReview] ([Uid]);
