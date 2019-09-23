using BusinessLayer.Interface;
using DataAccessLayer;
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
    public class UrduQuotesController : ControllerBase
    {
        private readonly IUrduQManager _urduQManager;
        public UrduQuotesController(IUrduQManager UQM)
        {
            _urduQManager = UQM;
        }
        // GET: api/UrduQuotes
        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<Urdu>>> Get()
        {
            var result = await _urduQManager.GetAll();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        // GET: api/UrduQuotes/5
        [HttpGet]
        public async Task<ActionResult<Urdu>> Get(string id)
        {
            if (id != null)
            {
                var item = await _urduQManager.Get(id);
                if (item != null)
                    return Ok(item);
                else
                    return BadRequest("Id Not Found");
            }
            else
            {
                return BadRequest("Please Enter Id");
            }
        }

        // POST: api/UrduQuotes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Urdu value)
        {
            await _urduQManager.AddQuote(value);
            return Ok();
        }

        // PUT: api/UrduQuotes/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/UrduQuotes/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            if (id != null)
            {
                bool deleted = await _urduQManager.RemoveQuote(id);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Image Doesn't exist");
            }
            return BadRequest("Insert Image Id");
        }
    }
}
