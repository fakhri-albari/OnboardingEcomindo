using Microsoft.EntityFrameworkCore;

namespace OnboardingEcomindo.Models
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }

        public DbSet<TestModel> TestModels { get; set; }
    }
}
