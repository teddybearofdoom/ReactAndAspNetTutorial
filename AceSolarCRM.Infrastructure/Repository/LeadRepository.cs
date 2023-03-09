using AceSolarCRM.EntitySpace.Entities;
using Repository.AppInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceSolarCRM.Infrastructure.Repository
{
    public class LeadRepository : ILeadRepository
    {
        private readonly IDbConnection _connection;

        public LeadRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public Task<int> AddAsync(Leads entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Leads>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Leads> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Leads entity)
        {
            throw new NotImplementedException();
        }
    }
}
