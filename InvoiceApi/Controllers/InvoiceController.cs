using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceApp.Core;
using InvoiceApp.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace InvoiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class InvoiceController : ControllerBase
    {
        InvoiceManager invManager;

        public InvoiceController(InvoiceManager manager)
        {
            invManager = manager;
        }

        // GET: api/Invoice
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //TODO when we implement auth
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async  Task<ActionResult<IEnumerable<Invoice>>> GetListByStatus(int status)
        {
            try
            {
                InvoiceStatus invStatus;
                if (Enum.TryParse<InvoiceStatus>(status.ToString(), out invStatus))
                {
                   var invoices = await invManager.GetList(status);
                    return Ok(invoices);
                }
                else
                {
                    return BadRequest("Invalid Status");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        // GET: api/Invoice/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Invoice>> GetAsync(string id)
        {
            Invoice inv = await invManager.GetByIdAsync(id);
            return inv;
        }

        // POST: api/Invoice
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Invoice>> PostAsync([FromBody] Invoice invoice)
        {
            try
            {
                string id = await invManager.AddAsync(invoice);
                return Created("", id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        // PUT: api/Invoice/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Invoice>> Put(string id, [FromBody] Invoice invoice)
        {
            try
            {
                if (await invManager.UpdateAsync(id, invoice))
                {
                    return Ok(invoice);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
