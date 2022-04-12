using contractor_jobs_company.Repositories;

namespace contractor_jobs_company.Services
{
    public class JobsService
    {
        private readonly JobsRepository _jobsRepo;

        public JobsService(JobsRepository jobsRepo)
        {
            _jobsRepo = jobsRepo;
        }
    }
}