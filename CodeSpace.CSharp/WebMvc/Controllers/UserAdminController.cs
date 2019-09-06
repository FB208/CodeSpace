using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.IBLL.BBSAdmin;
using WebMvc.BLLContainer;
using WebMvc.Model.BBSAdmin;
using WebMvc.ViewModel;

namespace WebMvc.Controllers
{
    public class UserAdminController : BaseController
    {

        //private readonly IUserTableService _userTableService;
        //public UserAdminController(IUserTableService Context)
        //{
        //    _userTableService = Context;
        //}
        //private IUserTableService _userTableService = BLLContainer.Container.Resolve<IUserTableService>();
        public IActionResult Index()
        {
            List<UserAdminVM> list = new UserAdminVM().GetList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}