using System.Web.Mvc;

namespace AssistantWebMySql.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        public ActionResult Index()
        {
            return User.Identity.IsAuthenticated ? 
                (ActionResult) View() : RedirectToAction("Login", "Account");
        }
    }
}