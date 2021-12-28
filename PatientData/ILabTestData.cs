using CRUD_PatientLabTestAPI.Models;

namespace CRUD_PatientLabTestAPI.PatientData
{
    public interface ILabTestData
    {
    List<LabTest> GetLabTests();
    LabTest GetLabTest(Guid id);
    LabTest AddLabTest(LabTest labtest);

    void DeleteLabTest(LabTest labtest);
    LabTest EditLabTest(LabTest labtest);

     List<PatientLabTest> GetPatientLabTestDetails ();
     List<PatientLabTest> GetPatientLabTestDetailsByTime(string FromDate, string ToDate , string Type);
    }
}
