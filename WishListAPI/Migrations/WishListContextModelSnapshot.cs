﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WishListAPI.Data;

namespace WishListAPI.Migrations
{
    [DbContext(typeof(WishListContext))]
    partial class WishListContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("Relational:Sequence:.WishCartItem_hilo", "'WishCartItem_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WishListAPI.Domain.WishCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "WishCartItem_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("BuyerId");

                    b.Property<int>("EventId");

                    b.Property<string>("EventTitle")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("NumOfTickets");

                    b.Property<decimal>("TicketPrice");

                    b.Property<string>("TicketType")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("WishCartItem");
                });
#pragma warning restore 612, 618
        }
    }
}
