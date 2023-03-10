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
            var sql = "DELETE FROM Customers WHERE CustId = @Id";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result;
        }

        public Task<IReadOnlyList<Customers>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customers> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Customers entity)
        {
            throw new NotImplementedException();
        }
    }
}
