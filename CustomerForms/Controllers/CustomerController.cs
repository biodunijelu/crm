using CustomerForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;
using System.Net;

namespace CustomerForms.Controllers
{
    public class CustomerController : Controller
    {



        private CustomerFormsContext db;

        public CustomerController()
        {

            db = new CustomerFormsContext();
    }

        public ActionResult Index()
        {
            var customers = db.Customers;
            return View(customers.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new Customer();
            return View(model);
        }
         [HttpPost]
        public ActionResult Create(Customer model)
        {
           if (ModelState.IsValid)
           {
              
               db.Customers.Add(model);
               int result = db.SaveChanges();

               if  (result > 0){

                      return RedirectToAction("index");

               }


              

           }

           ViewBag.ErrorMessage = "Operation failed. Please check your input and try again";
           return View(model);
        }
 
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Customers.FirstOrDefault(p => p.ID == id);

            return View(model);
          
        }
    [HttpPost]
        public ActionResult Edit(Customer model)
        {

            if (ModelState.IsValid)
            {

                db.Entry(model).State = EntityState.Modified;
                int result = db.SaveChanges();

                if (result > 0)
                {

                    return RedirectToAction("index");

                }
               
            }
        ViewBag.ErrorMessage = "Operation failed. Please check your input and try again";
                return View(model);

        }

    [HttpGet]
    public ActionResult delete(int id)

    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        Customer Customer = db.Customers.Find(id);

        if (Customer == null)
        {
            return HttpNotFound();
        }
        return View(Customer);

       

    } 
    
          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public ActionResult DeleteConfirmed(int id)
          {
              Customer Customer = db.Customers.Find(id);
              db.Customers.Remove(Customer);
              db.SaveChanges();
              return RedirectToAction("Index");
          }

    }
    
}
