using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamFourA.Models;
using Microsoft.EntityFrameworkCore;

namespace TeamFourA.Db
{
    public class ShoppingContext:DbContext
    {
        protected IConfiguration configuration;

        public ShoppingContext(DbContextOptions<ShoppingContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            //shermaine - add index for username for sql
            // unique name within a column
            model.Entity<User>().HasIndex(tbl => tbl.Username).IsUnique();


            //shermaine- make productID in running number order
            model.Entity<Product>()
                .Property(o => o.Id)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.Product_seq");

            model.HasSequence<int>("Product_seq", schema: "dbo")
                .StartsAt(1)
                .IncrementsBy(1);


            model.Entity<Transaction>()
                .Property(p => p.Id)
                .ValueGeneratedNever();

            model.Entity<TransactionDetail>()
                .Property(p => p.Id)
                .ValueGeneratedNever();

            model.Entity<Transaction>()
                .HasMany(p => p.TransactionDetail)
                .WithOne(p => p.Transaction)
                .HasForeignKey(p => p.TransactionId);

            model.Entity<TransactionDetail>()
                .HasMany(p => p.ActivationCodes)
                .WithOne(a => a.TransactionDetail)
                .HasForeignKey(a => a.TransactionDetailId);

            model.Entity<TransactionDetail>()
                .HasOne(p => p.Product)
                .WithMany(p => p.TransactionDetails)
                .HasForeignKey(p => p.ProductId);

            model.Entity<User>()
                .HasMany(u => u.Transactions)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<ActivationCode> ActivationCodes { get; set; }
    }     
 }
