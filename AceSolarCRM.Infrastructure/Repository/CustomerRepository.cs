using AceSolarCRM.EntitySpace.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using Repository.AppInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceSolarCRM.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration configuration;

        public CustomerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Customers entity)
        {
            entity.CustId = Guid.NewGuid();
            
            var sql = "Insert into Customers (ContactId, CustomerType, FocalPerson, LocationPin) VALUES (@ContactId, @CustomerType, @FocalPerson, @LocationPin)";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var sql = "DELETE FROM Customers WHERE CustId = @CustId";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { CustId = id });
            return result;
        }

        public async Task<IReadOnlyList<Customers>> GetAllAsync()
        {
            var sql = "SELECT * FROM Customers";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.QueryAsync<Customers>(sql);
            return result.ToList();
        }

        public async Task<Customers> GetByIdAsync(Guid id)
        {
            var sql = "SELECT * FROM Customers where CustId = @CustId";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<Customers>(sql, new { CustId = id });
            return result;
        }

        public async Task<int> UpdateAsync(Customers entity)
        {
            var sql = "UPDATE Customers SET CustomerType = @CustomerType, FocalPerson = @FocalPerson, LocationPin = @LocationPin";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.ExecuteAsync(sql);
            return result;
        }
    }
}
