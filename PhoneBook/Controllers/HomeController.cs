using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PhoneBook.Models;

using PhoneBook.Data;

namespace PhoneBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ContactBookContext _dbContext;
        private readonly IPersonService _personService; 

        public HomeController(
            IConfiguration configuration,
            //, ContactBookContext dbContext, 
            IPersonService personService)
        {
            _configuration = configuration;
            //_dbContext = dbContext;
            _personService = personService;
        }

        public IActionResult Index()
        {
            //var list = _dbContext.Person.ToList();
            //foreach (var item in list)
            //{
            //    var phoneList = _dbContext.Phones.Where(p => p.PersonId == item.Id);
            //    foreach (var phone in phoneList)
            //    {
            //        item.Phones.Add(phone);
            //    }
            //}

            //var list = _dbContext.Person.ToList();
            //return View(list);

            var list = _personService.GetAllPerson();
            return View(list);
        }

        public IActionResult Details(int Id)
        {
            var person = _dbContext.Person.Where(p => p.Id == Id).FirstOrDefault();
            return View(person);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }


        // show list
        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page. #1";
            return View();
        }

        // add new
        [HttpPost]
        public IActionResult Contact(Person person)
        {
            _dbContext.Person.Add(person);
            _dbContext.SaveChanges();

            return RedirectToAction("index");
        }

        // show edit page
        [HttpGet]
        [Route("[controller]/Contact/{Id:int}")]
        public IActionResult Contact(int Id)
        {
            ViewData["Message"] = "Your contact page. #2";
            ViewBag.Mode = "edit";

            var person = _dbContext.Person.Where(p => p.Id == Id).FirstOrDefault();
            person.Phones.Clear();

            var phoneList = _dbContext.Phones.Where(p => p.PersonId == person.Id);
            foreach (var item in phoneList)
            {
                person.Phones.Add(item);
            }

            return View(person);
        }

        // update person 
        [HttpPost]
        [Route("[controller]/Contact/{Id:int}")]
        public IActionResult ContactUpdate(int Id, Person personUpdate)
        {
            var person = _dbContext.Person.Where(p => p.Id == Id).FirstOrDefault();
            person.FirstName = personUpdate.FirstName;
            _dbContext.SaveChanges();

            var phoneList = _dbContext.Phones.Where(p => p.PersonId == person.Id).ToList();
            foreach (var item in phoneList)
            {
                var upd = personUpdate.Phones.Where(p => p.Id == item.Id).FirstOrDefault();
                if (upd != null)
                {
                    item.PhoneNumber = upd.PhoneNumber;
                    _dbContext.Phones.Update(item);
                    _dbContext.SaveChanges();
                }
            }

            return RedirectToAction("index");
        }
            




        public IActionResult Privacy()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
