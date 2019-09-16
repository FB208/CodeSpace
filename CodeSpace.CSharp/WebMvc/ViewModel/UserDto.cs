﻿using Common.Standard.AutoMapper9;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Model.BBSAdmin;

namespace WebMvc.ViewModel
{
    [AutoInject(sourceType:typeof(User),targetType: typeof(UserDto))]
    public class UserDto
    {
        public UserDto() { }

        public int ID { get; set; }

        public string Name { get; set; }
        //public string RoleFlags { get; set; }
        public string Eye { get; set; }

    }
}
