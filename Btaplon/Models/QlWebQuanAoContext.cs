using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Btaplon.Models;

public partial class QlWebQuanAoContext : DbContext
{
    public QlWebQuanAoContext()
    {
    }

    public QlWebQuanAoContext(DbContextOptions<QlWebQuanAoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<TAnhSp> TAnhSps { get; set; }

    public virtual DbSet<TChatlieuSp> TChatlieuSps { get; set; }

    public virtual DbSet<TChiTietHdb> TChiTietHdbs { get; set; }

    public virtual DbSet<TChiTietSp> TChiTietSps { get; set; }

    public virtual DbSet<TChucVu> TChucVus { get; set; }

    public virtual DbSet<TDacDiem> TDacDiems { get; set; }

    public virtual DbSet<THoaDonBan> THoaDonBans { get; set; }

    public virtual DbSet<TKhachHang> TKhachHangs { get; set; }

    public virtual DbSet<TKichCo> TKichCos { get; set; }

    public virtual DbSet<TLoaiSp> TLoaiSps { get; set; }

    public virtual DbSet<TMauSac> TMauSacs { get; set; }

    public virtual DbSet<TNhaCungCap> TNhaCungCaps { get; set; }

    public virtual DbSet<TNhanVien> TNhanViens { get; set; }

    public virtual DbSet<TPhieuNhap> TPhieuNhaps { get; set; }

    public virtual DbSet<TSanPham> TSanPhams { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(" Data Source=TRUONG\\TRUONG;Initial Catalog=QlWebQuanAo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.MaKh)
                .HasMaxLength(25)
                .HasColumnName("MaKH");
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");
            entity.Property(e => e.TenKh)
                .HasMaxLength(50)
                .HasColumnName("TenKH");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK_Order_tKhachHang");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.MaSp, e.OderId });

            entity.ToTable("OrderDetail");

            entity.Property(e => e.MaSp)
                .HasMaxLength(25)
                .HasColumnName("MaSP");
            entity.Property(e => e.OderId).HasColumnName("OderID");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK_OrderDetail_Order");
        });

        modelBuilder.Entity<TAnhSp>(entity =>
        {
            entity.HasKey(e => new { e.MaSp, e.TenFileAnh }).HasName("pk_tAnhSP");

            entity.ToTable("tAnhSP");

            entity.Property(e => e.MaSp)
                .HasMaxLength(25)
                .HasColumnName("MaSP");
            entity.Property(e => e.TenFileAnh).HasMaxLength(100);

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TAnhSps)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tAnhSP_tSanPham");
        });

        modelBuilder.Entity<TChatlieuSp>(entity =>
        {
            entity.HasKey(e => e.MaCl);

            entity.ToTable("tChatlieuSP");

            entity.Property(e => e.MaCl)
                .HasMaxLength(25)
                .HasColumnName("MaCL");
            entity.Property(e => e.TenCl)
                .HasMaxLength(100)
                .HasColumnName("TenCL");
        });

