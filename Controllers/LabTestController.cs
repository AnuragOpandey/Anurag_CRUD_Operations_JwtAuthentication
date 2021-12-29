using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LabReportsAPI.PatientData;
using LabReportsAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace LabReportsAPI.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class LabTestController : ControllerBase
    {
        private ILabTestDetails _labtestData;
        private readonly ILogger<LabTestController> _logger;
        public LabTestController(ILabTestDetails labtestData, ILogger<LabTestController> logger)
        {
            _labtestData = labtestData;
            _logger = logger;
        }

       
        [HttpGet(Name = "GetLabTestDetails")]
        public IActionResult GetLabTest()
        {
            return Ok(_labtestData.GetLabTests());
        }
        [HttpGet]
        [Route("GetLabTestbyid/{id}")]
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
        [Route("GetPatientLabReportDetails")]
        public IActionResult GetPatientLabTestDetails()
        {
            var labtest = _labtestData.GetPatientLabTestDetails();
            if (labtest != null)
            {
                return Ok(labtest);
            }
            return NotFound($"Lab Reports were not found");

        }

        [HttpGet]
        [Route("GetPatientLabReportByTime/{FromDate}/{ToDate}")]
        public IActionResult GetPatientLabReportByTime(DateTime FromDate, DateTime ToDate)
        {
            var labtest = _labtestData.GetPatientLabTestDetailsByTime(FromDate, ToDate);
            if (labtest != null)
            {
                return Ok(labtest);
            }
            return NotFound($"Lab Reports with ID was not found");

        }

        [HttpPost]
        public IActionResult AddLabTest(LabTest labtest)
        {
            _labtestData.AddLabTest(labtest);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + labtest.Id,
                labtest);

        }

        [HttpDelete]
        [Route("DeleteLabReportsByid/{id}")]
        public IActionResult deletePatient(Guid id)
        {
            var labtest = _labtestData.GetLabTest(id);
            if (labtest != null)
            {
                _labtestData.DeleteLabTest(labtest);
                return Ok();
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
            return Ok();


        }
    }
}
