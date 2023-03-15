using System.ComponentModel.DataAnnotations;

namespace QuanLySanPhamWeb.Models
{
    public class NhaCungCap
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public virtual ICollection<NhaCungCap_SanPham> NhaCungCap_SanPhams { get; set; }
    }
}
