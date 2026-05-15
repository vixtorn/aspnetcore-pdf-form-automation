namespace PdfFormDemo.Models
{
    public class InspectionFormModel
    {
        public string DeviceName { get; set; } = string.Empty;

        public string Temperature { get; set; } = string.Empty;

        public string Result { get; set; } = string.Empty;

        public string IsUsable { get; set; } = string.Empty;

        public int SelectedEmployeeId { get; set; }
    }
}