using BusinessLayer.Interface;
using DataAccessLayer;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace BusinessLayer.Manager
{
    public class ArabicManager : IArabicQManager
    {
        private readonly QuotesDBContext _context = null;
        public ArabicManager(IOptions<Settings> settings)
        {
            _context = new QuotesDBContext(settings);
        }
        public async Task AddQuote(Arabic item)
        {
            try
            {
                await _context.Arabic.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Arabic> Get(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                var item = await _context.Arabic.Find(a => a.imageId == internalId).FirstOrDefaultAsync();
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

        public async Task<IEnumerable<Arabic>> GetAll()
        {
            try
            {
                var result = await _context.Arabic.Find(_ => true).ToListAsync();
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
                DeleteResult actionResult = await _context.Arabic.DeleteOneAsync(Builders<Arabic>.Filter.Eq("imageId", internalId));
                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}