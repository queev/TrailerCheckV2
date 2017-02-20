using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerCheck.Models;
using Microsoft.EntityFrameworkCore;

namespace TrailerCheck.Data
{
    public class TrailerCheckContext : DbContext
    {
        public TrailerCheckContext(DbContextOptions<TrailerCheckContext> options) : base(options)
        {

        }

        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuiler)
        {
            modelBuiler.Entity<Trailer>().ToTable("Trailer");
            modelBuiler.Entity<Registration>().ToTable("Registration");
            modelBuiler.Entity<Owner>().ToTable("Owner");
        }
    }
}
