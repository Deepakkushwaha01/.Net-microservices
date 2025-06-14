IF ('$(LoadTestSeedData)' = 'Y')
BEGIN
	:r .\Integration\Seed\User.seed.data.sql
END