INSERT INTO [Integration].[CustomerReview] (
    [Uid],
    [CustomerName],
    [ReviewText],
    [Rating],
    [CreatedOn],
    [DeletedOn],
    [CreatedBy],
    [UpdatedBy]
)
VALUES
-- ✅ Sample 1
(NEWID(), N'Ravi Sharma', N'Excellent service!', 5, GETDATE(), NULL, NULL, NULL),

-- ✅ Sample 2
(NEWID(), N'Anjali Mehta', N'Product quality is good.', 4, GETDATE(), NULL, NULL, NULL),

-- ✅ Sample 3
(NEWID(), N'Aman Gupta', N'Average experience.', 3, GETDATE(), NULL, NULL, NULL),

-- ✅ Sample 4
(NEWID(), N'Shruti Verma', N'Not satisfied with delivery.', 2, GETDATE(), NULL, NULL, NULL),

-- ✅ Sample 5
(NEWID(), N'Karan Joshi', N'Totally worth the price.', 5, GETDATE(), NULL, NULL, NULL);
