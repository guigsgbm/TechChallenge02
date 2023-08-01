using AutoMapper;
using Shared.Models;
using WebAPI.DTOs;

namespace WebAPI.Profiles;

public class NewsProfile : Profile
{

    public NewsProfile()
    {
        CreateMap<CreateNewsDto, News>();
    }
}
