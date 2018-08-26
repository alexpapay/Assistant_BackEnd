using System;
using System.Web.Http;
using System.Web.Mvc;
using AssistantWebMySql.DAL;
using AssistantWebMySql.Interfaces;
using AssistantWebMySql.Models;
using AssistantWebMySql.Models.DbSets;

namespace AssistantWebMySql.Controllers
{
    public class ConsoleController : Controller
    {
        private readonly IConsoleRepository _consoleRepository;

        public ConsoleController()
        {
            _consoleRepository = new ConsoleRepository(new AssistantContext());
        }

        // GET: Console/Index
        public ActionResult Index()
        {
            return User.Identity.IsAuthenticated ?
                (ActionResult)View(_consoleRepository.GetAllUsers()) : RedirectToAction("Login", "Account");
        }

        // POST: Console/Create
        [System.Web.Mvc.HttpPost]
        public ActionResult Create(RegisteredUser newUser)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            _consoleRepository.AddNewUser(newUser);

            return RedirectToAction("Index");
        }

        // POST: Console/Edit
        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(int? id, DateTime? newLicenseDate)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            if (newLicenseDate == null || id == null)
                return View("Error");

            _consoleRepository.UpdateLicense(id.Value, newLicenseDate.Value);

            return RedirectToAction("Index");
        }

        // POST: Console/Delete
        [System.Web.Mvc.HttpPost]
        public ActionResult Delete(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            if (id == null)
                return View("Error");

            _consoleRepository.Delete(id.Value);

            return RedirectToAction("Index");
        }

        // POST: Console/AuthRequest
        [System.Web.Mvc.HttpPost]
        public HttpStatusCodeResult AuthRequest([FromBody] RegisteredUser parameters)
        {
            return _consoleRepository.GetUser(parameters.Name, parameters.KeyHash) == null ? 
                new HttpStatusCodeResult(404) : new HttpStatusCodeResult(200);
        }

        // POST: Console/RegisterRequest
        [System.Web.Mvc.HttpPost]
        public HttpStatusCodeResult RegisterRequest([FromBody] RegisteredUser parameters)
        {
            if (parameters == null)
                return new HttpStatusCodeResult(404);

            return !_consoleRepository.AddNewUser(parameters) ?
                new HttpStatusCodeResult(404) : new HttpStatusCodeResult(200);
        }
    }
}