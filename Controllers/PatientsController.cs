using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LabReportsAPI.PatientData;
using LabReportsAPI.Models;

namespace LabReportsAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PatientsController : ControllerBase
    {
        private IPatientDetails _patientData;
        private readonly ILogger<PatientsController> _logger;
        public PatientsController(IPatientDetails patientData, ILogger<PatientsController> logger)
        {
            _patientData = patientData;
            _logger = logger;
        }
  
        [HttpGet(Name = "GetPatientDetails")]
        public IActionResult GetPatients()
        {
            return Ok(_patientData.GetPatients());
        }

        [HttpGet]
         [Route("GetPatientbyid/{id}")]
        public IActionResult GetPatient(Guid id)
        {
            var patient = _patientData.GetPatient(id);
            if (patient != null)
            {
                return Ok(patient);
            }
            return NotFound($"Patient with ID:{id} was not found");            
        }

        [HttpPost]
        public IActionResult AddPatient(Patient patient)
        {
            _patientData.AddPatient(patient);
            return Created(HttpContext.Request.Scheme + "://" +HttpContext.Request.Host + HttpContext.Request.Path + "/" + patient.Id,
                patient);          

        }

        [HttpDelete]
        [Route("DeletePatientByid/{id}")]
        public IActionResult deletePatient(Guid id)
        {
            var patient = _patientData.GetPatient(id);
            if (patient != null)
            {
                _patientData.DeletePatient(patient);
                return Ok();
            }
            return NotFound($"Patient with ID:{id} was not found");
        }

        [HttpPatch]
        [Route("EditPatientbyid/{id}")]
        public IActionResult EditPatient(Guid id, Patient patient)
        {
            var existingpatient = _patientData.GetPatient(id);
            if (existingpatient != null)
            {
                patient.Id = existingpatient.Id;
                _patientData.EditPatient(patient);
            }
            return Ok();
        }

    }
}
