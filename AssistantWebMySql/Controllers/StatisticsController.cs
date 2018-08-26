using System.Web.Mvc;
using AssistantWebMySql.DAL;
using AssistantWebMySql.Interfaces;
using AssistantWebMySql.Models;
using AssistantWebMySql.Models.DbSets;

namespace AssistantWebMySql.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsController()
        {
            _statisticsRepository = new StatisticsRepository(new AssistantContext());
        }

        // GET: Statistics/Index
        public ActionResult Index()
        {
            return User.Identity.IsAuthenticated ?
                (ActionResult)View(_statisticsRepository.GetAll()) : RedirectToAction("Login", "Account");
        }

        // POST: Statistics/Monitoring
        [HttpPost]
        public ActionResult Monitoring(MonitoringValue monitoringValue)
        {
            _statisticsRepository.Add(monitoringValue);
            return View("Index");
        }
    }
}