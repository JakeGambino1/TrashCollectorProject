using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Employees
        public ActionResult Index()
        {
            var listOfEmployees = db.Employees.ToList();
            return View(listOfEmployees);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = db.Employees.Where(e => e.Id == id).SingleOrDefault();
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                string currentUserId = User.Identity.GetUserId();
                employee.ApplicationId = currentUserId;
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Details", "Employees", new { id = employee.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = db.Employees.Where(e => e.Id == id).SingleOrDefault();
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                Employee editEmployee = db.Employees.Find(id);
                editEmployee.FirstName = employee.FirstName;
                editEmployee.LastName = employee.LastName;
                editEmployee.ZipCode = employee.ZipCode;
                db.SaveChanges();
                return RedirectToAction("Details", "Employees", new { id = editEmployee.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = db.Employees.Where(e => e.Id == id).SingleOrDefault();
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                // TODO: Add delete logic here
                db.Employees.Remove(db.Customers.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
