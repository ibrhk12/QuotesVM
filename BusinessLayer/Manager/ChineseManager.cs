using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Tables;
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
    public class ChineseManager : IChineseQManager
    {
        private readonly QuotesDBContext _context;
        public ChineseManager(IOptions<Settings> settings)
        {
            _context = new QuotesDBContext(settings);
        }

        public async Task AddQuote(Chinese item)
        {
            try
            {
                await _context.Chinese.InsertOneAsync(item);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Chinese> Get(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                var item = await _context.Chinese.Find(i => i.imageId == internalId).FirstOrDefaultAsync();
                return item;
            }
            catch(Exception ex)
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

        public async Task<IEnumerable<Chinese>> GetAll()
        {
            try
            {
                var result = await _context.Chinese.Find(_ => true).ToListAsync();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveQuote(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                DeleteResult actionResult = await _context.Chinese.DeleteOneAsync(Builders<Chinese>.Filter.Eq("imageId", internalId));
                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
