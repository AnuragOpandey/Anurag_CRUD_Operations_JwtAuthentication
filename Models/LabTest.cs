namespace CRUD_PatientLabTestAPI.Models
{
    public class LabTest
    {
        public Guid Id { get; set; }

        public string patientID { get; set; }
        public string type { get; set; }
        public string result { get; set; }
        public DateTime timeOfTest { get; set; }

        public DateTime enteredTime { get; set; }
    }
}
