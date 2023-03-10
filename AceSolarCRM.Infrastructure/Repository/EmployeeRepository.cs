using AceSolarCRM.EntitySpace.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using Repository.AppInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceSolarCRM.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Employees entity)
        {
            entity.EmpId = Guid.NewGuid();
            var sql = "Insert into Employees (EmpId, ContactId, FirstName, LastName, PhoneNumber, JoiningDate, DeptId, Salary) VALUES (@EmpId, @ContactId, @FirstName, @LastName, @PhoneNumber, @JoiningDate, @DeptId, @Salary)";

            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var sql = "DELETE FROM Employees WHERE EmpId = @Id";
            using var connection = new SqlConnection
                (configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result;
        }

        public async Task<IReadOnlyList<Employees>> GetAllAsync()
        {
            var sql = "Select * from Employees";
            using var connection = new SqlConnection
                (configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.QueryAsync<Employees>(sql);
            return result.ToList();
        }

        public async Task<Employees> GetByIdAsync(Guid id)
        {
            var sql = "Select * From Employees Where Id = @Id";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.QueryFirstOrDefaultAsync<Employees>(sql);
            return result;
        }

        public async Task<int> UpdateAsync(Employees entity)
        {
            var sql = "Update Employees SET JoiningDate = @JoiningDate, JobTitle = @JobTitle, DeptId = @DeptId, Salary = @Salary";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.ExecuteAsync(sql);
            return result;
        }
    }
}
