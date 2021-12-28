using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD_PatientLabTestAPI.PatientData;
using CRUD_PatientLabTestAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace CRUD_PatientLabTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class LabTestController : ControllerBase
    {
        private ILabTestData _labtestData;
        private readonly ILogger<LabTestController> _logger;
        public LabTestController(ILabTestData labtestData, ILogger<LabTestController> logger)
        {
            _labtestData = labtestData;
            _logger = logger;
        }
    

    [HttpGet(Name = "GetLabTestDetails"), AllowAnonymous]
    public IActionResult GetLabTest()
    {
        return Ok(_labtestData.GetLabTests());
    }
        [HttpGet]
        [Route("GetLabTestbyid/{id}"), AllowAnonymous]
        public IActionResult GetPatient(Guid id)
        {
            var labtest = _labtestData.GetLabTest(id);
            if (labtest != null)
            {
                return Ok(labtest);
            }
            return NotFound($"Lab Reports with ID:{id} was not found");

        }

        [HttpGet]
        [Route("GetPatientLabReportDetails"), AllowAnonymous]
        public IActionResult GetPatientLabTestDetails()
        {
            var labtest = _labtestData.GetPatientLabTestDetails();
            if (labtest != null)
            {
                return Ok(labtest);
            }
            return NotFound($"Patient Lab Details was not found");

        }

        [HttpGet]
        [Route("GetPatientLabReportByTime/{FromDate}/{ToDate}/{Type}"), AllowAnonymous]
        public IActionResult GetPatientLabReportByTime(string FromDate,string ToDate, string Type)
        {
            var labtest = _labtestData.GetPatientLabTestDetailsByTime(FromDate, ToDate, Type);
            if (labtest != null)
            {
                return Ok(labtest);
            }
            return NotFound($"There were no Lab Reports for the given DateTime Range");

        }

        [HttpPost("AddLabTestDetails")]
        public IActionResult AddLabTest(LabTest labtest)
        {
            _labtestData.AddLabTest(labtest);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + labtest.Id,
                labtest + $"Added Successfully");

        }

        [HttpDelete]
        [Route("DeleteLabReportsByid/{id}")]
        public IActionResult deletePatient(Guid id)
        {
            var labtest = _labtestData.GetLabTest(id);
            if (labtest != null)
            {
                _labtestData.DeleteLabTest(labtest);
                return Ok($"Deleted Successfully");
            }
            return NotFound($"Lab Reports with ID:{id} was not found");


        }

        [HttpPatch]
        [Route("EditPatientbyid/{id}")]
        public IActionResult EditLabTest(Guid id, LabTest labTest)
        {
            var existinglabtest = _labtestData.GetLabTest(id);
            if (existinglabtest != null)
            {
                labTest.Id = existinglabtest.Id;
                _labtestData.EditLabTest(labTest);
            }
            return Ok($"Updated Successfully");


        }
    }
}
