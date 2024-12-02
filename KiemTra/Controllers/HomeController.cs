using KiemTra.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace KiemTra.Controllers
{
	public class HomeController : Controller
	{
		QlgiaiBongDaContext db = new QlgiaiBongDaContext();
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			String caulacboid = "101";
			var lstCauthu = db.Cauthus.Where(x => x.CauLacBoId == caulacboid).ToList();
			return View(lstCauthu);
		}
        [Route("SuaCauThu")]
        [HttpGet]
        public IActionResult SuaCauThu(String cauthuid)
        {
            ViewBag.CauLacBoId = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");
            var cauthu = db.Trandaus.Find(cauthuid.Trim());
            return View(cauthu);
        }
        [Route("SuaCauThu")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaCauThu(Cauthu cauthu)
        {
            TempData["Message"] = "";
            if (ModelState.IsValid)
            {
                db.Entry(cauthu).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "Đã sửa cầu thủ thành công!";
                return RedirectToAction("Index");
            }
            return View(cauthu);
        }
        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
