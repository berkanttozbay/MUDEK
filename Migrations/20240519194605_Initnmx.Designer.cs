﻿// <auto-generated />
using MUDEK.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MUDEK.Migrations
{
    [DbContext(typeof(MudekDbContext))]
    [Migration("20240519194605_Initnmx")]
    partial class Initnmx
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MUDEK.Models.AltBaslik", b =>
                {
                    b.Property<int>("AltBaslikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AltBaslikId"));

                    b.Property<string>("AltBasliklar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DegerlendirmeId")
                        .HasColumnType("int");

                    b.HasKey("AltBaslikId");

                    b.HasIndex("DegerlendirmeId");

                    b.ToTable("AltBasliks");
                });

            modelBuilder.Entity("MUDEK.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseSemester")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descriptions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeyWords")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("MUDEK.Models.Degerlendirme", b =>
                {
                    b.Property<int>("DegerlendirmeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DegerlendirmeId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("DegerlendirmeAltBaslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DegerlendirmeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DegerlendirmeYuzde")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DegerlendirmeId");

                    b.HasIndex("CourseId");

                    b.ToTable("Degerlendirmeler");
                });

            modelBuilder.Entity("MUDEK.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("MUDEK.Models.AltBaslik", b =>
                {
                    b.HasOne("MUDEK.Models.Degerlendirme", "Degerlendirme")
                        .WithMany("AltBasliklar")
                        .HasForeignKey("DegerlendirmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Degerlendirme");
                });

            modelBuilder.Entity("MUDEK.Models.Degerlendirme", b =>
                {
                    b.HasOne("MUDEK.Models.Course", "Course")
                        .WithMany("Degerlendirmeler")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("MUDEK.Models.Course", b =>
                {
                    b.Navigation("Degerlendirmeler");
                });

            modelBuilder.Entity("MUDEK.Models.Degerlendirme", b =>
                {
                    b.Navigation("AltBasliklar");
                });
#pragma warning restore 612, 618
        }
    }
}
