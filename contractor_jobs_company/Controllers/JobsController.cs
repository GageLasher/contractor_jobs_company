using contractor_jobs_company.Services;
using Microsoft.AspNetCore.Mvc;


namespace contractor_jobs_company.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _js;

        public JobsController(JobsService js)
        {
            _js = js;
        }
    }
}