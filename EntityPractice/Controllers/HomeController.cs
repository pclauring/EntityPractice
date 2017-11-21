using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using EntityPractice.Models;

namespace EntityPractice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListCustomers()
        {
            //creating object from the ORM
            NorthwindEntities ORM = new NorthwindEntities();

            //load the data from the DbSet into a data structure
            List<Customer> CustomerList = ORM.Customers.ToList();
            //filter the data
            ViewBag.CustomerList = CustomerList;
            return View("CustomersView");
        }

        public ActionResult ListCustomersByCountry(string Country)
        {
            NorthwindEntities ORM = new NorthwindEntities();

            List<Customer> OutputList = new List<Customer>();
            foreach (Customer c in ORM.Customers.ToList())
            {
                if (c.Country.ToLower() == Country.ToLower())
                {
                    OutputList.Add(c);
                }
            }

            ViewBag.CustomerList = OutputList;
            return View("CustomersView");
        }

        public ActionResult SearchForCustomerID(string CustomerID)
        {
            NorthwindEntities ORM = new NorthwindEntities();
            List<Customer> OutputList = new List<Customer>();

            foreach (Customer c in ORM.Customers.ToList())
            {
                if (c.CustomerID.Contains(CustomerID.ToUpper()))
                {
                    OutputList.Add(c);
                }
            }

            ViewBag.CustomerList = OutputList;
            return View("CustomersView");
        }
    }
}