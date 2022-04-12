using System.Data;

namespace contractor_jobs_company.Repositories
{
    public class JobsRepository
    {
        private readonly IDbConnection _db;

        public JobsRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}