using Microsoft.EntityFrameworkCore;

namespace jQueryAjaxEFASPNetCore.Models
{
    public class TransactionDbContext: DbContext
    {

        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {

        }

        //table dans la base de données.
        public DbSet<TransactionModel> Transactions { get; set; }
    }
}
