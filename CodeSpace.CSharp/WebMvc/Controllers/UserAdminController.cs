using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.IBLL.BBSAdmin;
using WebMvc.BLLContainer;
using WebMvc.Model.BBSAdmin;

namespace WebMvc.Controllers
{
    public class UserAdminController : BaseController
    {

        //private readonly IUserTableService _userTableService;
        //public UserAdminController(IUserTableService Context)
        //{
        //    _userTableService = Context;
        //}
        private IUserTableService _userTableService = BLLContainer.Container.Resolve<IUserTableService>();
        public IActionResult Index()
        {
            List<UserTable> list = _userTableService.GetModels(m => true).ToList();
            return View(list);
        }
    }
}