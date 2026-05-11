namespace PdfFormDemo.Models
{
    public class InspectionFormModel
    {
        public string DeviceName { get; set; }  //Property for the device name. Burada cihaz adını tutacak bir property tanımlanmıştır.
        public string Temperature { get; set; } //get: Veriyi okumayı, set: Veriyi içine kaydetmeyi sağlar.
        public string Result { get; set; }
        public string IsUsable { get; set; }
    }
}