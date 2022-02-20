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
        public DbSet<Gender> Gender { get; set; }
        public DbSet<CougYear> CougYear { get; set; }
        public DbSet<CougCourse> CougCourse { get; set; }
        public DbSet<Coug> Coug { get; set; }
        public DbSet<CougProgram> CougProgram { get; set; }
        public DbSet<CougProgramRegistration> CougProgramRegistrations { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
    }
}
