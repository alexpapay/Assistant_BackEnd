using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using AssistantWebMySql.Models;
using AssistantWebMySql.Models.DbSets;

namespace AssistantWebMySql.Controllers
{
    public class UpdateController : Controller
    {
        // GET: Update
        public ActionResult Index()
        {
            List<Update> updateModel;
            using (var db = new AssistantContext())
            {
                updateModel = db.Updates.Where(x => x.Id != 0).ToList();
            }
            return View(updateModel);
        }

        public ActionResult Add(Update updateData)
        {
            if (updateData == null)
                return RedirectToAction("Index");
            using (var db = new AssistantContext())
            {
                db.Updates.Add(updateData);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            using (var db = new AssistantContext())
            {
                var updateForDelete = db.Updates.FirstOrDefault(x => x.Id == id);
                db.Updates.Remove(updateForDelete ?? throw new InvalidOperationException());
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Download(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            using (var db = new AssistantContext())
            {
                var updateForDownload = db.Updates.FirstOrDefault(x => x.Id == id);

                if (updateForDownload != null)
                    return Redirect(updateForDownload.DownLoadLink);
            }
            return RedirectToAction("Index");
        }

        public JsonResult CheckVersion([FromBody] UpdateJson checkVersion)
        {
            if (checkVersion == null)
                return null;

            using (var db = new AssistantContext())
            {
                List<Update> lastVersionList = db.Updates.Where(x => x.Id != 0).ToList();
                if (!lastVersionList.Any())
                    return null;

                var lastVersion = lastVersionList.LastOrDefault();

                if (lastVersion != null && lastVersion.Version == checkVersion.Version)
                    return null;

                string descriptionText;
                switch (checkVersion.Language)
                {
                    case 0: descriptionText = lastVersion.RussianDescription; break;
                    case 1: descriptionText = lastVersion.EnglishDescription; break;
                    case 2: descriptionText = lastVersion.DeutschDescription; break;
                    case 3: descriptionText = lastVersion.ChineseDescription; break;
                    default: descriptionText = lastVersion.RussianDescription; break;
                }
                return Json(new UpdateJson
                {
                    Version = lastVersion.Version,
                    Description = descriptionText,
                    DownLoadLink = lastVersion.DownLoadLink
                },
                    JsonRequestBehavior.AllowGet);
            }
        }
    }
}