using System.Collections.Generic;
using contractor_jobs_company.Models;
using contractor_jobs_company.Repositories;

namespace contractor_jobs_company.Services
{
    public class JobsService
    {
        private readonly JobsRepository _jobsRepo;
        private readonly ContractorsService _cs;
        private readonly CompaniesService _companyService;

        public JobsService(JobsRepository jobsRepo, ContractorsService cs, CompaniesService companyService)
        {
            _jobsRepo = jobsRepo;
            _cs = cs;
            _companyService = companyService;
        }

        internal ContractorViewModel Create(Job jobData)
        {
            Job job = _jobsRepo.Create(jobData);
            ContractorViewModel contractor = _cs.GetViewModelById(job.ContractorId);
            Company company = _companyService.GetById(jobData.CompanyId);
            contractor.JobId = job.Id;
            return contractor;



        }

        internal List<ContractorViewModel> JetJobsByContractorId(int id)
        {
            return _jobsRepo.GetJobsByContractorId(id);

        }
    }
}