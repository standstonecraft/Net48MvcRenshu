using Net48MvcRenshu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Net48MvcRenshu.Controllers
{
    public class UploadFilesController : Controller
    {
        private static string folder = @"C:\develop\workspace\Net48MvcRenshu\folderForUploadFiles";
        [HttpGet]
        public ActionResult Index()
        {
            UploadFilesModel model = new UploadFilesModel();

            var storedFile = Directory.GetFiles(folder).Select(f => new { name = Path.GetFileName(f), fileId = Server.UrlEncode(Path.GetFileName(f)) }).ToList();
            model.StoredFileJson = JsonConvert.SerializeObject(storedFile);
            return View("UploadFiles", model);
        }

        [HttpGet]
        public FileResult Download(string fileId)
        {
            string actualName = fileId; // fileIdからファイル名に変換(実際は何か複雑な処理)
            string actualPath = Path.Combine(folder, actualName);
            return File(actualPath, MimeMapping.GetMimeMapping(actualPath), actualName);
        }
        [HttpPost]
        public ActionResult Update(UploadFilesModel model)
        {
            // xボタンで削除されたファイルを実際に削除する
            if (model.FileIdToRemove != null)
            {
                List<string> filesToRemove = model.FileIdToRemove.Split(',')
                    .Select(fid =>
                    {
                        // fileId から物理ファイル名に変換する処理
                        string actualPath = Path.Combine(folder, fid);
                        return actualPath;
                    }).ToList();
                foreach (var file in filesToRemove)
                {
                    try
                    {
                        System.IO.File.Delete(file);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            // アップロードされたファイルを保存する
            List<HttpPostedFileWrapper> files = model.File.Where(f => f != null).ToList();
            foreach (var file in files)
            {
                file.SaveAs(Path.Combine(folder, file.FileName));
            }
            return RedirectToAction("Index");
        }
    }
}