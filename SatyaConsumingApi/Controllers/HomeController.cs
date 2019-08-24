using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Entities;
using System.IO;
using System.Net;

namespace SatyaConsumingApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Part6()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Part6(HttpPostedFileBase file)
        {
            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    byte[] Bytes = new byte[file.InputStream.Length + 1];
                    file.InputStream.Read(Bytes, 0, Bytes.Length);
                    var fileContent = new ByteArrayContent(Bytes);
                    fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = file.FileName };
                    content.Add(fileContent);
                    var requestUri = "http://localhost:47250/api/Upload";
                    var result = client.PostAsync(requestUri, content).Result;
                    if (result.StatusCode == HttpStatusCode.Created)
                    {
                        List<string> m = result.Content.ReadAsAsync<List<string>>().Result;
                        WebClient wc = new WebClient();
                        ViewBag.Success = wc.DownloadString(m.FirstOrDefault()).ToString();
                    }
                    else
                    {
                        ViewBag.Failed = "Failed !" + result.Content.ToString();
                    }
                }
            }
            return View();
        }
    }
}
