using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using PdfFormDemo.Data;
using PdfFormDemo.Models;
using PdfFormDemo.Services;

namespace PdfFormDemo.Controllers
{
    public class InspectionController : Controller
    {
        private readonly PdfService _pdfService;

        private readonly ApplicationDbContext _context;

        public InspectionController(
            PdfService pdfService,
            ApplicationDbContext context)
        {
            _pdfService = pdfService;

            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await LoadEmployeesDropdownAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(
            InspectionFormModel model)
        {
            var selectedEmployee =
                await _context.Employees
                .AsNoTracking()
                .Where(e => e.Id == model.SelectedEmployeeId)
                .Select(e => new
                {
                    e.Id,
                    e.Name
                })
                .FirstOrDefaultAsync();

            if (selectedEmployee == null)
            {
                ModelState.AddModelError(
                    "",
                    "Çalışan bulunamadı."
                );

                await LoadEmployeesDropdownAsync();

                return View(model);
            }

            _pdfService.GeneratePdf(
                model,
                selectedEmployee.Id,
                selectedEmployee.Name
            );

            return View("PdfPreview");
        }

        private async Task LoadEmployeesDropdownAsync()
        {
            ViewBag.Employees =
                await _context.Employees
                .AsNoTracking()
                .OrderBy(e => e.Name)
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.Name
                })
                .ToListAsync();
        }
    }
}