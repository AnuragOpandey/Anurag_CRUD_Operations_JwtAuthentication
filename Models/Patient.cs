namespace CRUD_PatientLabTestAPI.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string patientID { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public string type { get; set; }

        public DateTime dOB { get; set; }
    }
}
