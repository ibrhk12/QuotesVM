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
    public class SpanishQuotesController : ControllerBase
    {
        private readonly ISpanishQManager _spanishQManager;
        public SpanishQuotesController(ISpanishQManager SQM)
        {
            _spanishQManager = SQM;
        }
        // GET: api/SpanishQuotes
        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<Spanish>>> Get()
        {
            var result = await _spanishQManager.GetAll();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        // GET: api/SpanishQuotes/5
        [HttpGet]
        public async Task<ActionResult<Spanish>> Get(string id)
        {
            if (id != null)
            {
                var item = await _spanishQManager.Get(id);
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

        // POST: api/SpanishQuotes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Spanish value)
        {
            await _spanishQManager.AddQuote(value);
            return Ok();
        }

        // PUT: api/SpanishQuotes/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/SpanishQuotes/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            if (id != null)
            {
                bool deleted = await _spanishQManager.RemoveQuote(id);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Image Doesn't exist");
            }
            return BadRequest("Insert Image Id");
        }
    }
}
