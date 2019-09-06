using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceApp.Core;
using InvoiceApp.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
namespace InvoiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class InvoiceController : ControllerBase
    {
        private const string ClientRefreshSignal = "RefreshInvoiceList";
        InvoiceManager _invManager;
        readonly IHubContext<SignalRHandler> _hubContext;
        public InvoiceController(InvoiceManager manager, IHubContext<SignalRHandler> hubContext)
        {
            _invManager = manager;
            _hubContext = hubContext;
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
                if (Enum.TryParse(status.ToString(), out InvoiceStatus invStatus))
                {
                    IEnumerable<Invoice> invoices = await _invManager.GetList(status);
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
            Invoice inv = await _invManager.GetByIdAsync(id);
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
                string id = await _invManager.AddAsync(invoice);
                await _hubContext.Clients.All.SendAsync(ClientRefreshSignal);
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
                if (await _invManager.UpdateAsync(id, invoice))
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
