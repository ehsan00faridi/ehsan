using Application.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Infrastructure.Redis
//{
//    public class RedisCacheService : ICacheService
//    {
//        private readonly IDatabase _database;

//        public RedisCacheService(IConnectionMultiplexer redis)
//        {
//            _database = redis.GetDatabase();
//        }

//        public async Task<string> GetValueAsync(string key)
//        {
//            return await _database.StringGetAsync(key);
//        }

//        public async Task SetValueAsync(string key, string value, TimeSpan expiry)
//        {
//            await _database.StringSetAsync(key, value, expiry);
//        }
//    }
//}
