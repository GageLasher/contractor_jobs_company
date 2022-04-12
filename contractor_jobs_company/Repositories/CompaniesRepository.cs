using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using contractor_jobs_company.Models;
using Dapper;

namespace contractor_jobs_company.Repositories
{
    public class CompaniesRepository
    {
        private readonly IDbConnection _db;

        public CompaniesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Company Create(Company data)
        {
            string sql = @"
            INSERT INTO companies
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, data);
            data.Id = id;
            return data;
        }

        internal List<Company> GetAll()
        {
            string sql = @"
            SELECT * FROM companies;
            ";
            return _db.Query<Company>(sql).ToList();
        }

        internal string Remove(int id)
        {
            string sql = @"
            DELETE FROM companies WHERE id = @id LIMIT 1;
             ";
            int rowsAffected = _db.Execute(sql, new { id });
            if (rowsAffected > 0)
            {
                return "delorted";
            }
            throw new Exception("could not delete");
        }

        internal Company GetById(int id)
        {
            string sql = @"
            SELECT 
             *
             FROM companies c
            WHERE c.id = @id;
            ";
            return _db.Query<Company>(sql
            , new { id }).FirstOrDefault();
        }
    }
}