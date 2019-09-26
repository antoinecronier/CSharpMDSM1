using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class WebApplication1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebApplication1Context() : base("name=WebApplication1Context")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class2>()
                .HasMany<Class1>(x => x.Class1s)
                .WithMany(x => x.Class2s)
                .Map(x =>
                {
                    x.MapLeftKey("class1Id");
                    x.MapRightKey("class2Id");
                    x.ToTable("c12");
                });
        }

        public System.Data.Entity.DbSet<WebApplication1.Models.Class1> Class1 { get; set; }
        public System.Data.Entity.DbSet<WebApplication1.Models.Class2> Class2 { get; set; }
    }
}
