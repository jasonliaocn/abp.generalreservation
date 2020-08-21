﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nm.Reservation.Migrations;
using Oracle.EntityFrameworkCore.Metadata;
using Volo.Abp.EntityFrameworkCore;

namespace Nm.Reservation.Migrations.Migrations
{
    [DbContext(typeof(ReservationMigrationsDbContext))]
    partial class ReservationMigrationsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("_Abp_DatabaseProvider", EfCoreDatabaseProvider.Oracle)
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("Nm.Reservation.ReservationCondition", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnName("ITEMNAME")
                        .HasColumnType("NVARCHAR2(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ItemValue")
                        .IsRequired()
                        .HasColumnName("ITEMVALUE")
                        .HasColumnType("NVARCHAR2(100)")
                        .HasMaxLength(100);

                    b.Property<int>("RCType")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RCTYPE")
                        .HasColumnType("NUMBER(10)")
                        .HasDefaultValue(1);

                    b.Property<Guid>("RMId")
                        .HasColumnName("RMID")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid?>("ReservationConditionId")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("ScriptPost")
                        .HasColumnName("SCRIPTPOST")
                        .HasColumnType("NVARCHAR2(500)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("ItemName");

                    b.HasIndex("ItemValue");

                    b.HasIndex("RMId");

                    b.HasIndex("ReservationConditionId");

                    b.ToTable("RESCONDITIONS");
                });

            modelBuilder.Entity("Nm.Reservation.ReservationManagerInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("ConcurrencyStamp")
                        .HasColumnType("NVARCHAR2(40)")
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("CreationTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnName("CreatorId")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid?>("DeleterId")
                        .HasColumnName("DeleterId")
                        .HasColumnType("RAW(16)");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("DeletionTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("ExtraProperties")
                        .HasColumnName("ExtraProperties")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("IncludeDay")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("INCLUDEDAY")
                        .HasColumnType("NUMBER(1)")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsDeleted")
                        .HasColumnType("NUMBER(1)")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("LastModificationTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnName("LastModifierId")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasColumnType("NVARCHAR2(200)")
                        .HasMaxLength(200);

                    b.Property<int>("OpenDays")
                        .HasColumnName("OPENDAYS")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("ScriptPost")
                        .HasColumnName("SCRIPTPOST")
                        .HasColumnType("NVARCHAR2(500)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("RESMANAGERINFOS");
                });

            modelBuilder.Entity("Nm.Reservation.ReservationPeriod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnName("ENDTIME")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasColumnType("NVARCHAR2(100)")
                        .HasMaxLength(100);

                    b.Property<Guid>("RCId")
                        .HasColumnName("RCID")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("ScriptPost")
                        .HasColumnName("SCRIPTPOST")
                        .HasColumnType("NVARCHAR2(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("StartTime")
                        .HasColumnName("STARTTIME")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.HasIndex("RCId");

                    b.ToTable("RESPERIOD");
                });

            modelBuilder.Entity("Nm.Reservation.ReservationCondition", b =>
                {
                    b.HasOne("Nm.Reservation.ReservationManagerInfo", null)
                        .WithMany("ReservationConditions")
                        .HasForeignKey("RMId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nm.Reservation.ReservationCondition", null)
                        .WithMany("ChildResConditions")
                        .HasForeignKey("ReservationConditionId");
                });

            modelBuilder.Entity("Nm.Reservation.ReservationPeriod", b =>
                {
                    b.HasOne("Nm.Reservation.ReservationCondition", null)
                        .WithMany("RPeriod")
                        .HasForeignKey("RCId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
