﻿// <auto-generated />
using System;
using FindAFriend.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FindAFriend.Infra.Data.Migrations
{
    [DbContext(typeof(FindAFriendContext))]
    [Migration("20240221000721_ChangeAddressToValueObject")]
    partial class ChangeAddressToValueObject
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FindAFriend.Domain.Institution", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("ResponsibleName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("responsible_name");

                    b.HasKey("Id")
                        .HasName("pk_institutions");

                    b.ToTable("institutions", (string)null);
                });

            modelBuilder.Entity("FindAFriend.Domain.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("about");

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("age");

                    b.Property<int>("DependencyLevel")
                        .HasColumnType("integer")
                        .HasColumnName("dependency_level");

                    b.Property<int>("EnergyLevel")
                        .HasColumnType("integer")
                        .HasColumnName("energy_level");

                    b.Property<int>("EnvironmentSize")
                        .HasColumnType("integer")
                        .HasColumnName("environment_size");

                    b.Property<int>("Gender")
                        .HasColumnType("integer")
                        .HasColumnName("gender");

                    b.Property<Guid>("InstitutionId")
                        .HasColumnType("uuid")
                        .HasColumnName("institution_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Size")
                        .HasColumnType("integer")
                        .HasColumnName("size");

                    b.HasKey("Id")
                        .HasName("pk_pets");

                    b.HasIndex("InstitutionId")
                        .HasDatabaseName("ix_pets_institution_id");

                    b.ToTable("pets", (string)null);
                });

            modelBuilder.Entity("FindAFriend.Domain.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("PetId")
                        .HasColumnType("uuid")
                        .HasColumnName("pet_id");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("pk_photos");

                    b.HasIndex("PetId")
                        .HasDatabaseName("ix_photos_pet_id");

                    b.ToTable("photos", (string)null);
                });

            modelBuilder.Entity("FindAFriend.Domain.Institution", b =>
                {
                    b.OwnsOne("FindAFriend.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("InstitutionId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_city");

                            b1.Property<int>("Number")
                                .HasColumnType("integer")
                                .HasColumnName("address_number");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_state");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_zip_code");

                            b1.HasKey("InstitutionId");

                            b1.ToTable("institutions");

                            b1.WithOwner()
                                .HasForeignKey("InstitutionId")
                                .HasConstraintName("fk_institution_institution_id");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("FindAFriend.Domain.Pet", b =>
                {
                    b.HasOne("FindAFriend.Domain.Institution", null)
                        .WithMany("Pets")
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_pets_institutions_institution_id");
                });

            modelBuilder.Entity("FindAFriend.Domain.Photo", b =>
                {
                    b.HasOne("FindAFriend.Domain.Pet", null)
                        .WithMany("Photos")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_photos_pets_pet_id");
                });

            modelBuilder.Entity("FindAFriend.Domain.Institution", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("FindAFriend.Domain.Pet", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}