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

            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var sql = "DELETE FROM Leads WHERE LeadId = @Id";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { LeadId = id });
            return result;
        }

        public async Task<IReadOnlyList<Leads>> GetAllAsync()
        {
            var sql = "SELECT * FROM Leads";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.QueryAsync<Leads>(sql);
            return result.ToList();
        }

        public async Task<Leads> GetByIdAsync(Guid id)
        {
            var sql = "SELECT * FROM Leads WHERE LeadId = @Id";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync(sql, new { LeadId = id });
            return result;
        }

        public async Task<int> UpdateAsync(Leads entity)
        {
            var sql = "UPDATE Leads SET LeadName = @LeadName, ReferralType = @ReferralType, ReferredBy = @ReferredBy, PhoneNumber = @PhoneNumber, Address = @Address, Proposal = @Proposal";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }
}
