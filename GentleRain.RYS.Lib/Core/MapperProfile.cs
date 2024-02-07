using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<UserCreateModel, User>();
            CreateMap<User, UserCreateModel>();
            CreateMap<UserUpdateModel, User>();
            CreateMap<User, UserUpdateModel>();

            CreateMap<Position, PositionModel>();
            CreateMap<PositionModel, Position>();
            CreateMap<PositionCreateModel, Position>();
            CreateMap<Position, PositionCreateModel>();
            CreateMap<PositionUpdateModel, Position>();
            CreateMap<Position, PositionUpdateModel>();

            CreateMap<Tax, TaxModel>();
            CreateMap<TaxModel, Tax>();
            CreateMap<TaxCreateModel, Tax>();
            CreateMap<Tax, TaxCreateModel>();
            CreateMap<TaxUpdateModel, Tax>();
            CreateMap<Tax, TaxUpdateModel>();
        }
    }
}
