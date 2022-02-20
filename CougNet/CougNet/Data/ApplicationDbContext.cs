using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CougModels;

namespace CougNet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CougModels.Gender> Gender { get; set; }
        public DbSet<CougModels.CougYear> CougYear { get; set; }
        public DbSet<CougModels.CougCourse> CougCourse { get; set; }
        public DbSet<CougModels.Coug> Coug { get; set; }
        public DbSet<CougModels.CougProgram> CougProgram { get; set; }
    }
}
