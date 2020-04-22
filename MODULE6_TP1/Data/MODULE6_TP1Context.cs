using MODULE6_TP1_BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MODULE6_TP1.Data
{
    public class MODULE6_TP1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MODULE6_TP1Context() : base("name=MODULE6_TP1Context")
        {
        }

        public System.Data.Entity.DbSet<MODULE6_TP1_BO.Samourai> Samourais { get; set; }
        public System.Data.Entity.DbSet<MODULE6_TP1_BO.Arme> Armes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Recordable>();
            /*modelBuilder.Entity<Samourai>().HasOptional(s => s.Arme).WithOptionalDependent();*/
        }
    }
}
