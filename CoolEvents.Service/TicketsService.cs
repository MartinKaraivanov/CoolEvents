using CoolEvents.Data.Models;
using CoolEvents.Data;
using CoolEvents.Service.Models;
using CoolEvents.Service.Mappings;
using AutoMapper;

namespace CoolEvents.Service;

public class TicketsService : ITicketsService
{
	private readonly IRepository<Ticket> _ticketRepository;
	private readonly IRepository<AppUser> _userRepository;
	private readonly IRepository<Event> _eventRepository;
	private readonly IMapper _mapper;

	public TicketsService(IRepository<Ticket> ticketRepository, IRepository<AppUser> userRepository, IRepository<Event> eventRepository, IMapper mapper)
	{
		_ticketRepository = ticketRepository;
		_userRepository = userRepository;
		_eventRepository = eventRepository;
		_mapper = mapper;
	}

	public async Task<TicketDto> CreateTicketAsync(TicketDto ticketDto)
	{
		var user = _userRepository.Retrieve(x => x.Id == ticketDto.User.Id.ToString()).SingleOrDefault();
        ArgumentNullException.ThrowIfNull(user);

        var @event = _eventRepository.Retrieve(x => x.Id == ticketDto.Event.Id).SingleOrDefault();
		ArgumentNullException.ThrowIfNull(@event);

		Ticket ticket = new Ticket { Id = Guid.NewGuid(), Event = @event, User = user };

		var newTicket = await _ticketRepository.AddAsync(ticket);

		return _mapper.Map<TicketDto>(newTicket);
	}

	public IEnumerable<TicketDto> GetAllTickets()
	{
		return _ticketRepository.RetrieveMappedTo<TicketDto>(x => true);
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
