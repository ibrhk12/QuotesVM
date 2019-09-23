using BusinessLayer.Interface;
using DataAccessLayer.Tables;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuotesVM.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChineseQuotesController : ControllerBase
    {
        private readonly IChineseQManager _chineseQManager;
        public ChineseQuotesController(IChineseQManager CQM)
        {
            _chineseQManager = CQM;
        }
        [HttpGet("getAll")]
        // GET: api/ChineseQuotes
        public async Task<ActionResult<IEnumerable<Chinese>>> Get()
        {
            var result = await _chineseQManager.GetAll();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        // GET: api/ChineseQuotes/5
        [HttpGet]
        public async Task<ActionResult<Chinese>> Get(string id)
        {
            if(id != null)
            {
                var result = await _chineseQManager.Get(id);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest("Id Not Found");
            }
            return BadRequest("Please Enter Id");
        }

        // POST: api/ChineseQuotes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Chinese value)
        {
            await _chineseQManager.AddQuote(value);
            return Ok();
        }

        // PUT: api/ChineseQuotes/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/ChineseQuotes/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            if (id != null)
            {
                bool deleted = await _chineseQManager.RemoveQuote(id);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Image Doesn't exist");
            }
            return BadRequest("Insert Image Id");
        }
    }
}
