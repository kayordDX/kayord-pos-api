﻿// <auto-generated />
using System;
using Kayord.Pos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;

#nullable disable

namespace Kayord.Pos.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Kayord.Pos.Entities.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("Business");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Clock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OutletId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OutletId");

                    b.HasIndex("UserId");

                    b.ToTable("Clock");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int[]>("Orders")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<int?>("TableId")
                        .HasColumnType("integer");

                    b.HasKey("CustomerId");

                    b.HasIndex("TableId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Extra", b =>
                {
                    b.Property<int>("ExtraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ExtraId"));

                    b.Property<int?>("MenuItemId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OrderItemId")
                        .HasColumnType("integer");

                    b.Property<int>("PositionId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("ExtraId");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderItemId");

                    b.ToTable("Extra");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OutletId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OutletId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MenuItemId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Division")
                        .HasColumnType("integer");

                    b.Property<int>("MenuSectionId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<NpgsqlTsVector>("SearchVector")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("tsvector")
                        .HasAnnotation("Npgsql:TsVectorConfig", "english")
                        .HasAnnotation("Npgsql:TsVectorProperties", new[] { "Name", "Description" });

                    b.HasKey("MenuItemId");

                    b.HasIndex("MenuSectionId");

                    b.HasIndex("SearchVector");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("SearchVector"), "GIN");

                    b.ToTable("MenuItem");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.MenuItemOptionGroup", b =>
                {
                    b.Property<int>("OptionGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("integer");

                    b.HasKey("OptionGroupId", "MenuItemId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("MenuItemOptionGroup");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.MenuSection", b =>
                {
                    b.Property<int>("MenuSectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MenuSectionId"));

                    b.Property<int>("MenuId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.HasKey("MenuSectionId");

                    b.HasIndex("MenuId");

                    b.HasIndex("ParentId");

                    b.ToTable("MenuSection");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Option", b =>
                {
                    b.Property<int>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OptionId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OptionGroupId")
                        .HasColumnType("integer");

                    b.Property<int?>("OrderItemId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("OptionId");

                    b.HasIndex("OptionGroupId");

                    b.HasIndex("OrderItemId");

                    b.ToTable("Option");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.OptionGroup", b =>
                {
                    b.Property<int>("OptionGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OptionGroupId"));

                    b.Property<int>("MaxSelections")
                        .HasColumnType("integer");

                    b.Property<int>("MinSelections")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OptionGroupId");

                    b.ToTable("OptionGroup");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("integer");

                    b.Property<int>("TableBookingId")
                        .HasColumnType("integer");

                    b.HasKey("OrderItemId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.OrderItemExtra", b =>
                {
                    b.Property<int>("OrderItemExtraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderItemExtraId"));

                    b.Property<int>("ExtraId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderItemId")
                        .HasColumnType("integer");

                    b.HasKey("OrderItemExtraId");

                    b.ToTable("OrderItemExtra");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.OrderItemOption", b =>
                {
                    b.Property<int>("OrderItemOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderItemOptionId"));

                    b.Property<int>("OptionId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderItemId")
                        .HasColumnType("integer");

                    b.HasKey("OrderItemOptionId");

                    b.ToTable("OrderItemOption");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Outlet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BusinessId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("Outlet");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.SalesPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("OutletId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OutletId");

                    b.ToTable("SalesPeriod");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OutletId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OutletId");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TableId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SectionId")
                        .HasColumnType("integer");

                    b.HasKey("TableId");

                    b.HasIndex("SectionId");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.TableBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("BookingName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SalesPeriodId")
                        .HasColumnType("integer");

                    b.Property<int>("TableId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SalesPeriodId");

                    b.HasIndex("TableId");

                    b.HasIndex("UserId");

                    b.ToTable("TableBooking");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.TableCashUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CashUpDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OutletId")
                        .HasColumnType("integer");

                    b.Property<decimal>("SalesAmount")
                        .HasColumnType("numeric");

                    b.Property<int>("TableBookingId")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("OutletId");

                    b.HasIndex("TableBookingId");

                    b.ToTable("TableCashUp");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.TableOrder", b =>
                {
                    b.Property<int>("TableOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TableOrderId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("OrderItemId")
                        .HasColumnType("integer");

                    b.Property<int>("TableBookingId")
                        .HasColumnType("integer");

                    b.HasKey("TableOrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderItemId");

                    b.ToTable("TableOrder");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TagId"));

                    b.Property<int?>("MenuItemId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TagId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.UserOutlet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OutletId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isCurrent")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("UserOutlet");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserRoleId"));

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Clock", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.Outlet", "Outlet")
                        .WithMany()
                        .HasForeignKey("OutletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kayord.Pos.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Outlet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Customer", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.Table", null)
                        .WithMany("Customers")
                        .HasForeignKey("TableId");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Extra", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.MenuItem", null)
                        .WithMany("Extras")
                        .HasForeignKey("MenuItemId");

                    b.HasOne("Kayord.Pos.Entities.OrderItem", null)
                        .WithMany("Extras")
                        .HasForeignKey("OrderItemId");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Menu", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.Outlet", "Outlet")
                        .WithMany()
                        .HasForeignKey("OutletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Outlet");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.MenuItem", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.MenuSection", "MenuSection")
                        .WithMany("MenuItems")
                        .HasForeignKey("MenuSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuSection");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.MenuItemOptionGroup", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.MenuItem", "MenuItem")
                        .WithMany("MenuItemOptionGroups")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kayord.Pos.Entities.OptionGroup", "OptionGroup")
                        .WithMany("MenuItemOptionGroups")
                        .HasForeignKey("OptionGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("OptionGroup");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.MenuSection", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.Menu", "Menu")
                        .WithMany("MenuSections")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kayord.Pos.Entities.MenuSection", "Parent")
                        .WithMany("SubMenuSections")
                        .HasForeignKey("ParentId");

                    b.Navigation("Menu");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Option", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.OptionGroup", "OptionGroup")
                        .WithMany("Options")
                        .HasForeignKey("OptionGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kayord.Pos.Entities.OrderItem", null)
                        .WithMany("Options")
                        .HasForeignKey("OrderItemId");

                    b.Navigation("OptionGroup");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.OrderItem", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Outlet", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.Business", "Business")
                        .WithMany("Outlets")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.SalesPeriod", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.Outlet", "Outlet")
                        .WithMany()
                        .HasForeignKey("OutletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Outlet");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Section", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.Outlet", "Outlet")
                        .WithMany("Sections")
                        .HasForeignKey("OutletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Outlet");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Table", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.Section", "Section")
                        .WithMany("Tables")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.TableBooking", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.SalesPeriod", "SalesPeriod")
                        .WithMany()
                        .HasForeignKey("SalesPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kayord.Pos.Entities.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kayord.Pos.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SalesPeriod");

                    b.Navigation("Table");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.TableCashUp", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.Outlet", "Outlet")
                        .WithMany()
                        .HasForeignKey("OutletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kayord.Pos.Entities.TableBooking", "TableBooking")
                        .WithMany()
                        .HasForeignKey("TableBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Outlet");

                    b.Navigation("TableBooking");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.TableOrder", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kayord.Pos.Entities.OrderItem", "OrderItem")
                        .WithMany()
                        .HasForeignKey("OrderItemId");

                    b.Navigation("Customer");

                    b.Navigation("OrderItem");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Tag", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.MenuItem", null)
                        .WithMany("Tags")
                        .HasForeignKey("MenuItemId");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.UserRole", b =>
                {
                    b.HasOne("Kayord.Pos.Entities.Role", "Role")
                        .WithMany("UserRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kayord.Pos.Entities.User", "User")
                        .WithMany("UserRole")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Business", b =>
                {
                    b.Navigation("Outlets");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Menu", b =>
                {
                    b.Navigation("MenuSections");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.MenuItem", b =>
                {
                    b.Navigation("Extras");

                    b.Navigation("MenuItemOptionGroups");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.MenuSection", b =>
                {
                    b.Navigation("MenuItems");

                    b.Navigation("SubMenuSections");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.OptionGroup", b =>
                {
                    b.Navigation("MenuItemOptionGroups");

                    b.Navigation("Options");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.OrderItem", b =>
                {
                    b.Navigation("Extras");

                    b.Navigation("Options");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Outlet", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Role", b =>
                {
                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Section", b =>
                {
                    b.Navigation("Tables");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.Table", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("Kayord.Pos.Entities.User", b =>
                {
                    b.Navigation("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}
