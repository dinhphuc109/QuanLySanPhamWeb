using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLySanPhamWeb.Models
{
    public class NhaCungCap_SanPham
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("SanPhamID")]
        public int? SanPhamID { get; set; }
        [ForeignKey("NCCID")]
        public int? NCCID { get; set; }
    }
}
