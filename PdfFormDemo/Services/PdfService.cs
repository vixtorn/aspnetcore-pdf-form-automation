using iText.Kernel.Pdf;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Pdf.Canvas;
using PdfFormDemo.Models;

namespace PdfFormDemo.Services
{
    public class PdfService
    {
        public string GeneratePdf(
            InspectionFormModel model,
            int employeeId,
            string employeeName)
        {
            string templatePath =
                "wwwroot/templates/inspection-template.pdf";

            string outputPath =
                "wwwroot/output.pdf";

            PdfReader reader =
                new PdfReader(templatePath);

            PdfWriter writer =
                new PdfWriter(outputPath);

            PdfDocument pdf =
                new PdfDocument(reader, writer);

            PdfPage page =
                pdf.GetPage(1);

            PdfCanvas canvas =
                new PdfCanvas(page);

            PdfFont font =
                PdfFontFactory.CreateFont(
                    StandardFonts.HELVETICA
                );

            float deviceNameX = 100;
            float deviceNameY = 700;

            float employeeIdX = deviceNameX + 250;
            float employeeIdY = deviceNameY;

            float employeeNameX = employeeIdX;
            float employeeNameY = employeeIdY - 15;

            // DEVICE NAME
            canvas.BeginText();
            canvas.SetFontAndSize(font, 12);
            canvas.MoveText(deviceNameX, deviceNameY);
            canvas.ShowText(model.DeviceName);
            canvas.EndText();

            // EMPLOYEE ID
            canvas.BeginText();
            canvas.SetFontAndSize(font, 12);
            canvas.MoveText(employeeIdX, employeeIdY);
            canvas.ShowText(employeeId.ToString());
            canvas.EndText();

            // EMPLOYEE NAME
            canvas.BeginText();
            canvas.SetFontAndSize(font, 12);
            canvas.MoveText(employeeNameX, employeeNameY);
            canvas.ShowText(employeeName);
            canvas.EndText();

            // TEMPERATURE
            canvas.BeginText();
            canvas.SetFontAndSize(font, 12);
            canvas.MoveText(100, 685);
            canvas.ShowText(model.Temperature);
            canvas.EndText();

            // RESULT
            canvas.BeginText();
            canvas.SetFontAndSize(font, 12);
            canvas.MoveText(100, 670);
            canvas.ShowText(model.Result);
            canvas.EndText();

            // IS USABLE
            canvas.BeginText();
            canvas.SetFontAndSize(font, 12);
            canvas.MoveText(100, 655);
            canvas.ShowText(model.IsUsable);
            canvas.EndText();

            pdf.Close();

            return "Template PDF dolduruldu";
        }
    }
}