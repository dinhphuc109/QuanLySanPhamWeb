using Microsoft.EntityFrameworkCore;
using QuanLySanPhamWeb.Models;

namespace QuanLySanPhamWeb.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<NhaCungCap> nhaCungCaps { get; set; }
        public DbSet<NhaCungCap_SanPham> nhaCungCap_SanPhams { get; set; }
        public DbSet<DonViTinh> donViTinhs { get; set; }
    }
}
