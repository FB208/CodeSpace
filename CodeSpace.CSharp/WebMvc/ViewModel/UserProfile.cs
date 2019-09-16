using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.ViewModel
{
    public class UserProfile:Profile
    {
        //添加你的实体映射关系.
        public UserProfile()
        {
            //UserInfoEntity转UserInfoDto.
            CreateMap<User, UserDto>()
            .BeforeMap((source, dto) =>
            {
                //可以较为精确的控制输出数据格式
                //dto.CreateTime = Convert.ToDateTime(source.CreateTime).ToString("yyyy-MM-dd");
                //if (string.IsNullOrEmpty(source.GetCreateTime))
                //{
                //    source.GetCreateTime = Convert.ToDateTime(source.GetCreateTime).ToString("yyyy-MM-dd");
                //}
                //dto.Role = "admin";
            })
                //指定映射字段。将UserInfo.GetCreateTime映射到UserInfoDTO.TestTime
                .ForMember(dto => dto.ID, opt => opt.MapFrom(info => info.ID))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(info => info.ID))
                .ForMember(dto => dto.Eye, opt => opt.Ignore());

            CreateMap<Head, UserDto>();
        }
    }
}
