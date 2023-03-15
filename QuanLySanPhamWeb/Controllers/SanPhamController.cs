using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuanLySanPhamWeb.Data;
using QuanLySanPhamWeb.Models;

namespace QuanLySanPhamWeb.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly AppDbContext _db;
        public SanPhamController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<SanPham> sanPhamsList = _db.sanPhams;
            return View(sanPhamsList);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SanPham obj)
        {
            if (ModelState.IsValid)
            {
                //SanPham donViTinh = new SanPham();
                //List<SelectListItem> donViTinhs = _db.donViTinhs.OrderBy(n => n.ID).Select(n => new SelectListItem
                //{
                //    Value = n.DVTinh,
                //    Text = n.DVTinh
                //}).ToList();
                //donViTinh.DvtID = donViTinhs;
                _db.sanPhams.Add(obj);
                _db.SaveChanges();
                TempData["Thanh cong"] = "Tao Thanh Cong";
                return RedirectToAction("Index");
            }
            ViewBag.DonViTinh = new SelectList(new List<DonViTinh>());
            return View(obj);

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SanPhamFromDb = _db.sanPhams.Find(id);
            if (SanPhamFromDb == null)
            {
                return NotFound();
            }
            return View(SanPhamFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SanPham obj)
        {
            if (ModelState.IsValid)
            {
                _db.sanPhams.Update(obj);
                _db.SaveChanges();
                TempData["Thanh cong"] = "Sua Thanh Cong";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var SanPhamFromDb = _db.sanPhams.Find(id);
            if (SanPhamFromDb == null)
            {
                return NotFound();
            }
            return View(SanPhamFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.sanPhams.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.sanPhams.Remove(obj);
            _db.SaveChanges();
            TempData["Thanh cong"] = "Xoa Thanh Cong";
            return RedirectToAction("Index");

        }

    }
}
