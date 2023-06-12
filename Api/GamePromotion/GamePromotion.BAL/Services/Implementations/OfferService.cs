using AutoMapper;
using GamePromotion.BAL.Models;
using GamePromotion.DAL.Entities;
using GamePromotion.DAL.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamePromotion.BAL.Services.Implementations
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<OfferService> _logger;

        public OfferService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<OfferService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OfferModel> AddOffer(AddOfferModel offer)
        {
            var newOffer = _mapper.Map<Offer>(offer);
            await _unitOfWork.OfferRepository.AddOffer(newOffer);
            await _unitOfWork.SaveAsync();
            _logger.LogError($"Offer with id:{newOffer.id} was successfully created");
            return _mapper.Map<OfferModel>(newOffer);
        }

        public async Task<IEnumerable<OfferModel>> GetOffers()
        {
            var offers = await _unitOfWork.OfferRepository.GetAllOffers();
            return _mapper.Map<IEnumerable<OfferModel>>(offers);
        }
    }
}
