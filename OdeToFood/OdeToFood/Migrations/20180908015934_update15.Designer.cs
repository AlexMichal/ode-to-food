﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using OdeToFood.Data;
using System;

namespace OdeToFood.Migrations
{
    [DbContext(typeof(OdeToFoodDbContext))]
    [Migration("20180908015934_update15")]
    partial class update15
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OdeToFood.Models.CuisineType", b =>
                {
                    b.Property<int>("CuisineTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("CuisineTypeId");

                    b.ToTable("CuisineTypes","dbo");
                });

            modelBuilder.Entity("OdeToFood.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CuisineTypeId");

                    b.Property<int>("Dislikes");

                    b.Property<int>("Likes");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("RestaurantId");

                    b.HasIndex("CuisineTypeId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("OdeToFood.Models.Restaurant", b =>
                {
                    b.HasOne("OdeToFood.Models.CuisineType", "CuisineType")
                        .WithMany()
                        .HasForeignKey("CuisineTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
