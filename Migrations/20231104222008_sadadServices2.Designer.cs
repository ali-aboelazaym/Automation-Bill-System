﻿// <auto-generated />
using System;
using Automation_System.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Automation_System.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231104222008_sadadServices2")]
    partial class sadadServices2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Automation_System.Entities.AccessTokenResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("errorKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isValid")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("AccessTokenResponses");
                });

            modelBuilder.Entity("Automation_System.Entities.CustomerDefaultBillingAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("country");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("fax");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("state");

                    b.Property<string>("StateCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("state_code");

                    b.Property<string>("Street2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("street2");

                    b.Property<int>("Zip")
                        .HasColumnType("int")
                        .HasColumnName("zip");

                    b.Property<int>("ZohoDataId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ZohoDataId")
                        .IsUnique();

                    b.ToTable("CustomerDefaultBillingAddresses");
                });

            modelBuilder.Entity("Automation_System.Entities.RefreshTokenResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("errorKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isValid")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokenResponses");
                });

            modelBuilder.Entity("Automation_System.Entities.ResponseAcceTok", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AccessTokenResponseId")
                        .HasColumnType("int");

                    b.Property<int>("ExpiredAfterSeconds")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccessTokenResponseId")
                        .IsUnique();

                    b.ToTable("ResponseAcceToks");
                });

            modelBuilder.Entity("Automation_System.Entities.ResponseRefTok", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RefreshTokenResponseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RefreshTokenResponseId")
                        .IsUnique();

                    b.ToTable("ResponseRefToks");
                });

            modelBuilder.Entity("Automation_System.Entities.ZohoData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("currency_code");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("customer_name");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int")
                        .HasColumnName("invoice_id");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("invoice_number");

                    b.Property<string>("InvoiceUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("invoice_url");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,8)")
                        .HasColumnName("total");

                    b.HasKey("Id");

                    b.ToTable("ZohoDatas");
                });

            modelBuilder.Entity("Automation_System.Entities.CustomerDefaultBillingAddress", b =>
                {
                    b.HasOne("Automation_System.Entities.ZohoData", null)
                        .WithOne("CustomerDefaultBillingAddress")
                        .HasForeignKey("Automation_System.Entities.CustomerDefaultBillingAddress", "ZohoDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Automation_System.Entities.ResponseAcceTok", b =>
                {
                    b.HasOne("Automation_System.Entities.AccessTokenResponse", null)
                        .WithOne("AccessToken")
                        .HasForeignKey("Automation_System.Entities.ResponseAcceTok", "AccessTokenResponseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Automation_System.Entities.ResponseRefTok", b =>
                {
                    b.HasOne("Automation_System.Entities.RefreshTokenResponse", null)
                        .WithOne("RefreshToken")
                        .HasForeignKey("Automation_System.Entities.ResponseRefTok", "RefreshTokenResponseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Automation_System.Entities.AccessTokenResponse", b =>
                {
                    b.Navigation("AccessToken")
                        .IsRequired();
                });

            modelBuilder.Entity("Automation_System.Entities.RefreshTokenResponse", b =>
                {
                    b.Navigation("RefreshToken")
                        .IsRequired();
                });

            modelBuilder.Entity("Automation_System.Entities.ZohoData", b =>
                {
                    b.Navigation("CustomerDefaultBillingAddress")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
