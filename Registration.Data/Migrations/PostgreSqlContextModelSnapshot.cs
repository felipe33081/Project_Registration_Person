﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Registration.Data.Context;

#nullable disable

namespace Registration.Data.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    partial class PostgreSqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Registration.Model.Account.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CivilStatus")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("DocumentExpiration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DocumentIssuanceDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DocumentIssuer")
                        .HasColumnType("text");

                    b.Property<string>("DocumentNumber")
                        .HasColumnType("text");

                    b.Property<int?>("DocumentType")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FathersName")
                        .HasColumnType("text");

                    b.Property<int?>("Gender")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("MothersName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Nationality")
                        .HasColumnType("text");

                    b.Property<decimal?>("NetSalary")
                        .HasColumnType("numeric");

                    b.Property<string>("Occupation")
                        .HasColumnType("text");

                    b.Property<int?>("OccupationType")
                        .HasColumnType("integer");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Phone2")
                        .HasColumnType("text");

                    b.Property<string>("PlaceOfBirthCountry")
                        .HasColumnType("text");

                    b.Property<string>("PlaceOfBirthState")
                        .HasColumnType("text");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ResidenceType")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Workplace")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Registration.Model.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AddressName")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Complement")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<int?>("UF")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Registration.Model.Account.Person", b =>
                {
                    b.HasOne("Registration.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}
