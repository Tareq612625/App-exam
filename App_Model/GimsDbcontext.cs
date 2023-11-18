using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Model;
using App_Model.Authorization;
using App_Model.ProductInfo;
using App_Model.UseEntity;
using App_Model.PIEntity;

namespace App_Model
{
    public partial class GimsDbcontext : DbContext
    {
        public GimsDbcontext(DbContextOptions<GimsDbcontext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<PIDetails>(entity =>
            {
                //entity.HasKey(e => new { e.Id });
                //entity.HasOne(e => e.ProductMakeMaster)
                //     .WithMany()
                //     .HasForeignKey(e => e.Id)
                //     .OnDelete(DeleteBehavior.NoAction);
                //entity.HasOne(e => e.SupplierInfo)
                //      .WithMany()
                //      .HasForeignKey(e => e.Id)
                //      .OnDelete(DeleteBehavior.NoAction);
            });

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<PIMaster> PIMaster { get; set; }
        public virtual DbSet<PIDetails> PIDetails { get; set; }
        public virtual DbSet<CustomerMaster> CustomerMaster { get; set; }
        public virtual DbSet<CustomerLocation> CustomerLocation { get; set; }
        public virtual DbSet<BuyerMaster> BuyerMaster { get; set; }
        public virtual DbSet<ProductMaster> ProductMaster { get; set; }



    }
}
