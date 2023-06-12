using AutoMapper;
using GamePromotion.BAL.Models;
using GamePromotion.DAL.Entities;
using GamePromotion.DAL.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamePromotion.BAL.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<EventService> _logger;

        public EventService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<EventService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<EventModel> AddEvent(AddEventModel evnt)
        {
            var newEvent = _mapper.Map<Event>(evnt);
            await _unitOfWork.EventRepository.AddEvent(newEvent);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation($"Event with id:{newEvent.id} was successfully created");
            return _mapper.Map<EventModel>(newEvent);
        }

        public async Task<IEnumerable<EventModel>> GetEvents()
        {
            var result = await _unitOfWork.EventRepository.GetAllEvents();
            return _mapper.Map<IEnumerable<EventModel>>(result);
        }
    }
}
