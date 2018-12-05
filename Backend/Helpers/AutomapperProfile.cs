using AutoMapper;
using SavingsDeposits.DTOs;
using SavingsDeposits.Entities;

namespace SavingsDeposits.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            
            
            CreateMap<SavingsDepositDTO, SavingsDeposit>();
            CreateMap<SavingsDeposit, SavingsDepositDTO>();
        }
    }
}