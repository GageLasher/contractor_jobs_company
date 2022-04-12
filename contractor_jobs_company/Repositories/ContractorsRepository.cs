using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using contractor_jobs_company.Models;
using Dapper;

namespace contractor_jobs_company.Repositories
{
    public class ContractorsRepository
    {
        private readonly IDbConnection _db;

        public ContractorsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal Contractor Create(Contractor data)
        {
            string sql = @"
            INSERT INTO contractors
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, data);
            data.Id = id;
            return data;
        }

        internal List<Contractor> GetAll()
        {
            string sql = @"
            SELECT * FROM contractors;
            ";
            return _db.Query<Contractor>(sql).ToList();
        }

        internal ContractorViewModel GetViewModelById(int id)
        {
            string sql = "SELECT * FROM contractors WHERE id = @id;";
            return _db.Query<ContractorViewModel>(sql, new { id }).FirstOrDefault();
        }

        internal string Remove(int id)
        {
            string sql = @"
            DELETE FROM contractors WHERE id = @id LIMIT 1;
             ";
            int rowsAffected = _db.Execute(sql, new { id });
            if (rowsAffected > 0)
            {
                return "delorted";
            }
            throw new Exception("could not delete");
        }

        internal Contractor GetById(int id)
        {
            string sql = @"
            SELECT 
             *
             FROM contractors c
            WHERE c.id = @id;
            ";
            return _db.Query<Contractor>(sql
            , new { id }).FirstOrDefault();
        }
    }
}