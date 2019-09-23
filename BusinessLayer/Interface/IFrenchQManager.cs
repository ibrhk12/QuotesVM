using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IFrenchQManager
    {
        //Get
        Task<IEnumerable<French>> GetAll();
        //Get one
        Task<French> Get(string id);
        //Create
        Task AddQuote(French item);
        //Delete Quote
        Task<bool> RemoveQuote(string id);
    }
}
