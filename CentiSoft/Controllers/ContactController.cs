using CentiSoft.DAL;
using CentiSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentiSoft.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            ContactRepository contactRepository = new ContactRepository();
            List<Contact> contacts = contactRepository.LoadAllContacts();
            List<ContactVM> contactVMs = new List<ContactVM>();
            foreach(Contact c in contacts)
            {
                ContactVM contactVM = new ContactVM();
                contactVM.Id = c.Id;
                contactVM.Name = c.Name;
                contactVM.Position = c.Position;
                contactVM.PhoneNumber = c.PhoneNumber;
                contactVM.Company = c.Company;
                contactVMs.Add(contactVM);
            }
            ContactVM model = new ContactVM();
            model.contacts = contactVMs;
            return View(model);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        ///Create
        [HttpPost]
        public ActionResult Create(ContactVM model)
        {
            ContactRepository contactRepository = new ContactRepository();
            Contact contact = new Contact();
            contact.Name = model.Name;
            contact.Company = model.Company;
            contact.Position = model.Position;
            contact.PhoneNumber = model.PhoneNumber;
            contactRepository.CreateContact(contact);

            return RedirectToAction("Index");
        }

        

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contact/Edit/5
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

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contact/Delete/5
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
