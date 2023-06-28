using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCX_Labs.Models;
using Microsoft.EntityFrameworkCore;


namespace FCX_Labs.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<User> Users { get; set; }

    }
}