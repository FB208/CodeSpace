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
        private IMapper mapper;
        public DtoHelper(IMapper _mapper) {
            mapper = _mapper;
        }
        public PeopleDto GetDto(PhysicalAttribute physical,SocialAttribute social) {
            PeopleDto peopleDto = new PeopleDto();
            mapper.Map(social, mapper.Map(physical, peopleDto));
            return peopleDto;
        }
    }
}
