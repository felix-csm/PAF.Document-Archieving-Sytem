using Integrated3M.Framework.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrated3M.Framework.Repository
{
    public class AppContext : DbContext, IDisposedTracker
    {

        public AppContext() : base("DAS")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserModule> UserModule { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleModule> RoleModule { get; set; }

        public bool IsDisposed { get; set; }
        public object Configurations { get; internal set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //UserRole
            modelBuilder.Entity<UserRole>().Ignore(p => p.StartQuarter);
            modelBuilder.Entity<UserRole>().Ignore(p => p.EndQuarter);
            modelBuilder.Entity<UserRole>().HasRequired(c => c.Role).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<UserModule>().HasRequired(c => c.Role).WithMany().WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
        protected override void Dispose(bool disposing)
        {
            IsDisposed = true;
            base.Dispose(disposing);
        }

    }
}
