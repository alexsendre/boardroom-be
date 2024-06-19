﻿// <auto-generated />
using System;
using BoardRoom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BoardRoom.Migrations
{
    [DbContext(typeof(BoardRoomDbContext))]
    [Migration("20240619003605_UserOrders")]
    partial class UserOrders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BoardRoom.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.Property<int>("SellerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://i.pcmag.com/imagery/reviews/05mQGIDQOTCx8qyj5vd3S8t-1.fit_lim.size_840x473.v1695825614.jpg",
                            Name = "Monitor",
                            Price = 159.99m,
                            RoomId = 1,
                            SellerId = 1
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "https://images.stockx.com/images/FaZe-x-Murakami-Mousepad-Black.jpg?fit=fill&bg=FFFFFF&w=700&h=500&fm=webp&auto=compress&q=90&dpr=2&trim=color&updated_at=1637778655",
                            Name = "Deskpad",
                            Price = 19.99m,
                            RoomId = 2,
                            SellerId = 2
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "https://m.media-amazon.com/images/I/81Y5x1jljBL._AC_UF1000,1000_QL80_.jpg",
                            Name = "Couch",
                            Price = 349.99m,
                            RoomId = 3,
                            SellerId = 3
                        });
                });

            modelBuilder.Entity("BoardRoom.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("boolean");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Total")
                        .HasColumnType("numeric");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "3939 Coco Mel",
                            City = "Candy",
                            IsClosed = true,
                            PaymentTypeId = 1,
                            State = "AK",
                            Total = 0m,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "333 Angel Ln",
                            City = "Brite",
                            IsClosed = true,
                            PaymentTypeId = 2,
                            State = "TX",
                            Total = 0m,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Address = "1 W North St",
                            City = "Harara",
                            IsClosed = false,
                            PaymentTypeId = 3,
                            State = "CA",
                            Total = 0m,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("BoardRoom.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Label = "Debit/Credit Card"
                        },
                        new
                        {
                            Id = 2,
                            Label = "Cash"
                        },
                        new
                        {
                            Id = 3,
                            Label = "PayPal"
                        },
                        new
                        {
                            Id = 4,
                            Label = "Klarna"
                        });
                });

            modelBuilder.Entity("BoardRoom.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("SellerId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "this is a nice description for room 1!",
                            ImageUrl = "https://i.pinimg.com/564x/59/fb/79/59fb7976ceae747a206a79a426093824.jpg",
                            Location = "Lexington, KY",
                            SellerId = 1,
                            Title = "Room 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "this is a nice description for room 2!",
                            ImageUrl = "https://i.pinimg.com/564x/c5/f7/78/c5f7782a1e831c2d2f481404f39a3588.jpg",
                            Location = "Nashville, TN",
                            SellerId = 2,
                            Title = "Room 2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "this is a nice description for room 3!",
                            ImageUrl = "https://i.pinimg.com/564x/70/28/82/702882477d62e948ae11f3f73cce3a66.jpg",
                            Location = "Houston, TX",
                            SellerId = 3,
                            Title = "Room 3"
                        });
                });

            modelBuilder.Entity("BoardRoom.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Label = "Gaming"
                        },
                        new
                        {
                            Id = 2,
                            Label = "Minimalist"
                        },
                        new
                        {
                            Id = 3,
                            Label = "Workspace"
                        },
                        new
                        {
                            Id = 4,
                            Label = "Quirky"
                        });
                });

            modelBuilder.Entity("BoardRoom.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<bool>("IsSeller")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RoomId")
                        .HasColumnType("integer");

                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "hello! my bio",
                            Email = "jordancarter@test.com",
                            FirstName = "Jordan",
                            ImageUrl = "https://cdns-images.dzcdn.net/images/artist/16cc4a271b96586a46c35d8182412e92/1900x1900-000000-80-0-0.jpg",
                            IsSeller = false,
                            LastName = "Carter",
                            Uid = "uid1",
                            Username = "jordancarter"
                        },
                        new
                        {
                            Id = 2,
                            Bio = "hello! my bio",
                            Email = "postmalone@gmail.com",
                            FirstName = "Austin",
                            ImageUrl = "https://m.media-amazon.com/images/M/MV5BODg4N2I0NmEtNTIyMS00MzVjLThjYzgtODAwMzcwYThkMTVkXkEyXkFqcGdeQXVyMTI2Nzk3NzI4._V1_FMjpg_UX1000_.jpg",
                            IsSeller = false,
                            LastName = "Post",
                            Uid = "uid1",
                            Username = "testcase"
                        },
                        new
                        {
                            Id = 3,
                            Bio = "hello! my bio",
                            Email = "jenjo@gmail.com",
                            FirstName = "Jen",
                            ImageUrl = "https://imageio.forbes.com/specials-images/imageserve/1189837141/2019-American-Music-Awards---Red-Carpet/960x0.jpg?format=jpg&width=960",
                            IsSeller = false,
                            LastName = "Jones",
                            Uid = "uid1",
                            Username = "fishtank"
                        });
                });

            modelBuilder.Entity("ItemOrder", b =>
                {
                    b.Property<int>("ItemsId")
                        .HasColumnType("integer");

                    b.Property<int>("OrdersId")
                        .HasColumnType("integer");

                    b.HasKey("ItemsId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("ItemOrder");
                });

            modelBuilder.Entity("ItemRoom", b =>
                {
                    b.Property<int>("ItemsId")
                        .HasColumnType("integer");

                    b.Property<int>("RoomsId")
                        .HasColumnType("integer");

                    b.HasKey("ItemsId", "RoomsId");

                    b.HasIndex("RoomsId");

                    b.ToTable("ItemRoom");
                });

            modelBuilder.Entity("OrderUser", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("OrdersId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("OrderUser");
                });

            modelBuilder.Entity("RoomTag", b =>
                {
                    b.Property<int>("RoomsId")
                        .HasColumnType("integer");

                    b.Property<int>("TagsId")
                        .HasColumnType("integer");

                    b.HasKey("RoomsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("RoomTag");
                });

            modelBuilder.Entity("BoardRoom.Models.Room", b =>
                {
                    b.HasOne("BoardRoom.Models.Order", null)
                        .WithMany("Rooms")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("BoardRoom.Models.User", b =>
                {
                    b.HasOne("BoardRoom.Models.Room", null)
                        .WithMany("Users")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("ItemOrder", b =>
                {
                    b.HasOne("BoardRoom.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardRoom.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ItemRoom", b =>
                {
                    b.HasOne("BoardRoom.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardRoom.Models.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderUser", b =>
                {
                    b.HasOne("BoardRoom.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardRoom.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoomTag", b =>
                {
                    b.HasOne("BoardRoom.Models.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardRoom.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BoardRoom.Models.Order", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("BoardRoom.Models.Room", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}