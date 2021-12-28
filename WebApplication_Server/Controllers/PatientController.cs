using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Server.Models;
using WebApplication_Server.Repositories;

namespace WebApplication_Server.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> Get()
        {
            var patients = PatientRepository.GetPatients();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public ActionResult<Patient> Get(long id)
        {
            var patient = PatientRepository.GetPatient(id);

            if (patient != null)
            {
                return Ok(patient);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post(Patient patient)
        {
            PatientRepository.AddPatient(patient);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(Patient patient, long id)
        {
            var dbPatient = PatientRepository.GetPatient(id);

            if (dbPatient != null)
            {
                PatientRepository.UpdatePatient(patient);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var patient = PatientRepository.GetPatient(id);

            if (patient != null)
            {
                PatientRepository.DeletePatient(patient);
                return Ok();
            }

            return NotFound();
        }
    }
}