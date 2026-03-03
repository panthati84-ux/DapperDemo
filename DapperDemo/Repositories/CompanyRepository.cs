using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dapper;
using DapperDemo.Models;

namespace DapperDemo.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbConnection _connection;

        public CompanyRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public Task<IEnumerable<Company>> GetAllAsync()
        {
            const string sql = "SELECT CompanyId, Name, Address, City, State, PostalCode FROM Companies";
            return _connection.QueryAsync<Company>(sql);
        }

        public Task<Company?> GetByIdAsync(int id)
        {
            const string sql = "SELECT CompanyId, Name, Address, City, State, PostalCode FROM Companies WHERE CompanyId = @Id";
            return _connection.QuerySingleOrDefaultAsync<Company>(sql, new { Id = id });
        }

        public async Task<int> AddAsync(Company company)
        {
            const string sql = @"
                INSERT INTO Companies (Name, Address, City, State, PostalCode)
                VALUES (@Name, @Address, @City, @State, @PostalCode);
                SELECT CAST(SCOPE_IDENTITY() AS int);";

            var id = await _connection.QuerySingleAsync<int>(sql, company);
            company.CompanyId = id;
            return id;
        }

        public Task<bool> UpdateAsync(Company company)
        {
            const string sql = @"
                UPDATE Companies
                SET Name = @Name,
                    Address = @Address,
                    City = @City,
                    State = @State,
                    PostalCode = @PostalCode
                WHERE CompanyId = @CompanyId";

            return ExecuteAndReturnSuccessAsync(sql, company);
        }

        public Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Companies WHERE CompanyId = @Id";
            return ExecuteAndReturnSuccessAsync(sql, new { Id = id });
        }

        private async Task<bool> ExecuteAndReturnSuccessAsync(string sql, object? param = null)
        {
            var affected = await _connection.ExecuteAsync(sql, param);
            return affected > 0;
        }
    }
}