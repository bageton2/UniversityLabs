﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Practice5EF;

namespace Practice5EF.Migrations
{
    [DbContext(typeof(ProductionDBContext))]
    [Migration("20191127163731_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Practice5EF.Models.Product", b =>
                {
                    b.Property<Guid>("ProductGID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Cost");

                    b.Property<string>("Name");

                    b.Property<Guid?>("ProductCategoryGID");

                    b.HasKey("ProductGID");

                    b.HasIndex("ProductCategoryGID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Practice5EF.Models.ProductCategory", b =>
                {
                    b.Property<Guid>("ProductCategoryGID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caption");

                    b.HasKey("ProductCategoryGID");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Practice5EF.Models.ProductToProvider", b =>
                {
                    b.Property<Guid>("ProductToProviderGID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ProductGID");

                    b.Property<Guid?>("ProviderGID");

                    b.HasKey("ProductToProviderGID");

                    b.HasIndex("ProductGID");

                    b.HasIndex("ProviderGID");

                    b.ToTable("ProductsToProviders");
                });

            modelBuilder.Entity("Practice5EF.Models.Provider", b =>
                {
                    b.Property<Guid>("ProviderGID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ProviderGID");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("Practice5EF.Models.Product", b =>
                {
                    b.HasOne("Practice5EF.Models.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryGID");
                });

            modelBuilder.Entity("Practice5EF.Models.ProductToProvider", b =>
                {
                    b.HasOne("Practice5EF.Models.Product", "Product")
                        .WithMany("ProductsProviders")
                        .HasForeignKey("ProductGID");

                    b.HasOne("Practice5EF.Models.Provider", "Provider")
                        .WithMany("ProductsProviders")
                        .HasForeignKey("ProviderGID");
                });
#pragma warning restore 612, 618
        }
    }
}
