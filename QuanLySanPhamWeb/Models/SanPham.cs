using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLySanPhamWeb.Models
{
    public class SanPham
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string MaSP { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenSP { get; set; }
        public string LoaiSP { get; set; }
        public string MoTa { get; set; }
        public int SoLuongSP { get; set; }
        [Range(0, double.MaxValue)]
        public double GiaSP { get; set; }
       
        public int? DvtID { get; set; }
        public virtual ICollection<NhaCungCap_SanPham> NhaCungCap_SanPhams { get; set; }
    }
}
