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
    public class FrenchQuotesController : ControllerBase
    {
        private readonly IFrenchQManager _frenchQManager;
        public FrenchQuotesController(IFrenchQManager FQM)
        {
            _frenchQManager = FQM;
        }
        // GET: api/FrenchQuotes
        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<French>>> Get()
        {
            var result = await _frenchQManager.GetAll();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        // GET: api/FrenchQuotes/5
        [HttpGet]
        public async Task<ActionResult<French>> Get(string id)
        {
            if (id != null)
            {
                var item = await _frenchQManager.Get(id);
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

        // POST: api/FrenchQuotes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]French value)
        {
            await _frenchQManager.AddQuote(value);
            return Ok();
        }

        // PUT: api/FrenchQuotes/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/FrenchQuotes/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            if (id != null)
            {
                bool deleted = await _frenchQManager.RemoveQuote(id);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Image Doesn't exist");
            }
            return BadRequest("Insert Image Id");
        }
    }
}
