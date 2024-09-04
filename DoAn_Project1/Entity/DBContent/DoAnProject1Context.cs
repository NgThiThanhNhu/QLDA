using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entity.DBContent;

public partial class DoAnProject1Context : DbContext
{
    public DoAnProject1Context(DbContextOptions<DoAnProject1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<PHANQUYEN> PHANQUYENs { get; set; }

    public virtual DbSet<PHANQUYEN_NHOMQUYEN> PHANQUYEN_NHOMQUYENs { get; set; }

    public virtual DbSet<SYS_MENU> SYS_MENUs { get; set; }

    public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }

    public virtual DbSet<VAITRO> VAITROs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PHANQUYEN>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PHANQUYEN");

            entity.Property(e => e.ControllerName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PHANQUYEN_NHOMQUYEN>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PHANQUYEN_NHOMQUYEN");

            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenGoi).HasMaxLength(500);
        });

        modelBuilder.Entity<SYS_MENU>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SYS_MENU");

            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Controller)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ControllerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenGoi).HasMaxLength(500);
        });

        modelBuilder.Entity<TAIKHOAN>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TAIKHOAN");

            entity.Property(e => e.AnhDaiDien).HasMaxLength(500);
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.HoLot).HasMaxLength(200);
            entity.Property(e => e.MatKhau).HasMaxLength(500);
            entity.Property(e => e.MatKhauSalt).HasMaxLength(100);
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua).HasMaxLength(256);
            entity.Property(e => e.NguoiTao).HasMaxLength(256);
            entity.Property(e => e.NguoiXoa).HasMaxLength(256);
            entity.Property(e => e.SoDienThoai).HasMaxLength(12);
            entity.Property(e => e.Ten).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<VAITRO>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VAITRO");

            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoSua).HasMaxLength(256);
            entity.Property(e => e.NguoiTao).HasMaxLength(256);
            entity.Property(e => e.NguoiXoa).HasMaxLength(256);
            entity.Property(e => e.TenGoi).HasMaxLength(256);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
