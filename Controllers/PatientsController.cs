using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD_PatientLabTestAPI.PatientData;
using CRUD_PatientLabTestAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace CRUD_PatientLabTestAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize(Roles ="Admin")]
    public class PatientsController : ControllerBase
    {
        private IPatientData _patientData;
        private readonly ILogger<PatientsController> _logger;
        public PatientsController(IPatientData patientData, ILogger<PatientsController> logger)
        {
            _patientData = patientData;
            _logger = logger;
        }

  
        [HttpGet(Name = "GetPatientDetails"), AllowAnonymous]
        public IActionResult GetPatients()
        {
            return Ok(_patientData.GetPatients());
        }

        [HttpGet]
         [Route("GetPatientbyid/{id}"), AllowAnonymous]
        public IActionResult GetPatient(Guid id)
        {
            var patient = _patientData.GetPatient(id);
            if (patient != null)
            {
                return Ok(patient);
            }
            return NotFound($"Patient with ID:{id} was not found");
            
        }

        [HttpPost("AddPatients")]
        public IActionResult AddPatient(Patient patient)
        {
            _patientData.AddPatient(patient);
            return Created(HttpContext.Request.Scheme + "://" +HttpContext.Request.Host + HttpContext.Request.Path + "/" + patient.Id,
                patient + $"Added Successfully");
            

        }

        [HttpDelete]
        [Route("DeletePatientByid/{id}")]
        public IActionResult deletePatient(Guid id)
        {
            var patient = _patientData.GetPatient(id);
            if (patient != null)
            {
                _patientData.DeletePatient(patient);
                return Ok($"Deleted Successfully");
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
            return Ok($"Updated Successfully");


        }

    }
}
