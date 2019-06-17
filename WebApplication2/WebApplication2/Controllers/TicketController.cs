using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Contracts;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
   // [Route("api/[controller]")]
   //[ApiController]
    public class TicketController : Controller
    {
        private ITicketRepository _ticketRepository;

        public TicketController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        [HttpPost]
        [Route("Ticket/Ticket/{merchId}/{empId}/{custId}")]
        public JsonResult GetTicket([FromBody]List<TicketContract> ticket, int merchId, int empId, int custId)
        {
            return Json(_ticketRepository.DoTicketing(ticket, merchId, empId, custId));
        }
        [HttpGet]
        [Route("Ticket/AllTicket/{merchId}")]
        public JsonResult AllTickets(int merchId)
        {
            return Json(_ticketRepository.GetAllTickets(merchId));
        }
        [HttpGet]
        [Route("Ticket/AllTicketLine/{merchId}")]
        public JsonResult AllTicketLine(int merchId)
        {
            return Json(_ticketRepository.GetAllTicketLine(merchId));
        }
        [HttpDelete]
        [Route("Ticket/DeleteTicket/{merchId}/{tickId}")]
        public JsonResult DeleteTicket(int merchId,int tickId)
        {
            return Json(_ticketRepository.DeleteTicket(merchId, tickId));
        }
    }
}