using CRUD_PatientLabTestAPI.Models;

namespace CRUD_PatientLabTestAPI.PatientData
{
    public interface IPatientData
    {
        List<Patient> GetPatients();
        Patient GetPatient(Guid id);
        Patient AddPatient(Patient patient);

        void DeletePatient(Patient patient);
        Patient EditPatient(Patient patient);
    }
}
