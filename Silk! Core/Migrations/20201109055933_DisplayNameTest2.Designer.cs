﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SilkBot;

namespace SilkBot.Migrations
{
    [DbContext(typeof(SilkDbContext))]
    [Migration("20201109055933_DisplayNameTest2")]
    partial class DisplayNameTest2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0-rc.2.20475.6");

            modelBuilder.Entity("SilkBot.Database.Models.ChangelogModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Additions")
                        .HasColumnType("text");

                    b.Property<string>("Authors")
                        .HasColumnType("text");

                    b.Property<DateTime>("ChangeTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Removals")
                        .HasColumnType("text");

                    b.Property<string>("Version")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ChangeLogs");
                });

            modelBuilder.Entity("SilkBot.Database.Models.TicketMessageHistoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<decimal>("Sender")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int?>("TicketModelId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TicketModelId");

                    b.ToTable("TicketMessageHistoryModel");
                });

            modelBuilder.Entity("SilkBot.Database.Models.TicketModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("Closed")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Opened")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Opener")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("SilkBot.Database.Models.TicketResponderModel", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("ResponderId")
                        .HasColumnType("numeric(20,0)");

                    b.ToTable("TicketResponderModel");
                });

            modelBuilder.Entity("SilkBot.Models.Ban", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("GuildId")
                        .HasColumnType("text");

                    b.Property<decimal?>("GuildId1")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<int?>("UserInfoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GuildId1");

                    b.HasIndex("UserInfoId");

                    b.ToTable("Ban");
                });

            modelBuilder.Entity("SilkBot.Models.BlackListedWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<decimal?>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Word")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.ToTable("BlackListedWord");
                });

            modelBuilder.Entity("SilkBot.Models.GuildModel", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<bool>("AutoDehoist")
                        .HasColumnType("boolean");

                    b.Property<bool>("BlacklistWords")
                        .HasColumnType("boolean");

                    b.Property<decimal>("GeneralLoggingChannel")
                        .HasColumnType("numeric(20,0)");

                    b.Property<bool>("GreetMembers")
                        .HasColumnType("boolean");

                    b.Property<decimal>("GreetingChannel")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("InfractionFormat")
                        .HasColumnType("text");

                    b.Property<bool>("LogMessageChanges")
                        .HasColumnType("boolean");

                    b.Property<bool>("LogRoleChange")
                        .HasColumnType("boolean");

                    b.Property<decimal>("MessageEditChannel")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("MuteRoleId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<bool>("WhitelistInvites")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("SilkBot.Models.SelfAssignableRole", b =>
                {
                    b.Property<decimal>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal?>("GuildModelId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("RoleId");

                    b.HasIndex("GuildModelId");

                    b.ToTable("SelfAssignableRole");
                });

            modelBuilder.Entity("SilkBot.Models.UserInfoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("Cash")
                        .HasColumnType("integer");

                    b.Property<int>("Flags")
                        .HasColumnType("integer");

                    b.Property<decimal?>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime>("LastCashIn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("UserId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SilkBot.Models.UserInfractionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<decimal>("Enforcer")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime>("InfractionTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("InfractionType")
                        .HasColumnType("integer");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserInfractionModel");
                });

            modelBuilder.Entity("SilkBot.Models.WhiteListedLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<decimal?>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.ToTable("WhiteListedLink");
                });

            modelBuilder.Entity("SilkBot.Database.Models.TicketMessageHistoryModel", b =>
                {
                    b.HasOne("SilkBot.Database.Models.TicketModel", "TicketModel")
                        .WithMany("History")
                        .HasForeignKey("TicketModelId");

                    b.Navigation("TicketModel");
                });

            modelBuilder.Entity("SilkBot.Models.Ban", b =>
                {
                    b.HasOne("SilkBot.Models.GuildModel", "Guild")
                        .WithMany("Bans")
                        .HasForeignKey("GuildId1");

                    b.HasOne("SilkBot.Models.UserInfoModel", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserInfoId");

                    b.Navigation("Guild");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("SilkBot.Models.BlackListedWord", b =>
                {
                    b.HasOne("SilkBot.Models.GuildModel", "Guild")
                        .WithMany("BlackListedWords")
                        .HasForeignKey("GuildId");

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("SilkBot.Models.SelfAssignableRole", b =>
                {
                    b.HasOne("SilkBot.Models.GuildModel", null)
                        .WithMany("SelfAssignableRoles")
                        .HasForeignKey("GuildModelId");
                });

            modelBuilder.Entity("SilkBot.Models.UserInfoModel", b =>
                {
                    b.HasOne("SilkBot.Models.GuildModel", "Guild")
                        .WithMany("DiscordUserInfos")
                        .HasForeignKey("GuildId");

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("SilkBot.Models.UserInfractionModel", b =>
                {
                    b.HasOne("SilkBot.Models.UserInfoModel", "User")
                        .WithMany("Infractions")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SilkBot.Models.WhiteListedLink", b =>
                {
                    b.HasOne("SilkBot.Models.GuildModel", "Guild")
                        .WithMany("WhiteListedLinks")
                        .HasForeignKey("GuildId");

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("SilkBot.Database.Models.TicketModel", b =>
                {
                    b.Navigation("History");
                });

            modelBuilder.Entity("SilkBot.Models.GuildModel", b =>
                {
                    b.Navigation("Bans");

                    b.Navigation("BlackListedWords");

                    b.Navigation("DiscordUserInfos");

                    b.Navigation("SelfAssignableRoles");

                    b.Navigation("WhiteListedLinks");
                });

            modelBuilder.Entity("SilkBot.Models.UserInfoModel", b =>
                {
                    b.Navigation("Infractions");
                });
#pragma warning restore 612, 618
        }
    }
}
