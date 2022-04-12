using System.Collections.Generic;
using contractor_jobs_company.Models;
using contractor_jobs_company.Services;
using Microsoft.AspNetCore.Mvc;

namespace contractor_jobs_company.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly CompaniesService _cs;

        public CompaniesController(CompaniesService cs)
        {
            _cs = cs;
        }
        [HttpPost]
        public ActionResult<Company> Create([FromBody] Company data)
        {
            try
            {
                Company company = _cs.Create(data);
                return Ok(company);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public ActionResult<List<Company>> GetAll()
        {
            try
            {
                List<Company> companies = _cs.GetAll();
                return Ok(companies);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Company> GetById(int id)
        {
            try
            {
                Company company = _cs.GetById(id);
                return Ok(company);
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