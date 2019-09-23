using BusinessLayer.Interface;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuotesVM.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnglishQuotesController : ControllerBase
    {
        private readonly IEnglishQManager _englishQManager;
        public EnglishQuotesController(IEnglishQManager EQM)
        {
            _englishQManager = EQM;
        }
        // GET: api/EnglishQuotes
        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<English>>> Get()
        {
            var result = await _englishQManager.GetAll();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        // GET: api/EnglishQuotes/5
        [HttpGet]
        public async Task<ActionResult<English>> Get(string id)
        {
            if(id != null)
            {
                var item = await _englishQManager.Get(id);
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

        // POST: api/EnglishQuotes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]English value)
        {
            await _englishQManager.AddQuote(value);
            return Ok();
        }

        //// PUT: api/EnglishQuotes/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/EnglishQuotes/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            if (id != null)
            {
                bool deleted = await _englishQManager.RemoveQuote(id);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Image Doesn't exist");
            }
            return BadRequest("Insert Image Id");
        }
    }
}
