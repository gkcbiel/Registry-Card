using Cards.Models;
using Microsoft.EntityFrameworkCore;

namespace Cards.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Credit> Credit { get; set; }

        public DbSet<Logs> Log { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationTypes>().HasData(new OperationTypes[] {
                new OperationTypes{OperationTypeId=1, OperationName="Authenticate"},
                new OperationTypes{OperationTypeId=2, OperationName="Get"},
                new OperationTypes{OperationTypeId=3, OperationName="GetByCardNumber"},
                new OperationTypes{OperationTypeId=4, OperationName="Post"},
                new OperationTypes{OperationTypeId=5, OperationName="Upload"}
            });
        }
    }
}
