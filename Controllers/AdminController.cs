using System.Linq;
using System.Web.Mvc;
using VRASearchEngine.Models;
using VRASearchEngine.Helper;

namespace VRASearchEngine.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var admins = _context.Admins.ToList();
            return View(admins);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdminModel admin)
        {
            if (ModelState.IsValid)
            {
                // In future, hash password here
                _context.Admins.Add(admin);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        public ActionResult Delete(int id)
        {
            var admin = _context.Admins.Find(id);
            if (admin == null)
                return HttpNotFound();

            _context.Admins.Remove(admin);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
