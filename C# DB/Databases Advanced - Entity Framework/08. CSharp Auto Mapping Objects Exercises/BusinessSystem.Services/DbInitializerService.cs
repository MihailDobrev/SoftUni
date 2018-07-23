namespace BusinessSystem.Services
{
    using BusinessSystem.Data;
    using Contracts;
    using Microsoft.EntityFrameworkCore;

    public class DbInitializerService : IDbInitializerService
    {
        private readonly BusinessSystemContext context;

        public DbInitializerService(BusinessSystemContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            this.context.Database.Migrate();
        }
    }
}
