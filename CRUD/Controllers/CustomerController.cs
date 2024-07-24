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

                
               TempData["success"] = "Customer created succesfully";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id) {
        
            Customer? customer = _db.Customers.Find(id);
            if (id == null || id ==0 || customer ==null )
            {
                return NotFound();
            }
            return View(customer);
        
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (_db.Customers.Any(c => c.Email!.Equals(customer.Email)&&
            c.Id != customer.Id))
            {
                ModelState.AddModelError("email", "email already taken");
            }
            if (ModelState.IsValid)
            {
                _db.Customers.Update(customer);
                _db.SaveChanges();

                TempData["success"] = "Customer edited succesfully";

                return RedirectToAction("Index");
            }

            return View();

        }

        public IActionResult Delete(int? id)
        {

            Customer? customer = _db.Customers.Find(id);
            if (id == null || id == 0 || customer == null)
            {
                return NotFound();
            }
            
            _db.Customers.Remove(customer);
            _db.SaveChanges();

            TempData["success"] = "Customer deleted succesfully";

            return RedirectToAction("Index");

        }


    }
}
