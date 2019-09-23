using DataAccessLayer;
using DataAccessLayer.Tables;
using DataAccessLayer.Tables.SucessStory;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace BusinessLayer
{
    public class QuotesDBContext
    {
        private readonly IMongoDatabase _database = null;
        public QuotesDBContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }
        //Arabic Quotes Table
        public IMongoCollection<Arabic> Arabic
        {
            get
            {
                return _database.GetCollection<Arabic>("Arabic");
            }
        }
        //English Quotes Table
        public IMongoCollection<English> English
        {
            get
            {
                return _database.GetCollection<English>("English");
            }
        }
        //French Quotes Table
        public IMongoCollection<French> French
        {
            get
            {
                return _database.GetCollection<French>("French");
            }
        }
        //Spanish Quotes Table
        public IMongoCollection<Spanish> Spanish
        {
            get
            {
                return _database.GetCollection<Spanish>("Spanish");
            }
        }
        //Hindi Quotes Table
        public IMongoCollection<Hindi> Hindi
        {
            get
            {
                return _database.GetCollection<Hindi>("Hindi");
            }
        }
        //Chinese Quotes Table
        public IMongoCollection<Chinese> Chinese
        {
            get
            {
                return _database.GetCollection<Chinese>("Chinese");
            }
        }
        //Urdu Quotes Table
        public IMongoCollection<Urdu> Urdu
        {
            get
            {
                return _database.GetCollection<Urdu>("Urdu");
            }
        }
        //Arabic Success Story Table
        public IMongoCollection<ArabicSS> ArabicSS
        {
            get
            {
                return _database.GetCollection<ArabicSS>("ArabicSS");
            }
        }
        //English Success Story Table
        public IMongoCollection<EnglishSS> EnglishSS
        {
            get
            {
                return _database.GetCollection<EnglishSS>("EnglishSS");
            }
        }
        //French Success Story Table
        public IMongoCollection<FrenchSS> FrenchSS
        {
            get
            {
                return _database.GetCollection<FrenchSS>("FrenchSS");
            }
        }
        //Spanish Success Story Table
        public IMongoCollection<SpanishSS> SpanishSS
        {
            get
            {
                return _database.GetCollection<SpanishSS>("SpanishSS");
            }
        }
        //Hindi Success Story Table
        public IMongoCollection<HindiSS> HindiSS
        {
            get
            {
                return _database.GetCollection<HindiSS>("HindiSS");
            }
        }
        //Chinese Success Story Table
        public IMongoCollection<ChineseSS> ChineseSS
        {
            get
            {
                return _database.GetCollection<ChineseSS>("ChineseSS");
            }
        }
        //Urdu Success Story Table
        public IMongoCollection<UrduSS> UrduSS
        {
            get
            {
                return _database.GetCollection<UrduSS>("UrduSS");
            }
        }
    }
}
