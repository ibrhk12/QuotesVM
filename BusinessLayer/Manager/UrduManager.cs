using BusinessLayer.Interface;
using DataAccessLayer;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Manager
{
    public class UrduManager : IUrduQManager
    {
        private readonly QuotesDBContext _context;
        public UrduManager(IOptions<Settings> settings)
        {
            _context = new QuotesDBContext(settings);
        }

        public async Task AddQuote(Urdu item)
        {
            try
            {
                await _context.Urdu.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Urdu> Get(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                var item = await _context.Urdu.Find(i => i.imageId == internalId).FirstOrDefaultAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        public async Task<IEnumerable<Urdu>> GetAll()
        {
            try
            {
                var result = await _context.Urdu.Find(_ => true).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveQuote(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                DeleteResult actionResult = await _context.Urdu.DeleteOneAsync(Builders<Urdu>.Filter.Eq("imageId", internalId));
                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
