using Entity_Layer.ComplexTypes;
using Entity_Layer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

        public DbSet<Education> Education { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<MembersEducation> MembersEducation { get; set; }
        public DbSet<Source> Source { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Trainer> Trainer{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=EducationPortal; Trusted_Connection=True;");
            }
        }
    }
}
