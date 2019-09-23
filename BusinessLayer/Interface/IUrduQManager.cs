using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IUrduQManager
    {
        //Get
        Task<IEnumerable<Urdu>> GetAll();
        //Get one
        Task<Urdu> Get(string id);
        //Create
        Task AddQuote(Urdu item);
        //Delete Quote
        Task<bool> RemoveQuote(string id);
    }
}
