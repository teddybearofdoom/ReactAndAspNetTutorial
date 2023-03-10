using AceSolarCRM.EntitySpace.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32.SafeHandles;
using Repository.AppInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace AceSolarCRM.Infrastructure.Repository
{
    public class DealRepository : IDealRepository
    {
        private readonly IConfiguration configuration;

        public DealRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Deals entity)
        {
            entity.DealsId = Guid.NewGuid();
            entity.CreatedAt = DateTime.Now;
            var sql = "Insert into Deals (Proposal, FocalPerson, PrimaryVisit, PrimaryMeeting, PrimarySketch, ContacId, FirstName, LastName, PhoneNumber) VALUES (@Proposal, @FocalPerson, @PrimaryVisit, @PrimaryMeeting, @PrimarySketch, @ContactId)";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var sql = "DELETE FROM Deals WHERE DealsId = @Id";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { DealsId = id });
            return result;
        }

        public async Task<IReadOnlyList<Deals>> GetAllAsync()
        {
            var sql = "SELECT * FROM Deals";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.QueryAsync<Deals>(sql);
            return result.ToList(); 
        }

        public async Task<Deals> GetByIdAsync(Guid id)
        {
            var sql = "SELECT * FROM Deals Where Id = @Id";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<Deals>(sql);
            return result;
        }

        public async Task<int> UpdateAsync(Deals entity)
        {
            var sql = "UPDATE Deals SET Proposal = @Proposal, FocalPerson = @FocalPerson, PrimaryVisit = @PrimaryVisit, PrimaryMeeting = @PrimaryMeeting, PrimarySketch = @PrimarySketch, ContactId = @ContactId, FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber";
            using var connection = new SqlConnection(configuration.GetConnectionString("SQLDatabase"));
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }
}
