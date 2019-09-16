using Common.Standard.AutoMapper9;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.ViewModel
{
    public class UserDtoHelper
    {
        public UserDto GetDto()
        {
            User tuser = new User()
            {
                ID = 1,
                Name = "张三"
            };
            Head head = new Head()
            {
                Eye = "眼"
            };
            UserDto nuser = new UserDto();
            //nuser = tuser.MapTo<UserDto>();
            nuser = AutoMapperHelper.Map<UserDto>(tuser)
                .MapPart(head);
            //UserDto nuser = new UserDto() { ID=1};

            return nuser;
        }
    }
}
