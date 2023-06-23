using AutoMapper;
using CoolEvents.Data.Models;
using CoolEvents.Data.Repositories;
using CoolEvents.Service.Models;

namespace CoolEvents.Service;

public class TicketsService : ITicketsService
{
	private readonly IRepository<Ticket> _ticketRepository;
	private readonly IMapper _mapper;

	public TicketsService(IRepository<Ticket> ticketRepository, IMapper mapper)
	{
		_ticketRepository = ticketRepository;
		_mapper = mapper;
	}

	public async Task<TicketDto> CreateTicketAsync(TicketDto ticketDto)
	{
		var ticket = new Ticket { Id = Guid.NewGuid(), EventId = ticketDto.Event.Id, UserId = ticketDto.User.Id};

		var newTicket = await _ticketRepository.AddAsync(ticket);

		return _mapper.Map<TicketDto>(newTicket);
	}

	public IEnumerable<TicketDto> GetAllTickets()
	{
		return _ticketRepository.RetrieveMappedTo<TicketDto>(x => true);
	}

	public int GetNumberOfTickets()
	{
		return _ticketRepository.Count();
	}

    public TicketDto GetTicketById(Guid id)
    {
        var ticket = _ticketRepository.RetrieveMappedTo<TicketDto>(x => x.Id == id).SingleOrDefault();

        ArgumentNullException.ThrowIfNull(ticket);

        return ticket;
    }

    public IEnumerable<TicketDto> GetTicketsByUserId(Guid id)
	{
		return _ticketRepository.RetrieveMappedTo<TicketDto>(x => x.User.Id == id.ToString());
	}

	public async Task DeleteTicketAsync(Guid id)
	{
		var ticket = _ticketRepository.Retrieve(x => x.Id == id).SingleOrDefault();

		if (ticket == null)
		{
			throw new ArgumentException("Does not exist");
		}

		await _ticketRepository.RemoveAsync(ticket);
	}
}
