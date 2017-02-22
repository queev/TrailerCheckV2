using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TrailerCheck.Data;

namespace TrailerCheck.Migrations
{
    [DbContext(typeof(TrailerCheckContext))]
    [Migration("20170220161706_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrailerCheck.Models.Owner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("RegistrationDate");

                    b.HasKey("ID");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("TrailerCheck.Models.Registration", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OwnerID");

                    b.Property<int>("TrailerID");

                    b.HasKey("ID");

                    b.HasIndex("OwnerID");

                    b.HasIndex("TrailerID");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("TrailerCheck.Models.Trailer", b =>
                {
                    b.Property<int>("TrailerID");

                    b.Property<string>("Description");

                    b.Property<string>("Model");

                    b.HasKey("TrailerID");

                    b.ToTable("Trailer");
                });

            modelBuilder.Entity("TrailerCheck.Models.Registration", b =>
                {
                    b.HasOne("TrailerCheck.Models.Owner", "Owner")
                        .WithMany("Registrations")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrailerCheck.Models.Trailer", "Trailer")
                        .WithMany("Registrations")
                        .HasForeignKey("TrailerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
