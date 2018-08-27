using System.Web.Http;
using System.Web.Mvc;
using AssistantWebMySql.DAL;
using AssistantWebMySql.Interfaces;
using AssistantWebMySql.Models;
using AssistantWebMySql.Models.DbSets;

namespace AssistantWebMySql.Controllers
{
    public class UpdateController : Controller
    {
        private readonly IUpdateRepository _updateRepository;

        public UpdateController()
        {
            _updateRepository = new UpdateRepository(new AssistantContext());
        }

        // GET: Update/Index
        public ActionResult Index()
        {
            return User.Identity.IsAuthenticated ?
                (ActionResult)View(_updateRepository.GetAllUpdates()) : RedirectToAction("Login", "Account");
        }

        // POST: Update/Add
        [System.Web.Mvc.HttpPost]
        public ActionResult Add(Update updateData)
        {
            if (updateData == null)
                return View("Error");

            if (!User.Identity.IsAuthenticated)
                return View("Error");

            _updateRepository.AddNew(updateData);

            return RedirectToAction("Index");
        }

        // POST: Update/Delete/7
        [System.Web.Mvc.HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return View("Error");

            if (!User.Identity.IsAuthenticated)
                return View("Error");

            _updateRepository.Delete(id.Value);

            return RedirectToAction("Index");
        }

        // GET: Update/Download/7
        public ActionResult Download(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            if (!User.Identity.IsAuthenticated)
                return View("Error");

            string downloadLink = _updateRepository.GetDownloadLink(id.Value);

            return string.IsNullOrEmpty(downloadLink) ?
                (ActionResult)View("Error") : Redirect(downloadLink);
        }

        // GET: Update/CheckVersion
        public JsonResult CheckVersion([FromBody] UpdateJson checkVersion)
        {
            if (checkVersion == null)
                return null;

            UpdateJson updateJson = _updateRepository.GetUpdateJson(checkVersion);

            return updateJson != null ? 
                Json(updateJson,JsonRequestBehavior.AllowGet) : null;
        }
    }
}