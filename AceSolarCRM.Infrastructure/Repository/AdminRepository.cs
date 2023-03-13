using AceSolarCRM.EntitySpace.Entities;
using Microsoft.Extensions.Configuration;
using Repository.AppInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceSolarCRM.Infrastructure.Repository
{
    internal class AdminRepository : IAdminRepository
    {
        private readonly IConfiguration configuration;

        public AdminRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<int> AddAsync(Admin entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Admin>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Admin> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
