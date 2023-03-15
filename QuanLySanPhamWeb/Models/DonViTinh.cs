using System.ComponentModel.DataAnnotations;

namespace QuanLySanPhamWeb.Models
{
    public class DonViTinh
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string MaDVT { get; set; }
        [Required]
        [MaxLength(100)]
        public string DVTinh { get; set; }

    }
}
