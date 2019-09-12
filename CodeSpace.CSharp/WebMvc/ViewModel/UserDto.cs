using Common.Standard.AutoMapper9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.ViewModel
{
    [AutoInject(sourceType:typeof(User),targetType: typeof(UserDto))]
    public class UserDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
