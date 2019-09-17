using AutoMapper;
using Common.Standard.AutoMapper9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.DemoClass.AutoMapperDemo
{
    public class DtoHelper
    {


        public PeopleDto GetDto(PhysicalAttribute physical,SocialAttribute social) {
            var peopleDto = AutoMapperHelper.Map<PeopleDto>(physical)
                .MapPart(social);
            return peopleDto;
        }
    }
}
