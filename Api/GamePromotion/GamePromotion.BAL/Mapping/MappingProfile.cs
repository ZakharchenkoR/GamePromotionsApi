using AutoMapper;
using GamePromotion.BAL.Enums;
using GamePromotion.BAL.Models;
using GamePromotion.DAL.Entities;

namespace GamePromotion.BAL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Offer, OfferModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.StartsAt, opt => opt.MapFrom(src => src.startsat))
            .ForMember(dest => dest.ExpiresAt, opt => opt.MapFrom(src => src.expiresat))
            .ForMember(dest => dest.OfferType, opt => opt.MapFrom(src => (OfferTypes)src.offertype)).ReverseMap();

            CreateMap<Offer, AddOfferModel>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
           .ForMember(dest => dest.StartsAt, opt => opt.MapFrom(src => src.startsat))
           .ForMember(dest => dest.ExpiresAt, opt => opt.MapFrom(src => src.expiresat))
           .ForMember(dest => dest.OfferType, opt => opt.MapFrom(src => (OfferTypes)src.offertype)).ReverseMap();

            CreateMap<Event, EventModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.StartsAt, opt => opt.MapFrom(src => src.startsat))
            .ForMember(dest => dest.ExpiresAt, opt => opt.MapFrom(src => src.expiresat))
            .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => (EventTypes)src.eventtype)).ReverseMap();

            CreateMap<Event, AddEventModel>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
           .ForMember(dest => dest.StartsAt, opt => opt.MapFrom(src => src.startsat))
           .ForMember(dest => dest.ExpiresAt, opt => opt.MapFrom(src => src.expiresat))
           .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => (EventTypes)src.eventtype)).ReverseMap();
        }
    }
}