        modelBuilder.Entity<TChiTietHdb>(entity =>
        {
            entity.HasKey(e => new { e.SoHdb, e.MaChiTietSp });

            entity.ToTable("tChiTietHDB");

            entity.Property(e => e.SoHdb)
                .HasMaxLength(25)
                .HasColumnName("SoHDB");
            entity.Property(e => e.MaChiTietSp)
                .HasMaxLength(25)
                .HasColumnName("MaChiTietSP");

            entity.HasOne(d => d.MaChiTietSpNavigation).WithMany(p => p.TChiTietHdbs)
                .HasForeignKey(d => d.MaChiTietSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietHDB_tChiTietSP");

            entity.HasOne(d => d.SoHdbNavigation).WithMany(p => p.TChiTietHdbs)
                .HasForeignKey(d => d.SoHdb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietHDB_tHoaDonBan");
        });

        modelBuilder.Entity<TChiTietSp>(entity =>
        {
            entity.HasKey(e => e.MaChiTietSp).HasName("pk_tChiTietSP");

            entity.ToTable("tChiTietSP");

            entity.Property(e => e.MaChiTietSp)
                .HasMaxLength(25)
                .HasColumnName("MaChiTietSP");
            entity.Property(e => e.AnhDaiDien).HasMaxLength(100);
            entity.Property(e => e.MaKichCo).HasMaxLength(25);
            entity.Property(e => e.MaMauSac).HasMaxLength(25);
            entity.Property(e => e.MaSp)
                .HasMaxLength(25)
                .HasColumnName("MaSP");

            entity.HasOne(d => d.MaKichCoNavigation).WithMany(p => p.TChiTietSps)
                .HasForeignKey(d => d.MaKichCo)
                .HasConstraintName("FK_tChiTietSP_tKichCo");

            entity.HasOne(d => d.MaMauSacNavigation).WithMany(p => p.TChiTietSps)
                .HasForeignKey(d => d.MaMauSac)
                .HasConstraintName("FK_tChiTietSP_tMauSac");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TChiTietSps)
                .HasForeignKey(d => d.MaSp)
                .HasConstraintName("FK_tChiTietSP_tSanPham");
        });

        modelBuilder.Entity<TChucVu>(entity =>
        {
            entity.HasKey(e => e.MaCv).HasName("pk_tChucVu");

            entity.ToTable("tChucVu");

            entity.Property(e => e.MaCv)
                .HasMaxLength(25)
                .HasColumnName("MaCV");
            entity.Property(e => e.TenCv)
                .HasMaxLength(50)
                .HasColumnName("TenCV");
        });

        modelBuilder.Entity<TDacDiem>(entity =>
        {
            entity.HasKey(e => e.MaDd).HasName("pk_tDacDiem");

            entity.ToTable("tDacDiem");

            entity.Property(e => e.MaDd)
                .HasMaxLength(25)
                .HasColumnName("MaDD");
            entity.Property(e => e.TenDd)
                .HasMaxLength(200)
                .HasColumnName("TenDD");
        });

        modelBuilder.Entity<THoaDonBan>(entity =>
        {
            entity.HasKey(e => e.SoHdb).HasName("pk_tHoaDonBan");

            entity.ToTable("tHoaDonBan");

            entity.Property(e => e.SoHdb)
                .HasMaxLength(25)
                .HasColumnName("SoHDB");
            entity.Property(e => e.GiamGiaHd).HasColumnName("GiamGiaHD");
            entity.Property(e => e.MaKh)
                .HasMaxLength(25)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaNv)
                .HasMaxLength(25)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayLapHd)
                .HasColumnType("datetime")
                .HasColumnName("NgayLapHD");
            entity.Property(e => e.TongTienHd).HasColumnName("TongTienHD");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.THoaDonBans)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK_tHoaDonBan_tKhachHang");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.THoaDonBans)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK_tHoaDonBan_tNhanVien");
        });

        modelBuilder.Entity<TKhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("pk_tKhachHang");

            entity.ToTable("tKhachHang");

            entity.Property(e => e.MaKh)
                .HasMaxLength(25)
                .HasColumnName("MaKH");
            entity.Property(e => e.AnhDaiDien).HasMaxLength(100);
            entity.Property(e => e.DiaChi).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.GioiTinh).HasMaxLength(5);
            entity.Property(e => e.Sdt).HasColumnName("SDT");
            entity.Property(e => e.TenKh)
                .HasMaxLength(50)
                .HasColumnName("TenKH");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TKhachHangs)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK_tKhachHang_tUser");
        });

        modelBuilder.Entity<TKichCo>(entity =>
        {
            entity.HasKey(e => e.MaKichCo).HasName("pk_tKichCo");

            entity.ToTable("tKichCo");

            entity.Property(e => e.MaKichCo).HasMaxLength(25);
            entity.Property(e => e.TenKichCo).HasMaxLength(200);
        });

        modelBuilder.Entity<TLoaiSp>(entity =>
        {
            entity.HasKey(e => e.MaLoai);

            entity.ToTable("tLoaiSP");

            entity.Property(e => e.MaLoai).HasMaxLength(25);
            entity.Property(e => e.Loai).HasMaxLength(100);
        });

        modelBuilder.Entity<TMauSac>(entity =>
        {
            entity.HasKey(e => e.MaMauSac).HasName("pk_tMau");

            entity.ToTable("tMauSac");

            entity.Property(e => e.MaMauSac).HasMaxLength(25);
            entity.Property(e => e.TenMauSac).HasMaxLength(200);
        });

        modelBuilder.Entity<TNhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("pk_tNhaCungCap");

            entity.ToTable("tNhaCungCap");

            entity.Property(e => e.MaNcc)
                .HasMaxLength(25)
                .HasColumnName("MaNCC");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.Sdt).HasColumnName("SDT");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(200)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<TNhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("pk_MaNV");

            entity.ToTable("tNhanVien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(25)
                .HasColumnName("MaNV");
            entity.Property(e => e.AnhDaiDien).HasMaxLength(100);
            entity.Property(e => e.GioiTinh).HasMaxLength(5);
            entity.Property(e => e.MaCv)
                .HasMaxLength(25)
                .HasColumnName("MaCV");
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.Sdt).HasColumnName("SDT");
            entity.Property(e => e.TenNv)
                .HasMaxLength(50)
                .HasColumnName("TenNV");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");

            entity.HasOne(d => d.MaCvNavigation).WithMany(p => p.TNhanViens)
                .HasForeignKey(d => d.MaCv)
                .HasConstraintName("FK_tNhanVien_tChucVu");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TNhanViens)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK_tNhanVien_tUser");
        });

        modelBuilder.Entity<TPhieuNhap>(entity =>
        {
            entity.HasKey(e => e.SoHdn).HasName("pk_tPhieuNhap");

            entity.ToTable("tPhieuNhap");

            entity.Property(e => e.SoHdn)
                .HasMaxLength(25)
                .HasColumnName("SoHDN");
            entity.Property(e => e.MaNcc)
                .HasMaxLength(25)
                .HasColumnName("MaNCC");
            entity.Property(e => e.NgayNhap).HasColumnType("datetime");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.TPhieuNhaps)
                .HasForeignKey(d => d.MaNcc)
                .HasConstraintName("FK_tPhieuNhap_tNhaCungCap");
        });

        modelBuilder.Entity<TSanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("pk_tSanPham");

            entity.ToTable("tSanPham");

            entity.Property(e => e.MaSp)
                .HasMaxLength(25)
                .HasColumnName("MaSP");
            entity.Property(e => e.AnhDaiDien).HasMaxLength(100);
            entity.Property(e => e.MaCl)
                .HasMaxLength(25)
                .HasColumnName("MaCL");
            entity.Property(e => e.MaDd)
                .HasMaxLength(25)
                .HasColumnName("MaDD");
            entity.Property(e => e.MaLoai).HasMaxLength(25);
            entity.Property(e => e.MaNcc)
                .HasMaxLength(25)
                .HasColumnName("MaNCC");
            entity.Property(e => e.Slvote).HasColumnName("SLVote");
            entity.Property(e => e.TenSp)
                .HasMaxLength(200)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.MaClNavigation).WithMany(p => p.TSanPhams)
                .HasForeignKey(d => d.MaCl)
                .HasConstraintName("FK_tSanPham_tChatlieuSP");

            entity.HasOne(d => d.MaDdNavigation).WithMany(p => p.TSanPhams)
                .HasForeignKey(d => d.MaDd)
                .HasConstraintName("FK_tSanPham_tDacDiem");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.TSanPhams)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK_tSanPham_tLoaiSP");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.TSanPhams)
                .HasForeignKey(d => d.MaNcc)
                .HasConstraintName("FK_tSanPham_tNhaCungCap");
        });

        modelBuilder.Entity<TUser>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("tUser");

            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
