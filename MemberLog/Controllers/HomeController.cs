using Aspose.BarCode.BarCodeRecognition;
using MemberLog.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using ZXing;
using ZXing.QrCode;
using ZXing.Windows.Compatibility;

namespace MemberLog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public JsonResult Scan(IFormFile file)
        {
            string readedBarcode = "";
            try
            {
                if (file == null || file.Length == 0)
                {
                    return Json("Error");
                }

                var path = Path.Combine(_webHostEnvironment.ContentRootPath, "uploads", file.FileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                    fileStream.Close();
                }


                System.Drawing.Image img = System.Drawing.Image.FromFile(path);
                System.Diagnostics.Debug.WriteLine("Width:" + img.Width + " - Height:" + img.Height);

                try
                {
                    // Initialize barcode reader
                    using (BarCodeReader reader = new BarCodeReader(path, DecodeType.AllSupportedTypes))
                    {
                        // Recognize barcodes on the image
                        foreach (var barcode in reader.ReadBarCodes())
                        {

                            readedBarcode = barcode.CodeText;
                        }
                    }

                }

                catch (Exception exp)
                {

                    System.Console.Write(exp.Message);
                }


            }
            catch (Exception ex)
            {
                ViewBag.Title = ex.Message;
            }
            return Json(readedBarcode);


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