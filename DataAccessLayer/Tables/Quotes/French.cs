using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class French
    {
        [BsonId]
        public ObjectId imageId { get; set; }
        public string imageName { get; set; }
        public string imageUrl { get; set; }
        public string Quote { get; set; }
    }
}
