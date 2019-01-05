﻿// <auto-generated />
using System;
using LisbonDB47.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LisbonDB47.Migrations
{
    [DbContext(typeof(LisbonDbContext))]
    partial class LisbonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("LisbonDB47.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateEdited");

                    b.Property<int>("PoiID");

                    b.Property<int>("UserID");

                    b.HasKey("CommentID");

                    b.HasIndex("PoiID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("LisbonDB47.Models.Image", b =>
                {
                    b.Property<int>("ImageID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<byte[]>("ImageData");

                    b.Property<bool>("Private");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.Property<int>("UserPoiID");

                    b.HasKey("ImageID");

                    b.HasIndex("UserPoiID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("LisbonDB47.Models.Like", b =>
                {
                    b.Property<int>("LikeID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("PoiID");

                    b.Property<int>("UserID");

                    b.HasKey("LikeID");

                    b.HasIndex("PoiID");

                    b.HasIndex("UserID");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("LisbonDB47.Models.Path", b =>
                {
                    b.Property<int>("PathID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateEdited");

                    b.Property<string>("Title");

                    b.Property<int>("UserID");

                    b.HasKey("PathID");

                    b.HasIndex("UserID");

                    b.ToTable("Paths");
                });

            modelBuilder.Entity("LisbonDB47.Models.PathPoi", b =>
                {
                    b.Property<int>("PathPoiID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("PathID");

                    b.Property<int>("PoiID");

                    b.HasKey("PathPoiID");

                    b.HasIndex("PathID");

                    b.HasIndex("PoiID");

                    b.ToTable("PathPois");
                });

            modelBuilder.Entity("LisbonDB47.Models.Poi", b =>
                {
                    b.Property<int>("PoiID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Title");

                    b.HasKey("PoiID");

                    b.ToTable("Pois");
                });

            modelBuilder.Entity("LisbonDB47.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Mail");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LisbonDB47.Models.UserPoi", b =>
                {
                    b.Property<int>("UserPoiID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("PoiID");

                    b.Property<bool>("Private");

                    b.Property<int>("UserID");

                    b.HasKey("UserPoiID");

                    b.HasIndex("PoiID");

                    b.HasIndex("UserID");

                    b.ToTable("UserPois");
                });

            modelBuilder.Entity("LisbonDB47.Models.Comment", b =>
                {
                    b.HasOne("LisbonDB47.Models.Poi", "Poi")
                        .WithMany("Comments")
                        .HasForeignKey("PoiID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LisbonDB47.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LisbonDB47.Models.Image", b =>
                {
                    b.HasOne("LisbonDB47.Models.UserPoi", "UserPoi")
                        .WithMany("Images")
                        .HasForeignKey("UserPoiID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LisbonDB47.Models.Like", b =>
                {
                    b.HasOne("LisbonDB47.Models.Poi", "Poi")
                        .WithMany("Likes")
                        .HasForeignKey("PoiID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LisbonDB47.Models.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LisbonDB47.Models.Path", b =>
                {
                    b.HasOne("LisbonDB47.Models.User", "User")
                        .WithMany("Paths")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LisbonDB47.Models.PathPoi", b =>
                {
                    b.HasOne("LisbonDB47.Models.Path", "Path")
                        .WithMany("PathPois")
                        .HasForeignKey("PathID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LisbonDB47.Models.Poi", "Poi")
                        .WithMany("PathPois")
                        .HasForeignKey("PoiID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LisbonDB47.Models.UserPoi", b =>
                {
                    b.HasOne("LisbonDB47.Models.Poi", "Poi")
                        .WithMany("UserPois")
                        .HasForeignKey("PoiID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LisbonDB47.Models.User", "User")
                        .WithMany("UserPois")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
