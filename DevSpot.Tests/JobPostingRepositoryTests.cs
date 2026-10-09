using DevSpot.Data;
using DevSpot.Models;
using DevSpot.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevSpot.Tests
{
    public class JobPostingRepositoryTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public JobPostingRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("JobPostingDb")
                .Options;
        }

        private ApplicationDbContext CreateDbContext() => new ApplicationDbContext(_options);

        [Fact]
        public async Task AddSync_ShouldAddJobPosting()
        {
            var db = CreateDbContext();
            var repository = new JobPostingRepository(db);

            var jobPosting = new JobPosting()
            {
                Title = "Test Title",
                Description = "Test Description",
                Company = "Test Company",
                Location = "Test Location",
                UserId = "TestUserId"
            };

            await repository.AddAsync(jobPosting);

            var result = db.JobPostings.SingleOrDefault(x => x.Title == "Test Title");

            Assert.NotNull(result);
            Assert.Equal("Test Title", result.Title);
            Assert.Equal("Test Description", result.Description);
        }
    }
}
