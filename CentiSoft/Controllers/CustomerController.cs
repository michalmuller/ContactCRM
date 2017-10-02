using CentiSoft.DAL;
using CentiSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentiSoft.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            CustomerRepository customerRepository = new CustomerRepository();
            List<Customer> customers = customerRepository.LoadAllCustomers();
            List<CustomerVM> customerVMs = new List<CustomerVM>();
            foreach(Customer c in customers)
            {
                CustomerVM customerVM = new CustomerVM();
                customerVM.Id = c.Id;
                customerVM.Name = c.Name;
                customerVM.Position = c.Position;
                customerVM.PhoneNumber = c.PhoneNumber;
                customerVM.Company = c.Company;
                customerVMs.Add(customerVM);
            }
            CustomerVM model = new CustomerVM();
            model.customers = customerVMs;
            return View(model);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
