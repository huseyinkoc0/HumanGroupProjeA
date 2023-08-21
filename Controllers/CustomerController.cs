using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanGroupProjeA.Models.Entity;

namespace HumanGroupProjeA.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        HgProjeAEntities db = new HgProjeAEntities();
        public ActionResult Index()


        {
            var customers=db.Customer.ToList();
            return View(customers);
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer x)
        {
            db.Customer.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerDelete( int id) 
        {
            var customer=db.Customer.Find(id);
            db.Customer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult CustomerEdit( int id)
        {
            var x=db.Customer.Find(id);
            return View("CustomerEdit",x);
        }

        public ActionResult CustomerUpdate(Customer x)
        {
            var Cst = db.Customer.Find(x.ID);
            Cst.Name = x.Name;
            Cst.Surname = x.Surname;
            Cst.PhoneNumber = x.PhoneNumber;
            Cst.Education= x.Education;
            Cst.Gender=x.Gender;
            Cst.Tc=x.Tc;
            Cst.Mail=x.Mail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}