using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class CustomerController(ApplicationDbContext db) : Controller
    {

        private readonly ApplicationDbContext _db = db;
        public IActionResult Index()
        {
            List<Customer> customers = _db.Customers.ToList();
            return View(customers);
        }
    }
}
