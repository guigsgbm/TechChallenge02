﻿using AutoMapper;
using WebAPI.DTOs;

namespace WebAPI.Profiles;

public class NoticeProfile : Profile
{

    public NoticeProfile()
    {
        CreateMap<CreateNoticeDto, Notice>();
    }
}
