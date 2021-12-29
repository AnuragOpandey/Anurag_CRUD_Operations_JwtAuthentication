namespace LabReportsAPI.Models
{
    public class LabTest
    {
        public Guid Id { get; set; }
        public string patientID { get; set; }
        public string patientName { get; set; }
        public string Type { get; set; }
        public string Result { get; set; }
        public DateTime TimeOfTest { get; set; }

        public DateTime EnteredTime { get; set; }
    }
}
