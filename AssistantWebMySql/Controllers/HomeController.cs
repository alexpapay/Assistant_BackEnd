using System.Web.Mvc;
using AssistantWebMySql.Models;

namespace AssistantWebMySql.Controllers
{
    public class HomeController : Controller
    {
        private readonly AssistantContext _db = new AssistantContext();

        // GET: Home/Index
        public ActionResult Index()
        {
            return User.Identity.IsAuthenticated ? 
                (ActionResult) View() : RedirectToAction("Login", "Account");
        }
    }
}