using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFOperation.DbModels;

namespace EFOperation
{
    public class DataContext : DbContext
    {
        public virtual DbSet<DbData> DbData { get; set; }

        public DataContext() : base("DataContext")
        {
            this.Database.Connection.ConnectionString = "Data Source=.;Initial Catalog=EFOperation;MultipleActiveResultSets=True;User ID=netcore;Password=netcore";
        }
    }
}
