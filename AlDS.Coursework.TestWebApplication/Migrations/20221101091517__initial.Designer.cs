﻿// <auto-generated />
using System;
using AlDS.Coursework.Test.TestWebApplication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlDS.Coursework.TestWebApplication.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20221101091517__initial")]
    partial class _initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AlDS.Coursework.Board.BoardModel.Board", b =>
                {
                    b.Property<int>("BoardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BoardId"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<string>("Space")
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.Property<string>("Title")
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BoardId");

                    b.HasIndex("BoardId");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("AlDS.Coursework.Board.BoardModel.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CardId"), 1L, 1);

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<string>("Title")
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.HasKey("CardId");

                    b.HasIndex("BoardId");

                    b.HasIndex("CardId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("AlDS.Coursework.Board.BoardModel.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NoteId"), 1L, 1);

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasMaxLength(257)
                        .HasColumnType("nvarchar(257)");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateExecuted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<int?>("IdUserExecuted")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasMaxLength(1023)
                        .HasColumnType("nvarchar(1023)");

                    b.Property<string>("Title")
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.HasKey("NoteId");

                    b.HasIndex("CardId");

                    b.HasIndex("NoteId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("AlDS.Coursework.Board.RelatedTablesModel.UserBoard", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "BoardId");

                    b.HasIndex("BoardId");

                    b.ToTable("UserBoards");
                });

            modelBuilder.Entity("AlDS.Coursework.Board.UserModel.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<DateTime>("DateBirthday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.Property<string>("Firstname")
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.Property<string>("Information")
                        .HasMaxLength(253)
                        .HasColumnType("nvarchar(253)");

                    b.Property<string>("Middlename")
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.Property<string>("Name")
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.HasKey("UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AlDS.Coursework.Board.BoardModel.Card", b =>
                {
                    b.HasOne("AlDS.Coursework.Board.BoardModel.Board", "Board")
                        .WithMany("Cards")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("AlDS.Coursework.Board.BoardModel.Note", b =>
                {
                    b.HasOne("AlDS.Coursework.Board.BoardModel.Card", "Card")
                        .WithMany("Notes")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");
                });

            modelBuilder.Entity("AlDS.Coursework.Board.RelatedTablesModel.UserBoard", b =>
                {
                    b.HasOne("AlDS.Coursework.Board.BoardModel.Board", "Board")
                        .WithMany("UserBoards")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlDS.Coursework.Board.UserModel.User", "User")
                        .WithMany("UserBoards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AlDS.Coursework.Board.BoardModel.Board", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("UserBoards");
                });

            modelBuilder.Entity("AlDS.Coursework.Board.BoardModel.Card", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("AlDS.Coursework.Board.UserModel.User", b =>
                {
                    b.Navigation("UserBoards");
                });
#pragma warning restore 612, 618
        }
    }
}