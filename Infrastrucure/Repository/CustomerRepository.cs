using Dapper;
using Domain.Models.Customers;
using Infrastrucure.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastrucure.Repository
{
    public class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
    {
        private readonly IDbConnection _connection;

        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _connection = context.Database.GetDbConnection();
        }
        public async Task<IEnumerable<Customer>> GetAll()
        {
            var sql = "SELECT Id, Name FROM Customers";
            return await _connection.QueryAsync<Customer>(sql);
        }
    }
}
