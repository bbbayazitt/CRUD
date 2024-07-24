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

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if(_db.Customers.Any(c=> c.Email!.Equals(customer.Email)))
            {
                ModelState.AddModelError("email", "email already taken");
            }
            if (ModelState.IsValid)
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
