using System.Collections.Generic;
using contractor_jobs_company.Models;
using contractor_jobs_company.Repositories;

namespace contractor_jobs_company.Services
{
    public class CompaniesService
    {
        private readonly CompaniesRepository _companiesRepo;

        public CompaniesService(CompaniesRepository companiesRepo)
        {
            _companiesRepo = companiesRepo;
        }

        internal Company Create(Company data)
        {
            return _companiesRepo.Create(data);
        }

        internal List<Company> GetAll()
        {
            return _companiesRepo.GetAll();
        }

        internal Company GetById(int id)
        {
            return _companiesRepo.GetById(id);
        }

        internal string Remove(int id)
        {
            return _companiesRepo.Remove(id);
        }
    }
}