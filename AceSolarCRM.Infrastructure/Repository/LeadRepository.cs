﻿using AceSolarCRM.EntitySpace.Entities;
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
    public class LeadRepository : ILeadRepository
    {
        private readonly IConfiguration configuration;
        private readonly IDbConnection? _connection;

        public LeadRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Leads entity)
        {
            entity.AddedOn = DateTime.Now;
            entity.LeadId = Guid.NewGuid();
            var sql = "Insert into Leads (LeadId, LeadName, ReferralType, ReferredBy, PhoneNumber, Address, Proposal, AssignedTo, AddedOn) VALUES (@LeadId, @LeadName, @ReferrealType, @ReferredBy, @PhoneNumber, @Address, @Proposal, @AssignedTo, @AddedOn)";

            using(var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"))) 
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
