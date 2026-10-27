using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class CompanyContext : DbContext
    {

        public CompanyContext(DbContextOptions<CompanyContext> options) :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ServiceProviderCompany>().HasData(
                new ServiceProviderCompany() { ServiceProviderCompanyID = 1, ServiceProviderCompanyName = "Ri-Tech", Address = "Akurdi pune", EmailId="contact@gmail.com",MobileNo="8963251456",WebsiteUrl= "https://ritechpune.com",Password="abcd"  }
                );
            modelBuilder.Entity<MainCategory>().HasData(
                new MainCategory() { MainCategoryID=1, MainCategoryName = "Electrical Services" },
                new MainCategory() { MainCategoryID = 2, MainCategoryName = "Plumbing" }
                );
            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory() { SubCategoryID=1,SubCategoryName= "Pipe Leakage Repair",MainCategoryID=1},
                new SubCategory() { SubCategoryID = 2, SubCategoryName = "Fan Installation", MainCategoryID = 2 }
                );
        }

        public DbSet<DispatchAgency> Agencyes { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderDispatch> orderDispatches { get; set; }
        public DbSet<OrderPayment> orderPayment { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<ServicePhotos> servicePhotos { get; set; }
        public DbSet<ServiceProviderCompany> serviceProvidersCompany { get; set; }
        public DbSet<SubCategory> subCategories { get; set; }
        public DbSet<User> users { get; set; }
    }

    
}
