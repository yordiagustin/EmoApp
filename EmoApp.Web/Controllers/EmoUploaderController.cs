using EmoApp.Web.Models;
using EmoApp.Web.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmoApp.Web.Controllers
{
    public class EmoUploaderController : Controller
    {
        string serverFolderPath;
        EmotionHelper emoHelper;
        string key;
        private EmoAppWebContext db = new EmoAppWebContext();

        public EmoUploaderController()
        {
            serverFolderPath = ConfigurationManager.AppSettings["UPLOAD_DIR"];
            key = ConfigurationManager.AppSettings["EMOTION_KEY"];
            emoHelper = new EmotionHelper(key);
        }

        // GET: EmoUploader
        public ActionResult Index()
        {
            return View();
        }

        //POST: EmoUploader
        [HttpPost]
        public async Task<ActionResult> Index(HttpPostedFileBase file)
        {
            if (file!= null || file.ContentLength < 0)
            {
                var pictureName = Guid.NewGuid().ToString();
                pictureName += Path.GetExtension(file.FileName);

                var route = Server.MapPath(serverFolderPath);

                route = route + "/" + pictureName;

                file.SaveAs(route);

                var fileopt = file.InputStream;

                EmoPicture emoPicture = await emoHelper.DetectAndExtractFacesAsync(fileopt);

                emoPicture.Name = file.FileName;
                emoPicture.Path = $"{serverFolderPath}/{pictureName}";

                db.EmoPictures.Add(emoPicture);
                await db.SaveChangesAsync();

                               
                return RedirectToAction("Details","EmoPictures", new {Id = emoPicture.Id});
            }
            return View();
        }
    }
}