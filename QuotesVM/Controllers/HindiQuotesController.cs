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
    public class HindiQuotesController : ControllerBase
    {
        private readonly IHindiQManager _hindiQManager;
        public HindiQuotesController(IHindiQManager HQM)
        {
            _hindiQManager = HQM;
        }
        // GET: api/HindiQuotes
        [HttpGet("getAll")]
        public async Task<IEnumerable<Hindi>> Get()
        {
            var result = await _hindiQManager.GetAll();
            return result;
        }

        // GET: api/HindiQuotes/5
        [HttpGet]
        public async Task<ActionResult<Hindi>> Get(string id)
        {
            if (id != null)
            {
                var item = await _hindiQManager.Get(id);
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

        // POST: api/HindiQuotes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Hindi value)
        {
            await _hindiQManager.AddQuote(value);
            return Ok();
        }

        // PUT: api/HindiQuotes/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/HindiQuotes/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            if (id != null)
            {
                bool deleted = await _hindiQManager.RemoveQuote(id);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Image Doesn't exist");
            }
            return BadRequest("Insert Image Id");
        }
    }
}
