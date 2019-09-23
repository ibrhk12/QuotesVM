using DataAccessLayer.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IChineseQManager
    {
        //Get
        Task<IEnumerable<Chinese>> GetAll();
        //Get one
        Task<Chinese> Get(string id);
        //Create
        Task AddQuote(Chinese item);
        //Delete Quote
        Task<bool> RemoveQuote(string id);
    }
}
