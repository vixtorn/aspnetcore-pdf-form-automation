using PdfFormDemo.Services;
using Microsoft.AspNetCore.Mvc;
using PdfFormDemo.Models;

namespace PdfFormDemo.Controllers
{
    public class InspectionController : Controller
    {
        private readonly PdfService _pdfService;

        public InspectionController()
        {
            _pdfService = new PdfService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(
        InspectionFormModel model
        )
        {
            _pdfService.GeneratePdf(model);

            return View("PdfPreview");
        }
    }
}