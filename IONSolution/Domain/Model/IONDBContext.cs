using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace IONSolution.Domain.Model
{
    public class IONDBContext : DbContext
    {

        public IONDBContext(DbContextOptions<IONDBContext> options)
       : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region seed data
            
            modelBuilder.Entity<User>().HasData(
                new User { UserName="User1",Password="Pass1",Token= "Token1" },
                new User { UserName = "User2", Password = "Pass2", Token = "Token2" },
                new User { UserName = "User3", Password = "Pass3", Token = "Token3" },
                new User { UserName = "User4", Password = "Pass4", Token = "Token4" },
                new User { UserName = "User5", Password = "Pass5", Token = "Token5" }
                );

            #endregion
        }
        public DbSet<User> Users { get; set; }

    }


}
