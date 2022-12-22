using Microsoft.EntityFrameworkCore;
using IT4.Models;

namespace IT4.Data
{
    public class IT4DBContext : DbContext
    {
        public IT4DBContext(DbContextOptions options) : base(options)
        {
        }

        public  DbSet<Column> Column { get; set; }
        public  DbSet<DataBase> DataBase { get; set; }
        public  DbSet<Row> Row { get; set; }
        public  DbSet<Table> Table { get; set; }
    }
}
