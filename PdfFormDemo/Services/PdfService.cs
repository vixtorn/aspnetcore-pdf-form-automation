using iText.Kernel.Pdf;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Pdf.Canvas;
using PdfFormDemo.Models;

namespace PdfFormDemo.Services
{
    public class PdfService
    {
        public string GeneratePdf(InspectionFormModel model)
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

            // DEVICE NAME
            //Burada MoveText() modülü ile PDF üzerindeki konumu belirliyoruz. ShowText() modülü ile de PDF üzerine yazı yazıyoruz. 
            //EndText() modülü ile de yazma işlemini sonlandırıyoruz. Bu işlemi her bir alan için tekrarlıyoruz. 
            //EndText() modülünü kullanmazsak, PDF üzerine yazı yazma işlemi devam eder ve diğer alanlara da yazı yazılır. Bu nedenle her bir alan için EndText() modülünü kullanarak yazma işlemini sonlandırıyoruz.
            canvas.BeginText();

            canvas.SetFontAndSize(font, 12);

            canvas.MoveText(100, 700);

            canvas.ShowText(model.DeviceName);

            canvas.EndText();



            // TEMPERATURE

            canvas.BeginText();

            canvas.SetFontAndSize(font, 12);

            canvas.MoveText(100, 685);

            canvas.ShowText(model.Temperature.ToString());

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