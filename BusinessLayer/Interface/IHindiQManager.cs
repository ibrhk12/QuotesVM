using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IHindiQManager
    {
        //Get
        Task<IEnumerable<Hindi>> GetAll();
        //Get one
        Task<Hindi> Get(string id);
        //Create
        Task AddQuote(Hindi item);
        //Delete Quote
        Task<bool> RemoveQuote(string id);
    }
}
