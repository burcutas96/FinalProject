﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        //Bu metot, projenin hangi veritabanı ile ilişkili olduğunu belirttiğin yer.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Burda diyoruz ki: Sql server kullanıcaz.
            //@ demek: ters slaşı (\) normal slaş algıla demek.
            //Bağlantı kuracağımız db'in bağlantısını yazıyoruz.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        //Hangi nesnemin veritabanındaki hangi nesneyle karşılık geleceğini burada kodluyoruz.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}