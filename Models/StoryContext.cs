using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Online_Story_Maker_Sridhar.Models
{
    public class StoryContext : DbContext
    {
        public DbSet<Story_Table> StoryTable { get; set; }

        public DbSet<Image_Table> ImageTable { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
        public override int SaveChanges()
        {
            var changeSet = ChangeTracker.Entries<Story_Table>();

            if (changeSet != null)
            {
                foreach (var modified in changeSet.Where(x => x.State == System.Data.Entity.EntityState.Added))
                {
                    modified.Entity.DateandTimeModified = DateTime.Now;
                }
               
                foreach (var modified in changeSet.Where(x => x.State == System.Data.Entity.EntityState.Modified))
                {
                    modified.Entity.DateandTimeModified = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

        public int SaveChangesforImage()
        {
            var changeSet = ChangeTracker.Entries<Image_Table>();

            if (changeSet != null)
            {
                foreach (var modified in changeSet.Where(x => x.State == System.Data.Entity.EntityState.Added))
                {
                    modified.Entity.DateofModification = DateTime.Now;
                }
                foreach (var modified in changeSet.Where(x => x.State == System.Data.Entity.EntityState.Modified))
                {
                    modified.Entity.DateofModification = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}