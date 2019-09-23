using BusinessLayer.Interface;
using BusinessLayer.Manager;
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
    public class ArabicQuotesController : ControllerBase
    {
        private readonly IArabicQManager _arabicQManager;
        public ArabicQuotesController(IArabicQManager AQM)
        {
            _arabicQManager = AQM;
        }
        // GET api/values
        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<Arabic>>> Get()
        {
            var result = await _arabicQManager.GetAll();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        // GET api/values/5
        [HttpGet]
        public async Task<ActionResult<Arabic>> Get(string id)
        {
            if (id != null)
            {
                var result = await _arabicQManager.Get(id);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest("Id Not Found");
            }
            return BadRequest("please Enter Id");
        }

        // POST api/values
        //Create
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Arabic value)
        {
            await _arabicQManager.AddQuote(value);
            return Ok();
        }

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            if (id != null)
            {
                bool deleted = await _arabicQManager.RemoveQuote(id);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Image Doesn't exist");
            }
            return BadRequest("Insert Image Id");
        }
    }

}