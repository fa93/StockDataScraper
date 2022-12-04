﻿// <auto-generated />
using DataScraper.Main.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataScraper.Worker.Migrations
{
    [DbContext(typeof(DseDbContext))]
    partial class DseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataScraper.Main.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TradeCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("DataScraper.Main.Entities.StockPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Change")
                        .HasColumnType("float");

                    b.Property<double>("ClosePrice")
                        .HasColumnType("float");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<double>("High")
                        .HasColumnType("float");

                    b.Property<double>("LastTradingPrice")
                        .HasColumnType("float");

                    b.Property<double>("Low")
                        .HasColumnType("float");

                    b.Property<int>("Trade")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.Property<double>("Volume")
                        .HasColumnType("float");

                    b.Property<double>("YesterdayClosePrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("StockPrices");
                });

            modelBuilder.Entity("DataScraper.Main.Entities.StockPrice", b =>
                {
                    b.HasOne("DataScraper.Main.Entities.Company", "Company")
                        .WithMany("StockPrices")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("DataScraper.Main.Entities.Company", b =>
                {
                    b.Navigation("StockPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
