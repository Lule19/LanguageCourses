﻿// <auto-generated />
using System;
using LanguageCourses.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LanguageCourses.API.Migrations
{
    [DbContext(typeof(LanguageCoursesDbContext))]
    partial class LanguageCoursesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LanguageCourses.API.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProfessorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("LanguageCourses.API.Models.CourseUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("LanguageCourses.API.Models.Forum", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Forums");
                });

            modelBuilder.Entity("LanguageCourses.API.Models.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("LanguageCourses.API.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ForumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ForumId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("LanguageCourses.API.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("VerifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("9150584f-eb77-4a84-a13f-698a581985d8"),
                            Email = "fjovanovic284@gmail.com",
                            FirstName = "Filip",
                            LastName = "Jovanović",
                            PasswordHash = new byte[] { 192, 181, 39, 120, 168, 138, 141, 118, 147, 238, 137, 89, 178, 75, 141, 12, 44, 147, 243, 116, 156, 217, 215, 37, 157, 208, 174, 233, 103, 166, 31, 172, 87, 206, 222, 205, 220, 97, 172, 235, 28, 126, 202, 186, 14, 87, 69, 198, 41, 245, 185, 219, 133, 105, 150, 136, 3, 178, 217, 17, 124, 85, 127, 28 },
                            PasswordSalt = new byte[] { 20, 180, 206, 111, 109, 66, 100, 124, 208, 254, 50, 7, 228, 218, 106, 113, 237, 113, 240, 27, 201, 43, 118, 68, 104, 18, 122, 193, 108, 118, 247, 89, 167, 124, 172, 33, 78, 130, 45, 121, 145, 139, 152, 250, 10, 50, 15, 124, 142, 159, 5, 131, 107, 195, 251, 222, 104, 181, 66, 165, 179, 31, 163, 91, 28, 19, 184, 145, 22, 82, 108, 145, 199, 126, 104, 206, 244, 36, 141, 152, 193, 52, 80, 213, 12, 130, 172, 197, 252, 248, 61, 234, 32, 222, 36, 163, 85, 107, 122, 77, 156, 29, 200, 119, 82, 162, 79, 9, 144, 178, 50, 55, 5, 193, 242, 11, 139, 119, 234, 243, 143, 84, 52, 248, 226, 166, 80, 11 },
                            Phone = "061 755 8995",
                            Role = 2,
                            VerificationToken = "E275AB39BA88C3CDD93B29F2AFA6212FD417D8507E5B50B17EA9A57802CFE2E14498B4845183B2BAE3F05EA076130FDED55C894FC158B453EA5A5CC2167DE4C6",
                            VerifiedAt = new DateTime(2023, 12, 13, 2, 35, 31, 643, DateTimeKind.Local).AddTicks(7462)
                        });
                });

            modelBuilder.Entity("LanguageCourses.API.Models.CourseUser", b =>
                {
                    b.HasOne("LanguageCourses.API.Models.Course", "Course")
                        .WithMany("CourseUsers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanguageCourses.API.Models.User", "User")
                        .WithMany("CourseUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LanguageCourses.API.Models.Forum", b =>
                {
                    b.HasOne("LanguageCourses.API.Models.Course", "Course")
                        .WithMany("Forums")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("LanguageCourses.API.Models.Lesson", b =>
                {
                    b.HasOne("LanguageCourses.API.Models.Course", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("LanguageCourses.API.Models.Post", b =>
                {
                    b.HasOne("LanguageCourses.API.Models.Forum", "Forum")
                        .WithMany("Posts")
                        .HasForeignKey("ForumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Forum");
                });

            modelBuilder.Entity("LanguageCourses.API.Models.Course", b =>
                {
                    b.Navigation("CourseUsers");

                    b.Navigation("Forums");

                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("LanguageCourses.API.Models.Forum", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("LanguageCourses.API.Models.User", b =>
                {
                    b.Navigation("CourseUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
