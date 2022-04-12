using System.Collections.Generic;
using contractor_jobs_company.Models;
using contractor_jobs_company.Repositories;

namespace contractor_jobs_company.Services
{
    public class ContractorsService
    {
        private readonly ContractorsRepository _contractorsRepo;

        public ContractorsService(ContractorsRepository contractorsRepo)
        {
            _contractorsRepo = contractorsRepo;
        }
        internal Contractor Create(Contractor data)
        {
            return _contractorsRepo.Create(data);
        }

        internal List<Contractor> GetAll()
        {
            return _contractorsRepo.GetAll();
        }

        internal ContractorViewModel GetViewModelById(int contractorId)
        {
            return _contractorsRepo.GetViewModelById(contractorId);
        }




        internal Contractor GetById(int id)
        {
            return _contractorsRepo.GetById(id);
        }

        internal string Remove(int id)
        {
            return _contractorsRepo.Remove(id);
        }
    }
}