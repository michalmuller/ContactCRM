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

        // GET EDIT PAGE
        public ActionResult Edit(int id)
        {
            ContactRepository contactRepository = new ContactRepository();
            Contact contact = contactRepository.LoadContact(id);

            ContactVM model = new ContactVM();
            model.Id = contact.Id;
            model.Name = contact.Name;
            model.Company = contact.Company;
            model.Position = contact.Position;
            model.PhoneNumber = contact.PhoneNumber;

            return View(model);
        }

        public ActionResult Show(int id)
        {
            ContactRepository contactRepository = new ContactRepository();
            Contact contact = contactRepository.LoadContact(id);

            ContactVM model = new ContactVM();
            model.Id = contact.Id;
            model.Name = contact.Name;
            model.Company = contact.Company;
            model.Position = contact.Position;
            model.PhoneNumber = contact.PhoneNumber;

            return View(model);
        }

        //HTTP POST EDIT PAGE
        [HttpPost]
        public ActionResult Edit(ContactVM model)
        {
            Contact contact = new Contact();
            contact.Id = model.Id;
            contact.Company = model.Company;
            contact.Position = model.Position;
            contact.PhoneNumber = model.PhoneNumber;
            contact.Name = model.Name;

            ContactRepository contactRepository = new ContactRepository();
            contactRepository.EditContact(contact);

            return RedirectToAction("Index");
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

        
        
        public ActionResult Delete(int id)
        {
            ContactRepository contactRepository = new ContactRepository();
            contactRepository.DeleteContact(id);
            return RedirectToAction("Index");

        }

        // POST: Contact/Delete/5
        
    }
}
