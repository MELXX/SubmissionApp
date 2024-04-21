using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Group> Group { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<GroupPermission> GroupPermissions { get; set; }
        public DbSet<Models.Document> Documents { get; set; }
        public DbSet<UserDocument> UserDocuments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }

        public AppDbContext()
        {
                
        }
    }
}
