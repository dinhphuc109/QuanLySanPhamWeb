using Microsoft.AspNetCore.Mvc;
using QuanLySanPhamWeb.Data;
using QuanLySanPhamWeb.Models;

namespace QuanLySanPhamWeb.Controllers
{
    public class DonViTinhController : Controller
    {
        private readonly AppDbContext _db;
        public DonViTinhController(AppDbContext db)
        {
            _db=db;
        }
        public IActionResult Index()
        {
            IEnumerable<DonViTinh> donViTinhsList = _db.donViTinhs;
            return View(donViTinhsList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DonViTinh obj)
        {
            if (ModelState.IsValid)
            {
                _db.donViTinhs.Add(obj);
                _db.SaveChanges();
                TempData["Thanh cong"] = "Tao Thanh Cong";
                return RedirectToAction("Index");
            }         
            return View(obj);
                
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var DonViTinhFromDb = _db.donViTinhs.Find(id);
            if (DonViTinhFromDb == null)
            {
                return NotFound();
            }
            return View(DonViTinhFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DonViTinh obj)
        {
            if (ModelState.IsValid)
            {
                _db.donViTinhs.Update(obj);
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
            var DonViTinhFromDb = _db.donViTinhs.Find(id);
            if (DonViTinhFromDb == null)
            {
                return NotFound();
            }
            return View(DonViTinhFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.donViTinhs.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.donViTinhs.Remove(obj);
                _db.SaveChanges();
            TempData["Thanh cong"] = "Xoa Thanh Cong";
            return RedirectToAction("Index");
            

        }
    }
}
