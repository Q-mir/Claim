﻿using Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Connection : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        public Connection(DbContextOptions<Connection> options) : base(options) { }
    }
}
