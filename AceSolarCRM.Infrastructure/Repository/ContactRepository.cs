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
    public class ContactRepository : IContactRepository
    {
        private readonly IConfiguration configuration;

        public ContactRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Contacts entity)
        {
            entity.ContactId = Guid.NewGuid();

            var sql = "Insert into Contacts (ContactId, FirstName, LastName, ConjoiningName, PhoneNumber, Email, HouseNo, StreetNo, Area, City, Region, PostalCode, Country) VALUES (@ContactId, @FirstName, @LastName, @ConjoiningName, @PhoneNumber, @Email, @HouseNo, @StreetNo, @Area, @City, @Region, @PostalCode, @Country)";

            using (var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(Contacts contact)
        {
            var sql = "DELETE FROM Contacts " +
                "WHERE ContactId = @ContactId AND " +
                "WHERE FirstName = @FirstName AND " +
                "WHERE LastName = @LastName AND " +
                "Where PhoneNumber = @PhoneNumber";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.ExecuteAsync(sql, contact);
            return result; 
        }

        public async Task<IReadOnlyList<Contacts>> GetAllAsync()
        {
            var sql = "SELECT * FROM Contacts";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.QueryAsync<Contacts>(sql);
            return result.ToList();
        }

        public async Task<Contacts> GetByIdAsync(Contacts contact)
        {
            var sql = "SELECT * FROM Contacts " +
                "WHERE ContactId = @ContactId AND " +
                "WHERE FirstName = @FirstName AND " +
                "WHERE LastName = @LastName AND " +
                "Where PhoneNumber = @PhoneNumber";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<Contacts>(sql, contact);
            return result;
        }

        public Task<int> UpdateAsync(Contacts entity)
        {
            var sql = "UPDATE Contacts SET FirstName = @FirstName, LastName = @SecondName, ConjoiningName = @ConjoiningName, PhoneNumber = @PhoneNumber, Email = @Email, HouseNo = @HouseNo, StreetNo = @StreetNo, Area = @Area, City = @City, Region = @Region, PostalCode = @PostalCode, Country = @Country";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = connection.ExecuteAsync(sql, entity);
            return result;
        }
    }
}
