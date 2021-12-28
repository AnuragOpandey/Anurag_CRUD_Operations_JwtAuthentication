using CRUD_PatientLabTestAPI.Models;

namespace CRUD_PatientLabTestAPI.PatientData
{
    public class MockPatientData : IPatientData
    {
        private List<Patient> patients = new List<Patient>()
        {
            new Patient()
            {
                Id = Guid.NewGuid(),
                patientID = "P1",
                name="Piyush",
                gender = "Male",
                type = "Typhoid",
                age =21,
                dOB = Convert.ToDateTime("03/29/2001")
            },
            new Patient()
            {
                Id = Guid.NewGuid(),
                patientID = "P2",
                name="Akash",
                gender = "Male",
                type= "Dengue",
                age =21,
                dOB = Convert.ToDateTime("05/20/2000")
            },
              new Patient()
            {
                Id = Guid.NewGuid(),
                patientID="P3",
                name="Ashish",
                gender = "Male",
                type= "Malaria",
                age =31,
                dOB = Convert.ToDateTime("06/26/1990")


            },

                  new Patient()
            {
                Id = Guid.NewGuid(),
                patientID="P4",
                name="Pallavi",
                gender = "Female",
                type= "Malaria",
                age =26,
                dOB = Convert.ToDateTime("02/20/1994")


            },
                   new Patient()
            {
                Id = Guid.NewGuid(),
                patientID="P5",
                name="Yogita",
                gender = "Female",
                type= "Dengue",
                age =31,
                dOB = Convert.ToDateTime("02/20/1990")
            }
        };
        public Patient AddPatient(Patient patient)
        {
            patient.Id=Guid.NewGuid();
            patients.Add(patient);
            return patient;
        }

        public void DeletePatient(Patient patient)
        {
            patients.Remove(patient);
        }

        public Patient EditPatient(Patient patient)
        {
            var existingPatient = GetPatient(patient.Id);
            existingPatient.name = patient.name;
            return existingPatient;
        }

        public Patient GetPatient(Guid id)
        {
            return patients.SingleOrDefault(x => x.Id == id);
        }

        public List<Patient> GetPatients()
        {
            return patients;
        }
    }
}
