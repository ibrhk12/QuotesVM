using DataAccessLayer;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IArabicQManager
    {
        //Get
        Task<IEnumerable<Arabic>> GetAll();
        //Get one
        Task<Arabic> Get(string id);
        //Create
        Task AddQuote(Arabic item);
        //Delete Quote
        Task<bool> RemoveQuote(string id);
    }
}