﻿// <auto-generated />
using System.Collections.Generic;
using BackEndForJawla1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackEndForJawla1.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("busNetwork")
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BackEndForJawla1.Models.bucketInfo", b =>
                {
                    b.Property<string>("routeID")
                        .HasColumnType("text");

                    b.Property<List<int>>("nodesInBucket")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<int>("numBuckets")
                        .HasColumnType("integer");

                    b.HasKey("routeID");

                    b.ToTable("bucketInfo", "busNetwork");
                });

            modelBuilder.Entity("BackEndForJawla1.Models.busRouteStop", b =>
                {
                    b.Property<string>("routeID")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("StopID")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("StopOrder")
                        .HasColumnType("integer");

                    b.HasKey("routeID");

                    b.ToTable("stopsgeojson", "busNetwork");
                });

            modelBuilder.Entity("BackEndForJawla1.Models.routes", b =>
                {
                    b.Property<string>("routeID")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("routeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("routeID");

                    b.ToTable("routes", "busNetwork");
                });

            modelBuilder.Entity("BackEndForJawla1.Models.user", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("userId"));

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("userId");

                    b.ToTable("user", "busNetwork");
                });
#pragma warning restore 612, 618
        }
    }
}
