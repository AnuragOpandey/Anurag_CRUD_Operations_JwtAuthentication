namespace LabReportsAPI.Models
{
    public class PatientLabTest
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public string Type { get; set; }
        public string Result { get; set; }
        public DateTime TimeOfTest { get; set; }
        public DateTime EnteredTime { get; set; }
    }
}
