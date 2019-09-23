using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IEnglishQManager
    {
        //Get
        Task<IEnumerable<English>> GetAll();
        //Get one
        Task<English> Get(string id);
        //Create
        Task AddQuote(English item);
        //Delete Quote
        Task<bool> RemoveQuote(string id);
    }
}
