using CoolEvents.Service.Models;

namespace CoolEvents.Service;

public interface ITicketsService
{
	Task<TicketDto> CreateTicketAsync(TicketDto ticketDto);
	IEnumerable<TicketDto> GetAllTickets();
    TicketDto GetTicketById(Guid id);
	int GetNumberOfTickets();
    IEnumerable<TicketDto> GetTicketsByUserId(Guid id);
	Task DeleteTicketAsync(Guid id);
}
