using Book_Keeper_DomainModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Book_Keeper_DbContext_Layer
{
    public class DbContextLayer : DbContext 
    {
        public DbContextLayer(DbContextOptions<DbContextLayer> options) :base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
   
}