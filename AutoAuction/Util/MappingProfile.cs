using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoAuction.DAL.Entities;
using AutoAuction.DTO;
using AutoAuction.Models;
using AutoMapper;

namespace AutoAuction.Util
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //LotMap
            Mapper.CreateMap<Lot, LotViewModel>();
            Mapper.CreateMap<Lot, CustomerLotViewModel>();
            Mapper.CreateMap<CreateLotViewModel,Lot>();
            Mapper.CreateMap<Lot, UpdateLotViewModel>();
            Mapper.CreateMap<UpdateLotViewModel, Lot>();
           
            //CustomerLotMap 
            Mapper.CreateMap<CreateCustomerLotDTO, CustomerLot>();
            Mapper.CreateMap<UpdateCustomerLotDTO, CustomerLot>();      
            Mapper.CreateMap<CustomerLot, CustomerLotDTO>()
                .ForMember("LotName", opt => opt.MapFrom(src => src.Lot.LotName))
                .ForMember("LotImageUrl", opt => opt.MapFrom(src => src.Lot.LotImageUrl))
                .ForMember("StarLotSaleDate", opt => opt.MapFrom(src => src.Lot.StarLotSaleDate))
                .ForMember("EndLotSaleDate", opt => opt.MapFrom(src => src.Lot.EndLotSaleDate))
                .ForMember("StartLotPrice", opt => opt.MapFrom(src => src.Lot.StartLotPrice))
                .ForMember("CurrentPrice", opt => opt.MapFrom(src => src.Lot.CurrentPrice))
                .ForMember("IsSold", opt => opt.MapFrom(src => src.Lot.IsSold));  
             
            //LoginMap
            Mapper.CreateMap<LoginViewModel, Customer>();

            //RegisterMap
            Mapper.CreateMap<RegisterViewModel, Customer>();
        }
    }
}