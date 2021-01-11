using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techno_Project.Controllers;
using Techno_Project.Models;

namespace Techno_Project.Contexts
{
    public class GenericDbContext : DbContext
    {
        public GenericDbContext()
        {

        }

        public GenericDbContext(DbContextOptions<GenericDbContext> options)
           : base(options)
        {
        }
        public virtual DbSet<FormData> FormData { get; set; }    
        public virtual DbSet<Movableitems> Movableitems { get; set; }
        public virtual DbSet<FormEmail> FormEmail { get; set; }
        public virtual DbSet<RequestStatus> RequestStatus { get; set; }
        public virtual DbSet<Authentication> Authentication { get; set; }



        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<FormData>().OwnsOne(x => x.FormId);
            //modelBuilder.Entity<FormEmail>().OwnsOne(x => x.id);
            //  modelBuilder.Entity<FormData>().HasKey(x =>  x.FormId);


        }
    }
}
