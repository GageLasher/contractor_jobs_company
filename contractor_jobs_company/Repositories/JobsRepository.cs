using System.Collections.Generic;
using System.Data;
using System.Linq;
using contractor_jobs_company.Models;
using Dapper;

namespace contractor_jobs_company.Repositories
{
    public class JobsRepository
    {
        private readonly IDbConnection _db;

        public JobsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Job Create(Job jobData)
        {
            string sql = @"
            INSERT INTO jobs
            (contractorId, companyId)
            VALUES
            (@ContractorId, @CompanyId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, jobData);
            jobData.Id = id;
            return jobData;
        }

        internal List<ContractorViewModel> GetJobsByContractorId(int id)
        {
            string sql = @"
            SELECT
                c.*,
                j.*,
                company.*
            FROM jobs j
            JOIN contractors c ON c.id =j.contractorId
            JOIN company company ON company.id = j.companyId
            WHERE j.contractorId = @id;
            ";
            List<ContractorViewModel> contractors = _db.Query<ContractorViewModel, Job, Company, ContractorViewModel>(sql, (c, j, company) =>
            {
                // NOTE assemble the view model
                c.JobId = j.Id;

                return c;
            }, new { id }).ToList();
            return contractors;
        }
    }
}