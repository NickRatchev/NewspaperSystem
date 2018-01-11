﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NewspaperSystem.Data;
using System;

namespace NewspaperSystem.Data.Migrations
{
    [DbContext(typeof(NewspaperSystemDbContext))]
    [Migration("20180108163155_SetDEcimalPrecisions")]
    partial class SetDEcimalPrecisions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<int>("TownId");

                    b.Property<string>("VatNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("TownId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MachineDataId");

                    b.Property<int>("OrderId");

                    b.Property<byte>("Pairs1Color");

                    b.Property<byte>("Pairs2Color");

                    b.Property<byte>("Pairs3Color");

                    b.Property<byte>("Pairs4Color");

                    b.HasKey("Id");

                    b.HasIndex("MachineDataId");

                    b.HasIndex("OrderId");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.MachineData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BaseSpeed");

                    b.Property<byte>("M1NumberOfPages");

                    b.Property<byte>("M2NumberOfPages");

                    b.Property<byte>("NumberOfPages");

                    b.Property<byte>("ProductionFactor");

                    b.Property<int>("Web1Id");

                    b.Property<int>("Web2Id");

                    b.HasKey("Id");

                    b.HasIndex("Web1Id");

                    b.HasIndex("Web2Id");

                    b.ToTable("MachineDatas");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.MaterialConsumption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Foil")
                        .HasColumnType("decimal(16, 4)");

                    b.Property<decimal>("InkBlack")
                        .HasColumnType("decimal(16, 4)");

                    b.Property<decimal>("InkColor")
                        .HasColumnType("decimal(16, 4)");

                    b.Property<decimal>("PageHeight")
                        .HasColumnType("decimal(8, 4)");

                    b.Property<decimal>("PageWidth")
                        .HasColumnType("decimal(8, 4)");

                    b.Property<decimal>("PlateDeveloper")
                        .HasColumnType("decimal(16, 4)");

                    b.Property<decimal>("Tape")
                        .HasColumnType("decimal(16, 4)");

                    b.Property<decimal>("Wischwasser")
                        .HasColumnType("decimal(16, 4)");

                    b.HasKey("Id");

                    b.ToTable("MaterialConsumptions");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Materials.BlackInk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("SafetyMargin")
                        .HasColumnType("decimal(8, 4)");

                    b.HasKey("Id");

                    b.ToTable("BlackInks");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Materials.BlindPlate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("SafetyMargin")
                        .HasColumnType("decimal(8, 4)");

                    b.HasKey("Id");

                    b.ToTable("BlindPlates");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Materials.ColorInk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("SafetyMargin")
                        .HasColumnType("decimal(8, 4)");

                    b.HasKey("Id");

                    b.ToTable("ColorInks");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Materials.Foil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("SafetyMargin")
                        .HasColumnType("decimal(8, 4)");

                    b.HasKey("Id");

                    b.ToTable("Foils");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Materials.Paper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("PaperTypeId");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("SafetyMargin")
                        .HasColumnType("decimal(8, 4)");

                    b.HasKey("Id");

                    b.HasIndex("PaperTypeId");

                    b.ToTable("Papers");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Materials.PaperType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Grammage");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("PaperTypes");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Materials.Plate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("SafetyMargin")
                        .HasColumnType("decimal(8, 4)");

                    b.HasKey("Id");

                    b.ToTable("Plates");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Materials.PlateDeveloper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("SafetyMargin")
                        .HasColumnType("decimal(8, 4)");

                    b.HasKey("Id");

                    b.ToTable("PlateDevelopers");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Materials.Tape", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("SafetyMargin")
                        .HasColumnType("decimal(8, 4)");

                    b.HasKey("Id");

                    b.ToTable("Tapes");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Materials.Wischwasser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("SafetyMargin")
                        .HasColumnType("decimal(8, 4)");

                    b.HasKey("Id");

                    b.ToTable("Wischwassers");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(8, 4)");

                    b.Property<int>("Issue");

                    b.Property<int>("OrderCalcId");

                    b.Property<int>("PaperTypeId");

                    b.Property<int>("PrintRun");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("OrderCalcId")
                        .IsUnique();

                    b.HasIndex("PaperTypeId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.OrderCalc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("BlackInkKg")
                        .HasColumnType("decimal(16, 4)");

                    b.Property<decimal>("BlackInkPrice")
                        .HasColumnType("money");

                    b.Property<int>("Blinds");

                    b.Property<decimal>("BlindsPrice")
                        .HasColumnType("money");

                    b.Property<decimal>("ColorInksKg")
                        .HasColumnType("decimal(16, 4)");

                    b.Property<decimal>("ColorInksPrice")
                        .HasColumnType("money");

                    b.Property<decimal>("FoilKg")
                        .HasColumnType("decimal(16, 4)");

                    b.Property<decimal>("FoilPrice")
                        .HasColumnType("money");

                    b.Property<decimal>("MachineSetupPrice")
                        .HasColumnType("money");

                    b.Property<int>("OrderId");

                    b.Property<decimal>("PackingPrice")
                        .HasColumnType("money");

                    b.Property<decimal>("PaperKg")
                        .HasColumnType("decimal(16, 4)");

                    b.Property<decimal>("PaperPrice")
                        .HasColumnType("money");

                    b.Property<decimal>("PaperWasteKg")
                        .HasColumnType("decimal(16, 4)");

                    b.Property<decimal>("PaperWastePrice")
                        .HasColumnType("money");

                    b.Property<decimal>("PlateExposingPrice")
                        .HasColumnType("money");

                    b.Property<int>("Plates");

                    b.Property<decimal>("PlatesPrice")
                        .HasColumnType("money");

                    b.Property<decimal>("PrintingPrice")
                        .HasColumnType("money");

                    b.Property<decimal>("TapeMeters")
                        .HasColumnType("decimal(16, 4)");

                    b.Property<decimal>("TapePrice")
                        .HasColumnType("money");

                    b.Property<decimal>("WischwasserKg")
                        .HasColumnType("decimal(16, 4)");

                    b.Property<decimal>("WischwasserPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("OrderCalcs");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.PaperWaste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CoreWaste")
                        .HasColumnType("decimal(8, 4)");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Key1");

                    b.Property<int>("Key2");

                    b.Property<int>("Key3");

                    b.Property<int>("Key4");

                    b.Property<int>("Key5");

                    b.Property<decimal>("PrintingWaste")
                        .HasColumnType("decimal(8, 4)");

                    b.Property<decimal>("Value1")
                        .HasColumnType("decimal(8, 4)");

                    b.Property<decimal>("Value2")
                        .HasColumnType("decimal(8, 4)");

                    b.Property<decimal>("Value3")
                        .HasColumnType("decimal(8, 4)");

                    b.Property<decimal>("Value4")
                        .HasColumnType("decimal(8, 4)");

                    b.Property<decimal>("Value5")
                        .HasColumnType("decimal(8, 4)");

                    b.HasKey("Id");

                    b.ToTable("PaperWastes");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<decimal>("DefaultDiscount");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.ServicePrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Impression")
                        .HasColumnType("money");

                    b.Property<decimal>("MachineSetup")
                        .HasColumnType("money");

                    b.Property<decimal>("Packing")
                        .HasColumnType("money");

                    b.Property<decimal>("PlateExposing")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("ServicePrices");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.WebSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("WebName")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<int>("WebWidth");

                    b.HasKey("Id");

                    b.ToTable("WebSizes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NewspaperSystem.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NewspaperSystem.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NewspaperSystem.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("NewspaperSystem.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Client", b =>
                {
                    b.HasOne("NewspaperSystem.Data.Models.Town", "Town")
                        .WithMany("Clients")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Component", b =>
                {
                    b.HasOne("NewspaperSystem.Data.Models.MachineData", "MachineData")
                        .WithMany("Components")
                        .HasForeignKey("MachineDataId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NewspaperSystem.Data.Models.Order", "Order")
                        .WithMany("Components")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.MachineData", b =>
                {
                    b.HasOne("NewspaperSystem.Data.Models.WebSize", "Web1")
                        .WithMany()
                        .HasForeignKey("Web1Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NewspaperSystem.Data.Models.WebSize", "Web2")
                        .WithMany()
                        .HasForeignKey("Web2Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Materials.Paper", b =>
                {
                    b.HasOne("NewspaperSystem.Data.Models.Materials.PaperType", "PaperType")
                        .WithMany("PaperPrices")
                        .HasForeignKey("PaperTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Order", b =>
                {
                    b.HasOne("NewspaperSystem.Data.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NewspaperSystem.Data.Models.OrderCalc", "OrderCalc")
                        .WithOne("Order")
                        .HasForeignKey("NewspaperSystem.Data.Models.Order", "OrderCalcId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NewspaperSystem.Data.Models.Materials.PaperType", "PaperType")
                        .WithMany("Orders")
                        .HasForeignKey("PaperTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NewspaperSystem.Data.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewspaperSystem.Data.Models.Product", b =>
                {
                    b.HasOne("NewspaperSystem.Data.Models.Client", "Client")
                        .WithMany("Products")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}