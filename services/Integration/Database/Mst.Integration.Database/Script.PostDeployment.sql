IF ('$(LoadTestSeedData)' = 'Y')
BEGIN
	:r .\Integration\Seed\CustomerReview.seed.data.sql
END