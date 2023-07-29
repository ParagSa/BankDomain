using AutoMapper;

using Book_keeper.Models.ViewModels;

namespace Book_keeper.Profiles
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserViewModel,Book_Keeper_DomainModels.User>().ReverseMap();
        }
    }
}
