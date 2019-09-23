using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ISpanishQManager
    {
        //Get
        Task<IEnumerable<Spanish>> GetAll();
        //Get one
        Task<Spanish> Get(string id);
        //Create
        Task AddQuote(Spanish item);
        //Delete Quote
        Task<bool> RemoveQuote(string id);
    }
}
