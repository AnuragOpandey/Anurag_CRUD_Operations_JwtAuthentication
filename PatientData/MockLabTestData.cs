using CRUD_PatientLabTestAPI.Models;
using CRUD_PatientLabTestAPI.PatientData;

namespace CRUD_PatientLabTestAPI.PatientData
{
    public class MockLabTestData : ILabTestData
    {
        private IPatientData _patient;
        public MockLabTestData(IPatientData patient)
        {
            _patient = patient;
        }
        private List<LabTest> labTests = new List<LabTest>()
        {
            new LabTest()
            {

                Id = Guid.NewGuid(),
                patientID="P1",
                type="Typhoid",
                result = "Positive",
                enteredTime =Convert.ToDateTime("09/20/2021"),
                timeOfTest = Convert.ToDateTime("09/20/2021")
            },
            new LabTest()
            {

                Id = Guid.NewGuid(),
                patientID="P2",
                type="Dengue",
                result = "Negative",
                enteredTime =Convert.ToDateTime("10/23/2015"),
                timeOfTest = Convert.ToDateTime("10/23/2015")
            },
              new LabTest()
            {
                Id = Guid.NewGuid(),
                patientID="P3",
                type="Malaria",
                result = "Positive",
                enteredTime =Convert.ToDateTime("09/22/2020"),
                timeOfTest = Convert.ToDateTime("09/22/2020")
            },
                   new LabTest()
            {
                Id = Guid.NewGuid(),
                patientID="P4",
                type="Malaria",
                result = "Positive",
                enteredTime =Convert.ToDateTime("11/20/2021"),
                timeOfTest = Convert.ToDateTime("11/20/2021")
            },
                   new LabTest()
            {
                Id = Guid.NewGuid(),
                patientID="P4",
                type="Dengue",
                result = "Negative",
                enteredTime =Convert.ToDateTime("12/15/2021"),
                timeOfTest = Convert.ToDateTime("12/15/2021")
            },
                            new LabTest()
            {
                Id = Guid.NewGuid(),
                patientID="P5",
                type="Dengue",
                result = "Positive",
                enteredTime =Convert.ToDateTime("8/15/2021"),
                timeOfTest = Convert.ToDateTime("8/15/2021")
            }
        };

        public LabTest AddLabTest(LabTest labtest)
        {
            labtest.Id = Guid.NewGuid();
            labTests.Add(labtest);
            return labtest;
        }

        public void DeleteLabTest(LabTest labtest)
        {
            labTests.Remove(labtest);
        }

        public LabTest EditLabTest(LabTest labtest)
        {
            var existingLabTest = GetLabTest(labtest.Id);
            existingLabTest.type = labtest.type;
            return existingLabTest;
        }

        public LabTest GetLabTest(Guid id)
        {
            return labTests.SingleOrDefault(x => x.Id == id);
        }

        public List<LabTest> GetLabTests()
        {
            return labTests;
        }

        

        public List<PatientLabTest> GetPatientLabTestDetails()
        {
            var results = (from l in labTests
                           join p in _patient.GetPatients()
                           on l.patientID equals p.patientID
                           select new PatientLabTest
                           {
                               Name = p.name,
                               Gender = p.gender,
                               Age = p.age,
                               DOB = p.dOB,
                               Type = l.type,
                               Result = l.result,
                               EnteredTime = l.enteredTime,
                               TimeOfTest = l.timeOfTest
                           }).ToList();
            return results;

        }
        public List<PatientLabTest> GetPatientLabTestDetailsByTime(string FromDate,string ToDate, string Type)
        {
            var results = (from l in labTests
                           join p in _patient.GetPatients()
                           on l.patientID equals p.patientID
                           where l.enteredTime>=Convert.ToDateTime(FromDate) && l.enteredTime<= Convert.ToDateTime(ToDate) && l.type==Type   
                           select new PatientLabTest
                           {
                               Name = p.name,
                               Gender = p.gender,
                               Age = p.age,
                               DOB = p.dOB,
                               Type = l.type,
                               Result = l.result,
                               EnteredTime = l.enteredTime,
                               TimeOfTest = l.timeOfTest
                           }).ToList();
            return results;

        }
    }
}
    