namespace LabReportsAPI.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string patientID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
    }
}
