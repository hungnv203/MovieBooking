using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Movie.Dtos;

namespace WS.Movie.ApplicationService.Service.Abstract
{
    public interface ITicketService
    {
        Task<TicketDto> CreateTicketAsync(CreateTicketDto createTicketDto);
        Task<List<TicketDto>> GetAllTicketsAsync();
        Task<TicketDto> GetTicketByIdAsync(int ticketId);
    }
}
