using System.Collections.Generic;
using contractor_jobs_company.Models;
using contractor_jobs_company.Services;
using Microsoft.AspNetCore.Mvc;

namespace contractor_jobs_company.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorsController : ControllerBase
    {
        private readonly ContractorsService _cs;

        public ContractorsController(ContractorsService cs)
        {
            this._cs = cs;
        }
        [HttpPost]
        public ActionResult<Contractor> Create([FromBody] Contractor data)
        {
            try
            {
                Contractor contractor = _cs.Create(data);
                return Ok(contractor);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public ActionResult<List<Contractor>> GetAll()
        {
            try
            {
                List<Contractor> contractors = _cs.GetAll();
                return Ok(contractors);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Contractor> GetById(int id)
        {
            try
            {
                Contractor contractor = _cs.GetById(id);
                return Ok(contractor);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<string> Remove(int id)
        {
            try
            {
                _cs.Remove(id);
                return Ok("deleted");
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}