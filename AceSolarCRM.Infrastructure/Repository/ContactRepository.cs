using AceSolarCRM.EntitySpace.Entities;
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

        public Task<int> AddAsync(Contacts entity)
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

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Contacts>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Contacts> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Contacts entity)
        {
            throw new NotImplementedException();
        }
    }
}
